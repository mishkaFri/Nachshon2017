
Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic



Public Class UC_Parameters
    Private ps As Autodesk.AutoCAD.Windows.PaletteSet
    'Private _Bro As BlockRefOne 
    Private _BrName As String
    Private Sc(2) As Double

    'Private Sub ComboBox1_SelectedIndexChanged( _
    'ByVal sender As System.Object, ByVal e As System.EventArgs) _
    'Handles ComboBox1.SelectedIndexChanged
    '    'toggle docking
    '    With Me.Ps1
    '        Select Case Me.ComboBox1.SelectedIndex
    '            Case Is = 0 'bottom
    '                .Dock = DockSides.Bottom
    '            Case Is = 1 'left
    '                .Dock = DockSides.Left
    '            Case Is = 2 'right
    '                .Dock = DockSides.Right
    '            Case Is = 3 ''top
    '                .Dock = DockSides.Top
    '            Case Is = 4 'float
    '                .Dock = DockSides.None
    '        End Select
    '    End With
    'End Sub

    'Public Sub New(ByVal ps As Autodesk.AutoCAD.Windows.PaletteSet)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    Me.ps = ps

    'End Sub

    Public Sub setMode(ByVal mode As Integer, ByRef BrName As String)
        Me.BrName = BrName
        Select Case mode
            Case 1
                Me.TxtXpar.Enabled = True
                Me.TxtYpar.Enabled = False
                GlbData.GlbMainUc.HideControlsInPanel()
                GlbData.GlbMainUc.pnlMain.Controls.Add(Me)
                Me.Visible = True
                Me.Update()
            Case 2
                Me.TxtXpar.Enabled = False
                Me.TxtYpar.Enabled = True
                Me.Show()
            Case 3
                Me.TxtXpar.Enabled = True
                Me.TxtYpar.Enabled = True
                GlbData.GlbMainUc.HideControlsInPanel()
                GlbData.GlbMainUc.pnlMain.Controls.Add(Me)
                Me.Visible = True
                Me.Update()
            Case 0
                Dim Bro As BlockRefOne = Me.PerformJig(BrName)
                If Bro Is Nothing Then
                    Exit Sub
                End If
                'If Bro Is Nothing Then Exit Sub
                'Dim Caw As New ClsAttWork(Bro)
                'Dim Atbl As New AttributeTlb(Caw)
                'Application.ShowModelessDialog(Application.MainWindow.Handle, Atbl, False)
                'Atbl.GenerateTbl()
                'Dim CurAttWork As New ClsAttWork(Bro)
                Dim Alist As List(Of AttribTemplateOne) = Bro.GetNewAtts()
                For Each ato As AttribTemplateOne In Alist
                    GlbData.GlbSrvArx.SetAcadAtt(Bro, ato)
                Next
                GlbData.GlbActDoc.Save()
                GlbData.GlbSrvArx.FinishAction()

        End Select


    End Sub
    Public Property BrName() As String
        Get
            Return _BrName
        End Get
        Set(ByVal value As String)
            _BrName = value
        End Set
    End Property
   
   
    Public Property Ps1() As Autodesk.AutoCAD.Windows.PaletteSet
        Get
            Return ps
        End Get
        Set(ByVal value As Autodesk.AutoCAD.Windows.PaletteSet)
            ps = value
        End Set
    End Property

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not Me.Validation() Then
            Exit Sub
        End If
        Dim bro As BlockRefOne
        Dim OldDim(1) As Double
        Dim AtoL As New AttribTemplateOne
        Dim AtoW As New AttribTemplateOne
        bro = Me.PerformJig(Me.BrName)
        If bro Is Nothing Then Exit Sub
        OldDim = Me.GetOldDim(bro)

        If Me.TxtXpar.Enabled And OldDim(0) <> 0 Then
            Sc(0) = CDbl(Me.TxtXpar.Text) / OldDim(0)
            AtoL = Me.SetNewDim(CDbl(Me.TxtXpar.Text), 0, bro)
        Else
            Sc(0) = 1
        End If

        If Me.TxtYpar.Enabled And OldDim(1) <> 0 Then

            Sc(1) = CDbl(Me.TxtYpar.Text) / OldDim(1)
            AtoW = Me.SetNewDim(CDbl(Me.TxtYpar.Text), 1, bro)
        Else
            Sc(1) = 1
        End If
        Sc(2) = 1
        GlbSrvArx.SetBrScale(bro.BlockObj, Sc)
        If AtoL IsNot Nothing AndAlso AtoL.Tag <> "" Then
            GlbData.GlbSrvArx.SetAcadAtt(bro, AtoL)
        End If

        If AtoW IsNot Nothing AndAlso AtoW.Tag <> "" Then
            GlbData.GlbSrvArx.SetAcadAtt(bro, AtoW)
        End If

        Dim Alist As List(Of AttribTemplateOne) = bro.GetNewAtts()
        For Each ato As AttribTemplateOne In Alist
            GlbData.GlbSrvArx.SetAcadAtt(bro, ato)
        Next

        ' Set "Changed" attribute
        Dim ChgAtt As New AttribTemplateOne
        ChgAtt.Tag = "AppFlgChg"
        ChgAtt.AttValue = "1"
        GlbSrvArx.SetAcadAtt(bro, ChgAtt)

        'Dim Caw As New ClsAttWork(bro)
        'Dim Atbl As New AttributeTlb(Caw)

        'Application.ShowModelessDialog(Application.MainWindow.Handle, Atbl, False)
        'Atbl.GenerateTbl()
        'Atbl.Save2MyAtts(True)
        GlbData.GlbActDoc.Save()
        GlbData.GlbSrvArx.FinishAction()
        Me.Parent.Controls.Remove(Me)
    End Sub
    Public Function Validation() As Boolean
        If Me.TxtXpar.Enabled And (Me.TxtXpar.Text = "" OrElse Not IsNumeric(Me.TxtXpar.Text)) Then
            Application.ShowAlertDialog("Please enter numeric parameter for length")
            Me.TxtXpar.Focus()
            Return False
        End If

        If Me.TxtYpar.Enabled And (Me.TxtYpar.Text = "" OrElse Not IsNumeric(Me.TxtYpar.Text)) Then
            Application.ShowAlertDialog("Please enter numeric parameter for width")
            Me.TxtYpar.Focus()
            Return False
        End If
        Return True
    End Function
    Public Function GetOldDim(ByVal bro As BlockRefOne) As Double()
        Dim dimen(1) As Double
        Dim Ato As AttribTemplateOne = bro.BlockAttrib.GetAttrByTag("KMID_L")
        If Not Ato Is Nothing AndAlso Not Ato.AttValue = "" Then
            dimen(0) = Ato.AttValue

        End If
        Ato = bro.BlockAttrib.GetAttrByTag("KMID_W")
        If Not Ato Is Nothing AndAlso Not Ato.AttValue = "" Then
            dimen(1) = Ato.AttValue
        End If
        Return dimen
    End Function

    Public Function SetNewDim(ByVal val As Double, ByVal coor As Integer, ByRef bro As BlockRefOne) As AttribTemplateOne
        Dim Ato As New AttribTemplateOne
        Select Case coor
            Case 0
                Ato = bro.BlockAttrib.GetAttrByTag("KMID_L")
                If Not Ato Is Nothing Then
                    Ato.AttValue = Sc(0)
                    'SetNewDim = Ato
                End If
            Case 1
                Ato = bro.BlockAttrib.GetAttrByTag("KMID_W")
                If Not Ato Is Nothing Then
                    Ato.AttValue = Sc(1)
                    'SetNewDim = Ato
                End If
        End Select
        Return Ato

    End Function

    Public Function PerformJig(ByVal BlName As String) As BlockRefOne
        Dim br As BlockReference = GlbSrvArx.StartBlJig(BlName)
        If br Is Nothing Then
            Return Nothing
        End If
        Dim Bro As New BlockRefOne
        Bro.BlockName = br.Name
        Bro.BlockObj = br
        Bro.BlockObj.Highlight()
        If Not Bro.LoadAttrib() Then
            Return Nothing
        End If
        Bro.BlockAttrib.LoadFromCustomProp()
        GlbData.GlbBlocks.BlockList.Add(Bro)
        Return Bro

    End Function

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub
End Class
