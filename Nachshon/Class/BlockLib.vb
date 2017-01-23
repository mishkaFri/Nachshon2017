Public Class BlockLib
    Private _Id As Integer
    Private _Code As String
    Private _NameHeb As String
    Private _NameEng As String
    Private _DrwName As String
    Private _FormName As String
    Private _Icon As Object
    Private _IsParent As Boolean
    Private _UnderObjList As List(Of Integer)
    Public Sub New(ByVal rs As ADODB.Recordset)
        If rs Is Nothing Then
            Exit Sub
        End If
        On Error Resume Next
        Me.Code = rs.Fields("Code").Value
        Me.NameHeb = rs.Fields("Name_Heb").Value
        Me.NameEng = rs.Fields("Name_Eng").Value
        Me.DrwName = rs.Fields("Acad_File").Value
        Me.Id = rs.Fields("Id").Value
        If rs.Fields("Code_Parrent").Value = String.Empty Then
            Me.IsParent = True
        Else
            Me.IsParent = False
        End If
        Me.FormName = Me.Code & " - " & Me.NameHeb

    End Sub
#Region "Prop"
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
        End Set
    End Property
    Public Property DrwName() As String
        Get
            Return _DrwName
        End Get
        Set(ByVal value As String)
            _DrwName = value
        End Set
    End Property
    Public Property FormName() As String
        Get
            Return _FormName
        End Get
        Set(ByVal value As String)
            _FormName = value
        End Set
    End Property
    Public Property Icon() As Object
        Get
            Return _Icon
        End Get
        Set(ByVal value As Object)
            _Icon = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Public Property IsParent() As Boolean
        Get
            Return _IsParent
        End Get
        Set(ByVal value As Boolean)
            _IsParent = value
        End Set
    End Property
    Public Property NameEng() As String
        Get
            Return _NameEng
        End Get
        Set(ByVal value As String)
            _NameEng = value
        End Set
    End Property
    Public Property NameHeb() As String
        Get
            Return _NameHeb
        End Get
        Set(ByVal value As String)
            _NameHeb = value
        End Set
    End Property
    Public Property UnderObjList() As List(Of Integer)
        Get
            Return _UnderObjList
        End Get
        Set(ByVal value As List(Of Integer))
            _UnderObjList = value
        End Set
    End Property
#End Region


End Class