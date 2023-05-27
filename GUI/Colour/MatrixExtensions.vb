Imports System.Runtime.CompilerServices

Imports Vector = System.Collections.Generic.List(Of Double)
Imports Matrix = System.Collections.Generic.List(Of System.Collections.Generic.List(Of Double))

Namespace Colour
    Module MatrixExtensions
        <Extension()>
        Public Function Inverse(ByVal matrix As Matrix) As Matrix
            Dim a = matrix(1)(1)*matrix(2)(2) - matrix(1)(2)*matrix(2)(1)
            Dim d = - (matrix(0)(1)*matrix(2)(2) - matrix(0)(2)*matrix(2)(1))
            Dim G = matrix(0)(1)*matrix(1)(2) - matrix(0)(2)*matrix(1)(1)
            Dim b = - (matrix(1)(0)*matrix(2)(2) - matrix(1)(2)*matrix(2)(0))
            Dim e = matrix(0)(0)*matrix(2)(2) - matrix(0)(2)*matrix(2)(0)
            Dim h = - (matrix(0)(0)*matrix(1)(2) - matrix(0)(2)*matrix(1)(0))
            Dim c = matrix(1)(0)*matrix(2)(1) - matrix(1)(1)*matrix(2)(0)
            Dim f = - (matrix(0)(0)*matrix(2)(1) - matrix(0)(1)*matrix(2)(0))
            Dim i = matrix(0)(0)*matrix(1)(1) - matrix(0)(1)*matrix(1)(0)
            Dim det = matrix(0)(0)*a + matrix(0)(1)*b + matrix(0)(2)*c

            Dim result As Matrix = New Matrix From {
                    New Vector From {a/det, d/det, g/det},
                    New Vector From {b/det, e/det, h/det},
                    New Vector From {c/det, f/det, i/det}
                    }
            Return result
        End Function

        <Extension()>
        Public Function MultiplyBy(ByVal matrix As Matrix, vector As Vector)
            Dim result = New Double(matrix.Count) {}

            For i = 0 To matrix.Count - 1
                For k = 0 To vector.Count - 1
                    result(i) += matrix(i)(k)*vector(k)
                Next
            Next

            Return result
        End Function

        <Extension()>
        Public Function MultiplyBy(ByVal matrix1 As Matrix, matrix2 As Matrix)
            Dim result = Matrices.CreateEmpty(matrix1.Count, matrix2(0).Count)

            For i = 0 To matrix1.Count - 1
                For j = 0 To matrix2(0).Count - 1
                    For k = 0 To matrix1(0).Count - 1
                        result(i)(j) += matrix1(i)(k)*matrix2(k)(j)
                    Next
                Next
            Next

            Return result
        End Function
    End Module
End NameSpace