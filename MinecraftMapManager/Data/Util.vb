Namespace Data
    Public Module Util
        Public Function Memset (Of T)(ByRef arr As T(), c As T, n As Integer) As T()
            For i = 0 To n - 1
                arr(i) = c
            Next

            Return arr
        End Function
    End Module
End NameSpace