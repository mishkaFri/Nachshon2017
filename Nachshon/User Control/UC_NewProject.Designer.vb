<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_NewProject
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
        Me.grpProjParam = New System.Windows.Forms.GroupBox
        Me.TxtNameHeb = New System.Windows.Forms.TextBox
        Me.Name_Heb = New System.Windows.Forms.Label
        Me.btnPath2Project = New System.Windows.Forms.Button
        Me.txtPath2Folder = New System.Windows.Forms.TextBox
        Me.lblPath2Folder = New System.Windows.Forms.Label
        Me.txtDescriptor = New System.Windows.Forms.TextBox
        Me.lbDescrip = New System.Windows.Forms.Label
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.lblPartNumb = New System.Windows.Forms.Label
        Me.txtProjectName = New System.Windows.Forms.TextBox
        Me.lblProjName = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpProjParam.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Arial Narrow", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(24, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(152, 20)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "New Project"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpProjParam
        '
        Me.grpProjParam.Controls.Add(Me.TxtNameHeb)
        Me.grpProjParam.Controls.Add(Me.Name_Heb)
        Me.grpProjParam.Controls.Add(Me.btnPath2Project)
        Me.grpProjParam.Controls.Add(Me.txtPath2Folder)
        Me.grpProjParam.Controls.Add(Me.lblPath2Folder)
        Me.grpProjParam.Controls.Add(Me.txtDescriptor)
        Me.grpProjParam.Controls.Add(Me.lbDescrip)
        Me.grpProjParam.Controls.Add(Me.txtPartNumber)
        Me.grpProjParam.Controls.Add(Me.lblPartNumb)
        Me.grpProjParam.Controls.Add(Me.txtProjectName)
        Me.grpProjParam.Controls.Add(Me.lblProjName)
        Me.grpProjParam.Location = New System.Drawing.Point(8, 32)
        Me.grpProjParam.Name = "grpProjParam"
        Me.grpProjParam.Size = New System.Drawing.Size(184, 202)
        Me.grpProjParam.TabIndex = 2
        Me.grpProjParam.TabStop = False
        '
        'TxtNameHeb
        '
        Me.TxtNameHeb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameHeb.Location = New System.Drawing.Point(74, 88)
        Me.TxtNameHeb.Name = "TxtNameHeb"
        Me.TxtNameHeb.Size = New System.Drawing.Size(104, 22)
        Me.TxtNameHeb.TabIndex = 4
        '
        'Name_Heb
        '
        Me.Name_Heb.AutoSize = True
        Me.Name_Heb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_Heb.Location = New System.Drawing.Point(3, 88)
        Me.Name_Heb.Name = "Name_Heb"
        Me.Name_Heb.Size = New System.Drawing.Size(61, 17)
        Me.Name_Heb.TabIndex = 11
        Me.Name_Heb.Text = "Name Heb"
        '
        'btnPath2Project
        '
        Me.btnPath2Project.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPath2Project.Location = New System.Drawing.Point(149, 29)
        Me.btnPath2Project.Name = "btnPath2Project"
        Me.btnPath2Project.Size = New System.Drawing.Size(31, 22)
        Me.btnPath2Project.TabIndex = 2
        Me.btnPath2Project.Text = ". . ."
        Me.ToolTip1.SetToolTip(Me.btnPath2Project, "Define project root directory")
        Me.btnPath2Project.UseVisualStyleBackColor = True
        '
        'txtPath2Folder
        '
        Me.txtPath2Folder.AcceptsTab = True
        Me.txtPath2Folder.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath2Folder.Location = New System.Drawing.Point(6, 29)
        Me.txtPath2Folder.Name = "txtPath2Folder"
        Me.txtPath2Folder.Size = New System.Drawing.Size(140, 22)
        Me.txtPath2Folder.TabIndex = 1
        '
        'lblPath2Folder
        '
        Me.lblPath2Folder.AutoSize = True
        Me.lblPath2Folder.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath2Folder.Location = New System.Drawing.Point(6, 9)
        Me.lblPath2Folder.Name = "lblPath2Folder"
        Me.lblPath2Folder.Size = New System.Drawing.Size(87, 17)
        Me.lblPath2Folder.TabIndex = 8
        Me.lblPath2Folder.Text = "Project Folder:"
        '
        'txtDescriptor
        '
        Me.txtDescriptor.AcceptsReturn = True
        Me.txtDescriptor.AcceptsTab = True
        Me.txtDescriptor.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescriptor.Location = New System.Drawing.Point(74, 146)
        Me.txtDescriptor.MaximumSize = New System.Drawing.Size(100, 100)
        Me.txtDescriptor.Multiline = True
        Me.txtDescriptor.Name = "txtDescriptor"
        Me.txtDescriptor.Size = New System.Drawing.Size(100, 50)
        Me.txtDescriptor.TabIndex = 6
        '
        'lbDescrip
        '
        Me.lbDescrip.AutoSize = True
        Me.lbDescrip.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescrip.Location = New System.Drawing.Point(3, 145)
        Me.lbDescrip.Name = "lbDescrip"
        Me.lbDescrip.Size = New System.Drawing.Size(69, 17)
        Me.lbDescrip.TabIndex = 6
        Me.lbDescrip.Text = "Description"
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNumber.Location = New System.Drawing.Point(74, 118)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(104, 22)
        Me.txtPartNumber.TabIndex = 5
        '
        'lblPartNumb
        '
        Me.lblPartNumb.AutoSize = True
        Me.lblPartNumb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNumb.Location = New System.Drawing.Point(3, 118)
        Me.lblPartNumb.Name = "lblPartNumb"
        Me.lblPartNumb.Size = New System.Drawing.Size(73, 17)
        Me.lblPartNumb.TabIndex = 3
        Me.lblPartNumb.Text = "Project Num"
        '
        'txtProjectName
        '
        Me.txtProjectName.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProjectName.Location = New System.Drawing.Point(74, 62)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(104, 22)
        Me.txtProjectName.TabIndex = 3
        '
        'lblProjName
        '
        Me.lblProjName.AutoSize = True
        Me.lblProjName.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjName.Location = New System.Drawing.Point(3, 62)
        Me.lblProjName.Name = "lblProjName"
        Me.lblProjName.Size = New System.Drawing.Size(62, 17)
        Me.lblProjName.TabIndex = 0
        Me.lblProjName.Text = "Name Eng"
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(8, 240)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(31, 27)
        Me.btnCancel.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnCancel, "Back")
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Image = Global.Nachshon.My.Resources.Resources.acgsConfigRes_512
        Me.btnOK.Location = New System.Drawing.Point(161, 240)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(31, 27)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Tag = "Create Project"
        Me.ToolTip1.SetToolTip(Me.btnOK, "Create new Project")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'UC_NewProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpProjParam)
        Me.Controls.Add(Me.lblName)
        Me.Name = "UC_NewProject"
        Me.Size = New System.Drawing.Size(200, 270)
        Me.grpProjParam.ResumeLayout(False)
        Me.grpProjParam.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents grpProjParam As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescriptor As System.Windows.Forms.TextBox
    Friend WithEvents lbDescrip As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblPartNumb As System.Windows.Forms.Label
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents lblProjName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblPath2Folder As System.Windows.Forms.Label
    Friend WithEvents btnPath2Project As System.Windows.Forms.Button
    Friend WithEvents txtPath2Folder As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TxtNameHeb As System.Windows.Forms.TextBox
    Friend WithEvents Name_Heb As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
