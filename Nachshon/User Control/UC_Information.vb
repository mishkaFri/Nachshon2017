Imports System
Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic
Public Class UC_Information

    Private Sub UC_Information_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.txtProjectName.Text = GlbData.GlbActiveProject.Name
        Me.txtProjectPN.Text = GlbData.GlbActiveProject.PartNumb
        Me.txtProjDescrip.Text = GlbData.GlbActiveProject.Name
        Me.TxtNameHeb.Text = GlbData.GlbActiveProject.NameHeb

        Me.txtKitchName.Text = GlbData.GlbActiveKitchen.Name
        Me.txtKitchPN.Text = GlbData.GlbActiveKitchen.PartNumb
        Me.txtKitchNameEng.Text = GlbData.GlbActiveKitchen.Name
        Me.TxtKitNameHeb.Text = GlbData.GlbActiveKitchen.NameHeb

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Parent.Controls.Remove(Me)
        GlbData.GlbMainUc.SetButtonsByMode(MainMenuButtonsMode.KitchenOk)
    End Sub

    Public Sub LoadInEditMode()
        UC_Information_Load(New Object(), New System.EventArgs())
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim ch As Integer
        Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        Dim prEnt As PromptEntityOptions = New PromptEntityOptions("Pick Block")
        Dim prEntRes As PromptEntityResult = ed.GetEntity(prEnt)
        Dim ent As Entity = Nothing
        Dim CurBlock As BlockRefOne = Nothing
        Dim FoundBlock As BlockRefOne = Nothing

        If prEntRes.Status <> PromptStatus.OK Then
            Exit Sub
        End If

        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        tm = db.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()

        ent = tr.GetObject(prEntRes.ObjectId, OpenMode.ForRead)

        If ent IsNot Nothing AndAlso TypeOf ent Is BlockReference Then
            Dim CurBlockRef As BlockReference = CType(ent, BlockReference)
            If GlbData.GlbBlocks.BlockList Is Nothing Then
                Exit Sub
            End If

            FoundBlock = Nothing
            For ch = 1 To GlbData.GlbBlocks.BlockList.Count
                CurBlock = GlbData.GlbBlocks.BlockList.Item(ch)
                If CurBlock.BlockObj.ObjectId.GetHashCode() = CurBlockRef.ObjectId.GetHashCode() Then
                    FoundBlock = CurBlock
                    Exit For
                End If
            Next ch
        End If
        tr.Dispose()
        If FoundBlock Is Nothing Then
            Exit Sub
        End If
        Dim Caw As New ClsAttWork(FoundBlock)
        Dim Atbl As New AttributeTlb(Caw, False)
        Application.ShowModelessDialog(Application.MainWindow.Handle, Atbl, False)
        GlbData.GlbSrvArx.FinishAction()
        'Atbl.GenerateTbl()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ch As Integer
        Dim CurBlkOne As BlockRefOne

        For ch = 1 To GlbData.GlbBlocks.BlockList.Count
            CurBlkOne = GlbData.GlbBlocks.BlockList.Item(ch)
            'GlbData.GlbSrvArx.ApplyAttributeDef(CurBlkOne.BlockObj, "KELC_HP", "300")
        Next ch


    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub
End Class
