Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
'Imports Microsoft.Office.Interop.Excel

Public Class CrtTblManager

    Private _CurExcel As ExcelManager
    Private _path2BOM As String
    Private _knumInTlb As List(Of String)
    Private _BlocksInTlb As List(Of BlockRefOne)
    Private _RemBroList As List(Of BlockRefOne)
    Private _rowNum As Integer
    Private _LastCol As String
    Private _ListType As String
    Private _BomType As String
    Private _IsHeb As Boolean
    Private _CoinType As String
    Private _ExchangeRate As String
    Private _UCBomList As UC_BomList
    Private _Lang As String
    Public TemplateTagH(31, 1) As String

#Region "Properties"
    Public Property BlocksInTlb() As List(Of BlockRefOne)
        Get
            Return _BlocksInTlb
        End Get
        Set(ByVal value As List(Of BlockRefOne))
            _BlocksInTlb = value
        End Set
    End Property
    Public Property BomType() As String
        Get
            Return _BomType
        End Get
        Set(ByVal value As String)
            _BomType = value
        End Set
    End Property
    Public Property CoinType() As String
        Get
            Return _CoinType
        End Get
        Set(ByVal value As String)
            _CoinType = value
        End Set
    End Property
    Public Property ExchangeRate() As String
        Get
            Return _ExchangeRate
        End Get
        Set(ByVal value As String)
            _ExchangeRate = value
        End Set
    End Property
    Public Property IsHeb() As Boolean
        Get
            Return _IsHeb
        End Get
        Set(ByVal value As Boolean)
            _IsHeb = value
        End Set
    End Property
    Public Property KnumInTlb() As List(Of String)
        Get
            Return _knumInTlb
        End Get
        Set(ByVal value As List(Of String))
            _knumInTlb = value
        End Set
    End Property
    Public Property LastCol() As String
        Get
            Return _LastCol
        End Get
        Set(ByVal value As String)
            _LastCol = value
        End Set
    End Property
    Public Property ListType() As String
        Get
            Return _ListType
        End Get
        Set(ByVal value As String)
            _ListType = value
        End Set
    End Property
    Public Property Path2BOM() As String
        Get
            Return _path2BOM
        End Get
        Set(ByVal value As String)
            _path2BOM = value
        End Set
    End Property
    Public Property CurExcel() As ExcelManager
        Get
            Return _CurExcel
        End Get
        Set(ByVal value As ExcelManager)
            _CurExcel = value
        End Set
    End Property
    Public Property RemBroList() As List(Of BlockRefOne)
        Get
            Return _RemBroList
        End Get
        Set(ByVal value As List(Of BlockRefOne))
            _RemBroList = value
        End Set
    End Property
    Public Property RowNum() As Integer
        Get
            Return _rowNum
        End Get
        Set(ByVal value As Integer)
            _rowNum = value
        End Set
    End Property
    Public Property UCBomList() As UC_BomList
        Get
            Return _UCBomList
        End Get
        Set(ByVal value As UC_BomList)
            _UCBomList = value
        End Set
    End Property
    Public Property Lang() As String
        Get
            Return _Lang
        End Get
        Set(ByVal value As String)
            _Lang = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal Ltype As String, Optional ByVal BomT As String = "", _
    Optional ByVal CnType As String = "", Optional ByVal ExRate As String = "", _
    Optional ByRef UCBL As UC_BomList = Nothing, Optional ByVal Lng As String = GlbEnum.Language.Hebrew)
        Me.KnumInTlb = New List(Of String)
        Me.BlocksInTlb = New List(Of BlockRefOne)
        Me.RemBroList = New List(Of BlockRefOne)
        Me.RowNum = 3
        Me.LastCol = "AF"
        Me.ListType = Ltype
        If BomT <> "" Then
            Me.BomType = BomT
        End If
        Me.CoinType = CnType 'SZ 
        If ExRate <> "" Then
            Dim er As Double = CDbl(ExRate)
            er = Math.Round(er, 1)
            ExRate = er.ToString("N1")
        End If
        Me.ExchangeRate = ExRate 'SZ
        Me.UCBomList = UCBL 'SZ
        Me.Lang = Lng 'SZ
    End Sub

    Public Sub CreateBOM(ByVal Type As String, ByVal Name As String, ByVal IsExtended As Boolean, ByVal IsPrice As Boolean)
        Dim p2f As String = GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder)
        Dim p2t As String = GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) & "ExcelTables\BOM\Bom_" & Lang & ".xls" 'SZ
        If IsPrice = True Then
            Me.Path2BOM = p2f & GlbData.GlbActiveKitchen.PartNumb & "_OMD" & Name & "_" & Lang & ".xls"
        Else
            Me.Path2BOM = p2f & GlbData.GlbActiveKitchen.PartNumb & "_BOQ" & Name & "_" & Lang & ".xls"
        End If

        CurExcel = New ExcelManager(False)
        CurExcel.CloseWB(Me.Path2BOM)
        If System.IO.File.Exists(Me.Path2BOM) Then
            System.IO.File.Delete(Me.Path2BOM)
        End If
        Try
            System.IO.File.Copy(p2t, Me.Path2BOM)
        Catch ex As Exception
            Application.ShowAlertDialog("Cant Find Excel Prototype")
        End Try
        CurExcel = New ExcelManager(Me.Path2BOM, False)
        Me.UCBomList.ProgBar.Value = 10
        Me.SetTitle()
        Me.UCBomList.ProgBar.Value += 10
        Dim HasRAItems As Boolean = False
        Me.FillBom(IsExtended, Type, IsPrice, HasRAItems)

        ' Set print options
        Dim CurWorksheet As Microsoft.Office.Interop.Excel.Worksheet = CurExcel.ObjExcelWorkSheet
        CurWorksheet.PageSetup.PrintTitleRows = "$1:$5"
        Me.SetBomSum(IsPrice)

        ' set borders
        Dim AllRng As Object = CurExcel.SelectALL()
        AllRng.Borders(9).LineStyle = 1
        AllRng.Borders(7).LineStyle = 1
        AllRng.Borders(10).LineStyle = 1
        Dim rng As Object
        rng = CurExcel.ObjExcelWorkSheet.range("A" & Me.RowNum - 1, "D" & Me.RowNum - 1)
        rng.Borders(9).LineStyle = Microsoft.Office.Interop.Excel.Constants.xlNone
        rng.Borders(7).LineStyle = Microsoft.Office.Interop.Excel.Constants.xlNone

        ' Add Section for RA Items (Inlets)
        If HasRAItems = True And Type = "ת" Then
            AddInletSection()
        End If

        CurExcel.CloseFile()
        If Me.RowNum < 6 Then
            System.IO.File.Delete(Me.Path2BOM)
        End If
    End Sub

    ''' <summary>
    ''' Add Section to the BOM that deals with Inlet additions
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddInletSection()
        ' Get Last Row
        Dim rng As Microsoft.Office.Interop.Excel.Range = Me.CurExcel.ObjExcelWorkSheet.Range("A1")
        rng.Select()
        Dim myLastRow As Integer = CurExcel.ObjExcelWorkSheet.Cells.Find("*", rng, , , Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, _
          Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious).Row
        'Add 2 rows and Merge Cells (A,B,C)
        Dim CurRow As Integer = myLastRow + 2
        Dim rng1 As Microsoft.Office.Interop.Excel.Range = CurExcel.ObjExcelWorkSheet.range("A" & CurRow, "C" & CurRow)
        rng1.Merge()

        'Add Text according to system language
        Dim Text As String
        If Me.Lang = Language.Hebrew Then
            Text = "עלות התקנת ''שטוצר'' (כניסת צינור ''2) בודד לתעלת רצפה. המחיר הוא לכניסה אחת - כמות כללית/לתעלה ומיקום ייקבעו על-פי תכנית יועץ האינסטלציה"
        Else 'English
            Text = "Cost of installing single 2'' drainage inlet in floor trough's side. Location and number (overall and in trough) of inlets - acc. To installation consultant"
        End If
        rng1.FormulaR1C1 = Text
        rng1.Rows.WrapText = True
        If Me.Lang = Language.Hebrew Then
            rng1.Rows.RowHeight = 30
        Else
            rng1.Rows.RowHeight = 45
        End If

        CurExcel.SetBorderToRange(rng1) 'Add border around text

        'Add thick border around E cell
        CurExcel.CurCol = "E"
        CurExcel.CurRow = CurRow
        CurExcel.SetBorder(Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium)

        'Add data into E cell (Inlet Price from DB)
        Dim conn As New DBConn
        If Not conn.OpenConnectByPath(My.Settings.Path2PriceDB) Then
            Exit Sub
        End If

        Dim rs As New ADODB.Recordset
        Try
            rs.Open("Select Price from RA Where ParitName='RA-inlet'", conn.Connection, ADODB.CursorTypeEnum.adOpenStatic, _
                        ADODB.LockTypeEnum.adLockOptimistic)
            'rs = conn.Connection.Execute("Select Price from RA Where ParitName='RA-inlet'")
        Catch ex As Exception
            Exit Sub
        End Try
        Dim InletPrice As String = ""
        If Not rs.EOF Then
            Try
                InletPrice = rs.Fields("Price").Value
                If InletPrice <> "" Then
                    CurExcel.SetCurrWord(Math.Round(CDbl(InletPrice) / CDbl(Me.ExchangeRate), 2))
                End If
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

    Public Sub CreateOprList()
        Dim p2f As String = GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder)
        Dim p2t As String = GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) & "ExcelTables\List\ListOpr_" & Me.Lang & ".xls"

        Me.Path2BOM = p2f & GlbData.GlbActiveKitchen.PartNumb & "_" & Me.ListType & "_" & Lang & ".xls"
        CurExcel = New ExcelManager(False)
        CurExcel.CloseWB(Me.Path2BOM)
        If System.IO.File.Exists(Me.Path2BOM) Then
            System.IO.File.Delete(Me.Path2BOM)
        End If
        Try
            System.IO.File.Copy(p2t, Me.Path2BOM)
        Catch ex As Exception
            Application.ShowAlertDialog("Cant Find Excell Prototype")
        End Try
        System.IO.File.SetAttributes(Me.Path2BOM, IO.FileAttributes.Normal)
        CurExcel = New ExcelManager(Me.Path2BOM, False)
        Me.UCBomList.ProgBar.Value = 10
        Me.SetTitle()
        Me.FillOpr()
        CurExcel.CloseFile()
    End Sub

    Public Sub CreateList()
        'Clear TemplateTagH
        For j As Integer = 0 To 31
            TemplateTagH(j, 0) = ""
            TemplateTagH(j, 1) = ""
        Next

        If Me.BuildTemplateTagHMatrix() = False Then
            Exit Sub
        End If

        Me.RowNum = 3
        If Me.ListType = ListTypes.Operational Then
            Me.CreateOprList()
            Exit Sub
        End If
        Me.BlocksInTlb = New List(Of BlockRefOne)
        Me.KnumInTlb = New List(Of String)
        Dim p2f As String = GlbData.GlbSrvFunc.AddSlash2Path(GlbData.GlbActiveProject.Path2Folder)
        Dim p2t As String = GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) & "ExcelTables\List\List_" & Me.Lang & ".xls"

        Me.Path2BOM = p2f & GlbData.GlbActiveKitchen.PartNumb & "_" & Me.ListType & "_" & Me.Lang & ".xls"
        CurExcel = New ExcelManager(False)
        CurExcel.CloseWB(Me.Path2BOM)
        If System.IO.File.Exists(Me.Path2BOM) Then
            System.IO.File.Delete(Me.Path2BOM)
        End If
        Try
            System.IO.File.Copy(p2t, Me.Path2BOM)
        Catch ex As Exception
            Application.ShowAlertDialog("Cant Find Excell Prototype")
        End Try
        System.IO.File.SetAttributes(Me.Path2BOM, IO.FileAttributes.Normal)
        CurExcel = New ExcelManager(Me.Path2BOM, False)
        Me.UCBomList.ProgBar.Value = 5
        Me.SetTitle()
        Me.UCBomList.ProgBar.Value = 10
        'GlbData.GlbBlocks.SortByKNum()
        Me.FillNormalBro()
        Me.FilllengthBro()
        If Me.RowNum < 7 Then
            CurExcel.ObjExcelWorkBook.Close()
            Application.ShowAlertDialog("No Blocks or Numbering in Drawing")
            Exit Sub
        End If
        Me.SetListTypeView()
        Me.FindEmptySec()
        Me.AddSpecialAtts()
        Me.SetListSums()
        Me.UCBomList.ProgBar.Value = 100
        Me.CurExcel.CloseFile()
        'Me.CurExcel.SetAllBorders() 'SZ
    End Sub

    Public Sub SetTitle()
        Me.CurExcel.CurCol = "A"
        Me.CurExcel.CurRow = 1
        Dim Title As String = GetTitle()
        Select Case ListType.Trim(Chr(32))
            Case ListTypes.Operational
                ' Set Project name 'SZ
                If Me.Lang = GlbEnum.Language.Hebrew Then
                    Me.CurExcel.SetCurrWord("שם הפרוייקט :" & GlbData.GlbActiveProject.NameHeb)
                Else
                    Me.CurExcel.SetCurrWord("Project Name :" & GlbData.GlbActiveProject.Name)
                End If
                ' Set Kitchen name
                Me.CurExcel.CurCol = "A"
                Me.CurExcel.CurRow = 2
                If Me.Lang = GlbEnum.Language.Hebrew Then
                    Me.CurExcel.SetCurrWord("שם המטבח : " & GlbData.GlbActiveKitchen.NameHeb)
                Else
                    Me.CurExcel.SetCurrWord("Kithcen Name : " & GlbData.GlbActiveKitchen.Name)
                End If
                ' Set Title
                Me.CurExcel.CurCol = "A"
                Me.CurExcel.CurRow = 3
                Me.CurExcel.SetCurrWord(Title)
                ' Set date
                Me.CurExcel.CurCol = "B"
                Me.CurExcel.CurRow = 1
                Me.CurExcel.SetCurrWord(Now.Date)
                ' Set Kitchen File name
                Me.CurExcel.CurCol = "B"
                Me.CurExcel.CurRow = 2
                Me.CurExcel.SetCurrWord(GlbData.GlbActiveProject.PartNumb & GlbData.GlbActiveKitchen.PartNumb)
                ' Set next line
                Me.CurExcel.CurCol = "A"
                Me.RowNum = 6
                Exit Sub
            Case ListTypes.BOM
                ' Set Project name 'SZ
                If Me.Lang = GlbEnum.Language.Hebrew Then
                    Me.CurExcel.SetCurrWord(GlbData.GlbActiveProject.NameHeb)
                Else
                    Me.CurExcel.SetCurrWord(GlbData.GlbActiveProject.Name)
                End If
                ' Set date
                Me.CurExcel.CurCol = "E"
                Me.CurExcel.CurRow = 2
                Me.CurExcel.SetCurrWord(Now.Date)
                ' Set Coin type
                Me.CurExcel.CurCol = "A"
                Me.CurExcel.CurRow = 2
                If Me.Lang = GlbEnum.Language.Hebrew Then
                    Me.CurExcel.SetCurrWord("מטבע: " & Me.CoinType)
                Else
                    Me.CurExcel.SetCurrWord("Currency: " & Me.CoinType)
                End If
                ' Set Exchange rate 
                Me.CurExcel.CurCol = "A"
                Me.CurExcel.CurRow = 3
                If Me.Lang = GlbEnum.Language.Hebrew Then
                    Me.CurExcel.SetCurrWord("שער: " & Me.ExchangeRate)
                Else
                    Me.CurExcel.SetCurrWord("Ex. rate: " & Me.ExchangeRate)
                End If
                'Set Bom type name
                Me.CurExcel.CurCol = "B"
                Me.CurExcel.CurRow = 2
                If Me.Lang = Language.Hebrew Then
                    Me.CurExcel.SetCurrWord("כתב כמויות : " & Me.BomType)
                Else
                    'Get The name from the ToolTip
                    Dim BomTypeName As String = GetBomEngTitle()
                    If BomTypeName <> "" Then
                        Me.CurExcel.SetCurrWord("Bill of Quantities : " & BomTypeName)
                    End If
                End If

                ' Set Kitchen name
                Me.CurExcel.CurCol = "B"
                Me.CurExcel.CurRow = 3
                If Me.Lang = GlbEnum.Language.Hebrew Then
                    Me.CurExcel.SetCurrWord(GlbData.GlbActiveKitchen.NameHeb)
                Else
                    Me.CurExcel.SetCurrWord(GlbData.GlbActiveKitchen.Name)
                End If
                ' Set Kitchen File name
                Me.CurExcel.CurCol = "E"
                Me.CurExcel.CurRow = 3
                Me.CurExcel.SetCurrWord(GlbData.GlbActiveProject.PartNumb & GlbData.GlbActiveKitchen.PartNumb)
                ' Set next line
                Me.CurExcel.CurCol = "A"
                Me.RowNum = 6
                Exit Sub
        End Select
        ' Set List Title 'SZ
        ' Set date
        Me.CurExcel.SetCurrWord(Now.Date)
        ' Set Kitchen File name
        Me.CurExcel.CurCol = "A"
        Me.CurExcel.CurRow = 2
        Me.CurExcel.SetCurrWord(GlbData.GlbActiveProject.PartNumb & GlbData.GlbActiveKitchen.PartNumb)
        ' Set Project name
        Me.CurExcel.CurCol = "E"
        Me.CurExcel.CurRow = 1
        If Me.Lang = GlbEnum.Language.Hebrew Then
            Me.CurExcel.SetCurrWord(GlbData.GlbActiveProject.NameHeb)
        Else
            Me.CurExcel.SetCurrWord(GlbData.GlbActiveProject.Name)
        End If

        ' Set Kitchen name
        Me.CurExcel.CurCol = "E"
        Me.CurExcel.CurRow = 2
        If Me.Lang = GlbEnum.Language.Hebrew Then
            Me.CurExcel.SetCurrWord(GlbData.GlbActiveKitchen.NameHeb)
        Else
            Me.CurExcel.SetCurrWord(GlbData.GlbActiveKitchen.Name)
        End If
        ' Set List Name
        Me.CurExcel.CurCol = "E"
        Me.CurExcel.CurRow = 3
        Me.CurExcel.SetCurrWord(Title)
        ' Set First Data cell
        Me.CurExcel.CurCol = "A"
        Me.RowNum = 7
    End Sub

    ''' <summary>
    ''' Get English title for BOM (BOQ)
    ''' </summary>
    ''' <returns>English title (if found) or nothing ("") if not found.</returns>
    ''' <remarks></remarks>
    Public Function GetBomEngTitle() As String
        Dim BomTitle As String = ""
        Select Case Me.BomType
            Case "ציוד קבוע במבנה"
                BomTitle = "Embedded-in-Place"
            Case "ציוד לרכישה"
                BomTitle = "Buy-Out Equipment"
            Case "ציוד הקפאה"
                BomTitle = "Refrigerated Equipment"
            Case "ציוד לייצור מיוחד"
                BomTitle = "Custom Mfg Equipment"
            Case "לא במכרז"
                BomTitle = "Not in Tender"
            Case "אשפה"
                BomTitle = "Garbage Disposal Equipment"
            Case "ציוד בישול"
                BomTitle = "Cooking Equipment"
            Case "ציוד הדחה"
                BomTitle = "Dishwashing Equipment"
            Case "כונניות"
                BomTitle = "Storage Equipment"
            Case "ברזים"
                BomTitle = "Faucets"
            Case "חדרי קירור"
                BomTitle = "Walk-in Cold Room"
            Case "דלתות פנדל"
                BomTitle = "HDPE Doors"
            Case "תקרות מתנדפות"
                BomTitle = "Ventilation Hoods"
            Case "ציוד אפיה"
                BomTitle = "Baking Equipment"
        End Select

        Return BomTitle
    End Function

    ''' <summary>
    ''' Get title for List according to the chosen type
    ''' </summary>
    ''' <returns>List Name</returns>
    ''' <remarks></remarks>
    Public Function GetTitle() As String
        If Me.Lang = GlbEnum.Language.Hebrew Then
            Select Case ListType.Trim(Chr(32))
                Case ListTypes.Wide
                    Return "רשימת ציוד רחבה"
                Case ListTypes.Narrow
                    Return "רשימת ציוד צרה"
                Case ListTypes.Fixed
                    Return "רשימת ציוד קבוע במבנה"
                Case ListTypes.Operational
                    Return "רשימת ציוד תפעולי"
            End Select
        Else ' If the Language is English
            Select Case ListType.Trim(Chr(32))
                Case ListTypes.Wide
                    Return "Wide Equipment List"
                Case ListTypes.Narrow
                    Return "Narrow Equipment List"
                Case ListTypes.Fixed
                    Return "Embedded-in-Place Equipment"
                Case ListTypes.Operational
                    Return "Operational Equipment List"
            End Select
        End If
        Return Nothing
    End Function

    Public Sub FillBom(ByVal isext As Boolean, ByVal type As String, _
                       ByVal IsPrice As Boolean, ByRef HasRAItems As Boolean)
        Dim grpnum As Integer
        Dim Prog As Double
        Dim grpName As String = ""
        Dim ato, AMic As AttribTemplateOne
        Dim IsPar As Boolean
        CurExcel.CurRow = Me.RowNum
        Me.RemBroList = GlbData.GlbSrvFunc.FillListFromDadsFuckingCollection _
                                                (GlbData.GlbBlocks.BlockList)

        Prog = 80 / GlbData.GlbBlocks.BlockList.Count ' For Progress Bar  'SZ
        For Each bro As BlockRefOne In GlbData.GlbBlocks.BlockList
            Me.UCBomList.ProgBar.Value += Math.Floor(Prog)
            ato = bro.GetBlkAttrByTag("KNUM")
            If ato Is Nothing OrElse ato.AttValue = "" Then
                Me.RemBroList.Remove(bro)
                Continue For
            End If
            If bro.BlockName.StartsWith("RA") And type <> "א" Then
                HasRAItems = True
            End If
            If Me.KnumInTlb.Contains(ato.AttValue) Then
                Me.RemBroList.Remove(bro)
                Continue For
            End If
            If Not type = "All" Then
                If isext Then
                    AMic = bro.GetBlkAttrByTag("KMIC_W")
                Else
                    AMic = bro.GetBlkAttrByTag("KMIC_R")
                End If
                If AMic.AttValue <> type Then
                    Continue For
                End If
            Else
                AMic = bro.GetBlkAttrByTag("KMIC_R")
                If AMic.AttValue = "א" Then
                    Continue For
                End If
            End If
            Me.FillBomRow(bro, IsPrice)
            CurExcel.SetRowBorder()
            bro.RowInList = Me.RowNum
            Me.RowNum += 1
            Me.KnumInTlb.Add(ato.AttValue)
            Me.BlocksInTlb.Add(bro)

            Me.RemBroList.Remove(bro)
            If bro.IsGrpMember(grpnum, grpName, IsPar) AndAlso IsPar Then
                Me.FillListSonRows(grpnum, IsPrice)
            End If

        Next
        If Me.RowNum < 6 Then
            Exit Sub
        End If
        Me.UCBomList.ProgBar.Value = 100
        Me.KnumInTlb.Clear()
    End Sub

    Public Sub FillNormalBro()
        Dim grpnum, Prog As Integer
        Dim grpName As String = ""
        Dim ato As AttribTemplateOne
        Dim IsPar, IsFix As Boolean
        CurExcel.CurRow = Me.RowNum
        Me.RemBroList = GlbData.GlbSrvFunc.FillListFromDadsFuckingCollection _
                                                (GlbData.GlbBlocks.BlockList)
        Prog = 70 / GlbData.GlbBlocks.BlockList.Count
        For Each bro As BlockRefOne In GlbData.GlbBlocks.BlockList
            If Me.UCBomList.ProgBar.Value + Math.Floor(Prog) > 100 Then
                Me.UCBomList.ProgBar.Value = 100
            Else
                Me.UCBomList.ProgBar.Value += Math.Floor(Prog)
            End If

            IsFix = Me.IsInFixed(bro)
            If IsFix AndAlso Not Me.ListType = ListTypes.Fixed Or _
            Not IsFix AndAlso Me.ListType = ListTypes.Fixed Then
                Continue For
            End If

            ato = bro.GetBlkAttrByTag("KNUM")

            If ato Is Nothing OrElse ato.AttValue = "" Then
                Me.RemBroList.Remove(bro)
                Continue For
            End If

            'If Not Me.DoesContainSupplies(bro) Then
            'Continue For
            'End If

            If Not IsNumeric(ato.AttValue.Chars(0)) Then
                Continue For
            End If

            If Me.KnumInTlb.Contains(ato.AttValue) Then
                Me.RemBroList.Remove(bro)
                Continue For
            End If

            Me.FillRow(bro)
            'Dim rng As Microsoft.Office.Interop.Excel.Range = CurExcel.ObjExcelWorkSheet.rows(Me.RowNum)
            'rng.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            CurExcel.SetRowBorder()
            bro.RowInList = Me.RowNum
            Me.RowNum += 1
            Me.KnumInTlb.Add(ato.AttValue)
            Me.BlocksInTlb.Add(bro)
            Me.RemBroList.Remove(bro)
            If bro.IsGrpMember(grpnum, grpName, IsPar) AndAlso IsPar Then
                Me.FillListSonRows(grpnum)
            End If
        Next
        If Me.RowNum < 6 Then
            Exit Sub
        End If
    End Sub

    Public Function IsInFixed(ByVal bro As BlockRefOne) As Boolean
        Dim ato As AttribTemplateOne
        ato = bro.GetBlkAttrByTag("KMIC_R")
        If ato IsNot Nothing AndAlso ato.AttValue = "ת" Then
            Return True
        End If
        Return False
    End Function

    Public Function FillOpr() As Boolean
        Me.CurExcel.CurRow = Me.RowNum
        Dim ato As AttribTemplateOne
        Dim Ata As AttribTemplateAll
        Dim RemBroList As New List(Of BlockRefOne)
        Dim kkoSum, Prog As Double
        Dim Description As String
        'RemBroList = GlbData.GlbSrvFunc.FillListFromDadsFuckingCollection(GlbData.GlbBlocks.BlockList)
        ' For Progress Bar  'SZ
        Prog = 90 / GlbData.GlbBlocks.BlockList.Count
        For Each bro As BlockRefOne In GlbData.GlbBlocks.BlockList
            If Me.UCBomList.ProgBar.Value + Math.Floor(Prog) < 100 Then
                Me.UCBomList.ProgBar.Value += Math.Floor(Prog) 'SZ - Progress Bar
            Else
                Me.UCBomList.ProgBar.Value = 100
            End If

            If RemBroList.Contains(bro) Then
                Continue For
            End If
            RemBroList.Add(bro)
            Ata = bro.GetBlkAttsByPartTag("KKO")
            If Ata.NAttrib < 1 Then
                Continue For
            End If
            If Me.Lang = GlbEnum.Language.Hebrew Then
                ato = Ata.AttrList.Item(1)
                Description = ato.Description
            Else
                ato = Ata.AttrList.Item(1)
                Description = GetEngAttrNameFromDB(ato.Tag)
            End If

            If ato Is Nothing OrElse ato.AttValue = "" OrElse Not IsNumeric(ato.AttValue) Then
                Continue For
            End If

            If Not Me.DoesContainSupplies(bro) Then
                Continue For
            End If

            kkoSum = Me.CalcKKOSum(ato, RemBroList) + CDbl(ato.AttValue)
            CurExcel.CurRow = Me.RowNum
            CurExcel.SetCurrWord(Description)
            CurExcel.SetBorder()
            CurExcel.SetNextWord(kkoSum)
            CurExcel.SetBorder()
            CurExcel.SetCurrReturn()
            Me.RowNum += 1
        Next
        Return False
    End Function

    Public Function GetEngAttrNameFromDB(ByVal Tag As String) As String
        Dim Desc As String
        Dim conn As New DBConn
        If Not conn.OpenConnectByPath(My.Settings.Path2DB) Then
            Return (Nothing)
        End If
        Dim rs As New ADODB.Recordset
        Try
            rs.Open("Select DescriptionE from Attributes where Tag = '" & Tag & "'", conn.Connection, ADODB.CursorTypeEnum.adOpenStatic, _
                        ADODB.LockTypeEnum.adLockOptimistic)
            'rs = conn.Connection.Execute("Select DescriptionE from Attributes where Tag = '" & Tag & "'")
        Catch ex As Exception
            Return "Error finding " & Tag & " in DB"
        End Try

        If rs Is Nothing Then
            Return ("")
        End If
        Desc = rs.Fields.Item(0).Value
        rs.Close()
        conn.CloseConnection()
        Return Desc
    End Function

    Public Function CalcKKOSum(ByVal KKato As AttribTemplateOne, ByRef RemBroList As List(Of BlockRefOne)) As Double
        Dim ato As AttribTemplateOne
        Dim val As Double = 0
        Dim sum As Double = 0
        For Each bro As BlockRefOne In GlbData.GlbBlocks.BlockList
            If RemBroList.Contains(bro) Then
                Continue For
            End If
            ato = bro.GetBlkAttrByTag(KKato.Tag)
            If ato Is Nothing OrElse ato.AttValue = "" OrElse Not IsNumeric(ato.AttValue) Then
                Continue For
            End If
            RemBroList.Add(bro)
            val = CDbl(ato.AttValue)
            sum += val

        Next

        Return sum
    End Function

    Public Sub FilllengthBro()
        Dim grpnum, Prog As Integer
        Dim grpName As String = ""
        Dim ato As AttribTemplateOne
        Dim IsPar, IsFix As Boolean
        Dim sum As Double
        If Me.RemBroList.Count > 0 Then
            Prog = 20 / Me.RemBroList.Count
        End If
        For Each bro As BlockRefOne In Me.RemBroList
            ' Update Progress Bar ' SZ
            If Me.UCBomList.ProgBar.Value + Math.Floor(Prog) > 100 Then
                Me.UCBomList.ProgBar.Value = 100
            Else
                Me.UCBomList.ProgBar.Value += Math.Floor(Prog)
            End If

            IsFix = Me.IsInFixed(bro)
            If IsFix AndAlso Not Me.ListType = ListTypes.Fixed Or _
            Not IsFix AndAlso Me.ListType = ListTypes.Fixed Then
                Continue For
            End If
            ato = bro.GetBlkAttrByTag("KNUM")
            If ato Is Nothing OrElse ato.AttValue = "" _
                 OrElse IsNumeric(ato.AttValue) Then
                Continue For
            End If

            If Not Me.DoesContainSupplies(bro) Then
                'Continue For
            End If

            If Me.KnumInTlb.Contains(ato.AttValue) Then
                Continue For
            End If

            Me.FillRow(bro)
            Dim rng As Microsoft.Office.Interop.Excel.Range = CurExcel.ObjExcelWorkSheet.rows(Me.RowNum)
            'rng.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot
            CurExcel.SetRowBorder(-4118) 'SZ  ' -4118 is dotted line pattern
            bro.RowInList = Me.RowNum
            Me.RowNum += 1
            sum = Me.GetLenSum(ato.AttValue)
            Dim Prow As String = CInt(CurExcel.CurRow) - 1
            rng = CurExcel.ObjExcelWorkSheet.range("C" & Prow, "D" & Prow)
            CurExcel.ObjExcelApp.displayalerts = False
            rng.Merge()
            rng.FormulaR1C1 = sum
            Me.KnumInTlb.Add(ato.AttValue)
            Me.BlocksInTlb.Add(bro)
            If bro.IsGrpMember(grpnum, grpName, IsPar) AndAlso IsPar Then
                Me.FillListSonRows(grpnum)
            End If
        Next
    End Sub

    Public Function GetLenSum(ByVal knum As String) As Double
        Dim ato As AttribTemplateOne
        Dim sum As Double = 0

        For Each bro As BlockRefOne In Me.RemBroList
            ato = bro.GetBlkAttrByTag("KNUM")

            If ato Is Nothing OrElse ato.AttValue <> knum Then
                Continue For
            End If
            ato = bro.GetBlkAttrByTag("KMID_L")
            If ato Is Nothing OrElse Not IsNumeric(ato.AttValue) Then
                Continue For
            End If
            sum += CDbl(ato.AttValue)
        Next
        Return sum
    End Function

    Public Sub SetListTypeView()
        Dim colName As String = ""
        Select Case Me.ListType.Trim(Chr(32))
            Case ListTypes.Wide
                Exit Sub
            Case ListTypes.Narrow
                colName = "InNarrow"
            Case ListTypes.Fixed
                colName = "InFixed"
        End Select

        If colName = "" Then
            Exit Sub
        End If

        CurExcel.CurCol = "A"
        Dim Sr(1) As String
        Dim IsIn As Boolean
        Dim removeSec As Boolean = False
        Dim conn As New DBConn
        If Not conn.OpenConnectByPath(My.Settings.Path2DB) Then
            Exit Sub
        End If

        Dim rs As New ADODB.Recordset

        While CurExcel.CurCol <> "AG"
          
            Try
                rs.Open("Select " & colName & " from TemplateTagH where TmpltClmn = '" & CurExcel.CurCol.Trim(" ") & "'", conn.Connection, ADODB.CursorTypeEnum.adOpenStatic, _
                        ADODB.LockTypeEnum.adLockOptimistic)
                If rs.EOF Then
                    Exit While
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            IsIn = rs.Fields.Item(0).Value

            rs.Close()


            If Not IsIn Then
                'Dim ran As Object = CurExcel.ObjExcelWorkSheet.range(Sr(0) & "1:" & Sr(1) & "1")
                CurExcel.ObjExcelWorkSheet.columns(CurExcel.CurCol & ":" & CurExcel.CurCol).entirecolumn.hidden = True
            End If

            CurExcel.ColNext()

        End While

    End Sub

    Public Sub FindEmptySec()
        CurExcel.CurCol = "H"
        Dim Sr(1) As String
        Dim val As String
        Dim removeSec As Boolean = False
        Dim conn As New DBConn
        If Not conn.OpenConnectByPath(My.Settings.Path2DB) Then
            Exit Sub
        End If

        Dim rs As New ADODB.Recordset
        Dim GoOn As Boolean = True
        While GoOn
            If CurExcel.CurCol = "AG" Then
                Exit While
            End If
            If removeSec Then
                'Dim ran As Object = CurExcel.ObjExcelWorkSheet.range(Sr(0) & "1:" & Sr(1) & "1")

                CurExcel.ObjExcelWorkSheet.columns(Sr(0) & ":" & Sr(1)).entirecolumn.hidden = True

            End If
            Try
                rs.Open("Select GrpRange from TemplateTagH where TmpltClmn = '" & CurExcel.CurCol.Trim(" ") & "'", conn.Connection, ADODB.CursorTypeEnum.adOpenStatic, _
                        ADODB.LockTypeEnum.adLockOptimistic)
                'rs = conn.Connection.Execute("Select GrpRange from TemplateTagH where TmpltClmn = '" & CurExcel.CurCol.Trim(" ") & "'")
                If rs.EOF Then
                    Exit While
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim range As String = rs.Fields.Item(0).Value
            If range Is Nothing Then
                Exit Sub
            End If

            rs.Close()

            Sr = range.Split("-")
            For i As Integer = 0 To Sr.Length - 1
                Sr(i) = Sr(i).Trim(Chr(32))
            Next
            If Sr.Length < 1 Or Sr.Length > 2 Then
                Exit Sub
            End If
            CurExcel.CurRow = 3
            removeSec = False
            Do
                val = CurExcel.GetWord(CurExcel.CurCol, CurExcel.CurRow)
                If val IsNot Nothing AndAlso val <> "" Then
                    CurExcel.CurCol = Sr(1)
                    CurExcel.ColNext()

                    Exit Do
                End If
                CurExcel.RowNext()
                If CurExcel.CurRow = (Me.RowNum) Then

                    CurExcel.CurRow = 3
                    If Sr.Length < 2 OrElse CurExcel.CurCol = Sr(1) Then
                        removeSec = True
                        CurExcel.ColNext()
                        'CurExcel.ColNext()
                        Exit Do

                    End If
                    CurExcel.ColNext()
                End If
            Loop
        End While


    End Sub

    ''' <summary>
    '''In Use, must be replaced by "GetAttByColumnFromList" to make list faster
    ''' </summary>
    ''' <param name="col"></param>
    ''' <param name="tag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAttByColumn(ByVal col As String, ByRef tag As String) As Boolean
        Dim conn As New DBConn
        If Not conn.OpenConnectByPath(My.Settings.Path2DB) Then
            Return False
        End If

        Dim rs As New ADODB.Recordset
        Try
            rs.Open("Select TagName from TemplateTagH where TmpltClmn = '" & CurExcel.CurCol & "'", conn.Connection, ADODB.CursorTypeEnum.adOpenStatic, _
                        ADODB.LockTypeEnum.adLockOptimistic)
            'rs = conn.Connection.Execute("Select TagName from TemplateTagH where TmpltClmn = '" & CurExcel.CurCol & "'")
        Catch ex As Exception
            Return False
        End Try

        If rs.EOF Then
            Return False
        End If

        Try
            tag = rs.Fields(0).Value
            If tag = "KNAM_H" And Me.Lang = Language.English Then
                tag = "KNAM_E"
            End If
            If tag = "KNOT_H" And Me.Lang = Language.English Then
                tag = "KNOT_E"
            End If
        Catch ex As Exception
            Return False
        End Try

        If tag Is Nothing OrElse tag = "" Then
            Return False
        End If

        conn.CloseConnection()
        Return True

    End Function

    Public Function GetAttByColumnFromList(ByVal col As String, ByRef tag As String) As Boolean
        tag = ""
        Dim Len As Integer = (Me.TemplateTagH.Length / 2) - 1
        For i As Integer = 0 To Len
            If TemplateTagH(i, 0) = col Then
                tag = TemplateTagH(i, 1)
                Exit For
            End If
        Next
        Try
            If tag = "KNAM_H" And Me.Lang = Language.English Then
                tag = "KNAM_E"
            End If
            If tag = "KNOT_H" And Me.Lang = Language.English Then
                tag = "KNOT_E"
            End If
        Catch ex As Exception
            Return False
        End Try

        If tag Is Nothing OrElse tag = "" Then
            Return False
        End If

        Return True

    End Function

    Public Function BuildTemplateTagHMatrix() As Boolean
        Dim conn As New DBConn
        If Not conn.OpenConnectByPath(My.Settings.Path2DB) Then
            Return False
        End If

        Dim rs As New ADODB.Recordset
        Try
            rs.Open("Select TmpltClmn,TagName from TemplateTagH", conn.Connection, ADODB.CursorTypeEnum.adOpenStatic, _
                        ADODB.LockTypeEnum.adLockOptimistic)
            'rs = conn.Connection.Execute("Select TmpltClmn,TagName from TemplateTagH")
        Catch ex As Exception
            Return False
        End Try

        If rs.EOF Then
            Return False
        End If
        Dim i As Integer = 0
        Try
            While Not rs.EOF
                Me.TemplateTagH(i, 0) = rs.Fields("TmpltClmn").Value
                Me.TemplateTagH(i, 1) = rs.Fields("TagName").Value
                i += 1
                rs.MoveNext()
            End While
        Catch ex As Exception
            Return False
        End Try

        conn.CloseConnection()
        Return True
    End Function

    Public Sub AddSpecialAtts()
        Dim grpnum As Integer
        Dim grpName As String = ""
        Dim IsPar As Boolean
        Dim grp As Group
        Dim CreatCol As Boolean
        Dim atoList As New List(Of AttribTemplateOne)
        atoList = GlbData.GlbAttrTempObj.GetSpecial()
        If Not atoList.Count > 0 Then
            Exit Sub
        End If
        Dim Bato, Kato As AttribTemplateOne
        'Dim brorow As Integer
        For Each ato As AttribTemplateOne In atoList
            CreatCol = True
            For Each bro As BlockRefOne In Me.BlocksInTlb
                Bato = bro.GetBlkAttrByTag(ato.Tag)
                If Bato Is Nothing OrElse Bato.AttValue = "" Then
                    Continue For
                End If
                If CreatCol Then
                    Me.CreateColumn(ato.Description)
                    CreatCol = False
                End If
                'Kato = bro.GetBlkAttrByTag("KNUM")
                'If Kato Is Nothing Then
                '    Continue For
                'End If

                'If Kato.AttValue <> "" Then    'Is not child in group
                '    brorow = CurExcel.GerRowNumByColVal("A", Kato.AttValue)
                If bro.RowInList > 0 And bro.RowInList < Me.RowNum Then
                    CurExcel.CurRow = bro.RowInList
                    CurExcel.CurCol = Me.LastCol
                    CurExcel.SetCurrWord(Bato.AttValue)
                    CurExcel.SetBorder()
                End If
                'ElseIf bro.IsGrpMember(grpnum, grpName, IsPar) AndAlso Not IsPar Then
                'grp = GlbData.GlbSrvFunc.GetorSetGroupByNum(grpnum, False)
                'If grp Is Nothing Then
                '    Continue For
                'End If

                'End If
            Next
        Next
    End Sub

    Public Sub CreateColumn(ByVal name As String)
        CurExcel.CurCol = Me.LastCol
        CurExcel.ColNext()
        Me.LastCol = CurExcel.CurCol
        CurExcel.CurRow = 6
        CurExcel.SetBorder()
        CurExcel.CurRow = 5
        CurExcel.SetCurrWord(name)
        CurExcel.SetBorder()
    End Sub

    Public Sub FillSonRows(ByVal grpNum As Integer)
        Dim ea() As String
        Dim grp As Group = GlbData.GlbSrvFunc.GetorSetGroupByNum(grpNum, False)
        If grp Is Nothing Then
            Exit Sub
        End If
        For Each bro As BlockRefOne In grp.BlockList
            ea = Me.GetBomInfo(bro)
            ea(0) = "(--)"
            Me.FillRow(ea)
            Me.BlocksInTlb.Add(bro)
            Me.RowNum += 1
        Next
    End Sub

    Public Sub FillListSonRows(ByVal grpNum As Integer, Optional ByVal IsPrice As Boolean = False)
        Dim grp As Group = GlbData.GlbSrvFunc.GetorSetGroupByNum(grpNum, False)
        Dim UsedB As New List(Of String)
        Dim c As Integer = 0
        If grp Is Nothing Then
            Exit Sub
        End If
        For Each bro As BlockRefOne In grp.BlockList
            If Not bro.BlockName.EndsWith("A") AndAlso Not bro.BlockName.EndsWith("E") Then
                Continue For
            End If
            If UsedB.Contains(bro.BlockName) Then
                Continue For
            End If

            ' Don't include sons that doesent have any supplies.
            'If Not Me.DoesContainSupplies(bro) Then
            '    Continue For
            'End If

            If grp.BlockQntColl.Count < 1 Then
                Continue For
            End If
            c = grp.BlockQntColl.Item(bro.BlockName)
            If c < 1 Then
                Continue For
            End If
            UsedB.Add(bro.BlockName)
            CurExcel.SetCurrWord("(--)")
            CurExcel.ColNext()
            'CurExcel.SetCurrWord(c)
            'CurExcel.ColNext()
            Dim rng As Microsoft.Office.Interop.Excel.Range = CurExcel.ObjExcelWorkSheet.rows(CInt(CurExcel.CurRow))
            'rng.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot
            CurExcel.SetRowBorder(-4118) 'SZ
            If Me.ListType = "BOM" Then
                Me.FillBomRow(bro, IsPrice)
                CurExcel.SetRowBorder(-4118) 'SZ
                rng = CurExcel.ObjExcelWorkSheet.range("D" & Me.RowNum)
                rng.FormulaR1C1 = c
            Else
                Me.FillRow(bro)
                rng = CurExcel.ObjExcelWorkSheet.range("c" & Me.RowNum)
                rng.FormulaR1C1 = c
            End If
            rng = CurExcel.ObjExcelWorkSheet.rows(Me.RowNum)
            'rng.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot
            CurExcel.SetRowBorder() 'SZ
            bro.RowInList = Me.RowNum
            rng = CurExcel.ObjExcelWorkSheet.range("A" & Me.RowNum - 1)
            Try
                If Not rng.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter Then
                    rng.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlTop
                End If
            Catch ex As Exception
            End Try

            rng = CurExcel.ObjExcelWorkSheet.range("A" & Me.RowNum - 1, "A" & Me.RowNum)
            CurExcel.ObjExcelApp.displayalerts = False
            rng.Merge()
            Me.RowNum += 1
            Me.BlocksInTlb.Add(bro)
        Next
    End Sub

    Public Sub FillRow(ByVal Ea() As String)
        CurExcel.SetCurrWord(Ea(0))
        For i As Integer = 1 To Ea.Length - 1
            CurExcel.SetNextWord(Ea(i))
        Next
        CurExcel.SetCurrReturn()
    End Sub

    Public Sub FillBomRow(ByVal bro As BlockRefOne, ByVal IsPrice As Boolean)
        Dim BroPrice As Double
        Dim sum As Double = 0 'Gal

        Dim atts() As String = Me.GetBomInfo(bro)
        If atts(0) <> "" Then
            CurExcel.SetCurrWord(atts(0))
            CurExcel.SetNextWord(atts(1))
        Else
            CurExcel.SetCurrWord(atts(1))
        End If
        'If atts(0) <> "" AndAlso Not IsNumeric(atts(0).Chars(0)) Then
        '    isMeterLength = True
        '    If Me.Lang = GlbEnum.Language.Hebrew Then
        '        CurExcel.SetNextWord(".î.à")
        '    Else
        '        CurExcel.SetNextWord("M.L.")
        '    End If
        '    sum = Me.GetLenSum(atts(0))
        '    CurExcel.SetNextWord((sum / 100).ToString())
        'Else
        '    If Me.Lang = GlbEnum.Language.Hebrew Then
        '        CurExcel.SetNextWord("'éç")
        '    Else
        '        CurExcel.SetNextWord("Units")
        '    End If

        If Me.Lang = GlbEnum.Language.Hebrew Then
            Select Case (atts(8))
                Case GlbEnum.PriceUnitTypes.Meter_cm
                    CurExcel.SetNextWord("יח'")
                    CurExcel.SetNextWord(atts(2)) ' Set quantity
                Case GlbEnum.PriceUnitTypes.Unit
                    CurExcel.SetNextWord("יח'")
                    CurExcel.SetNextWord(atts(2)) ' Set quantity
                Case GlbEnum.PriceUnitTypes.MeterCon_cm
                    CurExcel.SetNextWord("מ.א.")
                    sum = Me.GetLenSum(atts(0))
                    CurExcel.SetNextWord((sum / 100).ToString())
                Case GlbEnum.PriceUnitTypes.Area
                    CurExcel.SetNextWord("קומ")
                    CurExcel.SetNextWord(atts(2)) ' Set quantity
            End Select
        Else
            Select Case (atts(8))
                Case GlbEnum.PriceUnitTypes.Meter_cm
                    CurExcel.SetNextWord("Units")
                    CurExcel.SetNextWord(atts(2)) ' Set quantity
                Case GlbEnum.PriceUnitTypes.Unit
                    CurExcel.SetNextWord("Units")
                    CurExcel.SetNextWord(atts(2)) ' Set quantity
                Case GlbEnum.PriceUnitTypes.MeterCon_cm
                    CurExcel.SetNextWord("Mtr.")
                    sum = Me.GetLenSum(atts(0))
                    CurExcel.SetNextWord((sum / 100).ToString())
                Case GlbEnum.PriceUnitTypes.Area
                    CurExcel.SetNextWord("Com")
                    CurExcel.SetNextWord(atts(2)) ' Set quantity
            End Select
        End If   

        'End If
        If IsPrice = True Then
            BroPrice = Me.GetBlockPrice(bro) 'SZ
            If BroPrice <> Nothing Or BroPrice <> 0 Then 'SZ - Set Price in BOM
                CurExcel.SetNextWord(BroPrice)
                'check if Unit is MeterCon_cm
                If atts(8) = GlbEnum.PriceUnitTypes.MeterCon_cm Then
                    CurExcel.SetNextWord(BroPrice * sum / 100)
                Else
                    CurExcel.SetNextWord(BroPrice * CDbl(atts(2)))
                End If
            End If
        End If
        CurExcel.SetCurrReturn()
    End Sub

    Public Function GetBlockPrice(ByVal bro As BlockRefOne) As Double 'SZ
        Dim UnPrice, TmpPrice, TotPrice As Double ' Price per Unit , Total Price 
        Dim Unit As Integer
        Dim fam As String = bro.BlockName.Substring(0, 2)
        Dim conn As New DBConn
        Dim rs As New ADODB.Recordset
        If Not conn.OpenConnectByPath(My.Settings.Path2PriceDB) Then
            Exit Function
        End If
        Try
            rs.Open("Select Price , Unit from " & fam & " where ParitName = '" & bro.BlockName & "'", conn.Connection, ADODB.CursorTypeEnum.adOpenStatic, _
                        ADODB.LockTypeEnum.adLockOptimistic)
            'rs = conn.Connection.Execute("Select Price , Unit from " & fam & " where ParitName = '" & bro.BlockName & "'")
        Catch ex As Exception
            Return Nothing
        End Try
        If Not rs.EOF Then
            ' Get and set Unit Price and Unit type from Price DB
            Try
                TmpPrice = CDbl(rs.Fields("Price").Value)
            Catch ex As Exception
                Return 0
            End Try

            Try
                If TmpPrice = Nothing OrElse TmpPrice = 0 Then
                    UnPrice = 0
                Else
                    UnPrice = TmpPrice
                End If
            Catch ex As Exception
                UnPrice = 0
            End Try
            Unit = CInt(rs.Fields("Unit").Value)
            If UnPrice > 0 Then
                ' Calculate total price including attributes prices
                TotPrice = CalcPrice(bro, UnPrice, Unit, conn) / CDbl(Me.ExchangeRate)
            End If

        End If
        conn.CloseConnection()
        Return TotPrice
    End Function

    ''' <summary>
    ''' Calculate price according to unit type and attributes
    ''' </summary>
    ''' <param name="bro">Current block</param>
    ''' <param name="UnPrice">Price per unit</param>
    ''' <param name="Unit">The kind of the unit (meter/unit/Sq meter...)</param>
    ''' <param name="Conn">database connection</param>
    ''' <returns>The calculated price</returns>
    ''' <remarks></remarks>
    Public Function CalcPrice(ByVal bro As BlockRefOne, ByVal UnPrice As Double, ByVal Unit As Integer, ByRef Conn As DBConn) As Double 'SZ
        Dim RetVal, Len, AttribPrice As Double
        Dim Att As AttribTemplateOne
        Select Case Unit
            Case GlbEnum.PriceUnitTypes.Meter_cm
                'Get length from attribute KMID_L (in cm)
                Att = bro.GetBlkAttrByTag("KMID_L")
                Len = CDbl(Att.AttValue) / 100 ' Get length in meters
                AttribPrice = GetAttribPrice(bro, Conn) ' Get Price of all attributes
                RetVal = (Len * UnPrice) + AttribPrice

            Case GlbEnum.PriceUnitTypes.Unit
                AttribPrice = GetAttribPrice(bro, Conn) ' Get Price of all attributes
                RetVal = UnPrice + AttribPrice

            Case GlbEnum.PriceUnitTypes.MeterCon_cm
                AttribPrice = GetAttribPrice(bro, Conn) ' Get Price of all attributes
                RetVal = UnPrice + AttribPrice

            Case GlbEnum.PriceUnitTypes.Area
                Att = bro.GetBlkAttrByTag("KMID_A")
                Dim AttVal As String
                If Att IsNot Nothing Then
                    If Att.AttValue Is Nothing Or Att.AttValue = "" Then
                        Dim AttTemp As AttribTemplateOne = bro.GetBlkAttrByTag("KMID_L")
                        If IsNumeric(CInt(AttTemp.AttValue)) Then
                            AttVal = AttTemp.AttValue
                        Else
                            AttVal = "0"
                        End If
                    Else
                        AttVal = Att.AttValue
                    End If
                Else
                    Dim AttTemp As AttribTemplateOne = bro.GetBlkAttrByTag("KMID_L")
                    If IsNumeric(CInt(AttTemp.AttValue)) Then
                        AttVal = CDbl(AttTemp.AttValue) * 0.01 'convert from cm to Meters if length
                    Else
                        AttVal = "0"
                    End If
                End If

                Len = CDbl(AttVal) ' Get Area
                AttribPrice = GetAttribPrice(bro, Conn) ' Get Price of all attributes
                RetVal = (Len * UnPrice) + AttribPrice

        End Select
        Return RetVal
    End Function

    Public Function GetAttribPrice(ByVal bro As BlockRefOne, ByRef Conn As DBConn) As Double
        Dim rs As New ADODB.Recordset
        Dim AttList As New List(Of AttribTemplateOne)
        Dim AttName As String
        Dim Attval As Double
        Dim AttPrice As Double = 0
        ' Find all needed attributes in the block (Category = Equipment , Operational)
        AttList = bro.GetAttrByCategory("Equipment")
        AttList.AddRange(bro.GetAttrByCategory("Operational"))
        ' For each found attribute - find it's price in Price DB - Attributes
        For Each att As AttribTemplateOne In AttList
            If att.AttValue <> "" OrElse Not att.AttValue Is Nothing Then
                If IsNumeric(att.AttValue) Or att.AttValue = "x" Or att.AttValue = "X" Then
                    AttName = att.Tag
                    If IsNumeric(att.AttValue) Then
                        Attval = CDbl(att.AttValue)
                    Else
                        Attval = 1
                    End If
                    Try
                        ' Find attribute price
                        rs.Open("Select Price from Attributes where Tag = '" & AttName & "'", Conn.Connection, _
                                ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
                        'rs = Conn.Connection.Execute("Select Price from Attributes where Tag = '" & AttName & "'")
                        If rs.EOF Then
                            rs.Close()
                            Continue For
                        End If
                        AttPrice = AttPrice + (CDbl(rs.Fields("Price").Value) * Attval)
                        rs.Close()
                    Catch ex As Exception
                        Continue For
                    End Try
                End If
            End If
        Next
        Return AttPrice
    End Function

    Public Sub FillRow(ByVal bro As BlockRefOne)
        Dim cont As Boolean = True
        Dim ato As AttribTemplateOne
        Dim NextTag As String = ""
        While cont

            'If Not Me.GetAttByColumn(CurExcel.CurCol, NextTag) Then
            'Exit While
            'End If

            'Get Attributes from the prepeared list
            If Not Me.GetAttByColumnFromList(CurExcel.CurCol, NextTag) Then
                Exit While
            End If

            ato = bro.GetBlkAttrByTag(NextTag)

            If ato Is Nothing OrElse ato.AttValue = "" Then
                CurExcel.ColNext()
                Continue While
            End If
            CurExcel.SetCurrWord(ato.AttValue)
            'CurExcel.SetBorder()
            CurExcel.ColNext()
        End While
        CurExcel.SetCurrReturn()
    End Sub

    Public Sub SetListSums()
        If Me.ListType = ListTypes.Fixed Then
            Exit Sub
        End If
        Dim indx As Integer = Me.RowNum
        CurExcel.CurCol = "A"
        CurExcel.CurRow = indx
        If Me.Lang = GlbEnum.Language.English Then
            CurExcel.SetCurrWord("Total : ")
            CurExcel.ObjExcelWorkSheet.range(CurExcel.CurCol & CurExcel.CurRow).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
        Else
            CurExcel.SetCurrWord("סה''כ: ")
            CurExcel.ObjExcelWorkSheet.range(CurExcel.CurCol & CurExcel.CurRow).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
        End If
        Dim rng As Microsoft.Office.Interop.Excel.Range = CurExcel.ObjExcelWorkSheet.range("A" & indx, "B" & indx)
        rng.Merge()
        Dim calc As Boolean
        Dim conn As New DBConn
        If Not conn.OpenConnectByPath(My.Settings.Path2DB) Then
            Exit Sub
        End If

        Dim rs As New ADODB.Recordset
        Try
            rs.Open("Select * from TemplateTagH ", conn.Connection, _
                    ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            'rs = conn.Connection.Execute("Select * from TemplateTagH ")
        Catch ex As Exception
            Exit Sub
        End Try

        If rs.EOF Then
            Exit Sub
        End If

        While Not rs.EOF
            Try
                calc = rs.Fields("CalcSum").Value
            Catch ex As Exception
                Exit Sub
            End Try

            If calc Then
                Try
                    CurExcel.CurCol = rs.Fields("TmpltClmn").Value
                Catch ex As Exception
                    Continue While
                End Try
                'rng = CurExcel.ObjExcelWorkSheet.range(CurExcel.CurCol & "3:" & CurExcel.CurCol & indx)
                'sum = rng.Summary

                'CurExcel.CurRow = indx
                'CurExcel.SetCurrWord(sum)
                Dim Kval, Qval, SumVal As String
                Dim Qpar As String = ""
                Dim totQ As Integer
                Dim totSum As Double = 0
                For i As Integer = 7 To Me.RowNum - 1
                    Kval = CurExcel.GetWord("A", i)
                    Qval = CurExcel.GetWord("C", i)

                    If Not Kval = "" Then
                        Qpar = Qval
                        totQ = CInt(Qval)
                    ElseIf Qpar <> "" Then
                        totQ = CInt(Qval) * CInt(Qpar)
                    End If

                    SumVal = CurExcel.GetWord(CurExcel.CurCol, i)
                    If Not IsNumeric(SumVal) OrElse SumVal = "" Then
                        Continue For
                    End If
                    totSum += CDbl(SumVal) * totQ
                Next
                If totSum > 0 Then
                    CurExcel.ObjExcelWorkSheet.range(CurExcel.CurCol & indx).formular1c1 = totSum
                End If
                'CurExcel.ObjExcelWorkSheet.range(CurExcel.CurCol & indx).Formula = "=sum(" & CurExcel.CurCol & "3:" & CurExcel.CurCol & indx - 1 & ")"
            End If
            rs.MoveNext()
        End While
        conn.CloseConnection()
        Me.RowNum += 1
        CurExcel.RowNext()
        CurExcel.SetRowBorder()

    End Sub

    Public Function GetBomInfo(ByVal bro As BlockRefOne) As String()
        Dim ExcelArray(8) As String
        Dim TmpAto As AttribTemplateOne

        TmpAto = bro.GetBlkAttrByTag("KNUM")
        If TmpAto IsNot Nothing Then
            ExcelArray(0) = TmpAto.AttValue
        End If
        If Me.Lang = GlbEnum.Language.Hebrew Then
            TmpAto = bro.GetBlkAttrByTag("KNAM_H")
        Else
            TmpAto = bro.GetBlkAttrByTag("KNAM_E")
        End If

        If TmpAto IsNot Nothing Then
            ExcelArray(1) = TmpAto.AttValue
        End If

        TmpAto = bro.GetBlkAttrByTag("KQNT")
        If TmpAto IsNot Nothing Then
            ExcelArray(2) = TmpAto.AttValue
        End If

        TmpAto = bro.GetBlkAttrByTag("KMID_L")
        If TmpAto IsNot Nothing Then
            ExcelArray(3) = TmpAto.AttValue
        End If

        TmpAto = bro.GetBlkAttrByTag("KMID_W")
        If TmpAto IsNot Nothing Then
            ExcelArray(4) = TmpAto.AttValue
        End If

        TmpAto = bro.GetBlkAttrByTag("KMID_H")
        If TmpAto IsNot Nothing Then
            ExcelArray(5) = TmpAto.AttValue
        End If

        TmpAto = bro.GetBlkAttrByTag("KMID_A")
        If TmpAto IsNot Nothing Then
            ExcelArray(6) = TmpAto.AttValue
        End If

        TmpAto = bro.GetBlkAttrByTag("KNOT_H")
        If TmpAto IsNot Nothing Then
            ExcelArray(7) = TmpAto.AttValue
        End If

        TmpAto = bro.GetBlkAttrByTag("KUNIT")
        If TmpAto IsNot Nothing Then
            ExcelArray(8) = TmpAto.AttValue
        End If

        Return ExcelArray
    End Function

    Public Function DoesContainSupplies(ByVal bro As BlockRefOne) As Boolean
        Dim curattr As AttribTemplateOne
        curattr = bro.GetBlkAttrByTag("KELC_KW")
        If curattr IsNot Nothing AndAlso curattr.AttValue <> "" Then
            Return (True)
        End If
        curattr = bro.GetBlkAttrByTag("KELC_HP")
        If curattr IsNot Nothing AndAlso curattr.AttValue <> "" Then
            Return (True)
        End If

        curattr = bro.GetBlkAttrByTag("KSTM_KK")
        If curattr IsNot Nothing AndAlso curattr.AttValue <> "" Then
            Return (True)
        End If

        curattr = bro.GetBlkAttrByTag("KGAS_KK")
        If curattr IsNot Nothing AndAlso curattr.AttValue <> "" Then
            Return (True)
        End If
        Return False
    End Function

    Public Sub SetBomSum(ByVal calcPrice As Boolean)
        If Me.ListType = ListTypes.Fixed Then
            Exit Sub
        End If
        Dim indx As Integer = Me.RowNum
        CurExcel.CurCol = "E"
        CurExcel.CurRow = indx
        If Me.Lang = GlbEnum.Language.English Then
            CurExcel.SetCurrWord("Total ")

        Else
            CurExcel.SetCurrWord("סה''כ:")
        End If
        Dim rng As Microsoft.Office.Interop.Excel.Range = CurExcel.ObjExcelWorkSheet.range("E" & indx, "E" & indx)
        rng.Font.Bold = True
        rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
        rng = CurExcel.ObjExcelWorkSheet.range("A" & indx, "D" & indx)
        rng.Merge()
        
        If (calcPrice = True) Then
            Dim totSum As Double = 0
            Dim SumVal As String
            CurExcel.CurCol = "F"
            For i As Integer = 6 To Me.RowNum - 1
                SumVal = CurExcel.GetWord(CurExcel.CurCol, i)
                If Not IsNumeric(SumVal) OrElse SumVal = "" Then
                    Continue For
                End If
                totSum += CDbl(SumVal)
            Next
            If totSum > 0 Then
                CurExcel.ObjExcelWorkSheet.range(CurExcel.CurCol & indx).formular1c1 = totSum
                CurExcel.ObjExcelWorkSheet.range(CurExcel.CurCol & indx).Font.Bold = True
            End If
        End If

        Me.RowNum += 1
        CurExcel.RowNext()
        CurExcel.SetRowBorder()
    End Sub

    '==============================================================================

End Class
