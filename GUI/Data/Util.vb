Namespace Data
    Public Module Util
        Public Function Memset (Of T)(ByRef arr As T(), c As T, n As Integer) As T()
            For i = 0 To n - 1
                arr(i) = c
            Next

            Return arr
        End Function

        Public Function Clamp(value As Double, lower As Integer, upper As Integer) As Double
            If value < lower Then
                value = lower
            End If

            If value > upper Then
                value = upper
            End If

            Return value
        End Function
    End Module
End NameSpace