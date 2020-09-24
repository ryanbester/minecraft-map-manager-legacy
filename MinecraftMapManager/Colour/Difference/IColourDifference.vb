Imports MinecraftMapManager.Colour.Conversions

Namespace Colour.Difference
    Public Interface IColourDifference
        Function CalculateDifference(colour1 As IColour, colour2 As IColour) As Double
        Function GetClosestColour(colour1 As IColour) As IColour
    End Interface
End NameSpace