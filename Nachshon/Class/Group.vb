Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic


Public Class Group
    Private _ParentBlock As BlockRefOne
    Private _blockList As New List(Of BlockRefOne)
    Private _polyList As New List(Of Polyline)
    Private _GroupNum As Integer
    Private _GrpName As String
    Private _blockQntColl As New Collection
    Public Sub New()
        Me.GroupNum = -1
    End Sub
    Public Function GenGroupNum() As Integer
        Dim maxIndex As Integer = 0
        For Each grp As Group In GlbData.GlbGroups
            If grp.GroupNum > maxIndex Then
                maxIndex = grp.GroupNum
            End If
        Next
        Return maxIndex + 1
    End Function
    Public Function GetNameFromParAtt(ByVal attVal As String) As String
        If attVal.IndexOf("$") < 1 Then
            Return Nothing
        End If
        Dim tmp() As String = attVal.Split("$")
        Return tmp(0)
    End Function
    Public Sub SelfDestruct()
        GlbData.GlbSrvArx.RemoveAttByTag(Me.BlockList, "AppGrpNum")
        GlbData.GlbSrvArx.RemoveAttByTag(Me.ParentBlock, "AppGrpParent")
        GlbData.GlbSrvArx.RemoveXDataByTag(Me.PolyList, "AppGrpNum")
        GlbData.GlbGroups.Remove(Me)
    End Sub
    Public Function SaveParent() As Boolean
        If Me.ParentBlock Is Nothing Then
            Return False
        End If
        Dim grpnum As Integer
        Dim grpParName As String = ""
        Dim IsPar As Boolean

        If Me.ParentBlock.IsGrpMember(grpnum, grpParName, IsPar) Then
            If IsPar Then
                Application.ShowAlertDialog("This Block Is Already Parent In " & grpnum)
                Return False
            Else
                Application.ShowAlertDialog("This Block Is Already Member In " & grpnum)
                Return False
            End If
        End If
        If Me.BlockList.Contains(Me.ParentBlock) Then
            Application.ShowAlertDialog("This Block Is Already been chosen as this group member ")
            Return False
        End If
        Dim ParAto As New AttribTemplateOne
        ParAto.Tag = "AppGrpParent"
        ParAto.AttValue = Me.GrpName & "$" & Me.GroupNum

        SaveParent = GlbData.GlbSrvArx.SetAcadAtt(Me.ParentBlock, ParAto)


    End Function
    Public Sub SaveBlocksAndPoly()
        If Me.BlockList.Count < 1 Then
            Exit Sub
        End If

        If Me.GroupNum < 1 Then
            Exit Sub
        End If

        If Me.ParentBlock Is Nothing Then
            Exit Sub
        End If

        Dim GrpAto As New AttribTemplateOne
        GrpAto.Tag = "AppGrpNum"
        GrpAto.AttValue = Me.GroupNum
        'GrpAto.Description = "Systhema Application Group Number"
        'GrpAto.ShowInTbl = False
        'GrpAto.ShowInTender = False

        GlbData.GlbSrvArx.SetAcadAtt(Me.BlockList, GrpAto)
        GlbData.GlbSrvArx.SetGrpXData(Me.PolyList, Me.GroupNum)


        Dim ParAto As New AttribTemplateOne
        ParAto.Tag = "AppGrpParent"
        ParAto.AttValue = Me.GroupNum
        Dim parBlk As New List(Of BlockRefOne)
        parBlk.Add(Me.ParentBlock)
        GlbData.GlbSrvArx.SetAcadAtt(parBlk, ParAto)



    End Sub

    Public Function SaveBlocks(ByVal Blocks As List(Of BlockRefOne)) As Boolean
        If Blocks.Count < 1 Then
            Return False
        End If

        If Me.GroupNum < 1 Then
            Return False
        End If

        If Me.ParentBlock Is Nothing Then
            Return False
        End If

        Dim GrpAto As New AttribTemplateOne
        GrpAto.Tag = "AppGrpNum"
        GrpAto.AttValue = Me.GroupNum

        SaveBlocks = GlbData.GlbSrvArx.SetAcadAtt(Blocks, GrpAto)


    End Function

    Public Function SavePolyLines(ByRef Pol As List(Of Polyline)) As Boolean
        If Pol.Count < 1 Then
            Exit Function
        End If

        If Me.GroupNum < 1 Then
            Exit Function
        End If

        If Me.ParentBlock Is Nothing Then
            Exit Function
        End If

        SavePolyLines = GlbData.GlbSrvArx.SetGrpXData(Pol, Me.GroupNum)



    End Function

    Public Sub SetQntColl()
        Dim c As Integer
        Dim B2Rem As New List(Of BlockRefOne)

        Dim bro, Sbro As BlockRefOne
        For i As Integer = 0 To Me.BlockList.Count - 1
            bro = Me.BlockList.Item(i)
            If Me.BlockQntColl.Contains(Bro.BlockName) Then
                Continue For
            End If

            If B2Rem.Contains(bro) Then
                Continue For
            End If
            c = 1

            For j As Integer = i + 1 To Me.BlockList.Count - 1
                Sbro = Me.BlockList.Item(j)
                If B2Rem.Contains(Sbro) Then
                    Continue For
                End If
                If Sbro.BlockName = bro.BlockName Then
                    c += 1
                    B2Rem.Add(Sbro)
                End If
            Next
            Me.BlockQntColl.Add(c, bro.BlockName)

        Next

    End Sub

    Public Function CheckName(ByVal N As String) As Boolean
        If N Is Nothing OrElse N = "" Then
            Return False
        End If
        If N.Equals(Me.GrpName.Trim(Chr(32))) Then
            Return False
        End If
        For Each grp As Group In GlbData.GlbGroups
            If N.Equals(Me.GrpName.Trim(Chr(32))) Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Function ContainBlock(ByVal Bname As String) As Boolean
        For Each bro As BlockRefOne In Me.BlockList
            If Bname = bro.BlockName Then
                Return True
            End If
        Next
        Return False
    End Function
    
#Region "properties"
    Public Property BlockList() As List(Of BlockRefOne)
        Get
            Return _blockList
        End Get
        Set(ByVal value As List(Of BlockRefOne))
            _blockList = value
        End Set
    End Property
    Public Property BlockQntColl() As Collection
        Get
            Return _blockQntColl
        End Get
        Set(ByVal value As Collection)
            _blockQntColl = value
        End Set
    End Property
    Public Property GroupNum() As Integer
        Get
            Return _GroupNum
        End Get
        Set(ByVal value As Integer)
            _GroupNum = value
        End Set
    End Property
    Public Property GrpName() As String
        Get
            Return _GrpName
        End Get
        Set(ByVal value As String)
            _GrpName = value
        End Set
    End Property
    Public Property ParentBlock() As BlockRefOne
        Get
            Return _ParentBlock
        End Get
        Set(ByVal value As BlockRefOne)
            _ParentBlock = value
        End Set
    End Property
    Public Property PolyList() As List(Of Polyline)
        Get
            Return _polyList
        End Get
        Set(ByVal value As List(Of Polyline))
            _polyList = value
        End Set
    End Property

#End Region

End Class
