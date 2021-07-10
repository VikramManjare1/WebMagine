Imports System.ComponentModel
Imports System.IO

Public Class IDE

#Region "Global Members"
    Private Shared _ActiveProject As String
    Private Shared _ActiveDir As String
    Private Shared _ActiveWebPage As String

    Public Property xpActiveProjectFullPath As String
        Get
            Return _ActiveDir + _ActiveProject
        End Get
        Set(value As String)
            If value.EndsWith(".vws") Then
                Dim info = New FileInfo(value)
                xpActiveProject = info.Name
                xpActiveDir = info.Directory.FullName
                xpActiveWebPage = fxABSReadXMLFile(value)
            Else
                fxMBShowMsgBoxOK("Internal Error: ActiveProject Not Valid.", MBType.Information)
            End If
        End Set
    End Property

    Public Property xpActiveProject As String
        Get
            Return _ActiveProject.Remove(_ActiveProject.LastIndexOf("."))
        End Get
        Set(value As String)
            If value.EndsWith(".vws") Then
                _ActiveProject = value
            Else
                fxMBShowMsgBoxOK("Internal Error: ActiveProject Not Valid.", MBType.Information)
            End If
        End Set
    End Property
    Public ReadOnly Property xpActiveDirName As String
        Get
            Dim info = New FileInfo(xpActiveProjectFullPath)
            Return info.Directory.Name
        End Get
    End Property
    Public Property xpActiveDir As String
        Get
            Return _ActiveDir
        End Get
        Set(value As String)
            If value.EndsWith("\") Then
                _ActiveDir = value
            Else
                _ActiveDir = value + "\"
            End If
        End Set
    End Property
    Public ReadOnly Property xpActiveWebPageFullPath As String
        Get
            Return _ActiveDir + _ActiveWebPage
        End Get
    End Property
    Public Property xpActiveWebPage As String
        Get
            Return _ActiveWebPage
        End Get
        Set(value As String)
            If value.EndsWith(".html") Then
                _ActiveWebPage = value
            Else
                fxMBShowMsgBoxOK("Internal Error: WebPage Not Valid.", MBType.Information)
            End If
        End Set
    End Property
    Public ReadOnly Property xpActiveImageDirPath As String
        Get
            Return xpActiveDir + "images\"
        End Get
    End Property
    Public ReadOnly Property xpActiveVideoDirPath As String
        Get
            Return xpActiveDir + "videos\"
        End Get
    End Property
#End Region

#Region "Constructor"
    Public Sub New(ByVal projectFullPath As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        xpActiveProjectFullPath = projectFullPath
        Text = xpActiveProject + "-" + "WebMagine Simple IDE"
    End Sub
#End Region

#Region "fx"
    Public Sub fxRefreshIDE(sender As String)
        fxRefreshIDE(sender, True, True, True)
    End Sub
    Public Sub fxRefreshIDE(sender As String, loadLBItems As Boolean, loadWebView1 As Boolean, loadProperties As Boolean)
        Dim ebl = Enabled
        Enabled = False
        'MessageBox.Show(sender)
        ToolStripLabel1.Text = "Current Page: " + xpActiveWebPage
        ToolStripLabel1.ToolTipText = xpActiveWebPageFullPath
        ToolStripLabel2.Text = "Active Directory: " + xpActiveDirName
        ToolStripLabel2.ToolTipText = xpActiveDir
        Dim TempFiles = Directory.GetFiles(xpActiveDir, "*.html")
        ToolStripLabel3.Text = "Total HTML Pages: " + TempFiles.Count().ToString
        If TempFiles.Count > 0 Then
            Dim tooltiptemp As String = "{"
            TSComboBoxActivePage.Items.Clear()
            For Each item In TempFiles
                tooltiptemp += item.Replace(xpActiveDir, "") + ","
                TSComboBoxActivePage.Items.Add(item.Replace(xpActiveDir, ""))
            Next
            For Each item In TSComboBoxActivePage.Items
                If item = xpActiveWebPage Then
                    TSComboBoxActivePage.SelectedItem = item
                End If
            Next
            tooltiptemp = tooltiptemp.Remove(tooltiptemp.LastIndexOf(",")) + "}"
            ToolStripLabel3.ToolTipText = tooltiptemp
        End If
        If loadWebView1 Then
            fxLoadWebView1()
        End If
        If loadLBItems Then
            fxScanAddBlocks()
        End If
        If loadProperties Then
            fxLoadProperties()
        End If
        GroupBox3.Text = WebView1.Title + " - [ Title from Active Page ]"
        If ebl Then
            Enabled = True
        End If
    End Sub
    Public Sub fxLoadProperties()
        GroupBox2.Controls.Clear()
        validateL1Buttons()
        Dim index = LBAddedItems.SelectedIndex
        If index >= 0 Then
            If LBAddedItems.SelectedItem.ToString.EndsWith("Menu") Then
                GroupBox2.Controls.Add(New ucMenuProperties())
                GroupBox2.Controls.Item(0).Dock = DockStyle.Fill
            ElseIf LBAddedItems.SelectedItem.ToString.EndsWith(StrArrIntroType(0)) Then
                GroupBox2.Controls.Add(New ucIntroSimpleProperties())
                GroupBox2.Controls.Item(0).Dock = DockStyle.Fill
            ElseIf LBAddedItems.SelectedItem.ToString.EndsWith(StrArrIntroType(1)) Then
                GroupBox2.Controls.Add(New ucIntroImageProperties())
                GroupBox2.Controls.Item(0).Dock = DockStyle.Fill
            ElseIf LBAddedItems.SelectedItem.ToString.EndsWith(StrArrIntroType(2)) Then
                GroupBox2.Controls.Add(New ucIntroSimpleCover())
                GroupBox2.Controls.Item(0).Dock = DockStyle.Fill
            ElseIf LBAddedItems.SelectedItem.ToString.EndsWith(StrArrIntroType(3)) Then
                GroupBox2.Controls.Add(New ucIntroBGImageCover())
                GroupBox2.Controls.Item(0).Dock = DockStyle.Fill
            ElseIf LBAddedItems.SelectedItem.ToString.EndsWith(StrArrIntroType(4)) Then
                GroupBox2.Controls.Add(New ucIntroVideoProperties())
                GroupBox2.Controls.Item(0).Dock = DockStyle.Fill
            End If
        End If
    End Sub
    Private Sub fxScanAddBlocks()
        Try
            LBAddedItems.Items.Clear()
            If File.Exists(xpActiveWebPageFullPath) Then
                Dim kids = Integer.Parse(CType(WebView1.EvalScript("$('body').children().length;"), String))
                If kids > 0 Then
                    For i = 0 To kids - 1
                        Dim itemVal = CType(WebView1.EvalScript(String.Format("$('body').children().eq('{0}').attr('class');", i)), String)
                        Dim listItemVal = ""
                        If itemVal.Contains("app-bar") Then
                            listItemVal = String.Format("[{0}] Menu", i + 1)
                        ElseIf itemVal.Contains("intro-i1") Then
                            listItemVal = String.Format("[{0}] IntroSimple", i + 1)
                        ElseIf itemVal.Contains("intro-i2") Then
                            listItemVal = String.Format("[{0}] IntroImage", i + 1)
                        ElseIf itemVal.Contains("intro-iuc2") Then
                            listItemVal = String.Format("[{0}] IntroCoverSimple", i + 1)
                        ElseIf itemVal.Contains("intro-iuc3") Then
                            listItemVal = String.Format("[{0}] IntroBGImageCover", i + 1)
                        ElseIf itemVal.Contains("intro-i3") Then
                            listItemVal = String.Format("[{0}] IntroVideo", i + 1)
                        End If
                        LBAddedItems.Items.Add(String.Format("{0}", listItemVal, i))
                    Next
                End If
            End If
        Catch ex As Exception
            fxMBShowMsgBoxOK("Initialization Warning!", MBType.Information)
        End Try
    End Sub
    Public Sub fxLoadWebView1()
        WebView1.LoadUrlAndWait(xpActiveWebPageFullPath)
    End Sub
#End Region

#Region "IDE"
    Private Sub IDE_Load(sender As Object, e As EventArgs) Handles Me.Load
        fxRefreshIDE("LOADIDE")
    End Sub
    Private Sub IDE_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ToolStripLabel4.Text = "Inline Browser Size:" + WebControl1.Width.ToString() + " x " + WebControl1.Height.ToString()
    End Sub
    Private Sub IDE_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MessageBox.Show("Exit from IDE?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            startUpMain.fxRedirectToMainTile()
        Else
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "File"
    Private Sub NewProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProjectToolStripMenuItem.Click
        If fxMBShowMsgBoxYesNo("This will close current project.Do You want to Continue?", MBType.Question) = DialogResult.Yes Then
            startUpMain.fxRedirectFromIDEToNewProject()
        End If
    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProjectToolStripMenuItem.Click
        If fxMBShowMsgBoxYesNo("This will close current project.Do You want to Continue?", MBType.Question) = DialogResult.Yes Then
            startUpMain.fxRedirectFromIDEToOpenProject()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub
#End Region

#Region "Add Item"
    Private Sub MSSAddItemPage_Click(sender As Object, e As EventArgs) Handles MSSAddItemPage.Click
        DlgNewPage.ShowDialog(Me)
    End Sub
    Private Sub menuItems_Click(sender As Object, e As EventArgs) Handles darcula.Click, pink.Click, navy.Click, red.Click, green.Click, orange.Click
        Dim senderName = CType(sender, ToolStripMenuItem).Name
        For i = 0 To StrArrMenuTheme.Length - 1
            If senderName = StrArrMenuTheme(i) Then
                createMenu(i)
            End If
        Next
    End Sub
    Private Sub IntroSimple_Click(sender As Object, e As EventArgs) Handles IntroSimple.Click
        createIntro(0)
    End Sub
    Private Sub IntroImage_Click(sender As Object, e As EventArgs) Handles IntroImage.Click
        createIntro(1)
    End Sub
    Private Sub IntroSimpleCover_Click(sender As Object, e As EventArgs) Handles IntroSimpleCover.Click
        createIntro(2)
    End Sub
    Private Sub IntroImageCover_Click(sender As Object, e As EventArgs) Handles IntroImageCover.Click
        createIntro(3)
    End Sub
    Private Sub IntroVideo_Click(sender As Object, e As EventArgs) Handles IntroVideo.Click
        createIntro(4)
    End Sub

#End Region

#Region "Refresh"
    Private Sub MSRefresh_Click(sender As Object, e As EventArgs) Handles MSRefresh.Click
        fxRefreshIDE("Refresh Button")
    End Sub
#End Region

#Region "Preview in Browser"
    Private Sub TSViewInBrowser_Click(sender As Object, e As EventArgs) Handles MSViewInBrowser.Click
        Process.Start(xpActiveWebPageFullPath)
    End Sub
#End Region

#Region "Options"
    Private Sub TSSOptionsOnTOP_CheckedChanged(sender As Object, e As EventArgs) Handles MSSOptionsOnTOP.CheckedChanged
        If MSSOptionsOnTOP.Checked Then
            TopMost = True
        Else
            TopMost = False
        End If
    End Sub
#End Region

#Region "ToolStripTop"
    Private Sub ToolStripDropDownButton1_DropDownClosed(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.DropDownClosed
        fxWPOpenPage(TSComboBoxActivePage.Text)
    End Sub
#End Region

#Region "LBAddedItems"
    Private Sub LBAddedItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBAddedItems.SelectedIndexChanged
        fxLoadProperties()
    End Sub
    Private Sub validateL1Buttons()
        Dim index1 = LBAddedItems.SelectedIndex
        If index1 = -1 Then
            BtUpL1.Enabled = False
            BtDownL1.Enabled = False
        Else
            If index1 = 0 Then
                BtUpL1.Enabled = False
            Else
                BtUpL1.Enabled = True
            End If
            If index1 = LBAddedItems.Items.Count - 1 Then
                BtDownL1.Enabled = False
            Else
                BtDownL1.Enabled = True
            End If
        End If
    End Sub
#End Region

End Class
