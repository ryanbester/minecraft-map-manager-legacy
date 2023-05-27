Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports fNbt
Imports GUI.Colour.Conversions

Namespace Data
    Public Class MapColours
        Public Shared ReadOnly VariantTable = New Double(3) {0.71, 0.86, 1.0, 0.53}

        Public Shared ReadOnly ColourTable = New List(Of Color) From
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

        Public Shared ReadOnly ColourNames = New List(Of String) From
            {
            "0 NONE", "1 GRASS", "2 SAND", "3 WOOL", "4 FIRE", "5 ICE", "6 METAL", "7 PLANT", "8 SNOW", "9 CLAY",
            "10 DIRT", "11 STONE", "12 WATER", "13 WOOD", "14 QUARTZ", "15 COLOR_ORANGE", "16 COLOR_MAGENTA",
            "17 COLOR_LIGHT_BLUE", "18 COLOR_YELLOW", "19 COLOR_LIGHT_GREEN", "20 COLOR_PINK", "21 COLOR_GRAY",
            "22 COLOR_LIGHT_GRAY", "23 COLOR_CYAN", "24 COLOR_PURPLE", "25 COLOR_BLUE", "26 COLOR_BROWN",
            "27 COLOR_GREEN", "28 COLOR_RED", "29 COLOR_BLACK", "30 GOLD", "31 DIAMOND", "32 LAPIS", "33 EMERALD",
            "34 PODZOL", "35 NETHER", "36 TERRACOTTA_WHITE", "37 TERRACOTTA_ORANGE", "38 TERRACOTTA_MAGENTA",
            "39 TERRACOTTA_LIGHT_BLUE", "40 TERRACOTTA_YELLOW", "41 TERRACOTTA_LIGHT_GREEN", "42 TERRACOTTA_PINK",
            "43 TERRACOTTA_GRAY", "44 TERRACOTTA_LIGHT_GRAY", "45 TERRACOTTA_CYAN", "46 TERRACOTTA_PURPLE",
            "47 TERRACOTTA_BLUE", "48 TERRACOTTA_BROWN", "49 TERRACOTTA_GREEN", "50 TERRACOTTA_RED",
            "51 TERRACOTTA_BLACK", "52 CRIMSON_NYLIUM", "53 CRIMSON_STEM", "54 CRIMSON_HYPHAE", "55 WARPED_NYLIUM",
            "56 WARPED_STEM", "57 WARPED_HYPHAE", "58 WARPED_WART_BLOCK"
            }

        Private Shared ReadOnly Dim ColourCache As Dictionary(Of ColourRGB, Byte) = New Dictionary(Of ColourRGB, Byte)

        Public Shared Function CreateBitmapFromMap(colours As Byte()) As Bitmap
            Try
                Dim bitmap = New Bitmap(128, 128)

                For i = 0 To colours.Count - 1
                    Dim colour = colours(i)

                    Dim row = Math.Floor(i/128)
                    Dim column = i - (row*128)

                    Dim rgbColour = GetRgbColour(colour)
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

        Public Shared Function GetRgbColour(colour As Byte)
            Dim base = Math.Floor(colour/4)
            Dim variation = colour Mod 4

            Dim multiplier = VariantTable(variation)
            Dim baseColour = ColourTable(base)
            Dim rgbColour = Color.FromArgb(baseColour.A, baseColour.R*multiplier, baseColour.G*multiplier,
                                           baseColour.B*multiplier)
            Return rgbColour
        End Function

        Public Shared Function GetMapColour(colour As ColourRGB) As Byte
            Dim byteColour As Byte? = CacheGetValue(colour)
            If byteColour IsNot Nothing Then
                Return byteColour
            End If

            Dim color = colour.ToColor()

            Dim base = 0, colorVariant = 0
            For i = 0 To VariantTable.Length - 1
                Dim multiplier = VariantTable(i)

                Dim R = color.R/multiplier
                Dim G = color.G/multiplier
                Dim B = color.B/multiplier

                If (R > 255) Or (G > 255) Or (B > 255) Then
                    Continue For
                End If

                If (R < 0) Or (G < 0) Or (B < 0) Then
                    Continue For
                End If

                Dim baseColor = Color.FromArgb(color.A, color.R/multiplier, color.G/multiplier,
                                               color.B/multiplier)
                For j = 0 To ColourTable.Count - 1
                    If ColourTable(j).A = 0
                        ' Do not allow transparency
                        Continue For
                    End If
                    If ColourTable(j).Equals(baseColor) Then
                        base = j
                        colorVariant = i
                    End If
                Next
            Next

            CacheAdd(colour, base*4 + colorVariant)

            Return base*4 + colorVariant
        End Function

        Public Shared Sub CacheAdd(key As ColourRGB, value As Byte)
            If ColourCache.ContainsKey(key)
                Return
            End If

            ColourCache.Add(key, value)
        End Sub

        Public Shared Function CacheGetValue(key As ColourRGB) As Byte?
            If Not ColourCache.ContainsKey(key)
                Return Nothing
            End If

            Return ColourCache(key)
        End Function

        Public Shared Sub Clear()
            ColourCache.Clear()
        End Sub

        Public Shared Function CombineLayers(bottom As Byte(), top As Byte()) As Byte()
            Dim newLayer = bottom.Clone()

            For i = 0 To top.Length - 1
                If top(i) < 255 Then
                    newLayer(i) = top(i)
                End If
            Next

            Return newLayer
        End Function

        Public Shared Sub SetPixel(ByRef layer As Byte(), x As Integer, y As Integer, colour As Byte)
            Dim pos = (y*128) + x

            If pos > - 1 And pos < layer.Length Then
                layer(pos) = colour
            End If
        End Sub
    End Class
End Namespace