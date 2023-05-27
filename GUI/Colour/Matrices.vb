Imports GUI.Colour.MatrixExtensions

Imports Vector = System.Collections.Generic.List(Of Double)
Imports Matrix = System.Collections.Generic.List(Of System.Collections.Generic.List(Of Double))

Namespace Colour
    Public Module Matrices
        Public Function CreateEmpty(rows As Integer, columns As Integer) As Double()()
            Dim result = New Double(rows)() {}

            For i = 0 To rows
                result(i) = New Double(columns) {}
            Next

            Return result
        End Function

        Public Function GetRGBToXYZMatrix(workingSpace As WorkingSpace.WorkingSpace) As Matrix
            Dim xr = workingSpace.ChromaR.X/workingSpace.ChromaR.Y
            Const yr As Double = 1
            Dim zr = (1 - workingSpace.ChromaR.X - workingSpace.ChromaR.Y)/workingSpace.ChromaR.Y

            Dim xg = workingSpace.ChromaG.X/workingSpace.ChromaG.Y
            Const yg As Double = 1
            Dim zg = (1 - workingSpace.ChromaG.X - workingSpace.ChromaG.Y)/workingSpace.ChromaG.Y

            Dim xb = workingSpace.ChromaB.X/workingSpace.ChromaB.Y
            Const yb As Double = 1
            Dim zb = (1 - workingSpace.ChromaB.X - workingSpace.ChromaB.Y)/workingSpace.ChromaB.Y

            Dim s = New Matrix From {
                    New Vector From {xr, xg, xb},
                    New Vector From {yr, yg, yb},
                    New Vector From {zr, zg, zb}
                    }.Inverse().MultiplyBy(workingSpace.Illuminant.Vectorise())

            Dim sr = s(0), sg = s(1), sb = s(2)

            Dim m = New Matrix From {
                    New Vector From {sr*xr, sg*xg, sb*xb},
                    New Vector From {sr*yr, sg*yg, sb*yg},
                    New Vector From {sr*zr, sg*zg, sb*zb}
                    }

            Return m
        End Function
    End Module
End NameSpace