Imports MinecraftMapManager.Colour.Conversions

Namespace Colour
    Public Class ColourCache
        Public Dim LabColourPalette As List(Of ColourLAB) = New List(Of ColourLAB)

        Private Shared ReadOnly Dim Cache As Dictionary(Of ColourRGB, ColourRGB) = New Dictionary(Of ColourRGB, ColourRGB)

        Public Shared Sub Add(key As ColourRGB, value As ColourRGB)
            If Cache.ContainsKey(key)
                Return
            End If
            
            Cache.Add(key, value)
        End Sub
        
        Public Shared Function GetValue(key As ColourRGB) As ColourRGB
            If Not Cache.ContainsKey(key)
                Return Nothing
            End If
            
            Return Cache(key)
        End Function
        
        Public Shared Sub Clear()
            Cache.Clear()
        End Sub
    End Class
End NameSpace