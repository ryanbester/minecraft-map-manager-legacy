
Imports MinecraftMapManager.Data

Namespace Colour.Conversions
    Public Structure ColourLAB
        Implements IVectorable, IColour

        Public ReadOnly Property L As Double
        Public ReadOnly Property A As Double
        Public ReadOnly Property B As Double

        Public Sub New(l As Double, a As Double, b As Double)
            Me.L = l
            Me.A = a
            Me.B = b
        End Sub

        Public Function ToXYZ(workingSpace As WorkingSpace.WorkingSpace) As ColourXYZ
            Const e = 216/24389
            Const k = 24389/27

            Dim fy = (L + 16)/116d
            Dim fz = fy - (B/200d)
            Dim fx = (A/500d) + fy

            Dim xr = If (fx^3 > e, fx^3, (116*fx - 16)/k)
            Dim yr = If (L > k*e, ((L + 16)/116d)^3, L/k)
            Dim zr = If (fz^3 > e, fz^3, (116*fz - 16)/k)

            Dim x = xr*workingSpace.Illuminant.X
            Dim y = yr*workingSpace.Illuminant.Y
            Dim z = zr*workingSpace.Illuminant.Z

            Return New ColourXYZ(Clamp(x, 0, 1), Clamp(y, 0, 1), Clamp(z, 0, 1))
        End Function

        Public Function ToLinearRGB(workingSpace As WorkingSpace.WorkingSpace) As ColourLinearRGB
            Return ToXYZ(workingSpace).ToLinearRGB(workingSpace)
        End Function

        Public Function ToRGB(workingSpace As WorkingSpace.WorkingSpace) As ColourRGB
            Return ToLinearRGB(workingSpace).ToRGB(workingSpace)
        End Function

        Public Function ToLCHab(workingSpace As WorkingSpace.WorkingSpace) As ColourLCHab
            Dim c = Math.Sqrt(A*A + B*B)
            Dim h = 0
            If Math.Atan2(A, B) >= 0
                h = Math.Atan2(A, B)
            Else
                h = Math.Atan2(A, B) + 360
            End If
            Return New ColourLCHab(L, c, h)
        End Function

        Public Function Vectorise() As List(Of Double) Implements IVectorable.Vectorise
            Return New List(Of Double) From {L, A, B}
        End Function

        Public Overrides Function ToString() As String
            Return L.ToString + ", " + A.ToString() + ", " + B.ToString()
        End Function

        Public Function ToColor(workingSpace As WorkingSpace.WorkingSpace) As Color Implements IColour.ToColor
            Return ToRGB(workingSpace).ToColor()
        End Function

        Public Function GetColourType() As String Implements IColour.GetColourType
            Return "LAB"
        End Function
    End Structure
End NameSpace