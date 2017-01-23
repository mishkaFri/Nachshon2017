Public Class UC_BomList
    Private _curMode As Integer

    Private Sub UC_BomList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim xlFiles() As String = System.IO.Directory.GetFileSystemEntries(GlbData.GlbActiveProject.Path2Folder, "*.xls")
        Dim wrdFiles() As String = System.IO.Directory.GetFileSystemEntries(GlbData.GlbActiveProject.Path2Folder, "*.doc")
        Me.lstList.Items.Clear()
        Me.LstBom.Items.Clear()
        Me.LstTnd.Items.Clear()
        Me.LstTndBom.Items.Clear()
        LoadBomList(xlFiles) 'SZ
        LoadTenderList(wrdFiles) 'SZ
        LoadTenderBomList(xlFiles) 'SZ

        Me.FillCurrCmb()
    End Sub

    Public Sub LoadInEditMode()
        Me.UC_BomList_Load(New Object, New System.EventArgs)
    End Sub

    Public Sub SetMode(ByVal mode As Integer)
        Me.CurMode = mode
        For Each cont As Control In Me.TpgLists.Controls
            For Each control As Control In cont.Controls
                control.Visible = False
            Next
            cont.Visible = False
        Next

        For Each cont As Control In Me.TpgBom.Controls
            For Each control As Control In cont.Controls
                control.Visible = False
            Next
            cont.Visible = False
        Next

        For Each cont As Control In Me.TpgTender.Controls
            For Each control As Control In cont.Controls
                control.Visible = False
            Next
            cont.Visible = False
        Next
        Me.TabReports.Visible = True
        Me.btnCancel.Visible = True
        Me.BomBack.Visible = True
        Me.ChkPrice.Visible = True
        Me.Grp.Hide()
        Me.BtnBomView.Show()
        Me.ProgBar.Hide()

        Select Case mode
            Case ListUcMode.ListCreation
                Me.MenuStrip1.Visible = True
                Me.RadEngBOM.Visible = True
                Me.RadHebBOM.Visible = True
                Me.CmbCurr.Visible = True
                Me.TxtExcngRate.Visible = True
                Me.CmbListypes.Visible = True
                Me.BtnCrtList.Visible = True
                Me.radListEng.Visible = True
                Me.RadListHeb.Visible = True
                Me.RadListHeb.Checked = True
                Me.BtnListView.Visible = True
                Me.GrpTndView.Show()
                For Each ctrl As Control In Me.GrpTndView.Controls
                    ctrl.Show()
                    ctrl.Visible = True
                Next

            Case ListUcMode.ListSelectionLst
                Me.grpLstview.Visible = True
                Me.lstList.Visible = True
                Me.BtnOpenXls.Visible = True
                Me.BtnInsertXL.Visible = True

            Case ListUcMode.ListSelectionBom
                Me.GrpBomView.Show()
                For Each ctrl As Control In Me.GrpBomView.Controls
                    ctrl.Show()
                    ctrl.Visible = True
                Next
                Me.ChkPrice.Visible = False

            Case ListUcMode.ListSelectionTnd
                Me.GrpTndBom.Visible = True
                Me.BtnCrtAllTender.Visible = True
                Me.BtnCrtSelTnd.Visible = True

            Case ListUcMode.ListSelectionTndBom
                Me.GrpTndBom.Show()
                For Each ctrl As Control In Me.GrpTndBom.Controls
                    ctrl.Show()
                    ctrl.Visible = True
                Next
        End Select
    End Sub

    Public Sub LoadBomList(ByVal xlFiles As String()) 'SZ
        Dim curf, subf As String
        For Each f As String In xlFiles
            curf = f.Substring(f.LastIndexOf("\") + 1)
            If Not curf.StartsWith(GlbData.GlbActiveKitchen.PartNumb) Then
                Continue For
            End If
            subf = curf.Substring(curf.IndexOf("_") + 1)
            If subf IsNot Nothing Then
                If subf.StartsWith("BOM") Or subf.StartsWith("BOQ") Or subf.StartsWith("OMD") Then
                    Me.LstBom.Items.Add(curf)
                Else
                    Me.lstList.Items.Add(curf)
                End If
            End If
        Next
    End Sub

    Public Sub LoadTenderList(ByVal wrdFiles As String()) 'SZ
        Dim curf, subf As String
        For Each f As String In wrdFiles
            curf = f.Substring(f.LastIndexOf("\") + 1)
            If Not curf.StartsWith(GlbData.GlbActiveKitchen.PartNumb) Then
                Continue For
            End If
            subf = curf.Substring(curf.IndexOf("_") + 1)
            If subf IsNot Nothing Then
                If subf.StartsWith("TND") Then
                    Me.LstTnd.Items.Add(curf)
                End If
            End If
        Next
    End Sub

    Public Sub LoadTenderBomList(ByVal xlFiles As String())
        Dim curf, subf As String
        For Each f As String In xlFiles
            curf = f.Substring(f.LastIndexOf("\") + 1)
            If Not curf.StartsWith(GlbData.GlbActiveKitchen.PartNumb) Then
                Continue For
            End If
            subf = curf.Substring(curf.IndexOf("_") + 1)
            If subf IsNot Nothing Then
                If subf.StartsWith("BOM") Or subf.StartsWith("BOQ") Or subf.StartsWith("OMD") Then
                    Me.LstTndBom.Items.Add(curf)
                End If
            End If
        Next
    End Sub

    Public Sub FillCurrCmb() 'SZ
        ' Fill Currency ComboBox from Main (SysthemaDB) database.
        Dim Rec As String
        Me.CmbCurr.Items.Clear()
        Dim conn As New DBConn
        If Not conn.OpenConnectByPath(My.Settings.Path2DB) Then
            Exit Sub
        End If
        Dim rs As New ADODB.Recordset
        Try
            rs.Open("Select * from Currencies", conn.Connection, _
                    ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            'rs = conn.Connection.Execute("Select * from Currencies")
        Catch ex As Exception
            MsgBox("No Currency table in DB")
            Exit Sub
        End Try
        If rs.EOF Then
            MsgBox("No Currency data in DB")
            Exit Sub
        End If
        While Not rs.EOF
            Try
                Rec = rs.Fields("Sign").Value
                Me.CmbCurr.Items.Add(Rec)
                rs.MoveNext()
            Catch ex As Exception
                Continue While
            End Try
        End While
        conn.CloseConnection()
        Me.CmbCurr.Text = Me.CmbCurr.Items.Item(0) ' Set Shekel as the default Currency
        Me.TxtExcngRate.Text = "1.000"
    End Sub

    Private Sub BtnOpenXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpenXls.Click
        If Me.lstList.SelectedItem Is Nothing Then
            Exit Sub
        End If
        GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder)
        Dim p2t As String = GlbData.GlbActiveProject.Path2Folder & Me.lstList.SelectedItem
        Dim Em As New ExcelManager(p2t, True)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (Me.CurMode = ListUcMode.ListSelectionLst) Then
            Me.SetMode(ListUcMode.ListCreation)
            Me.TabReports.TabIndex = 1
        Else
            Me.Parent.Controls.Remove(Me)
        End If
    End Sub

    Private Sub BtnCrtList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrtList.Click
        Dim Lang As String
        If Me.RadListHeb.Checked = True Then
            Lang = GlbEnum.Language.Hebrew
        Else
            Lang = GlbEnum.Language.English
        End If
        If Me.CmbListypes.SelectedItem Is Nothing OrElse Me.CmbListypes.SelectedItem = "" Then
            Exit Sub
        End If
        If Not (Me.CmbListypes.SelectedItem.ToString().Contains(ListTypes.Wide) Or _
        Me.CmbListypes.SelectedItem.ToString().Contains(ListTypes.Narrow) Or _
         Me.CmbListypes.SelectedItem.ToString.Contains(ListTypes.Fixed) Or _
         Me.CmbListypes.SelectedItem.ToString().Contains(ListTypes.Operational)) Then
            Exit Sub
        End If
        Me.SetProgBar(1)
        Dim Cb As New CrtTblManager(Me.CmbListypes.SelectedItem.ToString(), , , , Me, Lang)
        Cb.CreateList()
        'Me.SetMode(ListUcMode.ListSelection)
        Me.SetProgBar(0)
        Me.LoadInEditMode()
    End Sub

    Private Sub BtnInsertXL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInsertXL.Click
        Dim Fname As String = GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder) & Me.lstList.SelectedItem
        If Not System.IO.File.Exists(Fname) Then
            Exit Sub
        End If

        'GlbData.GlbSrvArx.ImportXL(Fname, Me.CmbListypes.SelectedItem)
        GlbData.GlbSrvArx.ImportOleXL(Fname)
    End Sub

    Private Sub BtnListView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnListView.Click
        Me.LoadInEditMode()
        Me.SetMode(ListUcMode.ListSelectionLst)
    End Sub

    Private Sub AllBlocksToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllBlocksToolStripMenuItem2.Click
        Dim Lang As String
        If Me.RadHebBOM.Checked = True Then
            Lang = GlbEnum.Language.Hebrew
        Else
            Lang = GlbEnum.Language.English
        End If
        SetProgBar(1) ' Reset Progress bar (On) 'SZ
        Dim Cb As New CrtTblManager("BOM", "כללי", Me.CmbCurr.Text, Me.TxtExcngRate.Text, Me, Lang)
        Cb.CreateBOM("All", "AllBlocks", Me.GrpExtended.Visible, Me.ChkPrice.Checked)
        Dim Cb1 As New CrtTblManager("BOM", "לא למכרז", Me.CmbCurr.Text, Me.TxtExcngRate.Text, Me, Lang)
        Cb1.CreateBOM("א", "NotIn", Me.GrpExtended.Visible, Me.ChkPrice.Checked)
        SetProgBar(0) ' Turn Progres bar off 'SZ
    End Sub

    Private Sub RegularToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegularToolStripMenuItem1.Click
        Me.Grp.Visible = True
        Me.ChkNotIn.Visible = True
        Me.ChkFixed.Visible = True
        Me.ChkPurchase.Visible = True
        Me.ChkCool.Visible = True
        Me.ChkProduction.Visible = True
        Me.BtnCrtBom.Show()
        'For Each ctl As Control In Me.Grp.Controls
        '    ctl.Visible = True
        'Next
        Me.GrpExtended.Visible = False

    End Sub

    Private Sub ExtendedToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtendedToolStripMenuItem1.Click
        Me.Grp.Visible = True
        Me.ChkFixed.Visible = True
        Me.ChkPurchase.Visible = True
        Me.ChkCool.Visible = True
        Me.ChkProduction.Visible = True
        Me.GrpExtended.Visible = True
        Me.BtnCrtBom.Show()
    End Sub

    Private Sub TabReports_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabReports.Selected
        If e.TabPage.Text = "BOM" Then
            'Me.GrpExtended.Visible = False
            Me.Grp.Visible = False
        End If
    End Sub

    Private Sub BtnCrtBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrtBom.Click
        Dim chBox As CheckBox
        Dim Lang As String
        If Me.RadHebBOM.Checked = True Then
            Lang = GlbEnum.Language.Hebrew
        Else
            Lang = GlbEnum.Language.English
        End If
        SetProgBar(1) ' Turn on and Reset Progress bar 'SZ
        For Each con As Control In Me.Grp.Controls
            If con.Name.StartsWith("Chk") Then
                If con Is Nothing Then
                    Continue For
                End If
                chBox = TryCast(con, CheckBox)
                If Not chBox.Checked Then
                    Continue For
                End If
                Dim Cb As New CrtTblManager("BOM", Me.ToolTip1.GetToolTip(chBox), Me.CmbCurr.Text, Me.TxtExcngRate.Text, Me, Lang)
                Cb.CreateBOM(chBox.Text, chBox.Name.Substring(3), Me.GrpExtended.Visible, Me.ChkPrice.Checked)
            End If
        Next

        If Not Me.GrpExtended.Visible Then
            Exit Sub
        End If

        For Each con As Control In Me.GrpExtended.Controls
            If con.Name.StartsWith("Chk") Then
                chBox = TryCast(con, CheckBox)
                If Not chBox.Checked Then
                    Continue For
                End If
                Dim Cb As New CrtTblManager("BOM", Me.ToolTip1.GetToolTip(chBox), Me.CmbCurr.Text, Me.TxtExcngRate.Text, Me, Lang)
                Cb.CreateBOM(chBox.Text, chBox.Name.Substring(3), Me.GrpExtended.Visible, Me.ChkPrice.Checked)
            End If
        Next
        SetProgBar(0) 'Turn off and Progress bar 'SZ
    End Sub

    Private Sub BtnCrtAllTender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrtAllTender.Click
        Dim files() As String = System.IO.Directory.GetFiles(GlbData.GlbActiveProject.Path2Folder, "*.xls")
        Dim fn, Lang As String
        Dim Wm As CrtWrdManag
        If Me.RadEngTnd.Checked = True Then
            Lang = Language.English
        Else
            Lang = Language.Hebrew
        End If
        For Each f As String In files
            fn = f.Substring(f.LastIndexOf("\") + 1)
            If Not fn.Substring(fn.IndexOf("_") + 1).StartsWith("BOM") And Not fn.Substring(fn.IndexOf("_") + 1).StartsWith("BOQ") Then
                Continue For
            End If
            SetProgBar(1)
            Wm = New CrtWrdManag(f, False, Me, Lang)
        Next
        SetProgBar(0)
    End Sub

    Private Sub BomView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBomView.Click
        Me.LoadInEditMode()
        Me.SetMode(ListUcMode.ListSelectionBom)
    End Sub

    Private Sub BtnInsertBomXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInsertBomXls.Click
        Dim Fname As String = GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder) & Me.LstBom.SelectedItem
        If Not System.IO.File.Exists(Fname) Then
            Exit Sub
        End If
        'GlbData.GlbSrvArx.ImportXL(Fname, Me.CmbListypes.SelectedItem)
        GlbData.GlbSrvArx.ImportOleXL(Fname)
    End Sub

    Private Sub BtnOpenBomXls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpenBomXls.Click
        If Me.LstBom.SelectedItem Is Nothing Then
            Exit Sub
        End If
        GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder)
        Dim p2t As String = GlbData.GlbActiveProject.Path2Folder & Me.LstBom.SelectedItem
        Dim Em As New ExcelManager(p2t, True)

    End Sub

    Private Sub BomBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BomBack.Click
        If (Me.CurMode = ListUcMode.ListSelectionBom) Then
            Me.SetMode(ListUcMode.ListCreation)
            Me.TabReports.TabIndex = 2
        Else
            Me.Parent.Controls.Remove(Me)
        End If


    End Sub

    Public Sub close()
        Me.Parent.Controls.Remove(Me)
    End Sub

    Public Property CurMode() As Integer
        Get
            Return _curMode
        End Get
        Set(ByVal value As Integer)
            _curMode = value
        End Set
    End Property

    Private Sub BtnOpenTender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpenTender.Click
        'SZ - Open Tender Document
        Dim WordApp As New Microsoft.Office.Interop.Word.Application
        Dim WordDoc As Microsoft.Office.Interop.Word.Document
        If LstTnd.SelectedItems.Count = 0 Then
            MsgBox("No Tender Selected")
            Exit Sub
        End If
        Dim P2Tnd As String = GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder) & LstTnd.SelectedItem
        WordApp.Visible = True
        Try
            WordDoc = WordApp.Documents.Open(P2Tnd)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCloseTndBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCloseTndBom.Click
        Me.LoadInEditMode()
        Me.SetMode(ListUcMode.ListCreation)
    End Sub

    Private Sub BtnCrtSelTnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrtSelTnd.Click
        Dim Bomfile As String = GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder) & Me.LstTndBom.SelectedItem
        Dim fn, Lang As String
        Dim Wm As CrtWrdManag
        fn = Bomfile.Substring(Bomfile.LastIndexOf("\") + 1)
        If Not fn.Substring(fn.IndexOf("_") + 1).StartsWith("BOM") And Not fn.Substring(fn.IndexOf("_") + 1).StartsWith("BOQ") Then
            Exit Sub
        End If
        If Me.RadEngTnd.Checked = True Then
            Lang = Language.English
        Else
            Lang = Language.Hebrew
        End If
        SetProgBar(1)
        Wm = New CrtWrdManag(Bomfile, False, Me, Lang)
        SetProgBar(0)
    End Sub

    Private Sub BtnCrtTndView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrtTndView.Click
        Me.LoadInEditMode()
        Me.SetMode(ListUcMode.ListSelectionTndBom)
    End Sub

    Private Sub TabReports_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabReports.SelectedIndexChanged
        Me.SetMode(GlbEnum.ListUcMode.ListCreation)
    End Sub

    Private Sub SetProgBar(ByVal Mode As Integer) 'SZ
        ' 0 - Off
        ' 1 - On
        Select Case Mode
            Case 1
                Me.ProgBar.Show()
                Me.ProgBar.Visible = True
                Me.ProgBar.Value = 0
            Case 0
                Me.ProgBar.Hide()
                Me.ProgBar.Visible = False
        End Select

    End Sub

    Private Sub BtnTenderBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTenderBack.Click
        If (Me.CurMode = ListUcMode.ListSelectionTndBom) Then
            Me.SetMode(ListUcMode.ListSelectionTnd)
            Me.TabReports.TabIndex = 1
        Else
            Me.Parent.Controls.Remove(Me)
        End If
    End Sub

    Private Sub LstBom_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstBom.DoubleClick
        If Me.LstBom.SelectedItem Is Nothing Then
            Exit Sub
        End If
        GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder)
        Dim p2t As String = GlbData.GlbActiveProject.Path2Folder & Me.LstBom.SelectedItem
        Dim Em As New ExcelManager(p2t, True)
    End Sub

    Private Sub LstTnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstTnd.DoubleClick
        'SZ - Open Tender Document
        Dim WordApp As New Microsoft.Office.Interop.Word.Application
        Dim WordDoc As Microsoft.Office.Interop.Word.Document
        If LstTnd.SelectedItems.Count = 0 Then
            MsgBox("No Tender Selected")
            Exit Sub
        End If
        Dim P2Tnd As String = GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder) & LstTnd.SelectedItem
        WordApp.Visible = True
        Try
            WordDoc = WordApp.Documents.Open(P2Tnd, True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lstList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstList.DoubleClick
        If Me.lstList.SelectedItem Is Nothing Then
            Exit Sub
        End If
        GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder)
        Dim p2t As String = GlbData.GlbActiveProject.Path2Folder & Me.lstList.SelectedItem
        Dim Em As New ExcelManager(p2t, True)
    End Sub

End Class
