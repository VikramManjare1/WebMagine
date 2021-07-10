Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Public Class MultiLineTextEditor
    Inherits UITypeEditor
    Private _editorService As IWindowsFormsEditorService

    Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.DropDown
    End Function

    Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
        _editorService = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

        Dim textEditorBox As New TextBox()
        textEditorBox.Multiline = True
        textEditorBox.ScrollBars = ScrollBars.Vertical
        textEditorBox.Width = 300
        textEditorBox.Height = 150
        textEditorBox.BorderStyle = BorderStyle.None
        textEditorBox.AcceptsReturn = False

        textEditorBox.Text = TryCast(value, String)

        _editorService.DropDownControl(textEditorBox)

        Return textEditorBox.Text

    End Function

End Class