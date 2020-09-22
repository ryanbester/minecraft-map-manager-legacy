

Namespace Colour.Conversions
    Public Structure ColourLinearRGB
        Implements IVectorable, IColour

        Public ReadOnly Property R As Double
        Public ReadOnly Property G As Double
        Public ReadOnly Property B As Double

        Public Sub New(r As Double, g As Double, b As Double)
            Me.R = r
            Me.G = g
            Me.B = b
        End Sub

        Public Function ToXYZ(workingSpace As WorkingSpace.WorkingSpace) As ColourXYZ
            Dim xyz = MatrixExtensions.MultiplyBy(GetRGBToXYZMatrix(workingSpace), Me.Vectorise())

            Return New ColourXYZ(xyz(0), xyz(1), xyz(2))
        End Function
        
        Public Function ToRGB(workingSpace As WorkingSpace.WorkingSpace) As ColourRGB
            Dim newR = workingSpace.Companding.Compand(R)
            Dim newG = workingSpace.Companding.Compand(G)
            Dim newB = workingSpace.Companding.Compand(B)

            Return New ColourRGB(newR * 255.0, newG * 255.0, newB * 255.0)
        End Function
        
        Public Function ToLAB(workingSpace As WorkingSpace.WorkingSpace) As ColourLAB
            Return ToXYZ(workingSpace).ToLAB(workingSpace)
        End Function

        Public Function Vectorise() As List(Of Double) Implements IVectorable.Vectorise
            Return New List(Of Double) From {R, G, B}
        End Function

        Public Overrides Function ToString() As String
            Return R.ToString + ", " + G.ToString() + ", " + B.ToString()
        End Function

        Public Function ToColor(workingSpace As WorkingSpace.WorkingSpace) As Color Implements IColour.ToColor
            Return ToRGB(workingSpace).ToColor()
        End Function

        Public Function GetColourType() As String Implements IColour.GetColourType
            Return "LinearRGB"
        End Function
    End Structure
End NameSpace