
Imports Autodesk.AutoCAD.ApplicationServices

Imports Autodesk.AutoCAD.GraphicsSystem


Public Class UC_Numering

    Private Sub UC_Numering_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If GlbData.GlbKnumList Is Nothing Then
            Exit Sub
        End If

        Me.lstKnum.Items.Clear()
        For Each s As String In GlbData.GlbKnumList
            If s = "" Then
                Continue For
            End If
            Me.lstKnum.Items.Add(s)
        Next

        Me.lblSelCount.Text = ""

    End Sub

    Public Sub LoadInEditMode()
        UC_Numering_Load(New Object(), New System.EventArgs())
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'UnHighlighting to all 
        Me.lblSelCount.Text = ""
        'GlbData.GlbSrvFunc.UnHighLigtAll()
        GlbSrvArx.ActiveDoc.Editor.Regen()
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub lstKnum_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstKnum.SelectedIndexChanged
        Dim ch As Integer
        Dim CurBlockRef As BlockRefOne = Nothing
        Dim CurKnum As String = sender.selectedItem
        Dim CurAttrOne As AttribTemplateOne = Nothing

        If GlbData.GlbBlocks.BlockList Is Nothing Then
            Exit Sub
        End If

        'UnHighlighting to all 
        'GlbData.GlbSrvFunc.UnHighLigtAll()
        GlbSrvArx.ActiveDoc.Editor.Regen()
        'Set to Selection Set Blocks with Send
        Dim Count As Integer
        For ch = 1 To GlbData.GlbBlocks.BlockList.Count
            CurBlockRef = GlbData.GlbBlocks.BlockList.Item(ch)
            CurAttrOne = CurBlockRef.GetBlkAttrByTag("KNUM")
            If CurAttrOne IsNot Nothing AndAlso CurAttrOne.AttValue = CurKnum Then
                If CurBlockRef.BlockObj IsNot Nothing Then
                    CurBlockRef.BlockObj.Highlight()
                    Count += 1
                End If
            End If
        Next ch
        Me.lblSelCount.Text = "Blocks No = " & CStr(Count)
        
        GlbSrvArx.ActiveDoc.Editor.UpdateScreen()
       
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub
End Class
