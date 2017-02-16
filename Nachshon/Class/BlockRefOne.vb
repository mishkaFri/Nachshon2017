Imports System
Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic

Public Class BlockRefOne
    Private Dim _blockName As String
    Private Dim _blockObj As Autodesk.AutoCAD.DatabaseServices.BlockReference
    Private _blockAttrib As AttribTemplateAll
    Private _Scale(2) As Double
    Private _flagUsed As Boolean
    Private _flagStaticKnum As Boolean
    Private _Knum As String = ""
    Private _rowInList As Integer

    Public Function LoadAttrib() As Boolean
        'Dim ch As Integer
        Dim RetValBool As Boolean
        Dim AttrColl As Autodesk.AutoCAD.DatabaseServices.AttributeCollection
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ed As Editor = doc.Editor
        Dim db As Database = doc.Database
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        Dim CurAttr As New AttribTemplateOne
        Me.BlockAttrib = New AttribTemplateAll
        'RetValBool = Me.BlockAttrib.LoadFromDB()
        tm = db.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()
        Dim AttRef As AttributeReference
        AttrColl = Me.BlockObj.AttributeCollection()
        If AttrColl Is Nothing Then
            tr.Commit()
            tr.Dispose()

            Return (False)
        End If
        For Each AttId As ObjectId In AttrColl
            AttRef = CType(tr.GetObject(AttId, OpenMode.ForRead), AttributeReference)
            'Find Attribute By Name
            CurAttr = GlbData.GlbAttrTempObj.GetAttrByTag(AttRef.Tag)
            If CurAttr IsNot Nothing Then
                CurAttr.AttValue = AttRef.TextString
                Me.BlockAttrib.AttrList.Add(New AttribTemplateOne(CurAttr))
            ElseIf AttRef.Tag.StartsWith("AppGrp") Then
                Me.SetGrpAttribute(AttRef)
                ' ElseIf AttRef.Tag Then

            Else
                If Me.FillFromAttribute(AttRef, CurAttr) Then
                    Me.BlockAttrib.AttrList.Add(New AttribTemplateOne(CurAttr))
                End If

                
            End If
        Next

        Dim Custo As List(Of AttribTemplateOne) = GlbData.GlbAttrTempObj.GetSpecial()
        For Each ato As AttribTemplateOne In Custo
            If Me.BlockAttrib.DoesContainAttribute(ato.Tag) Then
                Continue For
            End If
            Me.BlockAttrib.AttrList.Add(New AttribTemplateOne(ato))
        Next

        tr.Commit()
        tr.Dispose()

        Return (True)

    End Function

    Public Function GetNewAtts() As List(Of AttribTemplateOne)
        Dim tr As Transaction = GlbData.GlbSrvArx.ActiveDocDB.TransactionManager.StartTransaction()
        Dim oid As ObjectId
        Dim Alist As New List(Of AttribTemplateOne)
        For Each ato As AttribTemplateOne In Me.BlockAttrib.AttrList
            If GlbData.GlbSrvArx.DoesContainAttribute(tr, Me.BlockObj.AttributeCollection, ato.Tag, oid) Then
                Continue For
            End If
            Alist.Add(ato)
        Next
        tr.Commit()
        tr.Dispose()
        Return Alist
    End Function

    Public Sub SetGrpAttribute(ByVal AttRef As AttributeReference)
        Dim grp As New Group
        If AttRef.TextString Is Nothing Then
            Exit Sub
        End If
        If AttRef.Tag = "AppGrpParent" AndAlso AttRef.TextString <> "" Then
            grp = GlbData.GlbSrvFunc.GetorSetGroupByParAtt(AttRef.TextString, True)
            If grp Is Nothing Then
                Exit Sub
            End If
            grp.ParentBlock = Me
        ElseIf AttRef.Tag = "AppGrpNum" AndAlso AttRef.TextString <> "" Then
            grp = GlbData.GlbSrvFunc.GetorSetGroupByNum(CInt(AttRef.TextString), True)
            grp.BlockList.Add(Me)
        End If


    End Sub

    Public Function GetBlkAttsByPartTag(ByVal CurAttTag As String) As AttribTemplateAll
        Dim ch As Integer
        Dim CurAttr As AttribTemplateOne = Nothing
        Dim AttAll As New AttribTemplateAll
        For ch = 1 To Me.BlockAttrib.AttrList.Count
            CurAttr = Me.BlockAttrib.AttrList.Item(ch)
            If CurAttr.Tag.StartsWith(CurAttTag) AndAlso CurAttr.AttValue <> "" And CurAttr.AttValue <> " " Then
                AttAll.AttrList.Add(CurAttr)
                AttAll.NAttrib += 1
            End If
        Next ch

        Return AttAll
    End Function

    Public Function GetBlkAttrByTag(ByVal CurAttTag As String) As AttribTemplateOne
        Dim ch As Integer
        Dim FoundAttr As AttribTemplateOne = Nothing
        Dim CurAttr As AttribTemplateOne = Nothing
        For ch = 1 To Me.BlockAttrib.AttrList.Count
            CurAttr = Me.BlockAttrib.AttrList.Item(ch)
            If Trim(CurAttr.Tag) = Trim(CurAttTag) Then
                'FoundAttr = New AttribTemplateOne(CurAttr)
                FoundAttr = (CurAttr)
                Exit For
            End If
        Next ch

        Return (FoundAttr)
    End Function

    Public Function FillFromAttribute(ByVal attref As AttributeReference, ByRef CurAttr As AttribTemplateOne) As Boolean
        CurAttr = New AttribTemplateOne()
        Dim CollArr() As String = attref.TextString.Split("#")
        If CollArr.Length < 6 Then Return False
        CurAttr.Tag = attref.Tag
        'Dim tr As Transaction = GlbSrvArx.ActiveDocDB.TransactionManager.StartTransaction()
        'Dim aDif As AttributeDefinition = GlbSrvArx.GetAttDefByAttRef(attref, tr)
        'tr.dispose()
        CurAttr.AttValue = CollArr(0)
        CurAttr.Description = CollArr(1)
        CurAttr.Unit = CollArr(2)
        CurAttr.ShowInBom = CollArr(3)
        CurAttr.ShowInTender = CollArr(4)
        CurAttr.Category = CollArr(5)
        Return True
    End Function

    Public Function IsGrpMember(ByRef GrpNum As Integer, ByRef GrpParName As String, ByRef IsParent As Boolean) As Boolean
        IsGrpMember = False
        Dim AttrColl As Autodesk.AutoCAD.DatabaseServices.AttributeCollection
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ed As Editor = doc.Editor
        Dim db As Database = doc.Database
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        Dim grp As Group
        tm = db.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()
        Dim AttRef As AttributeReference
        AttrColl = Me.BlockObj.AttributeCollection()
        If AttrColl Is Nothing Then
            tr.Commit()
            tr.Dispose()
            Return (False)
        End If
        For Each AttId As ObjectId In AttrColl
            AttRef = CType(tr.GetObject(AttId, OpenMode.ForRead), AttributeReference)
            If AttRef Is Nothing OrElse AttRef.TextString = "" Then
                Continue For
            End If
            'Find Attribute By Name
            If AttRef.Tag.StartsWith("AppGrpNum") Then
                grp = GlbData.GlbSrvFunc.GetorSetGroupByNum(CInt(AttRef.TextString), False)
                If Not grp Is Nothing And grp.ParentBlock IsNot Nothing Then
                    IsGrpMember = True
                    GrpNum = grp.GroupNum
                    GrpParName = grp.ParentBlock.BlockName
                    IsParent = False
                End If


            ElseIf AttRef.Tag.StartsWith("AppGrpParent") Then
                grp = GlbData.GlbSrvFunc.GetorSetGroupByParAtt(AttRef.TextString, False)
                If Not grp Is Nothing Then
                    IsGrpMember = True
                    GrpNum = grp.GroupNum
                    GrpParName = Me.BlockName
                    IsParent = True
                End If



            End If
        Next
        tr.Commit()
        tr.Dispose()


    End Function

    Public Function GetAttrByCategory(ByVal Cat As String) As List(Of AttribTemplateOne) ' SZ
        'Get list of all attributes from the block by category
        Dim RetList As New List(Of AttribTemplateOne)
        For Each att As AttribTemplateOne In Me.BlockAttrib.AttrList
            If att.Category.StartsWith(Cat) Then
                RetList.Add(att)
            End If
        Next
        Return RetList
    End Function

#Region "Properties"

    Public Property BlockAttrib() As AttribTemplateAll
        Get
            Return _blockAttrib
        End Get
        Set(ByVal value As AttribTemplateAll)
            _blockAttrib = value
        End Set
    End Property
    Public Property BlockName() As String
        Get
            Return _blockName
        End Get
        Set(ByVal value As String)
            _blockName = value
        End Set
    End Property
    Public Property BlockObj() As Autodesk.AutoCAD.DatabaseServices.BlockReference
        Get
            Return _blockObj
        End Get
        Set(ByVal value As Autodesk.AutoCAD.DatabaseServices.BlockReference)
            _blockObj = value
        End Set
    End Property
    Public Property FlagStaticKnum() As Boolean
        Get
            Return _flagStaticKnum
        End Get
        Set(ByVal value As Boolean)
            _flagStaticKnum = value
        End Set
    End Property
    Public Property FlagUsed() As Boolean
        Get
            Return _flagUsed
        End Get
        Set(ByVal value As Boolean)
            _flagUsed = value
        End Set
    End Property
    Public Property Knum() As String
        Get
            Return _Knum
        End Get
        Set(ByVal value As String)
            _Knum = value
        End Set
    End Property
    Public Property RowInList() As Integer
        Get
            Return _rowInList
        End Get
        Set(ByVal value As Integer)
            _rowInList = value
        End Set
    End Property
    Public Property Scale() As Double()
        Get
            Return _Scale
        End Get
        Set(ByVal value As Double())
            _Scale = value
        End Set
    End Property

#End Region
    End Class
