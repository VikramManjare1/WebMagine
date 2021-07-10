<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Startup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Startup))
        Me.LblWelcome = New System.Windows.Forms.Label()
        Me.LblChooseAction = New System.Windows.Forms.Label()
        Me.BtCreate = New System.Windows.Forms.Button()
        Me.BtOpen = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DlgOpenProjectFile = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblWelcome
        '
        Me.LblWelcome.AutoSize = True
        Me.LblWelcome.Font = New System.Drawing.Font("Segoe UI Semilight", 16.25!)
        Me.LblWelcome.Location = New System.Drawing.Point(119, 128)
        Me.LblWelcome.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LblWelcome.Name = "LblWelcome"
        Me.LblWelcome.Size = New System.Drawing.Size(247, 30)
        Me.LblWelcome.TabIndex = 0
        Me.LblWelcome.Text = "Welcome to WebMagine"
        '
        'LblChooseAction
        '
        Me.LblChooseAction.AutoSize = True
        Me.LblChooseAction.Font = New System.Drawing.Font("Segoe UI Semilight", 13.25!)
        Me.LblChooseAction.Location = New System.Drawing.Point(181, 179)
        Me.LblChooseAction.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LblChooseAction.Name = "LblChooseAction"
        Me.LblChooseAction.Size = New System.Drawing.Size(123, 25)
        Me.LblChooseAction.TabIndex = 1
        Me.LblChooseAction.Text = "Choose Action"
        '
        'BtCreate
        '
        Me.BtCreate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtCreate.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.BtCreate.Location = New System.Drawing.Point(57, 214)
        Me.BtCreate.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.BtCreate.Name = "BtCreate"
        Me.BtCreate.Size = New System.Drawing.Size(170, 43)
        Me.BtCreate.TabIndex = 2
        Me.BtCreate.Text = "Create New Project"
        Me.BtCreate.UseVisualStyleBackColor = True
        '
        'BtOpen
        '
        Me.BtOpen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtOpen.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.BtOpen.Location = New System.Drawing.Point(257, 214)
        Me.BtOpen.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.BtOpen.Name = "BtOpen"
        Me.BtOpen.Size = New System.Drawing.Size(170, 43)
        Me.BtOpen.TabIndex = 3
        Me.BtOpen.Text = "Open Existing Project"
        Me.BtOpen.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.EasyWebSimple.My.Resources.Resources.Icon256
        Me.PictureBox1.Location = New System.Drawing.Point(192, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'DlgOpenProjectFile
        '
        Me.DlgOpenProjectFile.Filter = "Visual Web Studio Project(.*vws)|*.vws"
        '
        'Startup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 309)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtOpen)
        Me.Controls.Add(Me.BtCreate)
        Me.Controls.Add(Me.LblChooseAction)
        Me.Controls.Add(Me.LblWelcome)
        Me.Font = New System.Drawing.Font("Segoe UI Light", 13.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Startup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WebMagine Starter"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblWelcome As Label
    Friend WithEvents LblChooseAction As Label
    Friend WithEvents BtCreate As Button
    Friend WithEvents BtOpen As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DlgOpenProjectFile As OpenFileDialog
End Class
