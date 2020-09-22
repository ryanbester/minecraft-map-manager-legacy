
Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles
Imports MinecraftMapManager.Colour
Imports MinecraftMapManager.Colour.Conversions
Imports MinecraftMapManager.Colour.Difference

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
                Case Else
                    Return Nothing
            End Select

            Dim colorDiffPercent = 70
            Dim colorDitherPercent = 0

            If Not ProcessSettings.Dithering = MapImageDithering.None Then
                colorDiffPercent = 40
                colorDitherPercent = 20
            End If

            For i = 0 To Width - 1
                worker.ReportProgress(Math.Round((i / Width) * colorDiffPercent), "Converting to colour palette...")
                For j = 0 To Height - 1
                    Dim colourRgb = New ColourRGB(scaledBitmap.GetPixel(i, j))

                    Dim nearestColour As ColourRGB? = ColourCache.GetValue(colourRgb)
                    If nearestColour IsNot Nothing Then
                        Image.SetPixel(i, j, CType(nearestColour, ColourRGB).ToColor())
                    Else
                        Dim lowest As ColourRGB
                        Dim lowestValue As Double = 100000
                        For Each color As ColourRGB In ColourCache.RgbColourPalette
                            Dim value = colourDiffMode.CalculateDifference(color, colourRgb)
                            If value < lowestValue Then
                                lowestValue = value
                                lowest = color
                            End If
                        Next
                        ColourCache.Add(colourRgb, lowest)
                        Image.SetPixel(i, j, lowest.ToColor())
                    End If
                Next
            Next

            ' TODO: Dither

            Return Image
        End Function

        Public Sub ConvertToLayer(ByRef layer As Byte(), worker As BackgroundWorker)
            Dim convertPercent = 30

            If Not ProcessSettings.Dithering = MapImageDithering.None
                convertPercent = 20
            End If

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