
Imports MinecraftMapManager.Data

Namespace Colour.Conversions
    Public Structure ColourLCHab
        Implements IVectorable, IColour

        Public ReadOnly Property L As Double
        Public ReadOnly Property C As Double
        Public ReadOnly Property H As Double

        Public Sub New(l As Double, c As Double, h As Double)
            Me.L = l
            Me.C = c
            Me.H = h
        End Sub
        
        Public Function ToLAB() As ColourLAB
            Return New ColourLAB(L, C * Math.Cos(H), C * Math.Sin(H))
        End Function

        Public Function ToXYZ(workingSpace As WorkingSpace.WorkingSpace) As ColourXYZ
            Return ToLAB().ToXYZ(workingSpace)
        End Function

        Public Function ToLinearRGB(workingSpace As WorkingSpace.WorkingSpace) As ColourLinearRGB
            Return ToXYZ(workingSpace).ToLinearRGB(workingSpace)
        End Function

        Public Function ToRGB(workingSpace As WorkingSpace.WorkingSpace) As ColourRGB
            Return ToLinearRGB(workingSpace).ToRGB(workingSpace)
        End Function

        Public Function Vectorise() As List(Of Double) Implements IVectorable.Vectorise
            Return New List(Of Double) From {L, C, H}
        End Function

        Public Overrides Function ToString() As String
            Return L.ToString + ", " + C.ToString() + ", " + H.ToString()
        End Function

        Public Function ToColor(workingSpace As WorkingSpace.WorkingSpace) As Color Implements IColour.ToColor
            Return ToRGB(workingSpace).ToColor()
        End Function

        Public Function GetColourType() As String Implements IColour.GetColourType
            Return "LCHab"
        End Function
    End Structure
End NameSpace