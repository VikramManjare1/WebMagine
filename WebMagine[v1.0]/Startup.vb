Imports System.IO

Public Class Startup

#Region "Constructor"
    Public Sub New()
        InitializeComponent()
        startUpMain = Me
    End Sub
    Public Sub New(ByVal filePath As String)
        InitializeComponent()
        startUpMain = Me
        DlgOpenProjectFile.FileName = filePath
    End Sub
#End Region

#Region "Components"
    Private Sub BtCreate_Click(sender As Object, e As EventArgs) Handles BtCreate.Click
        DlgNewProject.ShowDialog(Me)
    End Sub
#End Region

#Region "fx"
    Public Sub fxRedirectToIDE()
        Hide()
        ucIDEMain.Show()
        ucIDEMain.Activate()
    End Sub
    Public Sub fxRedirectToMainTile()
        ucIDEMain.Dispose()
        Show()
        Focus()
        Activate()
    End Sub
    Public Sub fxRedirectFromIDEToNewProject()
        fxRedirectToMainTile()
        BtCreate.PerformClick()
    End Sub
    Public Sub fxRedirectFromIDEToOpenProject()
        fxRedirectToMainTile()
        BtOpen.PerformClick()
    End Sub
    Private Sub BtOpen_Click(sender As Object, e As EventArgs) Handles BtOpen.Click
        If DlgOpenProjectFile.ShowDialog() = DialogResult.OK Then
            fxRedirectIndepedent()
        End If
    End Sub
    Private Sub fxRedirectIndepedent()
        Dim ActiveXMLFile = DlgOpenProjectFile.FileName
        If File.Exists(ActiveXMLFile) Then
            ucIDEMain = New IDE(ActiveXMLFile)
            startUpMain.fxRedirectToIDE()
        End If
    End Sub

    Private Sub Startup_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If DlgOpenProjectFile.FileName.Length > 0 Then
            fxRedirectIndepedent()
            DlgOpenProjectFile.FileName = ""
        End If
    End Sub
#End Region

End Class