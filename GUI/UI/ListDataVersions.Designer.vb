Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ListDataVersions
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
            Me.lblDataVersions = New System.Windows.Forms.Label()
            Me.btnSelect = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lvDataVersions = New System.Windows.Forms.ListView()
            Me.headDataVersion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.headClientVersion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.headProtocolVersion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.getDataVersionsWorker = New System.ComponentModel.BackgroundWorker()
            Me.SuspendLayout()
            '
            'lblDataVersions
            '
            Me.lblDataVersions.AutoSize = True
            Me.lblDataVersions.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDataVersions.Location = New System.Drawing.Point(12, 9)
            Me.lblDataVersions.Name = "lblDataVersions"
            Me.lblDataVersions.Size = New System.Drawing.Size(131, 24)
            Me.lblDataVersions.TabIndex = 0
            Me.lblDataVersions.Text = "Data Versions:"
            '
            'btnSelect
            '
            Me.btnSelect.Location = New System.Drawing.Point(269, 348)
            Me.btnSelect.Name = "btnSelect"
            Me.btnSelect.Size = New System.Drawing.Size(75, 23)
            Me.btnSelect.TabIndex = 1
            Me.btnSelect.Text = "Select"
            Me.btnSelect.UseVisualStyleBackColor = True
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(188, 348)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 23)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'lvDataVersions
            '
            Me.lvDataVersions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.headDataVersion, Me.headClientVersion, Me.headProtocolVersion})
            Me.lvDataVersions.Enabled = False
            Me.lvDataVersions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me.lvDataVersions.HideSelection = False
            Me.lvDataVersions.Location = New System.Drawing.Point(16, 37)
            Me.lvDataVersions.MultiSelect = False
            Me.lvDataVersions.Name = "lvDataVersions"
            Me.lvDataVersions.Size = New System.Drawing.Size(328, 305)
            Me.lvDataVersions.TabIndex = 3
            Me.lvDataVersions.UseCompatibleStateImageBehavior = False
            Me.lvDataVersions.View = System.Windows.Forms.View.Details
            '
            'headDataVersion
            '
            Me.headDataVersion.Text = "Data Version"
            Me.headDataVersion.Width = 81
            '
            'headClientVersion
            '
            Me.headClientVersion.Text = "Client Version"
            Me.headClientVersion.Width = 159
            '
            'headProtocolVersion
            '
            Me.headProtocolVersion.Text = "Protocol Version"
            Me.headProtocolVersion.Width = 64
            '
            'getDataVersionsWorker
            '
            '
            'ListDataVersions
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(356, 383)
            Me.Controls.Add(Me.lvDataVersions)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSelect)
            Me.Controls.Add(Me.lblDataVersions)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ListDataVersions"
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Data Versions"
            Me.TopMost = True
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblDataVersions As Label
        Friend WithEvents btnSelect As Button
        Friend WithEvents btnCancel As Button
        Friend WithEvents lvDataVersions As ListView
        Friend WithEvents headDataVersion As ColumnHeader
        Friend WithEvents headClientVersion As ColumnHeader
        Friend WithEvents headProtocolVersion As ColumnHeader
        Friend WithEvents getDataVersionsWorker As System.ComponentModel.BackgroundWorker
    End Class
End NameSpace