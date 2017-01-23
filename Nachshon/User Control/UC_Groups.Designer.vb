<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Groups
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_Groups))
        Me.LblGroups = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.BtnAddGrp = New System.Windows.Forms.Button
        Me.BtnEdit = New System.Windows.Forms.Button
        Me.lstGroups = New System.Windows.Forms.ListBox
        Me.lblSelCount = New System.Windows.Forms.Label
        Me.grpGroups = New System.Windows.Forms.GroupBox
        Me.GrpAddGrp = New System.Windows.Forms.GroupBox
        Me.BtnCopyGrp = New System.Windows.Forms.Button
        Me.BtnAddToGrp = New System.Windows.Forms.Button
        Me.BtnEraseFmGrp = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.LblSelectPar = New System.Windows.Forms.Label
        Me.btnAcadSelBlock = New System.Windows.Forms.Button
        Me.LblSel = New System.Windows.Forms.Label
        Me.lstBlocksInAss = New System.Windows.Forms.ListBox
        Me.TxtGrpName = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpGroups.SuspendLayout()
        Me.GrpAddGrp.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblGroups
        '
        Me.LblGroups.Font = New System.Drawing.Font("Arial Narrow", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGroups.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblGroups.Location = New System.Drawing.Point(12, 18)
        Me.LblGroups.Name = "LblGroups"
        Me.LblGroups.Size = New System.Drawing.Size(133, 20)
        Me.LblGroups.TabIndex = 18
        Me.LblGroups.Text = "Assemblies"
        Me.LblGroups.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(7, 193)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(31, 27)
        Me.btnCancel.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.btnCancel, "Back")
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'BtnAddGrp
        '
        Me.BtnAddGrp.Location = New System.Drawing.Point(44, 193)
        Me.BtnAddGrp.Name = "BtnAddGrp"
        Me.BtnAddGrp.Size = New System.Drawing.Size(50, 27)
        Me.BtnAddGrp.TabIndex = 21
        Me.BtnAddGrp.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.BtnAddGrp, "Add new Group")
        Me.BtnAddGrp.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Location = New System.Drawing.Point(96, 193)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(49, 27)
        Me.BtnEdit.TabIndex = 22
        Me.BtnEdit.Text = "Edit"
        Me.ToolTip1.SetToolTip(Me.BtnEdit, "Edit Selected Group")
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'lstGroups
        '
        Me.lstGroups.FormattingEnabled = True
        Me.lstGroups.ItemHeight = 16
        Me.lstGroups.Location = New System.Drawing.Point(13, 25)
        Me.lstGroups.Name = "lstGroups"
        Me.lstGroups.Size = New System.Drawing.Size(125, 84)
        Me.lstGroups.TabIndex = 12
        '
        'lblSelCount
        '
        Me.lblSelCount.AutoSize = True
        Me.lblSelCount.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelCount.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblSelCount.Location = New System.Drawing.Point(10, 119)
        Me.lblSelCount.Name = "lblSelCount"
        Me.lblSelCount.Size = New System.Drawing.Size(121, 17)
        Me.lblSelCount.TabIndex = 13
        Me.lblSelCount.Text = "Blocks In Assembly ="
        '
        'grpGroups
        '
        Me.grpGroups.Controls.Add(Me.lblSelCount)
        Me.grpGroups.Controls.Add(Me.lstGroups)
        Me.grpGroups.Location = New System.Drawing.Point(7, 48)
        Me.grpGroups.Name = "grpGroups"
        Me.grpGroups.Size = New System.Drawing.Size(147, 139)
        Me.grpGroups.TabIndex = 19
        Me.grpGroups.TabStop = False
        Me.grpGroups.Text = "Parent Name List:"
        '
        'GrpAddGrp
        '
        Me.GrpAddGrp.Controls.Add(Me.BtnCopyGrp)
        Me.GrpAddGrp.Controls.Add(Me.BtnAddToGrp)
        Me.GrpAddGrp.Controls.Add(Me.BtnEraseFmGrp)
        Me.GrpAddGrp.Controls.Add(Me.btnOK)
        Me.GrpAddGrp.Controls.Add(Me.LblSelectPar)
        Me.GrpAddGrp.Controls.Add(Me.btnAcadSelBlock)
        Me.GrpAddGrp.Controls.Add(Me.LblSel)
        Me.GrpAddGrp.Controls.Add(Me.lstBlocksInAss)
        Me.GrpAddGrp.Location = New System.Drawing.Point(7, 48)
        Me.GrpAddGrp.Name = "GrpAddGrp"
        Me.GrpAddGrp.Size = New System.Drawing.Size(147, 139)
        Me.GrpAddGrp.TabIndex = 24
        Me.GrpAddGrp.TabStop = False
        Me.GrpAddGrp.Text = "Add\Edit Assembly"
        '
        'BtnCopyGrp
        '
        Me.BtnCopyGrp.Image = CType(resources.GetObject("BtnCopyGrp.Image"), System.Drawing.Image)
        Me.BtnCopyGrp.Location = New System.Drawing.Point(56, 109)
        Me.BtnCopyGrp.Name = "BtnCopyGrp"
        Me.BtnCopyGrp.Size = New System.Drawing.Size(31, 27)
        Me.BtnCopyGrp.TabIndex = 31
        Me.BtnCopyGrp.Tag = "Open selected Kitchen"
        Me.ToolTip1.SetToolTip(Me.BtnCopyGrp, "Copy Group")
        Me.BtnCopyGrp.UseVisualStyleBackColor = True
        '
        'BtnAddToGrp
        '
        Me.BtnAddToGrp.Image = CType(resources.GetObject("BtnAddToGrp.Image"), System.Drawing.Image)
        Me.BtnAddToGrp.Location = New System.Drawing.Point(13, 109)
        Me.BtnAddToGrp.Name = "BtnAddToGrp"
        Me.BtnAddToGrp.Size = New System.Drawing.Size(31, 27)
        Me.BtnAddToGrp.TabIndex = 30
        Me.BtnAddToGrp.Tag = "Open selected Kitchen"
        Me.ToolTip1.SetToolTip(Me.BtnAddToGrp, "Add Component to Group")
        Me.BtnAddToGrp.UseVisualStyleBackColor = True
        '
        'BtnEraseFmGrp
        '
        Me.BtnEraseFmGrp.Image = CType(resources.GetObject("BtnEraseFmGrp.Image"), System.Drawing.Image)
        Me.BtnEraseFmGrp.Location = New System.Drawing.Point(56, 109)
        Me.BtnEraseFmGrp.Name = "BtnEraseFmGrp"
        Me.BtnEraseFmGrp.Size = New System.Drawing.Size(31, 27)
        Me.BtnEraseFmGrp.TabIndex = 29
        Me.BtnEraseFmGrp.Tag = "Open selected Kitchen"
        Me.BtnEraseFmGrp.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Image = Global.Nachshon.My.Resources.Resources.acgsConfigRes_512
        Me.btnOK.Location = New System.Drawing.Point(100, 109)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(31, 27)
        Me.btnOK.TabIndex = 28
        Me.btnOK.Tag = "Open selected Kitchen"
        Me.ToolTip1.SetToolTip(Me.btnOK, "Create Group")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'LblSelectPar
        '
        Me.LblSelectPar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.LblSelectPar.Location = New System.Drawing.Point(6, 65)
        Me.LblSelectPar.Name = "LblSelectPar"
        Me.LblSelectPar.Size = New System.Drawing.Size(125, 40)
        Me.LblSelectPar.TabIndex = 16
        Me.LblSelectPar.Text = "Pick Parent Block..."
        '
        'btnAcadSelBlock
        '
        Me.btnAcadSelBlock.Image = Global.Nachshon.My.Resources.Resources.SelectAll
        Me.btnAcadSelBlock.Location = New System.Drawing.Point(110, 28)
        Me.btnAcadSelBlock.Name = "btnAcadSelBlock"
        Me.btnAcadSelBlock.Size = New System.Drawing.Size(21, 25)
        Me.btnAcadSelBlock.TabIndex = 15
        Me.btnAcadSelBlock.UseVisualStyleBackColor = True
        '
        'LblSel
        '
        Me.LblSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.LblSel.Location = New System.Drawing.Point(6, 25)
        Me.LblSel.Name = "LblSel"
        Me.LblSel.Size = New System.Drawing.Size(107, 68)
        Me.LblSel.TabIndex = 0
        Me.LblSel.Text = "Select all components and press..."
        '
        'lstBlocksInAss
        '
        Me.lstBlocksInAss.FormattingEnabled = True
        Me.lstBlocksInAss.ItemHeight = 16
        Me.lstBlocksInAss.Location = New System.Drawing.Point(6, 21)
        Me.lstBlocksInAss.Name = "lstBlocksInAss"
        Me.lstBlocksInAss.Size = New System.Drawing.Size(125, 84)
        Me.lstBlocksInAss.TabIndex = 17
        '
        'TxtGrpName
        '
        Me.TxtGrpName.Location = New System.Drawing.Point(20, 20)
        Me.TxtGrpName.Name = "TxtGrpName"
        Me.TxtGrpName.Size = New System.Drawing.Size(100, 22)
        Me.TxtGrpName.TabIndex = 25
        '
        'UC_Groups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TxtGrpName)
        Me.Controls.Add(Me.GrpAddGrp)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnAddGrp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpGroups)
        Me.Controls.Add(Me.LblGroups)
        Me.Name = "UC_Groups"
        Me.Size = New System.Drawing.Size(161, 238)
        Me.grpGroups.ResumeLayout(False)
        Me.grpGroups.PerformLayout()
        Me.GrpAddGrp.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents LblGroups As System.Windows.Forms.Label
    Friend WithEvents BtnAddGrp As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents lstGroups As System.Windows.Forms.ListBox
    Friend WithEvents lblSelCount As System.Windows.Forms.Label
    Friend WithEvents grpGroups As System.Windows.Forms.GroupBox
    Friend WithEvents GrpAddGrp As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents LblSelectPar As System.Windows.Forms.Label
    Friend WithEvents btnAcadSelBlock As System.Windows.Forms.Button
    Friend WithEvents LblSel As System.Windows.Forms.Label
    Friend WithEvents lstBlocksInAss As System.Windows.Forms.ListBox
    Friend WithEvents BtnEraseFmGrp As System.Windows.Forms.Button
    Friend WithEvents BtnAddToGrp As System.Windows.Forms.Button
    Friend WithEvents TxtGrpName As System.Windows.Forms.TextBox
    Friend WithEvents BtnCopyGrp As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
