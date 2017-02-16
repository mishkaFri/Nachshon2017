'Imports System
'Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Interop
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic

Public Class SrvFunc

    Public Function AddSlash2Path(ByRef CurPath As String) As String
        If Right(CurPath, 1) <> "\" Then
            CurPath = CurPath & "\"
        End If
        Return CurPath
    End Function

    ''' <summary>
    ''' Parcelling given full path to file 
    ''' </summary>
    ''' <param name="Path2File">Given Full Path</param>
    ''' <param name="Path2Folder">Output Folder Path</param>
    ''' <returns>File Name</returns>
    ''' <remarks></remarks>
    Public Function ParcelFullPath(ByVal Path2File, ByRef Path2Folder) As String
        Dim FileName As String
        Dim ArrSplit() As String
        Dim CountWord As Integer

        FileName = ""
        ArrSplit = Split(Path2File, "\")

        CountWord = ArrSplit.Length
        If CountWord < 1 Then
            Return (FileName)
        End If

        Path2Folder = ""
        For ch As Integer = 0 To CountWord - 2
            Path2Folder = Path2Folder & ArrSplit(ch) & "\"
        Next ch

        FileName = ArrSplit(CountWord - 1)

        Return (FileName)
    End Function
    Public Function FillCollection(ByVal MyList As Collection) As Collection
        Dim coll As New Collection()
        For Each item As Object In MyList
            coll.Add(item)
        Next
        Return coll
    End Function

    Public Function FillDadsFuckingCollection(ByVal MyList As List(Of Object)) As Collection
        Dim coll As New Collection()
        For Each item As Object In MyList
            coll.Add(item)
        Next
        Return coll
    End Function

    Public Function FillListFromDadsFuckingCollection(ByVal coll As Collection) As List(Of BlockRefOne)
        Dim List As New List(Of BlockRefOne)
        For Each item As Object In coll
            List.Add(item)
        Next
        Return List
    End Function

    Public Function GetFileProperty(ByVal PropTag As String) As String
        Dim StrTmp As String

        StrTmp = ""
        Try
            GlbData.GlbActDoc.SummaryInfo.GetCustomByKey(PropTag, StrTmp)
        Catch ex As Exception

        End Try

        Return (StrTmp)

    End Function
    ''' <summary>
    ''' Change Document Property Value
    ''' </summary>
    ''' <param name="PropTag">Tag of Property</param>
    ''' <param name="NewPropVal">New Property Value</param>
    ''' <returns>True - Property was changed</returns>
    ''' <remarks></remarks>
    Public Function UpdateFileProperty(ByVal PropTag As String, ByVal NewPropVal As String)
        Dim RetValBool As Boolean

        RetValBool = True

        Try
            GlbData.GlbActDoc.SummaryInfo.RemoveCustomByKey(PropTag)
        Catch ex As Exception
            RetValBool = False
        End Try

        Try
            GlbData.GlbActDoc.SummaryInfo.AddCustomInfo(PropTag, NewPropVal)
        Catch ex As Exception
            RetValBool = False
        End Try

        Return (RetValBool)

    End Function

    Public Function GetUnSignedIntFmStr(ByVal str As String) As Integer
        Dim tmpStr As String = str
        While Not IsNumeric(tmpStr)
            If tmpStr.Length < 2 Then
                Return -1
            End If
            tmpStr = tmpStr.Substring(0, tmpStr.Length - 1)
        End While

        Return CInt(tmpStr)
    End Function

    Public Function GetAcadDoc(ByVal DocName As String) As AcadDocument
        For Each doc As AcadDocument In GlbData.GlbAcadApp.Documents
            If doc.FullName = DocName Then
                Return doc
            End If
        Next
        Return GlbData.GlbAcadApp.Documents.Open(DocName)
    End Function


    'Public Sub ApplyAttributeDef(ByRef BlockReference As Autodesk.AutoCAD.DatabaseServices.BlockReference)

    '    Dim Block As BlockTableRecord = _
    '         TryCast(BlockReference.BlockTableRecord.GetObject(Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead), BlockTableRecord)
    '    If Not Block.HasAttributeDefinitions Then Exit Sub
    '    If Block.Database Is Nothing Then Exit Sub
    '    Dim Trans As Transaction = Block.Database.TransactionManager.StartTransaction
    '    Try
    '        If BlockReference.Database Is Nothing Then Block.Database.AddDBObject(BlockReference)
    '        For Each Id As ObjectId In Block
    '            Dim Ent As Entity = Id.GetObject(Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead)
    '            If TypeOf Ent Is AttributeDefinition Then
    '                Dim AttDef As AttributeDefinition = Ent
    '                Dim AttRef As New AttributeReference
    '                BlockReference.AttributeCollection.AppendAttribute(AttRef)
    '                AttRef.SetPropertiesFrom(AttDef)
    '                AttRef.SetAttributeFromBlock(AttDef, BlockReference.BlockTransform)
    '                Trans.AddNewlyCreatedDBObject(AttRef, True)
    '            End If
    '        Next
    '        Trans.Commit()
    '    Catch ex As Autodesk.AutoCAD.Runtime.Exception
    '        Trans.Abort()
    '    Finally
    '        Trans.Dispose()
    '    End Try
    'End Sub

    Public Sub UnHighLigtAll()
        Dim ch As Integer
        Dim Count As Integer
        Dim CurBlockRef As BlockRefOne = Nothing

        If GlbData.GlbBlocks.BlockList Is Nothing Then
            Exit Sub
        End If

        Count = 0
        For ch = 1 To GlbData.GlbBlocks.BlockList.Count
            CurBlockRef = GlbData.GlbBlocks.BlockList.Item(ch)
            If CurBlockRef.BlockObj IsNot Nothing Then
                CurBlockRef.BlockObj.Unhighlight()
                Count += 1
            End If
        Next ch

        ' Me.lblSelCount.Text = "Blocks Selected = " & CStr(Count)

    End Sub

    Public Function GetorSetGroupByNum(ByVal GrpNum As Integer, ByVal Createnew As Boolean) As Group

        For Each grp As Group In GlbData.GlbGroups
            If grp.GroupNum = GrpNum Then
                Return grp
            End If
        Next
        If Not Createnew Then
            Return Nothing
        End If
        Dim NewGrp As New Group
        NewGrp.GroupNum = GrpNum
        GlbData.GlbGroups.Add(NewGrp)
        Return NewGrp
    End Function

    Public Function GetorSetGroupByParAtt(ByVal GrpAttTxt As String, ByVal Createnew As Boolean) As Group
        Dim NameandNum() As String = GrpAttTxt.Split("$")
        If NameandNum Is Nothing OrElse NameandNum.Length <> 2 Then
            Return Nothing
        End If
        Dim grpName As String = NameandNum(0)
        Dim grpNum As String = NameandNum(1)
        If Not IsNumeric(grpNum) Then
            Return Nothing
        End If
        For Each grp As Group In GlbData.GlbGroups
            If grp.GroupNum = CInt(grpNum) Then
                grp.GrpName = grpName
                Return grp
            End If
        Next
        If Not Createnew Then
            Return Nothing
        End If
        Dim NewGrp As New Group
        NewGrp.GroupNum = grpNum
        NewGrp.GrpName = grpName
        GlbData.GlbGroups.Add(NewGrp)
        Return NewGrp
    End Function

    Public Function GetGroupByParentName(ByVal parName As String) As Group
        Dim Pname As String = parName.Substring(0, parName.IndexOf(":"))
        Dim GNum As String = parName.Substring(parName.LastIndexOf(":") + 1)
        If GNum Is Nothing Then
            Return Nothing
        End If
        For Each grp As Group In GlbData.GlbGroups
            If grp.ParentBlock.BlockName = Pname AndAlso grp.GroupNum = CInt(GNum) Then
                Return grp
            End If
        Next
        Return Nothing
    End Function

    Public Function GetGroupByName(ByVal Name As String) As Group

        For Each grp As Group In GlbData.GlbGroups
            If grp.GrpName Is Nothing Then
                Continue For
            End If
            If Name.Equals(grp.GrpName) Then
                Return grp
            End If
        Next
        Return Nothing

    End Function

    Public Function GetGroupByKnum(ByVal Knum As String) As Group
        Dim ato As AttribTemplateOne
        For Each grp As Group In GlbData.GlbGroups
            If grp Is Nothing OrElse grp.ParentBlock Is Nothing Then
                Continue For
            End If
            ato = grp.ParentBlock.GetBlkAttrByTag("KNUM")
            If ato Is Nothing OrElse ato.AttValue Is Nothing Then
                Continue For
            End If
            If ato.AttValue = Knum Then
                Return grp
            End If
        Next
        Return Nothing

    End Function

    Public Sub UnSelectAll()
        'Dim sel As AcadSelectionSet = 
        'GlbData.GlbActDoc.ActiveSelectionSet.Clear()

    End Sub

End Class
