Imports MinecraftMapManager.Colour.Conversions

Namespace Colour.WorkingSpace

    Public Class WorkingSpace
        
        Public ReadOnly Property Illuminant As ColourXYZ

        Public ReadOnly Property ChromaR As ChromaticityCoords
        Public ReadOnly Property ChromaG As ChromaticityCoords
        Public ReadOnly Property ChromaB As ChromaticityCoords
    
        Public ReadOnly Property Gamma As Double
        
        Public ReadOnly Property Companding As ICompanding

        Public Sub New(illuminant As ColourXYZ, chromaR As ChromaticityCoords, chromaG As ChromaticityCoords,
                       chromaB As ChromaticityCoords, gamma As Double, companding As ICompanding)
            Me.Illuminant = illuminant
            Me.ChromaR = chromaR
            Me.ChromaG = chromaG
            Me.ChromaB = chromaB
            Me.gamma = Gamma
            Me.Companding = companding
        End Sub
    End Class
End NameSpace