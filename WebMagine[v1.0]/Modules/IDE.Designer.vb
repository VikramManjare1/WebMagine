<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IDE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IDE))
        Me.MS = New System.Windows.Forms.MenuStrip()
        Me.MSFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSAddItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSSAddItemPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MSSAddItemMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.darcula = New System.Windows.Forms.ToolStripMenuItem()
        Me.pink = New System.Windows.Forms.ToolStripMenuItem()
        Me.navy = New System.Windows.Forms.ToolStripMenuItem()
        Me.red = New System.Windows.Forms.ToolStripMenuItem()
        Me.green = New System.Windows.Forms.ToolStripMenuItem()
        Me.orange = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSSAddItemIntro = New System.Windows.Forms.ToolStripMenuItem()
        Me.IntroSimpleCover = New System.Windows.Forms.ToolStripMenuItem()
        Me.IntroSimple = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.IntroImageCover = New System.Windows.Forms.ToolStripMenuItem()
        Me.IntroImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.IntroVideo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSViewInBrowser = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSSOptionsOnTOP = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtUpL1 = New System.Windows.Forms.LinkLabel()
        Me.BtDownL1 = New System.Windows.Forms.LinkLabel()
        Me.LBAddedItems = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.WebControl1 = New EO.WinForm.WebControl()
        Me.WebView1 = New EO.WebBrowser.WebView()
        Me.TS = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TSComboBoxActivePage = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SS = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.MS.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TS.SuspendLayout()
        Me.SS.SuspendLayout()
        Me.SuspendLayout()
        '
        'MS
        '
        Me.MS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MSFile, Me.MSAddItem, Me.MSRefresh, Me.MSViewInBrowser, Me.MSOptions, Me.MSAbout})
        Me.MS.Location = New System.Drawing.Point(0, 0)
        Me.MS.Name = "MS"
        Me.MS.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MS.Size = New System.Drawing.Size(1124, 24)
        Me.MS.TabIndex = 0
        Me.MS.TabStop = True
        Me.MS.Text = "MenuStrip1"
        '
        'MSFile
        '
        Me.MSFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectToolStripMenuItem, Me.OpenProjectToolStripMenuItem, Me.ToolStripSeparator6, Me.ExportToDiskToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MSFile.Name = "MSFile"
        Me.MSFile.Size = New System.Drawing.Size(37, 20)
        Me.MSFile.Text = "&File"
        '
        'NewProjectToolStripMenuItem
        '
        Me.NewProjectToolStripMenuItem.Name = "NewProjectToolStripMenuItem"
        Me.NewProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewProjectToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.NewProjectToolStripMenuItem.Text = "&New Project"
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.OpenProjectToolStripMenuItem.Text = "&Open Project"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(183, 6)
        '
        'ExportToDiskToolStripMenuItem
        '
        Me.ExportToDiskToolStripMenuItem.Name = "ExportToDiskToolStripMenuItem"
        Me.ExportToDiskToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ExportToDiskToolStripMenuItem.Text = "E&xport to Disk"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.EasyWebSimple.My.Resources.Resources.delete_16x16
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'MSAddItem
        '
        Me.MSAddItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MSSAddItemPage, Me.ToolStripSeparator1, Me.MSSAddItemMenu, Me.MSSAddItemIntro})
        Me.MSAddItem.Name = "MSAddItem"
        Me.MSAddItem.Size = New System.Drawing.Size(68, 20)
        Me.MSAddItem.Text = "Add &Item"
        '
        'MSSAddItemPage
        '
        Me.MSSAddItemPage.Name = "MSSAddItemPage"
        Me.MSSAddItemPage.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MSSAddItemPage.Size = New System.Drawing.Size(173, 22)
        Me.MSSAddItemPage.Text = "&Page"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(170, 6)
        '
        'MSSAddItemMenu
        '
        Me.MSSAddItemMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.darcula, Me.pink, Me.navy, Me.red, Me.green, Me.orange})
        Me.MSSAddItemMenu.Name = "MSSAddItemMenu"
        Me.MSSAddItemMenu.Size = New System.Drawing.Size(173, 22)
        Me.MSSAddItemMenu.Text = "&Menu"
        '
        'darcula
        '
        Me.darcula.Name = "darcula"
        Me.darcula.Size = New System.Drawing.Size(113, 22)
        Me.darcula.Text = "darcula"
        '
        'pink
        '
        Me.pink.Name = "pink"
        Me.pink.Size = New System.Drawing.Size(113, 22)
        Me.pink.Text = "pink"
        '
        'navy
        '
        Me.navy.Name = "navy"
        Me.navy.Size = New System.Drawing.Size(113, 22)
        Me.navy.Text = "navy"
        '
        'red
        '
        Me.red.Name = "red"
        Me.red.Size = New System.Drawing.Size(113, 22)
        Me.red.Text = "red"
        '
        'green
        '
        Me.green.Name = "green"
        Me.green.Size = New System.Drawing.Size(113, 22)
        Me.green.Text = "green"
        '
        'orange
        '
        Me.orange.Name = "orange"
        Me.orange.Size = New System.Drawing.Size(113, 22)
        Me.orange.Text = "orange"
        '
        'MSSAddItemIntro
        '
        Me.MSSAddItemIntro.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IntroSimpleCover, Me.IntroSimple, Me.ToolStripSeparator7, Me.IntroImageCover, Me.IntroImage, Me.ToolStripSeparator8, Me.IntroVideo})
        Me.MSSAddItemIntro.Name = "MSSAddItemIntro"
        Me.MSSAddItemIntro.Size = New System.Drawing.Size(173, 22)
        Me.MSSAddItemIntro.Text = "&Intro"
        '
        'IntroSimpleCover
        '
        Me.IntroSimpleCover.Name = "IntroSimpleCover"
        Me.IntroSimpleCover.Size = New System.Drawing.Size(244, 22)
        Me.IntroSimpleCover.Text = "Simple [Cover]"
        '
        'IntroSimple
        '
        Me.IntroSimple.Name = "IntroSimple"
        Me.IntroSimple.Size = New System.Drawing.Size(244, 22)
        Me.IntroSimple.Text = "Simple [Short]"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(241, 6)
        '
        'IntroImageCover
        '
        Me.IntroImageCover.Name = "IntroImageCover"
        Me.IntroImageCover.Size = New System.Drawing.Size(244, 22)
        Me.IntroImageCover.Text = "With Image [Cover Background]"
        '
        'IntroImage
        '
        Me.IntroImage.Name = "IntroImage"
        Me.IntroImage.Size = New System.Drawing.Size(244, 22)
        Me.IntroImage.Text = "With Image [Short,Side by Side]"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(241, 6)
        '
        'IntroVideo
        '
        Me.IntroVideo.Name = "IntroVideo"
        Me.IntroVideo.Size = New System.Drawing.Size(244, 22)
        Me.IntroVideo.Text = "With Video"
        '
        'MSRefresh
        '
        Me.MSRefresh.Name = "MSRefresh"
        Me.MSRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MSRefresh.Size = New System.Drawing.Size(58, 20)
        Me.MSRefresh.Text = "&Refresh"
        '
        'MSViewInBrowser
        '
        Me.MSViewInBrowser.Name = "MSViewInBrowser"
        Me.MSViewInBrowser.Size = New System.Drawing.Size(118, 20)
        Me.MSViewInBrowser.Text = "&Preview in Browser"
        '
        'MSOptions
        '
        Me.MSOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MSSOptionsOnTOP})
        Me.MSOptions.Name = "MSOptions"
        Me.MSOptions.Size = New System.Drawing.Size(61, 20)
        Me.MSOptions.Text = "&Options"
        '
        'MSSOptionsOnTOP
        '
        Me.MSSOptionsOnTOP.CheckOnClick = True
        Me.MSSOptionsOnTOP.Name = "MSSOptionsOnTOP"
        Me.MSSOptionsOnTOP.Size = New System.Drawing.Size(152, 22)
        Me.MSSOptionsOnTOP.Text = "Always on Top"
        '
        'MSAbout
        '
        Me.MSAbout.Name = "MSAbout"
        Me.MSAbout.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.MSAbout.Size = New System.Drawing.Size(52, 20)
        Me.MSAbout.Text = "&About"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.LBAddedItems)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(0, 49)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(250, 623)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Added Items"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(3, 577)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(244, 44)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tasks"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtUpL1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtDownL1, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 19)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(238, 22)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'BtUpL1
        '
        Me.BtUpL1.AutoSize = True
        Me.BtUpL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtUpL1.Enabled = False
        Me.BtUpL1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.BtUpL1.Location = New System.Drawing.Point(3, 3)
        Me.BtUpL1.Margin = New System.Windows.Forms.Padding(3)
        Me.BtUpL1.Name = "BtUpL1"
        Me.BtUpL1.Size = New System.Drawing.Size(113, 16)
        Me.BtUpL1.TabIndex = 4
        Me.BtUpL1.TabStop = True
        Me.BtUpL1.Text = "Move Up"
        Me.BtUpL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtDownL1
        '
        Me.BtDownL1.AutoSize = True
        Me.BtDownL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtDownL1.Enabled = False
        Me.BtDownL1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.BtDownL1.Location = New System.Drawing.Point(122, 3)
        Me.BtDownL1.Margin = New System.Windows.Forms.Padding(3)
        Me.BtDownL1.Name = "BtDownL1"
        Me.BtDownL1.Size = New System.Drawing.Size(113, 16)
        Me.BtDownL1.TabIndex = 3
        Me.BtDownL1.TabStop = True
        Me.BtDownL1.Text = "Move Down"
        Me.BtDownL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LBAddedItems
        '
        Me.LBAddedItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LBAddedItems.FormattingEnabled = True
        Me.LBAddedItems.ItemHeight = 15
        Me.LBAddedItems.Location = New System.Drawing.Point(3, 18)
        Me.LBAddedItems.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LBAddedItems.Name = "LBAddedItems"
        Me.LBAddedItems.Size = New System.Drawing.Size(244, 603)
        Me.LBAddedItems.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(874, 49)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(250, 623)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Properties"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.WebControl1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(250, 49)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(624, 623)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Inline Browser"
        '
        'WebControl1
        '
        Me.WebControl1.BackColor = System.Drawing.Color.White
        Me.WebControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebControl1.Location = New System.Drawing.Point(3, 18)
        Me.WebControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WebControl1.Name = "WebControl1"
        Me.WebControl1.Size = New System.Drawing.Size(618, 603)
        Me.WebControl1.TabIndex = 0
        Me.WebControl1.Text = "WebControl1"
        Me.WebControl1.WebView = Me.WebView1
        '
        'TS
        '
        Me.TS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator2})
        Me.TS.Location = New System.Drawing.Point(0, 24)
        Me.TS.Name = "TS"
        Me.TS.Size = New System.Drawing.Size(1124, 25)
        Me.TS.TabIndex = 4
        Me.TS.Text = "ToolStripBar"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSComboBoxActivePage})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripDropDownButton1.Text = "Change Active Page"
        '
        'TSComboBoxActivePage
        '
        Me.TSComboBoxActivePage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TSComboBoxActivePage.Name = "TSComboBoxActivePage"
        Me.TSComboBoxActivePage.Size = New System.Drawing.Size(121, 23)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'SS
        '
        Me.SS.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.SS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.ToolStripLabel2, Me.ToolStripSeparator4, Me.ToolStripLabel3, Me.ToolStripSeparator5, Me.ToolStripLabel4})
        Me.SS.Location = New System.Drawing.Point(0, 672)
        Me.SS.Name = "SS"
        Me.SS.Size = New System.Drawing.Size(1124, 25)
        Me.SS.TabIndex = 6
        Me.SS.Text = "ToolStripBar"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripLabel1.Text = "Current Page:"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripLabel2.Text = "ActiveDir"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripLabel3.Text = "Total HTML Pages"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripLabel4.Text = "Inline Browser Size"
        '
        'IDE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 697)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TS)
        Me.Controls.Add(Me.MS)
        Me.Controls.Add(Me.SS)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MS
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1140, 736)
        Me.Name = "IDE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IDE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MS.ResumeLayout(False)
        Me.MS.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.TS.ResumeLayout(False)
        Me.TS.PerformLayout()
        Me.SS.ResumeLayout(False)
        Me.SS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MS As MenuStrip
    Friend WithEvents MSFile As ToolStripMenuItem
    Friend WithEvents MSAddItem As ToolStripMenuItem
    Friend WithEvents MSRefresh As ToolStripMenuItem
    Friend WithEvents MSAbout As ToolStripMenuItem
    Friend WithEvents MSSAddItemMenu As ToolStripMenuItem
    Friend WithEvents darcula As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MSSAddItemIntro As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents WebControl1 As EO.WinForm.WebControl
    Friend WithEvents WebView1 As EO.WebBrowser.WebView
    Friend WithEvents TS As ToolStrip
    Friend WithEvents MSSAddItemPage As ToolStripMenuItem
    Friend WithEvents pink As ToolStripMenuItem
    Friend WithEvents navy As ToolStripMenuItem
    Friend WithEvents red As ToolStripMenuItem
    Friend WithEvents green As ToolStripMenuItem
    Friend WithEvents orange As ToolStripMenuItem
    Friend WithEvents IntroSimple As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents SS As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents TSComboBoxActivePage As ToolStripComboBox
    Friend WithEvents LBAddedItems As ListBox
    Friend WithEvents MSOptions As ToolStripMenuItem
    Friend WithEvents MSSOptionsOnTOP As ToolStripMenuItem
    Friend WithEvents MSViewInBrowser As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents IntroImage As ToolStripMenuItem
    Friend WithEvents IntroVideo As ToolStripMenuItem
    Friend WithEvents IntroImageCover As ToolStripMenuItem
    Friend WithEvents NewProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ExportToDiskToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents IntroSimpleCover As ToolStripMenuItem
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents BtDownL1 As LinkLabel
    Friend WithEvents BtUpL1 As LinkLabel
End Class
