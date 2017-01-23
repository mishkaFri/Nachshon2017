<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Attributes_2
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
        Me.grpAutoCadSelect = New System.Windows.Forms.GroupBox
        Me.btnAcadSelAtt = New System.Windows.Forms.Button
        Me.lblClickAfterSel = New System.Windows.Forms.Label
        Me.grpSelectByKnum = New System.Windows.Forms.GroupBox
        Me.StripKlist = New System.Windows.Forms.ToolStrip
        Me.StripKlistDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.TxtKlist = New System.Windows.Forms.TextBox
        Me.btnKnumSelAtt = New System.Windows.Forms.Button
        Me.cmbKnumLst = New System.Windows.Forms.ComboBox
        Me.lblSelCount = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.AddAtt = New System.Windows.Forms.GroupBox
        Me.BtnAddAtt = New System.Windows.Forms.Button
        Me.grpAutoCadSelect.SuspendLayout()
        Me.grpSelectByKnum.SuspendLayout()
        Me.StripKlist.SuspendLayout()
        Me.AddAtt.SuspendLayout()
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
        Me.Label3.Text = "Blocks Attributes"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpAutoCadSelect
        '
        Me.grpAutoCadSelect.Controls.Add(Me.btnAcadSelAtt)
        Me.grpAutoCadSelect.Controls.Add(Me.lblClickAfterSel)
        Me.grpAutoCadSelect.Location = New System.Drawing.Point(7, 63)
        Me.grpAutoCadSelect.Name = "grpAutoCadSelect"
        Me.grpAutoCadSelect.Size = New System.Drawing.Size(145, 56)
        Me.grpAutoCadSelect.TabIndex = 16
        Me.grpAutoCadSelect.TabStop = False
        Me.grpAutoCadSelect.Text = "Autocad Selection"
        '
        'btnAcadSelAtt
        '
        Me.btnAcadSelAtt.Image = Global.Nachshon.My.Resources.Resources.SelectAll
        Me.btnAcadSelAtt.Location = New System.Drawing.Point(117, 23)
        Me.btnAcadSelAtt.Name = "btnAcadSelAtt"
        Me.btnAcadSelAtt.Size = New System.Drawing.Size(21, 25)
        Me.btnAcadSelAtt.TabIndex = 14
        Me.btnAcadSelAtt.UseVisualStyleBackColor = True
        '
        'lblClickAfterSel
        '
        Me.lblClickAfterSel.AutoSize = True
        Me.lblClickAfterSel.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClickAfterSel.ForeColor = System.Drawing.Color.Maroon
        Me.lblClickAfterSel.Location = New System.Drawing.Point(6, 27)
        Me.lblClickAfterSel.Name = "lblClickAfterSel"
        Me.lblClickAfterSel.Size = New System.Drawing.Size(115, 17)
        Me.lblClickAfterSel.TabIndex = 13
        Me.lblClickAfterSel.Text = "Click after Selection"
        '
        'grpSelectByKnum
        '
        Me.grpSelectByKnum.Controls.Add(Me.StripKlist)
        Me.grpSelectByKnum.Controls.Add(Me.TxtKlist)
        Me.grpSelectByKnum.Controls.Add(Me.btnKnumSelAtt)
        Me.grpSelectByKnum.Location = New System.Drawing.Point(7, 130)
        Me.grpSelectByKnum.Name = "grpSelectByKnum"
        Me.grpSelectByKnum.Size = New System.Drawing.Size(147, 59)
        Me.grpSelectByKnum.TabIndex = 17
        Me.grpSelectByKnum.TabStop = False
        Me.grpSelectByKnum.Text = "Selection By KNUM"
        '
        'StripKlist
        '
        Me.StripKlist.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.StripKlist.Dock = System.Windows.Forms.DockStyle.None
        Me.StripKlist.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StripKlist.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StripKlistDropDownButton1})
        Me.StripKlist.Location = New System.Drawing.Point(40, 22)
        Me.StripKlist.Name = "StripKlist"
        Me.StripKlist.Size = New System.Drawing.Size(23, 25)
        Me.StripKlist.TabIndex = 23
        Me.StripKlist.Text = "ToolStrip1"
        '
        'StripKlistDropDownButton1
        '
        Me.StripKlistDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripKlistDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.StripKlistDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StripKlistDropDownButton1.Name = "StripKlistDropDownButton1"
        Me.StripKlistDropDownButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StripKlistDropDownButton1.Size = New System.Drawing.Size(13, 22)
        Me.StripKlistDropDownButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.StripKlistDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.StripKlistDropDownButton1.ToolTipText = "Available KNUM's"
        '
        'TxtKlist
        '
        Me.TxtKlist.Location = New System.Drawing.Point(50, 22)
        Me.TxtKlist.Name = "TxtKlist"
        Me.TxtKlist.Size = New System.Drawing.Size(57, 22)
        Me.TxtKlist.TabIndex = 13
        Me.TxtKlist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnKnumSelAtt
        '
        Me.btnKnumSelAtt.Image = Global.Nachshon.My.Resources.Resources.SelectAll
        Me.btnKnumSelAtt.Location = New System.Drawing.Point(117, 21)
        Me.btnKnumSelAtt.Name = "btnKnumSelAtt"
        Me.btnKnumSelAtt.Size = New System.Drawing.Size(21, 25)
        Me.btnKnumSelAtt.TabIndex = 12
        Me.btnKnumSelAtt.UseVisualStyleBackColor = True
        '
        'cmbKnumLst
        '
        Me.cmbKnumLst.AllowDrop = True
        Me.cmbKnumLst.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKnumLst.FormattingEnabled = True
        Me.cmbKnumLst.Location = New System.Drawing.Point(96, 242)
        Me.cmbKnumLst.Name = "cmbKnumLst"
        Me.cmbKnumLst.Size = New System.Drawing.Size(97, 24)
        Me.cmbKnumLst.TabIndex = 22
        Me.cmbKnumLst.Visible = False
        '
        'lblSelCount
        '
        Me.lblSelCount.AutoSize = True
        Me.lblSelCount.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelCount.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblSelCount.Location = New System.Drawing.Point(42, 245)
        Me.lblSelCount.Name = "lblSelCount"
        Me.lblSelCount.Size = New System.Drawing.Size(72, 17)
        Me.lblSelCount.TabIndex = 24
        Me.lblSelCount.Text = "Blocks No ="
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(7, 245)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(31, 27)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'AddAtt
        '
        Me.AddAtt.Controls.Add(Me.BtnAddAtt)
        Me.AddAtt.Location = New System.Drawing.Point(7, 195)
        Me.AddAtt.Name = "AddAtt"
        Me.AddAtt.Size = New System.Drawing.Size(145, 41)
        Me.AddAtt.TabIndex = 17
        Me.AddAtt.TabStop = False
        Me.AddAtt.Text = "Add Kitchen Att"
        '
        'BtnAddAtt
        '
        Me.BtnAddAtt.Image = Global.Nachshon.My.Resources.Resources.Plus2
        Me.BtnAddAtt.Location = New System.Drawing.Point(50, 16)
        Me.BtnAddAtt.Name = "BtnAddAtt"
        Me.BtnAddAtt.Size = New System.Drawing.Size(36, 25)
        Me.BtnAddAtt.TabIndex = 14
        Me.BtnAddAtt.UseVisualStyleBackColor = True
        '
        'UC_Attributes_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AddAtt)
        Me.Controls.Add(Me.lblSelCount)
        Me.Controls.Add(Me.cmbKnumLst)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpSelectByKnum)
        Me.Controls.Add(Me.grpAutoCadSelect)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UC_Attributes_2"
        Me.Size = New System.Drawing.Size(161, 294)
        Me.grpAutoCadSelect.ResumeLayout(False)
        Me.grpAutoCadSelect.PerformLayout()
        Me.grpSelectByKnum.ResumeLayout(False)
        Me.grpSelectByKnum.PerformLayout()
        Me.StripKlist.ResumeLayout(False)
        Me.StripKlist.PerformLayout()
        Me.AddAtt.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpAutoCadSelect As System.Windows.Forms.GroupBox
    Friend WithEvents grpSelectByKnum As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblClickAfterSel As System.Windows.Forms.Label
    Friend WithEvents btnAcadSelAtt As System.Windows.Forms.Button
    Friend WithEvents btnKnumSelAtt As System.Windows.Forms.Button
    Friend WithEvents cmbKnumLst As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelCount As System.Windows.Forms.Label
    Friend WithEvents TxtKlist As System.Windows.Forms.TextBox
    Friend WithEvents StripKlistDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents StripKlist As System.Windows.Forms.ToolStrip
    Friend WithEvents AddAtt As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAddAtt As System.Windows.Forms.Button

End Class
