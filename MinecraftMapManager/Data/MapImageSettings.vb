Imports System.Drawing.Drawing2D
Imports MinecraftMapManager.Colour.WorkingSpace

Public Enum MapImageInterpolation
    NearestNeighbour
    Bicubic
    Bilinear
End Enum

Public Enum MapImageColourDifference
    Euclidean
    CIE76
    CIE94
    CMC
    BFD
    CIEDE2000
End Enum

Public Enum MapImageDithering
    None
    FloydSteinberg
    Threshold
    Halftone
    Bayer
    JarvisJudiceNinke
    Stucki
    Burkes
    Sierra
    TwoRowSierra
    SierraLite
    Atkinson
    GradientBased
End Enum

Public Class MapImageSettings
    Public Dim WorkingSpace As WorkingSpace
    Public Dim Interpolation As MapImageInterpolation
    Public Dim ColourDifference As MapImageColourDifference
    Public Dim Dithering As MapImageDithering

    Public Sub New(workingSpace As WorkingSpace, interpolation As MapImageInterpolation,
                   colourDifference As MapImageColourDifference, dithering As MapImageDithering)
        Me.WorkingSpace = workingSpace
        Me.Interpolation = interpolation
        Me.ColourDifference = colourDifference
        Me.Dithering = dithering
    End Sub

    Public Function InterpolationMode() As InterpolationMode
        Select Case Interpolation
            Case MapImageInterpolation.NearestNeighbour
                Return InterpolationMode.NearestNeighbor
            Case MapImageInterpolation.Bicubic
                Return InterpolationMode.Bicubic
            Case MapImageInterpolation.Bilinear
                Return InterpolationMode.Bilinear
        End Select

        Return InterpolationMode.NearestNeighbor
    End Function
End Class