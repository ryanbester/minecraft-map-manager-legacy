Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EditIdCounts
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
            Me.lblEditIDCounts = New System.Windows.Forms.Label()
            Me.lblWarning = New System.Windows.Forms.Label()
            Me.lblID = New System.Windows.Forms.Label()
            Me.txtIDCount = New System.Windows.Forms.NumericUpDown()
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
            Me.getVersionWorker = New GUI.UI.Controls.VersionBackgroundWorker()
            Me.btnSaveAs = New System.Windows.Forms.Button()
            Me.btnCreateNew = New System.Windows.Forms.Button()
            CType(Me.txtIDCount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDataVersion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblEditIDCounts
            '
            Me.lblEditIDCounts.AutoSize = True
            Me.lblEditIDCounts.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEditIDCounts.Location = New System.Drawing.Point(13, 13)
            Me.lblEditIDCounts.Name = "lblEditIDCounts"
            Me.lblEditIDCounts.Size = New System.Drawing.Size(148, 24)
            Me.lblEditIDCounts.TabIndex = 0
            Me.lblEditIDCounts.Text = "Edit idcounts.dat"
            '
            'lblWarning
            '
            Me.lblWarning.AutoSize = True
            Me.lblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWarning.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.lblWarning.Location = New System.Drawing.Point(14, 46)
            Me.lblWarning.MaximumSize = New System.Drawing.Size(400, 0)
            Me.lblWarning.Name = "lblWarning"
            Me.lblWarning.Size = New System.Drawing.Size(393, 32)
            Me.lblWarning.TabIndex = 1
            Me.lblWarning.Text = "Warning: Entering an invalid ID could cause previous maps to be overwritten."
            '
            'lblID
            '
            Me.lblID.AutoSize = True
            Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblID.Location = New System.Drawing.Point(12, 152)
            Me.lblID.Name = "lblID"
            Me.lblID.Size = New System.Drawing.Size(93, 16)
            Me.lblID.TabIndex = 2
            Me.lblID.Text = "Latest map ID:"
            '
            'txtIDCount
            '
            Me.txtIDCount.Enabled = False
            Me.txtIDCount.Location = New System.Drawing.Point(128, 152)
            Me.txtIDCount.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.txtIDCount.Name = "txtIDCount"
            Me.txtIDCount.Size = New System.Drawing.Size(94, 20)
            Me.txtIDCount.TabIndex = 3
            '
            'lblDataVersion
            '
            Me.lblDataVersion.AutoSize = True
            Me.lblDataVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDataVersion.Location = New System.Drawing.Point(12, 184)
            Me.lblDataVersion.Name = "lblDataVersion"
            Me.lblDataVersion.Size = New System.Drawing.Size(89, 16)
            Me.lblDataVersion.TabIndex = 4
            Me.lblDataVersion.Text = "Data Version:"
            '
            'txtDataVersion
            '
            Me.txtDataVersion.Enabled = False
            Me.txtDataVersion.Location = New System.Drawing.Point(128, 184)
            Me.txtDataVersion.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.txtDataVersion.Name = "txtDataVersion"
            Me.txtDataVersion.Size = New System.Drawing.Size(94, 20)
            Me.txtDataVersion.TabIndex = 5
            Me.txtDataVersion.Value = New Decimal(New Integer() {1626, 0, 0, 0})
            '
            'btnListDataVersion
            '
            Me.btnListDataVersion.Enabled = False
            Me.btnListDataVersion.Location = New System.Drawing.Point(228, 184)
            Me.btnListDataVersion.Name = "btnListDataVersion"
            Me.btnListDataVersion.Size = New System.Drawing.Size(75, 23)
            Me.btnListDataVersion.TabIndex = 6
            Me.btnListDataVersion.Text = "List..."
            Me.btnListDataVersion.UseVisualStyleBackColor = True
            '
            'btnSave
            '
            Me.btnSave.Enabled = False
            Me.btnSave.Location = New System.Drawing.Point(327, 224)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(75, 23)
            Me.btnSave.TabIndex = 7
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(165, 224)
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
            Me.lblFile.Location = New System.Drawing.Point(14, 90)
            Me.lblFile.Name = "lblFile"
            Me.lblFile.Size = New System.Drawing.Size(33, 16)
            Me.lblFile.TabIndex = 9
            Me.lblFile.Text = "File:"
            '
            'txtFile
            '
            Me.txtFile.Location = New System.Drawing.Point(53, 90)
            Me.txtFile.Name = "txtFile"
            Me.txtFile.Size = New System.Drawing.Size(192, 20)
            Me.txtFile.TabIndex = 10
            '
            'btnFileBrowse
            '
            Me.btnFileBrowse.Location = New System.Drawing.Point(251, 90)
            Me.btnFileBrowse.Name = "btnFileBrowse"
            Me.btnFileBrowse.Size = New System.Drawing.Size(75, 23)
            Me.btnFileBrowse.TabIndex = 11
            Me.btnFileBrowse.Text = "Browse..."
            Me.btnFileBrowse.UseVisualStyleBackColor = True
            '
            'btnFileLoad
            '
            Me.btnFileLoad.Location = New System.Drawing.Point(332, 90)
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
            Me.lblDataVersionName.Location = New System.Drawing.Point(309, 189)
            Me.lblDataVersionName.Name = "lblDataVersionName"
            Me.lblDataVersionName.Size = New System.Drawing.Size(92, 13)
            Me.lblDataVersionName.TabIndex = 13
            Me.lblDataVersionName.Text = "Loading Version..."
            '
            'getVersionWorker
            '
            Me.getVersionWorker.DataVersionControl = Me.txtDataVersion
            Me.getVersionWorker.VersionLabel = Me.lblDataVersionName
            '
            'btnSaveAs
            '
            Me.btnSaveAs.Enabled = False
            Me.btnSaveAs.Location = New System.Drawing.Point(246, 224)
            Me.btnSaveAs.Name = "btnSaveAs"
            Me.btnSaveAs.Size = New System.Drawing.Size(75, 23)
            Me.btnSaveAs.TabIndex = 14
            Me.btnSaveAs.Text = "Save As..."
            Me.btnSaveAs.UseVisualStyleBackColor = True
            '
            'btnCreateNew
            '
            Me.btnCreateNew.Location = New System.Drawing.Point(251, 119)
            Me.btnCreateNew.Name = "btnCreateNew"
            Me.btnCreateNew.Size = New System.Drawing.Size(156, 23)
            Me.btnCreateNew.TabIndex = 15
            Me.btnCreateNew.Text = "Create New"
            Me.btnCreateNew.UseVisualStyleBackColor = True
            '
            'EditIdCounts
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(414, 260)
            Me.Controls.Add(Me.btnCreateNew)
            Me.Controls.Add(Me.btnSaveAs)
            Me.Controls.Add(Me.lblDataVersionName)
            Me.Controls.Add(Me.btnFileLoad)
            Me.Controls.Add(Me.btnFileBrowse)
            Me.Controls.Add(Me.txtFile)
            Me.Controls.Add(Me.lblFile)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.btnListDataVersion)
            Me.Controls.Add(Me.txtDataVersion)
            Me.Controls.Add(Me.lblDataVersion)
            Me.Controls.Add(Me.txtIDCount)
            Me.Controls.Add(Me.lblID)
            Me.Controls.Add(Me.lblWarning)
            Me.Controls.Add(Me.lblEditIDCounts)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "EditIdCounts"
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Edit idcounts.dat"
            Me.TopMost = True
            CType(Me.txtIDCount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDataVersion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblEditIDCounts As Label
        Friend WithEvents lblWarning As Label
        Friend WithEvents lblID As Label
        Friend WithEvents txtIDCount As NumericUpDown
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
        Friend WithEvents btnCreateNew As Button
    End Class
End NameSpace