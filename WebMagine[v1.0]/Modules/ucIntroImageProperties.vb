Imports System.Drawing.Design
Imports System.Drawing.Imaging
Imports System.IO
Imports EO.WebBrowser
Imports PropertyGridEx

Public Class ucIntroImageProperties
    Private ArrStrWebSafeColors() As String = {"none", "black", "white", "lime", "green", "emerald", "teal", "blue", "cyan", "cobalt", "indigo", "violet", "pink", "magenta", "crimson", "red", "orange", "amber", "yellow", "brown", "olive", "steel", "mauve", "taupe", "gray", "dark", "darker", "darkBrown", "darkCrimson", "darkMagenta", "darkIndigo", "darkCyan", "darkCobalt", "darkTeal", "darkEmerald", "darkGreen", "darkOrange", "darkRed", "darkPink", "darkViolet", "darkBlue", "lightBlue", "lightRed", "lightGreen", "lighterBlue", "lightTeal", "lightOlive", "lightOrange", "lightPink", "grayDark", "grayDarker", "grayLight", "grayLighter"}
    Private ArrStrTextAlign() As String = {"align-center", "align-left", "align-right"}
    'Private ArrStrImageFormat() As String = {"hd", "sd", "square"}
    Private ArrStrTextPosition() As String = {"BeforeImage", "AfterImage"}
    Private _imageInfo As String = ""
    Private wv1 As New WebView
    Private threadRunner As ThreadRunner

    Private Sub CreateNewWV1()
        threadRunner = New ThreadRunner()
        Dim options As New EO.WebEngine.BrowserOptions()
        options.AllowJavaScript = False
        wv1 = New WebView()
        wv1.SetOptions(options)
        wv1 = threadRunner.CreateWebView()
    End Sub
    Private Property ImageHTMLInfo As String
        Get
            Return _imageInfo
        End Get
        Set(value As String)
            _imageInfo = value
        End Set
    End Property
    Private Sub ucIntroSimpleProperties_Load(sender As Object, e As EventArgs) Handles Me.Load
        fxFillPXG()
    End Sub
    Private Sub PXG_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PXG.PropertyValueChanged
        Dim ebl = ucIDEMain.Enabled
        ucIDEMain.Enabled = False
        If e.ChangedItem.Label = "ColorCycle" Then
            Dim bgcolor As String = "bg-none"
            If e.ChangedItem.Value = True Then
                bgcolor = "bg-" + fxGetBackgroundColor(True)
                If Not hasClassAt(".intro-i2", ucIDEMain.WebView1, getIntroItemIndexInLBBlocks(1), "ColorCycle") Then
                    ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2').eq('{0}').removeClass('{1}').addClass('colorcycle');", getIntroItemIndexInLBBlocks(1), bgcolor))
                    PXG.Item.Item(1).IsReadOnly = True
                End If
            Else
                ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2').eq('{0}').removeClass('colorcycle').addClass('{1}');", getIntroItemIndexInLBBlocks(1), "bg-" + PXG.Item.Item(1).Value))
                PXG.Item.Item(1).IsReadOnly = False
            End If
        ElseIf e.ChangedItem.Label = "BackgroundColor" Then
            Dim bgcolor1 As String = "bg-" + fxGetBackgroundColor(True)
            Dim bgcolor2 As String = "bg-" + e.ChangedItem.Value
            If hasClassAt(".intro-i2", ucIDEMain.WebView1, getIntroItemIndexInLBBlocks(1), "ColorCycle") Then
                ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2').eq('{0}').removeClass('colorcycle').addClass('{1}');", getIntroItemIndexInLBBlocks(1), bgcolor2))
            Else
                ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2').eq('{0}').removeClass('{1}').addClass('{2}');", getIntroItemIndexInLBBlocks(1), bgcolor1, bgcolor2))
            End If
        ElseIf e.ChangedItem.Label = "ForegroundColor" Then
            Dim fgcolor1 As String = "fg-" + fxGetBackgroundColor(False)
            Dim fgcolor2 As String = "fg-" + e.ChangedItem.Value
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2').eq('{0}').removeClass('{1}').addClass('{2}');", getIntroItemIndexInLBBlocks(1), fgcolor1, fgcolor2))
        ElseIf e.ChangedItem.Label = "PaddingTop" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-padding').eq('{0}').css('padding-top','{1}px');", getIntroItemIndexInLBBlocks(1), e.ChangedItem.Value))
        ElseIf e.ChangedItem.Label = "PaddingBottom" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-padding').eq('{0}').css('padding-bottom','{1}px');", getIntroItemIndexInLBBlocks(1), e.ChangedItem.Value))
        ElseIf e.ChangedItem.Label = "Title" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-title').eq('{0}').text(""{1}"");", getIntroItemIndexInLBBlocks(1), e.ChangedItem.Value))
        ElseIf e.ChangedItem.Label = "Subtitle" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-subtitle').eq('{0}').text(""{1}"");", getIntroItemIndexInLBBlocks(1), e.ChangedItem.Value))
        ElseIf e.ChangedItem.Label = "Description" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-desc').eq('{0}').text(""{1}"");", getIntroItemIndexInLBBlocks(1), e.ChangedItem.Value))
        ElseIf e.ChangedItem.Label = "TextAlign" Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2:eq({0}) div:eq(0)').attr('class','{1}');", getIntroItemIndexInLBBlocks(1), e.ChangedItem.Value))
        End If
        fxFLWriteFile("Simple Intro PropertiesValueChange", ucIDEMain.xpActiveWebPageFullPath, ucIDEMain.WebView1.GetHtml(), False, True, False)
        If e.ChangedItem.Label = "Image" Then
            Dim imageFileName = String.Format("IntroI_{0}.png", Date.Now.Ticks)
            Dim imageFilePath As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-image:eq({0}) .image-container .frame div').css('background-image');", getIntroItemIndexInLBBlocks(1))), String)
            imageFilePath = imageFilePath.Substring(imageFilePath.LastIndexOf("/") + 1)
            imageFilePath = imageFilePath.Remove(imageFilePath.LastIndexOf(""""))
            If Not imageFilePath.EndsWith("back1.jpg") Then
                File.Delete(ucIDEMain.xpActiveImageDirPath + imageFilePath)
            End If
            Dim img = New Bitmap(CType(e.ChangedItem.Value, Image), New Size(512, 288))
            img.Save(ucIDEMain.xpActiveImageDirPath + imageFileName, ImageFormat.Png)
            Dim htmlString As String = String.Format("<img src='images/{0}' data-role='fitImage' data-format='hd'></img>", imageFileName)
            Dim script = String.Format("$("".intro-i2-image:eq({0})"").prepend(""{1}"")", getIntroItemIndexInLBBlocks(1), htmlString)
            Dim script2 = String.Format("$('.intro-i2-image:eq({0}) .image-container').remove();", getIntroItemIndexInLBBlocks(1))
            performImageChanged(script2, script)
        End If
        'If e.ChangedItem.Label = "ImageFormat" Then
        'Dim imageFileName = String.Format("IntroI_{0}.png", Date.Now.Ticks)
        'Dim imageFilePath As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-image:eq({0}) .image-container .frame div').css('background-image');", getIntroItemIndexInLBBlocks(1))), String)
        'imageFilePath = imageFilePath.Substring(imageFilePath.LastIndexOf("/") + 1)
        'imageFilePath = imageFilePath.Remove(imageFilePath.LastIndexOf(""""))
        'Dim htmlString As String = String.Format("<img src='images/{0}' data-role='fitImage' data-format='{1}'></img>", imageFilePath, e.ChangedItem.Value)
        'Dim script2 = String.Format("$('.intro-i2-image:eq({0}) .image-container').remove();", getIntroItemIndexInLBBlocks(1))
        'Dim script = String.Format("$("".intro-i2-image:eq({0})"").prepend(""{1}"")", getIntroItemIndexInLBBlocks(1), htmlString)
        'performImageChanged(script2, script)
        'End If
        If e.ChangedItem.Label = "TextPosition" Then
            Dim script = ""
            If e.ChangedItem.Value = ArrStrTextPosition(0) Then
                script = String.Format("$('.intro-i2-cell-text:eq({0})').insertBefore($('.intro-i2-cell-image:eq({0})'));", getIntroItemIndexInLBBlocks(1))
            ElseIf e.ChangedItem.Value = ArrStrTextPosition(1) Then
                script = String.Format("$('.intro-i2-cell-text:eq({0})').insertAfter($('.intro-i2-cell-image:eq({0})'));", getIntroItemIndexInLBBlocks(1))
            End If
            Try
                ucIDEMain.WebView1.EvalScript(script)
            Catch ex As Exception
                fxMBShowMsgBoxOK("Internal Error. Error:" + ex.ToString(), MBType.Errors)
            End Try
            fxFLWriteFile("Simple Intro PropertiesValueChange", ucIDEMain.xpActiveWebPageFullPath, ucIDEMain.WebView1.GetHtml(), False, True, False)
        End If
        PXG.Refresh()
        If ebl Then
            ucIDEMain.Enabled = True
        End If
    End Sub

    Private Sub performImageChanged(script2 As String, script As String)
        CreateNewWV1()
        File.Copy(ucIDEMain.xpActiveWebPageFullPath, ucIDEMain.xpActiveImageDirPath + ucIDEMain.xpActiveWebPage)
        wv1.LoadUrlAndWait(ucIDEMain.xpActiveImageDirPath + ucIDEMain.xpActiveWebPage)
        wv1.EvalScript(script2)
        wv1.EvalScript(script)
        fxFLWriteFile("TempWV1", ucIDEMain.xpActiveImageDirPath + ucIDEMain.xpActiveWebPage, wv1.GetHtml(), False, False, False)
        File.Copy(ucIDEMain.xpActiveImageDirPath + ucIDEMain.xpActiveWebPage, ucIDEMain.xpActiveWebPageFullPath, True)
        File.Delete(ucIDEMain.xpActiveImageDirPath + ucIDEMain.xpActiveWebPage)
        ucIDEMain.fxRefreshIDE("Intro Image Changed", False, True, True)
    End Sub
    Private Sub BtRemoveIntroImage_Click(sender As Object, e As EventArgs) Handles BtRemoveIntroImage.Click
        Dim imageFilePath As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-image:eq({0}) .image-container .frame div').css('background-image');", getIntroItemIndexInLBBlocks(1))), String)
        imageFilePath = imageFilePath.Substring(imageFilePath.LastIndexOf("/") + 1)
        imageFilePath = imageFilePath.Remove(imageFilePath.LastIndexOf(""""))
        If Not imageFilePath.EndsWith("back1.jpg") Then
            removeIntroAfterConfirm(1, ucIDEMain.xpActiveImageDirPath + imageFilePath)
        Else
            removeIntroAfterConfirm(1)
        End If
    End Sub
    Public Function fxGetBackgroundColor(background As Boolean) As String
        Dim bgcolor As String = "none"
        If background Then
            For Each item In ArrStrWebSafeColors
                If hasClassAt(".intro-i2", ucIDEMain.WebView1, getIntroItemIndexInLBBlocks(1), "bg-" + item) Then
                    bgcolor = item
                    Exit For
                End If
            Next
        Else
            For Each item In ArrStrWebSafeColors
                If hasClassAt(".intro-i2", ucIDEMain.WebView1, getIntroItemIndexInLBBlocks(1), "fg-" + item) Then
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
            Dim ColorCycle As Boolean = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2').eq('{0}').attr('class');", getIntroItemIndexInLBBlocks(1))), String).Contains("colorcycle")
            Dim bgcolor As String = fxGetBackgroundColor(True)
            Dim fgcolor As String = fxGetBackgroundColor(False)
            Dim PaddingTop As Integer = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-padding').eq('{0}').css('padding-top');", getIntroItemIndexInLBBlocks(1))), String).Replace("px", "")
            Dim PaddingBottom As Integer = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-padding').eq('{0}').css('padding-bottom');", getIntroItemIndexInLBBlocks(1))), String).Replace("px", "")
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

            Dim title As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-title').eq('{0}').text();", getIntroItemIndexInLBBlocks(1))), String)
            Dim subtitle As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-subtitle').eq('{0}').text();", getIntroItemIndexInLBBlocks(1))), String)
            Dim description As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-desc').eq('{0}').text();", getIntroItemIndexInLBBlocks(1))), String)
            .Item.Add("Title", title, False, "Text", "Enter Title Text for the Selected Image Intro.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
            .Item.Add("Subtitle", subtitle, False, "Text", "Enter Subtitle Text for the Selected Image Intro.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
            .Item.Add("Description", description, False, "Text", "Enter Description Text for the Selected Image Intro.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)

            Dim textAlign As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2:eq({0}) div:eq(0)').attr('class');", getIntroItemIndexInLBBlocks(1))), String)
            .Item.Add("TextAlign", textAlign, False, "Text", "Text Align of Title & Subtitle Text.")
            .Item(.Item.Count - 1).Choices = New CustomChoices(ArrStrTextAlign, False)

            Dim imageFilePath As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-image:eq({0}) .image-container .frame div').css('background-image');", getIntroItemIndexInLBBlocks(1))), String)
            imageFilePath = imageFilePath.Substring(imageFilePath.LastIndexOf("/") + 1)
            imageFilePath = imageFilePath.Remove(imageFilePath.LastIndexOf(""""))

            Dim tempDir = ucIDEMain.xpActiveImageDirPath + "temp\"
            Directory.CreateDirectory(tempDir)

            File.Copy(ucIDEMain.xpActiveImageDirPath + imageFilePath, tempDir + imageFilePath)
            Dim fs As FileStream = New FileStream(tempDir + imageFilePath, FileMode.Open)
            Dim scaledimage As Image = Image.FromStream(fs)
            scaledimage = scaledimage.Clone()
            .Item.Add("Image", scaledimage, False, "Image", "Choose Image For the Image Intro. [Recommended Size ratio is 16:9]")
            fs.Close()
            File.Delete(tempDir + imageFilePath)

            'Dim imageFormat As String = CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.intro-i2-image:eq({0}) .image-container').attr('class');", getIntroItemIndexInLBBlocks(1))), String)
            'For Each item In ArrStrImageFormat
            'If imageFormat.Contains("image-format-" + item) Then
            '.Item.Add("ImageFormat", item, False, "Image", "Image Format [16x9 or 4x3 or square]")
            'Exit For
            'End If
            'Next
            '.Item(.Item.Count - 1).Choices = New CustomChoices(ArrStrImageFormat, False)

            Dim positionText As String = ""
            If hasClassAt(String.Format(".intro-i2-cell:eq({0}) div:eq(0)", getIntroItemIndexInLBBlocks(1)), "intro-i2-cell-text") Then
                positionText = ArrStrTextPosition(0)
            ElseIf hasClassAt(String.Format(".intro-i2-cell:eq({0}) div:eq(0)", getIntroItemIndexInLBBlocks(1)), "intro-i2-cell-image") Then
                positionText = ArrStrTextPosition(1)
            End If
            .Item.Add("TextPosition", positionText, False, "Text Layout", "Text Position with respect to Image.")
            .Item(.Item.Count - 1).Choices = New CustomChoices(ArrStrTextPosition, False)

            .Item.Add("Buttons", "(ButtonsIntroImage)", False, "Behaviour", "Edit Buttons In the selected IntroImage.", True)
            .Item(.Item.Count - 1).OnClick = AddressOf Me.CustomEventItem_OnClick
            .Refresh()
        End With
    End Sub
    Private Function CustomEventItem_OnClick(sender As Object, e As EventArgs) As Object
        IDEIntroSimpleButtons.ShowDialog(ucIDEMain)
        Return "ButtonsIntroImage"
    End Function
End Class
