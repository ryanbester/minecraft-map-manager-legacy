Imports MinecraftMapManager.Colour.Conversions

Namespace Colour
    Public Class ColourCache
        Public Shared Dim RgbColourPalette As List(Of ColourRGB) = New List(Of ColourRGB)
        Public Shared Dim LabColourPalette As List(Of ColourLAB) = New List(Of ColourLAB)
        Public Shared Dim LchAbColourPalette As List(Of ColourLCHab) = New List(Of ColourLCHab)()

        Private Shared ReadOnly Dim _
            Cache As Dictionary(Of ColourRGB, ColourRGB) = New Dictionary(Of ColourRGB, ColourRGB)

        Public Shared Sub Add(key As ColourRGB, value As ColourRGB)
            If Cache.ContainsKey(key)
                Return
            End If

            Cache.Add(key, value)
        End Sub

        Public Shared Function GetValue(key As ColourRGB) As ColourRGB?
            If Not Cache.ContainsKey(key)
                Return Nothing
            End If

            Return Cache(key)
        End Function

        Public Shared Sub Clear()
            Cache.Clear()
        End Sub

        Public Shared Sub LoadRgbColourPalette(settings As MapImageSettings)
            If RgbColourPalette.Count = 0
                For Each color As Color In Data.MapColours.ColourTable
                    If color.A = 0
                        ' Do not allow transparency
                        Continue For
                    End If
                    
                    For Each colorVariant As Double In Data.MapColours.VariantTable
                        Dim colourRgb = New ColourRGB(color.R*colorVariant, color.G*colorVariant, color.B*colorVariant)
                        RgbColourPalette.Add(colourRgb)
                    Next
                Next
            End If
        End Sub

        Public Shared Sub LoadLabColourPalette(settings As MapImageSettings)
            If LabColourPalette.Count = 0
                For Each color As Color In Data.MapColours.ColourTable
                    If color.A = 0
                        ' Do not allow transparency
                        Continue For
                    End If
                    
                    For Each colorVariant As Double In Data.MapColours.VariantTable
                        Dim colourRgb = New ColourRGB(color.R*colorVariant, color.G*colorVariant, color.B*colorVariant)
                        LabColourPalette.Add(colourRgb.ToLAB(settings.WorkingSpace))
                    Next
                Next
            End If
        End Sub
        
        Public Shared Sub LoadLchAbColourPalette(settings As MapImageSettings)
            If LchAbColourPalette.Count = 0
                For Each color As Color In Data.MapColours.ColourTable
                    If color.A = 0
                        ' Do not allow transparency
                        Continue For
                    End If
                    
                    For Each colorVariant As Double In Data.MapColours.VariantTable
                        Dim colourRgb = New ColourRGB(color.R*colorVariant, color.G*colorVariant, color.B*colorVariant)
                        LchAbColourPalette.Add(colourRgb.ToLCHab(settings.WorkingSpace))
                    Next
                Next
            End If
        End Sub 
    End Class
End NameSpace