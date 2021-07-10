Imports System.Drawing.Design
Imports PropertyGridEx

Public Class ucIntroSimpleProperties
    Private ArrStrWebSafeColors() As String = {"none", "black", "white", "lime", "green", "emerald", "teal", "blue", "cyan", "cobalt", "indigo", "violet", "pink", "magenta", "crimson", "red", "orange", "amber", "yellow", "brown", "olive", "steel", "mauve", "taupe", "gray", "dark", "darker", "darkBrown", "darkCrimson", "darkMagenta", "darkIndigo", "darkCyan", "darkCobalt", "darkTeal", "darkEmerald", "darkGreen", "darkOrange", "darkRed", "darkPink", "darkViolet", "darkBlue", "lightBlue", "lightRed", "lightGreen", "lighterBlue", "lightTeal", "lightOlive", "lightOrange", "lightPink", "grayDark", "grayDarker", "grayLight", "grayLighter"}

    Private Sub PXG_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PXG.PropertyValueChanged
        Dim ebl = ucIDEMain.Enabled
        ucIDEMain.Enabled = False
        If e.ChangedItem.Label = "ColorCycle" Then
            Dim bgcolor As String = "bg-none"
            If e.ChangedItem.Value = True Then
                bgcolor = "bg-" + fxGetBackgroundColor(True)
                If Not hasClassAt(".intro-i1", ucIDEMain.WebView1, getIntroItemIndexInLBBlocks(0), "ColorCycle") Then
                    ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1').eq('{0}').removeClass('{1}').addClass('colorcycle');", getIntroItemIndexInLBBlocks(0), bgcolor))
                    PXG.Item.Item(1).IsReadOnly = True
                End If
            Else
                ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1').eq('{0}').removeClass('colorcycle').addClass('{1}');", getIntroItemIndexInLBBlocks(0), "bg-" + PXG.Item.Item(1).Value))
                PXG.Item.Item(1).IsReadOnly = False
            End If
        ElseIf e.ChangedItem.Label = "BackgroundColor" Then
            Dim bgcolor1 As String = "bg-" + fxGetBackgroundColor(True)
            Dim bgcolor2 As String = "bg-" + e.ChangedItem.Value
            If hasClassAt(".intro-i1", ucIDEMain.WebView1, getIntroItemIndexInLBBlocks(0), "ColorCycle") Then
                ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1').eq('{0}').removeClass('colorcycle').addClass('{1}');", getIntroItemIndexInLBBlocks(0), bgcolor2))
            Else
                ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1').eq('{0}').removeClass('{1}').addClass('{2}');", getIntroItemIndexInLBBlocks(0), bgcolor1, bgcolor2))
            End If
        ElseIf e.ChangedItem.Label = "ForegroundColor" Then
            Dim fgcolor1 As String = "fg-" + fxGetBackgroundColor(False)
            Dim fgcolor2 As String = "fg-" + e.ChangedItem.Value
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1').eq('{0}').removeClass('{1}').addClass('{2}');", getIntroItemIndexInLBBlocks(0), fgcolor1, fgcolor2))
        ElseIf e.ChangedItem.Label = "PaddingTop" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-padding').eq('{0}').css('padding-top','{1}px');", getIntroItemIndexInLBBlocks(0), e.ChangedItem.Value))
        ElseIf e.ChangedItem.Label = "PaddingBottom" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-padding').eq('{0}').css('padding-bottom','{1}px');", getIntroItemIndexInLBBlocks(0), e.ChangedItem.Value))
        ElseIf e.ChangedItem.Label = "Title" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-title').eq('{0}').text(""{1}"");", getIntroItemIndexInLBBlocks(0), e.ChangedItem.Value))
        ElseIf e.ChangedItem.Label = "Subtitle" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-subtitle').eq('{0}').text(""{1}"");", getIntroItemIndexInLBBlocks(0), e.ChangedItem.Value))
        ElseIf e.ChangedItem.Label = "Description" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-desc').eq('{0}').text(""{1}"");", getIntroItemIndexInLBBlocks(0), e.ChangedItem.Value))
        End If
        fxFLWriteFile("Simple Intro PropertiesValueChange", ucIDEMain.xpActiveWebPageFullPath, ucIDEMain.WebView1.GetHtml(), False, True, False)
        PXG.Refresh()
        If ebl Then
            ucIDEMain.Enabled = True
        End If
    End Sub
    Private Sub BtRemoveIntroSimple_Click(sender As Object, e As EventArgs) Handles BtRemoveIntroSimple.Click
        removeIntroAfterConfirm(0)
    End Sub
    Public Function fxGetBackgroundColor(background As Boolean) As String
        Dim bgcolor As String = "none"
        If background Then
            For Each item In ArrStrWebSafeColors
                If hasClassAt(".intro-i1", ucIDEMain.WebView1, getIntroItemIndexInLBBlocks(0), "bg-" + item) Then
                    bgcolor = item
                    Exit For
                End If
            Next
        Else
            For Each item In ArrStrWebSafeColors
                If hasClassAt(".intro-i1", ucIDEMain.WebView1, getIntroItemIndexInLBBlocks(0), "fg-" + item) Then
                    bgcolor = item
                    Exit For
                End If
            Next
        End If
        Return bgcolor
    End Function

    Private Sub fxFillPXG()
        Dim ArrIntPaddingValues(255) As Integer
        For i = 0 To 255
            ArrIntPaddingValues(i) = i
        Next
        PXG.Item.Clear()
        With PXG
            Dim ColorCycle As Boolean = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1').eq('{0}').attr('class');", getIntroItemIndexInLBBlocks(0))), String).Contains("colorcycle")
            Dim bgcolor As String = fxGetBackgroundColor(True)
            Dim fgcolor As String = fxGetBackgroundColor(False)
            Dim PaddingTop As Integer = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-padding').eq('{0}').css('padding-top');", getIntroItemIndexInLBBlocks(0))), String).Replace("px", "")
            Dim PaddingBottom As Integer = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-padding').eq('{0}').css('padding-bottom');", getIntroItemIndexInLBBlocks(0))), String).Replace("px", "")
            .Item.Add("ColorCycle", ColorCycle, False, "Appearance", "If true background is with color animation.")
            If ColorCycle Then
                .Item.Add("BackgroundColor", bgcolor, True, "Appearance", "Choose background color.")
            Else
                .Item.Add("BackgroundColor", bgcolor, False, "Appearance", "Choose background color.")
            End If
            .Item(.Item.Count - 1).Choices = New CustomChoices(ArrStrWebSafeColors, False)
            .Item.Add("ForegroundColor", fgcolor, False, "Appearance", "Choose foreground color.")
            .Item(.Item.Count - 1).Choices = New CustomChoices(ArrStrWebSafeColors, False)
            .Item.Add("PaddingTop", PaddingTop, False, "Design", "Padding value from top.")
            .Item(.Item.Count - 1).Choices = New CustomChoices(ArrIntPaddingValues, False)
            .Item.Add("PaddingBottom", PaddingBottom, False, "Design", "Padding value from bottom.")
            .Item(.Item.Count - 1).Choices = New CustomChoices(ArrIntPaddingValues, False)

            Dim title As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-title').eq('{0}').text();", getIntroItemIndexInLBBlocks(0))), String)
            Dim subtitle As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-subtitle').eq('{0}').text();", getIntroItemIndexInLBBlocks(0))), String)
            Dim description As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i1-desc').eq('{0}').text();", getIntroItemIndexInLBBlocks(0))), String)
            .Item.Add("Title", title, False, "Text", "Enter Title Text for the Selected Simple Intro.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
            .Item.Add("Subtitle", subtitle, False, "Text", "Enter Subtitle Text for the Selected Simple Intro.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
            .Item.Add("Description", description, False, "Text", "Enter Description Text for the Selected Simple Intro.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)

            .Item.Add("Buttons", "(ButtonsIntroSimple)", False, "Behaviour", "Edit Buttons in the selected IntroSimple.", True)
            .Item(.Item.Count - 1).OnClick = AddressOf Me.CustomEventItem_OnClick
            .Refresh()
        End With
    End Sub

    Private Sub ucIntroSimpleProperties_Load(sender As Object, e As EventArgs) Handles Me.Load
        fxFillPXG()
    End Sub
    Private Function CustomEventItem_OnClick(sender As Object, e As EventArgs) As Object
        IDEIntroSimpleButtons.ShowDialog(ucIDEMain)
        Return "ButtonsIntroSimple"
    End Function
End Class
