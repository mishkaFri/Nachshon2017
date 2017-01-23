<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_InsertBlock
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
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.TabMenu = New System.Windows.Forms.TabControl
        Me.Attributes = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnAcadSel = New System.Windows.Forms.Button
        Me.lblAcadSelect = New System.Windows.Forms.Label
        Me.grpSelKNum = New System.Windows.Forms.GroupBox
        Me.btnKnumSel = New System.Windows.Forms.Button
        Me.cmbKnumList = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SubAssembly = New System.Windows.Forms.TabPage
        Me.Bom = New System.Windows.Forms.TabPage
        Me.Reserve = New System.Windows.Forms.TabPage
        Me.TabMenu.SuspendLayout()
        Me.Attributes.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpSelKNum.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMenu
        '
        Me.TabMenu.Controls.Add(Me.Attributes)
        Me.TabMenu.Controls.Add(Me.SubAssembly)
        Me.TabMenu.Controls.Add(Me.Bom)
        Me.TabMenu.Controls.Add(Me.Reserve)
        Me.TabMenu.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabMenu.Location = New System.Drawing.Point(8, 3)
        Me.TabMenu.Name = "TabMenu"
        Me.TabMenu.SelectedIndex = 0
        Me.TabMenu.ShowToolTips = True
        Me.TabMenu.Size = New System.Drawing.Size(192, 267)
        Me.TabMenu.TabIndex = 3
        '
        'Attributes
        '
        Me.Attributes.Controls.Add(Me.GroupBox1)
        Me.Attributes.Controls.Add(Me.grpSelKNum)
        Me.Attributes.Controls.Add(Me.Label1)
        Me.Attributes.Location = New System.Drawing.Point(4, 25)
        Me.Attributes.Name = "Attributes"
        Me.Attributes.Padding = New System.Windows.Forms.Padding(3)
        Me.Attributes.Size = New System.Drawing.Size(184, 238)
        Me.Attributes.TabIndex = 1
        Me.Attributes.Text = "1. Attributes"
        Me.Attributes.ToolTipText = "Change Attributes of Blocks"
        Me.Attributes.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAcadSel)
        Me.GroupBox1.Controls.Add(Me.lblAcadSelect)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(166, 56)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Autocad Selection "
        '
        'btnAcadSel
        '
        Me.btnAcadSel.Image = Global.Nachshon.My.Resources.Resources.SelectAll
        Me.btnAcadSel.Location = New System.Drawing.Point(132, 21)
        Me.btnAcadSel.Name = "btnAcadSel"
        Me.btnAcadSel.Size = New System.Drawing.Size(24, 25)
        Me.btnAcadSel.TabIndex = 13
        Me.btnAcadSel.UseVisualStyleBackColor = True
        '
        'lblAcadSelect
        '
        Me.lblAcadSelect.AutoSize = True
        Me.lblAcadSelect.ForeColor = System.Drawing.Color.Maroon
        Me.lblAcadSelect.Location = New System.Drawing.Point(6, 29)
        Me.lblAcadSelect.Name = "lblAcadSelect"
        Me.lblAcadSelect.Size = New System.Drawing.Size(115, 17)
        Me.lblAcadSelect.TabIndex = 12
        Me.lblAcadSelect.Text = "Click after Selection"
        '
        'grpSelKNum
        '
        Me.grpSelKNum.Controls.Add(Me.btnKnumSel)
        Me.grpSelKNum.Controls.Add(Me.cmbKnumList)
        Me.grpSelKNum.Location = New System.Drawing.Point(10, 110)
        Me.grpSelKNum.Name = "grpSelKNum"
        Me.grpSelKNum.Size = New System.Drawing.Size(168, 56)
        Me.grpSelKNum.TabIndex = 12
        Me.grpSelKNum.TabStop = False
        Me.grpSelKNum.Text = "Selection By Knum"
        '
        'btnKnumSel
        '
        Me.btnKnumSel.Image = Global.Nachshon.My.Resources.Resources.SelectAll
        Me.btnKnumSel.Location = New System.Drawing.Point(133, 21)
        Me.btnKnumSel.Name = "btnKnumSel"
        Me.btnKnumSel.Size = New System.Drawing.Size(24, 25)
        Me.btnKnumSel.TabIndex = 11
        Me.btnKnumSel.UseVisualStyleBackColor = True
        '
        'cmbKnumList
        '
        Me.cmbKnumList.FormattingEnabled = True
        Me.cmbKnumList.Location = New System.Drawing.Point(6, 21)
        Me.cmbKnumList.Name = "cmbKnumList"
        Me.cmbKnumList.Size = New System.Drawing.Size(119, 24)
        Me.cmbKnumList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Blocks Attributes"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SubAssembly
        '
        Me.SubAssembly.Location = New System.Drawing.Point(4, 25)
        Me.SubAssembly.Name = "SubAssembly"
        Me.SubAssembly.Size = New System.Drawing.Size(184, 238)
        Me.SubAssembly.TabIndex = 2
        Me.SubAssembly.Text = "2. Sub Assembly"
        Me.SubAssembly.ToolTipText = "Unit Blocks to Sub Assembly Object"
        Me.SubAssembly.UseVisualStyleBackColor = True
        '
        'Bom
        '
        Me.Bom.Location = New System.Drawing.Point(4, 25)
        Me.Bom.Name = "Bom"
        Me.Bom.Size = New System.Drawing.Size(184, 238)
        Me.Bom.TabIndex = 3
        Me.Bom.Text = "3. BOM"
        Me.Bom.ToolTipText = "Create Output Specification Documents"
        Me.Bom.UseVisualStyleBackColor = True
        '
        'Reserve
        '
        Me.Reserve.Location = New System.Drawing.Point(4, 25)
        Me.Reserve.Name = "Reserve"
        Me.Reserve.Size = New System.Drawing.Size(184, 238)
        Me.Reserve.TabIndex = 4
        Me.Reserve.Text = "4. Reserve"
        Me.Reserve.UseVisualStyleBackColor = True
        '
        'UC_InsertBlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabMenu)
        Me.Name = "UC_InsertBlock"
        Me.Size = New System.Drawing.Size(200, 270)
        Me.TabMenu.ResumeLayout(False)
        Me.Attributes.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpSelKNum.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TabMenu As System.Windows.Forms.TabControl
    Friend WithEvents Attributes As System.Windows.Forms.TabPage
    Friend WithEvents SubAssembly As System.Windows.Forms.TabPage
    Friend WithEvents Bom As System.Windows.Forms.TabPage
    Friend WithEvents Reserve As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpSelKNum As System.Windows.Forms.GroupBox
    Friend WithEvents btnKnumSel As System.Windows.Forms.Button
    Friend WithEvents cmbKnumList As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAcadSel As System.Windows.Forms.Button
    Friend WithEvents lblAcadSelect As System.Windows.Forms.Label

End Class
