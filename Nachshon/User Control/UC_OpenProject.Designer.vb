<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_OpenProject
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
        Me.lbDescrip = New System.Windows.Forms.Label
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.btnPath2Project = New System.Windows.Forms.Button
        Me.txtPath2Folder = New System.Windows.Forms.TextBox
        Me.grpProjParam = New System.Windows.Forms.GroupBox
        Me.TxtNameHeb = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPath2Folder = New System.Windows.Forms.Label
        Me.txtDescriptor = New System.Windows.Forms.TextBox
        Me.lblPartNumb = New System.Windows.Forms.Label
        Me.txtProjectName = New System.Windows.Forms.TextBox
        Me.lblProjName = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.grpProjParam.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbDescrip
        '
        Me.lbDescrip.AutoSize = True
        Me.lbDescrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbDescrip.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescrip.Location = New System.Drawing.Point(2, 106)
        Me.lbDescrip.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbDescrip.Name = "lbDescrip"
        Me.lbDescrip.Size = New System.Drawing.Size(55, 43)
        Me.lbDescrip.TabIndex = 6
        Me.lbDescrip.Text = "Description"
        '
        'txtPartNumber
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPartNumber, 2)
        Me.txtPartNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPartNumber.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNumber.Location = New System.Drawing.Point(61, 85)
        Me.txtPartNumber.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(71, 19)
        Me.txtPartNumber.TabIndex = 4
        '
        'btnPath2Project
        '
        Me.btnPath2Project.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPath2Project.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPath2Project.Location = New System.Drawing.Point(100, 18)
        Me.btnPath2Project.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPath2Project.Name = "btnPath2Project"
        Me.btnPath2Project.Size = New System.Drawing.Size(32, 21)
        Me.btnPath2Project.TabIndex = 10
        Me.btnPath2Project.Tag = "Project Browser"
        Me.btnPath2Project.Text = ". . ."
        Me.btnPath2Project.UseVisualStyleBackColor = True
        '
        'txtPath2Folder
        '
        Me.txtPath2Folder.AcceptsTab = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPath2Folder, 2)
        Me.txtPath2Folder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPath2Folder.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath2Folder.Location = New System.Drawing.Point(2, 18)
        Me.txtPath2Folder.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPath2Folder.Name = "txtPath2Folder"
        Me.txtPath2Folder.Size = New System.Drawing.Size(94, 19)
        Me.txtPath2Folder.TabIndex = 9
        Me.txtPath2Folder.Tag = "Path to Project"
        '
        'grpProjParam
        '
        Me.grpProjParam.Controls.Add(Me.TableLayoutPanel1)
        Me.grpProjParam.Location = New System.Drawing.Point(6, 19)
        Me.grpProjParam.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grpProjParam.Name = "grpProjParam"
        Me.grpProjParam.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grpProjParam.Size = New System.Drawing.Size(138, 166)
        Me.grpProjParam.TabIndex = 8
        Me.grpProjParam.TabStop = False
        '
        'TxtNameHeb
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtNameHeb, 2)
        Me.TxtNameHeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtNameHeb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameHeb.Location = New System.Drawing.Point(61, 63)
        Me.TxtNameHeb.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtNameHeb.Name = "TxtNameHeb"
        Me.TxtNameHeb.Size = New System.Drawing.Size(71, 19)
        Me.TxtNameHeb.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 22)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Name Heb"
        '
        'lblPath2Folder
        '
        Me.lblPath2Folder.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblPath2Folder, 3)
        Me.lblPath2Folder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPath2Folder.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath2Folder.Location = New System.Drawing.Point(2, 0)
        Me.lblPath2Folder.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPath2Folder.Name = "lblPath2Folder"
        Me.lblPath2Folder.Size = New System.Drawing.Size(130, 16)
        Me.lblPath2Folder.TabIndex = 8
        Me.lblPath2Folder.Text = "Project Folder:"
        '
        'txtDescriptor
        '
        Me.txtDescriptor.AcceptsReturn = True
        Me.txtDescriptor.AcceptsTab = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDescriptor, 2)
        Me.txtDescriptor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescriptor.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescriptor.Location = New System.Drawing.Point(61, 108)
        Me.txtDescriptor.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtDescriptor.Multiline = True
        Me.txtDescriptor.Name = "txtDescriptor"
        Me.txtDescriptor.Size = New System.Drawing.Size(71, 39)
        Me.txtDescriptor.TabIndex = 7
        '
        'lblPartNumb
        '
        Me.lblPartNumb.AutoSize = True
        Me.lblPartNumb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPartNumb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNumb.Location = New System.Drawing.Point(2, 83)
        Me.lblPartNumb.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPartNumb.Name = "lblPartNumb"
        Me.lblPartNumb.Size = New System.Drawing.Size(55, 23)
        Me.lblPartNumb.TabIndex = 3
        Me.lblPartNumb.Text = "Proj Number"
        '
        'txtProjectName
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtProjectName, 2)
        Me.txtProjectName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProjectName.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProjectName.Location = New System.Drawing.Point(61, 43)
        Me.txtProjectName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(71, 19)
        Me.txtProjectName.TabIndex = 1
        '
        'lblProjName
        '
        Me.lblProjName.AutoSize = True
        Me.lblProjName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProjName.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjName.Location = New System.Drawing.Point(2, 41)
        Me.lblProjName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProjName.Name = "lblProjName"
        Me.lblProjName.Size = New System.Drawing.Size(55, 20)
        Me.lblProjName.TabIndex = 0
        Me.lblProjName.Text = "Project Name"
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Arial Narrow", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(18, 0)
        Me.lblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(114, 16)
        Me.lblName.TabIndex = 7
        Me.lblName.Text = "Open Project"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(6, 189)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(23, 22)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Tag = "Go to Main Menu"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Image = Global.Nachshon.My.Resources.Resources.acgsConfigRes_512
        Me.btnOK.Location = New System.Drawing.Point(121, 189)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(23, 22)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Tag = "Update Project Data "
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.20408!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.79592!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtDescriptor, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtNameHeb, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbDescrip, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPath2Folder, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPartNumber, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPartNumb, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPath2Folder, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPath2Project, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProjName, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtProjectName, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 15)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.02439!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.97561!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(134, 149)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'UC_OpenProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpProjParam)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnOK)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "UC_OpenProject"
        Me.Size = New System.Drawing.Size(150, 219)
        Me.grpProjParam.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbDescrip As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPath2Project As System.Windows.Forms.Button
    Friend WithEvents txtPath2Folder As System.Windows.Forms.TextBox
    Friend WithEvents grpProjParam As System.Windows.Forms.GroupBox
    Friend WithEvents lblPath2Folder As System.Windows.Forms.Label
    Friend WithEvents txtDescriptor As System.Windows.Forms.TextBox
    Friend WithEvents lblPartNumb As System.Windows.Forms.Label
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents lblProjName As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TxtNameHeb As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
