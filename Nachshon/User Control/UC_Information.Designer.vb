<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Information
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
        Me.InformTab = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grpKitch = New System.Windows.Forms.GroupBox
        Me.txtKitchNameEng = New System.Windows.Forms.TextBox
        Me.LblNameEng = New System.Windows.Forms.Label
        Me.txtKitchPN = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtKitchName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpProj = New System.Windows.Forms.GroupBox
        Me.TxtNameHeb = New System.Windows.Forms.TextBox
        Me.LabelNameHeb = New System.Windows.Forms.Label
        Me.txtProjDescrip = New System.Windows.Forms.TextBox
        Me.lbDescrip = New System.Windows.Forms.Label
        Me.txtProjectPN = New System.Windows.Forms.TextBox
        Me.lblPartNumb = New System.Windows.Forms.Label
        Me.txtProjectName = New System.Windows.Forms.TextBox
        Me.lblProjName = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblClickForSelect = New System.Windows.Forms.Label
        Me.btnSelect = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.btnCancel = New System.Windows.Forms.Button
        Me.TxtKitNameHeb = New System.Windows.Forms.TextBox
        Me.LblNameheb = New System.Windows.Forms.Label
        Me.InformTab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grpKitch.SuspendLayout()
        Me.grpProj.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'InformTab
        '
        Me.InformTab.Controls.Add(Me.TabPage1)
        Me.InformTab.Controls.Add(Me.TabPage2)
        Me.InformTab.Controls.Add(Me.TabPage3)
        Me.InformTab.Location = New System.Drawing.Point(9, 9)
        Me.InformTab.Name = "InformTab"
        Me.InformTab.SelectedIndex = 0
        Me.InformTab.Size = New System.Drawing.Size(182, 250)
        Me.InformTab.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grpKitch)
        Me.TabPage1.Controls.Add(Me.grpProj)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(174, 221)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Project"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grpKitch
        '
        Me.grpKitch.Controls.Add(Me.TxtKitNameHeb)
        Me.grpKitch.Controls.Add(Me.LblNameheb)
        Me.grpKitch.Controls.Add(Me.txtKitchNameEng)
        Me.grpKitch.Controls.Add(Me.LblNameEng)
        Me.grpKitch.Controls.Add(Me.txtKitchPN)
        Me.grpKitch.Controls.Add(Me.Label2)
        Me.grpKitch.Controls.Add(Me.txtKitchName)
        Me.grpKitch.Controls.Add(Me.Label3)
        Me.grpKitch.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpKitch.Location = New System.Drawing.Point(6, 123)
        Me.grpKitch.Name = "grpKitch"
        Me.grpKitch.Size = New System.Drawing.Size(161, 90)
        Me.grpKitch.TabIndex = 5
        Me.grpKitch.TabStop = False
        Me.grpKitch.Text = "Kitchen"
        '
        'txtKitchNameEng
        '
        Me.txtKitchNameEng.AcceptsReturn = True
        Me.txtKitchNameEng.AcceptsTab = True
        Me.txtKitchNameEng.Enabled = False
        Me.txtKitchNameEng.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKitchNameEng.Location = New System.Drawing.Point(79, 37)
        Me.txtKitchNameEng.Multiline = True
        Me.txtKitchNameEng.Name = "txtKitchNameEng"
        Me.txtKitchNameEng.Size = New System.Drawing.Size(75, 22)
        Me.txtKitchNameEng.TabIndex = 19
        '
        'LblNameEng
        '
        Me.LblNameEng.AutoSize = True
        Me.LblNameEng.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNameEng.Location = New System.Drawing.Point(6, 41)
        Me.LblNameEng.Name = "LblNameEng"
        Me.LblNameEng.Size = New System.Drawing.Size(59, 17)
        Me.LblNameEng.TabIndex = 18
        Me.LblNameEng.Text = "NameEng"
        '
        'txtKitchPN
        '
        Me.txtKitchPN.Enabled = False
        Me.txtKitchPN.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKitchPN.Location = New System.Drawing.Point(80, 14)
        Me.txtKitchPN.Name = "txtKitchPN"
        Me.txtKitchPN.Size = New System.Drawing.Size(75, 22)
        Me.txtKitchPN.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 17)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Code"
        '
        'txtKitchName
        '
        Me.txtKitchName.Enabled = False
        Me.txtKitchName.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKitchName.Location = New System.Drawing.Point(81, 16)
        Me.txtKitchName.Name = "txtKitchName"
        Me.txtKitchName.Size = New System.Drawing.Size(74, 22)
        Me.txtKitchName.TabIndex = 15
        Me.txtKitchName.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Name"
        Me.Label3.Visible = False
        '
        'grpProj
        '
        Me.grpProj.Controls.Add(Me.TxtNameHeb)
        Me.grpProj.Controls.Add(Me.LabelNameHeb)
        Me.grpProj.Controls.Add(Me.txtProjDescrip)
        Me.grpProj.Controls.Add(Me.lbDescrip)
        Me.grpProj.Controls.Add(Me.txtProjectPN)
        Me.grpProj.Controls.Add(Me.lblPartNumb)
        Me.grpProj.Controls.Add(Me.txtProjectName)
        Me.grpProj.Controls.Add(Me.lblProjName)
        Me.grpProj.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpProj.Location = New System.Drawing.Point(6, 7)
        Me.grpProj.Name = "grpProj"
        Me.grpProj.Size = New System.Drawing.Size(162, 114)
        Me.grpProj.TabIndex = 4
        Me.grpProj.TabStop = False
        Me.grpProj.Text = "Project"
        '
        'TxtNameHeb
        '
        Me.TxtNameHeb.Enabled = False
        Me.TxtNameHeb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameHeb.Location = New System.Drawing.Point(80, 40)
        Me.TxtNameHeb.Name = "TxtNameHeb"
        Me.TxtNameHeb.Size = New System.Drawing.Size(75, 22)
        Me.TxtNameHeb.TabIndex = 15
        '
        'LabelNameHeb
        '
        Me.LabelNameHeb.AutoSize = True
        Me.LabelNameHeb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNameHeb.Location = New System.Drawing.Point(6, 45)
        Me.LabelNameHeb.Name = "LabelNameHeb"
        Me.LabelNameHeb.Size = New System.Drawing.Size(61, 17)
        Me.LabelNameHeb.TabIndex = 14
        Me.LabelNameHeb.Text = "Name Heb"
        '
        'txtProjDescrip
        '
        Me.txtProjDescrip.AcceptsReturn = True
        Me.txtProjDescrip.AcceptsTab = True
        Me.txtProjDescrip.Enabled = False
        Me.txtProjDescrip.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProjDescrip.Location = New System.Drawing.Point(80, 88)
        Me.txtProjDescrip.Multiline = True
        Me.txtProjDescrip.Name = "txtProjDescrip"
        Me.txtProjDescrip.Size = New System.Drawing.Size(75, 22)
        Me.txtProjDescrip.TabIndex = 13
        '
        'lbDescrip
        '
        Me.lbDescrip.AutoSize = True
        Me.lbDescrip.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescrip.Location = New System.Drawing.Point(5, 93)
        Me.lbDescrip.Name = "lbDescrip"
        Me.lbDescrip.Size = New System.Drawing.Size(69, 17)
        Me.lbDescrip.TabIndex = 12
        Me.lbDescrip.Text = "Description"
        '
        'txtProjectPN
        '
        Me.txtProjectPN.Enabled = False
        Me.txtProjectPN.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProjectPN.Location = New System.Drawing.Point(80, 64)
        Me.txtProjectPN.Name = "txtProjectPN"
        Me.txtProjectPN.Size = New System.Drawing.Size(75, 22)
        Me.txtProjectPN.TabIndex = 11
        '
        'lblPartNumb
        '
        Me.lblPartNumb.AutoSize = True
        Me.lblPartNumb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNumb.Location = New System.Drawing.Point(6, 69)
        Me.lblPartNumb.Name = "lblPartNumb"
        Me.lblPartNumb.Size = New System.Drawing.Size(49, 17)
        Me.lblPartNumb.TabIndex = 10
        Me.lblPartNumb.Text = "Number"
        '
        'txtProjectName
        '
        Me.txtProjectName.Enabled = False
        Me.txtProjectName.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProjectName.Location = New System.Drawing.Point(80, 17)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(75, 22)
        Me.txtProjectName.TabIndex = 9
        '
        'lblProjName
        '
        Me.lblProjName.AutoSize = True
        Me.lblProjName.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjName.Location = New System.Drawing.Point(6, 22)
        Me.lblProjName.Name = "lblProjName"
        Me.lblProjName.Size = New System.Drawing.Size(37, 17)
        Me.lblProjName.TabIndex = 8
        Me.lblProjName.Text = "Name"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.lblClickForSelect)
        Me.TabPage2.Controls.Add(Me.btnSelect)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(174, 199)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Block"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(9, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Block Information"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClickForSelect
        '
        Me.lblClickForSelect.AutoSize = True
        Me.lblClickForSelect.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClickForSelect.ForeColor = System.Drawing.Color.Maroon
        Me.lblClickForSelect.Location = New System.Drawing.Point(6, 56)
        Me.lblClickForSelect.Name = "lblClickForSelect"
        Me.lblClickForSelect.Size = New System.Drawing.Size(122, 17)
        Me.lblClickForSelect.TabIndex = 1
        Me.lblClickForSelect.Text = "Click Button && Select"
        '
        'btnSelect
        '
        Me.btnSelect.Image = Global.Nachshon.My.Resources.Resources.SelectOne
        Me.btnSelect.Location = New System.Drawing.Point(138, 56)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(30, 25)
        Me.btnSelect.TabIndex = 0
        Me.btnSelect.Tag = "Select Block"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(174, 199)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Group"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(9, 261)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(31, 27)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TxtKitNameHeb
        '
        Me.TxtKitNameHeb.AcceptsReturn = True
        Me.TxtKitNameHeb.AcceptsTab = True
        Me.TxtKitNameHeb.Enabled = False
        Me.TxtKitNameHeb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKitNameHeb.Location = New System.Drawing.Point(79, 62)
        Me.TxtKitNameHeb.Multiline = True
        Me.TxtKitNameHeb.Name = "TxtKitNameHeb"
        Me.TxtKitNameHeb.Size = New System.Drawing.Size(75, 22)
        Me.TxtKitNameHeb.TabIndex = 21
        '
        'LblNameheb
        '
        Me.LblNameheb.AutoSize = True
        Me.LblNameheb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNameheb.Location = New System.Drawing.Point(5, 64)
        Me.LblNameheb.Name = "LblNameheb"
        Me.LblNameheb.Size = New System.Drawing.Size(58, 17)
        Me.LblNameheb.TabIndex = 20
        Me.LblNameheb.Text = "NameHeb"
        '
        'UC_Information
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.InformTab)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "UC_Information"
        Me.Size = New System.Drawing.Size(200, 280)
        Me.InformTab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.grpKitch.ResumeLayout(False)
        Me.grpKitch.PerformLayout()
        Me.grpProj.ResumeLayout(False)
        Me.grpProj.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents InformTab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents grpProj As System.Windows.Forms.GroupBox
    Friend WithEvents txtProjDescrip As System.Windows.Forms.TextBox
    Friend WithEvents lbDescrip As System.Windows.Forms.Label
    Friend WithEvents txtProjectPN As System.Windows.Forms.TextBox
    Friend WithEvents lblPartNumb As System.Windows.Forms.Label
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents lblProjName As System.Windows.Forms.Label
    Friend WithEvents grpKitch As System.Windows.Forms.GroupBox
    Friend WithEvents txtKitchNameEng As System.Windows.Forms.TextBox
    Friend WithEvents LblNameEng As System.Windows.Forms.Label
    Friend WithEvents txtKitchPN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtKitchName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents lblClickForSelect As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNameHeb As System.Windows.Forms.TextBox
    Friend WithEvents LabelNameHeb As System.Windows.Forms.Label
    Friend WithEvents TxtKitNameHeb As System.Windows.Forms.TextBox
    Friend WithEvents LblNameheb As System.Windows.Forms.Label

End Class
