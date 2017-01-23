Public Class BlockAttSet
    Private _setName As String
    Private _BlockAtts As New List(Of BlockAttribOne)
    Public Sub New()
        Me.SetName = String.Empty
    End Sub
   
#Region "properties"
    Public Property BlockAtts() As List(Of BlockAttribOne)
        Get
            Return _BlockAtts
        End Get
        Set(ByVal value As List(Of BlockAttribOne))
            _BlockAtts = value
        End Set
    End Property
    Public Property SetName() As String
        Get
            Return _setName
        End Get
        Set(ByVal value As String)
            _setName = value
        End Set
    End Property
#End Region
End Class