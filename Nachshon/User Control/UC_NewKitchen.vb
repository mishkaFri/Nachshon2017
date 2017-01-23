Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices



Public Class UC_NewKitchen

    Private Sub UC_NewKitchen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblProjName.Text = GlbData.GlbActiveProject.Name

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim Path2Kitch As String
        Dim RetValBool As Boolean
        'Dim CurPrj As ProjOne = GlbData.GlbActiveProject
        'GlbData.GlbData_Ini(GlbData.GlbMainUc)
        'GlbData.GlbActiveProject = CurPrj
        GlbData.GlbData_Refresh()
        RetValBool = Me.MyValidate()
        If RetValBool = False Then
            Exit Sub
        End If

        Path2Kitch = GlbData.GlbActiveProject.Path2Folder
        GlbData.GlbSrvFunc.AddSlash2Path(Path2Kitch)
        Path2Kitch = Path2Kitch & GlbData.GlbActiveProject.PartNumb & Me.txtPartNumber.Text
        If Path2Kitch.Contains(".dwg") = False Then
            Path2Kitch = Path2Kitch & ".dwg"
        End If



        If System.IO.File.Exists(Path2Kitch) Then
            Application.ShowAlertDialog("Such kitchen already exists")
            Exit Sub
        End If

        Dim path2Temp As String = GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) & "Nachshon.dwt"
        If System.IO.File.Exists(path2Temp) Then
            GlbData.GlbActDoc = GlbData.GlbAcadApp.Documents.Add(path2Temp)
        Else
            GlbData.GlbActDoc = GlbData.GlbAcadApp.Documents.Add()
        End If

        GlbData.GlbActDoc.SummaryInfo.AddCustomInfo(GlbEnum.FilePropertNames.CustomProp_PartNumber, _
                                                Me.txtPartNumber.Text)
        GlbData.GlbActDoc.SummaryInfo.AddCustomInfo(GlbEnum.FilePropertNames.CustomProp_Description, _
                                                    Me.txtKitchName.Text)
        GlbData.GlbActDoc.SummaryInfo.AddCustomInfo(GlbEnum.FilePropertNames.CustomProp_DescriptionHeb, _
                                                   Me.txtNameHeb.Text)


        GlbData.GlbActDoc.SaveAs(Path2Kitch)
        Dim dm As Autodesk.AutoCAD.ApplicationServices.DocumentCollection = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager()
        'If GlbData.GlbSrvArx IsNot Nothing AndAlso GlbData.GlbSrvArx.ActiveDoc IsNot Nothing Then
        '    RemoveHandler dm.DocumentLockModeChanged, AddressOf GlbData.GlbSrvArx.vetoDeleteCommand
        'End If
        GlbData.GlbSrvArx = New SrvObjectARX()

        'AddHandler dm.DocumentLockModeChanged, AddressOf GlbData.GlbSrvArx.vetoDeleteCommand
        GlbData.EmtySS = GlbData.GlbSrvArx.ActiveDoc.Editor.SelectImplied().Value
        GlbData.GlbAttrTempObj.LoadFromDB()
        'Dim NumbCustInfo = GlbData.GlbActDoc.SummaryInfo.NumCustomInfo()

        GlbData.GlbActiveKitchen.Kitch_Ini()
        GlbData.GlbActiveKitchen.Name = Me.txtKitchName.Text
        GlbData.GlbActiveKitchen.PartNumb = Me.txtPartNumber.Text
        GlbData.GlbActiveKitchen.NameHeb = Me.txtNameHeb.Text


        'GlbData.GlbMainForm.SetButtonsByMode(MainMenuButtonsMode.KitchenOk)
        GlbData.GlbMainUc.SetButtonsByMode(MainMenuButtonsMode.KitchenOk)
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Function MyValidate() As Boolean
        Dim RetValBool As Boolean
        Dim Path2Kitch As String

        RetValBool = False

        If Len(Me.txtKitchName.Text) < 1 Then
            Me.txtKitchName.Focus()
            Return (RetValBool)
        End If

        Path2Kitch = GlbData.GlbActiveProject.Path2Folder
        GlbData.GlbSrvFunc.AddSlash2Path(Path2Kitch)
        Path2Kitch = Path2Kitch & Me.txtPartNumber.Text
        If Path2Kitch.Contains(".dwg") = False Then
            Path2Kitch = Path2Kitch & ".dwg"
        End If
        If System.IO.File.Exists(Path2Kitch) = True Then
            Me.txtKitchName.Focus()
            Return (RetValBool)
        End If
        If Me.txtPartNumber.Text.Length <> 3 Then
            MsgBox("Project Number must be 3 characters")
            Me.txtPartNumber.Focus()
            Return (RetValBool)
        End If

        For Each ch As Char In Me.txtPartNumber.Text
            If Not Char.IsLetter(ch) Then
                MsgBox("Project Number must not be numeric")
                Me.txtPartNumber.Focus()
                Return (RetValBool)
            End If
            'ch = Char.ToUpper(ch)
        Next
        Me.txtPartNumber.Text = Me.txtPartNumber.Text.ToUpper()
        RetValBool = True
        Return (RetValBool)
    End Function

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub

End Class
