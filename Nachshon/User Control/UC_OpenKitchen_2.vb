Public Class UC_OpenKitchen_2

   

    Private Sub btnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Len(GlbData.GlbActiveKitchen.Name) > 0 Then
            GlbData.GlbMainUc.SetButtonsByMode(MainMenuButtonsMode.KitchenOk)
        End If
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub UC_OpenKitchen_2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblProjNameTxt.Text = GlbData.GlbActiveProject.Name

        'Set Button Mode
        '      SetButtonMode(ButtonMode.BeforeSelectKitchen)

        'Fill Kitchen List 
        'FillKitchList()
    End Sub

    Public Sub FillKitchList()
        Dim ch As Integer
        Dim Path2Project As String
        Dim FileList() As String
        Dim CurIndx As Integer
        Dim CurName As String
        Me.lstBoxKitchList.Items.Clear()
        Me.lblProjNameTxt.Text = GlbData.GlbActiveProject.Name
        Path2Project = GlbData.GlbActiveProject.Path2Folder
        FileList = System.IO.Directory.GetFiles(Path2Project, "*.dwg")
        If FileList Is Nothing Then
            Exit Sub
        End If
        For ch = 0 To UBound(FileList)
            CurIndx = FileList(ch).LastIndexOf("\")
            CurName = Mid(FileList(ch), CurIndx + 2)
            CurIndx = InStr(CurName.ToLower(), ".dwg")
            If CurIndx < 1 Then
                Continue For
            End If
            CurName = Mid(CurName, 1, CurIndx - 1)
            If Not CurName.StartsWith(GlbData.GlbActiveProject.PartNumb) Then 'SZ
                Continue For
            End If
            Me.lstBoxKitchList.Items.Add(Trim(CurName))
        Next ch

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.lstBoxKitchList.SelectedItems.Count > 0 Then
            KitchSelected()
        Else 'SZ
            'GlbData.GlbArxApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("No Kitchen selected, Please select a kitchen")
            'MsgBox("No Kitchen selected " & vbCr & "Please select a kitchen")
        End If

    End Sub

    Private Sub KitchSelected()
        Dim CurIndx As Integer
        Dim KitchName As String
        Dim Path2Kitchen As String
        Dim StrTmp As String
        'Dim CurPrj As ProjOne = GlbData.GlbActiveProject
        'GlbData.GlbData_Ini(GlbData.GlbMainUc)
        'GlbData.GlbActiveProject = CurPrj
        GlbData.GlbData_Refresh()
        CurIndx = Me.lstBoxKitchList.SelectedIndex()
        KitchName = Me.lstBoxKitchList.Items(CurIndx)

        'Open Document 
        Path2Kitchen = GlbData.GlbActiveProject.Path2Folder
        GlbData.GlbSrvFunc.AddSlash2Path(Path2Kitchen)
        Path2Kitchen = Path2Kitchen & KitchName & ".dwg"

        GlbData.GlbActDoc = GlbData.GlbAcadApp.Documents.Open(Path2Kitchen)
        Dim dm As Autodesk.AutoCAD.ApplicationServices.DocumentCollection = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager()
        'If GlbData.GlbSrvArx IsNot Nothing AndAlso GlbData.GlbSrvArx.ActiveDoc IsNot Nothing Then
        '    RemoveHandler dm.DocumentLockModeChanged, AddressOf GlbData.GlbSrvArx.vetoDeleteCommand
        'End If

        GlbData.GlbSrvArx = New SrvObjectARX()
        'AddHandler dm.DocumentLockModeChanged, AddressOf GlbData.GlbSrvArx.vetoDeleteCommand
        GlbData.EmtySS = GlbData.GlbSrvArx.ActiveDoc.Editor.SelectImplied().Value
        GlbData.GlbAttrTempObj.LoadFromDB()
        GlbData.GlbAttrTempObj.LoadFromCustomProp()
        GlbData.GlbActDoc.WindowState = Autodesk.AutoCAD.Interop.Common.AcWindowState.acNorm
        'Get Properties 


        StrTmp = GlbData.GlbSrvFunc.GetFileProperty(GlbEnum.FilePropertNames.CustomProp_PartNumber)
        Me.txtPN.Text = StrTmp

        StrTmp = GlbData.GlbSrvFunc.GetFileProperty(GlbEnum.FilePropertNames.CustomProp_Description)
        Me.txtNameEng.Text = StrTmp

        StrTmp = GlbData.GlbSrvFunc.GetFileProperty(GlbEnum.FilePropertNames.CustomProp_DescriptionHeb)
        Me.TxtNameHeb.Text = StrTmp

        GlbData.GlbActiveKitchen.Kitch_Ini()
        GlbData.GlbActiveKitchen.Name = KitchName
        GlbData.GlbActiveKitchen.PartNumb = Me.txtPN.Text
        GlbData.GlbActiveKitchen.NameHeb = Me.txtNameEng.Text
        GlbData.GlbBlocks.LoadBlocks()
        GlbData.GlbSrvArx.LoadPolyLines()
        GlbData.GlbKnumList = GlbData.GlbBlocks.GetListKnumForCombo()
        'GlbData.GlbAcadApp.ZoomExtents()
        '     GlbData.GlbMainUc.SetButtonsByMode(MainMenuButtonsMode.KitchenOk)
    End Sub

    Private Sub lstBoxKitchList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstBoxKitchList.DoubleClick
        If Me.lstBoxKitchList.SelectedItems.Count > 0 Then
            KitchSelected()
        Else 'SZ
            GlbData.GlbArxApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("No Kitchen selected, Please select a kitchen")
        End If

    End Sub

    
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        GlbData.GlbActiveKitchen.PartNumb = Me.txtPN.Text
        GlbData.GlbActiveKitchen.Name = Me.txtNameEng.Text
        GlbData.GlbActiveKitchen.NameHeb = Me.TxtNameHeb.Text

        GlbData.GlbSrvFunc.UpdateFileProperty(GlbEnum.FilePropertNames.CustomProp_PartNumber, _
                                              GlbData.GlbActiveKitchen.PartNumb)
        GlbData.GlbSrvFunc.UpdateFileProperty(GlbEnum.FilePropertNames.CustomProp_Description, _
                                              GlbData.GlbActiveKitchen.Name)
        GlbData.GlbSrvFunc.UpdateFileProperty(GlbEnum.FilePropertNames.CustomProp_DescriptionHeb, _
                                             GlbData.GlbActiveKitchen.NameHeb)

        Me.Parent.Controls.Remove(Me)
        GlbData.GlbMainUc.SetButtonsByMode(MainMenuButtonsMode.KitchenOk)


    End Sub

    Private Sub txtPN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPN.TextChanged

    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub

End Class
