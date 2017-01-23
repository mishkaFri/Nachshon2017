Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic


Public Class AttribTemplateOne
    Private _id As Integer
    Private _tag As String
    Private _description As String
    Private _unit As String
    Private _category As String
    Private _showInBom As Boolean
    Private _showInTender As Boolean
    Private _note As String
    Private _ShowInTbl As Boolean
    Private _reserve As String
    Private _attValue As String

    Public Property AttValue() As String
        Get
            Return _attValue
        End Get
        Set(ByVal value As String)
            _attValue = value
        End Set
    End Property
    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Note() As String
        Get
            Return _note
        End Get
        Set(ByVal value As String)
            _note = value
        End Set
    End Property
    Public Property Reserve() As String
        Get
            Return _reserve
        End Get
        Set(ByVal value As String)
            _reserve = value
        End Set
    End Property
    Public Property ShowInBom() As Boolean
        Get
            Return _showInBom
        End Get
        Set(ByVal value As Boolean)
            _showInBom = value
        End Set
    End Property
    Public Property ShowInTbl() As Boolean
        Get
            Return _ShowInTbl
        End Get
        Set(ByVal value As Boolean)
            _ShowInTbl = value
        End Set
    End Property
    Public Property ShowInTender() As Boolean
        Get
            Return _showInTender
        End Get
        Set(ByVal value As Boolean)
            _showInTender = value
        End Set
    End Property
    Public Property Tag() As String
        Get
            Return _tag
        End Get
        Set(ByVal value As String)
            _tag = value
        End Set
    End Property
    Public Property Unit() As String
        Get
            Return _unit
        End Get
        Set(ByVal value As String)
            _unit = value
        End Set
    End Property

    Public Sub New()
        _id = -1
        _tag = ""
        _description = ""
        _unit = ""
        _category = ""
        _showInBom = False
        _showInTender = False
        _ShowInTbl = True
        _note = ""
        _reserve = ""
        _attValue = ""

    End Sub

    Public Sub New(ByVal Ato As AttribTemplateOne)
        If Ato Is Nothing Then
            Exit Sub
        End If
        _id = Ato.Id
        _tag = Ato.Tag
        _description = Ato.Description
        _unit = Ato.Unit
        _category = Ato.Category
        _showInBom = Ato.ShowInBom
        _showInTender = Ato.ShowInTender
        _ShowInTbl = Ato.ShowInTbl
        _note = ""
        _reserve = ""
        _attValue = Ato.AttValue
    End Sub

    Public Sub FillFromDataGridRow(ByVal Dgr As DataGridViewRow)
        Me.Tag = Dgr.Cells.Item(0).Value
        Me.AttValue = Dgr.Cells.Item(1).Value
        Me.Description = Dgr.Cells.Item(2).Value
        Me.Unit = Dgr.Cells.Item(3).Value
        Me.ShowInBom = Dgr.Cells.Item(4).Value
        Me.ShowInTender = Dgr.Cells.Item(5).Value
        Me.Category = Dgr.Cells.Item(6).Value

    End Sub

   
    Public Function FillFromAttList(ByVal CurrAtt As AttribTemplateOne) As Boolean


        Me.Tag = CurrAtt.Tag
        Me.Description = CurrAtt.Description
        Me.AttValue = CurrAtt.AttValue
        Me.Unit = CurrAtt.Unit
        Me.ShowInBom = CurrAtt.ShowInBom
        Me.ShowInTender = CurrAtt.ShowInTender
        Me.Category = CurrAtt.Category
        Return True
    End Function

    Public Sub GetGeomAttScFactor(ByVal NewVal As Double, ByRef Scale() As Double)
        Dim d As Double
        If Me.AttValue = "" Then
            d = 0
        Else
            d = CDbl(Me.AttValue)
        End If


        If d = 0 Then
            Me.AttValue = NewVal
            d = NewVal
        End If
        Select Case Me.Tag
            Case "KMID_W"
                Scale(1) = (NewVal / d)
            Case "KMID_L"
                Scale(0) = (NewVal / d)
            Case "KMID_H"
                Scale(2) = (NewVal / d)
        End Select
    End Sub
End Class
