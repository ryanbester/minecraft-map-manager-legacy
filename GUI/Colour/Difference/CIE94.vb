Imports GUI.Colour.Conversions

Namespace Colour.Difference
    Public Class CIE94
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

            Dim colour1Lab = CType(colour1, ColourLAB)
            Dim colour2Lab = CType(colour2, ColourLAB)

            If Not colour1.GetColourType() = "LCHab" Or Not colour2.GetColourType() = "LCHab"
                If colour1.GetColourType() = "LAB"
                    colour1 = CType(colour1, ColourLAB).ToLCHab(_workingSpace)
                End If

                If colour2.GetColourType() = "LAB"
                    colour2 = CType(colour2, ColourLAB).ToLCHab(_workingSpace)
                End If
            End If

            Dim colour1New = CType(colour1, ColourLCHab)
            Dim colour2New = CType(colour2, ColourLCHab)

            Dim c1 = Math.Sqrt(colour1Lab.A^2 + colour1Lab.B^2)
            Dim c2 = Math.Sqrt(colour2Lab.A^2 + colour2Lab.B^2)

            Dim part1 = (colour1New.L - colour2New.L)^2
            Dim part2 = ((c1 - c2)/1 + 0.045*c1)^2
            Dim diffHab = Math.Sqrt((colour1Lab.A - colour2Lab.A)^2 + (colour1Lab.B - colour2Lab.B)^2 + (c1 - c2)^2)
            Dim part3 = (diffHab/1 + 0.015*c1)

            Return Math.Sqrt(part1 + part2 + part3)
        End Function

        Public Function GetClosestColour(colour1 As IColour) As IColour Implements IColourDifference.GetClosestColour
            Dim nearestColour As ColourRGB? = ColourCache.GetValue(colour1)
            If nearestColour IsNot Nothing Then
                Return nearestColour
            Else
                Dim lowest As ColourLCHab
                Dim lowestValue As Double = 100000
                For Each color As ColourLCHab In ColourCache.LchAbColourPalette
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