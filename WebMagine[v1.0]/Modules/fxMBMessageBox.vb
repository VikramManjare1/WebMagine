Module fxMBMessageBox
    Enum MBType
        Errors
        Warning
        Exclamation
        Information
        Question
    End Enum
    Private Function fxGetMessageBoxIcon(mBoxType As MBType) As MessageBoxIcon
        Dim messageBoxIcon As MessageBoxIcon = MessageBoxIcon.None
        Select Case mBoxType
            Case MBType.Warning
                messageBoxIcon = MessageBoxIcon.Warning
            Case MBType.Errors
                messageBoxIcon = MessageBoxIcon.Error
            Case MBType.Exclamation
                messageBoxIcon = MessageBoxIcon.Exclamation
            Case MBType.Information
                messageBoxIcon = MessageBoxIcon.Information
            Case MBType.Question
                messageBoxIcon = MessageBoxIcon.Question
        End Select
        Return messageBoxIcon
    End Function
    Private Function fxGetMsgBoxStr(mBoxType As MBType) As String
        Dim str As String = " WebMagine "
        Select Case mBoxType
            Case MBType.Warning
                str += "Warning"
            Case MBType.Errors
                str += "Error"
            Case MBType.Exclamation
                str += "!"
            Case MBType.Information
                str += "Information"
            Case MBType.Question
                str += "Confirm Action"
        End Select
        Return str
    End Function
    Public Sub fxMBShowMsgBoxOK(content As String, mboxtype As MBType)
        MessageBox.Show(content, fxGetMsgBoxStr(mboxtype), MessageBoxButtons.OK, fxGetMessageBoxIcon(mboxtype))
    End Sub
    Public Function fxMBShowMsgBoxOKCancel(content As String, mboxtype As MBType) As DialogResult
        Return MessageBox.Show(content, fxGetMsgBoxStr(mboxtype), MessageBoxButtons.OKCancel, fxGetMessageBoxIcon(mboxtype))
    End Function
    Public Function fxMBShowMsgBoxYesNo(content As String, mboxtype As MBType) As DialogResult
        Return MessageBox.Show(content, fxGetMsgBoxStr(mboxtype), MessageBoxButtons.YesNo, fxGetMessageBoxIcon(mboxtype))
    End Function
End Module
