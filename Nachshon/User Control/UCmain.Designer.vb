<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCmain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCmain))
        Me.pnlVertMenu = New System.Windows.Forms.Panel
        Me.CloseProj = New System.Windows.Forms.ToolStrip
        Me.ProjectToolStripSplit = New System.Windows.Forms.ToolStripSplitButton
        Me.NewProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActiveDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeactivateDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton
        Me.TlsNewKitchen = New System.Windows.Forms.ToolStripMenuItem
        Me.TlsOpenKitch = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.InsertBlockStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.Group = New System.Windows.Forms.ToolStripButton
        Me.Attributes = New System.Windows.Forms.ToolStripButton
        Me.NumeringToolStrip = New System.Windows.Forms.ToolStripButton
        Me.DocManagerToolStrip = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSplitActions = New System.Windows.Forms.ToolStripSplitButton
        Me.UpdateDrawingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDrawingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDrawingAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyBlockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteBlocksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InfoToolStrip = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSplitConvert2D3D = New System.Windows.Forms.ToolStripSplitButton
        Me.ConvertSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConvertAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.SettingToolStrip = New System.Windows.Forms.ToolStripButton
        Me.ClsProjToolStrip = New System.Windows.Forms.ToolStripButton
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.ProgBar = New System.Windows.Forms.ProgressBar
        Me.lblProgBar = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.pnlVertMenu.SuspendLayout()
        Me.CloseProj.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVertMenu
        '
        Me.pnlVertMenu.Controls.Add(Me.CloseProj)
        Me.pnlVertMenu.Location = New System.Drawing.Point(2, 3)
        Me.pnlVertMenu.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlVertMenu.Name = "pnlVertMenu"
        Me.pnlVertMenu.Size = New System.Drawing.Size(26, 258)
        Me.pnlVertMenu.TabIndex = 3
        '
        'CloseProj
        '
        Me.CloseProj.Dock = System.Windows.Forms.DockStyle.Left
        Me.CloseProj.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProjectToolStripSplit, Me.ToolStripSplitButton1, Me.ToolStripSeparator1, Me.InsertBlockStripDropDownButton1, Me.Group, Me.Attributes, Me.NumeringToolStrip, Me.DocManagerToolStrip, Me.ToolStripSplitActions, Me.InfoToolStrip, Me.ToolStripSplitConvert2D3D, Me.ToolStripSeparator2, Me.SettingToolStrip, Me.ClsProjToolStrip})
        Me.CloseProj.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.CloseProj.Location = New System.Drawing.Point(0, 0)
        Me.CloseProj.Name = "CloseProj"
        Me.CloseProj.Size = New System.Drawing.Size(34, 258)
        Me.CloseProj.Stretch = True
        Me.CloseProj.TabIndex = 0
        Me.CloseProj.Text = "ToolStrip1"
        '
        'ProjectToolStripSplit
        '
        Me.ProjectToolStripSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProjectToolStripSplit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectToolStripMenuItem, Me.OpenProjectToolStripMenuItem, Me.ActiveDocumentToolStripMenuItem, Me.DeactivateDocumentToolStripMenuItem})
        Me.ProjectToolStripSplit.Image = CType(resources.GetObject("ProjectToolStripSplit.Image"), System.Drawing.Image)
        Me.ProjectToolStripSplit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ProjectToolStripSplit.Name = "ProjectToolStripSplit"
        Me.ProjectToolStripSplit.Size = New System.Drawing.Size(31, 20)
        Me.ProjectToolStripSplit.Text = "ProjectToolStripSplit"
        Me.ProjectToolStripSplit.ToolTipText = "Project Management"
        '
        'NewProjectToolStripMenuItem
        '
        Me.NewProjectToolStripMenuItem.Image = CType(resources.GetObject("NewProjectToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewProjectToolStripMenuItem.Name = "NewProjectToolStripMenuItem"
        Me.NewProjectToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.NewProjectToolStripMenuItem.Text = "New Project"
        Me.NewProjectToolStripMenuItem.ToolTipText = "Create New Project or Kitchen"
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Image = CType(resources.GetObject("OpenProjectToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.OpenProjectToolStripMenuItem.Text = "Open Project"
        Me.OpenProjectToolStripMenuItem.ToolTipText = "Edit Project ot Kitchen"
        '
        'ActiveDocumentToolStripMenuItem
        '
        Me.ActiveDocumentToolStripMenuItem.Image = CType(resources.GetObject("ActiveDocumentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ActiveDocumentToolStripMenuItem.Name = "ActiveDocumentToolStripMenuItem"
        Me.ActiveDocumentToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.ActiveDocumentToolStripMenuItem.Text = "Active Document"
        '
        'DeactivateDocumentToolStripMenuItem
        '
        Me.DeactivateDocumentToolStripMenuItem.Image = Global.Nachshon.My.Resources.Resources._ReadOnly
        Me.DeactivateDocumentToolStripMenuItem.Name = "DeactivateDocumentToolStripMenuItem"
        Me.DeactivateDocumentToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.DeactivateDocumentToolStripMenuItem.Text = "Open document as ReadOnly"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TlsNewKitchen, Me.TlsOpenKitch})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(31, 20)
        Me.ToolStripSplitButton1.Text = "ProjectToolStripSplit"
        Me.ToolStripSplitButton1.ToolTipText = "Project Management"
        '
        'TlsNewKitchen
        '
        Me.TlsNewKitchen.Image = CType(resources.GetObject("TlsNewKitchen.Image"), System.Drawing.Image)
        Me.TlsNewKitchen.Name = "TlsNewKitchen"
        Me.TlsNewKitchen.Size = New System.Drawing.Size(163, 22)
        Me.TlsNewKitchen.Text = "New Kitchen"
        Me.TlsNewKitchen.ToolTipText = "Create New Project or Kitchen"
        '
        'TlsOpenKitch
        '
        Me.TlsOpenKitch.Image = CType(resources.GetObject("TlsOpenKitch.Image"), System.Drawing.Image)
        Me.TlsOpenKitch.Name = "TlsOpenKitch"
        Me.TlsOpenKitch.Size = New System.Drawing.Size(163, 22)
        Me.TlsOpenKitch.Text = "Open Kitchen"
        Me.TlsOpenKitch.ToolTipText = "Edit Project ot Kitchen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 2)
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(33, 18)
        '
        'InsertBlockStripDropDownButton1
        '
        Me.InsertBlockStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InsertBlockStripDropDownButton1.Image = CType(resources.GetObject("InsertBlockStripDropDownButton1.Image"), System.Drawing.Image)
        Me.InsertBlockStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InsertBlockStripDropDownButton1.Name = "InsertBlockStripDropDownButton1"
        Me.InsertBlockStripDropDownButton1.Size = New System.Drawing.Size(31, 20)
        Me.InsertBlockStripDropDownButton1.Text = "ToolStripDropDownButton1"
        Me.InsertBlockStripDropDownButton1.ToolTipText = "Insert Block"
        '
        'Group
        '
        Me.Group.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Group.Image = CType(resources.GetObject("Group.Image"), System.Drawing.Image)
        Me.Group.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Group.Name = "Group"
        Me.Group.Size = New System.Drawing.Size(31, 20)
        Me.Group.ToolTipText = "Group Management"
        '
        'Attributes
        '
        Me.Attributes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Attributes.Image = CType(resources.GetObject("Attributes.Image"), System.Drawing.Image)
        Me.Attributes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Attributes.Name = "Attributes"
        Me.Attributes.Size = New System.Drawing.Size(31, 20)
        Me.Attributes.ToolTipText = "Attributes"
        '
        'NumeringToolStrip
        '
        Me.NumeringToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NumeringToolStrip.Image = Global.Nachshon.My.Resources.Resources.updateAttributes
        Me.NumeringToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NumeringToolStrip.Name = "NumeringToolStrip"
        Me.NumeringToolStrip.Size = New System.Drawing.Size(31, 20)
        Me.NumeringToolStrip.Text = "Numering"
        Me.NumeringToolStrip.ToolTipText = "Blocks Numering Create/Update "
        '
        'DocManagerToolStrip
        '
        Me.DocManagerToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DocManagerToolStrip.Image = CType(resources.GetObject("DocManagerToolStrip.Image"), System.Drawing.Image)
        Me.DocManagerToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DocManagerToolStrip.Name = "DocManagerToolStrip"
        Me.DocManagerToolStrip.Size = New System.Drawing.Size(31, 20)
        Me.DocManagerToolStrip.Text = "Document Management"
        '
        'ToolStripSplitActions
        '
        Me.ToolStripSplitActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitActions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateDrawingToolStripMenuItem, Me.SaveToolStripMenuItem, Me.CopyBlockToolStripMenuItem, Me.DeleteBlocksToolStripMenuItem})
        Me.ToolStripSplitActions.Image = CType(resources.GetObject("ToolStripSplitActions.Image"), System.Drawing.Image)
        Me.ToolStripSplitActions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitActions.Name = "ToolStripSplitActions"
        Me.ToolStripSplitActions.Size = New System.Drawing.Size(31, 20)
        Me.ToolStripSplitActions.Text = "Kitchen"
        '
        'UpdateDrawingToolStripMenuItem
        '
        Me.UpdateDrawingToolStripMenuItem.Image = CType(resources.GetObject("UpdateDrawingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UpdateDrawingToolStripMenuItem.Name = "UpdateDrawingToolStripMenuItem"
        Me.UpdateDrawingToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.UpdateDrawingToolStripMenuItem.Text = "Update Drawing"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDrawingToolStripMenuItem, Me.SaveDrawingAsToolStripMenuItem})
        Me.SaveToolStripMenuItem.Image = Global.Nachshon.My.Resources.Resources.nero_1153
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveDrawingToolStripMenuItem
        '
        Me.SaveDrawingToolStripMenuItem.Image = Global.Nachshon.My.Resources.Resources.nero_1153
        Me.SaveDrawingToolStripMenuItem.Name = "SaveDrawingToolStripMenuItem"
        Me.SaveDrawingToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.SaveDrawingToolStripMenuItem.Text = "Save Drawing"
        '
        'SaveDrawingAsToolStripMenuItem
        '
        Me.SaveDrawingAsToolStripMenuItem.Image = Global.Nachshon.My.Resources.Resources.nero_1153
        Me.SaveDrawingAsToolStripMenuItem.Name = "SaveDrawingAsToolStripMenuItem"
        Me.SaveDrawingAsToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.SaveDrawingAsToolStripMenuItem.Text = "Save Drawing As..."
        '
        'CopyBlockToolStripMenuItem
        '
        Me.CopyBlockToolStripMenuItem.Image = CType(resources.GetObject("CopyBlockToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyBlockToolStripMenuItem.Name = "CopyBlockToolStripMenuItem"
        Me.CopyBlockToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CopyBlockToolStripMenuItem.Text = "Copy Block"
        '
        'DeleteBlocksToolStripMenuItem
        '
        Me.DeleteBlocksToolStripMenuItem.Image = CType(resources.GetObject("DeleteBlocksToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteBlocksToolStripMenuItem.Name = "DeleteBlocksToolStripMenuItem"
        Me.DeleteBlocksToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.DeleteBlocksToolStripMenuItem.Text = "Delete Block\s"
        '
        'InfoToolStrip
        '
        Me.InfoToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InfoToolStrip.Image = CType(resources.GetObject("InfoToolStrip.Image"), System.Drawing.Image)
        Me.InfoToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InfoToolStrip.Name = "InfoToolStrip"
        Me.InfoToolStrip.Size = New System.Drawing.Size(31, 20)
        Me.InfoToolStrip.Text = "Blocks Information"
        '
        'ToolStripSplitConvert2D3D
        '
        Me.ToolStripSplitConvert2D3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitConvert2D3D.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConvertSelectionToolStripMenuItem, Me.ConvertAllToolStripMenuItem})
        Me.ToolStripSplitConvert2D3D.Image = Global.Nachshon.My.Resources.Resources.Conv2D3D
        Me.ToolStripSplitConvert2D3D.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitConvert2D3D.Name = "ToolStripSplitConvert2D3D"
        Me.ToolStripSplitConvert2D3D.Size = New System.Drawing.Size(32, 20)
        Me.ToolStripSplitConvert2D3D.Text = "ToolStripSplitButton2"
        Me.ToolStripSplitConvert2D3D.ToolTipText = "2D to 3D Conversion"
        '
        'ConvertSelectionToolStripMenuItem
        '
        Me.ConvertSelectionToolStripMenuItem.Name = "ConvertSelectionToolStripMenuItem"
        Me.ConvertSelectionToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ConvertSelectionToolStripMenuItem.Text = "Convert Selection"
        '
        'ConvertAllToolStripMenuItem
        '
        Me.ConvertAllToolStripMenuItem.Name = "ConvertAllToolStripMenuItem"
        Me.ConvertAllToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ConvertAllToolStripMenuItem.Text = "Convert All"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(33, 18)
        '
        'SettingToolStrip
        '
        Me.SettingToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SettingToolStrip.Image = CType(resources.GetObject("SettingToolStrip.Image"), System.Drawing.Image)
        Me.SettingToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SettingToolStrip.Name = "SettingToolStrip"
        Me.SettingToolStrip.Size = New System.Drawing.Size(23, 20)
        Me.SettingToolStrip.Text = "Setting Parameters"
        '
        'ClsProjToolStrip
        '
        Me.ClsProjToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClsProjToolStrip.Image = CType(resources.GetObject("ClsProjToolStrip.Image"), System.Drawing.Image)
        Me.ClsProjToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClsProjToolStrip.Name = "ClsProjToolStrip"
        Me.ClsProjToolStrip.Size = New System.Drawing.Size(23, 20)
        Me.ClsProjToolStrip.Text = "Setting Parameters"
        Me.ClsProjToolStrip.ToolTipText = "Exit Project"
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.ProgBar)
        Me.pnlMain.Location = New System.Drawing.Point(31, 20)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(150, 242)
        Me.pnlMain.TabIndex = 5
        '
        'ProgBar
        '
        Me.ProgBar.Location = New System.Drawing.Point(2, 226)
        Me.ProgBar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(143, 12)
        Me.ProgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgBar.TabIndex = 0
        '
        'lblProgBar
        '
        Me.lblProgBar.AutoSize = True
        Me.lblProgBar.Location = New System.Drawing.Point(28, 263)
        Me.lblProgBar.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProgBar.Name = "lblProgBar"
        Me.lblProgBar.Size = New System.Drawing.Size(0, 13)
        Me.lblProgBar.TabIndex = 1
        '
        'UCmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblProgBar)
        Me.Controls.Add(Me.pnlVertMenu)
        Me.Controls.Add(Me.pnlMain)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "UCmain"
        Me.Size = New System.Drawing.Size(184, 279)
        Me.pnlVertMenu.ResumeLayout(False)
        Me.pnlVertMenu.PerformLayout()
        Me.CloseProj.ResumeLayout(False)
        Me.CloseProj.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlVertMenu As System.Windows.Forms.Panel
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lblProgBar As System.Windows.Forms.Label
    Friend WithEvents ProgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CloseProj As System.Windows.Forms.ToolStrip
    Friend WithEvents ProjectToolStripSplit As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents NewProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiveDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSplitActions As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents UpdateDrawingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertBlockStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents InfoToolStrip As System.Windows.Forms.ToolStripButton
    Friend WithEvents Attributes As System.Windows.Forms.ToolStripButton
    Friend WithEvents Group As System.Windows.Forms.ToolStripButton
    Friend WithEvents DocManagerToolStrip As System.Windows.Forms.ToolStripButton
    Friend WithEvents ClsProjToolStrip As System.Windows.Forms.ToolStripButton
    Friend WithEvents SettingToolStrip As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyBlockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents TlsNewKitchen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TlsOpenKitch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBlocksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSplitConvert2D3D As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ConvertSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConvertAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeactivateDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveDrawingAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveDrawingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NumeringToolStrip As System.Windows.Forms.ToolStripButton

End Class
