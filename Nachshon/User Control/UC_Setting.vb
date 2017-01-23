Public Class UC_Setting

    Private Sub UC_Setting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtPath2Catag.Text = My.Settings.Path2Catag
        Me.txtPath2DB.Text = My.Settings.Path2DB
        Me.txtPath2ProjRoot.Text = My.Settings.Path2Project
        Me.TxtTempate.Text = My.Settings.Path2Temp
        Me.txtPath2PriceDB.Text = My.Settings.Path2PriceDB
    End Sub

    Private Sub btnPath2Catag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath2Catag.Click
        Me.FolderBrowserDialog1.ShowNewFolderButton = True

        Me.FolderBrowserDialog1.SelectedPath = Me.txtPath2Catag.Text

        Dim DK As System.Windows.Forms.DialogResult = Me.FolderBrowserDialog1.ShowDialog()
        If (DK = DialogResult.OK) Then
            If Not (String.IsNullOrEmpty(Me.FolderBrowserDialog1.SelectedPath)) Then
                Me.txtPath2Catag.Text = Me.FolderBrowserDialog1.SelectedPath
            End If
        End If
    End Sub

    Private Sub OpenFileDialog2_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub btnPath2ProjRoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath2ProjRoot.Click
        Me.FolderBrowserDialog1.ShowNewFolderButton = True

        Me.FolderBrowserDialog1.SelectedPath = Me.txtPath2ProjRoot.Text

        Dim DK As System.Windows.Forms.DialogResult = Me.FolderBrowserDialog1.ShowDialog()
        If (DK = DialogResult.OK) Then
            If Not (String.IsNullOrEmpty(Me.FolderBrowserDialog1.SelectedPath)) Then
                Me.txtPath2ProjRoot.Text = Me.FolderBrowserDialog1.SelectedPath
            End If
        End If
    End Sub

    Private Sub btnPath2DB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath2DB.Click
        Me.OpenFileDialog1.CheckFileExists = True
        Me.OpenFileDialog1.CheckPathExists = True
        Me.OpenFileDialog1.FileName = ""
        Try
            Me.OpenFileDialog1.InitialDirectory = Me.txtPath2DB.Text
        Catch
            Me.OpenFileDialog1.InitialDirectory = System.Environment.CurrentDirectory
        End Try

        Me.OpenFileDialog1.Title = "Select Path To DB ..."
        Dim DK As System.Windows.Forms.DialogResult = Me.OpenFileDialog1.ShowDialog()
        If (DK = DialogResult.OK) Then
            If Not (String.IsNullOrEmpty(Me.OpenFileDialog1.FileName)) Then
                Me.txtPath2DB.Text = Me.OpenFileDialog1.FileName
            End If
        End If

    End Sub

    Private Sub btnPath2PriceDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath2PriceDB.Click 'SZ
        Me.OpenFileDialog1.CheckFileExists = True
        Me.OpenFileDialog1.CheckPathExists = True
        Me.OpenFileDialog1.FileName = ""
        Try
            Me.OpenFileDialog1.InitialDirectory = Me.txtPath2PriceDB.Text
        Catch
            Me.OpenFileDialog1.InitialDirectory = System.Environment.CurrentDirectory
        End Try

        Me.OpenFileDialog1.Title = "Select Path To Prices DB ..."
        Dim DK As System.Windows.Forms.DialogResult = Me.OpenFileDialog1.ShowDialog()
        If (DK = DialogResult.OK) Then
            If Not (String.IsNullOrEmpty(Me.OpenFileDialog1.FileName)) Then
                Me.txtPath2PriceDB.Text = Me.OpenFileDialog1.FileName
            End If
        End If

    End Sub

    Private Sub BtnTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTemplate.Click
        Me.FolderBrowserDialog1.ShowNewFolderButton = True

        Me.FolderBrowserDialog1.SelectedPath = Me.txtPath2ProjRoot.Text

        Dim DK As System.Windows.Forms.DialogResult = Me.FolderBrowserDialog1.ShowDialog()
        If (DK = DialogResult.OK) Then
            If Not (String.IsNullOrEmpty(Me.FolderBrowserDialog1.SelectedPath)) Then
                Me.TxtTempate.Text = Me.FolderBrowserDialog1.SelectedPath
            End If
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        My.Settings.Path2DB = Me.txtPath2DB.Text
        My.Settings.Path2Project = Me.txtPath2ProjRoot.Text
        My.Settings.Path2Catag = Me.txtPath2Catag.Text
        My.Settings.Path2Temp = Me.TxtTempate.Text
        My.Settings.Path2PriceDB = Me.txtPath2PriceDB.Text
        My.Settings.Save()
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Parent.Controls.Remove(Me)
    End Sub

    Private Sub grpPath_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub
    
   
    
End Class
