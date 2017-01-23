Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic

Public Class ClsAttWork
    Private _BlockOnes As New List(Of BlockRefOne)
    Private _AttTemplateAll As New AttribTemplateAll
    Private _NewAttTemplateAll As New AttribTemplateAll
    Private _EditedRows as New List(Of Integer )

    Public Sub New(ByVal Blocks As List(Of BlockRefOne))
        If Blocks.Count < 1 Then
            Exit Sub
        End If
        Me.BlockOnes.AddRange(Blocks)
        Dim CurAtt As AttribTemplateOne
        Dim val As String
        Dim i As Integer
        Dim curList As Collection = Me.setList(Blocks)
        For Each att As AttribTemplateOne In curList
            CurAtt = Me.BlockOnes.Item(0).GetBlkAttrByTag(att.Tag)
            If CurAtt Is Nothing Then
                att.AttValue = ""
                Me.AttTemplateAll.AttrList.Add(att)
                Continue For
            End If
            val = CurAtt.AttValue
            For i = 1 To UBound(Me.BlockOnes.ToArray())
                CurAtt = Me.BlockOnes.Item(i).GetBlkAttrByTag(att.Tag)
                If CurAtt Is Nothing OrElse val <> CurAtt.AttValue Then
                    att.AttValue = ""

                    Me.AttTemplateAll.AttrList.Add(att)
                    Exit For
                End If
            Next
            If i = Me.BlockOnes.Count Then
                att.AttValue = val
                Me.AttTemplateAll.AttrList.Add(att)
            End If
        Next
        Me.NewAttTemplateAll.addAta(Me.AttTemplateAll)
    End Sub
    Public Sub New(ByVal Block As BlockRefOne)
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        'Block.BlockObj = Me.GetWritableBr(Block)
        Me.BlockOnes.Add(Block)
        Me.AttTemplateAll = Block.BlockAttrib
        Me.NewAttTemplateAll.addAta(Me.AttTemplateAll)
    End Sub
    Public Function setList(ByVal blocks As List(Of BlockRefOne)) As Collection
        Dim AttCol As New Collection
        Dim tempNewCol As New Collection

        'For Each ato As AttribTemplateOne In GlbData.GlbAttrTempObj.AttrList
        '    AttCol.Add(ato)
        'Next
        For Each bro As BlockRefOne In blocks
            For Each ato As AttribTemplateOne In bro.BlockAttrib.AttrList
                If Not tempNewCol.Contains(ato.Tag) Then
                    tempNewCol.Add(ato, ato.Tag)
                End If
            Next
        Next
        Dim commonAtt As Boolean = True
        For Each ato As AttribTemplateOne In tempNewCol
            For Each bro As BlockRefOne In blocks
                If Not bro.BlockAttrib.DoesContainAttribute(ato.Tag) Then
                    commonAtt = False
                    Exit For
                End If
            Next
            If commonAtt Then
                AttCol.Add(ato)
            End If
            commonAtt = True
        Next
        Return AttCol
    End Function
    Public Sub SetAcadAtts()
        If Me.BlockOnes.Count < 1 Then
            Exit Sub
        End If
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = db.TransactionManager

        Dim attRef As AttributeReference = New AttributeReference()
        'Dim bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForWrite, False), BlockTable)
        Dim CurAttr As AttribTemplateOne
        Dim AttId As ObjectId
        Dim ret As Boolean
        For Each bro As BlockRefOne In Me.BlockOnes

            Dim tr As Transaction = db.TransactionManager.StartTransaction()
            For Each CurAttr In Me.NewAttTemplateAll.AttrList
                If CurAttr.Tag Is Nothing Then Continue For
                If GlbSrvArx.DoesContainAttribute(tr, bro.BlockObj.AttributeCollection, CurAttr.Tag, AttId) Then
                    attRef = CType(tr.GetObject(AttId, OpenMode.ForWrite), AttributeReference)
                    If CurAttr.AttValue Is Nothing Then
                        attRef.TextString = ""
                        Continue For
                    End If
                    attRef.TextString = CurAttr.AttValue
                Else
                    Dim tempA As AttribTemplateOne = bro.BlockAttrib.GetAttrByTag(CurAttr.Tag)
                    Dim FormVal As Boolean = True
                    If tempA IsNot Nothing OrElse CurAttr.Tag.StartsWith("AppGrp") Then
                        FormVal = False
                    End If
                    ret = GlbData.GlbSrvArx.ApplyAttributeDef(bro.BlockObj, CurAttr, FormVal)
                End If
            Next
            tr.Commit()
            tr.Dispose()
        Next
        'tr.Commit()
    End Sub

    Public Sub RemoveAttByTag(ByVal tag As String)

        If Me.BlockOnes.Count < 1 Then
            Exit Sub
        End If
        Application.DocumentManager.MdiActiveDocument.LockDocument()
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = db.TransactionManager

        Dim attRef As AttributeReference = New AttributeReference()
        'Dim bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForWrite, False), BlockTable)

        Dim AttId As ObjectId
        For Each bro As BlockRefOne In Me.BlockOnes
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
    Public Sub SetMyAtts()
        Dim Ato As AttribTemplateOne
        For Each bro As BlockRefOne In Me.BlockOnes
            For Each CurAttr As AttribTemplateOne In Me.NewAttTemplateAll.AttrList
                If CurAttr.Tag Is Nothing Then Continue For
                Ato = bro.BlockAttrib.GetAttrByTag(CurAttr.Tag)
                If Ato Is Nothing Then
                    bro.BlockAttrib.AttrList.Add(New AttribTemplateOne(CurAttr))
                Else
                    Ato.AttValue = CurAttr.AttValue
                End If

            Next
        Next
    End Sub

    Public Function GetNextAttName() As String
        If GlbData.GlbActDoc Is Nothing Then
            Return False
        End If
        Dim val, tag As String
        Dim CurNum As Integer = 0
        Dim MaxNum As Integer = 0
        For i As Integer = 0 To GlbData.GlbActDoc.SummaryInfo.NumCustomInfo - 1
            GlbData.GlbActDoc.SummaryInfo.GetCustomByIndex(i, tag, Val)
            If tag Is Nothing Then
                Continue For
            End If
            If Not tag.StartsWith("SP") Then
                Continue For
            End If
            If Not IsNumeric(tag.Chars(3)) Then
                Continue For
            End If
            CurNum = tag.Chars(3).ToString()
            If MaxNum < CurNum Then
                MaxNum = CurNum
            End If
        Next
       
        Return "SP" & MaxNum + 1

    End Function
   
#Region "Properties"
    Public Property AttTemplateAll() As AttribTemplateAll
        Get
            Return _AttTemplateAll
        End Get
        Set(ByVal value As AttribTemplateAll)
            _AttTemplateAll = value
        End Set
    End Property
    Public Property BlockOnes() As List(Of BlockRefOne)
        Get
            Return _BlockOnes
        End Get
        Set(ByVal value As List(Of BlockRefOne))
            _BlockOnes = value
        End Set
    End Property
    Public Property EditedRows() As List(Of Integer)
        Get
            Return _EditedRows
        End Get
        Set(ByVal value As List(Of Integer))
            _EditedRows = value
        End Set
    End Property
    Public Property NewAttTemplateAll() As AttribTemplateAll
        Get
            Return _NewAttTemplateAll
        End Get
        Set(ByVal value As AttribTemplateAll)
            _NewAttTemplateAll = value
        End Set
    End Property

#End Region
    
End Class