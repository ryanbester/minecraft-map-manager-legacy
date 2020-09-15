Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AboutDialog
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
            Me.lblAboutTitle = New System.Windows.Forms.Label()
            Me.lblCopyright = New System.Windows.Forms.Label()
            Me.btnOk = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblAboutTitle
            '
            Me.lblAboutTitle.AutoSize = True
            Me.lblAboutTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAboutTitle.Location = New System.Drawing.Point(14, 9)
            Me.lblAboutTitle.Name = "lblAboutTitle"
            Me.lblAboutTitle.Size = New System.Drawing.Size(240, 25)
            Me.lblAboutTitle.TabIndex = 0
            Me.lblAboutTitle.Text = "Minecraft Map Manager"
            Me.lblAboutTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCopyright
            '
            Me.lblCopyright.AutoSize = True
            Me.lblCopyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCopyright.Location = New System.Drawing.Point(16, 43)
            Me.lblCopyright.Name = "lblCopyright"
            Me.lblCopyright.Size = New System.Drawing.Size(193, 16)
            Me.lblCopyright.TabIndex = 1
            Me.lblCopyright.Text = "Copyright (C) 2020 Ryan Bester"
            '
            'btnOk
            '
            Me.btnOk.Location = New System.Drawing.Point(264, 94)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(75, 23)
            Me.btnOk.TabIndex = 2
            Me.btnOk.Text = "OK"
            Me.btnOk.UseVisualStyleBackColor = True
            '
            'AboutDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(351, 129)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.lblCopyright)
            Me.Controls.Add(Me.lblAboutTitle)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AboutDialog"
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "About Minecraft Map Manager"
            Me.TopMost = True
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblAboutTitle As Label
        Friend WithEvents lblCopyright As Label
        Friend WithEvents btnOk As Button
    End Class
End NameSpace