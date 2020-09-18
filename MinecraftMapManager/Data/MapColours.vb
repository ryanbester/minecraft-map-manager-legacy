Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports fNbt

Namespace Data
    Public Class MapColours
        Private Shared ReadOnly Dim VariantTable = New Double(3) {0.71, 0.86, 1.0, 0.53}

        Private Shared ReadOnly Dim ColourTable = New List(Of Color) From
            {
            Color.FromArgb(0, 255, 255, 255),
            Color.FromArgb(255, 127, 178, 56),
            Color.FromArgb(255, 247, 233, 163),
            Color.FromArgb(255, 199, 199, 199),
            Color.FromArgb(255, 255, 0, 0),
            Color.FromArgb(255, 160, 160, 255),
            Color.FromArgb(255, 167, 167, 167),
            Color.FromArgb(255, 0, 124, 0),
            Color.FromArgb(255, 255, 255, 255),
            Color.FromArgb(255, 164, 168, 184),
            Color.FromArgb(255, 151, 109, 77),
            Color.FromArgb(255, 112, 112, 112),
            Color.FromArgb(255, 64, 64, 255),
            Color.FromArgb(255, 143, 119, 72),
            Color.FromArgb(255, 255, 252, 245),
            Color.FromArgb(255, 216, 127, 51),
            Color.FromArgb(255, 178, 76, 216),
            Color.FromArgb(255, 102, 153, 216),
            Color.FromArgb(255, 229, 229, 51),
            Color.FromArgb(255, 127, 204, 25),
            Color.FromArgb(255, 242, 127, 165),
            Color.FromArgb(255, 76, 76, 76),
            Color.FromArgb(255, 153, 153, 153),
            Color.FromArgb(255, 76, 127, 153),
            Color.FromArgb(255, 127, 63, 178),
            Color.FromArgb(255, 51, 76, 178),
            Color.FromArgb(255, 102, 76, 51),
            Color.FromArgb(255, 102, 127, 51),
            Color.FromArgb(255, 153, 51, 51),
            Color.FromArgb(255, 25, 25, 25),
            Color.FromArgb(255, 250, 238, 77),
            Color.FromArgb(255, 92, 219, 213),
            Color.FromArgb(255, 74, 128, 255),
            Color.FromArgb(255, 0, 217, 58),
            Color.FromArgb(255, 129, 86, 49),
            Color.FromArgb(255, 112, 2, 0),
            Color.FromArgb(255, 209, 177, 161),
            Color.FromArgb(255, 159, 82, 36),
            Color.FromArgb(255, 149, 87, 108),
            Color.FromArgb(255, 112, 108, 138),
            Color.FromArgb(255, 186, 133, 36),
            Color.FromArgb(255, 103, 117, 53),
            Color.FromArgb(255, 160, 77, 78),
            Color.FromArgb(255, 57, 41, 35),
            Color.FromArgb(255, 135, 107, 98),
            Color.FromArgb(255, 87, 92, 92),
            Color.FromArgb(255, 122, 73, 88),
            Color.FromArgb(255, 76, 62, 92),
            Color.FromArgb(255, 76, 50, 35),
            Color.FromArgb(255, 76, 82, 42),
            Color.FromArgb(255, 142, 60, 46),
            Color.FromArgb(255, 37, 22, 16),
            Color.FromArgb(255, 189, 48, 49),
            Color.FromArgb(255, 148, 63, 97),
            Color.FromArgb(255, 92, 25, 29),
            Color.FromArgb(255, 22, 126, 134),
            Color.FromArgb(255, 58, 142, 140),
            Color.FromArgb(255, 86, 44, 62),
            Color.FromArgb(255, 20, 180, 133)
            }

        Public Shared Function CreateBitmapFromMap(colours As Byte()) As Bitmap
            Try
                Dim bitmap = New Bitmap(128, 128)

                For i = 0 To colours.Count - 1
                    Dim colour = colours(i)

                    Dim row = Math.Floor(i/128)
                    Dim column = i - (row*128)

                    Dim base = Math.Floor(colour/4)
                    Dim variation = colour Mod 4

                    Dim multiplier = VariantTable(variation)
                    Dim baseColour = ColourTable(base)
                    Dim rgbColour = Color.FromArgb(baseColour.A, baseColour.R*multiplier, baseColour.G*multiplier,
                                                   baseColour.B*multiplier)
                    bitmap.SetPixel(column, row, rgbColour)
                Next

                Return bitmap
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Shared Function CreateHeightmapFromMap(colours As Byte()) As Bitmap
            Try
                Dim bitmap = New Bitmap(128, 128)

                For i = 0 To colours.Count - 1
                    Dim colour = colours(i)

                    Dim row = Math.Floor(i/128)
                    Dim column = i - (row*128)

                    Dim variation = colour Mod 4

                    Dim multiplier = VariantTable(variation)
                    Dim rgbColour = Color.FromArgb(255, 255*multiplier, 255*multiplier,
                                                   255*multiplier)
                    bitmap.SetPixel(column, row, rgbColour)
                Next

                Return bitmap
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Shared Function UpscaleBitmap(bitmap As Bitmap, scale As Double) As Bitmap
            Dim upscaledBitmap = New Bitmap(512, 512)
            Dim gr = Graphics.FromImage(upscaledBitmap)
            gr.InterpolationMode = InterpolationMode.NearestNeighbor
            gr.DrawImage(bitmap, 0, 0, CInt(bitmap.Width*scale), CInt(bitmap.Height*scale))
            Return upscaledBitmap
        End Function
    End Class
End NameSpace