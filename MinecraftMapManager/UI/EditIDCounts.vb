Imports System.Collections.ObjectModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports fNbt

Namespace UI
    Public Class EditIDCounts
        Private Dim _versions As Collection(Of DataVersions.VersionInfo)
        Private Dim _nbtFile As NbtFile = Nothing

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
            Using openFileDialog = New OpenFileDialog()
                openFileDialog.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\saves"
                openFileDialog.Filter = "NBT files (*.dat;*.nbt)|*.dat;*.nbt|All files (*.*)|*.*"

                If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK
                    txtFile.Text = openFileDialog.FileName
                End If
            End Using
        End Sub

        Private Sub btnFileLoad_Click(sender As Object, e As EventArgs) Handles btnFileLoad.Click
            Dim fileName = txtFile.Text
            Try
                _nbtFile = New NbtFile()
                _nbtFile.LoadFromFile(fileName)

                Dim dataVersion = _nbtFile.RootTag("DataVersion").IntValue
                Dim mapId = _nbtFile.RootTag.Get (Of NbtCompound)("data")("map").IntValue

                txtDataVersion.Value = dataVersion
                txtIDCount.Value = mapId

                txtDataVersion.Enabled = True
                btnListDataVersion.Enabled = True
                txtIDCount.Enabled = True
                btnSave.Enabled = True
                btnSaveAs.Enabled = True
            Catch ex As Exception
                MessageBox.Show(Me, "Cannot read file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Close()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If _nbtFile Is Nothing
                MessageBox.Show(Me, "No data to save", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If

            SaveFile(_nbtFile.FileName)
        End Sub

        Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.Click
            If _nbtFile Is Nothing
                MessageBox.Show(Me, "No data to save", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If

            Dim saveFileDlg = New SaveFileDialog()
            saveFileDlg.Filter = "NBT files (*.dat;*.nbt)|*.dat;*.nbt|All files (*.*)|*.*"
            saveFileDlg.RestoreDirectory = True

            If saveFileDlg.ShowDialog() = DialogResult.OK
                SaveFile(saveFileDlg.FileName)
            End If
        End Sub

        Private Sub SaveFile(fileName As String)
            Try
                _nbtFile.RootTag.Remove("DataVersion")
                _nbtFile.RootTag.Add(New NbtInt("DataVersion", txtDataVersion.Value))
                Dim dataTag = _nbtFile.RootTag.Get (Of NbtCompound)("data")
                dataTag.Remove("map")
                dataTag.Add(New NbtInt("map", txtIDCount.Value))

                _nbtFile.SaveToFile(fileName, NbtCompression.None)
                MessageBox.Show(Me, "Saved to file successfully", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, "Error saving to file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
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