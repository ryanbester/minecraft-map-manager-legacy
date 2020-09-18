Imports System.Collections.ObjectModel
Imports MinecraftMapManager.Data

Namespace UI
    Public Class EditIdCounts
        Private Dim _idCountsFile As IdCountsFile

        Private Sub btnFileBrowse_Click(sender As Object, e As EventArgs) Handles btnFileBrowse.Click
            Using openFileDialog = New OpenFileDialog()
                openFileDialog.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\saves"
                openFileDialog.Filter = "NBT files (*.dat;*.nbt)|*.dat;*.nbt|All files (*.*)|*.*"
                openFileDialog.Title = "Open idcounts.dat file"

                If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK
                    txtFile.Text = openFileDialog.FileName
                End If
            End Using
        End Sub

        Private Sub btnFileLoad_Click(sender As Object, e As EventArgs) Handles btnFileLoad.Click
            Dim fileName = txtFile.Text
            Try
                _idCountsFile = New IdCountsFile(fileName)
                _idCountsFile.LoadData()

                txtDataVersion.Value = _idCountsFile.DataVersion
                txtIDCount.Value = _idCountsFile.MapId

                EnableControls()
            Catch ex As Exception
                MessageBox.Show(Me, "Cannot read file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
            Try
                _idCountsFile = New IdCountsFile(Nothing)
                _idCountsFile.CreateNew()

                EnableControlsForNew()
            Catch ex As Exception
                MessageBox.Show(Me, "Cannot create new file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub EnableControls()
            txtDataVersion.Enabled = True
            btnListDataVersion.Enabled = True
            txtIDCount.Enabled = True
            btnSave.Enabled = True
            btnSaveAs.Enabled = True
        End Sub

        Private Sub EnableControlsForNew()
            txtFile.Enabled = False
            btnFileBrowse.Enabled = False
            btnFileLoad.Enabled = False
            txtDataVersion.Enabled = True
            btnListDataVersion.Enabled = True
            txtIDCount.Enabled = True
            btnSave.Enabled = False
            btnSaveAs.Enabled = True
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Close()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If _idCountsFile Is Nothing Then
                MessageBox.Show(Me, "No data to save", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If

            Try
                PrepareForSave()
                _idCountsFile.SaveData()
                MessageBox.Show(Me, "Saved to file successfully", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, "Error saving to file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.Click
            If _idCountsFile Is Nothing Then
                MessageBox.Show(Me, "No data to save", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If

            Dim saveFileDlg = New SaveFileDialog()
            saveFileDlg.Filter = "NBT files (*.dat;*.nbt)|*.dat;*.nbt|All files (*.*)|*.*"
            saveFileDlg.RestoreDirectory = True
            saveFileDlg.Title = "Save idcounts.dat file"

            If saveFileDlg.ShowDialog() = DialogResult.OK Then
                Try
                    PrepareForSave()
                    _idCountsFile.SaveData(saveFileDlg.FileName)
                    MessageBox.Show(Me, "Saved to file successfully", "Minecraft Map Manager", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(Me, "Error saving to file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub PrepareForSave()
            _idCountsFile.DataVersion = txtDataVersion.Value
            _idCountsFile.MapId = txtIDCount.Value
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