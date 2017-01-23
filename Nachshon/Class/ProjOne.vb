Public Class ProjOne
    Private Dim _path2Folder As String
    Private _name As String
    Private _nameHeb As String
    Private Dim _partNumb As String
    Private Dim _descrip As String
    Public Property Descrip() As String
        Get
            Return _descrip
        End Get
        Set(ByVal value As String)
            _descrip = value
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
    Public Property NameHeb() As String
        Get
            Return _nameHeb
        End Get
        Set(ByVal value As String)
            _nameHeb = value
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

    Public Function Save2File(ByVal FlagMode As Integer) As Boolean
        Dim path2file As String
        Dim textAll As String

        path2file = Me.Path2Folder
        GlbData.GlbSrvFunc.AddSlash2Path(path2file)
        'If FlagMode = GlbEnum.ModeSaveProject.FromNewProject Then
        '    path2file = path2file & Me.Name
        'End If
        GlbData.GlbSrvFunc.AddSlash2Path(path2file)
        path2file = path2file & "ProjHead.txt"
        If System.IO.File.Exists(path2file) = True Then
            System.IO.File.Delete(path2file)
        End If

        textAll = "Project Name = " & Me.Name & Chr(13) & Chr(10)
        textAll = textAll & "Project NameHeb = " & Me.NameHeb & Chr(13) & Chr(10)
        textAll = textAll & "Part Number = " & Me.PartNumb & Chr(13) & Chr(10)
        textAll = textAll & "Description = " & Me.Descrip & Chr(13) & Chr(10)

        System.IO.File.WriteAllText(path2file, textAll)

    End Function

    Public Function Read2File() As Boolean
        Dim retvalbool As Boolean
        Dim ch As Integer
        Dim path2file As String
        Dim textAll() As String

        Dim TagValue() As String

        path2file = Me.Path2Folder
        GlbData.GlbSrvFunc.AddSlash2Path(path2file)
        path2file = path2file & "ProjHead.txt"
        If System.IO.File.Exists(path2file) = False Then
            MsgBox("Cannot Find Header File " & path2file)
            Return (False)
        End If

        textAll = System.IO.File.ReadAllLines(path2file)

        For ch = 0 To UBound(textAll)
            TagValue = textAll(ch).Split("=")
            Select Case Trim(TagValue(0))
                Case "Project Name"
                    Me.Name = Trim(TagValue(1))
                Case "Part Number"
                    Me.PartNumb = Trim(TagValue(1))
                Case "Description"
                    Me.Descrip = Trim(TagValue(1))
                Case "Project NameHeb"
                    Me.NameHeb = Trim(TagValue(1))
            End Select
        Next ch

        retvalbool = True
        Return (RetValBool)
    End Function

    Public Sub Proj_Ini()
        Me.Name = ""
        Me.PartNumb = ""
        Me.Path2Folder = ""
        Me.Descrip = ""
    End Sub
End Class
