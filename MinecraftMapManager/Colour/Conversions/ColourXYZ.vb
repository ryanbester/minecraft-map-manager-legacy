

Namespace Colour.Conversions
    Public Structure ColourXYZ
        Implements IVectorable

        Public ReadOnly Property X As Double
        Public ReadOnly Property Y As Double
        Public ReadOnly Property Z As Double

        Public Sub New(x As Double, y As Double, z As Double)
            Me.X = x
            Me.Y = y
            Me.Z = z
        End Sub

        Public Function ToLAB(workingSpace As WorkingSpace.WorkingSpace) As ColourLAB
            Const e = 216/24389
            Const k = 24389/27

            Dim xr = X/workingSpace.Illuminant.X
            Dim yr = Y/workingSpace.Illuminant.Y
            Dim zr = Z/workingSpace.Illuminant.Z

            Dim fx = If (xr > e, xr^(1/3), (k*xr + 16)/116)
            Dim fy = If (yr > e, yr^(1/3), (k*yr + 16)/116)
            Dim fz = If (zr > e, zr^(1/3), (k*zr + 16)/116)

            Dim l = 116*fy - 16
            Dim a = 500*(fx - fy)
            Dim b = 200*(fy - fz)

            Return New ColourLAB(l, a, b)
        End Function

        Public Function ToLinearRGB(workingSpace As WorkingSpace.WorkingSpace) As ColourLinearRGB
            Dim rgb = MatrixExtensions.MultiplyBy(MatrixExtensions.Inverse(GetRGBToXYZMatrix(workingSpace)),
                                                  Me.Vectorise())

            Return New ColourLinearRGB(rgb(0), rgb(1), rgb(2))
        End Function

        Public Function ToRGB(workingSpace As WorkingSpace.WorkingSpace) As ColourRGB
            Return ToLinearRGB(workingSpace).ToRGB(workingSpace)
        End Function

        Public Function Vectorise() As List(Of Double) Implements IVectorable.Vectorise
            Return New List(Of Double) From {X, Y, Z}
        End Function

        Public Overrides Function ToString() As String
            Return X.ToString + ", " + Y.ToString() + ", " + Z.ToString()
        End Function
    End Structure
End NameSpace