Imports System.Drawing.Design
Imports System.IO

Public Class ucMenuProperties
    Private Sub PXG_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PXG.PropertyValueChanged
        If e.ChangedItem.Label = "Theme" Then
            changeMenuTheme(e.ChangedItem.Value.ToString())
        ElseIf e.ChangedItem.Label = "Favicon" Then
            Dim stream = New FileStream(ucIDEMain.xpActiveDir + "favicon.ico", FileMode.Create)
            CType(e.ChangedItem.Value, Icon).Save(stream)
            stream.Close()
            ucIDEMain.fxRefreshIDE("Menu Icon Changed", False, True, False)
        ElseIf e.ChangedItem.Label = "FixedOnTop" Then
            If e.ChangedItem.Value Then
                replaceClassAt("Menu Fixed ON TOP", "header", ucIDEMain.WebView1, -1, "fixed-to", "fixed-top")
            Else
                replaceClassAt("Menu Fixed OFF TOP", "header", ucIDEMain.WebView1, -1, "fixed-top", "fixed-to")
            End If
        ElseIf e.ChangedItem.Label = "BrandName" Then
            setInnerTextAt("Menu Brand Name OK", ".headerDivBrand", ucIDEMain.WebView1, e.ChangedItem.Value, -1)
        End If
    End Sub

    Private Sub TSBtRemoveMenuBar_Click(sender As Object, e As EventArgs) Handles TSBtRemoveMenuBar.Click
        removeMenuAfterConfirm()
    End Sub

    Private Sub ucMenuProperties_Load(sender As Object, e As EventArgs) Handles Me.Load
        fxFillPXG()
    End Sub
    Public Enum MenuColorTheme
        darcula
        pink
        navy
        red
        green
        orange
    End Enum
    Private Sub fxFillPXG()
        PXG.Item.Clear()
        Dim BrandName As String = getInnerHTMLAt(".headerDivBrand", ucIDEMain.WebView1, -1)
        Dim tempTheme As MenuColorTheme = MenuColorTheme.darcula
        For i = 0 To StrArrMenuTheme.Length - 1
            If hasClassAt("header", ucIDEMain.WebView1, -1, StrArrMenuTheme(i)) Then
                tempTheme = i
            End If
        Next
        Dim favicon = New Icon(ucIDEMain.xpActiveDir + "favicon.ico")
        Dim fixedTop As Boolean = hasClassAt("header", ucIDEMain.WebView1, -1, "fixed-top")
        With PXG
            .Item.Add("BrandName", BrandName, False, "Appearance", "Enter Menu Brand Text")
            .Item(.Item.Count - 1).CustomEditor = CType(New MultiLineTextEditor(), UITypeEditor)

            .Item.Add("Theme", tempTheme, False, "Appearance", "Choose Menu Color Theme")
            .Item.Add("Favicon", favicon, False, "Design", "Select favicon for the website.")
            .Item.Add("FixedOnTop", fixedTop, False, "Dock", "If True menu will be fixed ON Top of Page Regardless of Scrolling.")
            .Item.Add("MenuItems", "(Menu Items)", False, "Behaviour", "Edit Menu Items", True)
            .Item(.Item.Count - 1).OnClick = AddressOf Me.CustomEventItem_OnClick
            .Refresh()
        End With
    End Sub

    Private Function CustomEventItem_OnClick(sender As Object, e As EventArgs) As Object
        IDEMenu.ShowDialog(ucIDEMain)
        Return "MenuItems"
    End Function
End Class

