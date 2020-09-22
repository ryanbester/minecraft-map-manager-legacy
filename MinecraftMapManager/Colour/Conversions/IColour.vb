Imports MinecraftMapManager.Colour.WorkingSpace

Public Interface IColour
    Function ToColor(workingSpace As WorkingSpace) As Color
    Function GetColourType() As String
End Interface