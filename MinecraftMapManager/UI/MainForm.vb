Imports System.Windows.Forms.VisualStyles
Imports MinecraftMapManager.Colour
Imports MinecraftMapManager.Colour.Conversions
Imports MinecraftMapManager.Colour.WorkingSpace

Namespace UI
    Public Class MainForm
        Private Sub btnOpenMapDAT_Click(sender As Object, e As EventArgs) Handles btnOpenMapDAT.Click
            Dim editMapDlg = New EditMapDAT()
            editMapDlg.ShowDialog()
        End Sub

        Private Sub btnOpenSave_Click(sender As Object, e As EventArgs) Handles btnOpenSave.Click
        End Sub

        Private Sub btnCreateMapDAT_Click(sender As Object, e As EventArgs) Handles btnCreateMapDAT.Click
            Dim editMapDlg = New EditMapDAT()
            editMapDlg.CreateNew()
            editMapDlg.ShowDialog()
        End Sub

        Private Sub btnEditIdcounts_Click(sender As Object, e As EventArgs) Handles btnEditIdcounts.Click
            Dim idCountDlg = New EditIDCounts()
            idCountDlg.ShowDialog()
        End Sub

        Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        End Sub

        Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
            Dim aboutDlg = New AboutDialog()
            aboutDlg.ShowDialog()
        End Sub
    End Class
End NameSpace