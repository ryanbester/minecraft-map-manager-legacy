﻿Imports GUI.Colour.Conversions

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

            Dim r = (colour1New.R - colour2New.R)*(colour1New.R - colour2New.R)
            Dim g = (colour1New.G - colour2New.G)*(colour1New.G - colour2New.G)
            Dim b = (colour1New.B - colour2New.B)*(colour1New.B - colour2New.B)
            
            Return (r + g + b)
        End Function

        Public Function GetClosestColour(colour1 As IColour) As IColour Implements IColourDifference.GetClosestColour
            Dim nearestColour As ColourRGB? = ColourCache.GetValue(colour1)
            If nearestColour IsNot Nothing Then
                Return nearestColour
            Else
                Dim lowest As ColourRGB
                Dim lowestValue As Double = 100000
                For Each color As ColourRGB In ColourCache.RgbColourPalette
                    Dim value = Me.CalculateDifference(color, colour1)
                    If value < lowestValue Then
                        lowestValue = value
                        lowest = color
                    End If
                Next
                ColourCache.Add(colour1, lowest)
                Return lowest
            End If
        End Function
    End Class
End NameSpace