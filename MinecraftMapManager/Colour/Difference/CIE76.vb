Imports MinecraftMapManager.Colour.Conversions

Namespace Colour.Difference
    Public Class CIE76
        Implements IColourDifference

        Private _workingSpace As WorkingSpace.WorkingSpace

        Sub New(workingSpace As WorkingSpace.WorkingSpace)
            _workingSpace = workingSpace
        End Sub

        Public Function CalculateDifference(colour1 As IColour, colour2 As IColour) As Double _
            Implements IColourDifference.CalculateDifference

            If Not colour1.GetColourType() = "LAB" Or Not colour2.GetColourType() = "LAB"
                If colour1.GetColourType() = "RGB"
                    colour1 = CType(colour1, ColourRGB).ToLAB(_workingSpace)
                End If

                If colour2.GetColourType() = "RGB"
                    colour2 = CType(colour2, ColourRGB).ToLAB(_workingSpace)
                End If
            End If

            Dim colour1New = CType(colour1, ColourLAB)
            Dim colour2New = CType(colour2, ColourLAB)

            Dim l = (colour1New.L - colour2New.L)^2
            Dim a = (colour1New.A - colour2New.A)^2
            Dim b = (colour1New.B - colour2New.B)^2

            Return (l + a + b)
        End Function

        Public Function GetClosestColour(colour1 As IColour) As IColour Implements IColourDifference.GetClosestColour
            Dim nearestColour As ColourRGB? = ColourCache.GetValue(colour1)
            If nearestColour IsNot Nothing Then
                Return nearestColour
            Else
                Dim lowest As ColourLAB
                Dim lowestValue As Double = 100000
                For Each color As ColourLAB In ColourCache.LabColourPalette
                    Dim value = Me.CalculateDifference(color, colour1)
                    If value < lowestValue Then
                        lowestValue = value
                        lowest = color
                    End If
                Next
                ColourCache.Add(colour1, lowest.ToRGB(_workingSpace))
                Return lowest.ToRGB(_workingSpace)
            End If
        End Function
    End Class
End NameSpace