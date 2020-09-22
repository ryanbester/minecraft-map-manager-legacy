Imports System.Collections.ObjectModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports fNbt
Imports MinecraftMapManager.Colour.WorkingSpace
Imports MinecraftMapManager.Data

Namespace UI
    Public Class EditMapDat
        Private _mapFile As MapFile

        Private ReadOnly _mapImage As MapImage = New MapImage()
        Private _previewUpdateNeeded = False

        Private Sub EditMapDat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cmbImageInterpolation.SelectedIndex = 0
            cmbImageDithering.SelectedIndex = 0
            cmbImageColorDifference.SelectedIndex = 0

            If Not previewUpdateWorker.IsBusy Then
                previewUpdateWorker.RunWorkerAsync()
            End If
        End Sub

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

                SetCompressionType()

                txtDataVersion.Value = _mapFile.DataVersion

                txtScale.Value = _mapFile.Scale
                SetDimension()
                chkTracking.Checked = _mapFile.Tracking
                chkUnlimitedTracking.Checked = _mapFile.UnlimitedTracking
                chkLocked.Checked = _mapFile.Locked

                txtX.Value = _mapFile.X
                txtZ.Value = _mapFile.Z

                _previewUpdateNeeded = True

                EnableControls()
            Catch ex As Exception
                MessageBox.Show(Me, "Cannot read file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub SetCompressionType()
            Select Case _mapFile.CompressionType
                Case NbtCompression.None
                    cmbCompressionType.SelectedIndex = 0
                Case NbtCompression.GZip
                    cmbCompressionType.SelectedIndex = 1
                Case NbtCompression.ZLib
                    cmbCompressionType.SelectedIndex = 2
            End Select
        End Sub

        Private Function GetCompressionType() As NbtCompression
            Select Case cmbCompressionType.SelectedIndex
                Case 0
                    Return NbtCompression.None
                Case 1
                    Return NbtCompression.GZip
                Case 2
                    Return NbtCompression.ZLib
            End Select

            Return NbtCompression.None
        End Function

        Private Sub SetDimension()
            Select Case _mapFile.Dimension
                Case 0
                    cmbDimension.SelectedIndex = 0
                Case - 1
                    cmbCompressionType.SelectedIndex = 1
                Case 1
                    cmbCompressionType.SelectedIndex = 2
            End Select
        End Sub

        Private Function GetDimension() As SByte
            Select Case cmbDimension.SelectedIndex
                Case 0
                    Return 0
                Case 1
                    Return - 1
                Case 2
                    Return 1
            End Select

            Return 0
        End Function

        Private Sub UpdatePreview()
            If _mapFile IsNot Nothing Then
                Dim colours = MapColours.CombineLayers(_mapFile.MapColoursImage, _mapFile.MapColoursManual)
                colours = MapColours.CombineLayers(_mapFile.MapColours, colours)

                Dim bitmap = MapColours.CreateBitmapFromMap(colours)

                If _mapImage.RawImage IsNot Nothing Then
                    If _mapImage.RenderPreview Then
                        Dim gr = Graphics.FromImage(bitmap)
                        Dim hatchBrush = New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Black, Color.White)
                        gr.DrawRectangle(New Pen(hatchBrush), _mapImage.X, _mapImage.Y, _mapImage.Width,
                                         _mapImage.Height)
                    End If
                End If

                Dim upscaledBitmap = MapColours.UpscaleBitmap(bitmap, 2)
                picMapPreview.Image = upscaledBitmap
            End If
        End Sub

        Private Sub previewUpdateWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) _
            Handles previewUpdateWorker.DoWork
            While Not previewUpdateWorker.CancellationPending
                While _previewUpdateNeeded
                    UpdatePreview()
                    _previewUpdateNeeded = False
                End While
            End While
        End Sub

        Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
            CreateNew()
        End Sub

        Public Sub CreateNew()
            Try
                _mapFile = New MapFile(Nothing)
                _mapFile.CreateNew()

                cmbCompressionType.SelectedIndex = 1
                cmbDimension.SelectedIndex = 0

                _previewUpdateNeeded = True

                EnableControls()
                EnableControlsForNew()
            Catch ex As Exception
                MessageBox.Show(Me, "Cannot create new file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub EnableControls()
            btnMapImageSave.Enabled = True
            btnMapHeightmapSave.Enabled = True
            btnEditColors.Enabled = True

            cmbCompressionType.Enabled = True
            txtDataVersion.Enabled = True
            btnListDataVersion.Enabled = True

            txtScale.Enabled = True
            cmbDimension.Enabled = True

            chkTracking.Enabled = True
            chkUnlimitedTracking.Enabled = True
            chkLocked.Enabled = _mapFile.DataVersion >= 1921
            txtX.Enabled = True
            txtZ.Enabled = True
            btnBanners.Enabled = True
            btnMarkers.Enabled = True

            grpImage.Enabled = False

            btnSave.Enabled = True
            btnSaveAs.Enabled = True
        End Sub

        Private Sub EnableControlsForNew()
            txtFile.Enabled = False
            btnFileBrowse.Enabled = False
            btnFileLoad.Enabled = False

            grpImage.Enabled = True

            btnSave.Enabled = False
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
                Try
                    PrepareForSave()
                    _mapFile.SaveData(saveFileDlg.FileName)
                    MessageBox.Show(Me, "Saved to file successfully", "Minecraft Map Manager", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(Me, "Error saving to file", "Minecraft Map Manager", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub PrepareForSave()
            _mapFile.CompressionType = GetCompressionType()
            _mapFile.DataVersion = txtDataVersion.Value

            _mapFile.Scale = txtScale.Value
            _mapFile.Dimension = GetDimension()

            _mapFile.Tracking = chkTracking.Checked
            _mapFile.UnlimitedTracking = chkUnlimitedTracking.Checked
            _mapFile.Locked = chkLocked.Checked
            _mapFile.X = txtX.Value
            _mapFile.Z = txtZ.Value
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
            chkLocked.Enabled = txtDataVersion.Value >= MapFile.Version19w02a

            If Not getVersionWorker.IsBusy Then
                getVersionWorker.RunWorkerAsync()
            End If
        End Sub

        Private Sub btnMapImageSave_Click(sender As Object, e As EventArgs) Handles btnMapImageSave.Click
            If _mapFile Is Nothing Then
                MessageBox.Show(Me, "No data to save", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If

            Try
                SaveImage(MapColours.CreateBitmapFromMap(_mapFile.MapColours), "Save Map Image")

                MessageBox.Show(Me, "Saved image successfully", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, "Error saving image", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnMapHeightmapSave_Click(sender As Object, e As EventArgs) Handles btnMapHeightmapSave.Click
            If _mapFile Is Nothing Then
                MessageBox.Show(Me, "No data to save", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return
            End If

            Try
                SaveImage(MapColours.CreateHeightmapFromMap(_mapFile.MapColours), "Save Map Heightmap")

                MessageBox.Show(Me, "Saved heightmap successfully", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, "Error saving heightmap", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub SaveImage(bitmap As Bitmap, title As String)
            Dim saveFileDlg = New SaveFileDialog()
            saveFileDlg.Filter =
                "Image files (*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpg;*.jpeg;*.png;*.tiff;*.tif;*.wmf)|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpg;*.jpeg;*.png;*.tiff;*.tif;*.wmf|All files (*.*)|*.*"
            saveFileDlg.RestoreDirectory = True
            saveFileDlg.Title = title

            If saveFileDlg.ShowDialog() = DialogResult.OK Then
                Try
                    Dim format = GetImageFormat(saveFileDlg.FileName)
                    bitmap.Save(saveFileDlg.FileName, format)
                Catch ex As Exception
                    Throw
                End Try
            End If
        End Sub

        Private Function GetImageFormat(fileName As String) As ImageFormat
            Select Case Path.GetExtension(fileName).ToLower()
                Case ".bmp"
                    Return ImageFormat.Bmp
                Case ".emf"
                    Return ImageFormat.Emf
                Case ".exif"
                    Return ImageFormat.Exif
                Case ".gif"
                    Return ImageFormat.Gif
                Case ".ico"
                    Return ImageFormat.Icon
                Case ".jpeg", ".jpg"
                    Return ImageFormat.Jpeg
                Case ".Png"
                    Return ImageFormat.Png
                Case ".tiff", ".tif"
                    Return ImageFormat.Tiff
                Case ".wmf"
                    Return ImageFormat.Wmf
            End Select

            Return ImageFormat.Png
        End Function

        Private Sub btnEditColors_Click(sender As Object, e As EventArgs) Handles btnEditColors.Click
            Dim editColorsDlg = New MapEditColors()
            editColorsDlg.MapFile = _mapFile
            editColorsDlg.ShowDialog()
            _previewUpdateNeeded = True
        End Sub

        Private Sub UpdateImagePreview()
            picImagePreview.Image = _mapImage.RawImage
        End Sub

        Private Sub EnableImageControls()
            txtImageX.Enabled = True
            txtImageY.Enabled = True
            txtImageWidth.Enabled = True
            txtImageHeight.Enabled = True

            cmbImageInterpolation.Enabled = True
            cmbImageDithering.Enabled = True
            cmbImageColorDifference.Enabled = True
            btnImageAdvancedSettings.Enabled = True
        End Sub

        Private Sub DisableImageControls()
            txtImageX.Enabled = False
            txtImageY.Enabled = False
            txtImageWidth.Enabled = False
            txtImageHeight.Enabled = False

            cmbImageInterpolation.Enabled = False
            cmbImageDithering.Enabled = False
            cmbImageColorDifference.Enabled = False
            btnImageAdvancedSettings.Enabled = False
        End Sub

        Private Sub btnImageAdd_Click(sender As Object, e As EventArgs) Handles btnImageAdd.Click
            Dim bitmap = _mapImage.AddImage()
            If bitmap IsNot Nothing Then
                btnImageAdd.Enabled = False
                btnImageRemove.Enabled = True
                btnImageApply.Enabled = True
                EnableImageControls()

                _mapImage.X = txtImageX.Value
                _mapImage.Y = txtImageY.Value
                _mapImage.Width = txtImageWidth.Value
                _mapImage.Height = txtImageHeight.Value

                UpdateImagePreview()
                _previewUpdateNeeded = True
            End If
        End Sub

        Private Sub btnImageRemove_Click(sender As Object, e As EventArgs) Handles btnImageRemove.Click
            btnImageRemove.Enabled = False
            btnImageAdd.Enabled = True
            btnImageApply.Enabled = False
            btnImageEdit.Enabled = False
            DisableImageControls()

            _mapImage.RawImage = Nothing
            UpdateImagePreview()
            _previewUpdateNeeded = True
        End Sub

        Private Sub txtImageX_ValueChanged(sender As Object, e As EventArgs) _
            Handles txtImageX.ValueChanged, txtImageY.ValueChanged, txtImageWidth.ValueChanged,
                    txtImageHeight.ValueChanged

            Dim control = DirectCast(sender, NumericUpDown)
            Select Case control.Name
                Case "txtImageX"
                    _mapImage.X = control.Value
                Case "txtImageY"
                    _mapImage.Y = control.Value
                Case "txtImageWidth"
                    _mapImage.Width = control.Value
                Case "txtImageHeight"
                    _mapImage.Height = control.Value
            End Select

            _previewUpdateNeeded = True
        End Sub

        Private Sub btnImageAdvancedSettings_Click(sender As Object, e As EventArgs) _
            Handles btnImageAdvancedSettings.Click
            MessageBox.Show(Me, "Colour profile, illuminant, custom illuminant and chromaticity coords",
                            "Advanced Settings")
        End Sub

        Private Sub btnImageEdit_Click(sender As Object, e As EventArgs) Handles btnImageEdit.Click
            _mapImage.RenderPreview = True
            _previewUpdateNeeded = True

            EnableImageControls()
            btnImageEdit.Enabled = False
            btnImageApply.Enabled = True
            btnImageRemove.Enabled = True
        End Sub

        Private Sub btnImageApply_Click(sender As Object, e As EventArgs) Handles btnImageApply.Click
            DisableImageControls()
            btnImageApply.Enabled = False
            btnImageEdit.Enabled = True
            btnImageRemove.Enabled = False

            Dim interpolation = CType(cmbImageInterpolation.SelectedIndex, MapImageInterpolation)
            Dim colourDifference = CType(cmbImageColorDifference.SelectedIndex, MapImageColourDifference)
            Dim dithering = CType(cmbImageDithering.SelectedIndex, MapImageDithering)
            _mapImage.ProcessSettings = New MapImageSettings(WorkingSpaces.sRGB, interpolation, colourDifference,
                                                             dithering)

            btnImageEdit.Enabled = False
            If Not processImageWorker.IsBusy Then
                processImageWorker.RunWorkerAsync()
            End If
        End Sub

        Private Sub processImageWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) _
            Handles processImageWorker.DoWork
            If _mapImage.ProcessImage(sender) Is Nothing Then
                MessageBox.Show(Me, "Error prcessing image", "Minecraft Map Manager", MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                processImageWorker.CancelAsync()
            End If
            _mapImage.ConvertToLayer(_mapFile.MapColoursImage, sender)
        End Sub

        Private Sub processImageWorker_ProgressChanged(sender As Object,
                                                       e As System.ComponentModel.ProgressChangedEventArgs) _
            Handles processImageWorker.ProgressChanged

            lblProgress.Text = e.UserState
            lblProgress.Refresh()
            barProgress.Value = e.ProgressPercentage
        End Sub

        Private Sub processImageWorker_RunWorkerCompleted(sender As Object,
                                                          e As System.ComponentModel.RunWorkerCompletedEventArgs) _
            Handles processImageWorker.RunWorkerCompleted
            _previewUpdateNeeded = True
            barProgress.Value = 0
            lblProgress.Text = ""
            btnImageEdit.Enabled = True
        End Sub
    End Class
End NameSpace