Public Class ExcelManager
    Private _path2File As String
    Private _objExcelApp As Object  ' Excel.Application
    Private _objExcelWorkBook As Object 'Excel.Workbook
    Private _objExcelWorkSheet As Object ' Excel.Worksheet
    Private _curRow As String
    Private _curCol As String
    Private oldCI As System.Globalization.CultureInfo

#Region "Properties"

    Public Property CurCol() As String
        Get
            Return _curCol
        End Get
        Set(ByVal value As String)
            _curCol = value
        End Set
    End Property

    Public Property CurRow() As String
        Get
            Return _curRow
        End Get
        Set(ByVal value As String)
            _curRow = value
        End Set
    End Property

    Public Property ObjExcelApp() As Object ' Excel.Application
        Get
            Return _objExcelApp
        End Get
        Set(ByVal value As Object) 'Excel.Application)
            _objExcelApp = value
        End Set
    End Property

    Public Property ObjExcelWorkBook() As Object ' Excel.Workbook
        Get
            Return _objExcelWorkBook
        End Get
        Set(ByVal value As Object) 'Excel.Workbook)
            _objExcelWorkBook = value
        End Set
    End Property

    Public Property ObjExcelWorkSheet() As Object 'Excel.Worksheet
        Get
            Return _objExcelWorkSheet
        End Get
        Set(ByVal value As Object) 'Excel.Worksheet
            _objExcelWorkSheet = value
        End Set
    End Property

    Public Property Path2File() As String
        Get
            Return _path2File
        End Get
        Set(ByVal value As String)
            _path2File = value
        End Set
    End Property

#End Region


    Public Function SelectALL() As Object
        Me.ObjExcelApp.ScreenUpdating = False
        Dim myLastRow As Long
        Dim myLastColumn As Long
        Dim myLastCell As String
        Dim myRange As String

        Dim rng As Microsoft.Office.Interop.Excel.Range = Me.ObjExcelWorkSheet.Range("A1")
        rng.Select()
        On Error Resume Next
        myLastRow = Me.ObjExcelWorkSheet.Cells.Find("*", rng, , , Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, _
        Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious).Row
        myLastColumn = Me.ObjExcelWorkSheet.Cells.Find("*", rng, , , Microsoft.Office.Interop.Excel.XlSearchOrder.xlByColumns, _
        Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious).Column
        myLastCell = Me.ObjExcelWorkSheet.Cells(myLastRow, myLastColumn).Address
        myRange = "a1:" & myLastCell
        Me.ObjExcelApp.ScreenUpdating = True
        Return Me.ObjExcelWorkSheet.Range(myRange)

    End Function


    Public Sub New(ByVal DoCreate As Boolean)
        Try
            ObjExcelApp = GetObject(, "Excel.Application")
        Catch ex As Exception
            Try
                If DoCreate Then
                    ObjExcelApp = CreateObject("Excel.Application")
                End If


            Catch ex1 As Exception
                ObjExcelApp = Nothing
                MsgBox("Excell Object Cannot Not Find")
                Exit Sub
            End Try
        End Try
        If ObjExcelApp Is Nothing Then
            Exit Sub
        End If
        ObjExcelApp.UserControl = True
        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo("en-US")
    End Sub

    Public Sub New(ByVal Path2ExcelFile As String, ByVal VisibFlag As Boolean)
        Try
            ObjExcelApp = GetObject(, "Excel.Application")
            If ObjExcelApp.Visible = False Then
                ObjExcelApp.Visible = VisibFlag
            End If
        Catch ex As Exception
            Try

                ObjExcelApp = CreateObject("Excel.Application")
                ObjExcelApp.Visible = VisibFlag
            Catch ex1 As Exception
                ObjExcelApp = Nothing
                MsgBox("Excell Object Cannot Not Find")
                Exit Sub
            End Try
        End Try

        ObjExcelApp.UserControl = True
        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo("en-US")
        Me.ObjExcelWorkBook = Me.GetOpenWBook(Path2ExcelFile)
        If Me.ObjExcelWorkBook Is Nothing Then
            Me.ObjExcelWorkBook = ObjExcelApp.Workbooks.Open(Path2ExcelFile)
        End If


        Me.ObjExcelWorkSheet = Me.ObjExcelWorkBook.Worksheets.Item(1)



        Me.CurRow = "1"
        Me.CurCol = "A"

        '   Me.ObjExcelWorkSheet.Range("A1").FormulaR1C1 = "Ksoftigor001"
    End Sub
    Public Sub Open(ByVal Path2Tlb As String)
        If Not System.IO.File.Exists(Path2Tlb) Then
            Exit Sub
        End If
        ObjExcelApp.Visible = True
        Me.ObjExcelWorkBook = ObjExcelApp.Workbooks.Open(Path2Tlb)

        Me.ObjExcelWorkSheet = Me.ObjExcelWorkBook.Worksheets.Item("Sheet1")

    End Sub
    Public Sub SetCurrWord(ByVal GivenWord As String)
        Dim FldName As String

        FldName = CurCol & CurRow
        Me.ObjExcelWorkSheet.Range(FldName).FormulaR1C1 = GivenWord
    End Sub

    Public Function GetWord(ByVal col As String, ByVal row As String) As String
        Dim FldName As String

        FldName = col & row
        Return Me.ObjExcelWorkSheet.Range(FldName).FormulaR1C1
    End Function
    Public Sub SetNextWord(ByVal GivenWord As String)
        Dim ch As Integer
        Dim FldName As String

        ch = 1 + Asc(CurCol)
        Me.CurCol = Chr(ch)

        FldName = CurCol & CurRow

        Me.ObjExcelWorkSheet.Range(FldName).FormulaR1C1 = GivenWord

    End Sub

    Public Sub ColNext()
        Dim ch As Integer = -1
        Dim l As Integer = CurCol.Length
        Dim resCol As String = ""
        While l > 0

            If Not Asc(CurCol.Chars(l - 1)) = Asc("Z") Then
                ch = 1 + Asc(CurCol.Chars(l - 1))
                resCol = Chr(ch) & resCol
                For i As Integer = 0 To l - 2
                    resCol = CurCol(i) & resCol
                Next
                Exit While
            End If
            resCol = resCol & "A"
            l -= 1
        End While
        If ch = -1 Then
            resCol = "A" & resCol
        End If

        Me.CurCol = resCol.Trim(Chr(32))
    End Sub

    Public Sub RowNext()
        Dim ch As Integer

        ch = 1 + CInt(Me.CurRow)
        Me.CurRow = CStr(ch)
    End Sub
    Public Function GerRowNumByColVal(ByVal col As String, ByVal val As String) As Integer
        Dim rng As Microsoft.Office.Interop.Excel.Range = Me.ObjExcelWorkSheet.range(col & "1")
        Dim rowVal As String

        For i As Integer = 3 To rng.Rows.Count

            rowVal = Me.GetWord(col, i)
            If rowVal = val Then
                Return i
            End If
        Next
        Return -1
    End Function
    Public Sub SetCurrReturn()
        Dim ch As Integer

        ch = 1 + CInt(Me.CurRow)
        Me.CurRow = CStr(ch)
        Me.CurCol = "A"
    End Sub

    Public Sub RowShift(ByVal Shift As Integer)
        Dim ch As Integer

        ch = Shift + CInt(Me.CurRow)
        Me.CurRow = CStr(ch)
    End Sub
    ''' <summary>
    ''' Set Border to the current cell
    ''' </summary>
    ''' <param name="LnStyle"> Line style, possible values : 
    '''                           1 : continious
    '''                           -4118 : xldot 
    '''                           -4138 : Bold     </param>
    ''' <remarks></remarks>
    Public Sub SetBorder(Optional ByVal LnStyle As Integer = 1)
        '********* Border Defenitions ********************
        ' 9= Bottom    8=Top    7 = Left     10 = Right  *
        ' 11 = Inside vertical  12 = Inside Horizontal   *
        '----------------------------------------------  *
        ' Style :     1 : continious                     *
        '         -4118 : xldot 
        '       -4138 : Bold                             *
        '*************************************************
        Dim FldName As String

        FldName = CurCol & CurRow
        If Me.ObjExcelWorkSheet.Range(FldName).Borders(9).LineStyle = -4142 Then
            Me.ObjExcelWorkSheet.Range(FldName).Borders(9).Weight = LnStyle
        End If

        If Me.ObjExcelWorkSheet.Range(FldName).Borders(8).LineStyle = -4142 Then
            Me.ObjExcelWorkSheet.Range(FldName).Borders(8).Weight = LnStyle
        End If

        If Me.ObjExcelWorkSheet.Range(FldName).Borders(7).LineStyle = -4142 Then
            Me.ObjExcelWorkSheet.Range(FldName).Borders(7).Weight = LnStyle
        End If

        If Me.ObjExcelWorkSheet.Range(FldName).Borders(10).LineStyle = -4142 Then
            Me.ObjExcelWorkSheet.Range(FldName).Borders(10).Weight = LnStyle
        End If


    End Sub

    ''' <summary>
    ''' Set Border to a given range
    ''' </summary>
    ''' <param name="LnStyle"> Line style, possible values : 
    '''                           1 : continious
    '''                           -4118 : xldot 
    '''                           -4138 : Bold     </param>
    ''' <remarks></remarks>
    Public Sub SetBorderToRange(ByVal rng As Microsoft.Office.Interop.Excel.Range, Optional ByVal LnStyle As Integer = 1)
        '********* Border Defenitions ********************
        ' 9= Bottom    8=Top    7 = Left     10 = Right  *
        ' 11 = Inside vertical  12 = Inside Horizontal   *
        '----------------------------------------------  *
        ' Style :     1 : continious                     *
        '         -4118 : xldot 
        '       -4138 : Bold                             *
        '*************************************************
        For i As Integer = 7 To 10
            If rng.Borders(i).LineStyle = -4142 Then
                rng.Borders(i).LineStyle = LnStyle
            End If
        Next

    End Sub

    Public Sub SetAllBorders() 'SZ
        '********* Border Defenitions ********************
        ' 9= Bottom    8=Top    7 = Left     10 = Right  *
        ' 11 = Inside vertical  12 = Inside Horizontal   *
        '*************************************************
        Dim Rng As Microsoft.Office.Interop.Excel.Range = SelectALL()
        Rng.Select()
        For i As Integer = 7 To 12
            With Rng.Borders(i)
                .LineStyle = 1
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = 2
            End With
        Next
    End Sub

    Public Sub SetRowBorder(Optional ByVal LnStyle As Integer = 1) 'SZ
        '********* Border Defenitions ********************
        ' 9= Bottom    8=Top    7 = Left     10 = Right  *
        ' 11 = Inside vertical  12 = Inside Horizontal   *
        '----------------------------------------------  *
        ' Style :     1 : continious                     *
        '         -4118 : xldot                          *
        '*************************************************
        Dim myRow As Long
        Dim myLastColumn As Long
        Dim myLastCell As String
        Dim myRange As String

        Dim rng As Microsoft.Office.Interop.Excel.Range = Me.ObjExcelWorkSheet.Range("A1")
        'rng.Select()
        On Error Resume Next
        myLastColumn = Me.ObjExcelWorkSheet.Cells.Find("*", rng, , , Microsoft.Office.Interop.Excel.XlSearchOrder.xlByColumns, _
        Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious).Column
        myRow = CInt(Me.CurRow) - 1
        myLastCell = Me.ObjExcelWorkSheet.Cells(myRow, myLastColumn).Address
        myLastCell = myLastCell.Replace("$", "")
        myRange = "a" & CStr(myRow) & ":" & myLastCell
        Me.ObjExcelApp.ScreenUpdating = True
        rng = Me.ObjExcelWorkSheet.Range(myRange)
        rng.Select()
        ' For Each cl As Microsoft.Office.Interop.Excel.Range In rng.Cells
        With rng.Cells.Borders(7) 'cl.Borders(7)  
            .LineStyle = 1
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = 2
        End With
        With rng.Borders(9) 'cl.Borders(9)
            .LineStyle = LnStyle
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = 2
        End With
        With rng.Borders(10) 'cl.Borders(9)
            .LineStyle = 1
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = 2
        End With
        With rng.Borders(11) 'cl.Borders(9)
            .LineStyle = 1
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = 2
        End With
        'Next
    End Sub

    Public Function GetOpenWBook(ByVal path2Wb) As Object
        If Me.ObjExcelApp Is Nothing Then
            Return Nothing
        End If
        For Each WBook As Object In Me.ObjExcelApp.workbooks
            If WBook.fullname = path2Wb Then
                Return WBook
            End If
        Next
        Return Nothing
    End Function

    Public Sub CloseWB(ByVal path2Wb)
        Dim WB As Object = Me.GetOpenWBook(path2Wb)
        If WB Is Nothing Then
            Exit Sub
        End If
        WB.close()
    End Sub

    Public Sub CloseFile()
        '      System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        Me.ObjExcelApp.DisplayAlerts() = False 'SZ
        Me.ObjExcelWorkBook.Save()
        Me.ObjExcelWorkBook.Close()
        Me.ObjExcelApp.DisplayAlerts() = True 'SZ
        Me.ObjExcelApp.Quit()
        Me.ObjExcelApp = Nothing

    End Sub

End Class
