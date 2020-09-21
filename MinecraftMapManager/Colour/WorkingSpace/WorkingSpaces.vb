Namespace Colour.WorkingSpace
    Public Module WorkingSpaces
        Public ReadOnly Dim _
            sRGB = New WorkingSpace(Illuminants.D65, New ChromaticityCoords(0.6400, 0.3300),
                                    New ChromaticityCoords(0.3000, 0.6000), New ChromaticityCoords(0.1500, 0.0600),
                                    Gamma.sRGBGamma, New sRGBCompanding())
    End Module
End NameSpace