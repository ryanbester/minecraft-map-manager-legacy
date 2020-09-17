Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EditMapDat
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.lblEditMap = New System.Windows.Forms.Label()
            Me.lblDataVersion = New System.Windows.Forms.Label()
            Me.txtDataVersion = New System.Windows.Forms.NumericUpDown()
            Me.btnListDataVersion = New System.Windows.Forms.Button()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lblFile = New System.Windows.Forms.Label()
            Me.txtFile = New System.Windows.Forms.TextBox()
            Me.btnFileBrowse = New System.Windows.Forms.Button()
            Me.btnFileLoad = New System.Windows.Forms.Button()
            Me.lblDataVersionName = New System.Windows.Forms.Label()
            Me.btnSaveAs = New System.Windows.Forms.Button()
            Me.picMapPreview = New System.Windows.Forms.PictureBox()
            Me.lblScale = New System.Windows.Forms.Label()
            Me.txtScale = New System.Windows.Forms.NumericUpDown()
            Me.lblDimension = New System.Windows.Forms.Label()
            Me.cmbDimension = New System.Windows.Forms.ComboBox()
            Me.chkTracking = New System.Windows.Forms.CheckBox()
            Me.chkUnlimitedTracking = New System.Windows.Forms.CheckBox()
            Me.chkLocked = New System.Windows.Forms.CheckBox()
            Me.txtX = New System.Windows.Forms.NumericUpDown()
            Me.lblX = New System.Windows.Forms.Label()
            Me.txtZ = New System.Windows.Forms.NumericUpDown()
            Me.lblZ = New System.Windows.Forms.Label()
            Me.btnBanners = New System.Windows.Forms.Button()
            Me.btnMarkers = New System.Windows.Forms.Button()
            Me.btnEditColors = New System.Windows.Forms.Button()
            Me.lblNbtCompressionType = New System.Windows.Forms.Label()
            Me.btnMapImageSave = New System.Windows.Forms.Button()
            Me.getVersionWorker = New MinecraftMapManager.UI.Controls.VersionBackgroundWorker()
            Me.cmbCompressionType = New System.Windows.Forms.ComboBox()
            Me.grpPreview = New System.Windows.Forms.GroupBox()
            Me.grpFile = New System.Windows.Forms.GroupBox()
            Me.grpMap = New System.Windows.Forms.GroupBox()
            Me.lblCenter = New System.Windows.Forms.Label()
            CType(Me.txtDataVersion, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.picMapPreview, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtScale, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtX, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtZ, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpPreview.SuspendLayout()
            Me.grpFile.SuspendLayout()
            Me.grpMap.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblEditMap
            '
            Me.lblEditMap.AutoSize = True
            Me.lblEditMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEditMap.Location = New System.Drawing.Point(13, 13)
            Me.lblEditMap.Name = "lblEditMap"
            Me.lblEditMap.Size = New System.Drawing.Size(84, 24)
            Me.lblEditMap.TabIndex = 0
            Me.lblEditMap.Text = "Edit Map"
            '
            'lblDataVersion
            '
            Me.lblDataVersion.AutoSize = True
            Me.lblDataVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDataVersion.Location = New System.Drawing.Point(13, 55)
            Me.lblDataVersion.Name = "lblDataVersion"
            Me.lblDataVersion.Size = New System.Drawing.Size(89, 16)
            Me.lblDataVersion.TabIndex = 4
            Me.lblDataVersion.Text = "Data Version:"
            '
            'txtDataVersion
            '
            Me.txtDataVersion.Enabled = False
            Me.txtDataVersion.Location = New System.Drawing.Point(108, 52)
            Me.txtDataVersion.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.txtDataVersion.Name = "txtDataVersion"
            Me.txtDataVersion.Size = New System.Drawing.Size(154, 20)
            Me.txtDataVersion.TabIndex = 5
            Me.txtDataVersion.Value = New Decimal(New Integer() {1626, 0, 0, 0})
            '
            'btnListDataVersion
            '
            Me.btnListDataVersion.Enabled = False
            Me.btnListDataVersion.Location = New System.Drawing.Point(268, 52)
            Me.btnListDataVersion.Name = "btnListDataVersion"
            Me.btnListDataVersion.Size = New System.Drawing.Size(75, 23)
            Me.btnListDataVersion.TabIndex = 6
            Me.btnListDataVersion.Text = "List..."
            Me.btnListDataVersion.UseVisualStyleBackColor = True
            '
            'btnSave
            '
            Me.btnSave.Enabled = False
            Me.btnSave.Location = New System.Drawing.Point(604, 444)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(75, 23)
            Me.btnSave.TabIndex = 7
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(442, 444)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 23)
            Me.btnCancel.TabIndex = 8
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'lblFile
            '
            Me.lblFile.AutoSize = True
            Me.lblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFile.Location = New System.Drawing.Point(14, 50)
            Me.lblFile.Name = "lblFile"
            Me.lblFile.Size = New System.Drawing.Size(33, 16)
            Me.lblFile.TabIndex = 9
            Me.lblFile.Text = "File:"
            '
            'txtFile
            '
            Me.txtFile.Location = New System.Drawing.Point(53, 50)
            Me.txtFile.Name = "txtFile"
            Me.txtFile.Size = New System.Drawing.Size(192, 20)
            Me.txtFile.TabIndex = 10
            '
            'btnFileBrowse
            '
            Me.btnFileBrowse.Location = New System.Drawing.Point(251, 50)
            Me.btnFileBrowse.Name = "btnFileBrowse"
            Me.btnFileBrowse.Size = New System.Drawing.Size(75, 23)
            Me.btnFileBrowse.TabIndex = 11
            Me.btnFileBrowse.Text = "Browse..."
            Me.btnFileBrowse.UseVisualStyleBackColor = True
            '
            'btnFileLoad
            '
            Me.btnFileLoad.Location = New System.Drawing.Point(332, 50)
            Me.btnFileLoad.Name = "btnFileLoad"
            Me.btnFileLoad.Size = New System.Drawing.Size(75, 23)
            Me.btnFileLoad.TabIndex = 12
            Me.btnFileLoad.Text = "Load"
            Me.btnFileLoad.UseVisualStyleBackColor = True
            '
            'lblDataVersionName
            '
            Me.lblDataVersionName.AutoSize = True
            Me.lblDataVersionName.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblDataVersionName.Location = New System.Drawing.Point(105, 75)
            Me.lblDataVersionName.Name = "lblDataVersionName"
            Me.lblDataVersionName.Size = New System.Drawing.Size(92, 13)
            Me.lblDataVersionName.TabIndex = 13
            Me.lblDataVersionName.Text = "Loading Version..."
            '
            'btnSaveAs
            '
            Me.btnSaveAs.Enabled = False
            Me.btnSaveAs.Location = New System.Drawing.Point(523, 444)
            Me.btnSaveAs.Name = "btnSaveAs"
            Me.btnSaveAs.Size = New System.Drawing.Size(75, 23)
            Me.btnSaveAs.TabIndex = 14
            Me.btnSaveAs.Text = "Save As..."
            Me.btnSaveAs.UseVisualStyleBackColor = True
            '
            'picMapPreview
            '
            Me.picMapPreview.Location = New System.Drawing.Point(18, 25)
            Me.picMapPreview.Name = "picMapPreview"
            Me.picMapPreview.Size = New System.Drawing.Size(256, 256)
            Me.picMapPreview.TabIndex = 15
            Me.picMapPreview.TabStop = False
            '
            'lblScale
            '
            Me.lblScale.AutoSize = True
            Me.lblScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScale.Location = New System.Drawing.Point(50, 19)
            Me.lblScale.Name = "lblScale"
            Me.lblScale.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.lblScale.Size = New System.Drawing.Size(46, 16)
            Me.lblScale.TabIndex = 17
            Me.lblScale.Text = "Scale:"
            '
            'txtScale
            '
            Me.txtScale.Location = New System.Drawing.Point(108, 19)
            Me.txtScale.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
            Me.txtScale.Name = "txtScale"
            Me.txtScale.Size = New System.Drawing.Size(120, 20)
            Me.txtScale.TabIndex = 18
            '
            'lblDimension
            '
            Me.lblDimension.AutoSize = True
            Me.lblDimension.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDimension.Location = New System.Drawing.Point(21, 53)
            Me.lblDimension.Name = "lblDimension"
            Me.lblDimension.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.lblDimension.Size = New System.Drawing.Size(75, 16)
            Me.lblDimension.TabIndex = 19
            Me.lblDimension.Text = "Dimension:"
            '
            'cmbDimension
            '
            Me.cmbDimension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbDimension.FormattingEnabled = True
            Me.cmbDimension.Items.AddRange(New Object() {"The Overworld", "The Nether", "The End"})
            Me.cmbDimension.Location = New System.Drawing.Point(107, 48)
            Me.cmbDimension.Name = "cmbDimension"
            Me.cmbDimension.Size = New System.Drawing.Size(121, 21)
            Me.cmbDimension.TabIndex = 20
            '
            'chkTracking
            '
            Me.chkTracking.AutoSize = True
            Me.chkTracking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkTracking.Location = New System.Drawing.Point(107, 75)
            Me.chkTracking.Name = "chkTracking"
            Me.chkTracking.Size = New System.Drawing.Size(80, 20)
            Me.chkTracking.TabIndex = 23
            Me.chkTracking.Text = "Tracking"
            Me.chkTracking.UseVisualStyleBackColor = True
            '
            'chkUnlimitedTracking
            '
            Me.chkUnlimitedTracking.AutoSize = True
            Me.chkUnlimitedTracking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkUnlimitedTracking.Location = New System.Drawing.Point(193, 75)
            Me.chkUnlimitedTracking.Name = "chkUnlimitedTracking"
            Me.chkUnlimitedTracking.Size = New System.Drawing.Size(139, 20)
            Me.chkUnlimitedTracking.TabIndex = 24
            Me.chkUnlimitedTracking.Text = "Unlimited Tracking"
            Me.chkUnlimitedTracking.UseVisualStyleBackColor = True
            '
            'chkLocked
            '
            Me.chkLocked.AutoSize = True
            Me.chkLocked.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLocked.Location = New System.Drawing.Point(107, 101)
            Me.chkLocked.Name = "chkLocked"
            Me.chkLocked.Size = New System.Drawing.Size(72, 20)
            Me.chkLocked.TabIndex = 25
            Me.chkLocked.Text = "Locked"
            Me.chkLocked.UseVisualStyleBackColor = True
            '
            'txtX
            '
            Me.txtX.Location = New System.Drawing.Point(108, 155)
            Me.txtX.Maximum = New Decimal(New Integer() {60000000, 0, 0, 0})
            Me.txtX.Minimum = New Decimal(New Integer() {60000000, 0, 0, -2147483648})
            Me.txtX.Name = "txtX"
            Me.txtX.Size = New System.Drawing.Size(120, 20)
            Me.txtX.TabIndex = 27
            '
            'lblX
            '
            Me.lblX.AutoSize = True
            Me.lblX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblX.Location = New System.Drawing.Point(77, 155)
            Me.lblX.Name = "lblX"
            Me.lblX.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.lblX.Size = New System.Drawing.Size(19, 16)
            Me.lblX.TabIndex = 26
            Me.lblX.Text = "X:"
            '
            'txtZ
            '
            Me.txtZ.Location = New System.Drawing.Point(107, 181)
            Me.txtZ.Maximum = New Decimal(New Integer() {60000000, 0, 0, 0})
            Me.txtZ.Minimum = New Decimal(New Integer() {60000000, 0, 0, -2147483648})
            Me.txtZ.Name = "txtZ"
            Me.txtZ.Size = New System.Drawing.Size(120, 20)
            Me.txtZ.TabIndex = 29
            '
            'lblZ
            '
            Me.lblZ.AutoSize = True
            Me.lblZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblZ.Location = New System.Drawing.Point(77, 181)
            Me.lblZ.Name = "lblZ"
            Me.lblZ.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.lblZ.Size = New System.Drawing.Size(19, 16)
            Me.lblZ.TabIndex = 28
            Me.lblZ.Text = "Z:"
            '
            'btnBanners
            '
            Me.btnBanners.Location = New System.Drawing.Point(107, 210)
            Me.btnBanners.Name = "btnBanners"
            Me.btnBanners.Size = New System.Drawing.Size(75, 23)
            Me.btnBanners.TabIndex = 30
            Me.btnBanners.Text = "Banners..."
            Me.btnBanners.UseVisualStyleBackColor = True
            '
            'btnMarkers
            '
            Me.btnMarkers.Location = New System.Drawing.Point(188, 210)
            Me.btnMarkers.Name = "btnMarkers"
            Me.btnMarkers.Size = New System.Drawing.Size(75, 23)
            Me.btnMarkers.TabIndex = 31
            Me.btnMarkers.Text = "Markers..."
            Me.btnMarkers.UseVisualStyleBackColor = True
            '
            'btnEditColors
            '
            Me.btnEditColors.Location = New System.Drawing.Point(68, 316)
            Me.btnEditColors.Name = "btnEditColors"
            Me.btnEditColors.Size = New System.Drawing.Size(157, 23)
            Me.btnEditColors.TabIndex = 32
            Me.btnEditColors.Text = "Edit Colours Manually..."
            Me.btnEditColors.UseVisualStyleBackColor = True
            '
            'lblNbtCompressionType
            '
            Me.lblNbtCompressionType.AutoSize = True
            Me.lblNbtCompressionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNbtCompressionType.Location = New System.Drawing.Point(13, 26)
            Me.lblNbtCompressionType.Name = "lblNbtCompressionType"
            Me.lblNbtCompressionType.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.lblNbtCompressionType.Size = New System.Drawing.Size(157, 16)
            Me.lblNbtCompressionType.TabIndex = 33
            Me.lblNbtCompressionType.Text = "NBT Compression Type:"
            '
            'btnMapImageSave
            '
            Me.btnMapImageSave.Location = New System.Drawing.Point(84, 287)
            Me.btnMapImageSave.Name = "btnMapImageSave"
            Me.btnMapImageSave.Size = New System.Drawing.Size(124, 23)
            Me.btnMapImageSave.TabIndex = 35
            Me.btnMapImageSave.Text = "Save Image..."
            Me.btnMapImageSave.UseVisualStyleBackColor = True
            '
            'getVersionWorker
            '
            Me.getVersionWorker.DataVersionControl = Me.txtDataVersion
            Me.getVersionWorker.VersionLabel = Me.lblDataVersionName
            '
            'cmbCompressionType
            '
            Me.cmbCompressionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCompressionType.FormattingEnabled = True
            Me.cmbCompressionType.Items.AddRange(New Object() {"None", "GZip", "ZLib"})
            Me.cmbCompressionType.Location = New System.Drawing.Point(176, 25)
            Me.cmbCompressionType.Name = "cmbCompressionType"
            Me.cmbCompressionType.Size = New System.Drawing.Size(167, 21)
            Me.cmbCompressionType.TabIndex = 36
            '
            'grpPreview
            '
            Me.grpPreview.Controls.Add(Me.btnEditColors)
            Me.grpPreview.Controls.Add(Me.picMapPreview)
            Me.grpPreview.Controls.Add(Me.btnMapImageSave)
            Me.grpPreview.Location = New System.Drawing.Point(17, 89)
            Me.grpPreview.Name = "grpPreview"
            Me.grpPreview.Size = New System.Drawing.Size(292, 349)
            Me.grpPreview.TabIndex = 37
            Me.grpPreview.TabStop = False
            Me.grpPreview.Text = "Map Preview"
            '
            'grpFile
            '
            Me.grpFile.Controls.Add(Me.cmbCompressionType)
            Me.grpFile.Controls.Add(Me.lblNbtCompressionType)
            Me.grpFile.Controls.Add(Me.btnListDataVersion)
            Me.grpFile.Controls.Add(Me.lblDataVersion)
            Me.grpFile.Controls.Add(Me.txtDataVersion)
            Me.grpFile.Controls.Add(Me.lblDataVersionName)
            Me.grpFile.Location = New System.Drawing.Point(330, 89)
            Me.grpFile.Name = "grpFile"
            Me.grpFile.Size = New System.Drawing.Size(349, 100)
            Me.grpFile.TabIndex = 38
            Me.grpFile.TabStop = False
            Me.grpFile.Text = "File"
            '
            'grpMap
            '
            Me.grpMap.Controls.Add(Me.btnMarkers)
            Me.grpMap.Controls.Add(Me.btnBanners)
            Me.grpMap.Controls.Add(Me.lblCenter)
            Me.grpMap.Controls.Add(Me.txtScale)
            Me.grpMap.Controls.Add(Me.lblScale)
            Me.grpMap.Controls.Add(Me.lblDimension)
            Me.grpMap.Controls.Add(Me.txtZ)
            Me.grpMap.Controls.Add(Me.cmbDimension)
            Me.grpMap.Controls.Add(Me.lblZ)
            Me.grpMap.Controls.Add(Me.chkTracking)
            Me.grpMap.Controls.Add(Me.txtX)
            Me.grpMap.Controls.Add(Me.lblX)
            Me.grpMap.Controls.Add(Me.chkUnlimitedTracking)
            Me.grpMap.Controls.Add(Me.chkLocked)
            Me.grpMap.Location = New System.Drawing.Point(330, 195)
            Me.grpMap.Name = "grpMap"
            Me.grpMap.Size = New System.Drawing.Size(349, 243)
            Me.grpMap.TabIndex = 39
            Me.grpMap.TabStop = False
            Me.grpMap.Text = "Map"
            '
            'lblCenter
            '
            Me.lblCenter.AutoSize = True
            Me.lblCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCenter.Location = New System.Drawing.Point(21, 128)
            Me.lblCenter.Name = "lblCenter"
            Me.lblCenter.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.lblCenter.Size = New System.Drawing.Size(80, 16)
            Me.lblCenter.TabIndex = 30
            Me.lblCenter.Text = "Map Center:"
            '
            'EditMapDat
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(697, 481)
            Me.Controls.Add(Me.btnSaveAs)
            Me.Controls.Add(Me.btnFileLoad)
            Me.Controls.Add(Me.btnFileBrowse)
            Me.Controls.Add(Me.txtFile)
            Me.Controls.Add(Me.lblFile)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.lblEditMap)
            Me.Controls.Add(Me.grpPreview)
            Me.Controls.Add(Me.grpFile)
            Me.Controls.Add(Me.grpMap)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "EditMapDat"
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Edit Map"
            Me.TopMost = True
            CType(Me.txtDataVersion, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.picMapPreview, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtScale, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtX, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtZ, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpPreview.ResumeLayout(False)
            Me.grpFile.ResumeLayout(False)
            Me.grpFile.PerformLayout()
            Me.grpMap.ResumeLayout(False)
            Me.grpMap.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblEditMap As Label
        Friend WithEvents lblDataVersion As Label
        Friend WithEvents txtDataVersion As NumericUpDown
        Friend WithEvents btnListDataVersion As Button
        Friend WithEvents btnSave As Button
        Friend WithEvents btnCancel As Button
        Friend WithEvents lblFile As Label
        Friend WithEvents txtFile As TextBox
        Friend WithEvents btnFileBrowse As Button
        Friend WithEvents btnFileLoad As Button
        Friend WithEvents lblDataVersionName As Label
        Friend WithEvents getVersionWorker As Controls.VersionBackgroundWorker
        Friend WithEvents btnSaveAs As Button
        Friend WithEvents picMapPreview As PictureBox
        Friend WithEvents lblScale As Label
        Friend WithEvents txtScale As NumericUpDown
        Friend WithEvents lblDimension As Label
        Friend WithEvents cmbDimension As ComboBox
        Friend WithEvents chkTracking As CheckBox
        Friend WithEvents chkUnlimitedTracking As CheckBox
        Friend WithEvents chkLocked As CheckBox
        Friend WithEvents txtX As NumericUpDown
        Friend WithEvents lblX As Label
        Friend WithEvents txtZ As NumericUpDown
        Friend WithEvents lblZ As Label
        Friend WithEvents btnBanners As Button
        Friend WithEvents btnMarkers As Button
        Friend WithEvents btnEditColors As Button
        Friend WithEvents lblNbtCompressionType As Label
        Friend WithEvents btnMapImageSave As Button
        Friend WithEvents cmbCompressionType As ComboBox
        Friend WithEvents grpPreview As GroupBox
        Friend WithEvents grpFile As GroupBox
        Friend WithEvents grpMap As GroupBox
        Friend WithEvents lblCenter As Label
    End Class
End NameSpace