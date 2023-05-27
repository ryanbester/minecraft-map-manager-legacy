
Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Forms.VisualStyles
Imports MinecraftMapManager.Colour
Imports MinecraftMapManager.Colour.Conversions
Imports MinecraftMapManager.Colour.Difference
Imports MinecraftMapManager.Colour.Dithering

Namespace Data
    Public Class MapImage
        Public Dim Image As Bitmap
        Public Dim RawImage As Bitmap

        ' Whether to show an outline where the image will be placed. False if the image has been converted.
        Public Dim RenderPreview As Boolean = True

        Public Dim X As Integer
        Public Dim Y As Integer
        Public Dim Width As Integer
        Public Dim Height As Integer

        Public Dim ProcessSettings As MapImageSettings

        Public Function AddImage() As Bitmap
            Using openFileDialog = New OpenFileDialog()
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                openFileDialog.Filter =
                    "Image files (*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpg;*.jpeg;*.png;*.tiff;*.tif;*.wmf)|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpg;*.jpeg;*.png;*.tiff;*.tif;*.wmf|All files (*.*)|*.*"
                openFileDialog.Title = "Open Image"

                If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    RawImage = New Bitmap(openFileDialog.FileName)
                    RenderPreview = True
                    Return RawImage
                End If

                Return Nothing
            End Using
        End Function

        Public Delegate Sub DitherProgress(i As Integer, worker As BackgroundWorker)

        Private Sub ReportDitherProgress(i As Integer, worker As BackgroundWorker)
            worker.ReportProgress(Math.Round((i/Image.Width)*70),
                                  "Converting to limited colour palette...")
        End Sub

        Public Function ProcessImage(worker As BackgroundWorker) As Bitmap
            ' Scale with interpolation mode
            Dim scaledBitmap = New Bitmap(Width, Height)
            Dim gr = Graphics.FromImage(scaledBitmap)
            gr.InterpolationMode = ProcessSettings.InterpolationMode()
            gr.DrawImage(rawImage, 0, 0, CInt(Width), CInt(Height))

            Image = New Bitmap(Width, Height)

            worker.ReportProgress(0, "Loading colour palette...")

            ' Clear ready for difference calculations
            ColourCache.Clear()

            Dim colourDiffMode As IColourDifference
            Select Case ProcessSettings.ColourDifference
                Case MapImageColourDifference.Euclidean
                    ColourCache.LoadRgbColourPalette(ProcessSettings)
                    colourDiffMode = New Euclidean()
                Case MapImageColourDifference.CIE76
                    ColourCache.LoadLabColourPalette(ProcessSettings)
                    colourDiffMode = New CIE76(ProcessSettings.WorkingSpace)
                Case MapImageColourDifference.CIE94
                    ColourCache.LoadLabColourPalette(ProcessSettings)
                    colourDiffMode = New CIE94(ProcessSettings.WorkingSpace)
                Case Else
                    Return Nothing
            End Select

            Dim colorDiffPercent = 70

            Dim colourDitherMode As IDither = Nothing
            Select Case ProcessSettings.Dithering
                Case MapImageDithering.FloydSteinberg
                    colourDitherMode = New FloydSteinberg(colourDiffMode, worker, AddressOf ReportDitherProgress)
            End Select

            worker.ReportProgress(0, "Converting to limited colour palette...")

            If colourDitherMode IsNot Nothing
                ' Dither
                Image = colourDitherMode.CalculateDither(scaledBitmap)
            Else
                ' Use plain colour difference algorithm
                For i = 0 To Width - 1
                    worker.ReportProgress(Math.Round((i/Width)*colorDiffPercent),
                                          "Converting to limited colour palette...")
                    For j = 0 To Height - 1
                        Dim colourRgb = New ColourRGB(scaledBitmap.GetPixel(i, j))

                        Dim nearestColour = colourDiffMode.GetClosestColour(colourRgb)
                        Image.SetPixel(i, j, CType(nearestColour, ColourRGB).ToColor())
                    Next
                Next
            End If

            Return Image
        End Function

        Public Sub ConvertToLayer(ByRef layer As Byte(), worker As BackgroundWorker)
            Dim convertPercent = 30

            worker.ReportProgress(100 - convertPercent, "Converting to Minecraft colours...")

            ' Reset layer
            Memset (Of Byte)(layer, 0, layer.Length)

            For i = 0 To Image.Width - 1
                worker.ReportProgress((100 - convertPercent) + Math.Round((i/Image.Width)*convertPercent),
                                      "Converting to Minecraft colours...")
                For j = 0 To Image.Height - 1
                    Dim colour = MapColours.GetMapColour(New ColourRGB(Image.GetPixel(i, j)))
                    MapColours.SetPixel(layer, X + i, Y + j, colour)
                Next
            Next

            RenderPreview = False
        End Sub
    End Class
End NameSpace