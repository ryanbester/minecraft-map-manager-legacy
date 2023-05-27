<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapEditColors
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
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.btnDraw = New System.Windows.Forms.CheckBox()
        Me.btnErase = New System.Windows.Forms.CheckBox()
        Me.chkShowImage = New System.Windows.Forms.CheckBox()
        Me.grpTool = New System.Windows.Forms.GroupBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtToolSize = New System.Windows.Forms.NumericUpDown()
        Me.grpColor = New System.Windows.Forms.GroupBox()
        Me.lsbColourVariant = New System.Windows.Forms.ListBox()
        Me.lsbColourBase = New System.Windows.Forms.ListBox()
        Me.lblVariant = New System.Windows.Forms.Label()
        Me.lblBaseColour = New System.Windows.Forms.Label()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.ImageBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTool.SuspendLayout()
        CType(Me.txtToolSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpColor.SuspendLayout()
        Me.SuspendLayout()
        '
        'picImage
        '
        Me.picImage.Cursor = System.Windows.Forms.Cursors.Cross
        Me.picImage.Location = New System.Drawing.Point(12, 12)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(512, 512)
        Me.picImage.TabIndex = 0
        Me.picImage.TabStop = False
        '
        'btnDraw
        '
        Me.btnDraw.Appearance = System.Windows.Forms.Appearance.Button
        Me.btnDraw.AutoSize = True
        Me.btnDraw.Checked = True
        Me.btnDraw.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnDraw.Location = New System.Drawing.Point(553, 12)
        Me.btnDraw.Name = "btnDraw"
        Me.btnDraw.Size = New System.Drawing.Size(42, 23)
        Me.btnDraw.TabIndex = 1
        Me.btnDraw.Text = "Draw"
        Me.btnDraw.UseVisualStyleBackColor = True
        '
        'btnErase
        '
        Me.btnErase.Appearance = System.Windows.Forms.Appearance.Button
        Me.btnErase.AutoSize = True
        Me.btnErase.Location = New System.Drawing.Point(553, 41)
        Me.btnErase.Name = "btnErase"
        Me.btnErase.Size = New System.Drawing.Size(44, 23)
        Me.btnErase.TabIndex = 2
        Me.btnErase.Text = "Erase"
        Me.btnErase.UseVisualStyleBackColor = True
        '
        'chkShowImage
        '
        Me.chkShowImage.AutoSize = True
        Me.chkShowImage.Location = New System.Drawing.Point(531, 506)
        Me.chkShowImage.Name = "chkShowImage"
        Me.chkShowImage.Size = New System.Drawing.Size(85, 17)
        Me.chkShowImage.TabIndex = 3
        Me.chkShowImage.Text = "Show Image"
        Me.chkShowImage.UseVisualStyleBackColor = True
        '
        'grpTool
        '
        Me.grpTool.Controls.Add(Me.lblSize)
        Me.grpTool.Controls.Add(Me.txtToolSize)
        Me.grpTool.Location = New System.Drawing.Point(622, 13)
        Me.grpTool.Name = "grpTool"
        Me.grpTool.Size = New System.Drawing.Size(350, 51)
        Me.grpTool.TabIndex = 4
        Me.grpTool.TabStop = False
        Me.grpTool.Text = "Tool"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(7, 20)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(30, 13)
        Me.lblSize.TabIndex = 1
        Me.lblSize.Text = "Size:"
        '
        'txtToolSize
        '
        Me.txtToolSize.Location = New System.Drawing.Point(43, 18)
        Me.txtToolSize.Name = "txtToolSize"
        Me.txtToolSize.Size = New System.Drawing.Size(120, 20)
        Me.txtToolSize.TabIndex = 0
        Me.txtToolSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'grpColor
        '
        Me.grpColor.Controls.Add(Me.lsbColourVariant)
        Me.grpColor.Controls.Add(Me.lsbColourBase)
        Me.grpColor.Controls.Add(Me.lblVariant)
        Me.grpColor.Controls.Add(Me.lblBaseColour)
        Me.grpColor.Location = New System.Drawing.Point(622, 70)
        Me.grpColor.Name = "grpColor"
        Me.grpColor.Size = New System.Drawing.Size(350, 425)
        Me.grpColor.TabIndex = 6
        Me.grpColor.TabStop = False
        Me.grpColor.Text = "Colour"
        '
        'lsbColourVariant
        '
        Me.lsbColourVariant.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lsbColourVariant.FormattingEnabled = True
        Me.lsbColourVariant.Location = New System.Drawing.Point(10, 278)
        Me.lsbColourVariant.Name = "lsbColourVariant"
        Me.lsbColourVariant.Size = New System.Drawing.Size(334, 134)
        Me.lsbColourVariant.TabIndex = 3
        '
        'lsbColourBase
        '
        Me.lsbColourBase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lsbColourBase.FormattingEnabled = True
        Me.lsbColourBase.Location = New System.Drawing.Point(10, 40)
        Me.lsbColourBase.Name = "lsbColourBase"
        Me.lsbColourBase.Size = New System.Drawing.Size(334, 212)
        Me.lsbColourBase.TabIndex = 2
        '
        'lblVariant
        '
        Me.lblVariant.AutoSize = True
        Me.lblVariant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariant.Location = New System.Drawing.Point(10, 255)
        Me.lblVariant.Name = "lblVariant"
        Me.lblVariant.Size = New System.Drawing.Size(64, 20)
        Me.lblVariant.TabIndex = 1
        Me.lblVariant.Text = "Variant:"
        '
        'lblBaseColour
        '
        Me.lblBaseColour.AutoSize = True
        Me.lblBaseColour.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseColour.Location = New System.Drawing.Point(10, 16)
        Me.lblBaseColour.Name = "lblBaseColour"
        Me.lblBaseColour.Size = New System.Drawing.Size(50, 20)
        Me.lblBaseColour.TabIndex = 0
        Me.lblBaseColour.Text = "Base:"
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(899, 501)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(75, 23)
        Me.btnDone.TabIndex = 7
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'ImageBackgroundWorker
        '
        Me.ImageBackgroundWorker.WorkerSupportsCancellation = True
        '
        'MapEditColors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 536)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.grpColor)
        Me.Controls.Add(Me.grpTool)
        Me.Controls.Add(Me.chkShowImage)
        Me.Controls.Add(Me.btnErase)
        Me.Controls.Add(Me.btnDraw)
        Me.Controls.Add(Me.picImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MapEditColors"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Edit Map Colours"
        Me.TopMost = True
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTool.ResumeLayout(False)
        Me.grpTool.PerformLayout()
        CType(Me.txtToolSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpColor.ResumeLayout(False)
        Me.grpColor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picImage As PictureBox
    Friend WithEvents btnDraw As CheckBox
    Friend WithEvents btnErase As CheckBox
    Friend WithEvents chkShowImage As CheckBox
    Friend WithEvents grpTool As GroupBox
    Friend WithEvents grpColor As GroupBox
    Friend WithEvents btnDone As Button
    Friend WithEvents lblSize As Label
    Friend WithEvents txtToolSize As NumericUpDown
    Friend WithEvents lblBaseColour As Label
    Friend WithEvents lblVariant As Label
    Friend WithEvents lsbColourBase As ListBox
    Friend WithEvents lsbColourVariant As ListBox
    Friend WithEvents ImageBackgroundWorker As System.ComponentModel.BackgroundWorker
End Class
