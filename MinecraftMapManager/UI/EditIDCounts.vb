Imports System.Collections.ObjectModel

Namespace UI
    Public Class EditIDCounts
        Private Dim _versions As Collection(Of DataVersions.VersionInfo)

        Private Sub EditIDCounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If Not getVersionWorker.IsBusy Then
                getVersionWorker.RunWorkerAsync()
            End If
        End Sub

        Private Sub getVersionWorker_DoWork() Handles getVersionWorker.DoWork
            DataVersions.GetDataVersions()
            _versions = DataVersions.GetDataVersionInfo(txtDataVersion.Value)
        End Sub

        Private Sub getVersionWorker_Completed() Handles getVersionWorker.RunWorkerCompleted
            If _versions Is Nothing Then
                lblDataVersionName.Text = "Invalid DataVersion"
            Else
                Dim versionString As String
                Dim i = 0
                For Each versionInfo In _versions
                    If i > 0 Then
                        versionString += ", "
                    End If
                    versionString += versionInfo.ClientVersion
                    i += 1
                Next
                lblDataVersionName.Text = versionString
            End If
        End Sub

        Private Sub btnFileBrowse_Click(sender As Object, e As EventArgs) Handles btnFileBrowse.Click
        End Sub

        Private Sub btnFileLoad_Click(sender As Object, e As EventArgs) Handles btnFileLoad.Click
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Close()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        End Sub

        Private Sub btnDataVersionList_Click(sender As Object, e As EventArgs) Handles btnListDataVersion.Click
            Dim listVersionsDlg = New ListDataVersions()
            listVersionsDlg.SelectedDataVersion = txtDataVersion.Value
            Dim result = listVersionsDlg.ShowDialog()
            If result = DialogResult.OK Then
                txtDataVersion.Value = listVersionsDlg.lvDataVersions.SelectedItems(0).SubItems(0).Text
            End If
        End Sub

        Private Sub txtDataVersion_ValueChanged(sender As Object, e As EventArgs) Handles txtDataVersion.ValueChanged
            If Not getVersionWorker.IsBusy Then
                getVersionWorker.RunWorkerAsync()
            End If
        End Sub
    End Class
End NameSpace