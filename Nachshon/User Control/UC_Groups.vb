Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic

Public Class UC_Groups
    Private _GroupCurr As New Group
    Private _curMode As Integer
    Private _NameChanged As Boolean

#Region "Properties"

    Public Property CurMode() As Integer
        Get
            Return _curMode
        End Get
        Set(ByVal value As Integer)
            _curMode = value
        End Set
    End Property

    Public Property GroupCurr() As Group
        Get
            Return _GroupCurr
        End Get
        Set(ByVal value As Group)
            _GroupCurr = value
        End Set
    End Property

    Public Property NameChanged() As Boolean
        Get
            Return _NameChanged
        End Get
        Set(ByVal value As Boolean)
            _NameChanged = value
        End Set
    End Property

#End Region

    Private Sub UC_Groups_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim dm As DocumentCollection = Application.DocumentManager()
        'AddHandler dm.DocumentLockModeChanged, AddressOf GlbData.GlbSrvArx.vetoDeleteCommand
        Me.LoadInEditMode()
    End Sub

    Public Sub LoadInEditMode()
        ' GlbSrvArx.ActiveDoc.Editor.Regen()
        Me.GroupCurr = New Group()
        Me.lstGroups.Items.Clear()
        Me.NameChanged = False
        Me.SetMode(GroupMenuButtonsMode.StartMode)
        For Each grp As Group In GlbData.GlbGroups
            If grp.ParentBlock Is Nothing Then
                Continue For
            End If

            Me.lstGroups.Items.Add(grp.GrpName)
        Next
    End Sub

    Public Sub SetMode(ByVal mode As Integer)
        For Each cont As Control In Me.Controls
            For Each control As Control In cont.Controls
                control.Visible = False
            Next
            cont.Visible = False
        Next
        Me.LblGroups.Visible = True
        Me.btnCancel.Visible = True
        Me.BtnEdit.Visible = True
        Me.BtnAddGrp.Visible = True
        ' Me.btnOK.Visible = True

        Select Case mode
            Case GroupMenuButtonsMode.StartMode
                'Me.GrpAddGrp.Visible = False
                'Me.grpGroups.BringToFront()
                '  Me.LblGroups.Visible = True

                Me.lstGroups.Visible = True
                Me.grpGroups.Visible = True
                Me.BtnEdit.Enabled = True
                Me.BtnAddGrp.Enabled = True
            Case GroupMenuButtonsMode.Add1
                ' Me.GrpAddGrp.BringToFront()
                ' Me.LblGroups.Visible = True
                Me.TxtGrpName.Text = GroupCurr.GrpName
                Me.TxtGrpName.Visible = True
                Me.GrpAddGrp.Visible = True
                Me.LblSel.Visible = True
                Me.btnAcadSelBlock.Visible = True
                'Me.LblSelectPar.Visible = False
                'Me.btnOK.Visible = False
                'Me.grpGroups.Visible = False
                Me.BtnEdit.Enabled = False
                Me.BtnAddGrp.Enabled = False
                'Me.lstBlocksInAss.Visible = False
            Case GroupMenuButtonsMode.Add2
                '  Me.LblGroups.Visible = True
                Me.GrpAddGrp.Visible = True
                'Me.LblSel.Visible = True
                'Me.btnAcadSelBlock.Visible = True
                Me.LblSelectPar.Visible = True
                'Me.btnOK.Visible = False
                'Me.grpGroups.Visible = False
                Me.BtnEdit.Enabled = False
                Me.BtnAddGrp.Enabled = False
                'Me.lstBlocksInAss.Visible = False
            Case GroupMenuButtonsMode.Edit
                Me.NameChanged = False
                Me.TxtGrpName.Text = GroupCurr.GrpName
                Me.TxtGrpName.Visible = True
                Me.LblGroups.Visible = False
                Me.GrpAddGrp.Visible = True
                Me.lstBlocksInAss.Visible = True
                Me.BtnAddToGrp.Visible = True
                Me.BtnEraseFmGrp.Visible = True



        End Select
        Me.CurMode = mode
    End Sub

    Private Sub BtnAddGrp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddGrp.Click
        GroupCurr.GroupNum = GroupCurr.GenGroupNum()
        GroupCurr.GrpName = "Group" & GroupCurr.GroupNum
        Me.TxtGrpName.Text = GroupCurr.GrpName
        Me.SetMode(GroupMenuButtonsMode.Add1)
        'Me.CurMode = GroupMenuButtonsMode.Add1
        Me.lstBlocksInAss.Items.Clear()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If CurMode = GroupMenuButtonsMode.StartMode Then
            'GlbSrvArx.ActiveDoc.Editor.Regen()
            GlbData.GlbSrvArx.FinishAction()
            'GlbData.GlbGroups.Item(1).BlockList.Item(1)
            Me.Parent.Controls.Remove(Me)
        Else

            Me.LoadInEditMode()
        End If
    End Sub

    Private Sub btnAcadSelBlock_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAcadSelBlock.Click
        Dim selBlocks As List(Of BlockRefOne) = GlbData.GlbSrvArx.GetSelectedBlocks()
        Dim selPoly As List(Of Polyline) = GlbData.GlbSrvArx.GetSelectedPolylines()
        If (selBlocks IsNot Nothing AndAlso selBlocks.Count < 1) And (selPoly IsNot Nothing AndAlso selPoly.Count < 1) Then
            Application.ShowAlertDialog("No Blocks or PolyLines Selected")
            Exit Sub
        End If
        Dim TmpKnum As String
        For Each blk As BlockRefOne In selBlocks
            TmpKnum = blk.BlockAttrib.AttrList.Item(3).AttValue
            If TmpKnum = Nothing Or TmpKnum = "" Then   'SZ - exit if the block doesn't have KNUM
                Application.ShowAlertDialog("One or more of the group members have no KNUM" & vbCr & "Please apply Numbering before creating groups")
                selBlocks.Clear()
                selPoly.Clear()
                Exit Sub
            End If
        Next
        GroupCurr.BlockList.AddRange(selBlocks)
        GroupCurr.PolyList.AddRange(selPoly)
        Me.SetMode(GroupMenuButtonsMode.Add2)
        Dim Bro As BlockRefOne = GlbData.GlbSrvArx.StartAndPickBlock()
        TmpKnum = Nothing
        TmpKnum = Bro.BlockAttrib.AttrList.Item(3).AttValue
        If TmpKnum = Nothing Or TmpKnum = "" Then 'SZ - exit if the block doesn't have KNUM
            Application.ShowAlertDialog("The Parent member have no KNUM" & vbCr & "Please apply Numbering before creating groups")
            selBlocks.Clear()
            selPoly.Clear()
            Exit Sub
        End If

        If Bro IsNot Nothing Then
            GroupCurr.ParentBlock = Bro
            Me.ShowAssList()

            Me.LblSelectPar.Visible = False
            Me.lstBlocksInAss.Visible = True
            Me.btnOK.Visible = True
        End If

        'GlbData.GlbSrvFunc.UnSelectAll()
        GlbData.GlbSrvArx.UnSelectAll()

    End Sub

    Private Sub btnOK_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ' GroupCurr.GroupNum = GroupCurr.GenGroupNum()
        'GroupCurr.GrpName = Me.TxtGrpName.Text
        If Not GroupCurr.SaveParent() Then

            'Application.ShowAlertDialog("Can't create group " & Me.GroupCurr.ParentBlock.BlockName & " Is already a parent")
            Me.SetMode(GroupMenuButtonsMode.Add1)
            Me.lstBlocksInAss.Items.Clear()
            Exit Sub
        End If
        GroupCurr.SaveBlocks(GroupCurr.BlockList)
        GroupCurr.SavePolyLines(GroupCurr.PolyList)
        GlbData.GlbGroups.Add(GroupCurr)
        Me.LoadInEditMode()
        GlbData.GlbSrvArx.FinishAction()
    End Sub

    Public Function IsPolygonName(ByVal Name As String, ByRef area As String) As Boolean
        If Name.StartsWith("Polyline_") Then
            area = Name.Substring(Name.IndexOf("_") + 1)
            If IsNumeric(area) Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub lstBlocksInAss_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstBlocksInAss.SelectedIndexChanged

        Dim CurBlk As String = sender.selectedItem
        Dim Area As String = ""
        Dim ent As Entity
        If Me.IsPolygonName(CurBlk, Area) Then
            Dim pol As Polyline = GlbData.GlbSrvArx.GetPolylineByGroupAndArea(Me.GroupCurr, Area)
            ent = pol
        Else
            Dim CurBlockRef As BlockRefOne = GlbData.GlbBlocks.GetBlockByName(CurBlk, GroupCurr.GroupNum)
            If CurBlockRef Is Nothing Then
                Exit Sub
            End If
            ent = CurBlockRef.BlockObj
        End If

        If ent Is Nothing Then
            Exit Sub
        End If
        GlbData.GlbSrvFunc.UnHighLigtAll()
        GlbSrvArx.FinishAction()

        ent.Highlight()
        GlbSrvArx.ActiveDoc.Editor.UpdateScreen()

    End Sub

    Private Sub lstGroups_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstGroups.SelectedIndexChanged
        Dim CurBlockRef As BlockRefOne = Nothing
        Dim CurGrp As String = sender.selectedItem

        If GlbData.GlbBlocks.BlockList Is Nothing Then
            Exit Sub
        End If

        'UnHighlighting to all 
        'GlbData.GlbSrvFunc.UnHighLigtAll()
        GlbSrvArx.ActiveDoc.Editor.Regen()
        'Set to Selection Set Blocks with Send

        Dim Grp As Group = GlbData.GlbSrvFunc.GetGroupByName(CurGrp)
        If Grp Is Nothing Then
            Exit Sub
        End If
        Grp.ParentBlock.BlockObj.Highlight()
        For Each bro As BlockRefOne In Grp.BlockList

            bro.BlockObj.Highlight()

        Next
        For Each pol As Polyline In Grp.PolyList

            pol.Highlight()

        Next
        Me.lblSelCount.Text = "Blocks No = " & CStr(Grp.BlockList.Count)

        GlbSrvArx.ActiveDoc.Editor.UpdateScreen()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        If Me.lstGroups.SelectedItem Is Nothing Then
            Application.ShowAlertDialog("No Group Selected")
            Exit Sub
        End If
        Me.GroupCurr = GlbData.GlbSrvFunc.GetGroupByName(Me.lstGroups.SelectedItem)
        Me.SetMode(GroupMenuButtonsMode.Edit)

        Me.ShowAssList()
    End Sub

    Private Sub BtnAddToGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddToGrp.Click
        Dim selBlocks As List(Of BlockRefOne) = GlbData.GlbSrvArx.GetSelectedBlocks()
        Dim selPoly As List(Of Polyline) = GlbData.GlbSrvArx.GetSelectedPolylines()
        If selBlocks.Count = 0 AndAlso selPoly.Count = 0 Then
            Application.ShowAlertDialog("No Blocks or PolyLines Selected")
            Exit Sub
        End If
        If GroupCurr.SaveBlocks(selBlocks) Then
            GroupCurr.BlockList.AddRange(selBlocks)
        Else
            Application.ShowAlertDialog("This Block Is Already Member In " & Me.GroupCurr.ParentBlock.BlockName & "::" & Me.GroupCurr.GroupNum)
        End If

        If GroupCurr.SavePolyLines(selPoly) Then
            GroupCurr.PolyList.AddRange(selPoly)
        End If

        Me.ShowAssList()
    End Sub

    Private Sub BtnEraseFmGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEraseFmGrp.Click
        If Me.lstBlocksInAss.SelectedItem Is Nothing Then
            Dim MsgRes As Integer = MsgBox("Do you want to disassemble " & Me.GroupCurr.ParentBlock.BlockName, MsgBoxStyle.YesNo)
            If MsgRes = 6 Then
                Me.GroupCurr.SelfDestruct()
                Me.btnCancel_Click(New Object, New System.EventArgs)
            End If
            Exit Sub
        End If
        Dim area As String = ""
        If Not Me.IsPolygonName(Me.lstBlocksInAss.SelectedItem, area) Then
            Dim Bro As BlockRefOne = GlbData.GlbBlocks.GetBlockByName(Me.lstBlocksInAss.SelectedItem, GroupCurr.GroupNum)
            If Bro Is Nothing Then
                Exit Sub
            End If

            GlbData.GlbSrvArx.RemoveAttByTag(Bro, "AppGrpNum")
            GroupCurr.BlockList.Remove(Bro)

        Else
            Dim pol As Polyline = GlbData.GlbSrvArx.GetPolylineByGroupAndArea(Me.GroupCurr, area)
            GlbData.GlbSrvArx.RemoveXDataByTag(pol, "AppGrpNum")
            Me.GroupCurr.PolyList.Remove(pol)
        End If
        Me.ShowAssList()
    End Sub

    Public Sub ShowAssList()
        Me.lstBlocksInAss.Items.Clear()
        Me.lstBlocksInAss.Items.Add(GroupCurr.ParentBlock.BlockName)

        For Each blk As BlockRefOne In GroupCurr.BlockList
            Me.lstBlocksInAss.Items.Add(blk.BlockName)
        Next

        For Each pol As Polyline In GroupCurr.PolyList
            Me.lstBlocksInAss.Items.Add("Polyline_" & Format(pol.Area * 0.001, "0.00"))
        Next


    End Sub

    Private Sub TxtGrpName_LostFoc(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGrpName.LostFocus
        If Me.NameChanged AndAlso Me.GroupCurr.CheckName(Me.TxtGrpName.Text) Then
            Me.GroupCurr.GrpName = Me.TxtGrpName.Text.Trim(Chr(32))
            Dim ParAto As New AttribTemplateOne
            ParAto.Tag = "AppGrpParent"
            ParAto.AttValue = Me.TxtGrpName.Text & "$" & Me.GroupCurr.GroupNum

            GlbData.GlbSrvArx.SetAcadAtt(Me.GroupCurr.ParentBlock, ParAto)

        End If
    End Sub

    Private Sub TxtGrpName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGrpName.TextChanged
        If Me.GrpAddGrp.Visible = True Then
            Me.NameChanged = True
        End If

    End Sub

    Private Sub BtnCopyGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopyGrp.Click
        If Me.lstGroups.SelectedItem Is Nothing Then
            Application.ShowAlertDialog("No Group Selected")
            Exit Sub
        End If
        Me.GroupCurr = GlbData.GlbSrvFunc.GetGroupByName(Me.lstGroups.SelectedItem)
        For Each bro As BlockRefOne In Me.GroupCurr.BlockList

        Next
    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub
End Class
