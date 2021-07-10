Imports System.IO

Module fxISMIntroSimpleManipulation
    Public StrArrIntroType() As String = {"IntroSimple", "IntroImage", "IntroCoverSimple", "IntroBGImageCover", "IntroVideo"}
    Public Sub createIntro(ByVal introTypeIndex As Short)
        ucIDEMain.Enabled = False
        Dim index = ucIDEMain.LBAddedItems.SelectedIndex
        appendToBody("Create Intro", StrArrIntroType(introTypeIndex), ucIDEMain.LBAddedItems.SelectedIndex, False)
        ucIDEMain.LBAddedItems.SelectedIndex = index + 1
        ucIDEMain.Enabled = True
    End Sub
    Public Sub removeIntroAfterConfirm(ByVal introTypeIndex As Short, Optional fileToDeletePath As String = "")
        Dim subMessages() As String = {"Simple Intro", "Image Intro", "Simple Cover Intro", "BGImage Cover Intro", "Video Intro"}
        Dim selectors() As String = {".intro-i1", ".intro-i2", ".intro-iuc2", ".intro-iuc3", ".intro-i3"}
        Dim message = String.Format("This will remove selected {0} Item from the page.Do you want to continue?", subMessages(introTypeIndex))
        If fxMBShowMsgBoxYesNo(message, MBType.Question) = DialogResult.Yes Then
            ucIDEMain.WebView1.EvalScript(String.Format("var $prev = $('{0}').eq('{1}');$prev.remove();", selectors(introTypeIndex), getIntroItemIndexInLBBlocks(introTypeIndex)))
            fxFLWriteFile("Remove IntroSimple", ucIDEMain.xpActiveWebPageFullPath, ucIDEMain.WebView1.GetHtml(), True, True, True)
            If (introTypeIndex = 1 Or introTypeIndex = 3 Or introTypeIndex = 4) And fileToDeletePath.Length > 0 Then
                File.Delete(fileToDeletePath)
            End If
        End If
        If IDEIntroSimpleButtons.Visible Then
            IDEIntroSimpleButtons.Close()
        End If
    End Sub
    Public Function getIntroItemIndexInLBBlocks(introIndex As Integer) As Integer
        Return getItemIndexInLBBlocks(StrArrIntroType(introIndex))
    End Function
    Public Function getItemIndexInLBBlocks(ByVal value As String) As Integer
        Dim item = ucIDEMain.LBAddedItems.SelectedItem
        Dim selection = -1
        If item.ToString().Contains(value.ToString()) Then
            For i = 0 To ucIDEMain.LBAddedItems.SelectedIndex
                If ucIDEMain.LBAddedItems.Items.Item(i).ToString().Contains(value) Then
                    selection += 1
                End If
            Next
        End If
        Return selection
    End Function
End Module
