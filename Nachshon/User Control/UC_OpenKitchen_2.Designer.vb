<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_OpenKitchen_2
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
        Me.lblName = New System.Windows.Forms.Label
        Me.lblProjName = New System.Windows.Forms.Label
        Me.lblProjNameTxt = New System.Windows.Forms.Label
        Me.lstBoxKitchList = New System.Windows.Forms.ListBox
        Me.lblSelKitch = New System.Windows.Forms.Label
        Me.lblPN = New System.Windows.Forms.Label
        Me.lblKitchName = New System.Windows.Forms.Label
        Me.txtPN = New System.Windows.Forms.TextBox
        Me.txtNameEng = New System.Windows.Forms.TextBox
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.TxtNameHeb = New System.Windows.Forms.TextBox
        Me.LblNameHeb = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblName, 3)
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Font = New System.Drawing.Font("Arial Narrow", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(2, 0)
        Me.lblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(146, 28)
        Me.lblName.TabIndex = 21
        Me.lblName.Text = "Open Kitchen"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProjName
        '
        Me.lblProjName.AutoSize = True
        Me.lblProjName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjName.ForeColor = System.Drawing.Color.Blue
        Me.lblProjName.Location = New System.Drawing.Point(2, 28)
        Me.lblProjName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProjName.Name = "lblProjName"
        Me.lblProjName.Size = New System.Drawing.Size(51, 26)
        Me.lblProjName.TabIndex = 23
        Me.lblProjName.Text = "Active Project:"
        '
        'lblProjNameTxt
        '
        Me.lblProjNameTxt.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblProjNameTxt, 2)
        Me.lblProjNameTxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProjNameTxt.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjNameTxt.Location = New System.Drawing.Point(80, 28)
        Me.lblProjNameTxt.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProjNameTxt.Name = "lblProjNameTxt"
        Me.lblProjNameTxt.Size = New System.Drawing.Size(68, 26)
        Me.lblProjNameTxt.TabIndex = 24
        Me.lblProjNameTxt.Text = "_"
        '
        'lstBoxKitchList
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lstBoxKitchList, 2)
        Me.lstBoxKitchList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstBoxKitchList.FormattingEnabled = True
        Me.lstBoxKitchList.Location = New System.Drawing.Point(2, 66)
        Me.lstBoxKitchList.Margin = New System.Windows.Forms.Padding(2)
        Me.lstBoxKitchList.Name = "lstBoxKitchList"
        Me.lstBoxKitchList.Size = New System.Drawing.Size(112, 56)
        Me.lstBoxKitchList.TabIndex = 25
        Me.lstBoxKitchList.Tag = "Select Kitchen by double Click or push OK"
        '
        'lblSelKitch
        '
        Me.lblSelKitch.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblSelKitch, 3)
        Me.lblSelKitch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSelKitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblSelKitch.Location = New System.Drawing.Point(2, 54)
        Me.lblSelKitch.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSelKitch.Name = "lblSelKitch"
        Me.lblSelKitch.Size = New System.Drawing.Size(146, 10)
        Me.lblSelKitch.TabIndex = 26
        Me.lblSelKitch.Text = "Select Kitchen:"
        '
        'lblPN
        '
        Me.lblPN.AutoSize = True
        Me.lblPN.Location = New System.Drawing.Point(2, 124)
        Me.lblPN.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPN.Name = "lblPN"
        Me.lblPN.Size = New System.Drawing.Size(32, 13)
        Me.lblPN.TabIndex = 28
        Me.lblPN.Text = "Code"
        '
        'lblKitchName
        '
        Me.lblKitchName.AutoSize = True
        Me.lblKitchName.Location = New System.Drawing.Point(2, 148)
        Me.lblKitchName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblKitchName.Name = "lblKitchName"
        Me.lblKitchName.Size = New System.Drawing.Size(54, 13)
        Me.lblKitchName.TabIndex = 29
        Me.lblKitchName.Text = "NameEng"
        '
        'txtPN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPN, 2)
        Me.txtPN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPN.Location = New System.Drawing.Point(80, 126)
        Me.txtPN.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPN.Name = "txtPN"
        Me.txtPN.Size = New System.Drawing.Size(68, 20)
        Me.txtPN.TabIndex = 30
        '
        'txtNameEng
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtNameEng, 2)
        Me.txtNameEng.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNameEng.Location = New System.Drawing.Point(80, 150)
        Me.txtNameEng.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNameEng.Name = "txtNameEng"
        Me.txtNameEng.Size = New System.Drawing.Size(68, 20)
        Me.txtNameEng.TabIndex = 31
        '
        'btnUpdate
        '
        Me.btnUpdate.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnUpdate.Image = Global.Nachshon.My.Resources.Resources.EditDb
        Me.btnUpdate.Location = New System.Drawing.Point(125, 193)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(23, 24)
        Me.btnUpdate.TabIndex = 32
        Me.btnUpdate.Tag = "Exit with Update Propertiies"
        Me.ToolTip1.SetToolTip(Me.btnUpdate, "Update kitchen properties")
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnOK.Image = Global.Nachshon.My.Resources.Resources.acgsConfigRes_512
        Me.btnOK.Location = New System.Drawing.Point(118, 95)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(30, 27)
        Me.btnOK.TabIndex = 27
        Me.btnOK.Tag = "Open selected Kitchen"
        Me.ToolTip1.SetToolTip(Me.btnOK, "Open Selected kitchen")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(2, 193)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(23, 24)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Tag = "Exit without update Properties"
        Me.ToolTip1.SetToolTip(Me.btnCancel, "Back")
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TxtNameHeb
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtNameHeb, 2)
        Me.TxtNameHeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtNameHeb.Location = New System.Drawing.Point(80, 173)
        Me.TxtNameHeb.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtNameHeb.Name = "TxtNameHeb"
        Me.TxtNameHeb.Size = New System.Drawing.Size(68, 20)
        Me.TxtNameHeb.TabIndex = 34
        '
        'LblNameHeb
        '
        Me.LblNameHeb.AutoSize = True
        Me.LblNameHeb.Location = New System.Drawing.Point(2, 171)
        Me.LblNameHeb.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblNameHeb.Name = "LblNameHeb"
        Me.LblNameHeb.Size = New System.Drawing.Size(55, 13)
        Me.LblNameHeb.TabIndex = 33
        Me.LblNameHeb.Text = "NameHeb"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.24138!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.75862!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtNameHeb, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProjName, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblNameHeb, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProjNameTxt, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lstBoxKitchList, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblKitchName, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPN, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPN, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNameEng, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOK, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSelKitch, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnUpdate, 2, 7)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.63158!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.36842!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(150, 219)
        Me.TableLayoutPanel1.TabIndex = 35
        '
        'UC_OpenKitchen_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "UC_OpenKitchen_2"
        Me.Size = New System.Drawing.Size(150, 219)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblProjName As System.Windows.Forms.Label
    Friend WithEvents lblProjNameTxt As System.Windows.Forms.Label
    Friend WithEvents lstBoxKitchList As System.Windows.Forms.ListBox
    Friend WithEvents lblSelKitch As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblPN As System.Windows.Forms.Label
    Friend WithEvents lblKitchName As System.Windows.Forms.Label
    Friend WithEvents txtPN As System.Windows.Forms.TextBox
    Friend WithEvents txtNameEng As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents TxtNameHeb As System.Windows.Forms.TextBox
    Friend WithEvents LblNameHeb As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
