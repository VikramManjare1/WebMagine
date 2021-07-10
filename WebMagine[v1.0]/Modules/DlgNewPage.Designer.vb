<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DlgNewPage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DlgNewPage))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LblxPath = New System.Windows.Forms.Label()
        Me.LblProjectPath = New System.Windows.Forms.Label()
        Me.LblProjectName = New System.Windows.Forms.Label()
        Me.TextBoxDefault = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(84, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 22)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 22)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(343, 113)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(162, 28)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.26316!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.73684!))
        Me.TableLayoutPanel2.Controls.Add(Me.LblxPath, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LblProjectPath, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LblProjectName, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxDefault, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(13, 12)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.47619!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.52381!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(495, 79)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'LblxPath
        '
        Me.LblxPath.AutoSize = True
        Me.LblxPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblxPath.Enabled = False
        Me.LblxPath.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblxPath.Location = New System.Drawing.Point(129, 27)
        Me.LblxPath.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LblxPath.Name = "LblxPath"
        Me.LblxPath.Size = New System.Drawing.Size(362, 49)
        Me.LblxPath.TabIndex = 5
        Me.LblxPath.Text = "Path"
        Me.LblxPath.UseCompatibleTextRendering = True
        '
        'LblProjectPath
        '
        Me.LblProjectPath.AutoSize = True
        Me.LblProjectPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblProjectPath.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblProjectPath.Location = New System.Drawing.Point(4, 27)
        Me.LblProjectPath.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LblProjectPath.Name = "LblProjectPath"
        Me.LblProjectPath.Size = New System.Drawing.Size(117, 49)
        Me.LblProjectPath.TabIndex = 4
        Me.LblProjectPath.Text = "Page File Path"
        '
        'LblProjectName
        '
        Me.LblProjectName.AutoSize = True
        Me.LblProjectName.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblProjectName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblProjectName.Location = New System.Drawing.Point(4, 3)
        Me.LblProjectName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LblProjectName.Name = "LblProjectName"
        Me.LblProjectName.Size = New System.Drawing.Size(117, 15)
        Me.LblProjectName.TabIndex = 3
        Me.LblProjectName.Text = "Enter Page Name"
        '
        'TextBoxDefault
        '
        Me.TextBoxDefault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDefault.Location = New System.Drawing.Point(128, 2)
        Me.TextBoxDefault.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxDefault.MaxLength = 15
        Me.TextBoxDefault.Name = "TextBoxDefault"
        Me.TextBoxDefault.Size = New System.Drawing.Size(364, 23)
        Me.TextBoxDefault.TabIndex = 0
        '
        'DlgNewPage
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(531, 153)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgNewPage"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Page Dialog"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents LblxPath As Label
    Friend WithEvents LblProjectPath As Label
    Friend WithEvents LblProjectName As Label
    Friend WithEvents TextBoxDefault As TextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
End Class
