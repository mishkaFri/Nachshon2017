<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_BomList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_BomList))
        Me.TabReports = New System.Windows.Forms.TabControl
        Me.TpgBom = New System.Windows.Forms.TabPage
        Me.Grp = New System.Windows.Forms.GroupBox
        Me.GrpExtended = New System.Windows.Forms.GroupBox
        Me.ChkCoolRoom = New System.Windows.Forms.CheckBox
        Me.ChkShelf = New System.Windows.Forms.CheckBox
        Me.ChkCeiling = New System.Windows.Forms.CheckBox
        Me.ChkWeight = New System.Windows.Forms.CheckBox
        Me.ChkBake = New System.Windows.Forms.CheckBox
        Me.ChkSink = New System.Windows.Forms.CheckBox
        Me.ChkCooking = New System.Windows.Forms.CheckBox
        Me.ChkGarbage = New System.Windows.Forms.CheckBox
        Me.ChkWash = New System.Windows.Forms.CheckBox
        Me.ChkCool = New System.Windows.Forms.CheckBox
        Me.ChkFixed = New System.Windows.Forms.CheckBox
        Me.ChkProduction = New System.Windows.Forms.CheckBox
        Me.ChkPurchase = New System.Windows.Forms.CheckBox
        Me.ChkNotIn = New System.Windows.Forms.CheckBox
        Me.RadHebBOM = New System.Windows.Forms.RadioButton
        Me.TxtExcngRate = New System.Windows.Forms.TextBox
        Me.CmbCurr = New System.Windows.Forms.ComboBox
        Me.ChkPrice = New System.Windows.Forms.CheckBox
        Me.BtnBomView = New System.Windows.Forms.Button
        Me.RadEngBOM = New System.Windows.Forms.RadioButton
        Me.BtnCrtBom = New System.Windows.Forms.Button
        Me.BomBack = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.AllBlocksToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AllBlocksToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ByTenderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RegularToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExtendedToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GrpBomView = New System.Windows.Forms.GroupBox
        Me.BtnInsertBomXls = New System.Windows.Forms.Button
        Me.BtnOpenBomXls = New System.Windows.Forms.Button
        Me.LstBom = New System.Windows.Forms.ListBox
        Me.TpgLists = New System.Windows.Forms.TabPage
        Me.BtnListView = New System.Windows.Forms.Button
        Me.RadListHeb = New System.Windows.Forms.RadioButton
        Me.BtnCrtList = New System.Windows.Forms.Button
        Me.radListEng = New System.Windows.Forms.RadioButton
        Me.CmbListypes = New System.Windows.Forms.ComboBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpLstview = New System.Windows.Forms.GroupBox
        Me.BtnInsertXL = New System.Windows.Forms.Button
        Me.BtnOpenXls = New System.Windows.Forms.Button
        Me.lstList = New System.Windows.Forms.ListBox
        Me.TpgTender = New System.Windows.Forms.TabPage
        Me.GrpTndBom = New System.Windows.Forms.GroupBox
        Me.RadHebTnd = New System.Windows.Forms.RadioButton
        Me.RadEngTnd = New System.Windows.Forms.RadioButton
        Me.BtnCrtSelTnd = New System.Windows.Forms.Button
        Me.BtnCloseTndBom = New System.Windows.Forms.Button
        Me.BtnCrtAllTender = New System.Windows.Forms.Button
        Me.LstTndBom = New System.Windows.Forms.ListBox
        Me.GrpTndView = New System.Windows.Forms.GroupBox
        Me.BtnTenderBack = New System.Windows.Forms.Button
        Me.BtnCrtTndView = New System.Windows.Forms.Button
        Me.BtnOpenTender = New System.Windows.Forms.Button
        Me.LstTnd = New System.Windows.Forms.ListBox
        Me.ProgBar = New System.Windows.Forms.ProgressBar
        Me.BomTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllBlocksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ByTenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RegularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExtendedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabReports.SuspendLayout()
        Me.TpgBom.SuspendLayout()
        Me.Grp.SuspendLayout()
        Me.GrpExtended.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GrpBomView.SuspendLayout()
        Me.TpgLists.SuspendLayout()
        Me.grpLstview.SuspendLayout()
        Me.TpgTender.SuspendLayout()
        Me.GrpTndBom.SuspendLayout()
        Me.GrpTndView.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabReports
        '
        Me.TabReports.Controls.Add(Me.TpgBom)
        Me.TabReports.Controls.Add(Me.TpgLists)
        Me.TabReports.Controls.Add(Me.TpgTender)
        Me.TabReports.Location = New System.Drawing.Point(0, 0)
        Me.TabReports.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabReports.Name = "TabReports"
        Me.TabReports.SelectedIndex = 0
        Me.TabReports.Size = New System.Drawing.Size(143, 224)
        Me.TabReports.TabIndex = 0
        '
        'TpgBom
        '
        Me.TpgBom.Controls.Add(Me.Grp)
        Me.TpgBom.Controls.Add(Me.RadHebBOM)
        Me.TpgBom.Controls.Add(Me.TxtExcngRate)
        Me.TpgBom.Controls.Add(Me.CmbCurr)
        Me.TpgBom.Controls.Add(Me.ChkPrice)
        Me.TpgBom.Controls.Add(Me.BtnBomView)
        Me.TpgBom.Controls.Add(Me.RadEngBOM)
        Me.TpgBom.Controls.Add(Me.BtnCrtBom)
        Me.TpgBom.Controls.Add(Me.BomBack)
        Me.TpgBom.Controls.Add(Me.MenuStrip1)
        Me.TpgBom.Controls.Add(Me.GrpBomView)
        Me.TpgBom.Location = New System.Drawing.Point(4, 22)
        Me.TpgBom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TpgBom.Name = "TpgBom"
        Me.TpgBom.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TpgBom.Size = New System.Drawing.Size(135, 198)
        Me.TpgBom.TabIndex = 1
        Me.TpgBom.Text = "BOM"
        Me.TpgBom.UseVisualStyleBackColor = True
        '
        'Grp
        '
        Me.Grp.Controls.Add(Me.GrpExtended)
        Me.Grp.Controls.Add(Me.ChkCool)
        Me.Grp.Controls.Add(Me.ChkFixed)
        Me.Grp.Controls.Add(Me.ChkProduction)
        Me.Grp.Controls.Add(Me.ChkPurchase)
        Me.Grp.Controls.Add(Me.ChkNotIn)
        Me.Grp.Location = New System.Drawing.Point(2, 56)
        Me.Grp.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Grp.Name = "Grp"
        Me.Grp.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Grp.Size = New System.Drawing.Size(135, 90)
        Me.Grp.TabIndex = 29
        Me.Grp.TabStop = False
        Me.Grp.Text = "Types"
        '
        'GrpExtended
        '
        Me.GrpExtended.Controls.Add(Me.ChkCoolRoom)
        Me.GrpExtended.Controls.Add(Me.ChkShelf)
        Me.GrpExtended.Controls.Add(Me.ChkCeiling)
        Me.GrpExtended.Controls.Add(Me.ChkWeight)
        Me.GrpExtended.Controls.Add(Me.ChkBake)
        Me.GrpExtended.Controls.Add(Me.ChkSink)
        Me.GrpExtended.Controls.Add(Me.ChkCooking)
        Me.GrpExtended.Controls.Add(Me.ChkGarbage)
        Me.GrpExtended.Controls.Add(Me.ChkWash)
        Me.GrpExtended.Location = New System.Drawing.Point(0, 38)
        Me.GrpExtended.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpExtended.Name = "GrpExtended"
        Me.GrpExtended.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpExtended.Size = New System.Drawing.Size(135, 52)
        Me.GrpExtended.TabIndex = 35
        Me.GrpExtended.TabStop = False
        '
        'ChkCoolRoom
        '
        Me.ChkCoolRoom.AutoSize = True
        Me.ChkCoolRoom.Location = New System.Drawing.Point(98, 30)
        Me.ChkCoolRoom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkCoolRoom.Name = "ChkCoolRoom"
        Me.ChkCoolRoom.Size = New System.Drawing.Size(33, 17)
        Me.ChkCoolRoom.TabIndex = 40
        Me.ChkCoolRoom.Text = "ח"
        Me.ToolTip1.SetToolTip(Me.ChkCoolRoom, "חדרי קירור")
        Me.ChkCoolRoom.UseVisualStyleBackColor = True
        '
        'ChkShelf
        '
        Me.ChkShelf.AutoSize = True
        Me.ChkShelf.Location = New System.Drawing.Point(28, 7)
        Me.ChkShelf.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkShelf.Name = "ChkShelf"
        Me.ChkShelf.Size = New System.Drawing.Size(33, 17)
        Me.ChkShelf.TabIndex = 39
        Me.ChkShelf.Text = "כ"
        Me.ToolTip1.SetToolTip(Me.ChkShelf, "כונניות")
        Me.ChkShelf.UseVisualStyleBackColor = True
        '
        'ChkCeiling
        '
        Me.ChkCeiling.AutoSize = True
        Me.ChkCeiling.Location = New System.Drawing.Point(44, 30)
        Me.ChkCeiling.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkCeiling.Name = "ChkCeiling"
        Me.ChkCeiling.Size = New System.Drawing.Size(33, 17)
        Me.ChkCeiling.TabIndex = 38
        Me.ChkCeiling.Text = "מ"
        Me.ToolTip1.SetToolTip(Me.ChkCeiling, "תקרות מנדפות")
        Me.ChkCeiling.UseVisualStyleBackColor = True
        '
        'ChkWeight
        '
        Me.ChkWeight.AutoSize = True
        Me.ChkWeight.Location = New System.Drawing.Point(71, 30)
        Me.ChkWeight.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkWeight.Name = "ChkWeight"
        Me.ChkWeight.Size = New System.Drawing.Size(33, 17)
        Me.ChkWeight.TabIndex = 37
        Me.ChkWeight.Text = "ס"
        Me.ToolTip1.SetToolTip(Me.ChkWeight, "משקלים")
        Me.ChkWeight.UseVisualStyleBackColor = True
        '
        'ChkBake
        '
        Me.ChkBake.AutoSize = True
        Me.ChkBake.Location = New System.Drawing.Point(16, 29)
        Me.ChkBake.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkBake.Name = "ChkBake"
        Me.ChkBake.Size = New System.Drawing.Size(33, 17)
        Me.ChkBake.TabIndex = 36
        Me.ChkBake.Text = "צ"
        Me.ToolTip1.SetToolTip(Me.ChkBake, "ציוד אפיה")
        Me.ChkBake.UseVisualStyleBackColor = True
        '
        'ChkSink
        '
        Me.ChkSink.AutoSize = True
        Me.ChkSink.Location = New System.Drawing.Point(5, 7)
        Me.ChkSink.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkSink.Name = "ChkSink"
        Me.ChkSink.Size = New System.Drawing.Size(31, 17)
        Me.ChkSink.TabIndex = 35
        Me.ChkSink.Text = "ז"
        Me.ToolTip1.SetToolTip(Me.ChkSink, "ברזים")
        Me.ChkSink.UseVisualStyleBackColor = True
        '
        'ChkCooking
        '
        Me.ChkCooking.AutoSize = True
        Me.ChkCooking.Location = New System.Drawing.Point(79, 8)
        Me.ChkCooking.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkCooking.Name = "ChkCooking"
        Me.ChkCooking.Size = New System.Drawing.Size(33, 17)
        Me.ChkCooking.TabIndex = 33
        Me.ChkCooking.Text = "ב"
        Me.ToolTip1.SetToolTip(Me.ChkCooking, "ציוד בישול")
        Me.ChkCooking.UseVisualStyleBackColor = True
        '
        'ChkGarbage
        '
        Me.ChkGarbage.AutoSize = True
        Me.ChkGarbage.Location = New System.Drawing.Point(104, 8)
        Me.ChkGarbage.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkGarbage.Name = "ChkGarbage"
        Me.ChkGarbage.Size = New System.Drawing.Size(32, 17)
        Me.ChkGarbage.TabIndex = 32
        Me.ChkGarbage.Text = "ג"
        Me.ToolTip1.SetToolTip(Me.ChkGarbage, "אשפה")
        Me.ChkGarbage.UseVisualStyleBackColor = True
        '
        'ChkWash
        '
        Me.ChkWash.AutoSize = True
        Me.ChkWash.Location = New System.Drawing.Point(52, 7)
        Me.ChkWash.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkWash.Name = "ChkWash"
        Me.ChkWash.Size = New System.Drawing.Size(33, 17)
        Me.ChkWash.TabIndex = 31
        Me.ChkWash.Text = "ה"
        Me.ToolTip1.SetToolTip(Me.ChkWash, "מכונות הדחה")
        Me.ChkWash.UseVisualStyleBackColor = True
        '
        'ChkCool
        '
        Me.ChkCool.AutoSize = True
        Me.ChkCool.Location = New System.Drawing.Point(53, 15)
        Me.ChkCool.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkCool.Name = "ChkCool"
        Me.ChkCool.Size = New System.Drawing.Size(33, 17)
        Me.ChkCool.TabIndex = 24
        Me.ChkCool.Text = "ק"
        Me.ToolTip1.SetToolTip(Me.ChkCool, "ציוד מקורר")
        Me.ChkCool.UseVisualStyleBackColor = True
        '
        'ChkFixed
        '
        Me.ChkFixed.AutoSize = True
        Me.ChkFixed.Location = New System.Drawing.Point(104, 15)
        Me.ChkFixed.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkFixed.Name = "ChkFixed"
        Me.ChkFixed.Size = New System.Drawing.Size(33, 17)
        Me.ChkFixed.TabIndex = 22
        Me.ChkFixed.Text = "ת"
        Me.ToolTip1.SetToolTip(Me.ChkFixed, "ציוד קבוע במבנה")
        Me.ChkFixed.UseVisualStyleBackColor = True
        '
        'ChkProduction
        '
        Me.ChkProduction.AutoSize = True
        Me.ChkProduction.Location = New System.Drawing.Point(28, 15)
        Me.ChkProduction.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkProduction.Name = "ChkProduction"
        Me.ChkProduction.Size = New System.Drawing.Size(33, 17)
        Me.ChkProduction.TabIndex = 17
        Me.ChkProduction.Text = "פ"
        Me.ToolTip1.SetToolTip(Me.ChkProduction, "ציוד לייצור מיוחד")
        Me.ChkProduction.UseVisualStyleBackColor = True
        '
        'ChkPurchase
        '
        Me.ChkPurchase.AutoSize = True
        Me.ChkPurchase.Location = New System.Drawing.Point(79, 15)
        Me.ChkPurchase.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkPurchase.Name = "ChkPurchase"
        Me.ChkPurchase.Size = New System.Drawing.Size(32, 17)
        Me.ChkPurchase.TabIndex = 23
        Me.ChkPurchase.Text = "ר"
        Me.ToolTip1.SetToolTip(Me.ChkPurchase, "ציוד לרכישה")
        Me.ChkPurchase.UseVisualStyleBackColor = True
        '
        'ChkNotIn
        '
        Me.ChkNotIn.AutoSize = True
        Me.ChkNotIn.Location = New System.Drawing.Point(3, 15)
        Me.ChkNotIn.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkNotIn.Name = "ChkNotIn"
        Me.ChkNotIn.Size = New System.Drawing.Size(34, 17)
        Me.ChkNotIn.TabIndex = 34
        Me.ChkNotIn.Text = "א"
        Me.ToolTip1.SetToolTip(Me.ChkNotIn, "לא למכרז")
        Me.ChkNotIn.UseVisualStyleBackColor = True
        '
        'RadHebBOM
        '
        Me.RadHebBOM.AutoSize = True
        Me.RadHebBOM.Checked = True
        Me.RadHebBOM.Location = New System.Drawing.Point(71, 21)
        Me.RadHebBOM.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RadHebBOM.Name = "RadHebBOM"
        Me.RadHebBOM.Size = New System.Drawing.Size(62, 17)
        Me.RadHebBOM.TabIndex = 39
        Me.RadHebBOM.TabStop = True
        Me.RadHebBOM.Text = "Hebrew"
        Me.RadHebBOM.UseVisualStyleBackColor = True
        '
        'TxtExcngRate
        '
        Me.TxtExcngRate.Location = New System.Drawing.Point(43, 151)
        Me.TxtExcngRate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtExcngRate.Name = "TxtExcngRate"
        Me.TxtExcngRate.Size = New System.Drawing.Size(48, 20)
        Me.TxtExcngRate.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.TxtExcngRate, "Exchange Rate to Shekel")
        '
        'CmbCurr
        '
        Me.CmbCurr.Location = New System.Drawing.Point(94, 151)
        Me.CmbCurr.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmbCurr.Name = "CmbCurr"
        Me.CmbCurr.Size = New System.Drawing.Size(41, 21)
        Me.CmbCurr.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.CmbCurr, "Select BOM Currency")
        '
        'ChkPrice
        '
        Me.ChkPrice.AutoSize = True
        Me.ChkPrice.BackColor = System.Drawing.Color.Transparent
        Me.ChkPrice.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ChkPrice.Location = New System.Drawing.Point(5, 145)
        Me.ChkPrice.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ChkPrice.Name = "ChkPrice"
        Me.ChkPrice.Size = New System.Drawing.Size(35, 31)
        Me.ChkPrice.TabIndex = 27
        Me.ChkPrice.Text = "Price"
        Me.ToolTip1.SetToolTip(Me.ChkPrice, "Set Price in BOM")
        Me.ChkPrice.UseVisualStyleBackColor = False
        '
        'BtnBomView
        '
        Me.BtnBomView.Image = CType(resources.GetObject("BtnBomView.Image"), System.Drawing.Image)
        Me.BtnBomView.Location = New System.Drawing.Point(112, 176)
        Me.BtnBomView.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnBomView.Name = "BtnBomView"
        Me.BtnBomView.Size = New System.Drawing.Size(23, 22)
        Me.BtnBomView.TabIndex = 37
        Me.ToolTip1.SetToolTip(Me.BtnBomView, "Show created lists")
        Me.BtnBomView.UseVisualStyleBackColor = True
        '
        'RadEngBOM
        '
        Me.RadEngBOM.AutoSize = True
        Me.RadEngBOM.Location = New System.Drawing.Point(12, 21)
        Me.RadEngBOM.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RadEngBOM.Name = "RadEngBOM"
        Me.RadEngBOM.Size = New System.Drawing.Size(59, 17)
        Me.RadEngBOM.TabIndex = 40
        Me.RadEngBOM.Text = "English"
        Me.RadEngBOM.UseVisualStyleBackColor = True
        '
        'BtnCrtBom
        '
        Me.BtnCrtBom.Image = CType(resources.GetObject("BtnCrtBom.Image"), System.Drawing.Image)
        Me.BtnCrtBom.Location = New System.Drawing.Point(55, 175)
        Me.BtnCrtBom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnCrtBom.Name = "BtnCrtBom"
        Me.BtnCrtBom.Size = New System.Drawing.Size(24, 24)
        Me.BtnCrtBom.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.BtnCrtBom, "Create selected BOM lists")
        Me.BtnCrtBom.UseVisualStyleBackColor = True
        '
        'BomBack
        '
        Me.BomBack.Image = Global.Nachshon.My.Resources.Resources.back
        Me.BomBack.Location = New System.Drawing.Point(2, 176)
        Me.BomBack.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BomBack.Name = "BomBack"
        Me.BomBack.Size = New System.Drawing.Size(23, 22)
        Me.BomBack.TabIndex = 36
        Me.ToolTip1.SetToolTip(Me.BomBack, "Back")
        Me.BomBack.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllBlocksToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(2, 2)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(133, 21)
        Me.MenuStrip1.TabIndex = 26
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'AllBlocksToolStripMenuItem1
        '
        Me.AllBlocksToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllBlocksToolStripMenuItem2, Me.ByTenderToolStripMenuItem1})
        Me.AllBlocksToolStripMenuItem1.Name = "AllBlocksToolStripMenuItem1"
        Me.AllBlocksToolStripMenuItem1.Size = New System.Drawing.Size(84, 17)
        Me.AllBlocksToolStripMenuItem1.Text = "BomType"
        '
        'AllBlocksToolStripMenuItem2
        '
        Me.AllBlocksToolStripMenuItem2.Name = "AllBlocksToolStripMenuItem2"
        Me.AllBlocksToolStripMenuItem2.Size = New System.Drawing.Size(140, 22)
        Me.AllBlocksToolStripMenuItem2.Text = "All Blocks"
        '
        'ByTenderToolStripMenuItem1
        '
        Me.ByTenderToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegularToolStripMenuItem1, Me.ExtendedToolStripMenuItem1})
        Me.ByTenderToolStripMenuItem1.Name = "ByTenderToolStripMenuItem1"
        Me.ByTenderToolStripMenuItem1.Size = New System.Drawing.Size(140, 22)
        Me.ByTenderToolStripMenuItem1.Text = "ByTender"
        '
        'RegularToolStripMenuItem1
        '
        Me.RegularToolStripMenuItem1.Name = "RegularToolStripMenuItem1"
        Me.RegularToolStripMenuItem1.Size = New System.Drawing.Size(137, 22)
        Me.RegularToolStripMenuItem1.Text = "Regular"
        '
        'ExtendedToolStripMenuItem1
        '
        Me.ExtendedToolStripMenuItem1.Name = "ExtendedToolStripMenuItem1"
        Me.ExtendedToolStripMenuItem1.Size = New System.Drawing.Size(137, 22)
        Me.ExtendedToolStripMenuItem1.Text = "Extended"
        '
        'GrpBomView
        '
        Me.GrpBomView.AccessibleDescription = ""
        Me.GrpBomView.Controls.Add(Me.BtnInsertBomXls)
        Me.GrpBomView.Controls.Add(Me.BtnOpenBomXls)
        Me.GrpBomView.Controls.Add(Me.LstBom)
        Me.GrpBomView.Location = New System.Drawing.Point(0, 0)
        Me.GrpBomView.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpBomView.Name = "GrpBomView"
        Me.GrpBomView.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpBomView.Size = New System.Drawing.Size(137, 145)
        Me.GrpBomView.TabIndex = 0
        Me.GrpBomView.TabStop = False
        Me.GrpBomView.Text = "Bom List:"
        Me.GrpBomView.Visible = False
        '
        'BtnInsertBomXls
        '
        Me.BtnInsertBomXls.Image = Global.Nachshon.My.Resources.Resources.Plus2
        Me.BtnInsertBomXls.Location = New System.Drawing.Point(4, 119)
        Me.BtnInsertBomXls.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnInsertBomXls.Name = "BtnInsertBomXls"
        Me.BtnInsertBomXls.Size = New System.Drawing.Size(24, 24)
        Me.BtnInsertBomXls.TabIndex = 14
        Me.BtnInsertBomXls.UseVisualStyleBackColor = True
        '
        'BtnOpenBomXls
        '
        Me.BtnOpenBomXls.Image = Global.Nachshon.My.Resources.Resources.OPEN
        Me.BtnOpenBomXls.Location = New System.Drawing.Point(108, 119)
        Me.BtnOpenBomXls.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnOpenBomXls.Name = "BtnOpenBomXls"
        Me.BtnOpenBomXls.Size = New System.Drawing.Size(24, 24)
        Me.BtnOpenBomXls.TabIndex = 13
        Me.BtnOpenBomXls.UseVisualStyleBackColor = True
        '
        'LstBom
        '
        Me.LstBom.FormattingEnabled = True
        Me.LstBom.Location = New System.Drawing.Point(5, 19)
        Me.LstBom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.LstBom.Name = "LstBom"
        Me.LstBom.Size = New System.Drawing.Size(124, 95)
        Me.LstBom.TabIndex = 12
        '
        'TpgLists
        '
        Me.TpgLists.Controls.Add(Me.BtnListView)
        Me.TpgLists.Controls.Add(Me.RadListHeb)
        Me.TpgLists.Controls.Add(Me.BtnCrtList)
        Me.TpgLists.Controls.Add(Me.radListEng)
        Me.TpgLists.Controls.Add(Me.CmbListypes)
        Me.TpgLists.Controls.Add(Me.btnCancel)
        Me.TpgLists.Controls.Add(Me.grpLstview)
        Me.TpgLists.Location = New System.Drawing.Point(4, 22)
        Me.TpgLists.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TpgLists.Name = "TpgLists"
        Me.TpgLists.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TpgLists.Size = New System.Drawing.Size(135, 198)
        Me.TpgLists.TabIndex = 0
        Me.TpgLists.Text = "List"
        Me.TpgLists.UseVisualStyleBackColor = True
        '
        'BtnListView
        '
        Me.BtnListView.Image = CType(resources.GetObject("BtnListView.Image"), System.Drawing.Image)
        Me.BtnListView.Location = New System.Drawing.Point(111, 175)
        Me.BtnListView.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnListView.Name = "BtnListView"
        Me.BtnListView.Size = New System.Drawing.Size(24, 25)
        Me.BtnListView.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.BtnListView, "View existing lists")
        Me.BtnListView.UseVisualStyleBackColor = True
        '
        'RadListHeb
        '
        Me.RadListHeb.AutoSize = True
        Me.RadListHeb.Checked = True
        Me.RadListHeb.Location = New System.Drawing.Point(44, 51)
        Me.RadListHeb.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RadListHeb.Name = "RadListHeb"
        Me.RadListHeb.Size = New System.Drawing.Size(62, 17)
        Me.RadListHeb.TabIndex = 30
        Me.RadListHeb.TabStop = True
        Me.RadListHeb.Text = "Hebrew"
        Me.RadListHeb.UseVisualStyleBackColor = True
        '
        'BtnCrtList
        '
        Me.BtnCrtList.Image = CType(resources.GetObject("BtnCrtList.Image"), System.Drawing.Image)
        Me.BtnCrtList.Location = New System.Drawing.Point(57, 176)
        Me.BtnCrtList.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnCrtList.Name = "BtnCrtList"
        Me.BtnCrtList.Size = New System.Drawing.Size(24, 24)
        Me.BtnCrtList.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.BtnCrtList, "Create list")
        Me.BtnCrtList.UseVisualStyleBackColor = True
        '
        'radListEng
        '
        Me.radListEng.AutoSize = True
        Me.radListEng.Location = New System.Drawing.Point(45, 29)
        Me.radListEng.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.radListEng.Name = "radListEng"
        Me.radListEng.Size = New System.Drawing.Size(59, 17)
        Me.radListEng.TabIndex = 31
        Me.radListEng.Text = "English"
        Me.radListEng.UseVisualStyleBackColor = True
        '
        'CmbListypes
        '
        Me.CmbListypes.FormattingEnabled = True
        Me.CmbListypes.Items.AddRange(New Object() {"Wide ", "Narrow ", "Fixed", "Operational"})
        Me.CmbListypes.Location = New System.Drawing.Point(28, 5)
        Me.CmbListypes.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmbListypes.Name = "CmbListypes"
        Me.CmbListypes.Size = New System.Drawing.Size(95, 21)
        Me.CmbListypes.TabIndex = 29
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.Nachshon.My.Resources.Resources.back
        Me.btnCancel.Location = New System.Drawing.Point(4, 176)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(23, 22)
        Me.btnCancel.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.btnCancel, "Back")
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grpLstview
        '
        Me.grpLstview.Controls.Add(Me.BtnInsertXL)
        Me.grpLstview.Controls.Add(Me.BtnOpenXls)
        Me.grpLstview.Controls.Add(Me.lstList)
        Me.grpLstview.Location = New System.Drawing.Point(2, 2)
        Me.grpLstview.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grpLstview.Name = "grpLstview"
        Me.grpLstview.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.grpLstview.Size = New System.Drawing.Size(135, 165)
        Me.grpLstview.TabIndex = 27
        Me.grpLstview.TabStop = False
        Me.grpLstview.Text = "Doc List:"
        '
        'BtnInsertXL
        '
        Me.BtnInsertXL.Image = Global.Nachshon.My.Resources.Resources.Plus2
        Me.BtnInsertXL.Location = New System.Drawing.Point(2, 139)
        Me.BtnInsertXL.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnInsertXL.Name = "BtnInsertXL"
        Me.BtnInsertXL.Size = New System.Drawing.Size(24, 24)
        Me.BtnInsertXL.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.BtnInsertXL, "Add Chosen list to drawing")
        Me.BtnInsertXL.UseVisualStyleBackColor = True
        '
        'BtnOpenXls
        '
        Me.BtnOpenXls.Image = Global.Nachshon.My.Resources.Resources.OPEN
        Me.BtnOpenXls.Location = New System.Drawing.Point(106, 139)
        Me.BtnOpenXls.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnOpenXls.Name = "BtnOpenXls"
        Me.BtnOpenXls.Size = New System.Drawing.Size(24, 24)
        Me.BtnOpenXls.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.BtnOpenXls, "Open selected list")
        Me.BtnOpenXls.UseVisualStyleBackColor = True
        '
        'lstList
        '
        Me.lstList.FormattingEnabled = True
        Me.lstList.Location = New System.Drawing.Point(4, 16)
        Me.lstList.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lstList.Name = "lstList"
        Me.lstList.Size = New System.Drawing.Size(127, 121)
        Me.lstList.TabIndex = 12
        '
        'TpgTender
        '
        Me.TpgTender.Controls.Add(Me.GrpTndBom)
        Me.TpgTender.Controls.Add(Me.GrpTndView)
        Me.TpgTender.Location = New System.Drawing.Point(4, 22)
        Me.TpgTender.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TpgTender.Name = "TpgTender"
        Me.TpgTender.Size = New System.Drawing.Size(135, 198)
        Me.TpgTender.TabIndex = 2
        Me.TpgTender.Text = "Tender"
        Me.TpgTender.UseVisualStyleBackColor = True
        '
        'GrpTndBom
        '
        Me.GrpTndBom.Controls.Add(Me.RadHebTnd)
        Me.GrpTndBom.Controls.Add(Me.RadEngTnd)
        Me.GrpTndBom.Controls.Add(Me.BtnCrtSelTnd)
        Me.GrpTndBom.Controls.Add(Me.BtnCloseTndBom)
        Me.GrpTndBom.Controls.Add(Me.BtnCrtAllTender)
        Me.GrpTndBom.Controls.Add(Me.LstTndBom)
        Me.GrpTndBom.Location = New System.Drawing.Point(2, 2)
        Me.GrpTndBom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpTndBom.Name = "GrpTndBom"
        Me.GrpTndBom.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpTndBom.Size = New System.Drawing.Size(135, 202)
        Me.GrpTndBom.TabIndex = 39
        Me.GrpTndBom.TabStop = False
        Me.GrpTndBom.Text = "BOM List:"
        '
        'RadHebTnd
        '
        Me.RadHebTnd.AutoSize = True
        Me.RadHebTnd.Checked = True
        Me.RadHebTnd.Location = New System.Drawing.Point(69, 142)
        Me.RadHebTnd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RadHebTnd.Name = "RadHebTnd"
        Me.RadHebTnd.Size = New System.Drawing.Size(62, 17)
        Me.RadHebTnd.TabIndex = 40
        Me.RadHebTnd.TabStop = True
        Me.RadHebTnd.Text = "Hebrew"
        Me.RadHebTnd.UseVisualStyleBackColor = True
        '
        'RadEngTnd
        '
        Me.RadEngTnd.AutoSize = True
        Me.RadEngTnd.Location = New System.Drawing.Point(5, 142)
        Me.RadEngTnd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RadEngTnd.Name = "RadEngTnd"
        Me.RadEngTnd.Size = New System.Drawing.Size(59, 17)
        Me.RadEngTnd.TabIndex = 41
        Me.RadEngTnd.Text = "English"
        Me.RadEngTnd.UseVisualStyleBackColor = True
        '
        'BtnCrtSelTnd
        '
        Me.BtnCrtSelTnd.Image = Global.Nachshon.My.Resources.Resources.Tender1
        Me.BtnCrtSelTnd.Location = New System.Drawing.Point(55, 165)
        Me.BtnCrtSelTnd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnCrtSelTnd.Name = "BtnCrtSelTnd"
        Me.BtnCrtSelTnd.Size = New System.Drawing.Size(20, 22)
        Me.BtnCrtSelTnd.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.BtnCrtSelTnd, "Create Tender from selected BOM")
        Me.BtnCrtSelTnd.UseVisualStyleBackColor = True
        '
        'BtnCloseTndBom
        '
        Me.BtnCloseTndBom.Image = Global.Nachshon.My.Resources.Resources.back
        Me.BtnCloseTndBom.Location = New System.Drawing.Point(5, 165)
        Me.BtnCloseTndBom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnCloseTndBom.Name = "BtnCloseTndBom"
        Me.BtnCloseTndBom.Size = New System.Drawing.Size(23, 22)
        Me.BtnCloseTndBom.TabIndex = 39
        Me.ToolTip1.SetToolTip(Me.BtnCloseTndBom, "Back")
        Me.BtnCloseTndBom.UseVisualStyleBackColor = True
        '
        'BtnCrtAllTender
        '
        Me.BtnCrtAllTender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCrtAllTender.Image = Global.Nachshon.My.Resources.Resources.TwoDocs
        Me.BtnCrtAllTender.Location = New System.Drawing.Point(105, 165)
        Me.BtnCrtAllTender.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnCrtAllTender.Name = "BtnCrtAllTender"
        Me.BtnCrtAllTender.Size = New System.Drawing.Size(20, 22)
        Me.BtnCrtAllTender.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.BtnCrtAllTender, "Create all tenders according to the current document")
        Me.BtnCrtAllTender.UseVisualStyleBackColor = True
        '
        'LstTndBom
        '
        Me.LstTndBom.FormattingEnabled = True
        Me.LstTndBom.Location = New System.Drawing.Point(5, 17)
        Me.LstTndBom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.LstTndBom.Name = "LstTndBom"
        Me.LstTndBom.Size = New System.Drawing.Size(120, 121)
        Me.LstTndBom.TabIndex = 14
        '
        'GrpTndView
        '
        Me.GrpTndView.Controls.Add(Me.BtnTenderBack)
        Me.GrpTndView.Controls.Add(Me.BtnCrtTndView)
        Me.GrpTndView.Controls.Add(Me.BtnOpenTender)
        Me.GrpTndView.Controls.Add(Me.LstTnd)
        Me.GrpTndView.Location = New System.Drawing.Point(2, 2)
        Me.GrpTndView.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpTndView.Name = "GrpTndView"
        Me.GrpTndView.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GrpTndView.Size = New System.Drawing.Size(133, 202)
        Me.GrpTndView.TabIndex = 29
        Me.GrpTndView.TabStop = False
        Me.GrpTndView.Text = "Tender List:"
        Me.GrpTndView.Visible = False
        '
        'BtnTenderBack
        '
        Me.BtnTenderBack.Image = Global.Nachshon.My.Resources.Resources.back
        Me.BtnTenderBack.Location = New System.Drawing.Point(6, 169)
        Me.BtnTenderBack.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnTenderBack.Name = "BtnTenderBack"
        Me.BtnTenderBack.Size = New System.Drawing.Size(23, 22)
        Me.BtnTenderBack.TabIndex = 37
        Me.ToolTip1.SetToolTip(Me.BtnTenderBack, "Back")
        Me.BtnTenderBack.UseVisualStyleBackColor = True
        '
        'BtnCrtTndView
        '
        Me.BtnCrtTndView.Image = Global.Nachshon.My.Resources.Resources.bom
        Me.BtnCrtTndView.Location = New System.Drawing.Point(55, 168)
        Me.BtnCrtTndView.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnCrtTndView.Name = "BtnCrtTndView"
        Me.BtnCrtTndView.Size = New System.Drawing.Size(23, 24)
        Me.BtnCrtTndView.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.BtnCrtTndView, "Create new Tenders")
        Me.BtnCrtTndView.UseVisualStyleBackColor = True
        '
        'BtnOpenTender
        '
        Me.BtnOpenTender.Image = Global.Nachshon.My.Resources.Resources.OPEN
        Me.BtnOpenTender.Location = New System.Drawing.Point(103, 167)
        Me.BtnOpenTender.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnOpenTender.Name = "BtnOpenTender"
        Me.BtnOpenTender.Size = New System.Drawing.Size(24, 24)
        Me.BtnOpenTender.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.BtnOpenTender, "Open selected Tender")
        Me.BtnOpenTender.UseVisualStyleBackColor = True
        '
        'LstTnd
        '
        Me.LstTnd.FormattingEnabled = True
        Me.LstTnd.Location = New System.Drawing.Point(6, 17)
        Me.LstTnd.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.LstTnd.Name = "LstTnd"
        Me.LstTnd.Size = New System.Drawing.Size(122, 147)
        Me.LstTnd.TabIndex = 0
        '
        'ProgBar
        '
        Me.ProgBar.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ProgBar.Location = New System.Drawing.Point(2, 226)
        Me.ProgBar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(141, 10)
        Me.ProgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgBar.TabIndex = 39
        '
        'BomTypeToolStripMenuItem
        '
        Me.BomTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllBlocksToolStripMenuItem, Me.ByTenderToolStripMenuItem})
        Me.BomTypeToolStripMenuItem.Name = "BomTypeToolStripMenuItem"
        Me.BomTypeToolStripMenuItem.Size = New System.Drawing.Size(84, 22)
        Me.BomTypeToolStripMenuItem.Text = "BomType"
        '
        'AllBlocksToolStripMenuItem
        '
        Me.AllBlocksToolStripMenuItem.Name = "AllBlocksToolStripMenuItem"
        Me.AllBlocksToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.AllBlocksToolStripMenuItem.Text = "All Blocks"
        '
        'ByTenderToolStripMenuItem
        '
        Me.ByTenderToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegularToolStripMenuItem, Me.ExtendedToolStripMenuItem})
        Me.ByTenderToolStripMenuItem.Name = "ByTenderToolStripMenuItem"
        Me.ByTenderToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ByTenderToolStripMenuItem.Text = "ByTender"
        '
        'RegularToolStripMenuItem
        '
        Me.RegularToolStripMenuItem.Name = "RegularToolStripMenuItem"
        Me.RegularToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.RegularToolStripMenuItem.Text = "Regular"
        '
        'ExtendedToolStripMenuItem
        '
        Me.ExtendedToolStripMenuItem.Name = "ExtendedToolStripMenuItem"
        Me.ExtendedToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ExtendedToolStripMenuItem.Text = "Extended"
        '
        'UC_BomList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ProgBar)
        Me.Controls.Add(Me.TabReports)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "UC_BomList"
        Me.Size = New System.Drawing.Size(146, 240)
        Me.TabReports.ResumeLayout(False)
        Me.TpgBom.ResumeLayout(False)
        Me.TpgBom.PerformLayout()
        Me.Grp.ResumeLayout(False)
        Me.Grp.PerformLayout()
        Me.GrpExtended.ResumeLayout(False)
        Me.GrpExtended.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GrpBomView.ResumeLayout(False)
        Me.TpgLists.ResumeLayout(False)
        Me.TpgLists.PerformLayout()
        Me.grpLstview.ResumeLayout(False)
        Me.TpgTender.ResumeLayout(False)
        Me.GrpTndBom.ResumeLayout(False)
        Me.GrpTndBom.PerformLayout()
        Me.GrpTndView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabReports As System.Windows.Forms.TabControl
    Friend WithEvents TpgLists As System.Windows.Forms.TabPage
    Friend WithEvents BtnListView As System.Windows.Forms.Button
    Friend WithEvents BtnCrtList As System.Windows.Forms.Button
    Friend WithEvents radListEng As System.Windows.Forms.RadioButton
    Friend WithEvents RadListHeb As System.Windows.Forms.RadioButton
    Friend WithEvents CmbListypes As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpLstview As System.Windows.Forms.GroupBox
    Friend WithEvents BtnInsertXL As System.Windows.Forms.Button
    Friend WithEvents BtnOpenXls As System.Windows.Forms.Button
    Friend WithEvents lstList As System.Windows.Forms.ListBox
    Friend WithEvents TpgBom As System.Windows.Forms.TabPage
    Friend WithEvents TpgTender As System.Windows.Forms.TabPage
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents BomTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllBlocksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByTenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtendedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkPrice As System.Windows.Forms.CheckBox
    Friend WithEvents BtnCrtAllTender As System.Windows.Forms.Button
    Friend WithEvents GrpBomView As System.Windows.Forms.GroupBox
    Friend WithEvents BtnInsertBomXls As System.Windows.Forms.Button
    Friend WithEvents BtnOpenBomXls As System.Windows.Forms.Button
    Friend WithEvents LstBom As System.Windows.Forms.ListBox
    Friend WithEvents GrpTndView As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOpenTender As System.Windows.Forms.Button
    Friend WithEvents LstTnd As System.Windows.Forms.ListBox
    Friend WithEvents Grp As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBomView As System.Windows.Forms.Button
    Friend WithEvents BomBack As System.Windows.Forms.Button
    Friend WithEvents GrpExtended As System.Windows.Forms.GroupBox
    Friend WithEvents ChkCoolRoom As System.Windows.Forms.CheckBox
    Friend WithEvents ChkShelf As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCeiling As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWeight As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBake As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSink As System.Windows.Forms.CheckBox
    Friend WithEvents ChkNotIn As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCooking As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGarbage As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWash As System.Windows.Forms.CheckBox
    Friend WithEvents BtnCrtBom As System.Windows.Forms.Button
    Friend WithEvents ChkCool As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPurchase As System.Windows.Forms.CheckBox
    Friend WithEvents ChkFixed As System.Windows.Forms.CheckBox
    Friend WithEvents ChkProduction As System.Windows.Forms.CheckBox
    Friend WithEvents BtnCrtSelTnd As System.Windows.Forms.Button
    Friend WithEvents GrpTndBom As System.Windows.Forms.GroupBox
    Friend WithEvents LstTndBom As System.Windows.Forms.ListBox
    Friend WithEvents BtnCloseTndBom As System.Windows.Forms.Button
    Friend WithEvents BtnCrtTndView As System.Windows.Forms.Button
    Friend WithEvents AllBlocksToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllBlocksToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByTenderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegularToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtendedToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmbCurr As System.Windows.Forms.ComboBox
    Friend WithEvents TxtExcngRate As System.Windows.Forms.TextBox
    Public WithEvents ProgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnTenderBack As System.Windows.Forms.Button
    Friend WithEvents RadHebBOM As System.Windows.Forms.RadioButton
    Friend WithEvents RadEngBOM As System.Windows.Forms.RadioButton
    Friend WithEvents RadHebTnd As System.Windows.Forms.RadioButton
    Friend WithEvents RadEngTnd As System.Windows.Forms.RadioButton

End Class
