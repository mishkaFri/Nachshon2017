Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic


Public Class BlockTbl

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub GenerateTbl(ByVal BlockAtts As List(Of BlockAttribOne), ByVal ImgFiles() As String)
        Dim img As Bitmap
        For Each Ao As BlockAttribOne In BlockAtts
            img = Me.GetImg(Ao.BlockName, ImgFiles)
            Me.AddRow(img, Ao)
        Next
        Me.DataGridView1.Sort(Me.DataGridView1.Columns.Item("AcadBlock"), System.ComponentModel.ListSortDirection.Ascending)  'SZ
        'Me.Visible = True
    End Sub

    Private Function GetImg(ByVal Name As String, ByVal files() As String) As System.Drawing.Bitmap
        If files Is Nothing Then
            Return Nothing
        End If
        Dim RetImg As System.Drawing.Bitmap = Nothing
        Dim Size As New Size(64, 64)

        For Each img As String In files
            If Not img.Contains(Name) Then
                Continue For
            End If
            Dim Im As System.Drawing.Image = System.Drawing.Image.FromFile(img)
            RetImg = New System.Drawing.Bitmap(Im, Size)

        Next
        Return RetImg
    End Function

    Public Sub AddRow(ByVal img As System.Drawing.Bitmap, ByVal Ao As BlockAttribOne)
        Dim CellParam(7) As Object
        CellParam(0) = img
        CellParam(1) = Ao.BlockName
        CellParam(2) = Ao.AttribName
        CellParam(3) = Ao.AttribLength
        CellParam(4) = Ao.AttribWidth
        CellParam(5) = Ao.Attribheight
        CellParam(6) = Ao.AttribPower
        CellParam(7) = Ao.AttribHorse

        Dim dgvRow As New DataGridViewRow
        dgvRow.CreateCells(Me.DataGridView1, CellParam)
        dgvRow.Height = 64
        Me.DataGridView1.Rows.Add(dgvRow)
    End Sub

    Private Sub BlockTbl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub BlockTbl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Char.ConvertFromUtf32(Keys.Escape) Then
            Me.Close()
        End If

    End Sub

    Public Function GetTableRecordId(ByVal objTableId As ObjectId, ByVal strName As String) As ObjectId

        GetTableRecordId = ObjectId.Null

        Dim objDB As Database = HostApplicationServices.WorkingDatabase

        Dim objTrans As Transaction = objDB.TransactionManager.StartTransaction

        Dim objTable As SymbolTable = CType(objTrans.GetObject(objTableId, OpenMode.ForRead, False), SymbolTable)

        If objTable.Has(strName) Then

            Dim objID As ObjectId

            objID = objTable(strName)

            If objID.IsErased Then

                For Each objID In objTable

                    If Not objID.IsErased Then

                        Dim objSTR As SymbolTableRecord = CType(objTrans.GetObject(objID, OpenMode.ForRead, False), SymbolTableRecord)

                        If String.Compare(objSTR.Name, strName, True) = 0 Then

                            GetTableRecordId = objID

                            Exit For

                        End If

                    End If

                Next

            Else

                GetTableRecordId = objID

            End If

        End If

        objTrans.Commit()

        objTrans.Dispose()

    End Function

    'Private Function ImportBlock(ByVal Ablock As String) As Boolean
    '    GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Catag)
    '    Dim btr As BlockTableRecord
    '    Dim mapping As IdMapping = New IdMapping()
    '    Dim dm As DocumentCollection = Application.DocumentManager

    '    Dim destDb As Database = dm.MdiActiveDocument.Database
    '    Dim sourceDb As Database = New Database(False, True)
    '    Dim DrwName As String = Ablock.Substring(0, 2) & "2D.dwg"
    '    sourceDb.ReadDwgFile(My.Settings.Path2Catag & DrwName, System.IO.FileShare.Read, _
    '                            True, "")
    '    Dim blockIds As ObjectIdCollection = New ObjectIdCollection()
    '    Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = sourceDb.TransactionManager
    '    Dim tr As Transaction = tm.StartTransaction()
    '    Dim bt As BlockTable = CType(tm.GetObject(sourceDb.BlockTableId, OpenMode.ForRead, False), BlockTable)
    '    For Each btrId As ObjectId In bt
    '        btr = CType(tm.GetObject(btrId, OpenMode.ForRead, False), BlockTableRecord)
    '        If (Not btr.IsAnonymous And Not btr.IsLayout And btr.Name = Ablock) Then
    '            blockIds.Add(btrId)
    '            Exit For
    '        End If
    '        btr.Dispose()
    '    Next
    '    dm.MdiActiveDocument.LockDocument()
    '    Try
    '        sourceDb.WblockCloneObjects(blockIds, destDb.BlockTableId, mapping, _
    '                                   1, False)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    '    tr.Dispose()
    '    Return True
    'End Function
    'Public Function StartBlJig(ByVal BName As String) As BlockReference
    '    Dim doc As Document = Application.DocumentManager.MdiActiveDocument
    '    Dim ed As Editor = doc.Editor
    '    Dim db As Database = doc.Database
    '    Dim tr As Transaction = doc.TransactionManager.StartTransaction()
    '    Dim bt As BlockTable = CType(tr.GetObject(db.BlockTableId, OpenMode.ForRead), BlockTable)
    '    If Not bt.Has(BName) Then
    '        Return Nothing
    '    End If
    '    Dim space As BlockTableRecord = CType(tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite), BlockTableRecord)
    '    Dim btr As BlockTableRecord = CType(tr.GetObject(bt(BName), OpenMode.ForRead), BlockTableRecord)
    '    Dim br As BlockReference = New BlockReference(New Point3d(), btr.ObjectId)
    '    space.AppendEntity(br)
    '    tr.AddNewlyCreatedDBObject(br, True)
    '    Dim attInfo As Dictionary(Of ObjectId, AttInfo) = New Dictionary(Of ObjectId, AttInfo)
    '    If btr.HasAttributeDefinitions Then
    '        For Each id As ObjectId In btr
    '            Dim obj As DBObject = tr.GetObject(id, OpenMode.ForRead)
    '            Dim ad As AttributeDefinition = TryCast(obj, AttributeDefinition)
    '            If ad IsNot Nothing AndAlso Not ad.Constant Then
    '                Dim ar As AttributeReference = New AttributeReference()
    '                ar.SetAttributeFromBlock(ad, br.BlockTransform)
    '                If ad.Justify <> AttachmentPoint.BaseLeft Then
    '                    ar.AlignmentPoint = ad.AlignmentPoint.TransformBy(br.BlockTransform)
    '                End If
    '                If ar.IsMTextAttribute Then
    '                    ar.UpdateMTextAttribute()
    '                End If
    '                ar.TextString = ad.TextString
    '                Dim arid As ObjectId = br.AttributeCollection.AppendAttribute(ar)
    '                tr.AddNewlyCreatedDBObject(ar, True)
    '                attInfo.Add(arid, New AttInfo(ad.Position, ad.AlignmentPoint, ad.Justify <> AttachmentPoint.BaseLeft))
    '            End If
    '        Next
    '    End If



    '    Dim myJig As BlockJig = New BlockJig(tr, br, attInfo)
    '    If (myJig.Run() <> PromptStatus.OK) Then
    '        Return Nothing
    '    End If
    '    tr.Commit()
    '    tr.Dispose()
    '    Return br

    'End Function

    Public Function GetIndexByObjectId(ByVal Oi As ObjectId) As Integer
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ent As AcadEntity
        For i As Integer = 0 To GlbData.GlbAcadApp.ActiveDocument.ModelSpace.Count - 1
            ent = GlbData.GlbAcadApp.ActiveDocument.ModelSpace.Item(i)
            If Object.Equals(Oi.GetHashCode(), ent.ObjectID) Then
                Return i
            End If

        Next
        Return -1
    End Function

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim dgvRow As DataGridViewRow = Me.DataGridView1.Rows.Item(e.RowIndex)
        Dim BlName = dgvRow.Cells.Item("AcadBlock").Value
        If False = GlbSrvArx.ImportBlock(BlName) Then
            Exit Sub
        End If
        Me.Close()
        Dim tmp As UC_Parameters = GlbData.GlbMainUc.UC_List("UC_Parameters")
        Select Case Char.ToLower(BlName.Chars(2))
            Case "b"
                tmp.setMode(1, BlName)
            Case "c"
                tmp.setMode(2, BlName)
            Case "d"
                tmp.setMode(3, BlName)
            Case "a"
                tmp.setMode(0, BlName)
        End Select
        'Dim br As BlockReference = GlbSrvArx.StartBlJig(BlName)
        'If br Is Nothing Then
        '    Exit Sub
        'End If
        'Dim Bro As New BlockRefOne
        'Bro.BlockObj = br
        'Bro.BlockObj.Highlight()
        'If Not Bro.LoadAttrib() Then
        '    Exit Sub
        'End If
        'GlbData.GlbBlocks.BlockList.Add(Bro)
        'Dim Caw As New ClsAttWork(Bro)

        'Dim Atbl As New AttributeTlb(Caw)
        'Application.ShowModelessDialog(Application.MainWindow, Atbl)
        ''Atbl.GenerateTbl()
        'GlbData.GlbActDoc.Save()      
    End Sub

    
End Class