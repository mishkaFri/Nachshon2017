Public Class UC_OpenProject

    Private Sub btnPath2Project_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath2Project.Click
        Dim pathTmp As String
        Dim RetValBool As Boolean

        Me.FolderBrowserDialog1.ShowNewFolderButton = True
        Me.FolderBrowserDialog1.SelectedPath = Me.txtPath2Folder.Text

        Dim DK As System.Windows.Forms.DialogResult = Me.FolderBrowserDialog1.ShowDialog()
        If (DK = DialogResult.OK) Then
            If Not (String.IsNullOrEmpty(Me.FolderBrowserDialog1.SelectedPath)) Then
                Me.txtPath2Folder.Text = Me.FolderBrowserDialog1.SelectedPath
            End If
        End If

        If System.IO.Directory.Exists(Me.txtPath2Folder.Text) = True Then
            'Check is file ProjHead.txt existed 
            pathTmp = Me.txtPath2Folder.Text
            GlbData.GlbSrvFunc.AddSlash2Path(pathTmp)
            pathTmp = pathTmp & "ProjHead.txt"
            If System.IO.File.Exists(pathTmp) = False Then
                MsgBox("Folder: " & Me.txtPath2Folder.Text & " isNot Systhema Project")
                Exit Sub
            End If


            GlbData.GlbActiveProject.Path2Folder = Me.txtPath2Folder.Text
            RetValBool = GlbData.GlbActiveProject.Read2File()
            If RetValBool = False Then
                Exit Sub
            End If

            Me.txtProjectName.Text = GlbData.GlbActiveProject.Name
            Me.TxtNameHeb.Text = GlbData.GlbActiveProject.NameHeb
            Me.txtPartNumber.Text = GlbData.GlbActiveProject.PartNumb
            Me.txtDescriptor.Text = GlbData.GlbActiveProject.Descrip

        End If

    End Sub

    Private Sub UC_OpenProject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim PathFull As String

        Me.txtPath2Folder.Text = My.Settings.Path2Project

        Me.txtPartNumber.Text = ""
        Me.txtProjectName.Text = ""
        Me.txtDescriptor.Text = ""
        Me.TxtNameHeb.Text = ""
        'If Len(GlbData.GlbActiveProject.Name) > 0 Then
        '    PathFull = GlbData.GlbActiveProject.Path2Folder
        '    GlbData.GlbSrvFunc.AddSlash2Path(PathFull)
        '    'PathFull = PathFull & GlbData.GlbActiveProject.Name
        '    Me.txtPath2Folder.Text = PathFull

        '    Me.txtPartNumber.Text = GlbData.GlbActiveProject.PartNumb
        '    Me.txtProjectName.Text = GlbData.GlbActiveProject.Name
        '    Me.txtDescriptor.Text = GlbData.GlbActiveProject.Descrip

        'End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub bnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim RetValBool As Boolean

        GlbData.GlbActiveProject.Name = Me.txtProjectName.Text
        GlbData.GlbActiveProject.PartNumb = Me.txtPartNumber.Text
        GlbData.GlbActiveProject.Descrip = Me.txtDescriptor.Text

        RetValBool = GlbData.GlbActiveProject.Save2File(GlbEnum.ModeSaveProject.FromOpenProject)
        Me.Parent.Controls.Remove(Me)

    End Sub

    Public Sub LoadInEditMode()
        UC_OpenProject_Load(New Object(), New System.EventArgs())
    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub
End Class
