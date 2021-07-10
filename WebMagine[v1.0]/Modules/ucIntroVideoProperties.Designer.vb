﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucIntroVideoProperties
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucIntroImageProperties))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PXG = New PropertyGridEx.PropertyGridEx()
        Me.BtRemoveIntroImage = New System.Windows.Forms.ToolStripButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Image Intro Properties Box"
        '
        'PXG
        '
        '
        '
        '
        Me.PXG.DocCommentDescription.AccessibleName = ""
        Me.PXG.DocCommentDescription.AutoEllipsis = True
        Me.PXG.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PXG.DocCommentDescription.Location = New System.Drawing.Point(3, 21)
        Me.PXG.DocCommentDescription.Name = ""
        Me.PXG.DocCommentDescription.Size = New System.Drawing.Size(294, 34)
        Me.PXG.DocCommentDescription.TabIndex = 1
        Me.PXG.DocCommentImage = Nothing
        '
        '
        '
        Me.PXG.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PXG.DocCommentTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PXG.DocCommentTitle.Location = New System.Drawing.Point(3, 3)
        Me.PXG.DocCommentTitle.Name = ""
        Me.PXG.DocCommentTitle.Size = New System.Drawing.Size(294, 18)
        Me.PXG.DocCommentTitle.TabIndex = 0
        Me.PXG.DocCommentTitle.UseMnemonic = False
        Me.PXG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PXG.Location = New System.Drawing.Point(0, 15)
        Me.PXG.Name = "PXG"
        Me.PXG.SelectedObject = CType(resources.GetObject("PXG.SelectedObject"), Object)
        Me.PXG.ShowCustomProperties = True
        Me.PXG.Size = New System.Drawing.Size(300, 585)
        Me.PXG.TabIndex = 4
        '
        '
        '
        Me.PXG.ToolStrip.AccessibleName = "ToolBar"
        Me.PXG.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.PXG.ToolStrip.AllowMerge = False
        Me.PXG.ToolStrip.AutoSize = False
        Me.PXG.ToolStrip.CanOverflow = False
        Me.PXG.ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.PXG.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PXG.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtRemoveIntroImage})
        Me.PXG.ToolStrip.Location = New System.Drawing.Point(0, 1)
        Me.PXG.ToolStrip.Name = ""
        Me.PXG.ToolStrip.Padding = New System.Windows.Forms.Padding(2, 0, 1, 0)
        Me.PXG.ToolStrip.Size = New System.Drawing.Size(300, 25)
        Me.PXG.ToolStrip.TabIndex = 1
        Me.PXG.ToolStrip.TabStop = True
        Me.PXG.ToolStrip.Text = "PropertyGridToolBar"
        '
        'BtRemoveIntroImage
        '
        Me.BtRemoveIntroImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtRemoveIntroImage.Image = Global.EasyWebSimple.My.Resources.Resources.delete_16x16
        Me.BtRemoveIntroImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtRemoveIntroImage.Name = "BtRemoveIntroImage"
        Me.BtRemoveIntroImage.Size = New System.Drawing.Size(23, 22)
        Me.BtRemoveIntroImage.Text = "Remove Image Intro"
        '
        'ucIntroImageProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PXG)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucIntroImageProperties"
        Me.Size = New System.Drawing.Size(300, 600)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BtRemoveIntroImage As ToolStripButton
    Friend WithEvents PXG As PropertyGridEx.PropertyGridEx
End Class
