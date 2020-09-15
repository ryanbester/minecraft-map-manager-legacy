Imports System.ComponentModel
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Namespace UI
    Public Class ListDataVersions
        Public SelectedDataVersion As String = Nothing

        Private Sub ListDataVersions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Cursor = Cursors.WaitCursor
            UseWaitCursor = True
            getDataVersionsWorker.RunWorkerAsync()
        End Sub

        Private Sub getDataVersionsWorker_DoWork() Handles getDataVersionsWorker.DoWork
            DataVersions.GetDataVersions()
        End Sub

        Private Sub getDataVersionsWorker_Completed() Handles getDataVersionsWorker.RunWorkerCompleted
            For Each dataVersion As DataVersions.VersionInfo In DataVersions.dataVersions
                Dim lvItem = New ListViewItem(
                    New String() {dataVersion.DataVersion, dataVersion.ClientVersion,
                                  dataVersion.ProtocolVersion})
                lvDataVersions.Items.Add(lvItem)
                If dataVersion.DataVersion = SelectedDataVersion Then
                    lvItem.Selected = True
                    lvItem.EnsureVisible()
                End If
            Next

            lvDataVersions.Enabled = True
            UseWaitCursor = False
            Me.Cursor = Cursors.Default
        End Sub

        Private Sub lvDataVersions_DoubleClick(sender As Object, e As EventArgs) Handles lvDataVersions.DoubleClick
            If lvDataVersions.SelectedItems.Count > 0 Then
                Me.DialogResult = DialogResult.OK
                Close()
            End If
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Close()
        End Sub

        Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
            Me.DialogResult = DialogResult.OK
            Close()
        End Sub
    End Class
End NameSpace