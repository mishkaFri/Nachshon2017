Public Class DBConn
    Implements IDisposable


    Private _Connection As New ADODB.Connection
    Private _UserID As String
    Private _Password As String

    Public Enum ConnState
        Closed = 0
        Connecting = 2
        Connected = 1
        Executing = 4
        Fetching = 8
    End Enum

    Public Sub New()

        Me.UserID = String.Empty
        Me.Password = String.Empty
    End Sub


    Public Property Connection() As ADODB.Connection
        Get
            Return _Connection
        End Get
        Set(ByVal value As ADODB.Connection)
            _Connection = value
        End Set
    End Property

    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(ByVal value As String)
            _UserID = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property

    Public Shared Function GetConnectionString(ByRef iPath2Db As String) As String
        Dim ConnStr As String
        GetConnectionString = ""
        'ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & iPath2Db & ";" '& "Jet OLEDB:Database "
        ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" & "Data Source=" & iPath2Db & ";"
        GetConnectionString = ConnStr
    End Function

    Public Function OpenConnect(ByRef iConnStr As String) As Boolean
        Try
            Me.Connection = New ADODB.Connection()
            Me.Connection.ConnectionString = iConnStr
            If Not (String.IsNullOrEmpty(Me.UserID)) Then
                Me.Connection.Open(iConnStr, Me.UserID, Me.Password)
            Else
                Me.Connection.Open()
            End If

            If (Me.Connection.State <> ConnState.Connected) Then
                MsgBox("Connetion To DB Couldn't be established.")
                Return False
            End If
            Return True
        Catch ex As Exception
            'GlbErr.Report("Error Connecting To DB: " & ex.Message)
            MsgBox("Error while Connecting to DB.")
            Return False
        End Try

    End Function

    Public Function OpenConnectByPath(ByRef iPath2Db As String) As Boolean
        Dim ConnStr As String
        Dim RetValBool As String

        ConnStr = GetConnectionString(iPath2Db)
        RetValBool = Me.OpenConnect(ConnStr)
        Return RetValBool

    End Function

    Public Function ConnectionState() As ConnState
        If (Me.Connection Is Nothing) Then
            Return ConnState.Closed
        End If
        Return (Me.Connection.State)
    End Function

    Public Function CloseConnection() As Boolean
        If (Me.Connection Is Nothing) Then
            Return True
        End If
        Try
            If (Me.Connection.State <> ConnState.Closed) Then
                Me.Connection.Close()
            End If
            If Me.Connection.State = ConnState.Closed Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error While Closing DB.")
            'GlbErr.Report("Error While Closing DB. " & ex.Message)
        End Try
    End Function


    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
                If Not (Me.Connection Is Nothing) Then
                    If (Me.Connection.State <> ConnState.Closed) Then
                        Try
                            Me.Connection.Close()
                        Catch
                            Me.Connection = Nothing
                        End Try
                    End If
                End If
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
