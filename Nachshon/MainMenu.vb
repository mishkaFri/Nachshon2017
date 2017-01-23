Imports System

Imports System.Runtime.InteropServices

Imports Autodesk.AutoCAD.Interop
Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Interop.Common.ACAD_COLOR
Imports Autodesk.AutoCAD.ApplicationServices

Public Class Systhema
    Implements Autodesk.AutoCAD.Runtime.IExtensionApplication
    'Private UC_List As System.Collections.Generic.Dictionary(Of String, UserControl)

    Private Sub IniAuto() Implements Autodesk.AutoCAD.Runtime.IExtensionApplication.Initialize
        Dim im As UCmain
        Try
            im = New UCmain
        Catch ex As Exception
            MsgBox(ex.Message & "why")
        End Try

        'MsgBox("UCmain constract")
        Dim ps As New Autodesk.AutoCAD.Windows.PaletteSet("Systhema")
        'MsgBox("UCmain add 2 pallete")
        ps.Size = New System.Drawing.Size(im.Size.Width + 25, im.Size.Height + 5)
        ps.Add("Systhema", im)
        'MsgBox(" add  2 pallete")
        ps.Visible = True
        'MsgBox("ShowBox")
        'Dim dm As DocumentCollection = Application.DocumentManager()
        'AddHandler dm.DocumentLockModeChanged, AddressOf GlbData.GlbSrvArx.vetoDeleteCommand
        'Dim f As New TestCom(ps)
        'ps.Add("Test", f)
        'ps.Style = Autodesk.AutoCAD.Windows.PaletteSetStyles.ShowTabForSingle
        'im.Opacity = 0.7
        'Application.ShowModelessDialog(Application.MainWindow.Handle, Me)
    End Sub

    'Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingToolStrip.Click
    '    If (Me.UC_List("UC_Setting") Is Nothing) Then
    '        Me.UC_List.Add("UC_Setting", New UC_Setting())
    '    End If
    '    Dim tmp As UC_Setting = Me.UC_List("UC_Setting")

    '    HideControlsInPanel()
    '    Me.pnlMain.Controls.Add(tmp)
    '    tmp.Visible = True
    '    tmp.Update()
    'End Sub

    'Public Sub New()
    '    Dim RetValBool As Boolean

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    RetValBool = GlbData.GlbData_Ini(Me)
    '    ' Add any initialization after the InitializeComponent() call.
    '    Me.UC_List = New System.Collections.Generic.Dictionary(Of String, UserControl)



    '    Try
    '        'GlbData.GlbAcadApp = GetObject(, "AutoCAD.Application")
    '        GlbData.GlbAcadApp = ApplicationServices.Application.AcadApplication
    '        'Me.AxAcCtrl1 .po
    '        'GlbData.GlbArxApp = GetObject(, "AutoCAD.Application")
    '        'Application = GlbData.GlbAcadApp
    '    Catch ex As System.Exception
    '        Exit Sub
    '    End Try



    'End Sub

    'Private Sub HideControlsInPanel()
    '    For Each tmp As Control In Me.pnlMain.Controls
    '        tmp.Visible = False
    '    Next
    'End Sub

    'Private Sub Systhema_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Me.UC_List.Add("UC_Setting", New UC_Setting())
    '    Me.UC_List.Add("UC_NewProject", New UC_NewProject())
    '    Me.UC_List.Add("UC_OpenProject", New UC_OpenProject())
    '    Me.UC_List.Add("UC_InsertBlock", New UC_InsertBlock())
    '    Me.UC_List.Add("UC_NewKitchen", New UC_NewKitchen())
    '    Me.UC_List.Add("UC_OpenKitchen_2", New UC_OpenKitchen_2())

    '    'Set Buttons to Start Position 
    '    SetButtonsByMode(GlbEnum.MainMenuButtonsMode.StartMode)

    'End Sub


    'Private Sub NewProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProjectToolStripMenuItem.Click
    '    If (Me.UC_List("UC_NewProject") Is Nothing) Then
    '        Me.UC_List.Add("UC_NewProject", New UC_NewProject())
    '    End If
    '    Dim tmp As UC_NewProject = Me.UC_List("UC_NewProject")

    '    HideControlsInPanel()
    '    Me.pnlMain.Controls.Add(tmp)
    '    tmp.Visible = True
    '    tmp.Update()
    '    'Set Buttons to Start Position 
    '    SetButtonsByMode(GlbEnum.MainMenuButtonsMode.ProjectOk)
    'End Sub


    'Private Sub OpenProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjectToolStripMenuItem.Click
    '    If (Me.UC_List("UC_OpenProject") Is Nothing) Then
    '        Me.UC_List.Add("UC_OpenProject", New UC_OpenProject())
    '    End If
    '    Dim tmp As UC_OpenProject = Me.UC_List("UC_OpenProject")

    '    HideControlsInPanel()
    '    tmp.LoadInEditMode()
    '    Me.pnlMain.Controls.Add(tmp)
    '    tmp.Visible = True
    '    tmp.Update()

    '    'Set Buttons to Start Position 
    '    SetButtonsByMode(GlbEnum.MainMenuButtonsMode.ProjectOk)

    'End Sub


    'Private Sub NewKitchenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewKitchenToolStripMenuItem.Click
    '    ''If (Me.UC_List("UC_InsertBlock") Is Nothing) Then
    '    ''    Me.UC_List.Add("UC_InsertBlock", New UC_NewProject())
    '    ''End If
    '    ''Dim tmp As UC_InsertBlock = Me.UC_List("UC_InsertBlock")

    '    ''HideControlsInPanel()
    '    ''Me.pnlMain.Controls.Add(tmp)
    '    ''tmp.Visible = True
    '    ''tmp.Update()

    '    If (Me.UC_List("UC_NewKitchen") Is Nothing) Then
    '        Me.UC_List.Add("UC_NewKitchen", New UC_NewKitchen())
    '    End If
    '    Dim tmp As UC_NewKitchen = Me.UC_List("UC_NewKitchen")

    '    HideControlsInPanel()
    '    Me.pnlMain.Controls.Add(tmp)
    '    tmp.Visible = True
    '    tmp.Update()


    'End Sub


    'Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
    '    If (Me.UC_List("UC_OpenKitchen") Is Nothing) Then
    '        Me.UC_List.Add("UC_OpenKitchen_2", New UC_OpenKitchen_2())
    '    End If
    '    Dim tmp As UC_OpenKitchen_2 = Me.UC_List("UC_OpenKitchen_2")

    '    HideControlsInPanel()
    '    Me.pnlMain.Controls.Add(tmp)
    '    tmp.Visible = True
    '    tmp.Update()
    'End Sub
    'Private Sub ChangeMenu(ByVal menu As Control)
    '    Me.pnlMain.Controls.Clear()
    '    If Not (menu Is Nothing) Then
    '        Me.pnlMain.Controls.Add(menu)
    '        'Me.tlbLabel.Text = menu.Tag
    '    End If
    '    'Me.SetModels()
    'End Sub
    'Public Sub SetButtonsByMode(ByVal curMode As Integer)
    '    Select Case curMode

    '        Case GlbEnum.MainMenuButtonsMode.StartMode
    '            Me.ProjectToolStripSplit.Enabled = True
    '            Me.KitchenToolStripSplit.Enabled = False
    '            Me.InfoToolStrip.Enabled = False
    '            Me.ToolStripButton2.Enabled = False
    '            Me.SaveToolStrip.Enabled = False
    '            'Me.TabMenu.Visible = False

    '        Case GlbEnum.MainMenuButtonsMode.ProjectOk
    '            Me.ProjectToolStripSplit.Enabled = True
    '            Me.KitchenToolStripSplit.Enabled = True
    '            Me.InfoToolStrip.Enabled = True
    '            Me.ToolStripButton2.Enabled = True
    '            Me.SaveToolStrip.Enabled = True
    '            'Me.TabMenu.Visible = True

    '        Case GlbEnum.MainMenuButtonsMode.KitchenOk
    '            Me.ProjectToolStripSplit.Enabled = True
    '            Me.KitchenToolStripSplit.Enabled = True
    '            Me.InfoToolStrip.Enabled = True
    '            Me.ToolStripButton2.Enabled = True
    '            Me.SaveToolStrip.Enabled = True
    '            Me.ChangeMenu(New UC_InsertBlock())
    '            'Me.TabMenu.Visible = True

    '        Case GlbEnum.MainMenuButtonsMode.ProjectClosed
    '            Me.ProjectToolStripSplit.Enabled = True
    '            Me.KitchenToolStripSplit.Enabled = False
    '            Me.InfoToolStrip.Enabled = False
    '            Me.ToolStripButton2.Enabled = False
    '            Me.SaveToolStrip.Enabled = False
    '            'Me.TabMenu.Visible = False
    '    End Select
    'End Sub
    Public Sub Terminate() Implements Autodesk.AutoCAD.Runtime.IExtensionApplication.Terminate
    End Sub





End Class
