Imports EO.WebBrowser

Module fxJSPureJS
#Region "Pure JS Functions"
    Private Sub checkInitialChild()
        If Integer.Parse(CType(ucIDEMain.WebView1.EvalScript("$('body').children().length;"), String)) = 0 Then
            Dim data = ucIDEMain.WebView1.GetHtml()
            If data.Contains("No Blocks Added. To Add Blocks Click on Add Button on Menu Bar.") Then
                fxMBShowMsgBoxOK("Congratulation! You have successfully added first block in the page.", MBType.Information)
                data = data.Replace("No Blocks Added. To Add Blocks Click on Add Button on Menu Bar.", "")
                fxFLWriteFile("Check Initial Child", ucIDEMain.xpActiveWebPageFullPath, data, False, True, False)
            End If
        End If
    End Sub
    Public Sub appendToBody(ByVal sender As String, ByVal supportFileName As String, ByVal childIndex As Integer, ByVal before As Boolean)
        checkInitialChild()
        Dim data = fxFLReadFileHTML(String.Format("{0}Support\{1}.html", ApplicationDirectoryPath, supportFileName))
        Dim data2 As String = ""
        For i = 0 To data.Length - 1
            data2 += data(i)
        Next
        If childIndex = -2 Then
            If Integer.Parse(CType(ucIDEMain.WebView1.EvalScript("$('body').children().length;"), String)) > 0 Then
                ucIDEMain.WebView1.EvalScript(String.Format("$prev=$('body').children().eq('{0}');$(""{1}"").insertBefore($prev);", 0, data2))
            Else
                ucIDEMain.WebView1.EvalScript(String.Format("$(""{0}"").appendTo('body');", data2))
            End If
        ElseIf childIndex = -1 Then
            ucIDEMain.WebView1.EvalScript(String.Format("$(""{0}"").appendTo('body');", data2))
        ElseIf before = False Then
            ucIDEMain.WebView1.EvalScript(String.Format("$prev=$('body').children().eq('{0}');$(""{1}"").insertAfter($prev);", childIndex, data2))
        Else
            ucIDEMain.WebView1.EvalScript(String.Format("$prev=$('body').children().eq('{0}');$(""{1}"").insertBefore($prev);", childIndex, data2))
        End If
        fxFLWriteFile(sender, ucIDEMain.xpActiveWebPageFullPath, ucIDEMain.WebView1.GetHtml())
    End Sub
    Public Function hasClassAt(ByVal selector As String, ByVal wview As WebView, ByVal index As Integer, ByVal className As String) As Boolean
        Dim resultString As Boolean = False
        Dim script As String = ""
        If index = -1 Then
            script = String.Format("$(""body"").find(""{0}"").hasClass(""{1}"");", selector, className)
        Else
            script = String.Format("$(""body"").find(""{0}"").eq({1}).hasClass(""{2}"");", selector, index, className)
        End If
        Try
            resultString = CType(wview.EvalScript(script), String)
        Catch ex As Exception
            MessageBox.Show(script + " Not Working.Working File Is Courrupted.", "Error")
        End Try
        Return resultString
    End Function
    Public Function hasClassAt(ByVal pureSelector As String, ByVal className As String) As Boolean
        Dim resultString As Boolean = False
        Dim script = String.Format("$(""{0}"").hasClass(""{1}"")", pureSelector, className)
        Try
            resultString = CType(ucIDEMain.WebView1.EvalScript(script), String)
        Catch ex As Exception
            MessageBox.Show(script + " Not Working.Working File Is Courrupted.", "Error")
        End Try
        Return resultString
    End Function
    Public Function getClassAt(ByVal selector As String, ByVal wview As WebView, ByVal index As Integer) As String
        Dim resultString As String = ""
        Dim script As String = ""
        If index = -1 Then
            script = String.Format("$(""body"").find(""{0}"").attr(""class"");", selector)
        Else
            script = String.Format("$(""body"").find(""{0}"").eq({1}).attr(""class"");", selector, index)
        End If
        Try
            resultString = CType(wview.EvalScript(script), String)
        Catch ex As Exception
            MessageBox.Show(script + " Not Working.Working File Is Courrupted.", "Error")
        End Try
        Return resultString
    End Function
    Public Sub replaceClassAt(ByVal sender As String, ByVal selector As String, ByVal wview As WebView, ByVal index As Integer, ByVal oldClass As String, ByVal newClass As String)
        Dim script As String = ""
        If index = -1 Then
            script = String.Format("$(""{0}"").removeClass(""{1}"").addClass(""{2}"");", selector, oldClass, newClass)
        Else
            script = String.Format("$(""{0}"").eq({1}).removeClass(""{2}"").addClass(""{3}"");", selector, index, oldClass, newClass)
        End If
        wview.EvalScript(script)
        fxFLWriteFile(sender, ucIDEMain.xpActiveWebPageFullPath, wview.GetHtml(), False, True, False)
    End Sub
    Public Function getInnerHTMLAt(ByVal selector As String, ByVal wview As WebView, ByVal index As Integer) As String
        Dim resultString = ""
        Dim script As String = ""
        If index = -1 Then
            script = String.Format("$(""body"").find(""{0}"").html();", selector)
        Else
            script = String.Format("$(""body"").find(""{0}"").eq({1}).html();", selector, index)
        End If
        Try
            resultString = CType(wview.EvalScript(script), String)
        Catch ex As Exception
            MessageBox.Show(script + "Script Not Working.Working File Is Courrupted.", "Error")
        End Try
        Return resultString
    End Function
    Public Sub setInnerTextAt(ByVal sender As String, ByVal selector As String, ByVal wview As WebView, ByVal innerText As String, ByVal index As Integer)
        Dim script As String = ""
        If index = -1 Then
            script = String.Format("$(""{0}"").text(""{1}"");", selector, innerText)
        Else
            script = String.Format("$(""{0}"").eq({1}).text(""{2}"");", selector, index, innerText)
        End If
        wview.EvalScript(script)
        fxFLWriteFile(sender, ucIDEMain.xpActiveWebPageFullPath, wview.GetHtml(), False, True, False)
    End Sub
#End Region
End Module
