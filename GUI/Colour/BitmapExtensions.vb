Imports System.Runtime.CompilerServices
Imports GUI.Colour.Conversions
Imports GUI.Data

Namespace Colour
    Public Module BitmapExtensions
        <Extension()>
        Public Function GetPixelAsColourRGB(bitmap As Bitmap, x As Integer, y As Integer) As ColourRGB
            Return New ColourRGB(bitmap.GetPixel(x, y))
        End Function

        <Extension()>
        Public Sub SetPixelFromColourRGB(bitmap As Bitmap, x As Integer, y As Integer, colour As ColourRGB)
            bitmap.SetPixel(x, y, colour.ToColor())
        End Sub
    End Module
End NameSpace