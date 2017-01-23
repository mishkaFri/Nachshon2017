Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic


Public Class UC_InsertBlock
    Private _Obs As BlockLibs

#Region "Properties"
    Public Property Obs() As BlockLibs
        Get
            Return _Obs
        End Get
        Set(ByVal value As BlockLibs)
            _Obs = value
        End Set
    End Property
#End Region


    '    Private Sub BlockToolStripDropDownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.Obs = New BlockLibs()
    '        If Me.BlockToolStripDropDownButton.DropDownItems.Count = Obs.ParentList.Count Then
    '            Exit Sub
    '        End If
    '        For Each Bo As BlockLib In Obs.ParentList
    '            Me.BlockToolStripDropDownButton.DropDownItems.Add(Bo.FormName)
    '        Next
    '        Me.BlockToolStripDropDownButton.ShowDropDown()
    '    End Sub



    ''Private Sub BlockToolStripDropDownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Me.Obs = New BlockLibs()
    ''    If Me.BlockToolStripDropDownButton.DropDownItems.Count = Obs.ParentList.Count Then
    ''        Exit Sub
    ''    End If
    ''    For Each Bo As BlockLib In Obs.ParentList
    ''        Me.BlockToolStripDropDownButton.DropDownItems.Add(Bo.FormName)
    ''    Next
    ''    Me.BlockToolStripDropDownButton.ShowDropDown()
    ''End Sub

    '        Next
    '        ddi.ShowDropDown()
    '    End Sub


    ''Private Sub BlockToolStripDropDownButton_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
    ''    Dim Fname As String = e.ClickedItem.Text
    ''    Dim curBo As BlockLib = Me.Obs.GetBoByFname(Fname)
    ''    If Not curBo.IsParent Then
    ''        Me.btnCurrCategory.Text = curBo.FormName
    ''        Exit Sub
    ''    End If
    ''    Dim childBo As BlockLib
    ''    Dim ddi As ToolStripDropDownItem = e.ClickedItem
    ''    If curBo.UnderObjList.Count = ddi.DropDownItems.Count Then
    ''        Exit Sub
    ''    End If
    ''    For Each id As Integer In curBo.UnderObjList
    ''        childBo = Obs.GetBoById(id)
    ''        With ddi.DropDownItems.Add(childBo.FormName)
    ''            AddHandler .Click, AddressOf Smenu_Click
    ''        End With

    ''    Next
    ''    ddi.ShowDropDown()
    ''End Sub

    '    Private Sub BlockToolStripDropDownButton_DropDownItemClicked1(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
    '        Dim Fname As String = e.ClickedItem.Text
    '        Dim curBo As BlockLib = Me.Obs.GetBoByFname(Fname)
    '        If Not curBo.IsParent Then
    '            Me.LoadBlockTbl(curBo.FormName)
    '            Me.btnCurrCategory.Text = curBo.FormName
    '            Exit Sub
    '        End If
    '        Dim childBo As BlockLib
    '        Dim ddi As ToolStripDropDownItem = e.ClickedItem
    '        If curBo.UnderObjList.Count = ddi.DropDownItems.Count Then
    '            Exit Sub
    '        End If
    '        For Each id As Integer In curBo.UnderObjList
    '            childBo = Obs.GetBoById(id)
    '            With ddi.DropDownItems.Add(childBo.FormName)
    '                AddHandler .Click, AddressOf Smenu_Click
    '            End With

    ''Sub Smenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    Dim n As String = CType(sender, ToolStripItem).Text
    ''    Me.btnCurrCategory.Text = n
    ''    Me.LoadBlockTbl(n)
    ''End Sub

    '                    End If
    '                Next
    '                AttSet.BlockAtts.Add(attsObj)
    '            End If

    ''Private Sub BlockToolStripDropDownButton_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    Me.Obs = New BlockLibs()
    ''    If Me.BlockToolStripDropDownButton.DropDownItems.Count = Obs.ParentList.Count Then
    ''        Exit Sub
    ''    End If
    ''    For Each Bo As BlockLib In Obs.ParentList
    ''        Me.BlockToolStripDropDownButton.DropDownItems.Add(Bo.FormName)
    ''    Next
    ''    Me.BlockToolStripDropDownButton.ShowDropDown()
    ''End Sub

    ''Private Sub BlockToolStripDropDownButton_DropDownItemClicked1(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
    ''    Dim Fname As String = e.ClickedItem.Text
    ''    Dim curBo As BlockLib = Me.Obs.GetBoByFname(Fname)
    ''    If Not curBo.IsParent Then
    ''        Me.LoadBlockTbl(curBo.FormName)
    ''        Me.btnCurrCategory.Text = curBo.FormName
    ''        Exit Sub
    ''    End If
    ''    Dim childBo As BlockLib
    ''    Dim ddi As ToolStripDropDownItem = e.ClickedItem
    ''    If curBo.UnderObjList.Count = ddi.DropDownItems.Count Then
    ''        Exit Sub
    ''    End If
    ''    For Each id As Integer In curBo.UnderObjList
    ''        childBo = Obs.GetBoById(id)
    ''        With ddi.DropDownItems.Add(childBo.FormName)
    ''            AddHandler .Click, AddressOf Smenu_Click
    ''        End With

    ''    Next
    ''    ddi.ShowDropDown()
    ''End Sub
    ''Private Function CollectAttributes() As BlockAttSet
    ''    Dim attsObj As New BlockAttribOne
    ''    Dim AttSet As New BlockAttSet
    ''    'Dim atts As AttributeCollection
    ''    'Dim AttRef As AttributeReference
    ''    GlbSrvFunc.AddSlash2Path(My.Settings.Path2Catag)
    ''    Dim DrwName As String = Me.btnCurrCategory.Text.Substring(0, 2) & "2D.dwg"
    ''    Dim sourceDb As Database = New Database(False, True)
    ''    sourceDb.ReadDwgFile(My.Settings.Path2Catag & DrwName, System.IO.FileShare.Read, _
    ''                            True, "")
    ''    Dim blockIds As ObjectIdCollection = New ObjectIdCollection()
    ''    Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = sourceDb.TransactionManager
    ''    Dim tr As Transaction = tm.StartTransaction()
    ''    Dim obj As DBObject
    ''    Dim Bt As BlockTable = CType(tm.GetObject(sourceDb.BlockTableId, OpenMode.ForRead, False), BlockTable)
    ''    Dim btr As BlockTableRecord
    ''    Dim msbtr As BlockTableRecord = tm.GetObject(Bt.Item(BlockTableRecord.ModelSpace), OpenMode.ForRead)
    ''    For Each btrId As ObjectId In Bt
    ''        btr = CType(tm.GetObject(btrId, OpenMode.ForRead, False), BlockTableRecord)
    ''        If (Not btr.IsAnonymous And Not btr.IsLayout And btr.HasAttributeDefinitions And _
    ''                        btr.Name.StartsWith(Me.btnCurrCategory.Text.Substring(0, 2))) Then
    ''            attsObj = New BlockAttribOne
    ''            attsObj.BlockName = btr.Name
    ''            For Each id As ObjectId In btr
    ''                obj = tr.GetObject(id, OpenMode.ForRead)
    ''                Dim ad As AttributeDefinition = TryCast(obj, AttributeDefinition)
    ''                If ad IsNot Nothing AndAlso Not ad.Constant Then
    ''                    Select Case ad.Tag
    ''                        Case "KNAM_E"
    ''                            attsObj.AttribName = ad.TextString
    ''                        Case "KMID_L"
    ''                            attsObj.AttribLength = ad.TextString
    ''                        Case "KMID_H"
    ''                            attsObj.Attribheight = ad.TextString
    ''                        Case "KMID_W"
    ''                            attsObj.AttribWidth = ad.TextString
    ''                    End Select

    ''                End If
    ''            Next
    ''            AttSet.BlockAtts.Add(attsObj)
    ''        End If

    ''        btr.Dispose()
    ''    Next
    ''    'For Each brefId As ObjectId In msbtr
    ''    '    obj = tm.GetObject(brefId, OpenMode.ForRead)
    ''    '    If Not TypeOf obj Is BlockReference Then
    ''    '        Continue For
    ''    '    End If
    ''    '    Dim blkref As BlockReference = obj
    ''    '    If blkref.Name.StartsWith("*") Then
    ''    '        Continue For
    ''    '    End If
    ''    '    atts = blkref.AttributeCollection
    ''    '    attsObj = New BlockAttribOne
    ''    '    attsObj.BlockName = blkref.Name
    ''    '    For Each AttId As ObjectId In atts
    ''    '        AttRef = CType(tr.GetObject(AttId, OpenMode.ForRead), AttributeReference)
    ''    '        Select Case AttRef.Tag
    ''    '            Case "KNAM_E"
    ''    '                attsObj.AttribName = AttRef.TextString
    ''    '            Case "KMID_L"
    ''    '                attsObj.AttribLength = AttRef.TextString
    ''    '            Case "KMID_H"
    ''    '                attsObj.Attribheight = AttRef.TextString
    ''    '            Case "KMID_W"
    ''    '                attsObj.AttribWidth = AttRef.TextString
    ''    '        End Select
    ''    '    Next
    ''    '    AttSet.BlockAtts.Add(attsObj)
    ''    'Next
    ''    tr.Dispose()
    ''    AttSet.SetName = Me.btnCurrCategory.Text.Substring(0, 2)
    ''    GlbData.GlbLoadedBlockSets.Add(AttSet)
    ''    Return AttSet
    ''End Function
    ''Private Sub LoadBlockTbl(ByVal CatTxt As String)
    ''    Dim attsObj As New BlockAttribOne
    ''    Dim AttSet As New BlockAttSet
    ''    For Each Aset As BlockAttSet In GlbData.GlbLoadedBlockSets
    ''        If Not CatTxt.StartsWith(Aset.SetName) Then
    ''            Continue For
    ''        End If
    ''        AttSet = Aset
    ''    Next
    ''    If AttSet.SetName.Length < 1 Or AttSet.BlockAtts.Count < 1 Then
    ''        AttSet = Me.CollectAttributes()
    ''    End If

    ''    Dim ImgF() As String = System.IO.Directory.GetFiles(My.Settings.Path2Catag & AttSet.SetName & "_IMG")
    ''    Dim Btlb As New BlockTbl
    ''    Application.ShowModelessDialog(Application.MainWindow, Btlb)
    ''    Btlb.GenerateTbl(AttSet.BlockAtts, ImgF)

    ''End Sub

    '' Currently disabled

    ''Private Sub btnCurrCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Dim attsObj As New BlockAttribOne
    ''    Dim AttSet As New BlockAttSet
    ''    For Each Aset As BlockAttSet In GlbData.GlbLoadedBlockSets
    ''        If Not Me.btnCurrCategory.Text.StartsWith(Aset.SetName) Then
    ''            Continue For
    ''        End If
    ''        AttSet = Aset
    ''    Next
    ''    If AttSet.SetName = String.Empty Then
    ''        AttSet = Me.CollectAttributes()
    ''    End If

    ''    Dim ImgF() As String = System.IO.Directory.GetFiles(My.Settings.Path2Catag & AttSet.SetName & "_IMG")
    ''    Dim Btlb As New BlockTbl
    ''    Application.ShowModelessDialog(Application.MainWindow, Btlb)
    ''    Btlb.GenerateTbl(AttSet.BlockAtts, ImgF)

    ''End Sub

    '            Case 2   'Attributes

    '            Case 3   'Sub Assembly

    '            Case 4   'BOM

    '            Case 5   'Reserve


    '        End Select

    '    End Sub






    Private Sub btnAcadSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcadSel.Click
        Dim BlockOnes As New List(Of BlockRefOne)
        Dim ch As Integer
        Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        Dim res As PromptSelectionResult = ed.SelectImplied()
        If res.Status = PromptStatus.Error Then Return
        Dim SS As Autodesk.AutoCAD.EditorInput.SelectionSet = res.Value
        Dim idarray As ObjectId() = SS.GetObjectIds()
        Dim CurBlock As BlockRefOne = Nothing
        Dim FoundBlock As BlockRefOne = Nothing

        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        tm = db.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()

        Dim id As ObjectId
        For Each id In idarray
            Dim ent As Entity = tr.GetObject(id, OpenMode.ForRead)

            If ent IsNot Nothing AndAlso TypeOf ent Is BlockReference Then
                Dim CurBlockRef As BlockReference = CType(ent, BlockReference)
                If GlbData.GlbBlocks.BlockList Is Nothing Then
                    Exit Sub
                End If

                FoundBlock = Nothing
                For ch = 1 To GlbData.GlbBlocks.BlockList.Count
                    CurBlock = GlbData.GlbBlocks.BlockList.Item(ch)
                    If CurBlock.BlockObj.ObjectId.GetHashCode() = CurBlockRef.ObjectId.GetHashCode() Then
                        FoundBlock = CurBlock
                        Exit For
                    End If
                Next ch
            End If

            If FoundBlock IsNot Nothing Then
                BlockOnes.Add(FoundBlock)
            End If

        Next id
        tr.Dispose()

        If BlockOnes.Count < 1 Then
            Exit Sub
        End If

        Dim CurAttWork As ClsAttWork = New ClsAttWork(BlockOnes)
        Dim Atbl As New AttributeTlb(CurAttWork, False)
        Application.ShowModelessDialog(Application.MainWindow.Handle, Atbl)
    End Sub

    Private Sub cmbKnumList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbKnumList.Click
        Dim ch As Integer

        If GlbData.GlbKnumList Is Nothing Then
            Exit Sub
        End If

        Me.cmbKnumList.Items.Clear()

        For ch = 0 To GlbData.GlbKnumList.Count - 1
            Me.cmbKnumList.Items.Add(GlbData.GlbKnumList.Item(ch))
        Next ch

    End Sub

   
End Class
