Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic

Public Class AttributeTlb
    Private _myCaw As ClsAttWork
    Private _filters As New List(Of String)
    Private _Change As Boolean
    Private _Generated As Boolean
    Private _FillMode As Boolean
    'Private _CurBroList As New List(Of BlockRefOne)
#Region "properties"

    Public Property Change() As Boolean
        Get
            Return _Change
        End Get
        Set(ByVal value As Boolean)
            _Change = value
        End Set
    End Property

    Public Property FillMode() As Boolean
        Get
            Return _FillMode
        End Get
        Set(ByVal value As Boolean)
            _FillMode = value
        End Set
    End Property
    Public Property Filters() As List(Of String)
        Get
            Return _filters
        End Get
        Set(ByVal value As List(Of String))
            _filters = value
        End Set
    End Property
    Public Property Generated() As Boolean
        Get
            Return _Generated
        End Get
        Set(ByVal value As Boolean)
            _Generated = value
        End Set
    End Property
    Public Property MyCaw() As ClsAttWork
        Get
            Return _myCaw
        End Get
        Set(ByVal value As ClsAttWork)
            _myCaw = value
        End Set
    End Property
#End Region

    Public Sub New(ByRef Caw As ClsAttWork, ByVal Fm As Boolean)
        Me.InitializeComponent()
        Me.Change = False
        Me.Generated = False
        Me.MyCaw = Caw
        Me.FillMode = Fm
        'Me.GenerateTbl()
    End Sub
    Public Sub AddRow(ByVal Ato As AttribTemplateOne)
        Dim CellParam(6) As Object
        CellParam(0) = Ato.Tag
        CellParam(1) = Ato.AttValue
        CellParam(2) = Ato.Description
        CellParam(3) = Ato.Unit
        CellParam(4) = Ato.ShowInBom
        CellParam(5) = Ato.ShowInTender
        CellParam(6) = Ato.Category

        Dim dgvRow As New DataGridViewRow
        dgvRow.CreateCells(Me.DataGridView1, CellParam)
        Dim index As Integer = Me.DataGridView1.Rows.Add(dgvRow)
        If index >= 0 AndAlso Ato.Category <> "Added" Then
            For Each cell As System.Windows.Forms.DataGridViewCell In Me.DataGridView1.Rows.Item(index).Cells
                If cell.ColumnIndex <> 1 Then
                    cell.ReadOnly = True
                End If
            Next

        End If
    End Sub

    Public Sub GenerateTbl()
        If Me.FillMode Then
            Exit Sub
        End If
        Me.Generated = False
        For i As Integer = (Me.DataGridView1.Rows.Count - 1) To 0 Step -1
            If Not Me.DataGridView1.Rows.Item(i).IsNewRow Then
                Me.DataGridView1.Rows.RemoveAt(i)
            End If
        Next
        'Me.DataGridView1.Rows.Clear()

        For Each Ato As AttribTemplateOne In Me.MyCaw.NewAttTemplateAll.AttrList
            If Ato.Category = Me.CmbFilter.Text Or Me.CmbFilter.Text = "All" Then
                If Ato.Tag IsNot Nothing Then
                    Me.AddRow(Ato)
                End If


            End If
        Next



        'Me.Change = False
        Me.Generated = True
        If Me.MyCaw.BlockOnes.Count > 1 Then
            Exit Sub
        End If
        Dim bro As BlockRefOne = Me.MyCaw.BlockOnes.Item(0)
        Dim grpnum As Integer
        Dim grpName As String = ""
        Dim IsPar As Boolean
        If bro.IsGrpMember(grpnum, grpName, IsPar) Then
            Dim grp As Group = GlbData.GlbSrvFunc.GetorSetGroupByNum(grpnum, False)
            If grp Is Nothing Then
                Exit Sub
            End If
            If IsPar Then
                Me.LblIsGrpMem.Text = bro.BlockName & " Is " & grp.GrpName & " Parent!"
            Else
                Me.LblIsGrpMem.Text = bro.BlockName & " Is a child of " & grpName & " In  " & grp.GrpName
            End If
            Me.LblIsGrpMem.Visible = True
        Else
            Me.LblIsGrpMem.Text = bro.BlockName
            Me.LblIsGrpMem.Visible = True
        End If
    End Sub

    Private Sub AttributeTlb_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Me.Generated Then
            Exit Sub
        End If
        Me.ExitToolStripMenuItem_Click(New Object, New System.EventArgs())
    End Sub

    'Me.Visible = True

    Private Sub AttributeTlb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Char.ConvertFromUtf32(Keys.Escape) Then
            Me.ExitToolStripMenuItem_Click(New Object, New System.EventArgs())
        End If
    End Sub


    'Private Sub ByToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByToolStripMenuItem.Click
    '    me.TxtFilter .Text = e. 
    'End Sub


    Private Sub AttributeTlb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.MyCaw.EditedRows.Clear()

        If Me.FillMode Then
            Me.CmbFilter.Visible = False
            Me.Label1.Visible = False
            Dim Dgr As DataGridViewRow = Me.DataGridView1.Rows.Item(0)
            Dgr.Cells.Item("Tag").Value = Me.MyCaw.GetNextAttName()
            Exit Sub
        End If
        Me.CmbFilter.Visible = True
        Me.Label1.Visible = True
        'Me.Filters.Clear()
        For Each ato As AttribTemplateOne In GlbData.GlbAttrTempObj.AttrList
            If Not Me.Filters.Contains(ato.Category) And ato.Category IsNot Nothing Then
                Me.Filters.Add(ato.Category)
            End If
        Next
        Me.CmbFilter.Items.Clear()
        Me.CmbFilter.Items.Add("All")
        Me.CmbFilter.Items.AddRange(Me.Filters.ToArray())
        Me.CmbFilter.Items.Add("Added")
        Me.CmbFilter.SelectedItem = "All"
        'Me.LblIsGrpMem.Visible = False
        'Me.GenerateTbl()

    End Sub

    Public Sub Save2MyAtts(ByVal SaveDim As Boolean)
        If Not Application.DocumentManager.MdiActiveDocument.LockMode() = DocumentLockMode.Write Then
            Application.DocumentManager.MdiActiveDocument.LockDocument()
        End If
        MyCaw.NewAttTemplateAll.AttrList.Clear()
        If Me.FillMode Then
            Me.SaveNewKitchenAtt()
            Exit Sub
        End If
        Dim Sc(2) As Double
        ' Reset Bro scale for each block in MyCaw (only once before changing length Atts)
        For Each bro As BlockRefOne In Me.MyCaw.BlockOnes
            bro.Scale(0) = 0
            bro.Scale(1) = 0
            bro.Scale(2) = 0
        Next
        For Each dgr As DataGridViewRow In Me.DataGridView1.Rows
            If Not Me.MyCaw.EditedRows.Contains(dgr.Index) And Not (SaveDim And dgr.Cells.Item(6).Value = "Dimension") Then
                Continue For
            End If

            Dim ato As New AttribTemplateOne(MyCaw.AttTemplateAll.GetAttrByTag(dgr.Cells.Item(0).Value))
            If ato Is Nothing Then
                ato = New AttribTemplateOne()
                ato.FillFromDataGridRow(dgr)
                MyCaw.NewAttTemplateAll.AttrList.Add(ato)
                Continue For
            End If

            If ato.Category = "Dimension" AndAlso dgr.Cells.Item(1).Value <> "" Then
                For Each bro As BlockRefOne In Me.MyCaw.BlockOnes
                    Dim AtoDim As AttribTemplateOne = bro.BlockAttrib.GetAttrByTag(ato.Tag)
                    AtoDim.GetGeomAttScFactor(CDbl(dgr.Cells.Item(1).Value), bro.Scale)
                Next

            End If
            ato.FillFromDataGridRow(dgr)
            MyCaw.NewAttTemplateAll.AttrList.Add(ato)
        Next

        For Each bro As BlockRefOne In Me.MyCaw.BlockOnes
            If Me.CorrectSc(bro.Scale) And bro.BlockName.Chars(2) <> "A" Then
                GlbSrvArx.SetBrScale(bro.BlockObj, bro.Scale)
            End If
        Next

        MyCaw.SetAcadAtts()
        Me.MyCaw.SetMyAtts()
        Me.MyCaw.AttTemplateAll.addAta(Me.MyCaw.NewAttTemplateAll)
        'Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(vbCr & "Nachshon Saved!!!" & vbCr)
        GlbData.GlbActDoc.Save()
        Me.Change = False
    End Sub

    Public Sub SaveNewKitchenAtt()
        For Each dgr As DataGridViewRow In Me.DataGridView1.Rows
            If dgr.Cells.Item(0).Value Is Nothing Then
                Continue For
            End If

            If dgr.Cells.Item(6).Value Is Nothing Then
                Continue For
            End If

            If dgr.Cells.Item(2).Value Is Nothing Then
                Application.ShowAlertDialog("No Description for " & dgr.Cells.Item(0).Value)
                Continue For
            End If

            Dim ato As New AttribTemplateOne(MyCaw.AttTemplateAll.GetAttrByTag(dgr.Cells.Item(0).Value))

            If ato IsNot Nothing AndAlso ato.Tag IsNot Nothing Then
                Application.ShowAlertDialog("Attribute already exist in basic list")
                Continue For
            End If

            ato = New AttribTemplateOne()
            ato.FillFromDataGridRow(dgr)
            If ato.Tag Is Nothing Then
                Continue For
            End If
            MyCaw.NewAttTemplateAll.AttrList.Add(ato)
        Next
        Me.MyCaw.SetMyAtts()
        MyCaw.SetAcadAtts()

        Me.MyCaw.AttTemplateAll.addAta(Me.MyCaw.NewAttTemplateAll)
        For Each ato As AttribTemplateOne In Me.MyCaw.NewAttTemplateAll.AttrList
            Dim FormVal As String = ato.AttValue & "#" & ato.Description & "#" & ato.Unit & "#" _
                                               & ato.ShowInBom & "#" & ato.ShowInTender & "#" & ato.Category
            GlbData.GlbActDoc.SummaryInfo.AddCustomInfo("-" & ato.Tag, _
                                              FormVal)
            GlbData.GlbAttrTempObj.AttrList.Add(ato)
        Next

        GlbData.GlbActDoc.Save()
        Me.Change = False

    End Sub
    Private Function CorrectSc(ByRef sc() As Double) As Boolean

        For i As Integer = 0 To 2
            If sc(i) <= 0 Or sc(i) >= 10000 Then
                sc(i) = 1
            End If
        Next
        For Each d As Double In sc
            If d <> 1 Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub FilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ddi As ToolStripDropDownItem = CType(sender, ToolStripDropDownItem)
        Dim ddl As New List(Of String)
        For Each tsi As ToolStripItem In ddi.DropDownItems
            ddl.Add(tsi.Text)
        Next
        If Not ddl.Contains("All") Then
            With ddi.DropDownItems.Add("All")
                AddHandler .Click, AddressOf Smenu_Click
            End With
        End If

        For Each f As String In Me.Filters
            If Not ddl.Contains(f) Then
                With ddi.DropDownItems.Add(f)
                    AddHandler .Click, AddressOf Smenu_Click
                End With
            End If
        Next
        If Not ddl.Contains("Added") Then
            With ddi.DropDownItems.Add("Added")
                AddHandler .Click, AddressOf Smenu_Click
            End With
        End If

        ddi.ShowDropDown()
    End Sub
    Sub Smenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim n As String = CType(sender, ToolStripItem).Text
        'Me.TxtFilter.Text = n
    End Sub

    Private Sub CmbFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFilter.SelectedIndexChanged
        Me.MyCaw.NewAttTemplateAll.Set4ShowByCataegory(Me.CmbFilter.Text)
        Me.GenerateTbl()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        Me.Save2MyAtts(False)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If Change Then
            Dim ret As Integer = MsgBox("Save changes?", MsgBoxStyle.YesNoCancel)
            If ret = Microsoft.VisualBasic.MsgBoxResult.Yes Then
                Me.Save2MyAtts(False)
                Me.Generated = False
                Me.Close()
            ElseIf ret = Microsoft.VisualBasic.MsgBoxResult.No Then
                Me.Generated = False
                Me.Close()
            End If
        Else
            Me.Generated = False
            Me.Close()
        End If

        GlbData.GlbSrvFunc.UnHighLigtAll()

    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        Me.Change = True
    End Sub
    Private Sub DataGridView1_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        If Me.Generated = True Or Me.FillMode Then
            Dim Dgr As DataGridViewRow = Me.DataGridView1.Rows.Item(e.RowIndex - 1)
            Dgr.Cells.Item("Category").Value = "Added"
        End If

        If Me.FillMode Then
            Dim Dgr As DataGridViewRow = Me.DataGridView1.Rows.Item(e.RowIndex)
            Dim val As String = Me.DataGridView1.Rows.Item(e.RowIndex - 1).Cells.Item("Tag").Value
            If IsNumeric(val.Chars(2)) Then
                Dim num As Integer = CInt(val.Chars(2).ToString())
                val = val.Replace(val.Chars(2), num + 1)
            Else
                val = Me.MyCaw.GetNextAttName()
            End If

            Dgr.Cells.Item("Tag").Value = val
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If Not Me.MyCaw.EditedRows.Contains(e.RowIndex) Then
            Me.MyCaw.EditedRows.Add(e.RowIndex)
        End If
        Dim ChgAtt As New AttribTemplateOne()
        If Me.MyCaw.BlockOnes.Count = 1 Then
            If MyCaw.BlockOnes(0).BlockAttrib.DoesContainAttribute("FlgChg") = True Then
                ChgAtt = MyCaw.AttTemplateAll.GetAttrByTag("AppFlgChg")
                ChgAtt.AttValue = "1"
            Else
                ChgAtt.Tag = "AppFlgChg"
                ChgAtt.AttValue = "1"
                GlbSrvArx.SetAcadAtt(MyCaw.BlockOnes(0), ChgAtt)
                'MyCaw.AttTemplateAll.AttrList.Add(ChgAtt)
            End If
        End If

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Me.Save2MyAtts(False)
    End Sub
End Class