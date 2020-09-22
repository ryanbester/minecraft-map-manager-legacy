Imports MinecraftMapManager.Colour.Conversions

Namespace Colour.Difference
    Public Class Euclidean
        Implements IColourDifference

        Public Function CalculateDifference(colour1 As IColour, colour2 As IColour) As Double _
            Implements IColourDifference.CalculateDifference

            If Not colour1.GetColourType() = "RGB" Or Not colour2.GetColourType() = "RGB"
                Return Nothing
            End If
            
            Dim colour1New = CType(colour1, ColourRGB)
            Dim colour2New = CType(colour2, ColourRGB)

            Dim r = (colour1New.R - colour2New.R)^2
            Dim g = (colour1New.G - colour2New.G)^2
            Dim b = (colour1New.B - colour2New.B)^2

            Return (r + g + b)
        End Function
    End Class
End NameSpace