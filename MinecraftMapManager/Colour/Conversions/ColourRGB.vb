

Namespace Colour.Conversions
    Public Structure ColourRGB
        Implements IVectorable, IColour

        Public ReadOnly Property R As Double
        Public ReadOnly Property G As Double
        Public ReadOnly Property B As Double

        Public Sub New(r As Double, g As Double, b As Double)
            Me.R = r
            Me.G = g
            Me.B = b
        End Sub

        Public Sub New(color As Color)
            Me.R = color.R
            Me.G = color.G
            Me.B = color.B
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

        Public Function ToColor() As Color
            Return Color.FromArgb(R, G, B)
        End Function

        Public Function Vectorise() As List(Of Double) Implements IVectorable.Vectorise
            Return New List(Of Double) From {R, G, B}
        End Function

        Public Overrides Function ToString() As String
            Return R.ToString + ", " + G.ToString() + ", " + B.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            Return R = obj.R And G = obj.G And B = obj.B
        End Function

        Public Function ToColor(workingSpace As WorkingSpace.WorkingSpace) As Color Implements IColour.ToColor
            Return ToColor()
        End Function

        Public Function GetColourType() As String Implements IColour.GetColourType
            Return "RGB"
        End Function
    End Structure
End NameSpace