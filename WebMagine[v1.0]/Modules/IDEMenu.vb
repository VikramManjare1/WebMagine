Imports System.Drawing.Design

Public Class IDEMenu

#Region "Members"
    Enum menuMovementDir
        Up
        Down
    End Enum
#End Region

#Region "JS Functions"
    Private Function getCaption(ByVal indexL1 As Integer, Optional ByVal indexL2 As Integer = -1) As String
        If indexL2 = -1 Then
            Return CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('.level1M').text();", indexL1)), String)
        Else
            Return CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('ul').children('li').eq({1}).children('.level2M').text();", indexL1, indexL2)), String)
        End If
    End Function
    Private Function getHyperLink(ByVal indexL1 As Integer, Optional ByVal indexL2 As Integer = -1) As String
        If indexL2 = -1 Then
            Return CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('.level1M').attr('href')", indexL1)), String)
        Else
            Return CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('ul').children('li').eq({1}).children('.level2M').attr('href');", indexL1, indexL2)), String)
        End If
    End Function
    Private Sub setCaption(ByVal indexL1 As Integer, ByVal value As String, Optional ByVal indexL2 As Integer = -1)
        If indexL2 = -1 Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('.level1M').text('{1}');", indexL1, value))
        Else
            ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('ul').children('li').eq({1}).children('.level2M').text('{2}');", indexL1, indexL2, value))
        End If
        writeRefreshIDE("Set Menu Caption")
    End Sub
    Private Sub setHyperLink(ByVal indexL1 As Integer, ByVal value As String, Optional ByVal indexL2 As Integer = -1)
        If indexL2 = -1 Then
            ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('.level1M').attr('href','{1}');", indexL1, value))
        Else
            ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('ul').children('li').eq({1}).children('.level2M').attr('href','{2}');", indexL1, indexL2, value))
        End If
        writeRefreshIDE("Set Menu Hyperlink")
    End Sub
    Private Sub writeRefreshIDE(ByVal sender As String, Optional ByVal l2 As Boolean = False)
        fxFLWriteFile(sender, ucIDEMain.xpActiveWebPageFullPath, ucIDEMain.WebView1.GetHtml(), False, True, False)
        loadListViewL1()
        If l2 Then
            loadListViewL2(ListBoxL1.SelectedIndex)
        End If
    End Sub
#End Region

#Region "Manipulate Listbox"
    Private Sub loadListViewL1(Optional round As Short = 0)
        Dim prevIndex = ListBoxL1.SelectedIndex
        ListBoxL1.Items.Clear()
        Try
            For i = 0 To Integer.Parse(CType(ucIDEMain.WebView1.EvalScript("$('.app-bar-menu').children('.tl1m').length;"), String)) - 1
                ListBoxL1.Items.Add(getCaption(i))
            Next
            If prevIndex >= 0 Then
                ListBoxL1.SelectedIndex = prevIndex
            End If
        Catch ex As Exception
            If round < 3 Then
                loadListViewL1(round + 1)
            Else
                MessageBox.Show("Loading Error")
            End If
        End Try
        validateL1Buttons(ListBoxL1.SelectedIndex)
        validateL2Buttons(ListBoxL2.SelectedIndex)
    End Sub
    Private Sub loadListViewL2(ByVal selectedIndex As Integer, Optional round As Short = 0)
        PXG1.Item.Clear()
        PXG2.Item.Clear()
        PXG1.Refresh()
        PXG2.Refresh()
        Try
            Dim prevIndex = ListBoxL2.SelectedIndex
            ListBoxL2.Items.Clear()
            With PXG1
                Dim Caption As String = getCaption(selectedIndex)
                Dim Hyperlink As String = getHyperLink(selectedIndex)
                .Item.Add("Caption", Caption, False, "Design", "Enter Caption for the Selected L1 Item.")
                .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
                .Item.Add("Hyperlink", Hyperlink, False, "Design", "Enter Hyperlink for the Selected L1 Item. Note: Choose Hyperlink Carefully.")
                .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
                .Refresh()
            End With
            Dim count = Integer.Parse(CType(ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('ul').children('li').length;", selectedIndex)), String))
            If count <> 0 Then
                For i = 0 To count - 1
                    ListBoxL2.Items.Add(getCaption(selectedIndex, i))
                Next
            Else
            End If
            If prevIndex >= 0 Then
                ListBoxL2.SelectedIndex = prevIndex
            End If
            validateL1Buttons(selectedIndex)
            validateL2Buttons(ListBoxL2.SelectedIndex)
        Catch ex As Exception
            If round < 3 Then
                loadListViewL2(selectedIndex, round + 1)
            Else
                MessageBox.Show("Loading Error")
            End If
        End Try
    End Sub
    Private Sub loadListViewL3(ByVal selectedIndex1 As Integer, ByVal selectedIndex2 As Integer)
        PXG2.Item.Clear()
        With PXG2
            Dim Caption2 As String = getCaption(selectedIndex1, selectedIndex2)
            Dim Hyperlink2 As String = getHyperLink(selectedIndex1, selectedIndex2)
            .Item.Add("Caption", Caption2, False, "Design", "Enter Caption for the Selected L2 Item.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
            .Item.Add("Hyperlink", Hyperlink2, False, "Design", "Enter Hyperlink for the Selected L2 Item. Note: Choose Hyperlink Carefully.")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)
            .Refresh()
        End With
        validateL1Buttons(selectedIndex1)
        validateL2Buttons(selectedIndex2)
    End Sub
#End Region

#Region "Manipulate L1"
    Private Sub addMenuItemL1(ByVal count1 As Integer)
        If count1 < 6 Then
            ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $prev = $('.tl1m').eq({2});$(""<li class='tl1m'><a href='#' class='level1M'>Untitled [{3}]</a></li>"").insertAfter($prev);", vbCr, vbLf, ListBoxL1.SelectedIndex, count1 + 1))
            writeRefreshIDE("Add Menu Item")
        Else
            fxMBShowMsgBoxOK("Only 6 Level 1 Menu Items are Allowed!", MBType.Warning)
        End If
    End Sub
    Private Sub removeMenuItemL1(ByVal count1 As Integer, ByVal index1 As Integer)
        If count1 > 1 Then
            If index1 >= 0 Then
                ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $prev = $('.tl1m').eq({2});$prev.remove();", vbCr, vbLf, index1))
                writeRefreshIDE("Remove Menu Item", True)
            End If
        Else
            If removeMenuAfterConfirm() Then
                Me.Close()
            End If
        End If
    End Sub
    Private Sub moveMenuItemL1(ByVal index As Integer, ByVal selector As String, ByVal direction As menuMovementDir, Optional ByVal moveToExtreme As Boolean = False)
        If index >= 0 Then
            If direction = menuMovementDir.Up Then
                If Not moveToExtreme Then
                    ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $prev = $('{2}').eq({3});var $after = $('{2}').eq({4}); $after.insertBefore($prev);", vbCr, vbLf, selector, index - 1, index))
                Else
                    ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $prev = $('{2}').eq({3});var $after = $('{2}').eq({4}); $after.insertBefore($prev);", vbCr, vbLf, selector, 0, index))
                End If
            ElseIf direction = menuMovementDir.Down Then
                If Not moveToExtreme Then
                    ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $next = $('{2}').eq({3});var $current = $('{2}').eq({4}); $next.insertBefore($current);", vbCr, vbLf, selector, index + 1, index))
                Else
                    ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $next = $('{2}').eq({3});var $current = $('{2}').eq({4}); $next.insertAfter($current);", vbCr, vbLf, selector, index, ListBoxL1.Items.Count - 1))
                End If
            End If
            writeRefreshIDE("Move Menu Item")
        End If
    End Sub
#End Region

#Region "Manipulate L2"
    Private Sub addMenuItemL2(ByVal index1 As Integer, ByVal count2 As Integer)
        If count2 < 8 Then
            Dim index2 = ListBoxL2.SelectedIndex
            If count2 = 0 Then
                ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('.level1M').addClass('dropdown-toggle')", index1))
                ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('.level1M').attr('href','#')", index1))
                ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $prev = $('.tl1m').eq({2}).children('.level1M');$(""<ul class='d-menu' data-role='dropdown' data-no-close='True'><li><a href='#' class='level2M'>Untitled [{3}]</a></li></ul>"").insertAfter($prev);", vbCr, vbLf, index1, count2 + 1))
            ElseIf index2 >= 0 Then
                ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $prev = $('.tl1m').eq({2}).children('ul').children('li').eq({3});$(""<li><a href='#' class='level2M'>Untitled [{4}]</a></li>"").insertAfter($prev);", vbCr, vbLf, index1, index2, count2 + 1))
            Else
                ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $prev = $('.tl1m').eq({2}).children('ul').children('li').eq({3});$(""<li><a href='#' class='level2M'>Untitled [{4}]</a></li>"").insertAfter($prev);", vbCr, vbLf, index1, count2 - 1, count2 + 1))
            End If
            writeRefreshIDE("Add Menu Item L2", True)
        Else
            fxMBShowMsgBoxOK("Only 8 Level 2 Menu Items are Allowed!", MBType.Warning)
        End If
    End Sub
    Private Sub removeMenuItemL2(ByVal index1 As Integer, ByVal count2 As Integer, ByVal index2 As Integer)
        If count2 > 0 Then
            If index2 >= 0 Then
                If count2 = 1 Then
                    ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('.level1M').removeClass('dropdown-toggle')", index1))
                    ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('ul').remove()", index1))
                Else
                    ucIDEMain.WebView1.EvalScript(String.Format("$('.app-bar-menu').children('.tl1m').eq({0}).children('ul').children('li').eq({1}).remove()", index1, index2))
                End If
            End If
            writeRefreshIDE("Remove Menu Item L2", True)
        End If
    End Sub
    Private Sub moveMenuItemL2(ByVal index1 As Integer, ByVal index2 As Integer, ByVal direction As menuMovementDir, Optional ByVal moveToExtreme As Boolean = False)
        If index1 >= 0 And index2 >= 0 Then
            If direction = menuMovementDir.Up Then
                If Not moveToExtreme Then
                    ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $last = $('.tl1m').eq({2}).children('ul').children('li').eq({3});var $selection = $('.tl1m').eq({2}).children('ul').children('li').eq({4}); $selection.insertAfter($last);", vbCr, vbLf, index1, index2 - 2, index2))
                Else
                    ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $last = $('.tl1m').eq({2}).children('ul').children('li').eq({3});var $selection = $('.tl1m').eq({2}).children('ul').children('li').eq({4}); $selection.insertBefore($last);", vbCr, vbLf, index1, 0, index2))
                End If
            ElseIf direction = menuMovementDir.Down Then
                If Not moveToExtreme Then
                    ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $last = $('.tl1m').eq({2}).children('ul').children('li').eq({3});var $selection = $('.tl1m').eq({2}).children('ul').children('li').eq({4}); $selection.insertAfter($last);", vbCr, vbLf, index1, index2 + 1, index2))
                Else
                    ucIDEMain.WebView1.EvalScript(String.Format("{0}{1}var $last = $('.tl1m').eq({2}).children('ul').children('li').eq({3});var $selection = $('.tl1m').eq({2}).children('ul').children('li').eq({4}); $selection.insertAfter($last);", vbCr, vbLf, index1, ListBoxL2.Items.Count - 1, index2))
                End If
            End If
            writeRefreshIDE("Move Menu Item L2", True)
        End If
    End Sub
#End Region

#Region "Validate L Buttons"
    Private Sub validateL1Buttons(ByVal index1 As Integer)
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
            If index1 = ListBoxL1.Items.Count - 1 Then
                BtDownL1.Enabled = False
            Else
                BtDownL1.Enabled = True
            End If
        End If
    End Sub
    Private Sub validateL2Buttons(ByVal index2 As Integer)
        If ListBoxL2.Items.Count = 0 Or index2 = -1 Then
            BtRemoveL2.Enabled = False
            BtUpL2.Enabled = False
            BtDownL2.Enabled = False
        Else
            BtRemoveL2.Enabled = True
            If index2 = 0 Then
                BtUpL2.Enabled = False
            Else
                BtUpL2.Enabled = True
            End If
            If index2 = ListBoxL2.Items.Count - 1 Then
                BtDownL2.Enabled = False
            Else
                BtDownL2.Enabled = True
            End If
        End If
        If ListBoxL1.SelectedIndex = -1 Then
            BtAddL2.Enabled = False
            ListBoxL2.Items.Clear()
        Else
            BtAddL2.Enabled = True
        End If
    End Sub
#End Region

#Region "IDE"
    Private Sub IDEMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadListViewL1()
    End Sub
#End Region

#Region "ListBoxL1"
    Private Sub ListBoxL1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxL1.SelectedIndexChanged
        loadListViewL2(ListBoxL1.SelectedIndex)
    End Sub

    Private Sub ListBoxL2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxL2.SelectedIndexChanged
        loadListViewL3(ListBoxL1.SelectedIndex, ListBoxL2.SelectedIndex)
    End Sub
#End Region

#Region "Property Grids"
    Private Sub PXG1_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PXG1.PropertyValueChanged
        Enabled = False
        Dim i = ListBoxL1.SelectedIndex
        If i >= 0 Then
            If e.ChangedItem.Label = "Caption" Then
                setCaption(ListBoxL1.SelectedIndex, e.ChangedItem.Value.ToString())
            ElseIf e.ChangedItem.Label = "Hyperlink" Then
                setHyperLink(ListBoxL1.SelectedIndex, e.ChangedItem.Value.ToString())
            End If
            loadListViewL1()
        End If
        Enabled = True
    End Sub
    Private Sub PXG2_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PXG2.PropertyValueChanged
        Enabled = False
        Dim i = ListBoxL1.SelectedIndex
        Dim j = ListBoxL2.SelectedIndex
        If i >= 0 And j >= 0 Then
            If e.ChangedItem.Label = "Caption" Then
                setCaption(ListBoxL1.SelectedIndex, e.ChangedItem.Value.ToString(), ListBoxL2.SelectedIndex)
            ElseIf e.ChangedItem.Label = "Hyperlink" Then
                setHyperLink(ListBoxL1.SelectedIndex, e.ChangedItem.Value.ToString(), ListBoxL2.SelectedIndex)
            End If
            loadListViewL2(ListBoxL1.SelectedIndex)
        End If
        Enabled = True
    End Sub
#End Region

#Region "L1Buttons"
    Private Sub BtAddL1_Click(sender As Object, e As EventArgs) Handles BtAddL1.Click
        Enabled = False
        addMenuItemL1(ListBoxL1.Items.Count)
        Enabled = True
    End Sub

    Private Sub BtRemoveL1_Click(sender As Object, e As EventArgs) Handles BtRemoveL1.Click
        Enabled = False
        removeMenuItemL1(ListBoxL1.Items.Count, ListBoxL1.SelectedIndex)
        Enabled = True
    End Sub

    Private Sub BtTopL1_Click(sender As Object, e As EventArgs) Handles BtUpL1.DoubleClick
        Enabled = False
        moveMenuItemL1(ListBoxL1.SelectedIndex, ".tl1m", menuMovementDir.Up, True)
        ListBoxL1.SelectedIndex = 0
        Enabled = True
    End Sub

    Private Sub BtUpL1_Click(sender As Object, e As EventArgs) Handles BtUpL1.Click
        Enabled = False
        moveMenuItemL1(ListBoxL1.SelectedIndex, ".tl1m", menuMovementDir.Up)
        ListBoxL1.SelectedIndex = ListBoxL1.SelectedIndex - 1
        Enabled = True
    End Sub

    Private Sub BtDownL1_Click(sender As Object, e As EventArgs) Handles BtDownL1.Click
        Enabled = False
        moveMenuItemL1(ListBoxL1.SelectedIndex, ".tl1m", menuMovementDir.Down)
        ListBoxL1.SelectedIndex = ListBoxL1.SelectedIndex + 1
        Enabled = True
    End Sub

    Private Sub BtBottomL1_Click(sender As Object, e As EventArgs) Handles BtDownL1.DoubleClick
        Enabled = False
        moveMenuItemL1(ListBoxL1.SelectedIndex, ".tl1m", menuMovementDir.Down, True)
        ListBoxL1.SelectedIndex = ListBoxL1.Items.Count - 1
        Enabled = True
    End Sub
#End Region

#Region "L2 Buttons"
    Private Sub BtAddL2_Click(sender As Object, e As EventArgs) Handles BtAddL2.Click
        Enabled = False
        addMenuItemL2(ListBoxL1.SelectedIndex, ListBoxL2.Items.Count)
        Enabled = True
    End Sub

    Private Sub BtRemoveL2_Click(sender As Object, e As EventArgs) Handles BtRemoveL2.Click
        Enabled = False
        removeMenuItemL2(ListBoxL1.SelectedIndex, ListBoxL2.Items.Count, ListBoxL2.SelectedIndex)
        Enabled = True
    End Sub

    Private Sub BtTopL2_Click(sender As Object, e As EventArgs) Handles BtUpL2.DoubleClick
        Enabled = False
        moveMenuItemL2(ListBoxL1.SelectedIndex, ListBoxL2.SelectedIndex, menuMovementDir.Up, True)
        ListBoxL2.SelectedIndex = 0
        Enabled = True
    End Sub

    Private Sub BtUpL2_Click(sender As Object, e As EventArgs) Handles BtUpL2.Click
        Enabled = False
        moveMenuItemL2(ListBoxL1.SelectedIndex, ListBoxL2.SelectedIndex, menuMovementDir.Up)
        ListBoxL2.SelectedIndex = ListBoxL2.SelectedIndex - 1
        Enabled = True
    End Sub

    Private Sub BtDownL2_Click(sender As Object, e As EventArgs) Handles BtDownL2.Click
        Enabled = False
        moveMenuItemL2(ListBoxL1.SelectedIndex, ListBoxL2.SelectedIndex, menuMovementDir.Down)
        ListBoxL2.SelectedIndex = ListBoxL2.SelectedIndex + 1
        Enabled = True
    End Sub

    Private Sub BtBottomL2_Click(sender As Object, e As EventArgs) Handles BtDownL2.DoubleClick
        Enabled = False
        moveMenuItemL2(ListBoxL1.SelectedIndex, ListBoxL2.SelectedIndex, menuMovementDir.Down, True)
        ListBoxL2.SelectedIndex = ListBoxL2.Items.Count - 1
        Enabled = True
    End Sub
#End Region

End Class