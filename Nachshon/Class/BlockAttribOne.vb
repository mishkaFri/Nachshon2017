Public Class BlockAttribOne
    'Private _attribTag As String
    Private _blockName As String
    Private _attribName As String
    Private _attribDefault As String
    Private _attribLength As String
    Private _attribheight As String
    Private _attribWidth As String
    Private _attribHorse As String
    Private _attribPower As String
    Public Sub New()
        Me.AttribName = ""
        Me.AttribLength = ""
        Me.AttribWidth = ""
        Me.Attribheight = ""
        Me.BlockName = ""
        Me.AttribHorse = ""
        Me.AttribPower = ""
    End Sub
#Region "properties"
    Public Property AttribDefault() As String
        Get
            Return _attribDefault
        End Get
        Set(ByVal value As String)
            _attribDefault = value
        End Set
    End Property
    Public Property Attribheight() As String
        Get
            Return _attribheight
        End Get
        Set(ByVal value As String)
            _attribheight = value
        End Set
    End Property
    Public Property AttribHorse() As String
        Get
            Return _attribHorse
        End Get
        Set(ByVal value As String)
            _attribHorse = value
        End Set
    End Property
    Public Property AttribLength() As String
        Get
            Return _attribLength
        End Get
        Set(ByVal value As String)
            _attribLength = value
        End Set
    End Property
    Public Property AttribName() As String
        Get
            Return _attribName
        End Get
        Set(ByVal value As String)
            _attribName = value
        End Set
    End Property
    'Public Property AttribTag() As String
    '    Get
    '        Return _attribTag
    '    End Get
    '    Set(ByVal value As String)
    '        _attribTag = value
    '    End Set
    'End Property
    'Public Property AttribValue() As String
    '    Get
    '        Return _attribValue
    '    End Get
    '    Set(ByVal value As String)
    '        _attribValue = value
    '    End Set
    'End Property
    Public Property AttribPower() As String
        Get
            Return _attribPower
        End Get
        Set(ByVal value As String)
            _attribPower = value
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
    Public Property AttribWidth() As String
        Get
            Return _attribWidth
        End Get
        Set(ByVal value As String)
            _attribWidth = value
        End Set
    End Property
#End Region
   

End Class
