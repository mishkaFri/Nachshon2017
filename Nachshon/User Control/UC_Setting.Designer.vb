<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Setting
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
        Me.BtnTemplate = New System.Windows.Forms.Button
        Me.TxtTempate = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnPath2ProjRoot = New System.Windows.Forms.Button
        Me.txtPath2ProjRoot = New System.Windows.Forms.TextBox
        Me.lblPath2Projects = New System.Windows.Forms.Label
        Me.btnPath2DB = New System.Windows.Forms.Button
        Me.txtPath2DB = New System.Windows.Forms.TextBox
        Me.lblPath2DB = New System.Windows.Forms.Label
        Me.btnPath2Catag = New System.Windows.Forms.Button
        Me.txtPath2Catag = New System.Windows.Forms.TextBox
        Me.lblPath2Catalog = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabSettings = New System.Windows.Forms.TabControl
        Me.TabPg1Folders = New System.Windows.Forms.TabPage
        Me.TabPg2DB = New System.Windows.Forms.TabPage
        Me.btnPath2PriceDB = New System.Windows.Forms.Button
        Me.txtPath2PriceDB = New System.Windows.Forms.TextBox
        Me.lblPath2PriceDB = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TabSettings.SuspendLayout()
        Me.TabPg1Folders.SuspendLayout()
        Me.TabPg2DB.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Arial Narrow", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(26, 0)
        Me.lblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(114, 16)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Setting"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnTemplate
        '
        Me.BtnTemplate.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTemplate.Location = New System.Drawing.Point(109, 106)
        Me.BtnTemplate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnTemplate.Name = "BtnTemplate"
        Me.BtnTemplate.Size = New System.Drawing.Size(23, 16)
        Me.BtnTemplate.TabIndex = 11
        Me.BtnTemplate.Text = ". . ."
        Me.ToolTip1.SetToolTip(Me.BtnTemplate, "Path to templates foler")
        Me.BtnTemplate.UseVisualStyleBackColor = True
        '
        'TxtTempate
        '
        Me.TxtTempate.AcceptsTab = True
        Me.TxtTempate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTempate.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTempate.Location = New System.Drawing.Point(5, 109)
        Me.TxtTempate.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtTempate.Name = "TxtTempate"
        Me.TxtTempate.Size = New System.Drawing.Size(97, 19)
        Me.TxtTempate.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 84)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Path to Template:"
        '
        'btnPath2ProjRoot
        '
        Me.btnPath2ProjRoot.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPath2ProjRoot.Location = New System.Drawing.Point(109, 66)
        Me.btnPath2ProjRoot.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPath2ProjRoot.Name = "btnPath2ProjRoot"
        Me.btnPath2ProjRoot.Size = New System.Drawing.Size(23, 16)
        Me.btnPath2ProjRoot.TabIndex = 8
        Me.btnPath2ProjRoot.Text = ". . ."
        Me.btnPath2ProjRoot.UseVisualStyleBackColor = True
        '
        'txtPath2ProjRoot
        '
        Me.txtPath2ProjRoot.AcceptsTab = True
        Me.txtPath2ProjRoot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPath2ProjRoot.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath2ProjRoot.Location = New System.Drawing.Point(5, 69)
        Me.txtPath2ProjRoot.Margin = New System.Windows.Forms.Padding(5)
        Me.txtPath2ProjRoot.Name = "txtPath2ProjRoot"
        Me.txtPath2ProjRoot.Size = New System.Drawing.Size(97, 19)
        Me.txtPath2ProjRoot.TabIndex = 7
        '
        'lblPath2Projects
        '
        Me.lblPath2Projects.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblPath2Projects, 2)
        Me.lblPath2Projects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPath2Projects.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath2Projects.Location = New System.Drawing.Point(2, 44)
        Me.lblPath2Projects.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPath2Projects.Name = "lblPath2Projects"
        Me.lblPath2Projects.Size = New System.Drawing.Size(130, 20)
        Me.lblPath2Projects.TabIndex = 6
        Me.lblPath2Projects.Text = "Project Root Folder:"
        '
        'btnPath2DB
        '
        Me.btnPath2DB.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPath2DB.Location = New System.Drawing.Point(111, 25)
        Me.btnPath2DB.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPath2DB.Name = "btnPath2DB"
        Me.btnPath2DB.Size = New System.Drawing.Size(23, 18)
        Me.btnPath2DB.TabIndex = 5
        Me.btnPath2DB.Text = ". . ."
        Me.btnPath2DB.UseVisualStyleBackColor = True
        '
        'txtPath2DB
        '
        Me.txtPath2DB.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath2DB.Location = New System.Drawing.Point(4, 25)
        Me.txtPath2DB.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPath2DB.Name = "txtPath2DB"
        Me.txtPath2DB.Size = New System.Drawing.Size(106, 19)
        Me.txtPath2DB.TabIndex = 4
        '
        'lblPath2DB
        '
        Me.lblPath2DB.AutoSize = True
        Me.lblPath2DB.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath2DB.Location = New System.Drawing.Point(4, 10)
        Me.lblPath2DB.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPath2DB.Name = "lblPath2DB"
        Me.lblPath2DB.Size = New System.Drawing.Size(97, 15)
        Me.lblPath2DB.TabIndex = 3
        Me.lblPath2DB.Text = "Path to Access DB :"
        '
        'btnPath2Catag
        '
        Me.btnPath2Catag.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPath2Catag.Location = New System.Drawing.Point(109, 24)
        Me.btnPath2Catag.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPath2Catag.Name = "btnPath2Catag"
        Me.btnPath2Catag.Size = New System.Drawing.Size(23, 18)
        Me.btnPath2Catag.TabIndex = 2
        Me.btnPath2Catag.Text = ". . ."
        Me.btnPath2Catag.UseVisualStyleBackColor = True
        '
        'txtPath2Catag
        '
        Me.txtPath2Catag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPath2Catag.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath2Catag.Location = New System.Drawing.Point(5, 27)
        Me.txtPath2Catag.Margin = New System.Windows.Forms.Padding(5)
        Me.txtPath2Catag.Name = "txtPath2Catag"
        Me.txtPath2Catag.Size = New System.Drawing.Size(97, 19)
        Me.txtPath2Catag.TabIndex = 1
        '
        'lblPath2Catalog
        '
        Me.lblPath2Catalog.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblPath2Catalog, 2)
        Me.lblPath2Catalog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPath2Catalog.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath2Catalog.Location = New System.Drawing.Point(2, 0)
        Me.lblPath2Catalog.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPath2Catalog.Name = "lblPath2Catalog"
        Me.lblPath2Catalog.Size = New System.Drawing.Size(130, 22)
        Me.lblPath2Catalog.TabIndex = 0
        Me.lblPath2Catalog.Text = "Catalog Root Folder:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(4, 179)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(23, 22)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Image = Global.Nachshon.My.Resources.Resources.acgsConfigRes_512
        Me.btnOK.Location = New System.Drawing.Point(119, 179)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(23, 22)
        Me.btnOK.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnOK, "Save")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'TabSettings
        '
        Me.TabSettings.Controls.Add(Me.TabPg1Folders)
        Me.TabSettings.Controls.Add(Me.TabPg2DB)
        Me.TabSettings.Location = New System.Drawing.Point(2, 20)
        Me.TabSettings.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabSettings.Name = "TabSettings"
        Me.TabSettings.SelectedIndex = 0
        Me.TabSettings.Size = New System.Drawing.Size(146, 154)
        Me.TabSettings.TabIndex = 4
        '
        'TabPg1Folders
        '
        Me.TabPg1Folders.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPg1Folders.Location = New System.Drawing.Point(4, 22)
        Me.TabPg1Folders.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPg1Folders.Name = "TabPg1Folders"
        Me.TabPg1Folders.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPg1Folders.Size = New System.Drawing.Size(138, 128)
        Me.TabPg1Folders.TabIndex = 0
        Me.TabPg1Folders.Text = "Folders"
        Me.TabPg1Folders.UseVisualStyleBackColor = True
        '
        'TabPg2DB
        '
        Me.TabPg2DB.Controls.Add(Me.btnPath2PriceDB)
        Me.TabPg2DB.Controls.Add(Me.txtPath2PriceDB)
        Me.TabPg2DB.Controls.Add(Me.lblPath2PriceDB)
        Me.TabPg2DB.Controls.Add(Me.btnPath2DB)
        Me.TabPg2DB.Controls.Add(Me.txtPath2DB)
        Me.TabPg2DB.Controls.Add(Me.lblPath2DB)
        Me.TabPg2DB.Location = New System.Drawing.Point(4, 22)
        Me.TabPg2DB.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPg2DB.Name = "TabPg2DB"
        Me.TabPg2DB.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPg2DB.Size = New System.Drawing.Size(138, 128)
        Me.TabPg2DB.TabIndex = 1
        Me.TabPg2DB.Text = "Data Base"
        Me.TabPg2DB.UseVisualStyleBackColor = True
        '
        'btnPath2PriceDB
        '
        Me.btnPath2PriceDB.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPath2PriceDB.Location = New System.Drawing.Point(112, 64)
        Me.btnPath2PriceDB.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPath2PriceDB.Name = "btnPath2PriceDB"
        Me.btnPath2PriceDB.Size = New System.Drawing.Size(23, 18)
        Me.btnPath2PriceDB.TabIndex = 8
        Me.btnPath2PriceDB.Text = ". . ."
        Me.btnPath2PriceDB.UseVisualStyleBackColor = True
        '
        'txtPath2PriceDB
        '
        Me.txtPath2PriceDB.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath2PriceDB.Location = New System.Drawing.Point(4, 64)
        Me.txtPath2PriceDB.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPath2PriceDB.Name = "txtPath2PriceDB"
        Me.txtPath2PriceDB.Size = New System.Drawing.Size(106, 19)
        Me.txtPath2PriceDB.TabIndex = 7
        '
        'lblPath2PriceDB
        '
        Me.lblPath2PriceDB.AutoSize = True
        Me.lblPath2PriceDB.Font = New System.Drawing.Font("Arial Narrow", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath2PriceDB.Location = New System.Drawing.Point(4, 49)
        Me.lblPath2PriceDB.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPath2PriceDB.Name = "lblPath2PriceDB"
        Me.lblPath2PriceDB.Size = New System.Drawing.Size(123, 15)
        Me.lblPath2PriceDB.TabIndex = 6
        Me.lblPath2PriceDB.Text = "Path to Access Price DB :"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblPath2Catalog, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnTemplate, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPath2Catag, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPath2ProjRoot, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPath2Catag, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTempate, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPath2Projects, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPath2ProjRoot, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(134, 124)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'UC_Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabSettings)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblName)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "UC_Setting"
        Me.Size = New System.Drawing.Size(150, 203)
        Me.TabSettings.ResumeLayout(False)
        Me.TabPg1Folders.ResumeLayout(False)
        Me.TabPg2DB.ResumeLayout(False)
        Me.TabPg2DB.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblPath2Catalog As System.Windows.Forms.Label
    Friend WithEvents btnPath2DB As System.Windows.Forms.Button
    Friend WithEvents txtPath2DB As System.Windows.Forms.TextBox
    Friend WithEvents lblPath2DB As System.Windows.Forms.Label
    Friend WithEvents btnPath2Catag As System.Windows.Forms.Button
    Friend WithEvents txtPath2Catag As System.Windows.Forms.TextBox
    Friend WithEvents btnPath2ProjRoot As System.Windows.Forms.Button
    Friend WithEvents txtPath2ProjRoot As System.Windows.Forms.TextBox
    Friend WithEvents lblPath2Projects As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnTemplate As System.Windows.Forms.Button
    Friend WithEvents TxtTempate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabSettings As System.Windows.Forms.TabControl
    Friend WithEvents TabPg1Folders As System.Windows.Forms.TabPage
    Friend WithEvents TabPg2DB As System.Windows.Forms.TabPage
    Friend WithEvents btnPath2PriceDB As System.Windows.Forms.Button
    Friend WithEvents txtPath2PriceDB As System.Windows.Forms.TextBox
    Friend WithEvents lblPath2PriceDB As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
