<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_NewKitchen
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
        Me.grpProjName = New System.Windows.Forms.GroupBox
        Me.lblProjName = New System.Windows.Forms.Label
        Me.lblActiveProj = New System.Windows.Forms.Label
        Me.grpProjParam = New System.Windows.Forms.GroupBox
        Me.txtNameHeb = New System.Windows.Forms.TextBox
        Me.lbNameHeb = New System.Windows.Forms.Label
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.lblPartNumb = New System.Windows.Forms.Label
        Me.txtKitchName = New System.Windows.Forms.TextBox
        Me.lblKitchName = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpProjName.SuspendLayout()
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
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "New Kitchen"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpProjName
        '
        Me.grpProjName.Controls.Add(Me.lblProjName)
        Me.grpProjName.Controls.Add(Me.lblActiveProj)
        Me.grpProjName.Location = New System.Drawing.Point(5, 30)
        Me.grpProjName.Name = "grpProjName"
        Me.grpProjName.Size = New System.Drawing.Size(183, 46)
        Me.grpProjName.TabIndex = 3
        Me.grpProjName.TabStop = False
        '
        'lblProjName
        '
        Me.lblProjName.AutoSize = True
        Me.lblProjName.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjName.Location = New System.Drawing.Point(102, 18)
        Me.lblProjName.Name = "lblProjName"
        Me.lblProjName.Size = New System.Drawing.Size(0, 20)
        Me.lblProjName.TabIndex = 1
        '
        'lblActiveProj
        '
        Me.lblActiveProj.AutoSize = True
        Me.lblActiveProj.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveProj.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblActiveProj.Location = New System.Drawing.Point(10, 18)
        Me.lblActiveProj.Name = "lblActiveProj"
        Me.lblActiveProj.Size = New System.Drawing.Size(86, 17)
        Me.lblActiveProj.TabIndex = 0
        Me.lblActiveProj.Text = "Active Project:"
        '
        'grpProjParam
        '
        Me.grpProjParam.Controls.Add(Me.txtNameHeb)
        Me.grpProjParam.Controls.Add(Me.lbNameHeb)
        Me.grpProjParam.Controls.Add(Me.txtPartNumber)
        Me.grpProjParam.Controls.Add(Me.lblPartNumb)
        Me.grpProjParam.Controls.Add(Me.txtKitchName)
        Me.grpProjParam.Controls.Add(Me.lblKitchName)
        Me.grpProjParam.Location = New System.Drawing.Point(8, 80)
        Me.grpProjParam.Name = "grpProjParam"
        Me.grpProjParam.Size = New System.Drawing.Size(184, 121)
        Me.grpProjParam.TabIndex = 4
        Me.grpProjParam.TabStop = False
        '
        'txtNameHeb
        '
        Me.txtNameHeb.AcceptsReturn = True
        Me.txtNameHeb.AcceptsTab = True
        Me.txtNameHeb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameHeb.Location = New System.Drawing.Point(90, 46)
        Me.txtNameHeb.Multiline = True
        Me.txtNameHeb.Name = "txtNameHeb"
        Me.txtNameHeb.Size = New System.Drawing.Size(88, 22)
        Me.txtNameHeb.TabIndex = 2
        '
        'lbNameHeb
        '
        Me.lbNameHeb.AutoSize = True
        Me.lbNameHeb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNameHeb.Location = New System.Drawing.Point(7, 46)
        Me.lbNameHeb.Name = "lbNameHeb"
        Me.lbNameHeb.Size = New System.Drawing.Size(80, 17)
        Me.lbNameHeb.TabIndex = 6
        Me.lbNameHeb.Text = "Name Hebrew"
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNumber.Location = New System.Drawing.Point(90, 72)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(88, 22)
        Me.txtPartNumber.TabIndex = 3
        '
        'lblPartNumb
        '
        Me.lblPartNumb.AutoSize = True
        Me.lblPartNumb.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNumb.Location = New System.Drawing.Point(4, 72)
        Me.lblPartNumb.Name = "lblPartNumb"
        Me.lblPartNumb.Size = New System.Drawing.Size(80, 17)
        Me.lblPartNumb.TabIndex = 3
        Me.lblPartNumb.Text = "Kitchen Code"
        '
        'txtKitchName
        '
        Me.txtKitchName.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKitchName.Location = New System.Drawing.Point(90, 18)
        Me.txtKitchName.Multiline = True
        Me.txtKitchName.Name = "txtKitchName"
        Me.txtKitchName.Size = New System.Drawing.Size(88, 22)
        Me.txtKitchName.TabIndex = 1
        '
        'lblKitchName
        '
        Me.lblKitchName.AutoSize = True
        Me.lblKitchName.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKitchName.Location = New System.Drawing.Point(7, 18)
        Me.lblKitchName.Name = "lblKitchName"
        Me.lblKitchName.Size = New System.Drawing.Size(81, 17)
        Me.lblKitchName.TabIndex = 0
        Me.lblKitchName.Text = "Kitchen Name"
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(4, 207)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(31, 27)
        Me.btnCancel.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnCancel, "Back")
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Image = Global.Nachshon.My.Resources.Resources.acgsConfigRes_512
        Me.btnOK.Location = New System.Drawing.Point(157, 207)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(31, 27)
        Me.btnOK.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnOK, "Create new kitchen")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'UC_NewKitchen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpProjParam)
        Me.Controls.Add(Me.grpProjName)
        Me.Controls.Add(Me.lblName)
        Me.Name = "UC_NewKitchen"
        Me.Size = New System.Drawing.Size(200, 270)
        Me.grpProjName.ResumeLayout(False)
        Me.grpProjName.PerformLayout()
        Me.grpProjParam.ResumeLayout(False)
        Me.grpProjParam.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents grpProjName As System.Windows.Forms.GroupBox
    Friend WithEvents lblActiveProj As System.Windows.Forms.Label
    Friend WithEvents lblProjName As System.Windows.Forms.Label
    Friend WithEvents grpProjParam As System.Windows.Forms.GroupBox
    Friend WithEvents txtNameHeb As System.Windows.Forms.TextBox
    Friend WithEvents lbNameHeb As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblPartNumb As System.Windows.Forms.Label
    Friend WithEvents txtKitchName As System.Windows.Forms.TextBox
    Friend WithEvents lblKitchName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
