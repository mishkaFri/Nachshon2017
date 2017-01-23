Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.ApplicationServices.DocumentCollectionExtension
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic
'Imports Autodesk.AutoCAD.Windows.OPM
'Imports System.Runtime.InteropServices
'Imports System.Reflection
'Imports System
'Imports DrawOverrules

Public Class SrvObjectARX
    Private _ActiveDoc As Document
    Private _ActiveDocDB As Database

#Region "Properties"

    Public Property ActiveDoc() As Document
        Get
            Return _ActiveDoc
        End Get
        Set(ByVal value As Document)
            _ActiveDoc = value
        End Set

    End Property

    Public Property ActiveDocDB() As Database
        Get
            Return _ActiveDocDB
        End Get
        Set(ByVal value As Database)
            _ActiveDocDB = value
        End Set
    End Property

#End Region

    Public Sub New()
        Me.ActiveDoc = Application.DocumentManager.MdiActiveDocument
        If Me.ActiveDoc = Nothing Then
            Exit Sub
        End If
        Me.ActiveDocDB = Me.ActiveDoc.Database
    End Sub

    Public Sub ImportOleXL(ByVal Fname As String)
        'Dim ppr As PromptPointResult = Me.ActiveDoc.Editor.GetPoint("\nEnter table insertion point: ")

        'If ppr.Status <> PromptStatus.OK Then
        '    Exit Sub
        'End If

        Dim xlApp As New ExcelManager(Fname, False)
        If xlApp.ObjExcelWorkSheet Is Nothing Then
            Exit Sub
        End If


        Dim rng As Microsoft.Office.Interop.Excel.Range = xlApp.SelectALL()
        If rng.Rows.Count < 3 Then
            Exit Sub
        End If
        rng.Copy()
        GlbData.GlbActDoc.SendCommand("pasteclip " & vbCrLf)
        xlApp.CloseFile()
        Me.FinishAction()

    End Sub

    Public Sub ImportXL(ByVal Fname As String, ByVal XLType As String)

        Dim ppr As PromptPointResult = Me.ActiveDoc.Editor.GetPoint("\nEnter table insertion point: ")

        If ppr.Status <> PromptStatus.OK Then
            Exit Sub
        End If
        Const dlname As String = "XLink" 'GlbData.GlbActiveKitchen.PartNumb & "_" & XLType


        Dim dlm As DataLinkManager = Me.ActiveDocDB.DataLinkManager
        Dim dlId As ObjectId = dlm.GetDataLink(dlname)
        If dlId <> ObjectId.Null Then
            dlm.RemoveDataLink(dlId)
        End If


        '/ Create and add the Data Link

        Dim dl As DataLink = New DataLink()
        dl.DataAdapterId = "AcExcel"
        dl.Name = dlname
        dl.Description = "Excel fun with Through the Interface"
        dl.ConnectionString = Fname
        dl.DataLinkOption = DataLinkOption.PersistCache
        dl.UpdateOption = CInt(UpdateOption.AllowSourceUpdate)
        dlId = dlm.AddDataLink(dl)

        Dim tr As Transaction = Me.ActiveDoc.TransactionManager.StartTransaction()
        Using (tr)
            tr.AddNewlyCreatedDBObject(dl, True)
            Dim bt As BlockTable = CType(tr.GetObject(Me.ActiveDocDB.BlockTableId, OpenMode.ForRead), BlockTable)
            Dim tb As Table = New Table()
            tb.TableStyle = Me.ActiveDocDB.Tablestyle
            tb.Position = ppr.Value
            tb.SetDataLink(0, 0, dlId, True)
            tb.GenerateLayout()
            Dim btr As BlockTableRecord = CType(tr.GetObject(Me.ActiveDocDB.CurrentSpaceId, OpenMode.ForWrite), BlockTableRecord)
            btr.AppendEntity(tb)
            tr.AddNewlyCreatedDBObject(tb, True)
            tr.Commit()
        End Using
        Me.ActiveDoc.Editor.Regen()

    End Sub

    Public Function GetBlockRealName(ByRef BlockReference As Autodesk.AutoCAD.DatabaseServices.BlockReference) As String
        Me.ActiveDoc.LockDocument()
        Dim tr As Autodesk.AutoCAD.DatabaseServices.Transaction = Me.ActiveDocDB.TransactionManager.StartTransaction()
        Dim Block As New BlockTableRecord
        Dim ret_name As String = ""
        Block = CType(tr.GetObject(BlockReference.DynamicBlockTableRecord, OpenMode.ForRead, False), BlockTableRecord)
        If Block Is Nothing Then
            ret_name = ""
        Else
            ret_name = Block.Name
        End If

        Block.Dispose()
        tr.Dispose()
        Return ret_name
    End Function

    Public Function ApplyAttributeDef(ByRef BlockReference As Autodesk.AutoCAD.DatabaseServices.BlockReference, _
                                      ByVal CurAtt As AttribTemplateOne, _
                                      ByVal formValue As Boolean) As Boolean
        Me.ActiveDoc.LockDocument()
        Dim tr As Autodesk.AutoCAD.DatabaseServices.Transaction = Me.ActiveDocDB.TransactionManager.StartTransaction()
        Dim bt As BlockTable = CType(tr.GetObject(Me.ActiveDocDB.BlockTableId, OpenMode.ForRead, False), BlockTable)
        Dim Block As New BlockTableRecord
        For Each btrId As ObjectId In bt
            Try
                Block = CType(tr.GetObject(BlockReference.DynamicBlockTableRecord, OpenMode.ForRead, False), BlockTableRecord)
            Catch ex As Exception
                Block = CType(tr.GetObject(btrId, OpenMode.ForRead, False), BlockTableRecord)
            End Try

            Dim RealBlkName As String = BlockReference.Name
            If BlockReference.Name.Contains("*") Then
                RealBlkName = Me.GetBlockRealName(BlockReference)
            End If
            If (Not Block.IsAnonymous And Not Block.IsLayout And Block.Name = RealBlkName) Then 'BlockReference.Name) Then (SZ)
                Dim FormVal As String
                If formValue Then
                    FormVal = CurAtt.AttValue & "#" & CurAtt.Description & "#" & CurAtt.Unit & "#" _
                                   & CurAtt.ShowInBom & "#" & CurAtt.ShowInTender & "#" & CurAtt.Category
                Else
                    FormVal = CurAtt.AttValue
                End If

                Dim AttDefin As New AttributeDefinition(New Point3d(0, 0, 0), FormVal, CurAtt.Tag, CurAtt.Description, Me.ActiveDocDB.Textstyle)
                AttDefin.Invisible = True
                Block.UpgradeOpen()
                Dim AdId As ObjectId = Block.AppendEntity(CType(AttDefin, Entity))
                tr.AddNewlyCreatedDBObject(AttDefin, True)
                Block.DowngradeOpen()
                Exit For
            End If
        Next

        If Not Block.HasAttributeDefinitions Then Return False
        If Block.Database Is Nothing Then Return False

        If BlockReference.Database Is Nothing Then Block.Database.AddDBObject(BlockReference)

        For Each Id As ObjectId In Block
            Dim Ent As Entity = Id.GetObject(Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead)
            If TypeOf Ent Is AttributeDefinition Then
                Dim AttDef As AttributeDefinition = Ent
                If AttDef.Tag <> CurAtt.Tag Then Continue For
                Dim br As BlockReference = Me.GetWBref(bt, BlockReference.GetHashCode(), tr)
                Dim AttRef As New AttributeReference
                br.AttributeCollection.AppendAttribute(AttRef)
                AttRef.SetPropertiesFrom(AttDef)
                AttRef.SetAttributeFromBlock(AttDef, BlockReference.BlockTransform)
                AttRef.Invisible = True
                tr.AddNewlyCreatedDBObject(AttRef, True)
                AttDef.UpgradeOpen()
                AttDef.Erase()
            End If
        Next
        tr.Commit()

        tr.Dispose()
        Return True
    End Function

    Public Function GetWBref(ByVal Bt As BlockTable, ByVal Hash As Long, ByRef tr As Transaction) As BlockReference
        Dim msbtr As BlockTableRecord = tr.GetObject(Bt.Item(BlockTableRecord.ModelSpace), OpenMode.ForRead)
        Me.ActiveDoc.LockDocument()
        For Each id As ObjectId In msbtr
            Dim obj As DBObject = tr.GetObject(id, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite, False, True)
            Dim br As BlockReference = TryCast(obj, BlockReference)
            If br IsNot Nothing AndAlso br.GetHashCode() = Hash Then
                Return br
            End If
        Next
        Return Nothing
    End Function

    Public Function GetBtrFromBr(ByVal Br As BlockReference, ByVal tr As Transaction) As BlockTableRecord
        Dim bt As BlockTable = CType(tr.GetObject(Me.ActiveDocDB.BlockTableId, OpenMode.ForRead, False), BlockTable)
        Dim Block As New BlockTableRecord
        For Each btrId As ObjectId In bt
            Block = CType(tr.GetObject(btrId, OpenMode.ForRead, False), BlockTableRecord)
            If (Not Block.IsAnonymous And Not Block.IsLayout And Block.Name = Br.Name) Then
                Return Block
            End If
        Next
        Return Block
    End Function

    Public Function GetAttDefByAttRef(ByVal attref As AttributeReference, ByVal tr As Transaction) As AttributeDefinition
        Dim Block As BlockTableRecord = CType(tr.GetObject(attref.BlockId, OpenMode.ForRead), BlockTableRecord)
        For Each Id As ObjectId In Block
            Dim Ent As Entity = Id.GetObject(Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead)
            If TypeOf Ent Is AttributeDefinition Then
                Dim AttDef As AttributeDefinition = Ent
                If AttDef.Tag = attref.Tag Then
                    Return AttDef
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Function GetCommonAcadBr(ByVal ent As Entity) As AcadEntity

        For Each Br As AcadEntity In GlbData.GlbActDoc.Blocks.Item(0)
            If Not TypeOf Br Is AcadBlockReference And Not TypeOf Br Is AcadLWPolyline _
            And Not TypeOf Br Is AcadPolyline Then
                Continue For
            End If

            If Br.ObjectID = ent.ObjectId.GetHashCode Then
                Return Br
            End If

        Next

        Return Nothing
    End Function

    Public Function SetBrScale(ByVal Br As BlockReference, ByVal scale() As Double) As Boolean
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim KnumAtt As AttributeReference
        Dim h, w As Double
        Dim tr As Transaction = doc.TransactionManager.StartTransaction()
        Dim Oid As ObjectId

        If Me.DoesContainAttribute(tr, Br.AttributeCollection, "KNUM", Oid) Then
            KnumAtt = CType(tr.GetObject(Oid, OpenMode.ForWrite), AttributeReference)
        End If

        For i As Integer = 0 To 2
            scale(i) = Br.ScaleFactors.Coordinate(i) * scale(i)
        Next
        Dim Nonzero As Boolean = True
        For Each d As Double In scale
            If d <= 0 Then
                Nonzero = False
                Exit For
            End If
        Next
        If KnumAtt IsNot Nothing Then
            h = KnumAtt.Height
            w = KnumAtt.WidthFactor
        End If


        Dim ABr As AcadBlockReference = CType(Me.GetCommonAcadBr(Br), AcadBlockReference)
        If ABr IsNot Nothing AndAlso Nonzero Then
            ABr.XScaleFactor = scale(0)
            ABr.YScaleFactor = scale(1)
            ABr.ZScaleFactor = scale(2)
        End If
        If KnumAtt IsNot Nothing Then
            KnumAtt.Height = h
            KnumAtt.WidthFactor = w
        End If

        tr.Commit()
        tr.Dispose()
        Return True
    End Function

    Public Function StartBlJig(ByVal BName As String, _
                    Optional ByVal IsConv As Boolean = False, _
                    Optional ByVal InsPoint() As Double = Nothing, _
                    Optional ByVal RotAngle As Double = 0) As BlockReference
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ed As Editor = doc.Editor
        Dim db As Database = doc.Database
        Dim tr As Transaction = doc.TransactionManager.StartTransaction()
        Dim bt As BlockTable = CType(tr.GetObject(db.BlockTableId, OpenMode.ForRead), BlockTable)
        Dim Bl3DTmpNameA As String = BName.Substring(0, 7).Replace("-", "$") & "A"
        Dim Bl3DTmpNameB As String = BName.Substring(0, 7).Replace("-", "$") & "B"
        If Not bt.Has(BName) Then
            ' Check for 3D Parts
            If Not bt.Has(Bl3DTmpNameA) Then
                If Not bt.Has(Bl3DTmpNameB) Then
                    tr.Dispose()
                    Return Nothing
                Else
                    BName = Bl3DTmpNameB
                End If
            Else
                BName = Bl3DTmpNameA
            End If
        End If
        Dim space As BlockTableRecord = CType(tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite), BlockTableRecord)
        Dim btr As BlockTableRecord = CType(tr.GetObject(bt(BName), OpenMode.ForRead), BlockTableRecord)
        Dim br As BlockReference = New BlockReference(New Point3d(), btr.ObjectId)
        space.AppendEntity(br)
        tr.AddNewlyCreatedDBObject(br, True)
        Dim attInfo As Dictionary(Of ObjectId, AttInfo) = New Dictionary(Of ObjectId, AttInfo)
        If btr.HasAttributeDefinitions Then
            For Each id As ObjectId In btr
                Dim obj As DBObject = tr.GetObject(id, OpenMode.ForRead)
                Dim ad As AttributeDefinition = TryCast(obj, AttributeDefinition)
                If ad IsNot Nothing AndAlso Not ad.Constant Then
                    Dim ar As AttributeReference = New AttributeReference()
                    ar.SetAttributeFromBlock(ad, br.BlockTransform)
                    If ad.Justify <> AttachmentPoint.BaseLeft Then
                        ar.AlignmentPoint = ad.AlignmentPoint.TransformBy(br.BlockTransform)
                    End If
                    If ar.IsMTextAttribute Then
                        ar.UpdateMTextAttribute()
                    End If
                    ar.TextString = ad.TextString
                    Dim arid As ObjectId = br.AttributeCollection.AppendAttribute(ar)
                    tr.AddNewlyCreatedDBObject(ar, True)
                    attInfo.Add(arid, New AttInfo(ad.Position, ad.AlignmentPoint, ad.Justify <> AttachmentPoint.BaseLeft))
                End If
            Next
        End If

        If IsConv = True Then 'SZ 'Set coordinates for 3D Block
            Dim P3D As New Point3d(InsPoint)
            br.Position() = P3D
            br.Rotation = RotAngle
            tr.Commit()
            tr.Dispose()
            Return br
        End If

        Dim myJig As BlockJig = New BlockJig(tr, br, attInfo)
        If (myJig.Run() <> PromptStatus.OK) Then
            Return Nothing
        Else
            br.Layer = "0" ' Set Block layer to default  = 0
        End If
        tr.Commit()
        tr.Dispose()
        Return br

    End Function

    Public Function ImportBlock(ByVal Ablock As String, Optional ByVal Is3D As Boolean = False) As Boolean
        GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Catag)
        Dim btr As BlockTableRecord
        Dim mapping As IdMapping = New IdMapping()
        Dim dm As DocumentCollection = Application.DocumentManager
        Dim destDb As Database = dm.MdiActiveDocument.Database
        Dim sourceDb As Database = New Database(False, True)
        Dim BlockScale, Dir As String
        If Is3D Then 'SZ 'Check wether the imported block should be 3D
            BlockScale = "3D"
            Dir = "DWG3D\"
        Else
            BlockScale = "2D"
            Dir = ""
        End If
        Dim DrwName As String = Ablock.Substring(0, 2) & BlockScale & ".dwg"
        If Not IO.File.Exists(GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Catag) _
                             & Dir & DrwName) Then
            Return False
        End If
        sourceDb.ReadDwgFile(GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Catag) _
                            & Dir & DrwName, System.IO.FileShare.Read, True, "")
        Dim blockIds As ObjectIdCollection = New ObjectIdCollection()
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = sourceDb.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()
        Dim bt As BlockTable = CType(tm.GetObject(sourceDb.BlockTableId, OpenMode.ForRead, False), BlockTable)
        Dim Tmp3DName As String
        For Each btrId As ObjectId In bt
            btr = CType(tm.GetObject(btrId, OpenMode.ForRead, False), BlockTableRecord)
            If btr.Name.Length >= 7 Then
                Tmp3DName = btr.Name.Substring(0, 7).Replace("$", "-")
            Else
                Tmp3DName = btr.Name
            End If

            If (Not btr.IsAnonymous And Not btr.IsLayout And (btr.Name = Ablock Or Tmp3DName = Ablock.Substring(0, 7))) Then
                blockIds.Add(btrId)
                Exit For
            End If
            btr.Dispose()
        Next
        dm.MdiActiveDocument.LockDocument()
        Try
            sourceDb.WblockCloneObjects(blockIds, destDb.BlockTableId, mapping, 1, False)
        Catch ex As Exception
            Return False
        End Try
        tr.Dispose()
        Return True
    End Function

    Public Function SetBrAttVal(ByVal Br As BlockReference, ByVal value As String, ByVal tag As String) As Boolean
        If Not Me.ActiveDoc.LockMode() = DocumentLockMode.Write Then
            Me.ActiveDoc.LockDocument()
        End If

        If value Is Nothing Then
            value = ""
        End If
        Dim AttId As ObjectId
        Dim tr As Transaction = Me.ActiveDocDB.TransactionManager.StartTransaction()
        If tag Is Nothing Then Return False
        If GlbSrvArx.DoesContainAttribute(tr, Br.AttributeCollection, tag, AttId) Then
            Dim attRef As AttributeReference = CType(tr.GetObject(AttId, OpenMode.ForWrite), AttributeReference)
            attRef.TextString = value
            tr.Commit()
        Else
            Return False
        End If
        tr.Dispose()
        Return True
    End Function

    Public Function GetBrAttVal(ByVal Br As BlockReference, ByVal tag As String) As String
        If Not Me.ActiveDoc.LockMode() = DocumentLockMode.Write Then
            Me.ActiveDoc.LockDocument()
        End If
        Dim value As String = Nothing
        Dim AttId As ObjectId
        Dim tr As Transaction = Me.ActiveDocDB.TransactionManager.StartTransaction()
        If tag Is Nothing Then Return Nothing
        If GlbSrvArx.DoesContainAttribute(tr, Br.AttributeCollection, tag, AttId) Then
            Dim attRef As AttributeReference = CType(tr.GetObject(AttId, OpenMode.ForRead), AttributeReference)
            value = attRef.TextString
            tr.Commit()
        Else
            tr.Commit()
            tr.Dispose()
            Return Nothing
        End If
        tr.Dispose()
        Return value
    End Function

    Public Function DoesContainAttribute(ByRef tr As Transaction, ByVal ac As AttributeCollection, ByVal tag As String, ByRef oid As ObjectId) As Boolean
        'Dim tr As Transaction = Application.DocumentManager.MdiActiveDocument.Database.TransactionManager.StartTransaction()
        If Not Me.ActiveDoc.LockMode() = DocumentLockMode.Write Then
            Me.ActiveDoc.LockDocument()
        End If
        Dim attRef As AttributeReference = New AttributeReference()

        For Each AttId As ObjectId In ac
            attRef = CType(tr.GetObject(AttId, OpenMode.ForRead), AttributeReference)
            If attRef IsNot Nothing AndAlso attRef.Tag = tag Then
                'tr.Dispose()
                oid = AttId
                Return True
            End If
        Next
        'tr.Dispose()
        Return False

    End Function

    Public Function SetAcadAtt(ByVal Blocks As List(Of BlockRefOne), ByVal CurAttr As AttribTemplateOne) As Boolean
        If Blocks.Count < 1 Then
            Return False
        End If
        SetAcadAtt = False
        Dim Blk2Remove As New List(Of BlockRefOne)
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = db.TransactionManager

        Dim attRef As AttributeReference = New AttributeReference()
        'Dim bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForWrite, False), BlockTable)
        Dim AttId As ObjectId
        For Each bro As BlockRefOne In Blocks
            Dim tr As Transaction = db.TransactionManager.StartTransaction()

            If CurAttr.Tag Is Nothing Then Continue For
            If GlbSrvArx.DoesContainAttribute(tr, bro.BlockObj.AttributeCollection, CurAttr.Tag, AttId) Then
                Blk2Remove.Add(bro)
                attRef = CType(tr.GetObject(AttId, OpenMode.ForWrite), AttributeReference)

                If CurAttr.AttValue Is Nothing Then
                    attRef.TextString = ""
                    Continue For
                End If
                attRef.TextString = CurAttr.AttValue
            Else
                SetAcadAtt = True
                Dim tempA As AttribTemplateOne = bro.BlockAttrib.GetAttrByTag(CurAttr.Tag)
                Dim FormVal As Boolean = True
                If tempA IsNot Nothing OrElse CurAttr.Tag.StartsWith("AppGrp") Then
                    FormVal = False
                End If
                GlbData.GlbSrvArx.ApplyAttributeDef(bro.BlockObj, CurAttr, FormVal)
            End If
            tr.Commit()
            tr.Dispose()
        Next

        For Each bro As BlockRefOne In Blk2Remove
            Blocks.Remove(bro)
        Next

        'tr.Commit()


    End Function

    Public Function SetGrpXData(ByRef PolyList As List(Of Polyline), ByVal GrpNum As String) As Boolean
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        SetGrpXData = False
        Dim Pol2Remove As New List(Of Polyline)
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = Me.ActiveDocDB.TransactionManager
        Dim tr As Transaction
        Dim obj As DBObject
        For Each pol As Polyline In PolyList
            tr = tm.StartTransaction()
            obj = tr.GetObject(pol.ObjectId, OpenMode.ForWrite)
            Dim ch As String = Me.GetXData(tr, obj, "AppGrpNum")
            If ch IsNot Nothing AndAlso ch > 0 Then
                Application.ShowAlertDialog("Element already belongs to group")
                Pol2Remove.Add(pol)
            Else
                SetGrpXData = True
                Me.SetXData(tr, obj, "AppGrpNum", GrpNum)
            End If

            tr.Commit()
        Next

        For Each p As Polyline In Pol2Remove
            PolyList.Remove(p)
        Next

    End Function

    Public Function SetAcadAtt(ByVal Block As BlockRefOne, ByVal CurAttr As AttribTemplateOne) As Boolean
        If Block Is Nothing Then
            Return False
        End If
        SetAcadAtt = False
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = Me.ActiveDocDB.TransactionManager

        Dim attRef As AttributeReference = New AttributeReference()
        'Dim bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForWrite, False), BlockTable)
        Dim AttId As ObjectId

        Dim tr As Transaction = tm.StartTransaction()

        If CurAttr.Tag Is Nothing Then Exit Function
        If GlbSrvArx.DoesContainAttribute(tr, Block.BlockObj.AttributeCollection, CurAttr.Tag, AttId) Then
            attRef = CType(tr.GetObject(AttId, OpenMode.ForWrite), AttributeReference)
            If CurAttr.AttValue Is Nothing Then
                attRef.TextString = ""
                Exit Function
            End If
            attRef.TextString = CurAttr.AttValue
        Else
            SetAcadAtt = True
            Dim tempA As AttribTemplateOne = Block.BlockAttrib.GetAttrByTag(CurAttr.Tag)
            Dim FormVal As Boolean = True
            If tempA IsNot Nothing OrElse CurAttr.Tag.StartsWith("App") Then
                FormVal = False
            End If
            GlbData.GlbSrvArx.ApplyAttributeDef(Block.BlockObj, CurAttr, FormVal)

        End If
        tr.Commit()
        tr.Dispose()
        'tr.Commit()
    End Function

    Public Sub RemoveXDataByTag(ByVal pol As List(Of Polyline), ByVal tag As String)
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = Me.ActiveDocDB.TransactionManager
        Dim tr As Transaction
        Dim obj As DBObject
        'Dim db As Database
        'Dim rat As RegAppTable

        For Each poly As Polyline In pol
            tr = tm.StartTransaction()
            obj = tr.GetObject(poly.ObjectId, OpenMode.ForWrite)
            'db = obj.Database
            'rat = CType(tr.GetObject(db.RegAppTableId, OpenMode.ForRead), RegAppTable)
            'If Not rat.Has(tag) Then
            '    tr.Dispose()
            '    Continue For
            'End If
            'id = rat.Item(tag)
            'rat.RemoveField(rat.Item(tag))
            Me.SetXData(tr, obj, "AppGrpNum", "-1")
            tr.Commit()
        Next
    End Sub

    Public Sub RemoveXDataByTag(ByVal pol As Polyline, ByVal tag As String)
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = Me.ActiveDocDB.TransactionManager
        Dim tr As Transaction
        Dim obj As DBObject
        'Dim db As Database
        'Dim rat As RegAppTable
        'Dim id As ObjectId
        tr = tm.StartTransaction()
        obj = tr.GetObject(pol.ObjectId, OpenMode.ForWrite)
        'db = obj.Database
        'rat = CType(tr.GetObject(db.RegAppTableId, OpenMode.ForWrite), RegAppTable)
        'If Not rat.Has(tag) Then
        '    tr.Dispose()
        '    Exit Sub
        'End If
        'Dim ratr As RegAppTableRecord = New RegAppTableRecord()
        ''rat.Erase()
        'id = rat.Item(tag)
        'rat.
        '
        Me.SetXData(tr, obj, "AppGrpNum", "-1")
        tr.Commit()
    End Sub

    Public Sub RemoveAttByTag(ByVal Blocks As List(Of BlockRefOne), ByVal tag As String)

        If Blocks.Count < 1 Then
            Exit Sub
        End If
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = db.TransactionManager

        Dim attRef As AttributeReference = New AttributeReference()
        'Dim bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForWrite, False), BlockTable)

        Dim AttId As ObjectId
        For Each bro As BlockRefOne In Blocks
            Dim tr As Transaction = db.TransactionManager.StartTransaction()
            If GlbSrvArx.DoesContainAttribute(tr, bro.BlockObj.AttributeCollection, tag, AttId) Then

                attRef = CType(tr.GetObject(AttId, OpenMode.ForWrite), AttributeReference)
                attRef.Erase()


            End If



            tr.Commit()
            tr.Dispose()
        Next

        'tr.Commit()






    End Sub

    Public Sub RemoveAttByTag(ByVal Block As BlockRefOne, ByVal tag As String)

        If Block Is Nothing Then
            Exit Sub
        End If
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = db.TransactionManager

        Dim attRef As AttributeReference = New AttributeReference()
        'Dim bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForWrite, False), BlockTable)

        Dim AttId As ObjectId

        Dim tr As Transaction = db.TransactionManager.StartTransaction()
        If GlbSrvArx.DoesContainAttribute(tr, Block.BlockObj.AttributeCollection, tag, AttId) Then

            attRef = CType(tr.GetObject(AttId, OpenMode.ForWrite), AttributeReference)
            attRef.Erase()


        End If



        tr.Commit()
        tr.Dispose()


        'tr.Commit()






    End Sub

    Public Function StartAndPickBlock() As BlockRefOne
        Dim ch As Integer
        Dim ed As Editor = Me.ActiveDoc.Editor
        Dim prEnt As PromptEntityOptions = New PromptEntityOptions("Pick Block")
        Dim prEntRes As PromptEntityResult = ed.GetEntity(prEnt)
        Dim ent As Entity = Nothing
        Dim CurBlock As BlockRefOne = Nothing
        Dim FoundBlock As BlockRefOne = Nothing

        If prEntRes.Status <> PromptStatus.OK Then
            Return Nothing
        End If

        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        tm = Me.ActiveDocDB.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()

        ent = tr.GetObject(prEntRes.ObjectId, OpenMode.ForRead)

        If ent IsNot Nothing AndAlso TypeOf ent Is BlockReference Then
            Dim CurBlockRef As BlockReference = CType(ent, BlockReference)
            If GlbData.GlbBlocks.BlockList Is Nothing Then
                Return Nothing
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
        tr.Dispose()
        Return FoundBlock
    End Function

    Public Sub DeleteEnts(Optional ByVal Block2Remove As BlockRefOne = Nothing)
        Dim dm As DocumentCollection
        dm = Application.DocumentManager()
        If Not Application.DocumentManager.MdiActiveDocument.LockMode() = DocumentLockMode.Write Then
            Application.DocumentManager.MdiActiveDocument.LockDocument()
        End If
        Dim grp As Group = Nothing
        Dim tr As Transaction = Me.ActiveDocDB.TransactionManager.StartTransaction()
        Dim SelBlocks As New List(Of BlockRefOne)
        If Block2Remove Is Nothing Then
            SelBlocks = Me.GetSelectedBlocks()
        Else
            SelBlocks.Add(Block2Remove)
        End If

        Dim RemBlocks As New List(Of BlockRefOne)
        RemBlocks.AddRange(SelBlocks)
        Dim id As ObjectId
        For Each Blk As BlockRefOne In SelBlocks
            If Not Me.DoesContainAttribute(tr, Blk.BlockObj.AttributeCollection, "AppGrpParent", id) Then
                Continue For
            End If
            Dim attRef As AttributeReference = CType(tr.GetObject(id, OpenMode.ForRead), AttributeReference)
            If attRef.TextString Is Nothing OrElse attRef.TextString = "" Then
                Continue For
            End If
            grp = GlbData.GlbSrvFunc.GetorSetGroupByParAtt(attRef.TextString, False)
            If grp Is Nothing Then
                Continue For
            End If
            Dim pko As PromptKeywordOptions = New PromptKeywordOptions("Delete entire group " & grp.GrpName & " ?")
            pko.AllowNone = True
            pko.Keywords.Add("Yes")
            pko.Keywords.Add("No")
            pko.Keywords.Default = "Yes"
            Dim pkr As PromptResult = Me.ActiveDoc.Editor.GetKeywords(pko)
            RemBlocks.Remove(Blk)
            If Not (pkr.Status = PromptStatus.OK AndAlso pkr.StringResult = "Yes") Then
                Continue For
            End If
            Dim ent As AcadEntity = Me.GetCommonAcadBr(Blk.BlockObj)
            If ent IsNot Nothing Then
                ent.Delete()
            End If

            'grp.ParentBlock.BlockObj.Erase()
            For Each block As BlockRefOne In grp.BlockList
                If RemBlocks.Contains(block) Then
                    RemBlocks.Remove(block)
                End If
                ent = Me.GetCommonAcadBr(block.BlockObj)
                If ent Is Nothing Then
                    Continue For
                End If
                ent.Delete()
                'block.BlockObj.Erase()
            Next
            For Each Poly As Polyline In grp.PolyList

                ent = Me.GetCommonAcadBr(Poly)
                If ent Is Nothing Then
                    Continue For
                End If
                ent.Delete()
                'block.BlockObj.Erase()
            Next
            GlbData.GlbGroups.Remove(grp)

        Next

        For Each blk As BlockRefOne In RemBlocks
            If Me.DoesContainAttribute(tr, blk.BlockObj.AttributeCollection, "AppGrpNum", id) Then
                Dim pko As PromptKeywordOptions = New PromptKeywordOptions("Delete group member " & blk.BlockName & " ?")
                pko.AllowNone = True
                pko.Keywords.Add("Yes")
                pko.Keywords.Add("No")
                pko.Keywords.Default = "Yes"
                Dim pkr As PromptResult = Me.ActiveDoc.Editor.GetKeywords(pko)
                If Not (pkr.Status = PromptStatus.OK AndAlso pkr.StringResult = "Yes") Then
                    Continue For
                End If
            End If
            Dim ent As AcadEntity = Me.GetCommonAcadBr(blk.BlockObj)
            If ent Is Nothing Then
                Continue For
            End If
            ent.Delete()
            'blk.BlockObj.Erase()
        Next
        tr.Commit()
        tr.Dispose()
        Me.FinishAction()
    End Sub

    Public Sub CopyEnts()
        Dim SelBlocks As List(Of BlockRefOne) = Me.GetSelectedBlocks()
        If SelBlocks.Count < 1 Then
            MsgBox("Please select block\s for copy")
            Exit Sub
        End If
        Dim dm As DocumentCollection
        dm = Application.DocumentManager()
        If Not Application.DocumentManager.MdiActiveDocument.LockMode() = DocumentLockMode.Write Then
            Application.DocumentManager.MdiActiveDocument.LockDocument()
        End If
        Dim tr As Transaction = Me.ActiveDocDB.TransactionManager.StartTransaction()
        Dim id As ObjectId
        For Each Blk As BlockRefOne In SelBlocks
            If Me.DoesContainAttribute(tr, Blk.BlockObj.AttributeCollection, "AppGrpParent", id) Then
                Dim attRef As AttributeReference = CType(tr.GetObject(id, OpenMode.ForRead), AttributeReference)
                If attRef.TextString Is Nothing OrElse attRef.TextString = "" Then
                    Continue For
                End If

                Dim grp As Group = GlbData.GlbSrvFunc.GetorSetGroupByParAtt(attRef.TextString, False)
                If grp Is Nothing Then
                    Continue For
                End If
                Dim pko As PromptKeywordOptions = New PromptKeywordOptions("Copy entire goup " & grp.GrpName & " ?")
                pko.AllowNone = True
                pko.Keywords.Add("Yes")
                pko.Keywords.Add("No")
                pko.Keywords.Default = "Yes"
                Dim pkr As PromptResult = Me.ActiveDoc.Editor.GetKeywords(pko)
                If Not (pkr.Status = PromptStatus.OK AndAlso pkr.StringResult = "Yes") Then
                    Continue For
                End If
                'Dim dcoll As Collection = Me.GenDisplacementVecs4Grp(grp)
                Dim ppo As PromptPointOptions = New PromptPointOptions("\nSelect point: ")
                ppo.AllowNone = True
                Dim ppr As PromptPointResult = Me.ActiveDoc.Editor.GetPoint(ppo)
                If ppr.Status <> PromptStatus.OK Then
                    Continue For
                End If
                Dim newLoc As Point3d = ppr.Value
                Dim NewGrp As New Group
                Dim ent As AcadEntity = Me.GetCommonAcadBr(grp.ParentBlock.BlockObj)
                Dim Cent As AcadEntity = ent.Copy()
                Cent.Move(grp.ParentBlock.BlockObj.Position.ToArray(), newLoc.ToArray())
                Dim Mvec(2) As Double
                BMath.BMath_VectByPnt(grp.ParentBlock.BlockObj.Position.ToArray(), newLoc.ToArray(), Mvec)
                NewGrp.GroupNum = NewGrp.GenGroupNum()
                NewGrp.GrpName = "Group" & NewGrp.GroupNum
                Dim parBrefOne As BlockRefOne = GlbData.GlbBlocks.Addblock(Cent, tr)
                If parBrefOne Is Nothing Then
                    Exit Sub
                End If
                NewGrp.ParentBlock = parBrefOne
                If Not NewGrp.SaveParent() Then
                    Exit Sub
                End If
                'Dim bkw As BlockReference = CType(tr.GetObject(grp.ParentBlock.BlockObj.ObjectId, OpenMode.ForWrite), BlockReference)               
                'grp.ParentBlock.BlockObj.Position = newLoc
                Me.SetDisplacementByVecs4Grp(NewGrp, grp, Mvec, tr)
                NewGrp.SaveBlocks(NewGrp.BlockList)
                NewGrp.SavePolyLines(NewGrp.PolyList)
                GlbData.GlbGroups.Add(NewGrp)
            ElseIf Me.DoesContainAttribute(tr, Blk.BlockObj.AttributeCollection, "AppGrpNum", id) Then
                Dim attRef As AttributeReference = CType(tr.GetObject(id, OpenMode.ForRead), AttributeReference)
                If attRef.TextString Is Nothing OrElse attRef.TextString = "" Then
                    Continue For
                End If
                Dim pos As Point3d = Blk.BlockObj.Position
                Dim ppo As PromptPointOptions = New PromptPointOptions("\nSelect point: ")
                ppo.AllowNone = True
                Dim ppr As PromptPointResult = Me.ActiveDoc.Editor.GetPoint(ppo)
                If ppr.Status <> PromptStatus.OK Then
                    Continue For
                End If
                Dim newLoc As Point3d = ppr.Value
                Dim ent As AcadEntity = Me.GetCommonAcadBr(Blk.BlockObj)
                Dim Cent As AcadEntity = ent.Copy()
                Cent.Move(pos.ToArray(), newLoc.ToArray())
                Dim NewBro As BlockRefOne = GlbData.GlbBlocks.Addblock(Cent, tr)
                Me.RemoveAttByTag(NewBro, "AppGrpNum")

            Else
                Dim pos As Point3d = Blk.BlockObj.Position
                Dim ppo As PromptPointOptions = New PromptPointOptions("\nSelect point: ")
                ppo.AllowNone = True
                Dim ppr As PromptPointResult = Me.ActiveDoc.Editor.GetPoint(ppo)
                If ppr.Status <> PromptStatus.OK Then
                    Continue For
                End If
                Dim newLoc As Point3d = ppr.Value
                Dim ent As AcadEntity = Me.GetCommonAcadBr(Blk.BlockObj)
                Dim Cent As AcadEntity = ent.Copy()
                Cent.Move(pos.ToArray(), newLoc.ToArray())
                GlbData.GlbBlocks.Addblock(Cent, tr)
            End If
        Next
        tr.Commit()
        tr.Dispose()
        Me.FinishAction()
    End Sub

    Public Sub SetDisplacementByVecs4Grp(ByRef NewGrp As Group, ByVal grp As Group, ByVal Mvec() As Double, ByVal tr As Transaction)
        Dim dVec() As Double
        Dim Npnt(2) As Double
        Dim Bl As New List(Of BlockRefOne)
        Bl.AddRange(grp.BlockList)
        For Each bro As BlockRefOne In Bl
            dVec = Nothing
            'dVec = dcoll(bro.BlockObj.Id.Handle.Value.ToString())
            'If dVec Is Nothing Then
            '    Continue For
            'End If
            BMath.BMath_PntAddVect(bro.BlockObj.Position.ToArray(), Mvec, Npnt)
            'Dim bkw As BlockReference = CType(tr.GetObject(bro.BlockObj.ObjectId, OpenMode.ForWrite), BlockReference)
            'bro.BlockObj.Position = NewChLoc
            Dim ent As AcadEntity = Me.GetCommonAcadBr(bro.BlockObj)
            Dim Cent As AcadEntity = ent.Copy()
            'Dim z() As Double = {0, 0, 0}
            Cent.Move(bro.BlockObj.Position.ToArray(), Npnt)
            Dim blkrefOne As BlockRefOne = GlbData.GlbBlocks.Addblock(Cent, tr)
            NewGrp.BlockList.Add(blkrefOne)
        Next

        For Each pol As Polyline In grp.PolyList
            dVec = Nothing
            'dVec = dcoll(pol.Id.Handle.Value.ToString())
            'If dVec Is Nothing Then
            '    Continue For
            'End If
            BMath.BMath_PntAddVect(pol.StartPoint.ToArray(), Mvec, Npnt)
            Dim ent As AcadEntity = Me.GetCommonAcadBr(pol)
            If ent Is Nothing Then
                Continue For
            End If
            Dim Cent As AcadEntity = ent.Copy()
            Cent.Move(pol.StartPoint.ToArray(), Npnt)
            Dim Npol As Polyline = Me.GetPolyFmAcadEnt(Cent, tr)
            If Npol Is Nothing Then
                Continue For
            End If
            Me.RemoveXDataByTag(Npol, "AppGrpNum")
            NewGrp.PolyList.Add(Npol)
            'Dim plw As Polyline = CType(tr.GetObject(pol.ObjectId, OpenMode.ForWrite), Polyline).Clone()
            'plw.MoveGripPointsAt (plw.
            ' pol.StartPoint = NewChLoc

        Next

    End Sub

    Public Function GetBlkRefFmAcadEnt(ByVal ent As AcadEntity, ByVal tr As Transaction) As BlockReference
        'Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        'tm = Me.ActiveDocDB.TransactionManager
        Dim CurBlockRef As BlockReference = Nothing
        'Dim tr As Transaction = tm.StartTransaction()
        Dim e As Entity
        Dim Bt As BlockTable = CType(tr.GetObject(Me.ActiveDocDB.BlockTableId, OpenMode.ForRead, False), BlockTable)
        Dim msbtr As BlockTableRecord = tr.GetObject(Bt.Item(BlockTableRecord.ModelSpace), OpenMode.ForRead)

        Dim id As ObjectId ' First, dimension an ID variable used in the For Loop.
        For Each id In msbtr
            e = tr.GetObject(id, OpenMode.ForRead)
            If e IsNot Nothing AndAlso TypeOf e Is BlockReference Then
                CurBlockRef = CType(e, BlockReference)
                If CurBlockRef.ObjectId.GetHashCode = ent.ObjectID Then
                    Exit For
                End If
            End If

        Next
        'tr.Dispose()
        Return CurBlockRef
    End Function

    Public Function GetPolyFmAcadEnt(ByVal ent As AcadEntity, ByVal tr As Transaction) As Polyline
        'Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        'tm = Me.ActiveDocDB.TransactionManager
        Dim poly As Polyline = Nothing
        'Dim tr As Transaction = tm.StartTransaction()
        Dim e As Entity
        Dim Bt As BlockTable = CType(tr.GetObject(Me.ActiveDocDB.BlockTableId, OpenMode.ForRead, False), BlockTable)
        Dim msbtr As BlockTableRecord = tr.GetObject(Bt.Item(BlockTableRecord.ModelSpace), OpenMode.ForRead)

        Dim id As ObjectId ' First, dimension an ID variable used in the For Loop.
        For Each id In msbtr
            e = tr.GetObject(id, OpenMode.ForRead)
            If e IsNot Nothing AndAlso TypeOf e Is Polyline Then
                poly = CType(e, Polyline)
                If poly.ObjectId.GetHashCode = ent.ObjectID Then
                    Exit For
                End If
            End If

        Next
        'tr.Dispose()
        Return poly
    End Function

    Public Function GenDisplacementVecs4Grp(ByVal grp As Group) As Collection
        Dim dColl As New Collection
        Dim parPos As Point3d = grp.ParentBlock.BlockObj.Position
        Dim childpos As Point3d
        Dim dVec(2) As Double
        For Each bro As BlockRefOne In grp.BlockList
            childpos = bro.BlockObj.Position
            BMath.BMath_VectByPnt(parPos.ToArray(), childpos.ToArray(), dVec)
            dColl.Add(dVec, bro.BlockObj.Id.Handle.Value)
        Next
        For Each pol As Polyline In grp.PolyList
            childpos = pol.StartPoint
            BMath.BMath_VectByPnt(parPos.ToArray(), childpos.ToArray(), dVec)
            dColl.Add(dVec, pol.Id.Handle.Value)
        Next
        Return dColl
    End Function

    Public Function GetSelectedBlocks() As List(Of BlockRefOne)
        Dim BlockOnes As New List(Of BlockRefOne)
        If Not Application.DocumentManager.MdiActiveDocument.LockMode() = DocumentLockMode.Write Then
            Application.DocumentManager.MdiActiveDocument.LockDocument()
        End If

        Dim ed As Editor = Me.ActiveDoc.Editor
        Dim res As PromptSelectionResult = ed.SelectImplied()
        If res.Status = PromptStatus.Error Then Return BlockOnes
        If GlbData.GlbBlocks.BlockList Is Nothing Then
            Return BlockOnes
        End If
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        tm = Me.ActiveDocDB.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()

        Dim SS As Autodesk.AutoCAD.EditorInput.SelectionSet = res.Value
        Dim idarray As ObjectId() = SS.GetObjectIds()
        Dim FoundBlock As BlockRefOne = Nothing
        Dim CurBlock As BlockRefOne = Nothing
        Dim id As ObjectId
        For Each id In idarray
            Dim ent As Entity = tr.GetObject(id, OpenMode.ForRead)
            If ent Is Nothing Then
                Continue For
            End If
            If TypeOf ent Is BlockReference Then
                Dim CurBlockRef As BlockReference = CType(ent, BlockReference)
                FoundBlock = Nothing
                For ch As Integer = 1 To GlbData.GlbBlocks.BlockList.Count
                    CurBlock = GlbData.GlbBlocks.BlockList.Item(ch)
                    If CurBlock.BlockObj.ObjectId.GetHashCode() = CurBlockRef.ObjectId.GetHashCode() Then
                        FoundBlock = CurBlock
                        Exit For
                    End If
                Next ch
                If FoundBlock IsNot Nothing Then
                    BlockOnes.Add(FoundBlock)
                End If
            End If
        Next id
        tr.Dispose()
        Return BlockOnes
    End Function

    Public Function GetSelectedPolylines() As List(Of Polyline)

        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim Polylist As New List(Of Polyline)
        Dim ed As Editor = Me.ActiveDoc.Editor
        Dim res As PromptSelectionResult = ed.SelectImplied()
        If res.Status = PromptStatus.Error Then Return Polylist
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        tm = Me.ActiveDocDB.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()
        Dim SS As Autodesk.AutoCAD.EditorInput.SelectionSet = res.Value
        Dim Foundpoly As Polyline
        Dim idarray As ObjectId() = SS.GetObjectIds()
        Dim id As ObjectId
        For Each id In idarray
            Dim ent As Entity = tr.GetObject(id, OpenMode.ForRead)
            If ent Is Nothing Then
                Continue For
            End If

            If TypeOf ent Is Polyline Then
                Foundpoly = CType(ent, Polyline)
                Polylist.Add(Foundpoly)
            End If
        Next id
        tr.Dispose()
        Return Polylist
    End Function

    ''' <summary>
    ''' reset "Command line" in Autocad
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FinishAction()
        Application.DocumentManager.MdiActiveDocument.LockDocument(DocumentLockMode.NotLocked, Nothing, Nothing, True)
        Dim lm As Integer = Application.DocumentManager.MdiActiveDocument.LockMode(False)
        Me.ActiveDoc.Editor.Regen()
        Me.ActiveDoc.Editor.WriteMessage(vbCr & "Command:")
    End Sub

    Public Function GetXData(ByVal tr As Transaction, ByVal obj As DBObject, ByVal tag As String) As String
        Dim res As String = Nothing
        Dim rb As ResultBuffer = obj.XData
        If rb Is Nothing Then
            Return res
        End If
        Dim foundStart As Boolean = False

        For Each tv As TypedValue In rb
            If tv.TypeCode = CInt(DxfCode.ExtendedDataRegAppName) And tv.Value.ToString() = tag Then
                foundStart = True
            ElseIf foundStart = True Then
                If tv.TypeCode = CInt(DxfCode.ExtendedDataReal) Then
                    res = CDbl(tv.Value)
                    Exit For
                End If
            End If
        Next
        rb.Dispose()
        Return res
    End Function

    Public Function SetXData(ByVal tr As Transaction, ByVal obj As DBObject, ByVal tag As String, ByVal value As String) As Boolean
        Dim db As Database = obj.Database

        Dim rat As RegAppTable = CType(tr.GetObject(db.RegAppTableId, OpenMode.ForRead), RegAppTable)


        If Not rat.Has(tag) Then
            rat.UpgradeOpen()
            Dim ratr As RegAppTableRecord = New RegAppTableRecord()
            ratr.Name = tag
            rat.Add(ratr)
            tr.AddNewlyCreatedDBObject(ratr, True)
        End If


        ' Create the XData and set it on the object

        Dim rb As ResultBuffer = New ResultBuffer(New TypedValue(CInt(DxfCode.ExtendedDataRegAppName), _
        tag), New TypedValue(CInt(DxfCode.ExtendedDataReal), value))
        obj.XData = rb
        rb.Dispose()
    End Function

    Public Sub LoadPolyLines()
        Application.DocumentManager.MdiActiveDocument.LockDocument()

        Dim grpNum As String
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = Me.ActiveDocDB.TransactionManager

        Dim CurPoly As Polyline = Nothing
        Dim obj As DBObject
        Dim ent As Entity = Nothing
        Dim CurrGrp As Group
        Dim tr As Transaction = tm.StartTransaction()

        Dim Bt As BlockTable = CType(tm.GetObject(Me.ActiveDocDB.BlockTableId, OpenMode.ForRead, False), BlockTable)
        Dim msbtr As BlockTableRecord = tm.GetObject(Bt.Item(BlockTableRecord.ModelSpace), OpenMode.ForRead)

        Dim id As ObjectId ' First, dimension an ID variable used in the For Loop.
        For Each id In msbtr
            ent = tr.GetObject(id, OpenMode.ForRead)
            If ent IsNot Nothing AndAlso TypeOf ent Is Polyline Then
                CurPoly = CType(ent, Polyline)
                obj = tr.GetObject(CurPoly.ObjectId, OpenMode.ForRead)
                grpNum = Me.GetXData(tr, obj, "AppGrpNum")
                If grpNum IsNot Nothing AndAlso IsNumeric(grpNum) AndAlso grpNum > 0 Then
                    CurrGrp = GlbData.GlbSrvFunc.GetorSetGroupByNum(CInt(grpNum), False)
                    If CurrGrp Is Nothing Then
                        Continue For
                    End If
                    CurrGrp.PolyList.Add(CurPoly)
                End If

            End If
        Next

        tr.Dispose()
        tm.Dispose()



    End Sub

    Public Function GetPolylineByGroupAndArea(ByVal grp As Group, ByVal Area As String) As Polyline
        Dim DblArea As Double = CDbl(Area)
        For Each pol As Polyline In grp.PolyList
            If Math.Abs(DblArea - (pol.Area * 0.001)) < 0.01 Then
                Return pol
            End If
        Next
        Return Nothing
    End Function

    Public Sub vetoDeleteCommand(ByVal sender As Object, ByVal e As DocumentLockModeChangedEventArgs)

        'If Not (e.GlobalCommandName = "ERASE" Or e.GlobalCommandName = "PASTECLIP") Then
        '    Exit Sub
        'End If

        'Dim dm As DocumentCollection
        'dm = Application.DocumentManager()

        'RemoveHandler dm.DocumentLockModeChanged, AddressOf vetoDeleteCommand
        'Dim tr As Transaction = Me.ActiveDocDB.TransactionManager.StartTransaction()
        'Dim SelBlocks As List(Of BlockRefOne) = Me.GetSelectedBlocks()
        'Dim id As ObjectId
        'Select Case e.GlobalCommandName
        '    Case "ERASE"
        '        For Each Blk As BlockRefOne In SelBlocks
        '            If Me.DoesContainAttribute(tr, Blk.BlockObj.AttributeCollection, "AppGrpParent", id) Then
        '                Application.ShowAlertDialog(Blk.BlockObj.Name & " is group a parent and can't be deleted")
        '                e.Veto()
        '            ElseIf Me.DoesContainAttribute(tr, Blk.BlockObj.AttributeCollection, "AppGrpNum", id) Then
        '                Dim attRef As AttributeReference = CType(tr.GetObject(id, OpenMode.ForWrite), AttributeReference)
        '                If attRef.TextString IsNot Nothing AndAlso IsNumeric(attRef.TextString) AndAlso CInt(attRef.TextString) > 0 Then
        '                    Dim grp As Group = GlbData.GlbSrvFunc.GetorSetGroupByNum(CInt(attRef.TextString), False)
        '                    If grp Is Nothing Then
        '                        Continue For
        '                    End If
        '                    grp.BlockList.Remove(Blk)
        '                End If

        '            End If
        '        Next
        '    Case "PASTECLIP"
        '        For Each Blk As BlockRefOne In SelBlocks
        '            If Not Me.DoesContainAttribute(tr, Blk.BlockObj.AttributeCollection, "AppGrpParent", id) Then
        '                Continue For
        '            End If
        '            Dim attRef As AttributeReference = CType(tr.GetObject(id, OpenMode.ForWrite), AttributeReference)
        '            Dim GrpParVal As String = attRef.TextString
        '            Dim indxOfDol As Integer = GrpParVal.IndexOf("$")
        '            If indxOfDol < 1 Then
        '                Me.RemoveAttByTag(Blk, "AppGrpParent")
        '                Exit Select
        '            End If
        '            Dim grpName As String = GrpParVal.Substring(0, indxOfDol)
        '            Dim grp As Group = GlbData.GlbSrvFunc.GetGroupByName(grpName)
        '            Dim NameOk As Boolean = False
        '            Dim i As Integer = 0
        '            If IsNumeric(grpName.Chars(grpName.Length - 1)) Then
        '                grpName = grpName.Remove(grpName.Length - 1)
        '            End If
        '            While Not NameOk
        '                i += 1
        '                NameOk = grp.CheckName(grpName & i)
        '            End While
        '            grpName = grpName & i
        '            Dim GrpNum As Integer = grp.GenGroupNum()
        '            'Me.SetBrAttVal(Blk.BlockObj, grpName & "$" & GrpNum, "AppGrpParent")
        '            attRef.TextString = grpName & "$" & GrpNum
        '            SelBlocks.Remove(Blk)
        '            For Each bro As BlockRefOne In grp.BlockList
        '                If Me.DoesContainAttribute(tr, bro.BlockObj.AttributeCollection, "AppGrpNum", id) Then
        '                    attRef = CType(tr.GetObject(id, OpenMode.ForWrite), AttributeReference)
        '                    attRef.TextString = GrpNum
        '                End If
        '            Next
        '            For Each pol As Polyline In grp.PolyList
        '                Dim obj As DBObject = tr.GetObject(pol.ObjectId, OpenMode.ForWrite)
        '                Me.SetXData(tr, obj, "AppGrpNum", GrpNum)
        '            Next
        '            Exit For
        '        Next

        'End Select



        'tr.Commit()
        'tr.Dispose()
        'AddHandler dm.DocumentLockModeChanged, AddressOf GlbData.GlbSrvArx.vetoDeleteCommand
    End Sub

    Public Sub UnSelectAll()
        Me.ActiveDoc.Editor.SetImpliedSelection(EmtySS)
    End Sub

    Public Sub ConvertSelected2D3D(ByVal IsAll As Boolean) 'SZ
        If Not Application.DocumentManager.MdiActiveDocument.LockMode() = DocumentLockMode.Write Then
            Application.DocumentManager.MdiActiveDocument.LockDocument()
        End If
        'The function converts all selected blocks on the screen to 3D blocks
        Dim BName As String
        Dim IsScssImprt As Boolean
        Dim DelList As New List(Of BlockRefOne)
        'Get list of blocks (Selected / All blocks)
        Dim SelBlocks As New List(Of BlockRefOne)
        If IsAll = True Then
            'Convert Collection to List
            For Each b As BlockRefOne In GlbData.GlbBlocks.BlockList
                SelBlocks.Add(b)
            Next
        Else
            SelBlocks = Me.GetSelectedBlocks()
        End If
        If SelBlocks.Count < 1 Then
            Me.ActiveDoc.Editor.WriteMessage("No blocks found" & vbCr)
            Me.FinishAction()
            Exit Sub
        End If
        For Each bro As BlockRefOne In SelBlocks
            'Get Block name
            BName = bro.BlockName

            'If the block is already 3D, skip to next one
            If BName.Chars(3) = "$" Then
                Continue For
            End If

            'Find 3D file and get 3D block according to 2D block name.
            IsScssImprt = ImportBlock(BName, True)
            If IsScssImprt <> True Then
                Continue For
            End If

            'Insert new 3D block according to coordinates
            Dim BR3D As BlockReference
            Dim Bro3D As New BlockRefOne()
            Dim Bl_XYZ(3) As Double
            Bl_XYZ(0) = bro.BlockObj.Position.X
            Bl_XYZ(1) = bro.BlockObj.Position.Y
            Bl_XYZ(2) = bro.BlockObj.Position.Z
            Dim BlockRot As Double = bro.BlockObj.Rotation
            BR3D = StartBlJig(BName.Replace("-", "$"), True, Bl_XYZ, BlockRot)
            If BR3D = Nothing Then
                Continue For
            End If
            Bro3D.BlockObj = BR3D
            Bro3D.BlockName = BR3D.Name
            'Copy All Atributes from 2D Block to 3D Block
            Dim AttOk As Boolean
            Bro3D.BlockAttrib = bro.BlockAttrib
            For Each att As AttribTemplateOne In bro.BlockAttrib.AttrList
                AttOk = SetAcadAtt(Bro3D, att)
            Next

            'Add 3D block to Globlal Block list
            Dim tr As Transaction = Me.ActiveDocDB.TransactionManager.StartTransaction()
            Dim ent As AcadEntity = Me.GetCommonAcadBr(Bro3D.BlockObj)
            GlbData.GlbBlocks.Addblock(ent, tr)
            tr.Commit()
            tr.Dispose()

            DelList.Add(bro) ' Add 2D Block to Deletion list
        Next

        'Delete 2D Blocks (If all successfull)
        For Each DBro As BlockRefOne In DelList
            Me.DeleteEnts(DBro)
        Next

    End Sub

    Public Sub SetLeader() 'SZ
        'TD: Check that only one block selected
        'TD: Find Insertion point

        'TD: Create Leader
        Dim Ld As Entity
    End Sub

End Class