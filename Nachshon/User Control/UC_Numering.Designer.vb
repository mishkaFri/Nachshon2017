<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Numering
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpGroups = New System.Windows.Forms.GroupBox
        Me.lblSelCount = New System.Windows.Forms.Label
        Me.lstKnum = New System.Windows.Forms.ListBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpGroups.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Numering Result"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpGroups
        '
        Me.grpGroups.Controls.Add(Me.lblSelCount)
        Me.grpGroups.Controls.Add(Me.lstKnum)
        Me.grpGroups.Location = New System.Drawing.Point(7, 55)
        Me.grpGroups.Name = "grpGroups"
        Me.grpGroups.Size = New System.Drawing.Size(147, 139)
        Me.grpGroups.TabIndex = 16
        Me.grpGroups.TabStop = False
        Me.grpGroups.Text = "KNUM List:"
        '
        'lblSelCount
        '
        Me.lblSelCount.AutoSize = True
        Me.lblSelCount.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelCount.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblSelCount.Location = New System.Drawing.Point(10, 119)
        Me.lblSelCount.Name = "lblSelCount"
        Me.lblSelCount.Size = New System.Drawing.Size(103, 17)
        Me.lblSelCount.TabIndex = 13
        Me.lblSelCount.Text = "Blocks Selected ="
        '
        'lstKnum
        '
        Me.lstKnum.FormattingEnabled = True
        Me.lstKnum.ItemHeight = 16
        Me.lstKnum.Location = New System.Drawing.Point(13, 25)
        Me.lstKnum.Name = "lstKnum"
        Me.lstKnum.Size = New System.Drawing.Size(125, 84)
        Me.lstKnum.TabIndex = 12
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(7, 200)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(31, 27)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'UC_Numering
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpGroups)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UC_Numering"
        Me.Size = New System.Drawing.Size(161, 238)
        Me.grpGroups.ResumeLayout(False)
        Me.grpGroups.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpGroups As System.Windows.Forms.GroupBox
    Friend WithEvents lstKnum As System.Windows.Forms.ListBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblSelCount As System.Windows.Forms.Label

End Class
