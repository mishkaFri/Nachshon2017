Public Class AttribTemplateAll
    Private Dim _attrList As Collection
    Private _nAttrib As Integer

#Region "Properties"

    Public Property AttrList() As Collection
        Get
            Return _attrList
        End Get
        Set(ByVal value As Collection)
            _attrList = value
        End Set
    End Property

    Public Property NAttrib() As Integer
        Get
            Return _nAttrib
        End Get
        Set(ByVal value As Integer)
            _nAttrib = value
        End Set
    End Property

#End Region

    Public Sub New()
        'Dim RetValBool As Boolean
        Me.AttrList = New Collection
        Me.NAttrib = 0
    End Sub

    Public Function LoadFromDB() As Boolean
        Dim conn As New DBConn
        Dim CurAttrib As AttribTemplateOne
        Dim RetValBool As Boolean
        Dim StrTmp As String

        RetValBool = False

        If Not conn.OpenConnectByPath(My.Settings.Path2DB) Then
            Return (RetValBool)
        End If
        Dim rs As New ADODB.Recordset
        Try
            rs.Open("Select * from Attributes", conn.Connection, ADODB.CursorTypeEnum.adOpenStatic, _
                        ADODB.LockTypeEnum.adLockOptimistic)
            'rs = conn.Connection.Execute("Select * from Attributes")
        Catch ex As Exception

        End Try

        If rs Is Nothing Then
            Return (RetValBool)
        End If

        Me.AttrList = Nothing
        Me.NAttrib = 0

        While Not rs.EOF
            CurAttrib = New AttribTemplateOne
            CurAttrib.Id = rs.Fields("Id").Value
            If rs.Fields("Tag").Value IsNot System.DBNull.Value Then
                CurAttrib.Tag = rs.Fields("Tag").Value
            End If
            If rs.Fields("Description").Value IsNot System.DBNull.Value Then
                CurAttrib.Description = rs.Fields("Description").Value
            End If
            If rs.Fields("Unit").Value IsNot System.DBNull.Value Then
                CurAttrib.Unit = rs.Fields("Unit").Value
            End If
            CurAttrib.ShowInBom = False
            If rs.Fields("ShowInBom").Value IsNot System.DBNull.Value Then
                StrTmp = rs.Fields("ShowInBom").Value
                If Trim(StrTmp) = "1" Then
                    CurAttrib.ShowInBom = True
                End If
            End If

            CurAttrib.ShowInTender = False
            If rs.Fields("ShowInTender").Value IsNot System.DBNull.Value Then
                StrTmp = rs.Fields("ShowInTender").Value
                CurAttrib.ShowInTender = False
                If Trim(StrTmp) = "1" Then
                    CurAttrib.ShowInTender = True
                End If
            End If

            If rs.Fields("Category").Value IsNot System.DBNull.Value Then
                CurAttrib.Category = rs.Fields("Category").Value
            End If

            If rs.Fields("Note").Value IsNot System.DBNull.Value Then
                CurAttrib.Note = rs.Fields("Note").Value
            End If

            If rs.Fields("Reserve").Value IsNot System.DBNull.Value Then
                CurAttrib.Reserve = rs.Fields("Reserve").Value
            End If

            If Me.AttrList Is Nothing Then
                Me.AttrList = New Collection
            End If
            Me.AttrList.Add(CurAttrib)
            rs.MoveNext()
        End While

        Me.NAttrib = Me.AttrList.Count

        rs.Close()
        conn.CloseConnection()
    End Function

    Public Function LoadFromCustomProp() As Boolean
        If GlbData.GlbActDoc Is Nothing Then
            Return False
        End If
        Dim CurAttrib As AttribTemplateOne
        If Me.AttrList Is Nothing Then
            Me.AttrList = New Collection
        End If
        Dim tag, val As String
        For i As Integer = 0 To GlbData.GlbActDoc.SummaryInfo.NumCustomInfo - 1
            GlbData.GlbActDoc.SummaryInfo.GetCustomByIndex(i, tag, val)
            If tag Is Nothing Then
                Continue For
            End If
            If Not tag.StartsWith("-") Then
                Continue For
            End If
            CurAttrib = New AttribTemplateOne
            Dim CollArr() As String = val.Split("#")
            If CollArr.Length < 6 Then Continue For
            CurAttrib.Tag = tag.Substring(1)
            CurAttrib.AttValue = CollArr(0)
            CurAttrib.Description = CollArr(1)
            CurAttrib.Unit = CollArr(2)
            CurAttrib.ShowInBom = CollArr(3)
            CurAttrib.ShowInTender = CollArr(4)
            CurAttrib.Category = CollArr(5)
            Me.AttrList.Add(CurAttrib)

        Next
    End Function

    Public Sub addAta(ByVal ata As AttribTemplateAll)
        Dim tempA As AttribTemplateOne
        For Each ato As AttribTemplateOne In ata.AttrList
            tempA = Me.GetAttrByTag(ato.Tag)
            If tempA Is Nothing Then
                Me.AttrList.Add(ato)
            Else
                tempA = New AttribTemplateOne(ato)
            End If
        Next
        Me.NAttrib = Me.AttrList.Count
    End Sub

    Public Sub setAll4Show()
        For Each att As AttribTemplateOne In Me.AttrList
            att.ShowInTbl = True
        Next
    End Sub

    Public Sub Set4ShowByCataegory(ByVal Cat As String)
        If Cat.ToLower() = "all" Then
            Me.setAll4Show()
            Exit Sub
        End If
        For Each att As AttribTemplateOne In Me.AttrList
            If att Is Nothing OrElse att.Id = -1 Then
                Continue For
            End If
            If att.Category.StartsWith(Cat) Then
                att.ShowInTbl = True
            Else
                att.ShowInTbl = False
            End If
        Next
    End Sub

    Public Function DoesContainAttribute(ByVal tag As String) As Boolean
        For Each ato As AttribTemplateOne In Me.AttrList
            If ato.Tag = tag Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function GetAttrByTag(ByVal CurAttTag As String) As AttribTemplateOne
        Dim ch As Integer
        Dim FoundAttr As AttribTemplateOne = Nothing
        Dim CurAttr As AttribTemplateOne = Nothing

        For ch = 1 To Me.AttrList.Count
            CurAttr = AttrList.Item(ch)
            If Trim(CurAttr.Tag) = Trim(CurAttTag) Then
                'FoundAttr = New AttribTemplateOne(CurAttr)
                FoundAttr = (CurAttr)
                Exit For
            End If
        Next ch

        Return (FoundAttr)
    End Function

    Public Function GetSpecial() As List(Of AttribTemplateOne)
        Dim SAL As New List(Of AttribTemplateOne)
        For Each ato As AttribTemplateOne In Me.AttrList
            If ato.Tag.StartsWith("SP") Then
                SAL.Add(ato)
            End If
        Next
        Return SAL
    End Function

End Class
