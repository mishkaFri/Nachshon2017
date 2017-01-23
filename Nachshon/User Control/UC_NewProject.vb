Public Class UC_NewProject

    Private Sub lblPartNumb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPartNumb.Click

    End Sub

    Private Sub btnOKClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim RetValBool As Boolean
        Dim Path2Proj As String
        RetValBool = Me.MyValidate()
        If RetValBool = False Then
            Exit Sub
        End If

        'Create Folder by "project number"
        Path2Proj = Me.txtPath2Folder.Text
        GlbData.GlbSrvFunc.AddSlash2Path(Path2Proj)
        Path2Proj = Path2Proj & Me.txtPartNumber.Text 'sz
        System.IO.Directory.CreateDirectory(Path2Proj)

        'Fill GlbActiveProj Data 
        GlbData.GlbActiveProject.Proj_Ini()
        GlbData.GlbActiveProject.Path2Folder = Path2Proj
        GlbData.GlbActiveProject.PartNumb = Me.txtPartNumber.Text
        GlbData.GlbActiveProject.Name = Me.txtProjectName.Text
        GlbData.GlbActiveProject.NameHeb = Me.TxtNameHeb.Text
        GlbData.GlbActiveProject.Descrip = Me.txtDescriptor.Text

        RetValBool = GlbData.GlbActiveProject.Save2File(GlbEnum.ModeSaveProject.FromNewProject)
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Parent.Controls.Remove(Me)
    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub btnPath2Project_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath2Project.Click
        Me.FolderBrowserDialog1.ShowNewFolderButton = True
        Me.FolderBrowserDialog1.SelectedPath = Me.txtPath2Folder.Text

        Dim DK As System.Windows.Forms.DialogResult = Me.FolderBrowserDialog1.ShowDialog()
        If (DK = DialogResult.OK) Then
            If Not (String.IsNullOrEmpty(Me.FolderBrowserDialog1.SelectedPath)) Then
                Me.txtPath2Folder.Text = Me.FolderBrowserDialog1.SelectedPath
            End If
        End If
    End Sub

    Private Sub UC_NewProject_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtPath2Folder.Text = My.Settings.Path2Project
    End Sub

    Private Sub UC_NewProj_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtPath2Folder.Text = My.Settings.Path2Project

        txtDescriptor.Text = ""
    End Sub

    Private Function MyValidate() As Boolean
        Dim RetValBool As Boolean
        Dim Path2Proj As String

        RetValBool = False
        If System.IO.Directory.Exists(Me.txtPath2Folder.Text) = False Then
            Me.txtPath2Folder.Focus()
            Return (RetValBool)
        End If

        Path2Proj = Me.txtPath2Folder.Text
        GlbData.GlbSrvFunc.AddSlash2Path(Path2Proj)
        Path2Proj = Path2Proj & Me.txtProjectName.Text

        If System.IO.Directory.Exists(Path2Proj) = True Then
            MsgBox("Project: " & Path2Proj & " has exited already")
            Me.txtProjectName.Focus()
            Return (RetValBool)
        End If
        If Not IsNumeric(Me.txtPartNumber.Text) Or Me.txtPartNumber.Text.Length <> 5 Then
            MsgBox("Project Number must be 5 numeric characters")
            Me.txtPartNumber.Focus()
            Return (RetValBool)
        End If

        RetValBool = True
        Return (RetValBool)
    End Function
End Class
