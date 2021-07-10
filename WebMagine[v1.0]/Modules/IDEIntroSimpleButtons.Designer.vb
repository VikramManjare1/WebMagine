<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IDEIntroSimpleButtons
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IDEIntroSimpleButtons))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LBButtonItems = New System.Windows.Forms.ListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtDownL1 = New System.Windows.Forms.LinkLabel()
        Me.BtUpL1 = New System.Windows.Forms.LinkLabel()
        Me.BtRemoveL1 = New System.Windows.Forms.LinkLabel()
        Me.BtAddL1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PXG = New PropertyGridEx.PropertyGridEx()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(534, 316)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "IntroButtons"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(528, 294)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LBButtonItems)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 288)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buttons"
        '
        'LBButtonItems
        '
        Me.LBButtonItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LBButtonItems.FormattingEnabled = True
        Me.LBButtonItems.ItemHeight = 15
        Me.LBButtonItems.Location = New System.Drawing.Point(3, 19)
        Me.LBButtonItems.Name = "LBButtonItems"
        Me.LBButtonItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.LBButtonItems.Size = New System.Drawing.Size(252, 196)
        Me.LBButtonItems.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(3, 215)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(252, 70)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tasks"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtDownL1, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.BtUpL1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.BtRemoveL1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtAddL1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 19)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(246, 48)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'BtDownL1
        '
        Me.BtDownL1.AutoSize = True
        Me.BtDownL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtDownL1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.BtDownL1.Location = New System.Drawing.Point(126, 27)
        Me.BtDownL1.Margin = New System.Windows.Forms.Padding(3)
        Me.BtDownL1.Name = "BtDownL1"
        Me.BtDownL1.Size = New System.Drawing.Size(117, 18)
        Me.BtDownL1.TabIndex = 3
        Me.BtDownL1.TabStop = True
        Me.BtDownL1.Text = "Move Down"
        Me.BtDownL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtUpL1
        '
        Me.BtUpL1.AutoSize = True
        Me.BtUpL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtUpL1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.BtUpL1.Location = New System.Drawing.Point(3, 27)
        Me.BtUpL1.Margin = New System.Windows.Forms.Padding(3)
        Me.BtUpL1.Name = "BtUpL1"
        Me.BtUpL1.Size = New System.Drawing.Size(117, 18)
        Me.BtUpL1.TabIndex = 2
        Me.BtUpL1.TabStop = True
        Me.BtUpL1.Text = "Move Up"
        Me.BtUpL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtRemoveL1
        '
        Me.BtRemoveL1.AutoSize = True
        Me.BtRemoveL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtRemoveL1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.BtRemoveL1.Location = New System.Drawing.Point(126, 3)
        Me.BtRemoveL1.Margin = New System.Windows.Forms.Padding(3)
        Me.BtRemoveL1.Name = "BtRemoveL1"
        Me.BtRemoveL1.Size = New System.Drawing.Size(117, 18)
        Me.BtRemoveL1.TabIndex = 1
        Me.BtRemoveL1.TabStop = True
        Me.BtRemoveL1.Text = "Remove"
        Me.BtRemoveL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtAddL1
        '
        Me.BtAddL1.AutoSize = True
        Me.BtAddL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtAddL1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.BtAddL1.Location = New System.Drawing.Point(3, 3)
        Me.BtAddL1.Margin = New System.Windows.Forms.Padding(3)
        Me.BtAddL1.Name = "BtAddL1"
        Me.BtAddL1.Size = New System.Drawing.Size(117, 18)
        Me.BtAddL1.TabIndex = 0
        Me.BtAddL1.TabStop = True
        Me.BtAddL1.Text = "Add"
        Me.BtAddL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PXG)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(267, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(258, 288)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Properties"
        '
        'PXG
        '
        '
        '
        '
        Me.PXG.DocCommentDescription.AccessibleName = ""
        Me.PXG.DocCommentDescription.AutoEllipsis = True
        Me.PXG.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PXG.DocCommentDescription.Location = New System.Drawing.Point(3, 21)
        Me.PXG.DocCommentDescription.Name = ""
        Me.PXG.DocCommentDescription.Size = New System.Drawing.Size(246, 34)
        Me.PXG.DocCommentDescription.TabIndex = 1
        Me.PXG.DocCommentImage = Nothing
        '
        '
        '
        Me.PXG.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PXG.DocCommentTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PXG.DocCommentTitle.Location = New System.Drawing.Point(3, 3)
        Me.PXG.DocCommentTitle.Name = ""
        Me.PXG.DocCommentTitle.Size = New System.Drawing.Size(246, 18)
        Me.PXG.DocCommentTitle.TabIndex = 0
        Me.PXG.DocCommentTitle.UseMnemonic = False
        Me.PXG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PXG.Location = New System.Drawing.Point(3, 19)
        Me.PXG.Name = "PXG"
        Me.PXG.SelectedObject = CType(resources.GetObject("PXG.SelectedObject"), Object)
        Me.PXG.ShowCustomProperties = True
        Me.PXG.Size = New System.Drawing.Size(252, 266)
        Me.PXG.TabIndex = 1
        '
        '
        '
        Me.PXG.ToolStrip.AccessibleName = "ToolBar"
        Me.PXG.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.PXG.ToolStrip.AllowMerge = False
        Me.PXG.ToolStrip.AutoSize = False
        Me.PXG.ToolStrip.CanOverflow = False
        Me.PXG.ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.PXG.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PXG.ToolStrip.Location = New System.Drawing.Point(0, 1)
        Me.PXG.ToolStrip.Name = ""
        Me.PXG.ToolStrip.Padding = New System.Windows.Forms.Padding(2, 0, 1, 0)
        Me.PXG.ToolStrip.Size = New System.Drawing.Size(252, 25)
        Me.PXG.ToolStrip.TabIndex = 1
        Me.PXG.ToolStrip.TabStop = True
        Me.PXG.ToolStrip.Text = "PropertyGridToolBar"
        '
        'IDEIntroSimpleButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 316)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(550, 355)
        Me.Name = "IDEIntroSimpleButtons"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "IntroSimple Buttons Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents BtDownL1 As LinkLabel
    Friend WithEvents BtUpL1 As LinkLabel
    Friend WithEvents BtRemoveL1 As LinkLabel
    Friend WithEvents BtAddL1 As LinkLabel
    Friend WithEvents LBButtonItems As ListBox
    Friend WithEvents PXG As PropertyGridEx.PropertyGridEx
End Class
