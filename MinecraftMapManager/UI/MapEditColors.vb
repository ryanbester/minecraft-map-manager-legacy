Imports MinecraftMapManager.Data

Public Class MapEditColors
    Public Dim MapFile As MapFile

    Private Dim _colourVariants As List(Of Color)

    Private Enum Tool
        ToolDraw
        ToolErase
    End Enum

    Private Dim _currentTool As Tool = Tool.ToolDraw
    Private Dim _toolSize As Integer = 1

    Private Dim _isPainting = False
    Private Dim _currentColour As Byte
    Private Dim _currentColourRgb As Color

    Private Sub MapEditColors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lsbColourBase.ItemHeight = 40
        lsbColourBase.DataSource = MapColours.ColourTable

        lsbColourVariant.ItemHeight = 40
        lsbColourVariant.DataSource = Nothing

        UpdateImage()
    End Sub

    Private Sub lsbColourBase_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lsbColourBase.DrawItem
        e.DrawBackground()

        Dim item As Color = lsbColourBase.Items(e.Index)

        e.Graphics.FillRectangle(New SolidBrush(item), e.Bounds.Left + 5, e.Bounds.Top + 5, 30, 30)

        e.Graphics.DrawString(MapColours.ColourNames(e.Index),
                              New Font("Microsoft Sans Serif", 12.0F, FontStyle.Regular),
                              Brushes.Black, e.Bounds.Left + 35, e.Bounds.Top + 5)

        e.DrawFocusRectangle()
    End Sub

    Private Sub lsbColourVariant_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lsbColourVariant.DrawItem
        e.DrawBackground()

        Dim item As Color = lsbColourVariant.Items(e.Index)

        e.Graphics.FillRectangle(New SolidBrush(item), e.Bounds.Left + 5, e.Bounds.Top + 5, 30, 30)

        e.Graphics.DrawString(e.Index.ToString(), New Font("Microsoft Sans Serif", 12.0F, FontStyle.Regular),
                              Brushes.Black, e.Bounds.Left + 35, e.Bounds.Top + 5)

        e.DrawFocusRectangle()
    End Sub

    Private Sub lsbColourBase_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles lsbColourBase.SelectedIndexChanged
        Dim colour = MapColours.ColourTable(lsbColourBase.SelectedIndex)

        _colourVariants = New List(Of Color)()
        For Each multiplier As Double In MapColours.VariantTable
            _colourVariants.Add(Color.FromArgb(colour.A, colour.R*multiplier, colour.G*multiplier,
                                               colour.B*multiplier))
        Next

        lsbColourVariant.DataSource = _colourVariants
        lsbColourVariant.Refresh()
    End Sub

    Private Sub txtToolSize_ValueChanged(sender As Object, e As EventArgs) Handles txtToolSize.ValueChanged
        _toolSize = txtToolSize.Value
    End Sub

    Private Sub btnDraw_CheckedChanged(sender As Object, e As EventArgs) Handles btnDraw.CheckedChanged
        If btnDraw.Checked
            btnErase.Checked = False
            _currentTool = Tool.ToolDraw
        Else
            btnErase.Checked = True
        End If
    End Sub

    Private Sub btnErase_CheckedChanged(sender As Object, e As EventArgs) Handles btnErase.CheckedChanged
        If btnErase.Checked
            btnDraw.Checked = False
            _currentTool = Tool.ToolErase
        Else
            btnDraw.Checked = True
        End If
    End Sub

    Private Sub UpdateImage()
        Dim colours
        If chkShowImage.Checked
            colours = MapColours.CombineLayers(MapFile.MapColoursImage, MapFile.MapColoursManual)
            colours = MapColours.CombineLayers(MapFile.MapColours, colours)
        Else
            colours = MapColours.CombineLayers(MapFile.MapColours, MapFile.MapColoursManual)
        End If

        Dim bitmap = MapColours.CreateBitmapFromMap(colours)
        picImage.Image = MapColours.UpscaleBitmap(bitmap, 4)
    End Sub


    Private Sub picImage_MouseDown(sender As Object, e As MouseEventArgs) Handles picImage.MouseDown
        If btnErase.Checked
            _isPainting = True
            _currentColour = 255
            _currentColourRgb = Nothing
            Return
        End If

        If lsbColourBase.SelectedIndex = - 1 Or lsbColourVariant.SelectedIndex = - 1
            MessageBox.Show(Me, "No colour selected", "Minecraft Map Manager", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If

        _isPainting = True
        _currentColour = GetSelectedColour()
        _currentColourRgb = MapColours.GetRgbColour(_currentColour)

        If Not ImageBackgroundWorker.IsBusy Then
            ImageBackgroundWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub picImage_MouseMove(sender As Object, e As MouseEventArgs) Handles picImage.MouseMove
        If _isPainting Then
            Dim x = e.X
            Dim y = e.Y

            x = Clamp(x, 0, 511)
            y = Clamp(y, 0, 511)

            Dim mapX = x/4
            Dim mapY = y/4

            Dim startX = mapX - (_toolSize - 1)
            Dim endX = mapX + (_toolSize - 1)
            Dim startY = mapY - (_toolSize - 1)
            Dim endY = mapY + (_toolSize - 1)

            Dim bitmap = New Bitmap(picImage.Image)

            For i = startX To endX
                For j = startY To endY
                    MapColours.SetPixel(MapFile.MapColoursManual, i, j, _currentColour)
                    bitmap.SetPixel(Clamp(i*4, 0, 511), Clamp(j*4, 0, 511), _currentColourRgb)
                Next
            Next

            picImage.Image = bitmap
        End If
    End Sub

    Private Sub picImage_MouseUp(sender As Object, e As MouseEventArgs) Handles picImage.MouseUp
        _isPainting = False

        ImageBackgroundWorker.CancelAsync()
        UpdateImage()
    End Sub

    Private Function Clamp(value As Double, lower As Integer, upper As Integer) As Double
        If value < lower Then
            value = lower
        End If

        If value > upper Then
            value = upper
        End If

        Return value
    End Function

    Private Function GetSelectedColour() As Byte
        Return (lsbColourBase.SelectedIndex*4) + lsbColourVariant.SelectedIndex
    End Function

    Private Sub chkShowImage_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowImage.CheckedChanged
        UpdateImage()
    End Sub

    Private Sub ImageBackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) _
        Handles ImageBackgroundWorker.DoWork
        While Not ImageBackgroundWorker.CancellationPending
            UpdateImage()
        End While
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub
End Class