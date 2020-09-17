Imports System.Collections.ObjectModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports fNbt
Imports MinecraftMapManager.Data

Namespace UI
    Public Class EditMapDat
        Private _mapFile As MapFile

        Private Sub btnFileBrowse_Click(sender As Object, e As EventArgs) Handles btnFileBrowse.Click
            Using openFileDialog = New OpenFileDialog()
                openFileDialog.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\saves"
                openFileDialog.Filter = "NBT files (*.dat;*.nbt)|*.dat;*.nbt|All files (*.*)|*.*"
                openFileDialog.Title = "Open map file"

                If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    txtFile.Text = openFileDialog.FileName
                End If
            End Using
        End Sub

        Private Sub btnFileLoad_Click(sender As Object, e As EventArgs) Handles btnFileLoad.Click
            Dim fileName = txtFile.Text
            Try
                _mapFile = New MapFile(fileName)
                _mapFile.LoadData()

                txtDataVersion.Value = _mapFile.DataVersion

                Dim upscaledBitmap = MapColours.UpscaleBitmap(_mapFile.MapBitmap, 2)
                picMapPreview.Image = upscaledBitmap

                EnableControls()
            Catch ex As Exception
                MessageBox.Show(Me, "Cannot read file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub EnableControls()
            txtDataVersion.Enabled = True
            btnListDataVersion.Enabled = True
            btnSave.Enabled = True
            btnSaveAs.Enabled = True
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Close()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If _mapFile Is Nothing Then
                MessageBox.Show(Me, "No data to save", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If

            Try
                PrepareForSave()
                _mapFile.SaveData()
                MessageBox.Show(Me, "Saved to file successfully", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, "Error saving to file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.Click
            If _mapFile Is Nothing Then
                MessageBox.Show(Me, "No data to save", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If

            Dim saveFileDlg = New SaveFileDialog()
            saveFileDlg.Filter = "NBT files (*.dat;*.nbt)|*.dat;*.nbt|All files (*.*)|*.*"
            saveFileDlg.RestoreDirectory = True
            saveFileDlg.Title = "Save map file"

            If saveFileDlg.ShowDialog() = DialogResult.OK Then
                PrepareForSave()
                _mapFile.SaveData(saveFileDlg.FileName)
            End If
        End Sub

        Private Sub PrepareForSave()
            _mapFile.DataVersion = txtDataVersion.Value
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