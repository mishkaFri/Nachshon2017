Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic
'imports System .Windows .

Public Class UC_Attributes_2

    Private Sub btnAcadSelAtt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcadSelAtt.Click
        If GlbData.GlbBlocks.BlockList Is Nothing Then
            Exit Sub
        End If

        Dim BlockOnes As New List(Of BlockRefOne)
        Dim ch As Integer
        Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        Dim res As PromptSelectionResult = ed.SelectImplied()
        If res.Status = PromptStatus.Error Then Return
        Dim SS As Autodesk.AutoCAD.EditorInput.SelectionSet = res.Value
        Dim idarray As ObjectId() = SS.GetObjectIds()
        Dim CurBlock As BlockRefOne = Nothing
        Dim FoundBlock As BlockRefOne = Nothing

        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        tm = db.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()

        Dim id As ObjectId
        For Each id In idarray
            Dim ent As Entity = tr.GetObject(id, OpenMode.ForRead)

            If ent IsNot Nothing AndAlso TypeOf ent Is BlockReference Then
                Dim CurBlockRef As BlockReference = CType(ent, BlockReference)
               

                FoundBlock = Nothing
                For ch = 1 To GlbData.GlbBlocks.BlockList.Count
                    CurBlock = GlbData.GlbBlocks.BlockList.Item(ch)
                    If CurBlock.BlockObj.ObjectId.GetHashCode() = CurBlockRef.ObjectId.GetHashCode() Then
                        FoundBlock = CurBlock
                        Exit For
                    End If
                Next ch
            End If

            If FoundBlock IsNot Nothing Then
                BlockOnes.Add(FoundBlock)
            End If

        Next id
        tr.Dispose()

        If BlockOnes.Count < 1 Then
            Exit Sub
        End If

        Me.lblSelCount.Text = "Blocks No = " & CStr(BlockOnes.Count)

        Dim CurAttWork As ClsAttWork = New ClsAttWork(BlockOnes)
        Dim Atbl As New AttributeTlb(CurAttWork, False)
        Application.ShowModelessDialog(Application.MainWindow.Handle, Atbl, False)
    End Sub


    Private Sub UC_Attributes_2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.cmbKnumLst.Items.Clear()
        Me.StripKlistDropDownButton1.DropDownItems.Clear()
        Me.lblSelCount.Text = ""
        If GlbData.GlbKnumList Is Nothing Then
            Exit Sub
        End If
        For Each s As String In GlbData.GlbKnumList
            Me.cmbKnumLst.Items.Add(s)
            Me.StripKlistDropDownButton1.DropDownItems.Add(s)
        Next
        


    End Sub

    Public Sub LoadInEditMode()
        UC_Attributes_2_Load(New Object(), New System.EventArgs())
    End Sub

    Private Sub btnKnumSelAtt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKnumSelAtt.Click
        Dim ch As Integer
        Dim CurMask As String = ""
        Dim ModeMask As Integer = 0
        Dim CurBlockRef As BlockRefOne
        Dim CurAttrOne As AttribTemplateOne
        Dim BlockOnes As New List(Of BlockRefOne)
        Dim TmpMask As String
        Dim Count As Integer = 0

        If GlbData.GlbBlocks.BlockList Is Nothing Then
            Exit Sub
        End If

        'CurMask = Trim(Me.cmbKnumLst.Text)
        CurMask = Trim(Me.TxtKlist.Text)
        If CurMask.StartsWith("*") = True Then
            ModeMask = 1
        End If

        If CurMask.EndsWith("*") = True Then
            ModeMask += 2
        End If

        For ch = 1 To GlbData.GlbBlocks.BlockList.Count

            CurBlockRef = GlbData.GlbBlocks.BlockList.Item(ch)
            CurAttrOne = CurBlockRef.GetBlkAttrByTag("KNUM")
            Select Case ModeMask
                Case 0
                    If Not CurAttrOne Is Nothing Then     ' SZ
                        If CurMask = CurAttrOne.AttValue Then
                            BlockOnes.Add(CurBlockRef)
                            CurBlockRef.BlockObj.Highlight()
                            Count += 1
                        End If
                    End If
                Case 1
                        TmpMask = Mid(CurMask, 2)
                        If CurAttrOne.AttValue.EndsWith(TmpMask) = True Then
                            BlockOnes.Add(CurBlockRef)
                            CurBlockRef.BlockObj.Highlight()
                            Count += 1
                        End If
                Case 2
                        TmpMask = Mid(CurMask, 1, Len(CurMask) - 1)
                        If CurAttrOne.AttValue.StartsWith(TmpMask) = True Then
                            BlockOnes.Add(CurBlockRef)
                            CurBlockRef.BlockObj.Highlight()
                            Count += 1
                        End If

                Case 3
                        TmpMask = Mid(CurMask, 2)
                        TmpMask = Mid(TmpMask, 1, Len(TmpMask) - 1)
                        If CurAttrOne.AttValue.Contains(TmpMask) = True Then
                            BlockOnes.Add(CurBlockRef)
                            CurBlockRef.BlockObj.Highlight()
                            Count += 1
                        End If
            End Select

        Next ch

        If BlockOnes.Count < 1 Then
            Exit Sub
        End If

        Me.lblSelCount.Text = "Blocks No = " & CStr(Count)
        GlbSrvArx.ActiveDoc.Editor.UpdateScreen()
        Dim CurAttWork As ClsAttWork = New ClsAttWork(BlockOnes)
        Dim Atbl As New AttributeTlb(CurAttWork, False)
        Application.ShowModelessDialog(Application.MainWindow.Handle, Atbl, False)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.lblSelCount.Text = ""
        GlbSrvArx.ActiveDoc.Editor.Regen()
        'GlbData.GlbSrvFunc.UnHighLigtAll()
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub StripKlistDropDownButton1_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StripKlistDropDownButton1.DropDownItemClicked
        Me.TxtKlist.Text = e.ClickedItem.Text
        'Me.TxtKlist.Visible = True
    End Sub

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddAtt.Click

        Dim Blist As New List(Of BlockRefOne)
        Blist = GlbData.GlbSrvFunc.FillListFromDadsFuckingCollection(GlbData.GlbBlocks.BlockList)
        Dim CurAttWork As ClsAttWork = New ClsAttWork(Blist)
        Dim Atbl As New AttributeTlb(CurAttWork, True)
        Application.ShowModelessDialog(Application.MainWindow.Handle, Atbl)
    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub
End Class
