Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Public Class DlgNewProject
#Region "Members"
    Private BACKSPACE As Boolean
    Private SPACEKEY As Boolean
    Private _xDefaultFolderPath As String = ""
    Private Property DefaultFolderPath As String
        Get
            Return _xDefaultFolderPath
        End Get
        Set(value As String)
            If value.EndsWith("\") Then
                _xDefaultFolderPath = value
            Else
                _xDefaultFolderPath = value + "\"
            End If
            If TextBoxDefault.TextLength > 0 Then
                LblxPath.Text = _xDefaultFolderPath + TextBoxDefault.Text + "\" + TextBoxDefault.Text + ".vws"
            Else
                LblxPath.Text = _xDefaultFolderPath
            End If
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DefaultFolderPath = "C:\WebMagine Simple\WebsiteBuild\"
    End Sub
#End Region

#Region "Components"
    Private Sub TextBoxDefault_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxDefault.KeyDown
        If e.KeyCode = Keys.Back Then
            BACKSPACE = True
        Else
            BACKSPACE = False
        End If
        If e.KeyCode = Keys.Space Then
            SPACEKEY = True
        Else
            SPACEKEY = False
        End If
        If e.KeyData = Keys.Enter Then
            OK_Button.PerformClick()
        End If
    End Sub
    Private Sub TextBoxDefault_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDefault.KeyPress
        If SPACEKEY Then
            e.Handled = True
        End If
        If BACKSPACE = False And SPACEKEY = False Then
            If TextBoxDefault.TextLength = 0 Then
                Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                If Char.IsLetter(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False And allowedChars.IndexOf(e.KeyChar) = -1 Then
                    e.Handled = True
                End If
            Else
                Dim allowedChars As String = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                If Char.IsControl(e.KeyChar) = False And allowedChars.IndexOf(e.KeyChar) = -1 Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        fxPerformNewProjectTask()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBoxDefault_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxDefault.KeyUp
        DefaultFolderPath = DefaultFolderPath
    End Sub

    Private Sub LinkLblChangeFolder_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLblChangeFolder.LinkClicked
        If DlgFolderSelect.ShowDialog() = DialogResult.OK Then
            If DlgFolderSelect.SelectedPath.Length < 100 Then
                DefaultFolderPath = DlgFolderSelect.SelectedPath
            Else
                fxMBShowMsgBoxOK("Selected Path Length is Much Long.", MBType.Errors)
            End If
        End If
    End Sub
#End Region

#Region "fx"
    Private Sub fxPerformNewProjectTask()
        If TextBoxDefault.Text.Length > 0 Then
            Dim subFolder = TextBoxDefault.Text + "\"
            If Directory.Exists(DefaultFolderPath + subFolder) Then
                fxMBShowMsgBoxOK("Folder already contains Subfolder with Project Name.Choose Another Project Name Or Select Another Folder.", MBType.Errors)
                Exit Sub
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
            If Not Directory.Exists(DefaultFolderPath) Then
                Directory.CreateDirectory(DefaultFolderPath)
            End If
            Directory.CreateDirectory(DefaultFolderPath + subFolder)
            Dim ActiveXMLFile = DefaultFolderPath + subFolder + TextBoxDefault.Text + ".vws"
            Dim xws As XmlWriterSettings = New XmlWriterSettings()
            xws.Indent = True
            xws.NewLineOnAttributes = True
            Dim xw As XmlWriter = XmlWriter.Create(ActiveXMLFile, xws)
            xw.WriteStartDocument()
            xw.WriteStartElement("Configuration")
            xw.WriteElementString("ActivePage", ".html")
            xw.WriteEndElement()
            xw.WriteEndDocument()
            xw.Flush()
            xw.Close()
            ucIDEMain = New IDE(ActiveXMLFile)
            fxCopyFavicon(DefaultFolderPath + subFolder, True)
            fxABSCopyDirectory(ApplicationDirectoryPath + "Support\1", ucIDEMain.xpActiveDir)
            startUpMain.fxRedirectToIDE()
            fxWPCreateNewPage("index.html")
            TextBoxDefault.Text = ""
        End If
    End Sub
#End Region

End Class
