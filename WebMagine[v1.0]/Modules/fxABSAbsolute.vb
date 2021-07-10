Imports System.IO
Imports System.Text
Imports System.Xml

Module fxABSAbsolute
    Private _ucIDEMain As IDE
    Private _startUpMain As Startup
    Public ReadOnly Property ApplicationDirectoryPath As String
        Get
            Return New FileInfo(Application.ExecutablePath).DirectoryName + "\"
        End Get
    End Property
    Public Property ucIDEMain As IDE
        Get
            Return _ucIDEMain
        End Get
        Set(value As IDE)
            _ucIDEMain = value
        End Set
    End Property
    Public Property startUpMain As Startup
        Get
            Return _startUpMain
        End Get
        Set(value As Startup)
            _startUpMain = value
        End Set
    End Property
    Public Function fxFLReadFile(ByVal filePath As String) As String
        Return File.ReadAllText(filePath, Encoding.Unicode)
    End Function
    Public Function fxFLReadFileHTML(ByVal filePath As String) As String()
        Return File.ReadAllLines(filePath, Encoding.UTF8)
    End Function
    Public Sub fxFLWriteFile(ByVal sender As String, ByVal filepath As String, ByVal data As String)
        fxFLWriteFile(sender, filepath, data, True, True, True)
    End Sub
    Public Sub fxFLWriteFile(ByVal sender As String, ByVal filepath As String, ByVal data As String, loadLBItems As Boolean, loadWebView1 As Boolean, loadProperties As Boolean, Optional count As Integer = 0)
        Dim ebl = ucIDEMain.Enabled
        ucIDEMain.Enabled = False
        Try
            data = data.Replace("<div></div>", "")
            data = data.Replace("<div class=""app-bar-pullbutton automatic"" style=""display: none;""></div><div class=""clearfix"" style=""width: 0;""></div><nav class=""app-bar-pullmenu hidden flexstyle-app-bar-menu"" style=""display: none;""><ul class=""app-bar-pullmenubar hidden app-bar-menu""></ul></nav>", "")
            Dim fs = File.Create(filepath, 1024)
            Dim info = New UTF8Encoding(True).GetBytes(data)
            fs.Write(info, 0, info.Length)
            fs.Close()
            ucIDEMain.fxRefreshIDE(sender, loadLBItems, loadWebView1, loadProperties)
        Catch ex As Exception
            If count < 3 Then
                fxFLWriteFile(sender, filepath, data, loadLBItems, loadWebView1, loadProperties, count + 1)
            Else
                fxMBShowMsgBoxOK("File I/O Exception!", MBType.Errors)
            End If
        End Try
        If ebl Then
            ucIDEMain.Enabled = True
        End If
    End Sub
    Public Sub fxABSCopyDirectory(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not Directory.Exists(destinationPath) Then
            Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
           Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is FileInfo Then
                File.Copy(fileSystemInfo.FullName, destinationFileName, True)
            Else
                ' Recursively call the mothod to copy all the nested folders
                fxABSCopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub
    Public Sub fxCopyFavicon(ByVal folder As String, overWrite As Boolean)
        File.Copy(ApplicationDirectoryPath + "Support\Favicon.ico", folder + "Favicon.ico", overWrite)
    End Sub
    Public Function fxABSReadXMLFile(xmlFilePath As String) As String
        Dim doc = New XmlDocument()
        doc.Load(xmlFilePath)
        Return doc.GetElementsByTagName("ActivePage")(0).InnerXml
    End Function
    Public Sub fxABSChangeXMLFile(xmlFilePath As String, value As String)
        Dim doc = New XmlDocument()
        doc.Load(xmlFilePath)
        doc.GetElementsByTagName("ActivePage")(0).InnerXml = value
        doc.Save(xmlFilePath)
    End Sub
End Module
