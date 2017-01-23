Public Class BlockLibs
    Public ParentList As New List(Of BlockLib)
    Public ChildList As New List(Of BlockLib)

    Public Sub New()
        Dim conn As New DBConn
        If Not conn.OpenConnectByPath(My.Settings.Path2DB) Then
            Exit Sub
        End If
        Dim rs As New ADODB.Recordset '= conn.Connection.Execute("Select * from MenuLibrary")
        rs.Open("Select * from MenuLibrary", conn.Connection, ADODB.CursorTypeEnum.adOpenStatic, _
                        ADODB.LockTypeEnum.adLockOptimistic)
        Dim BO As BlockLib
        While Not rs.EOF
            BO = New BlockLib(rs)
            If Not BO.IsParent Then
                ChildList.Add(BO)
            Else
                ParentList.Add(BO)
            End If

            rs.MoveNext()
        End While

        For Each blockO As BlockLib In Me.ParentList
            blockO.UnderObjList = Me.GetAllSubCat(blockO.Code)
        Next


    End Sub
    Public Function GetAllSubCat(ByVal Code As String) As List(Of Integer)
        Dim ChildList As New List(Of Integer)
        For Each bo As BlockLib In Me.ChildList
            If bo.Code.StartsWith(Code) Then
                ChildList.Add(bo.Id)
            End If
        Next
        Return ChildList

    End Function

    Public Function GetBoById(ByVal Id As Integer) As BlockLib
        For Each bo As BlockLib In Me.ChildList
            If bo.Id.Equals(Id) Then
                Return bo
            End If
        Next

        For Each bo As BlockLib In Me.ParentList
            If bo.Id.Equals(Id) Then
                Return bo
            End If
        Next
        Return Nothing
    End Function

    Public Function GetBoByFname(ByVal Fname As String) As BlockLib
        For Each bo As BlockLib In Me.ChildList
            If bo.FormName.Equals(Fname) Then
                Return bo
            End If
        Next

        For Each bo As BlockLib In Me.ParentList
            If bo.FormName.Equals(Fname) Then
                Return bo
            End If
        Next
        Return Nothing
    End Function

    Public Function GetBoNameByDwg(ByVal DwgName As String) As String
        For Each bo As BlockLib In Me.ChildList
            If bo.DrwName.Equals(DwgName) Then
                Return bo.NameEng
            End If
        Next


        Return ""
    End Function
End Class
