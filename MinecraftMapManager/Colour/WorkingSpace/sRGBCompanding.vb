Namespace Colour.WorkingSpace
    Public Class sRGBCompanding
        Implements ICompanding

        Public Function InverseCompand(u As Double) As Double Implements ICompanding.InverseCompand
            Return If (u <= 0.04045, u/12.92, ((u + 0.055)/1.055)^2.4)
        End Function

        Public Function Compand(u As Double) As Double Implements ICompanding.Compand
            Return If (u <= 0.0031308, 12.92 * u, (1.055 *(u ^ (1/2.4)) - 0.055))
        End Function
    End Class
End NameSpace