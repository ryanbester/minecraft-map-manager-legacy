Imports System.ComponentModel
Imports GUI.Colour.Conversions
Imports GUI.Colour.Difference
Imports GUI.Data

Namespace Colour.Dithering
    Public Class FloydSteinberg
        Implements IDither

        Private _diffMode As IColourDifference
        Private _worker As BackgroundWorker
        Private _reportProgress As MapImage.DitherProgress

        Sub New(diffMode As IColourDifference, worker As BackgroundWorker, reportProgress As MapImage.DitherProgress)
            _diffMode = diffMode
            _worker = worker
            _reportProgress = reportProgress
        End Sub

        Public Function CalculateDither(bitmap As Bitmap) As Object Implements IDither.CalculateDither
            For y = 0 To bitmap.Height - 1
                _reportProgress(y, _worker)

                For x = 0 To bitmap.Width - 1
                    Dim oldColour = bitmap.GetPixelAsColourRGB(x, y)
                    Dim newColour = CType(_diffMode.GetClosestColour(oldColour), ColourRGB)
                    bitmap.SetPixelFromColourRGB(x, y, newColour)
                    Dim quantError = oldColour - newColour

                    Dim xBefore = Util.Clamp(x - 1, 0, bitmap.Width - 1)
                    Dim xAfter = Util.Clamp(x + 1, 0, bitmap.Width - 1)
                    Dim yAfter = Util.Clamp(y + 1, 0, bitmap.Height - 1)

                    Dim pixel1 = bitmap.GetPixelAsColourRGB(xAfter, y)
                    bitmap.SetPixelFromColourRGB(xAfter, y, pixel1 + quantError*(7/16))
                    Dim pixel2 = bitmap.GetPixelAsColourRGB(xBefore, yAfter)
                    bitmap.SetPixelFromColourRGB(xBefore, yAfter, pixel2 + quantError*(3/16))
                    Dim pixel3 = bitmap.GetPixelAsColourRGB(x, yAfter)
                    bitmap.SetPixelFromColourRGB(x, yAfter, pixel3 + quantError*(5/16))
                    Dim pixel4 = bitmap.GetPixelAsColourRGB(xAfter, yAfter)
                    bitmap.SetPixelFromColourRGB(xAfter, yAfter, pixel4 + quantError*(1/16))
                Next
            Next
            
            Return bitmap
        End Function
    End Class
End NameSpace