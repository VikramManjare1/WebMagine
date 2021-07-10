Imports System.Drawing.Design
Imports PropertyGridEx

Public Class IDEIntroSimpleButtons

#Region "Members"
    Private StrArrBtTheme() As String = {"bt-default", "primary", "success", "info", "danger", "warning", "link"}
    Private StrArrBtSize() As String = {"btS-default", "mini-button", "small-button", "large-button", "big-button"}
    Private StrArrBtBorder() As String = {"btB-default", "rounded", "cycle-button", "square-button"}
    Private StrArrBtGlow() As String = {"btG-default", "block-shadow-success", "block-shadow-warning", "block-shadow-danger", "block-shadow-info"}
    Private StrArrBtAnimation() As String = {"btA-default", "loading-pulse", "loading-cube"}
#End Region

#Region "introSelectedType"
    Private ReadOnly Property IntroTypedIndex As Integer
        Get
            Dim LBBlocksText As String = ucIDEMain.LBAddedItems.SelectedItem.ToString()
            If LBBlocksText.Contains("IntroSimple") Then
                Return 0
            ElseIf LBBlocksText.Contains("IntroImage") Then
                Return 1
            ElseIf LBBlocksText.Contains("IntroCoverSimple") Then
                Return 2
            ElseIf LBBlocksText.Contains("IntroBGImageCover") Then
                Return 3
            ElseIf LBBlocksText.Contains("IntroVideo") Then
                Return 4
            End If
            Return -1
        End Get
    End Property
    Private ReadOnly Property SelectorType As String
        Get
            Dim LBBlocksText As String = ucIDEMain.LBAddedItems.SelectedItem.ToString()
            Dim value As String = ""
            If LBBlocksText.Contains("IntroSimple") Then
                value = ".intro-i1-buttons"
            ElseIf LBBlocksText.Contains("IntroImage") Then
                value = ".intro-i2-buttons"
            ElseIf LBBlocksText.Contains("IntroCoverSimple") Then
                value = ".intro-iuc2-buttons"
            ElseIf LBBlocksText.Contains("IntroBGImageCover") Then
                value = ".intro-iuc3-buttons"
            ElseIf LBBlocksText.Contains("IntroVideo") Then
                value = ".intro-i3-buttons"
            End If
            Return value
        End Get
    End Property
#End Region

#Region "Helper JS"
    Private Function getButtonCount() As Integer
        Return Integer.Parse(CType(ucIDEMain.WebView1.EvalScript(String.Format("$('{0}').eq('{1}').children('a').length;", SelectorType, selectedIndexInLBBlocks)), String))
    End Function
    Private Function selectedIndexInLBBlocks() As Integer
        Return getIntroItemIndexInLBBlocks(IntroTypedIndex)
    End Function
    Private Function getCaption(ByVal index1 As Integer) As String
        Return CType(ucIDEMain.WebView1.EvalScript(String.Format("$('{0}').eq('{1}').children('a').eq('{2}').children('button').text();", SelectorType, selectedIndexInLBBlocks, index1)), String)
    End Function
    Private Function getCaptionMulti() As String
        Dim caption As String = getCaption(LBButtonItems.SelectedIndices.Item(0))
        For Each item In LBButtonItems.SelectedIndices
            If Not getCaption(item) = caption Then
                Return ""
            End If
        Next
        Return caption
    End Function
    Private Function getHyperLink(ByVal index1 As Integer) As String
        Return CType(ucIDEMain.WebView1.EvalScript(String.Format("$('{0}').eq('{1}').children('a').eq('{2}').attr('href');", SelectorType, selectedIndexInLBBlocks, index1)), String)
    End Function
    Private Function getHyperLinkMulti() As String
        Dim HyperLink As String = getHyperLink(LBButtonItems.SelectedIndices.Item(0))
        For Each item In LBButtonItems.SelectedIndices
            If Not getHyperLink(item) = HyperLink Then
                Return ""
            End If
        Next
        Return HyperLink
    End Function
    Private Sub setCaption(ByVal index1 As Integer, ByVal value As String)
        ucIDEMain.WebView1.EvalScript(String.Format("$('{0}').eq('{1}').children('a').eq('{2}').children('button').text('{3}');", SelectorType, selectedIndexInLBBlocks, index1, value))
    End Sub
    Private Sub setHyperLink(ByVal index1 As Integer, ByVal value As String)
        ucIDEMain.WebView1.EvalScript(String.Format("$('{0}').eq('{1}').children('a').eq('{2}').attr('href','{3}');", SelectorType, selectedIndexInLBBlocks, index1, value))
    End Sub
    Private Sub writeRefreshIDE(ByVal sender As String, Optional ByVal l2 As Boolean = False)
        fxFLWriteFile(sender, ucIDEMain.xpActiveWebPageFullPath, ucIDEMain.WebView1.GetHtml(), False, True, False)
        loadListViewL1(0)
        If l2 Then
            loadListViewL2(0)
        End If
    End Sub
    Private Sub writeRefreshIDEF(ByVal sender As String, Optional ByVal l2 As Boolean = False)
        fxFLWriteFile(sender, ucIDEMain.xpActiveWebPageFullPath, ucIDEMain.WebView1.GetHtml(), False, True, False)
        loadListViewL1F(0)
        If l2 Then
            loadListViewL2(0)
        End If
    End Sub
#End Region

#Region "Manipulate Listbox"
    Private Sub loadListViewL1(round As Short)
        Dim prevIndex = LBButtonItems.SelectedIndex
        LBButtonItems.Items.Clear()
        Try
            For i = 0 To getButtonCount() - 1
                LBButtonItems.Items.Add(getCaption(i))
            Next
            If prevIndex >= 0 Then
                LBButtonItems.SelectedIndex = prevIndex
            End If
        Catch ex As Exception
            If round < 3 Then
                loadListViewL1(round + 1)
            Else
                fxMBShowMsgBoxOK("Loading Error. No buttons found.", MBType.Warning)
            End If
        End Try
        validateL1Buttons(LBButtonItems.SelectedIndex)
    End Sub
    Private Sub loadListViewL1F(round As Short)
        LBButtonItems.Items.Clear()
        Try
            For i = 0 To getButtonCount() - 1
                LBButtonItems.Items.Add(getCaption(i))
            Next
        Catch ex As Exception
            If round < 3 Then
                loadListViewL1(round + 1)
            Else
                fxMBShowMsgBoxOK("Loading Error. No buttons found.", MBType.Warning)
            End If
        End Try
        validateL1Buttons(LBButtonItems.SelectedIndex)
    End Sub
    Private Sub loadListViewL2(round As Short)
        PXG.Item.Clear()
        PXG.Refresh()
        If LBButtonItems.SelectedIndices.Count = 1 Then
            Try
                fxFillPXG()
            Catch ex As Exception
                If round < 3 Then
                    loadListViewL2(round + 1)
                Else
                    fxMBShowMsgBoxOK("Loading Error. No buttons found.", MBType.Warning)
                End If
            End Try
            validateL1Buttons(LBButtonItems.SelectedIndex)
        Else
            Try
                fxFillPXGMulti()
            Catch ex As Exception
                If round < 3 Then
                    loadListViewL2(round + 1)
                Else
                    fxMBShowMsgBoxOK("Loading Error. No buttons found.", MBType.Warning)
                End If
            End Try
            validateL1ButtonsMulti(LBButtonItems.SelectedIndices.Item(0))
        End If
    End Sub
#End Region

#Region "Validate L Buttons"
    Private Sub validateL1Buttons(ByVal index1 As Integer)
        BtAddL1.Enabled = True
        If index1 = -1 Then
            BtRemoveL1.Enabled = False
            BtUpL1.Enabled = False
            BtDownL1.Enabled = False
        Else
            BtRemoveL1.Enabled = True
            If index1 = 0 Then
                BtUpL1.Enabled = False
            Else
                BtUpL1.Enabled = True
            End If
            If index1 = LBButtonItems.Items.Count - 1 Then
                BtDownL1.Enabled = False
            Else
                BtDownL1.Enabled = True
            End If
        End If
    End Sub
    Private Sub validateL1ButtonsMulti(ByVal index1 As Integer)
        BtAddL1.Enabled = False
        BtUpL1.Enabled = False
        BtDownL1.Enabled = False
        If index1 = -1 Then
            BtRemoveL1.Enabled = False
        Else
            BtRemoveL1.Enabled = True
        End If
    End Sub
#End Region

#Region "fx"
    Private Function fxGetButtonAppearance(index1 As Integer, ByVal strarr As String()) As String
        Dim appearance As String = ""
        For Each item In strarr
            If hasClassAt(String.Format("{0}:eq({1}) a:eq({2}) button", SelectorType, selectedIndexInLBBlocks, index1), item) Then
                appearance = item
                Exit For
            End If
        Next
        Return appearance
    End Function
    Private Function fxGetButtonAppearanceMulti(ByVal strarr As String()) As String
        Dim appearance As String = fxGetButtonAppearance(LBButtonItems.SelectedIndices.Item(0), strarr)
        For Each item In LBButtonItems.SelectedIndices
            If Not fxGetButtonAppearance(item, strarr) = appearance Then
                Return ""
            End If
        Next
        Return appearance
    End Function
    Private Sub fxSetButtonAppearance(index1 As Integer, ByVal strarr As String(), value As String)
        For Each item In strarr
            If hasClassAt(String.Format("{0}:eq({1}) a:eq({2}) button", SelectorType, selectedIndexInLBBlocks, index1), item) Then
                ucIDEMain.WebView1.EvalScript(String.Format("$('{0}:eq({1}) a:eq({2}) button').removeClass('{3}');", SelectorType, selectedIndexInLBBlocks, index1, item))
                Exit For
            End If
        Next
        ucIDEMain.WebView1.EvalScript(String.Format("$('{0}:eq({1}) a:eq({2}) button').addClass('{3}');", SelectorType, selectedIndexInLBBlocks, index1, value))
    End Sub
    Private Sub fxFillPXG()
        PXG.Item.Clear()
        Dim index1 = LBButtonItems.SelectedIndex
        Dim Caption As String = getCaption(index1)
        Dim Hyperlink As String = getHyperLink(index1)
        Dim ButtonTheme As String = fxGetButtonAppearance(index1, StrArrBtTheme)
        Dim ButtonSize As String = fxGetButtonAppearance(index1, StrArrBtSize)
        Dim ButtonBorder As String = fxGetButtonAppearance(index1, StrArrBtBorder)
        Dim ButtonGlow As String = fxGetButtonAppearance(index1, StrArrBtGlow)
        Dim ButtonAnimation As String = fxGetButtonAppearance(index1, StrArrBtAnimation)

        With PXG
            .Item.Add("Caption", Caption, False, "Design", "Enter Caption for the button.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
            .Item.Add("Hyperlink", Hyperlink, False, "Design", "Enter Hyperlink for the button.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)

        End With
        fxFillSubPXG({"ButtonTheme", "ButtonSize", "ButtonBorder", "ButtonGlow", "ButtonAnimation"}, {ButtonTheme, ButtonSize, ButtonBorder, ButtonGlow, ButtonAnimation}, {StrArrBtTheme, StrArrBtSize, StrArrBtBorder, StrArrBtGlow, StrArrBtAnimation})
        PXG.Refresh()
    End Sub
    Private Sub fxFillPXGMulti()
        PXG.Item.Clear()
        Dim Caption As String = getCaptionMulti()
        Dim Hyperlink As String = getHyperLinkMulti()
        Dim ButtonTheme As String = fxGetButtonAppearanceMulti(StrArrBtTheme)
        Dim ButtonSize As String = fxGetButtonAppearanceMulti(StrArrBtSize)
        Dim ButtonBorder As String = fxGetButtonAppearanceMulti(StrArrBtBorder)
        Dim ButtonGlow As String = fxGetButtonAppearanceMulti(StrArrBtGlow)
        Dim ButtonAnimation As String = fxGetButtonAppearanceMulti(StrArrBtAnimation)

        With PXG
            .Item.Add("Caption", Caption, False, "Design", "Enter Caption for the buttons.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
            .Item.Add("Hyperlink", Hyperlink, False, "Design", "Enter Hyperlink for the buttons.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)

        End With
        fxFillSubPXG({"ButtonTheme", "ButtonSize", "ButtonBorder", "ButtonGlow", "ButtonAnimation"}, {ButtonTheme, ButtonSize, ButtonBorder, ButtonGlow, ButtonAnimation}, {StrArrBtTheme, StrArrBtSize, StrArrBtBorder, StrArrBtGlow, StrArrBtAnimation})
        PXG.Refresh()
    End Sub

    Private Sub fxFillSubPXG(propertyName() As String, propertyValue() As String, strarr()() As String)
        For i = 0 To propertyName.Length - 1
            With PXG
                .Item.Add(propertyName(i), propertyValue(i), False, "Appearance", "Choose " & propertyName(i) & ".")
                .Item(.Item.Count - 1).Choices = New CustomChoices(strarr(i), False)
            End With
        Next
    End Sub
#End Region

#Region "Components"
    Private Sub IDEIntroButtons_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadListViewL1(0)
    End Sub

    Private Sub LBButtonItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBButtonItems.SelectedIndexChanged
        loadListViewL2(0)
    End Sub
    Private Sub PXG_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PXG.PropertyValueChanged
        Dim ebl = ucIDEMain.Enabled
        ucIDEMain.Enabled = False
        Enabled = False
        'fxMBShowMsgBoxOK("Renamed Button:" & item, MBType.Information)
        Dim prev As New List(Of Integer)
        For Each item In LBButtonItems.SelectedIndices
            prev.Add(item)
            If item >= 0 Then
                If e.ChangedItem.Label = "Caption" Then
                    setCaption(item, e.ChangedItem.Value.ToString())
                ElseIf e.ChangedItem.Label = "Hyperlink" Then
                    setHyperLink(item, e.ChangedItem.Value.ToString())
                ElseIf e.ChangedItem.Label = "ButtonTheme" Then
                    fxSetButtonAppearance(item, StrArrBtTheme, e.ChangedItem.Value)
                ElseIf e.ChangedItem.Label = "ButtonSize" Then
                    fxSetButtonAppearance(item, StrArrBtSize, e.ChangedItem.Value)
                ElseIf e.ChangedItem.Label = "ButtonBorder" Then
                    fxSetButtonAppearance(item, StrArrBtBorder, e.ChangedItem.Value)
                ElseIf e.ChangedItem.Label = "ButtonGlow" Then
                    fxSetButtonAppearance(item, StrArrBtGlow, e.ChangedItem.Value)
                ElseIf e.ChangedItem.Label = "ButtonAnimation" Then
                    fxSetButtonAppearance(item, StrArrBtAnimation, e.ChangedItem.Value)
                End If
            End If
        Next
        writeRefreshIDEF("Set Button Style")
        For Each item In prev
            LBButtonItems.SelectedIndex = item
        Next
        Enabled = True
        If ebl Then
            ucIDEMain.Enabled = True
        End If
    End Sub
#End Region

#Region "Manipulate L1"
    Private Sub addButtonItemL1(count1 As Integer)
        If count1 > 0 Then
            ucIDEMain.WebView1.EvalScript(String.Format("var $prev = $('{0}').eq('{1}').children('a').eq('{2}');$(""<a href='#'><button style='margin:5px' class='button success big-button btB-default btG-default loading-pulse intro-button-i1'>Untitled [{3}]</button></a>"").insertAfter($prev);", SelectorType, selectedIndexInLBBlocks, LBButtonItems.SelectedIndex, count1 + 1))
        Else
            ucIDEMain.WebView1.EvalScript(String.Format("var $prev = $('{0}').eq('{1}');$(""<a href='#'><button style='margin:5px' class='button success big-button btB-default btG-default loading-pulse intro-button-i1'>Untitled [{2}]</button></a>"").appendTo($prev);", SelectorType, selectedIndexInLBBlocks, count1 + 1))
        End If
        writeRefreshIDE("Add Button Item")
    End Sub
    Private Sub removeButtonItemL1()
        Dim i = 0
        For Each item In LBButtonItems.SelectedIndices
            Dim index1 = item
            If index1 - i >= 0 Then
                ucIDEMain.WebView1.EvalScript(String.Format("var $prev = $('{0}').eq('{1}').children('a').eq('{2}');$prev.remove();", SelectorType, selectedIndexInLBBlocks, index1 - i))
                i += 1
            End If
        Next
        writeRefreshIDE("Remove Button Item")
    End Sub
    Private Sub moveButtonItemL1(ByVal pureSelector1 As String, ByVal pureSelector2 As String)
        ucIDEMain.WebView1.EvalScript(String.Format("var $prev = $(""{0}"");var $after = $(""{1}"");$after.insertBefore($prev);", pureSelector1, pureSelector2))
        writeRefreshIDEF("Move Button Item")
    End Sub
#End Region

#Region "L1Buttons"
    Private Sub BtAddL1_Click(sender As Object, e As EventArgs) Handles BtAddL1.Click
        Enabled = False
        addButtonItemL1(LBButtonItems.Items.Count)
        Enabled = True
    End Sub

    Private Sub BtRemoveL1_Click(sender As Object, e As EventArgs) Handles BtRemoveL1.Click
        Enabled = False
        removeButtonItemL1()
        Enabled = True
    End Sub
    Private Sub BtUpL1_Click(sender As Object, e As EventArgs) Handles BtUpL1.Click
        Enabled = False
        Dim prev As String = String.Format("{0}:eq({1}) a:eq({2})", SelectorType, selectedIndexInLBBlocks, LBButtonItems.SelectedIndex - 1)
        Dim current As String = String.Format("{0}:eq({1}) a:eq({2})", SelectorType, selectedIndexInLBBlocks, LBButtonItems.SelectedIndex)
        Dim prevIndex = LBButtonItems.SelectedIndex
        moveButtonItemL1(prev, current)
        LBButtonItems.SelectedIndex = prevIndex - 1
        Enabled = True
    End Sub

    Private Sub BtDownL1_Click(sender As Object, e As EventArgs) Handles BtDownL1.Click
        Enabled = False
        Dim prev As String = String.Format("{0}:eq({1}) a:eq({2})", SelectorType, selectedIndexInLBBlocks, LBButtonItems.SelectedIndex)
        Dim current As String = String.Format("{0}:eq({1}) a:eq({2})", SelectorType, selectedIndexInLBBlocks, LBButtonItems.SelectedIndex + 1)
        Dim prevIndex = LBButtonItems.SelectedIndex
        moveButtonItemL1(prev, current)
        LBButtonItems.SelectedIndex = prevIndex + 1
        Enabled = True
    End Sub
#End Region

End Class