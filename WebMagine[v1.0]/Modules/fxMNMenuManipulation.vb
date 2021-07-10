Imports EO.WebBrowser

Module fxMNMenuManipulation
    Public StrArrMenuTheme() As String = {"darcula", "pink", "navy", "red", "green", "orange"}
    Public Sub createMenu(ByVal themeIndex As Short)
        ucIDEMain.Enabled = False
        If Integer.Parse(CType(ucIDEMain.WebView1.EvalScript("$('header').length;"), String)) = 0 Then
            appendToBody("Create Menu", "header", -2, True)
            changeMenuTheme(themeIndex)
        Else
            MessageBox.Show("Don't you think that one menu block is sufficient for one page!")
        End If
        ucIDEMain.Enabled = True
    End Sub
    Public Sub removeMenu(ByVal wv2 As WebView)
        wv2.EvalScript(vbCr & vbLf & "var $prev = $('header');$prev.remove();")
        fxFLWriteFile("Remove Menu", ucIDEMain.xpActiveWebPageFullPath, wv2.GetHtml(), True, True, True)
        If IDEMenu.Visible Then
            IDEMenu.Close()
        End If
    End Sub
    Public Sub changeMenuTheme(ByVal newThemeIndex As Short)
        Dim ebl = ucIDEMain.Enabled
        ucIDEMain.Enabled = False
        If Integer.Parse(CType(ucIDEMain.WebView1.EvalScript("$('header').length;"), String)) = 1 Then
            For i = 0 To StrArrMenuTheme.Length - 1
                If hasClassAt("header", ucIDEMain.WebView1, -1, StrArrMenuTheme(i)) Then
                    replaceClassAt("Change Menu Theme", "header", ucIDEMain.WebView1, -1, StrArrMenuTheme(i), StrArrMenuTheme(newThemeIndex))
                    Exit For
                End If
            Next
        End If
        If ebl Then
            ucIDEMain.Enabled = True
        End If
    End Sub
    Public Sub changeMenuTheme(ByVal newThemeName As String)
        Dim ebl = ucIDEMain.Enabled
        ucIDEMain.Enabled = False
        If Integer.Parse(CType(ucIDEMain.WebView1.EvalScript("$('header').length;"), String)) = 1 Then
            For i = 0 To StrArrMenuTheme.Length - 1
                If hasClassAt("header", ucIDEMain.WebView1, -1, StrArrMenuTheme(i)) Then
                    replaceClassAt("Change Menu Theme", "header", ucIDEMain.WebView1, -1, StrArrMenuTheme(i), newThemeName)
                    Exit For
                End If
            Next
        End If
        If ebl Then
            ucIDEMain.Enabled = True
        End If
    End Sub
    Public Function countMenu(ByVal level As Short) As Short
        If level = 1 Then
            Return Short.Parse(CType(ucIDEMain.WebView1.EvalScript("$('.app-bar-menu').children('.tl1m').length;"), String))
        ElseIf level = 2 Then
            Return Short.Parse(CType(ucIDEMain.WebView1.EvalScript("$('.app-bar-menu').children('.tl1m').length;"), String))
        End If
        Return -1
    End Function
    Public Function removeMenuAfterConfirm() As Boolean
        If MessageBox.Show("This will remove the menu block from the page.Are you sure you want to remove menu block from the page?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ucIDEMain.Enabled = False
            removeMenu(ucIDEMain.WebView1)
            ucIDEMain.Enabled = True
            Return True
        End If
        Return False
    End Function
End Module
