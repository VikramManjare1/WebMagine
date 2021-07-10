Imports System.IO

Module fxWPWebPage
    Public Sub fxWPCreateNewPage(webPage As String)
        Try
            If File.Exists(ucIDEMain.xpActiveDir + webPage) Then
                fxMBShowMsgBoxOK("File Already Exists! Choose Another Name for the Web Page.", MBType.Errors)
            Else
                ucIDEMain.xpActiveWebPage = webPage
                fxFLWriteFile("fxWPCreateNewPage", ucIDEMain.xpActiveWebPageFullPath, fxFLReadFile(ApplicationDirectoryPath + "Support\abstract.html"))
                fxABSChangeXMLFile(ucIDEMain.xpActiveProjectFullPath, webPage)
            End If
        Catch ex As Exception
            fxMBShowMsgBoxOK("Page Creation Failed. Error:" & ex.ToString(), MBType.Errors)
        End Try
    End Sub
    Public Sub fxWPOpenPage(webPage As String)
        Try
            If File.Exists(ucIDEMain.xpActiveDir + webPage) Then
                ucIDEMain.xpActiveWebPage = webPage
                fxABSChangeXMLFile(ucIDEMain.xpActiveProjectFullPath, webPage)
                ucIDEMain.fxRefreshIDE("Open Page")
            Else
                fxMBShowMsgBoxOK("Page Couden't be Opened.", MBType.Errors)
            End If
        Catch ex As Exception
            fxMBShowMsgBoxOK("Page Open Failed. Error:" & ex.ToString(), MBType.Errors)
        End Try
    End Sub
End Module
