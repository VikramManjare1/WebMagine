Imports System.Windows.Forms

Public Class DlgNewPage

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TextBoxDefault.Text.Length > 0 Then
            fxWPCreateNewPage(TextBoxDefault.Text + ".html")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBoxDefault_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxDefault.KeyUp
        LblxPath.Text = ucIDEMain.xpActiveDir + TextBoxDefault.Text + ".html"
    End Sub
End Class
