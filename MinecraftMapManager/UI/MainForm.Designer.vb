Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MainForm
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.mainTableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.lblSelectAction = New System.Windows.Forms.Label()
            Me.buttonTableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.btnOpenMapDAT = New System.Windows.Forms.Button()
            Me.btnOpenSave = New System.Windows.Forms.Button()
            Me.btnCreateMapDAT = New System.Windows.Forms.Button()
            Me.btnEditIdcounts = New System.Windows.Forms.Button()
            Me.btnAbout = New System.Windows.Forms.Button()
            Me.btnHelp = New System.Windows.Forms.Button()
            Me.mainTableLayout.SuspendLayout()
            Me.buttonTableLayout.SuspendLayout()
            Me.SuspendLayout()
            '
            'mainTableLayout
            '
            Me.mainTableLayout.ColumnCount = 1
            Me.mainTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.mainTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.mainTableLayout.Controls.Add(Me.lblSelectAction, 0, 0)
            Me.mainTableLayout.Controls.Add(Me.buttonTableLayout, 0, 1)
            Me.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill
            Me.mainTableLayout.Location = New System.Drawing.Point(0, 0)
            Me.mainTableLayout.Margin = New System.Windows.Forms.Padding(0)
            Me.mainTableLayout.Name = "mainTableLayout"
            Me.mainTableLayout.RowCount = 2
            Me.mainTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.mainTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.mainTableLayout.Size = New System.Drawing.Size(584, 361)
            Me.mainTableLayout.TabIndex = 0
            '
            'lblSelectAction
            '
            Me.lblSelectAction.AutoSize = True
            Me.lblSelectAction.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSelectAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelectAction.Location = New System.Drawing.Point(13, 23)
            Me.lblSelectAction.Margin = New System.Windows.Forms.Padding(13, 23, 13, 13)
            Me.lblSelectAction.Name = "lblSelectAction"
            Me.lblSelectAction.Size = New System.Drawing.Size(558, 25)
            Me.lblSelectAction.TabIndex = 0
            Me.lblSelectAction.Text = "Select an action"
            Me.lblSelectAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'buttonTableLayout
            '
            Me.buttonTableLayout.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.buttonTableLayout.ColumnCount = 2
            Me.buttonTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.buttonTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.buttonTableLayout.Controls.Add(Me.btnHelp, 0, 2)
            Me.buttonTableLayout.Controls.Add(Me.btnAbout, 0, 2)
            Me.buttonTableLayout.Controls.Add(Me.btnEditIdcounts, 1, 1)
            Me.buttonTableLayout.Controls.Add(Me.btnCreateMapDAT, 0, 1)
            Me.buttonTableLayout.Controls.Add(Me.btnOpenSave, 1, 0)
            Me.buttonTableLayout.Controls.Add(Me.btnOpenMapDAT, 0, 0)
            Me.buttonTableLayout.Location = New System.Drawing.Point(42, 64)
            Me.buttonTableLayout.MaximumSize = New System.Drawing.Size(500, 300)
            Me.buttonTableLayout.MinimumSize = New System.Drawing.Size(300, 100)
            Me.buttonTableLayout.Name = "buttonTableLayout"
            Me.buttonTableLayout.RowCount = 3
            Me.buttonTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.buttonTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.buttonTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
            Me.buttonTableLayout.Size = New System.Drawing.Size(500, 294)
            Me.buttonTableLayout.TabIndex = 1
            '
            'btnOpenMapDAT
            '
            Me.btnOpenMapDAT.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnOpenMapDAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOpenMapDAT.Location = New System.Drawing.Point(10, 10)
            Me.btnOpenMapDAT.Margin = New System.Windows.Forms.Padding(10)
            Me.btnOpenMapDAT.Name = "btnOpenMapDAT"
            Me.btnOpenMapDAT.Size = New System.Drawing.Size(230, 100)
            Me.btnOpenMapDAT.TabIndex = 0
            Me.btnOpenMapDAT.Text = "Open map DAT file"
            Me.btnOpenMapDAT.UseVisualStyleBackColor = True
            '
            'btnOpenSave
            '
            Me.btnOpenSave.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnOpenSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOpenSave.Location = New System.Drawing.Point(260, 10)
            Me.btnOpenSave.Margin = New System.Windows.Forms.Padding(10)
            Me.btnOpenSave.Name = "btnOpenSave"
            Me.btnOpenSave.Size = New System.Drawing.Size(230, 100)
            Me.btnOpenSave.TabIndex = 1
            Me.btnOpenSave.Text = "Open save"
            Me.btnOpenSave.UseVisualStyleBackColor = True
            '
            'btnCreateMapDAT
            '
            Me.btnCreateMapDAT.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnCreateMapDAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateMapDAT.Location = New System.Drawing.Point(10, 130)
            Me.btnCreateMapDAT.Margin = New System.Windows.Forms.Padding(10)
            Me.btnCreateMapDAT.Name = "btnCreateMapDAT"
            Me.btnCreateMapDAT.Size = New System.Drawing.Size(230, 100)
            Me.btnCreateMapDAT.TabIndex = 2
            Me.btnCreateMapDAT.Text = "Create map DAT file"
            Me.btnCreateMapDAT.UseVisualStyleBackColor = True
            '
            'btnEditIdcounts
            '
            Me.btnEditIdcounts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnEditIdcounts.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEditIdcounts.Location = New System.Drawing.Point(260, 130)
            Me.btnEditIdcounts.Margin = New System.Windows.Forms.Padding(10)
            Me.btnEditIdcounts.Name = "btnEditIdcounts"
            Me.btnEditIdcounts.Size = New System.Drawing.Size(230, 100)
            Me.btnEditIdcounts.TabIndex = 3
            Me.btnEditIdcounts.Text = "Edit idcounts.dat"
            Me.btnEditIdcounts.UseVisualStyleBackColor = True
            '
            'btnAbout
            '
            Me.btnAbout.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAbout.Location = New System.Drawing.Point(260, 250)
            Me.btnAbout.Margin = New System.Windows.Forms.Padding(10)
            Me.btnAbout.Name = "btnAbout"
            Me.btnAbout.Size = New System.Drawing.Size(230, 34)
            Me.btnAbout.TabIndex = 4
            Me.btnAbout.Text = "About"
            Me.btnAbout.UseVisualStyleBackColor = True
            '
            'btnHelp
            '
            Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnHelp.Location = New System.Drawing.Point(10, 250)
            Me.btnHelp.Margin = New System.Windows.Forms.Padding(10)
            Me.btnHelp.Name = "btnHelp"
            Me.btnHelp.Size = New System.Drawing.Size(230, 34)
            Me.btnHelp.TabIndex = 5
            Me.btnHelp.Text = "Help"
            Me.btnHelp.UseVisualStyleBackColor = True
            '
            'MainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(584, 361)
            Me.Controls.Add(Me.mainTableLayout)
            Me.MinimumSize = New System.Drawing.Size(500, 300)
            Me.Name = "MainForm"
            Me.Text = "Minecraft Map Manager"
            Me.mainTableLayout.ResumeLayout(False)
            Me.mainTableLayout.PerformLayout()
            Me.buttonTableLayout.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mainTableLayout As TableLayoutPanel
        Friend WithEvents lblSelectAction As Label
        Friend WithEvents buttonTableLayout As TableLayoutPanel
        Friend WithEvents btnEditIdcounts As Button
        Friend WithEvents btnCreateMapDAT As Button
        Friend WithEvents btnOpenSave As Button
        Friend WithEvents btnOpenMapDAT As Button
        Friend WithEvents btnHelp As Button
        Friend WithEvents btnAbout As Button
    End Class
End NameSpace