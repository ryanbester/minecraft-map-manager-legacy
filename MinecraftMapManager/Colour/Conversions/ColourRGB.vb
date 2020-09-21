

Namespace Colour.Conversions
    Public Structure ColourRGB
        Implements IVectorable

        Public ReadOnly Property R As Double
        Public ReadOnly Property G As Double
        Public ReadOnly Property B As Double

        Public Sub New(r As Double, g As Double, b As Double)
            Me.R = r
            Me.G = g
            Me.B = b
        End Sub


        Public Function ToLinearRGB(workingSpace As WorkingSpace.WorkingSpace) As ColourLinearRGB
            Dim srgbR = R/255.0
            Dim srgbG = G/255.0
            Dim srgbB = B/255.0

            Dim linearR = workingSpace.Companding.InverseCompand(srgbR)
            Dim linearG = workingSpace.Companding.InverseCompand(srgbG)
            Dim linearB = workingSpace.Companding.InverseCompand(srgbB)

            Return New ColourLinearRGB(linearR, linearG, linearB)
        End Function

        Public Function ToXYZ(workingSpace As WorkingSpace.WorkingSpace) As ColourXYZ
            Return ToLinearRGB(workingSpace).ToXYZ(workingSpace)
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
    End Structure
End NameSpace