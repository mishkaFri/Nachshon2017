
Imports System
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Interop.Common.ACAD_COLOR
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic
Public Class UCmain
    Public UC_List As System.Collections.Generic.Dictionary(Of String, UserControl)
    Private _Obs As BlockLibs
    Private _CurCategory as string

#Region "properties"
    Public Property CurCategory() As String
        Get
            Return _CurCategory
        End Get
        Set(ByVal value As String)
            _CurCategory = value
        End Set
    End Property
    Public Property Obs() As BlockLibs
        Get
            Return _Obs
        End Get
        Set(ByVal value As BlockLibs)
            _Obs = value
        End Set
    End Property
#End Region

    Public Sub New()
        Dim RetValBool As Boolean

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        RetValBool = GlbData.GlbData_Ini(Me)
        ' Add any initialization after the InitializeComponent() call.
        Me.UC_List = New System.Collections.Generic.Dictionary(Of String, UserControl)



        Try
            'GlbData.GlbAcadApp = GetObject(, "AutoCAD.Application")
            GlbData.GlbAcadApp = ApplicationServices.Application.AcadApplication
            'Me.AxAcCtrl1 .po
            'GlbData.GlbArxApp = GetObject(, "AutoCAD.Application")
            'Application = GlbData.GlbAcadApp
        Catch ex As System.Exception
            GlbData.GlbAcadApp = GetObject(, "AutoCAD.Application.21")
            Exit Sub
        End Try



    End Sub

    Public Sub HideControlsInPanel()
        For Each tmp As Control In Me.pnlMain.Controls
            tmp.Visible = False
        Next
    End Sub

    Private Sub UCmain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UC_List.Add("UC_Setting", New UC_Setting())
        Me.UC_List.Add("UC_NewProject", New UC_NewProject())
        Me.UC_List.Add("UC_OpenProject", New UC_OpenProject())
        Me.UC_List.Add("UC_Attributes_2", New UC_Attributes_2())
        'Me.UC_List.Add("UC_InsertBlock", New UC_InsertBlock())
        Me.UC_List.Add("UC_NewKitchen", New UC_NewKitchen())
        Me.UC_List.Add("UC_OpenKitchen_2", New UC_OpenKitchen_2())
        Me.UC_List.Add("UC_Information", New UC_Information())
        Me.UC_List.Add("UC_Numering", New UC_Numering())
        Me.UC_List.Add("UC_Parameters", New UC_Parameters())
        Me.UC_List.Add("UC_Groups", New UC_Groups())
        Me.UC_List.Add("UC_BomList", New UC_BomList())
        Me.ProgBar.Visible = False
        Me.lblProgBar.Visible = False

        'Set Buttons to Start Position 
        SetButtonsByMode(GlbEnum.MainMenuButtonsMode.StartMode)
    End Sub

    Private Sub NewProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProjectToolStripMenuItem.Click
        If (Me.UC_List("UC_NewProject") Is Nothing) Then
            Me.UC_List.Add("UC_NewProject", New UC_NewProject())
        End If
        Dim tmp As UC_NewProject = Me.UC_List("UC_NewProject")

        HideControlsInPanel()
        Me.pnlMain.Controls.Add(tmp)
        tmp.Visible = True
        tmp.Update()
        'Set Buttons to Start Position 
        SetButtonsByMode(GlbEnum.MainMenuButtonsMode.ProjectOk)
    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjectToolStripMenuItem.Click
        If (Me.UC_List("UC_OpenProject") Is Nothing) Then
            Me.UC_List.Add("UC_OpenProject", New UC_OpenProject())
        End If
        Dim tmp As UC_OpenProject = Me.UC_List("UC_OpenProject")

        HideControlsInPanel()
        tmp.LoadInEditMode()
        Me.pnlMain.Controls.Add(tmp)
        tmp.Visible = True
        tmp.Update()

        'Set Buttons to Start Position 
        SetButtonsByMode(GlbEnum.MainMenuButtonsMode.ProjectOk)

    End Sub

    Private Sub NewKitchenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlsNewKitchen.Click

        If (Me.UC_List("UC_NewKitchen") Is Nothing) Then
            Me.UC_List.Add("UC_NewKitchen", New UC_NewKitchen())
        End If
        Dim tmp As UC_NewKitchen = Me.UC_List("UC_NewKitchen")

        HideControlsInPanel()
        Me.pnlMain.Controls.Add(tmp)
        tmp.lblProjName.Text = GlbData.GlbActiveProject.Name
        tmp.Visible = True
        tmp.Update()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlsOpenKitch.Click
        If (Me.UC_List("UC_OpenKitchen_2") Is Nothing) Then
            Me.UC_List.Add("UC_OpenKitchen_2", New UC_OpenKitchen_2())
        End If
        Dim tmp As UC_OpenKitchen_2 = Me.UC_List("UC_OpenKitchen_2")

        HideControlsInPanel()
        Me.pnlMain.Controls.Add(tmp)
        tmp.FillKitchList()
        tmp.Visible = True
        tmp.Update()
    End Sub

    Public Sub ChangeMenu(ByVal menu As Control)
        Me.pnlMain.Controls.Clear()
        If Not (menu Is Nothing) Then
            Me.pnlMain.Controls.Add(menu)
            'Me.tlbLabel.Text = menu.Tag
        End If
        'Me.SetModels()
    End Sub

    Public Sub SetButtonsByMode(ByVal curMode As Integer)
        Select Case curMode

            Case GlbEnum.MainMenuButtonsMode.StartMode
                Me.ProjectToolStripSplit.Enabled = True
                Me.ToolStripSplitButton1.Enabled = False
                Me.ToolStripSplitActions.Enabled = False
                Me.InfoToolStrip.Enabled = False
                Me.DocManagerToolStrip.Enabled = False
                Me.ToolStripSplitActions.Enabled = False
                Me.InsertBlockStripDropDownButton1.Enabled = False
                Me.NumeringToolStrip.Enabled = False
                Me.Attributes.Enabled = False
                Me.Group.Enabled = False
                Me.ToolStripSplitConvert2D3D.Enabled = False

            Case GlbEnum.MainMenuButtonsMode.ProjectOk
                Me.ProjectToolStripSplit.Enabled = True
                Me.ToolStripSplitButton1.Enabled = True
                Me.ToolStripSplitActions.Enabled = True
                Me.InfoToolStrip.Enabled = True
                Me.DocManagerToolStrip.Enabled = True
                Me.ToolStripSplitActions.Enabled = True
                Me.InsertBlockStripDropDownButton1.Enabled = False
                Me.NumeringToolStrip.Enabled = False
                Me.Attributes.Enabled = False
                Me.Group.Enabled = False

            Case GlbEnum.MainMenuButtonsMode.KitchenOk
                Me.ProjectToolStripSplit.Enabled = True
                Me.ToolStripSplitButton1.Enabled = True
                Me.ToolStripSplitActions.Enabled = True
                Me.InfoToolStrip.Enabled = True
                Me.DocManagerToolStrip.Enabled = True
                Me.ToolStripSplitActions.Enabled = True
                'Me.ChangeMenu(New UC_InsertBlock())
                Me.InsertBlockStripDropDownButton1.Enabled = True
                Me.NumeringToolStrip.Enabled = True
                Me.Attributes.Enabled = True
                Me.Group.Enabled = True
                Me.ToolStripSplitConvert2D3D.Enabled = True

            Case GlbEnum.MainMenuButtonsMode.ProjectClosed
                Me.ProjectToolStripSplit.Enabled = True
                Me.ToolStripSplitActions.Enabled = False
                Me.InfoToolStrip.Enabled = False
                Me.DocManagerToolStrip.Enabled = False
                Me.ToolStripSplitActions.Enabled = False
                Me.InsertBlockStripDropDownButton1.Enabled = False
                Me.NumeringToolStrip.Enabled = False
                Me.Attributes.Enabled = False
                Me.Group.Enabled = False
                Me.ToolStripSplitConvert2D3D.Enabled = False

        End Select
    End Sub

    Private Sub SettingToolStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingToolStrip.Click, SettingToolStrip.Click
        If (Me.UC_List("UC_Setting") Is Nothing) Then
            Me.UC_List.Add("UC_Setting", New UC_Setting())
        End If
        Dim tmp As UC_Setting = Me.UC_List("UC_Setting")

        HideControlsInPanel()
        Me.pnlMain.Controls.Add(tmp)
        tmp.Visible = True
        tmp.Update()
    End Sub

    Private Sub ActiveDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiveDocumentToolStripMenuItem.Click
        Dim RetValBool As Boolean
        Dim CurDocum As Autodesk.AutoCAD.Interop.AcadDocument
        Dim FileName As String = ""
        Dim Path2File As String = ""
        Dim Path2Folder As String = ""
        Dim KitchName As String
        'Dim CurPrj As ProjOne = GlbData.GlbActiveProject
        'GlbData.GlbData_Ini(GlbData.GlbMainUc)
        'GlbData.GlbActiveProject = CurPrj
        GlbData.GlbData_Refresh()
        CurDocum = GlbData.GlbAcadApp.ActiveDocument()
        If CurDocum Is Nothing Then
            MsgBox("Cannot find active document")
            Exit Sub
        End If

        Path2Folder = CurDocum.Path
        FileName = CurDocum.Name

        '    FileName = GlbData.GlbSrvFunc.ParcelFullPath(Path2File, Path2Folder)
        GlbData.GlbSrvFunc.AddSlash2Path(Path2Folder)

        'Check is Header File Existed
        If System.IO.File.Exists(Path2Folder & "ProjHead.txt") = False Then
            MsgBox("Active Document is not a valid Nachshon Kitchen")
            Exit Sub
        End If

        'Load Project Object 
        GlbData.GlbActiveProject.Path2Folder = Path2Folder
        RetValBool = GlbData.GlbActiveProject.Read2File()
        If RetValBool = False Then
            MsgBox("Error on loading Project File:" & Path2Folder & "ProjHead.txt")
            Exit Sub
        End If
        Dim dm As DocumentCollection = Application.DocumentManager()
        'If GlbData.GlbSrvArx IsNot Nothing AndAlso GlbData.GlbSrvArx.ActiveDoc IsNot Nothing Then
        '    RemoveHandler dm.DocumentLockModeChanged, AddressOf GlbData.GlbSrvArx.vetoDeleteCommand
        'End If


        'Check whether document is Kitchen 
        GlbData.GlbActDoc = CurDocum
        GlbData.GlbSrvArx = New SrvObjectARX()
        'AddHandler dm.DocumentLockModeChanged, AddressOf GlbData.GlbSrvArx.vetoDeleteCommand
        GlbData.EmtySS = GlbData.GlbSrvArx.ActiveDoc.Editor.SelectImplied().Value
        Dim KitchPN As String = GlbData.GlbSrvFunc.GetFileProperty(GlbEnum.FilePropertNames.CustomProp_PartNumber)
        Dim KitchDesc As String = GlbData.GlbSrvFunc.GetFileProperty(GlbEnum.FilePropertNames.CustomProp_Description)
        Dim KitchNameHeb As String = GlbData.GlbSrvFunc.GetFileProperty(GlbEnum.FilePropertNames.CustomProp_DescriptionHeb)

        Dim Pos1 As Integer = FileName.LastIndexOf(".")
        KitchName = Mid(FileName, 1, Pos1)
        GlbData.GlbActiveKitchen.Kitch_Ini()
        GlbData.GlbActiveKitchen.PartNumb = KitchPN
        GlbData.GlbActiveKitchen.Name = KitchDesc
        GlbData.GlbActiveKitchen.NameHeb = KitchNameHeb
        GlbData.GlbMainUc.SetButtonsByMode(MainMenuButtonsMode.KitchenOk)

        GlbData.GlbAttrTempObj.LoadFromDB()
        GlbData.GlbAttrTempObj.LoadFromCustomProp()
        'Load Block List 
        GlbData.GlbBlocks.LoadBlocks()
        GlbData.GlbSrvArx.LoadPolyLines()

        GlbData.GlbKnumList = GlbData.GlbBlocks.GetListKnumForCombo()
        'GlbData.GlbAcadApp.ZoomExtents()
    End Sub

    Private Sub InfoToolStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoToolStrip.Click
        If (Me.UC_List("UC_Information") Is Nothing) Then
            Me.UC_List.Add("UC_Information", New UC_Information())
        End If
        Dim tmp As UC_Information = Me.UC_List("UC_Information")

        tmp.LoadInEditMode()
        HideControlsInPanel()
        Me.pnlMain.Controls.Add(tmp)
        tmp.Visible = True
        tmp.Update()
    End Sub

    Private Sub Group_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Group.Click
        If (Me.UC_List("UC_Groups") Is Nothing) Then
            Me.UC_List.Add("UC_Groups", New UC_Groups())
        End If
        Dim tmp As UC_Groups = Me.UC_List("UC_Groups")
        tmp.LoadInEditMode()
        HideControlsInPanel()
        Me.pnlMain.Controls.Add(tmp)
        tmp.Visible = True
        tmp.Update()
    End Sub

    Public Sub NumeringToolStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumeringToolStrip.Click
        Dim RetValBool As Boolean
        Me.ActiveDocumentToolStripMenuItem_Click(New Object, New System.EventArgs)
        'Close All UC
        HideControlsInPanel()

        'Visible Progress Bar 
        Me.lblProgBar.Show()
        Me.lblProgBar.Visible = True
        Me.lblProgBar.Text = "Numbering: Loading Blocks..."
        Me.lblProgBar.Update()
        Me.ProgBar.Show()
        Me.ProgBar.Update()
        

        'ReLoad Blocks
        GlbData.GlbBlocks.Clear()
        RetValBool = GlbData.GlbBlocks.LoadBlocks()
        Me.ProgBar.Value = 10
        Me.ProgBar.Update()

        For Each grp As Group In GlbData.GlbGroups
            grp.SetQntColl()
        Next
        Me.ProgBar.Value = 15
        Me.ProgBar.Update()

        'Clear KNUM Attribute Value 
        'GlbData.GlbBlocks.Clear_KNUM()

        'Set to Same Blocks Sequence Number 
        Me.lblProgBar.Text = "Numbering: Classification by Type..."
        Me.lblProgBar.Update()
        GlbData.GlbBlocks.SetPrevKnum(Me.ProgBar) ' Progbar 15-35

        'Reset Flag Used for Each Block
        GlbData.GlbBlocks.ResetFlagUsed()

        'Set Last Letter to KNUM by Group 
        'GlbData.GlbBlocks.SetResultKnum() ' was canceled due to new numbering system (SZ - 14/7/2011)
        GlbData.GlbBlocks.SetResultKnum2(Me.ProgBar) ' Progbar 35-95


        'Save Blocks KNUM into File
        Me.lblProgBar.Text = "Numbering: Update in Drawing..."
        Me.lblProgBar.Update()
        GlbData.GlbBlocks.UpdateKnumInAcad(Me.ProgBar) ' ProgBar 95-100
        GlbData.GlbKnumList = GlbData.GlbBlocks.GetListKnumForCombo()

        'Set "Command:" in next line
        Dim SrvArx As New SrvObjectARX
        SrvArx.FinishAction()

        'For Each s As String In GlbData.GlbKnumList
        'Me.Cmbtst.Items.Add(s)
        'Next

        Me.lblProgBar.Text = ""
        Me.lblProgBar.Visible = False
        Me.lblProgBar.Update()
        'Open UC  Panels 
        If (Me.UC_List("UC_Numering") Is Nothing) Then
            Me.UC_List.Add("UC_Numering", New UC_Numering())
        End If
        Dim tmp As UC_Numering = Me.UC_List("UC_Numering")

        'tmp.LoadInEditMode()
        HideControlsInPanel()
        Me.pnlMain.Controls.Add(tmp)
        tmp.Visible = True
        tmp.Update()
        tmp.LoadInEditMode()
        ' Me.Cmbtst.Items.AddRange(GlbData.GlbKnumList.ToArray())
        Me.ProgBar.Value = 0
        Me.ProgBar.Hide()
        Me.ProgBar.Update()

    End Sub

    Private Sub InsertBlockStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertBlockStripDropDownButton1.Click
        Me.Obs = New BlockLibs()
        If Me.InsertBlockStripDropDownButton1.DropDownItems.Count = Obs.ParentList.Count Then
            Exit Sub
        End If
        For Each Bo As BlockLib In Obs.ParentList
            Me.InsertBlockStripDropDownButton1.DropDownItems.Add(Bo.FormName)
        Next
        Me.InsertBlockStripDropDownButton1.ShowDropDown()
    End Sub

    Private Sub InsertBlockStripDropDownButton1_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles InsertBlockStripDropDownButton1.DropDownItemClicked
        Dim Fname As String = e.ClickedItem.Text
        Dim curBo As BlockLib = Me.Obs.GetBoByFname(Fname)
        If Not curBo.IsParent Then
            Me.LoadBlockTbl(curBo.FormName)
            Me.CurCategory = curBo.FormName
            Exit Sub
        End If
        Dim childBo As BlockLib
        Dim ddi As ToolStripDropDownItem = e.ClickedItem
        If curBo.UnderObjList.Count = ddi.DropDownItems.Count Then
            Exit Sub
        End If
        For Each id As Integer In curBo.UnderObjList
            childBo = Obs.GetBoById(id)
            'childBo = Obs.GetBoByFname(curBo.Code)
            With ddi.DropDownItems.Add(childBo.FormName)
                AddHandler .Click, AddressOf Smenu_Click
            End With
            Dim DrwName As String = childBo.FormName.Substring(0, 2) & "2D.dwg"

            If Not System.IO.File.Exists(GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Catag) & DrwName) Then
                ddi.DropDownItems.Item(ddi.DropDownItems.Count - 1).Enabled = False
            End If
        Next
        ddi.ShowDropDown()
    End Sub

    Sub Smenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim n As String = CType(sender, ToolStripItem).Text
        Me.CurCategory = n
        Me.LoadBlockTbl(n)
    End Sub

    Private Sub LoadBlockTbl(ByVal CatTxt As String)
        Dim attsObj As New BlockAttribOne
        Dim AttSet As New BlockAttSet
        For Each Aset As BlockAttSet In GlbData.GlbLoadedBlockSets
            If Not CatTxt.StartsWith(Aset.SetName) Then
                Continue For
            End If
            AttSet = Aset
        Next
        If AttSet.SetName.Length < 1 Or AttSet.BlockAtts.Count < 1 Then
            AttSet = Me.CollectAttributes()
        End If
        Dim ImgF() As String
        Try
            ImgF = System.IO.Directory.GetFiles(My.Settings.Path2Catag & AttSet.SetName & "_IMG")
        Catch ex As System.Exception
            MsgBox("image file is missing")
            ImgF = Nothing
        End Try

        Dim Btlb As New BlockTbl
        Application.ShowModelessDialog(Application.MainWindow.Handle, Btlb, False)
        Btlb.GenerateTbl(AttSet.BlockAtts, ImgF)

    End Sub

    Private Function CollectAttributes() As BlockAttSet
        Dim attsObj As New BlockAttribOne
        Dim AttSet As New BlockAttSet
        'Dim atts As AttributeCollection
        'Dim AttRef As AttributeReference
        GlbSrvFunc.AddSlash2Path(My.Settings.Path2Catag)
        Dim DrwName As String = Me.CurCategory.Substring(0, 2) & "2D.dwg"
        Dim sourceDb As Database = New Database(False, True)
        sourceDb.ReadDwgFile(My.Settings.Path2Catag & DrwName, System.IO.FileShare.Read, _
                                True, "")
        Dim blockIds As ObjectIdCollection = New ObjectIdCollection()
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = sourceDb.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()
        Dim obj As DBObject
        Dim Bt As BlockTable = CType(tm.GetObject(sourceDb.BlockTableId, OpenMode.ForRead, False), BlockTable)
        Dim btr As BlockTableRecord
        Dim msbtr As BlockTableRecord = tm.GetObject(Bt.Item(BlockTableRecord.ModelSpace), OpenMode.ForRead)
        For Each btrId As ObjectId In Bt
            btr = CType(tm.GetObject(btrId, OpenMode.ForRead, False), BlockTableRecord)
            If (Not btr.IsAnonymous And Not btr.IsLayout And btr.HasAttributeDefinitions And _
                            btr.Name.StartsWith(Me.CurCategory.Substring(0, 2))) Then
                attsObj = New BlockAttribOne
                attsObj.BlockName = btr.Name
                For Each id As ObjectId In btr
                    obj = tr.GetObject(id, OpenMode.ForRead)
                    Dim ad As AttributeDefinition = TryCast(obj, AttributeDefinition)
                    If ad IsNot Nothing AndAlso Not ad.Constant Then
                        Select Case ad.Tag
                            Case "KNAM_H"
                                attsObj.AttribName = ad.TextString
                            Case "KMID_L"
                                attsObj.AttribLength = ad.TextString
                            Case "KMID_H"
                                attsObj.Attribheight = ad.TextString
                            Case "KMID_W"
                                attsObj.AttribWidth = ad.TextString
                            Case "KELC_HP"
                                attsObj.AttribHorse = ad.TextString
                            Case "KELC_KW"
                                attsObj.AttribPower = ad.TextString
                        End Select

                    End If
                Next
                AttSet.BlockAtts.Add(attsObj)
            End If

            btr.Dispose()
        Next

        tr.Dispose()
        AttSet.SetName = Me.CurCategory.Substring(0, 2)
        GlbData.GlbLoadedBlockSets.Add(AttSet)
        Return AttSet
    End Function

    Private Sub Attributes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Attributes.Click
        If (Me.UC_List("UC_Attributes_2") Is Nothing) Then
            Me.UC_List.Add("UC_Attributes_2", New UC_Attributes_2())
        End If
        Dim tmp As UC_Attributes_2 = Me.UC_List("UC_Attributes_2")

        'tmp.LoadInEditMode()
        HideControlsInPanel()
        Me.pnlMain.Controls.Add(tmp)
        tmp.Visible = True
        tmp.Update()
        tmp.LoadInEditMode()
        'Me.ChangeMenu(New UC_Attributes())
    End Sub

    Private Sub CloseUCAll()
        Dim ch As Integer

        For ch = 1 To Me.UC_List.Count
            If Me.UC_List.Item(ch).Visible = True Then
                Me.UC_List.Item(ch).Visible = False
            End If
        Next ch
    End Sub

    Private Sub ClsProjToolStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClsProjToolStrip.Click
        Try
            If GlbData.GlbAcadApp.ActiveDocument Is Nothing Then
                Exit Sub
            End If
        Catch ex As System.Exception
            Exit Sub
        End Try

        If GlbData.GlbActDoc Is Nothing OrElse GlbData.GlbActDoc.Path Is Nothing Then
            Exit Sub
        End If
        GlbData.GlbActDoc.Save()
        GlbData.GlbActDoc.Close()
        GlbData.GlbData_Ini(Me)
        Me.SetButtonsByMode(GlbEnum.MainMenuButtonsMode.StartMode)
        HideControlsInPanel()
        GlbData.GlbActDoc = Nothing
        'For Each item As Object In Me.UC_List
        'item.close()
        'Next
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocManagerToolStrip.Click
        'Redo Numbering
        If MsgBox("Perform Numbering?", MsgBoxStyle.YesNo, "Ksoft") = MsgBoxResult.Yes Then
            Me.NumeringToolStrip_Click(New Object, New System.EventArgs)
        End If

        GlbData.GlbBlocks.SortByKNum()

        If (Me.UC_List("UC_BomList") Is Nothing) Then
            Me.UC_List.Add("UC_BomList", New UC_BomList())
        End If
        Dim tmp As UC_BomList = Me.UC_List("UC_BomList")
        tmp.LoadInEditMode()
        tmp.SetMode(ListUcMode.ListCreation)
        HideControlsInPanel()
        Me.pnlMain.Controls.Add(tmp)
        tmp.Visible = True
        tmp.Update()
    End Sub

    Private Sub UpdateDrawingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateDrawingToolStripMenuItem.Click
        Me.ActiveDocumentToolStripMenuItem_Click(New Object, New System.EventArgs)
    End Sub

    Private Sub CopyBlockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyBlockToolStripMenuItem.Click
        GlbData.GlbSrvArx.CopyEnts()
    End Sub

    Private Sub DeleteBlocksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBlocksToolStripMenuItem.Click
        GlbData.GlbSrvArx.DeleteEnts()
    End Sub

    Private Sub ConvertSelectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConvertSelectionToolStripMenuItem.Click
        GlbData.GlbSrvArx.ConvertSelected2D3D(False)
    End Sub

    Private Sub ConvertAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConvertAllToolStripMenuItem.Click
        GlbData.GlbSrvArx.ConvertSelected2D3D(True)
    End Sub

    Private Sub DeactivateDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeactivateDocumentToolStripMenuItem.Click
        If GlbData.GlbActDoc Is Nothing OrElse GlbData.GlbActDoc.Path Is Nothing Then
            Exit Sub
        End If
        Dim Path2Kitchen As String
        Path2Kitchen = GlbData.GlbActDoc.Path & "\" & GlbData.GlbActDoc.Name
        GlbData.GlbAcadApp.Documents.Open(Path2Kitchen, True)
        'Dim path As String = GlbData.GlbActDoc.Path
        'GlbData.GlbActDoc.Save()
        'GlbData.GlbActDoc.Close()
        'GlbData.GlbData_Ini(Me)
        'Me.SetButtonsByMode(GlbEnum.MainMenuButtonsMode.StartMode)
        'HideControlsInPanel()
    End Sub

    Private Sub SaveDrawingAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDrawingAsToolStripMenuItem.Click
        Dim NewDocName As String = ""

        Me.SaveFileDialog1.CheckFileExists = False
        Me.SaveFileDialog1.CheckPathExists = False
        Me.SaveFileDialog1.FileName = ""
        Try
            Me.SaveFileDialog1.InitialDirectory = GlbData.GlbActiveProject.Path2Folder
        Catch
            Me.SaveFileDialog1.InitialDirectory = System.Environment.CurrentDirectory
        End Try

        Me.SaveFileDialog1.Title = "Select Drawing As. . ."
        Me.SaveFileDialog1.DefaultExt = ".dwg"
        Me.SaveFileDialog1.Filter = "Drawing Files (*.dwg) | *.*"
        Dim DK As System.Windows.Forms.DialogResult = Me.SaveFileDialog1.ShowDialog()
        If (DK = DialogResult.OK) Then
            If Not (String.IsNullOrEmpty(Me.SaveFileDialog1.FileName)) Then
                NewDocName = Me.SaveFileDialog1.FileName
                GlbData.GlbActDoc.SaveAs(NewDocName)
            Else
                MsgBox("Wrong File Name")
            End If
        End If
    End Sub

    Private Sub SaveDrawingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDrawingToolStripMenuItem.Click
        GlbData.GlbActDoc.Save()
    End Sub
End Class

