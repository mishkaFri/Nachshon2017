Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports Autodesk.AutoCAD.Interop
Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Interop.Common.ACAD_COLOR
Imports Autodesk.AutoCAD

Module GlbData
    Public GlbSrvFunc As SrvFunc
    Public GlbActiveProject As ProjOne
    Public GlbActiveKitchen As KitchOne
    Public GlbAcadApp As AcadApplication
    Public GlbArxApp As ApplicationServices.Application
    Public GlbSrvArx As SrvObjectARX
    Public GlbActDoc As AcadDocument
    Public GlbMainUc As UCmain
    Public GlbLoadedBlockSets As List(Of BlockAttSet)
    Public GlbObjectBlockLibraries As BlockLibs
    Public GlbAttrTempObj As AttribTemplateAll
    Public GlbBlocks As BlockRefAll
    Public GlbGroups As List(Of Group)
    Public GlbKnumList As ArrayList = Nothing
    Public EmtySS As Autodesk.AutoCAD.EditorInput.SelectionSet
    Public GlbMath As MathKsoft = Nothing


    
    Public Function GlbData_Ini(ByVal MainUc As UCmain) As Boolean
        Dim retValBool As Boolean
        retValBool = True
        GlbSrvFunc = New SrvFunc
        GlbActiveProject = New ProjOne
        GlbActiveProject.Proj_Ini()
        GlbMainUc = MainUc
        GlbActiveKitchen = New KitchOne
        'GlbSrvArx = New SrvObjectARX()
        GlbActiveKitchen.Kitch_Ini()
        GlbLoadedBlockSets = New List(Of BlockAttSet)
        GlbGroups = New List(Of Group)
        GlbObjectBlockLibraries = New BlockLibs()
        GlbAttrTempObj = New AttribTemplateAll()
        GlbBlocks = New BlockRefAll
        'For Each uc As Control In GlbData.GlbMainUc.pnlMain.Controls
        '    GlbData.GlbMainUc.pnlMain.Controls.Remove(uc)
        'Next

    End Function

    Public Sub GlbData_Refresh()
        GlbActiveKitchen = New KitchOne
        GlbActiveKitchen.Kitch_Ini()
        GlbLoadedBlockSets = New List(Of BlockAttSet)
        GlbGroups = New List(Of Group)
        GlbObjectBlockLibraries = New BlockLibs()
        GlbAttrTempObj = New AttribTemplateAll()
        GlbBlocks = New BlockRefAll
    End Sub


End Module
