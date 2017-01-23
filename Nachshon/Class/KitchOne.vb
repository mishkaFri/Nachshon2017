Public Class KitchOne
    Private _path2Folder As String
    Private _name As String
    Private _partNumb As String
    Private _NameHeb As String
    Public Property NameHeb() As String
        Get
            Return _NameHeb
        End Get
        Set(ByVal value As String)
            _NameHeb = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Property PartNumb() As String
        Get
            Return _partNumb
        End Get
        Set(ByVal value As String)
            _partNumb = value
        End Set
    End Property
    Public Property Path2Folder() As String
        Get
            Return _path2Folder
        End Get
        Set(ByVal value As String)
            _path2Folder = value
        End Set
    End Property

    Public Sub Kitch_Ini()
        Me.Name = ""
        Me.PartNumb = ""
        Me.Path2Folder = ""
        Me.NameHeb = ""
    End Sub
End Class
