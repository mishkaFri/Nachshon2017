
Imports Microsoft.Office.Interop.Word

Public Class CrtWrdManag
    Private _CurExcel As ExcelManager
    Private _CurTenderDoc As Microsoft.Office.Interop.Word.Document
    Private _WordApp As Microsoft.Office.Interop.Word.Application
    Private _UCBomList As UC_BomList
    Private _Lang As String
    Private _LengthBroLen As String

#Region "Properties"
    Public Property CurExcel() As ExcelManager
        Get
            Return _CurExcel
        End Get
        Set(ByVal value As ExcelManager)
            _CurExcel = value
        End Set
    End Property
    Public Property CurTenderDoc() As Microsoft.Office.Interop.Word.Document
        Get
            Return _CurTenderDoc
        End Get
        Set(ByVal value As Microsoft.Office.Interop.Word.Document)
            _CurTenderDoc = value
        End Set
    End Property
    Public Property WordApp() As Microsoft.Office.Interop.Word.Application
        Get
            Return _WordApp
        End Get
        Set(ByVal value As Microsoft.Office.Interop.Word.Application)
            _WordApp = value
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
    Public Property LengthBroLen() As String
        Get
            Return _LengthBroLen
        End Get
        Set(ByVal value As String)
            _LengthBroLen = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal PathToXls As String, ByVal VisFlag As Boolean, _
                   Optional ByRef UcBL As UC_BomList = Nothing, _
                   Optional ByVal Lng As String = GlbEnum.Language.Hebrew)
        Try
            WordApp = GetObject(, "Word.Application")
        Catch ex As Exception
            WordApp = CreateObject("Word.Application")
        End Try
        Me.UCBomList = UcBL
        Me.Lang = Lng
        WordApp.Visible = VisFlag
        'Me.Set_Performance(True)
        Try
            Dim p2t As String
            If Me.Lang = Language.Hebrew Then
                p2t = GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) & "Docs\Tender\TenderTmp_H.dot"
            Else
                p2t = GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) & "Docs\Tender\TenderTmp_E.dot"
            End If

            Me.CurTenderDoc = WordApp.Documents.Add(p2t)
            WordApp.Options.PasteFormatBetweenDocuments = 0 '0= Keep source formatting 
            'CurTenderDoc.EmbedTrueTypeFonts = True
        Catch ex As Exception
            Exit Sub
        End Try

        ' Disabe Autocorrect text in Word    'SZ
        WordApp.Options.CheckGrammarAsYouType = False
        WordApp.Options.CheckGrammarWithSpelling = False
        WordApp.Options.IgnoreUppercase = False
        WordApp.Options.IgnoreMixedDigits = False
        WordApp.Options.IgnoreInternetAndFileAddresses = False
        WordApp.Options.RepeatWord = False
        WordApp.Options.ContextualSpeller = False
        WordApp.Options.CheckSpellingAsYouType = False
        '--------------------------------------------

        Me.CurExcel = New ExcelManager(PathToXls, False) 'Control over BOM Exl File
        Dim rng As Microsoft.Office.Interop.Excel.Range = Me.CurExcel.ObjExcelWorkSheet.Range("A1")
        rng.Select()
        Dim myLastRow As Integer = Me.CurExcel.ObjExcelWorkSheet.Cells.Find("*", rng, , , Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, _
        Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious).Row
        If myLastRow < 6 Then
            Exit Sub
        End If
        Dim Knum As String = ""
        Dim qnt As String = ""
        Dim bro As BlockRefOne
        Dim ispar As Boolean
        Dim Prog As Double

        ' For Progress Bar  'SZ
        Prog = 100 / (myLastRow - 6)

        For ch As Integer = 6 To myLastRow
            ' Proggres step for bar
            If Me.UCBomList.ProgBar.Value + Prog > 100 Then
                Me.UCBomList.ProgBar.Value = 100
            Else
                Me.UCBomList.ProgBar.Value += Prog
            End If
            Knum = CurExcel.GetWord("A", ch)
            If Knum = "" Then
                Continue For
            End If
            qnt = CurExcel.GetWord("D", ch)
            bro = GlbData.GlbBlocks.GetBlkByKnum(Knum, ispar)
            If bro Is Nothing Then
                Continue For
            End If
            ' Check Block Name's last letter
            If bro.BlockName.StartsWith("*") Then
                bro.BlockName = GlbSrvArx.GetBlockRealName(bro.BlockObj)
                If bro.BlockName.Length = 8 AndAlso bro.BlockName.Chars(7) = "D" Then
                    Continue For
                End If
            End If

            Me.AddTndItem(bro, qnt, ispar)
        Next
        Me.SetDocStyle() 'SZ
        Me.CurExcel.CloseFile()
        Dim Tmp As String = PathToXls.Substring(0, PathToXls.LastIndexOf("\") + 1)
        Dim TndName As String = PathToXls.Substring(Tmp.Length, PathToXls.Length - Tmp.Length)

        If TndName.Contains("BOM") Then
            TndName = TndName.Replace("BOM", "TND")
        Else
            TndName = TndName.Replace("BOQ", "TND")
        End If

        
        TndName = TndName.Remove(TndName.Length - 5)
        TndName = Tmp & TndName & Me.Lang & ".doc"
        WordApp.WordBasic.ViewFooterOnly()
        Me.CurTenderDoc.Sections.Item(1).Footers.Item(WdHeaderFooterIndex.wdHeaderFooterPrimary).PageNumbers.Add()
        ' Me.Set_Performance(False)
        If System.IO.File.Exists(TndName) Then
            'Me.CloseWrdDoc(TndName)
            System.IO.File.Delete(TndName)
        End If
        Me.CurTenderDoc.ActiveWindow.Selection.EscapeKey()
        Me.CurTenderDoc.SaveAs(TndName)
        Me.CloseWrdDoc(TndName)
        Try
            Clipboard.Clear()
        Catch ex As Exception

        End Try


    End Sub

    Public Sub FillFields(ByVal Fdoc As Microsoft.Office.Interop.Word.Document, ByVal Bro As BlockRefOne, ByVal Qnt As String, _
                          ByVal isSon As Boolean, ByRef noElec As Boolean, ByRef noGas As Boolean, ByRef noSteam As Boolean, _
                          ByVal isArea As Boolean)
        Dim kQnt As Integer = 0
        Dim curIndx As Integer = 1
        Dim SSV As Integer = 1  ' (Son Shift Value) : When Son - shift all fields  counters by -1 
        Dim LaNgShVal As Integer = 0 ' Language Shift Value - used in order to swich Knum and KNAM 
        ' Places according to language and table allignment (0 means Hebrew)
        If Me.Lang = Language.English Then
            LaNgShVal = 2
        End If
        Dim Ato As AttribTemplateOne
        Dim AttVal As String = ""
        If Not isSon Then
            Ato = Bro.GetBlkAttrByTag("KNUM")
            Fdoc.Fields.Item(GlbEnum.TndTlbFields.Num + LaNgShVal).Result.Text = GlbData.GlbActiveKitchen.PartNumb & "-" & Ato.AttValue
            curIndx += 1
            SSV = 0
        Else
            If Me.Lang = Language.English Then
                LaNgShVal = 1
            Else
                LaNgShVal = 0
            End If
        End If
        If Me.Lang = Language.Hebrew Then
            Ato = Bro.GetBlkAttrByTag("KNAM_H")
        Else
            Ato = Bro.GetBlkAttrByTag("KNAM_E")
        End If

        If Ato IsNot Nothing Then
            If isSon = True Then
                Fdoc.Fields.Item(GlbEnum.TndTlbFields.Desc - SSV + LaNgShVal).Result.Text = Ato.AttValue
            Else
                Fdoc.Fields.Item(GlbEnum.TndTlbFields.Desc - SSV).Result.Text = Ato.AttValue
            End If

        End If

        Ato = Bro.GetBlkAttrByTag("KQNT")
        If Ato IsNot Nothing Then
            kQnt = Ato.AttValue
            Fdoc.Fields.Item(GlbEnum.TndTlbFields.Qnt - SSV - LaNgShVal).Result.Text = Ato.AttValue
        End If

        If Not isArea Then
            curIndx += 1
            Ato = Bro.GetBlkAttrByTag("KMID_L")
            AttVal = Ato.AttValue
            'If Me.Lang = Language.Hebrew Then
            '    AttVal = Me.ReverseAroundPoint(AttVal)
            'End If
            Dim LenAto As AttribTemplateOne = Bro.GetBlkAttrByTag("KNUM")
            Dim UnitAtt As AttribTemplateOne = Bro.GetBlkAttrByTag("KUNIT")
            If Not IsNumeric(LenAto.AttValue) And LenAto.AttValue <> Nothing _
            And LenAto.AttValue <> "" And UnitAtt.AttValue = "5" Then
                AttVal = CStr(CDbl(Qnt) * 100) 'Convert to cm
                'If Me.Lang = Language.Hebrew Then
                '    AttVal = Me.ReverseAroundPoint(AttVal)
                'End If
                ' For length block - set total length from BOM
                Fdoc.Fields.Item(GlbEnum.TndTlbFields.Length - SSV).Result.Text = AttVal
                If kQnt > 1 Then
                    Fdoc.Fields.Item(GlbEnum.TndTlbFields.Qnt - SSV - LaNgShVal).Result.Text = IIf(LaNgShVal, "As Per Plan", "לפי תכנית")
                End If
            Else
                If Ato IsNot Nothing Then
                    AttVal = Ato.AttValue
                    'If Me.Lang = Language.Hebrew Then
                    '    AttVal = Me.ReverseAroundPoint(AttVal)
                    'End If
                    Fdoc.Fields.Item(GlbEnum.TndTlbFields.Length - SSV).Result.Text = AttVal
                End If
            End If
            curIndx += 1
            Ato = Bro.GetBlkAttrByTag("KMID_W")
            If Ato IsNot Nothing Then
                AttVal = Ato.AttValue
                'If Me.Lang = Language.Hebrew Then
                '    AttVal = Me.ReverseAroundPoint(AttVal)
                'End If
                Fdoc.Fields.Item(GlbEnum.TndTlbFields.Width - SSV).Result.Text = AttVal
            End If
            curIndx += 1
            Ato = Bro.GetBlkAttrByTag("KMID_H")
            If Ato IsNot Nothing Then
                AttVal = Ato.AttValue
                'If Me.Lang = Language.Hebrew Then
                '    AttVal = Me.ReverseAroundPoint(AttVal)
                'End If
                Fdoc.Fields.Item(GlbEnum.TndTlbFields.Height - SSV).Result.Text = AttVal
            End If

        Else
            curIndx += 1
            Ato = Bro.GetBlkAttrByTag("KMID_A")
            If Ato IsNot Nothing Then
                AttVal = Ato.AttValue
                'If Me.Lang = Language.Hebrew Then
                '    AttVal = Me.ReverseAroundPoint(AttVal)
                'End If
                Fdoc.Fields.Item(GlbEnum.TndTlbFields.Area - SSV).Result.Text = AttVal
            End If
        End If

        noElec = True
        noGas = True
        noSteam = True

        curIndx += 1
        Ato = Bro.GetBlkAttrByTag("KELC_KW")
        Dim Caption As String
        If Me.Lang = Language.Hebrew Then
            Caption = "ק''ו חשמל - "
        Else
            Caption = "KW: "
        End If
        If Ato IsNot Nothing AndAlso Ato.AttValue <> "" Then
            AttVal = Ato.AttValue
            'If Me.Lang = Language.Hebrew Then  ' SZ - return if doesn't work
            '    AttVal = Me.ReverseAroundPoint(AttVal)
            'End If
            Fdoc.Fields.Item(GlbEnum.TndTlbFields.Elec - SSV).Result.Text = Caption & AttVal
            noElec = False
        End If
        curIndx += 1
        Ato = Bro.GetBlkAttrByTag("KELC_PH")
        If Ato IsNot Nothing AndAlso Ato.AttValue <> "" Then
            Select Case Ato.AttValue
                Case "1"
                    If Me.Lang = Language.Hebrew Then
                        Fdoc.Fields.Item(GlbEnum.TndTlbFields.Phase - SSV).Result.Text = "חד-פאזי"  'SZ
                    Else
                        Fdoc.Fields.Item(GlbEnum.TndTlbFields.Phase - SSV).Result.Text = "Single-Phase"  'SZ
                    End If
                Case "3"
                    If Me.Lang = Language.Hebrew Then
                        Fdoc.Fields.Item(GlbEnum.TndTlbFields.Phase - SSV).Result.Text = "תלת-פאזי" 'SZ
                    Else
                        Fdoc.Fields.Item(GlbEnum.TndTlbFields.Phase - SSV).Result.Text = "3-Phase"  'SZ
                    End If
                Case Else
                    Fdoc.Fields.Item(GlbEnum.TndTlbFields.Phase - SSV).Result.Text = Ato.AttValue
            End Select
            noElec = False
        End If

        curIndx += 1

        Dim a As AttribTemplateOne = Bro.GetBlkAttrByTag("KNUM") 'SZ Temp
        Dim aa As String = a.AttValue 'SZ Temp

        Ato = Bro.GetBlkAttrByTag("KELC_HP")
        If Ato IsNot Nothing AndAlso Ato.AttValue <> "" Then
            Dim Caption2 As String
            AttVal = Ato.AttValue
            If Me.Lang = Language.Hebrew Then
                Caption2 = "כ''ס - "
            Else
                Caption2 = "HP: "
            End If
            'If Me.Lang = Language.Hebrew Then ' SZ - return if doesn't work
            '    AttVal = Me.ReverseAroundPoint(AttVal)
            'End If
            Fdoc.Fields.Item(GlbEnum.TndTlbFields.Horse - SSV).Result.Text = Caption2 & AttVal
            noElec = False

        End If

        curIndx += 1
        Ato = Bro.GetBlkAttrByTag("KGAS_KK")
        If Ato IsNot Nothing AndAlso Ato.AttValue <> "" Then
            AttVal = Ato.AttValue
            'If Me.Lang = Language.Hebrew Then ' SZ - return if doesn't work
            '    AttVal = Me.ReverseAroundPoint(AttVal)
            'End If
            Fdoc.Fields.Item(GlbEnum.TndTlbFields.Gas - SSV).Result.Text = AttVal
            noGas = False
        End If

        curIndx += 1
        Ato = Bro.GetBlkAttrByTag("KSTM_KK")
        If Ato IsNot Nothing AndAlso Ato.AttValue <> "" Then
            AttVal = Ato.AttValue
            'If Me.Lang = Language.Hebrew Then ' SZ - return if doesn't work
            '    AttVal = Me.ReverseAroundPoint(AttVal)
            'End If
            Fdoc.Fields.Item(GlbEnum.TndTlbFields.Steam - SSV).Result.Text = AttVal
            noSteam = False
        End If

        Dim tbl As Table
        tbl = Fdoc.Tables.Item(Fdoc.Tables.Count)
        tbl.Rows.Last.Cells.Delete()
        tbl.Rows.Last.Cells.Delete()
        tbl.Rows.Last.Cells.Delete()
        If isArea Then
            tbl.Rows.Item(GlbEnum.TndTlbRows.Size).Cells.Delete()
        Else
            tbl.Rows.Item(GlbEnum.TndTlbRows.Area).Cells.Delete()
        End If

    End Sub

    Public Sub FillFieldsArea(ByVal Fdoc As Microsoft.Office.Interop.Word.Document, ByVal Bro As BlockRefOne, ByVal Qnt As Integer)
        Dim Ato As AttribTemplateOne = Bro.GetBlkAttrByTag("KNUM")
        Fdoc.Fields.Item(1).Result.Text = Bro.BlockName.Substring(0, 3) & "-" & Ato.AttValue
        Ato = Bro.GetBlkAttrByTag("KNAM_H")
        If Ato IsNot Nothing Then
            Fdoc.Fields.Item(2).Result.Text = Ato.AttValue
        End If

        'Fdoc.Fields.Item(3).Result.Text = Qnt

        Ato = Bro.GetBlkAttrByTag("KMID_A")
        If Ato IsNot Nothing Then

            Fdoc.Fields.Item(3).Result.Text = Ato.AttValue
        End If


        Ato = Bro.GetBlkAttrByTag("KELC_KW")
        If Ato IsNot Nothing Then
            Fdoc.Fields.Item(4).Result.Text = Ato.AttValue
        End If

        Ato = Bro.GetBlkAttrByTag("KELC_PH")
        If Ato IsNot Nothing Then
            Fdoc.Fields.Item(5).Result.Text = Ato.AttValue
        End If

    End Sub

    Public Sub AddTndItem(ByVal bro As BlockRefOne, ByVal qnt As String, ByVal ispar As Boolean)
        Dim Ato, AtoTnd As AttribTemplateOne
        If bro.BlockName.StartsWith("*") Then
            Exit Sub
        End If
        Ato = bro.GetBlkAttrByTag("KNUM")
        Dim IsArea As Boolean
        If Ato Is Nothing OrElse Ato.AttValue = "" Then
            Exit Sub
        End If
        Dim TmpName As String
        Dim FirstAtt As Boolean = True
        'Dim ItemTbl As Microsoft.Office.Interop.Word.Table = _
        '                Me.CurTenderDoc.Tables.Add(Me.CurTenderDoc.ActiveWindow.Selection.Range, 1, 1)
        'With ItemTbl
        '    .Style = "Table Grid"
        '    .AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent)
        'End With

        Me.AddBlock2Selection(bro, Ato.AttValue, qnt)
        Dim ata As New AttribTemplateAll
        ata = bro.GetBlkAttsByPartTag("KK")
        For Each AtoTnd In ata.AttrList
            If AtoTnd.AttValue Is Nothing OrElse AtoTnd.AttValue = "" Then
                Continue For
            End If
            If AtoTnd.ShowInTender = False Then
                Continue For
            End If
            Me.AddAtt2Selection(AtoTnd, FirstAtt)
        Next

        ata = bro.GetBlkAttsByPartTag("KS")
        For Each AtoTnd In ata.AttrList
            If AtoTnd.AttValue Is Nothing OrElse AtoTnd.AttValue = "" Then
                Continue For
            End If
            If AtoTnd.ShowInTender = False Then
                Continue For
            End If
            Me.AddAtt2Selection(AtoTnd, FirstAtt)
        Next

        ata = bro.GetBlkAttsByPartTag("KT")
        For Each AtoTnd In ata.AttrList
            If AtoTnd.AttValue Is Nothing OrElse AtoTnd.AttValue = "" Then
                Continue For
            End If
            If AtoTnd.ShowInTender = False Then
                Continue For
            End If
            Me.AddAtt2Selection(AtoTnd, FirstAtt)
        Next

        ata = bro.GetBlkAttsByPartTag("KC") ' Get all KCLD_x attributes (Cold compressors)
        For Each AtoTnd In ata.AttrList
            If AtoTnd.AttValue Is Nothing OrElse AtoTnd.AttValue = "" Then
                Continue For
            End If
            If AtoTnd.ShowInTender = False Then
                Continue For
            End If
            Me.AddAtt2Selection(AtoTnd, FirstAtt)
        Next

        If ispar Then
            Dim AddItem As String
            If Me.Lang = Language.Hebrew Then
                AddItem = vbCr & "הצעת המחיר תכלול גם את הפריט/ים הבא/ים : "
            Else
                AddItem = vbCr & "The proposal will also include the following item/s: "
            End If
            Dim grp As Group = GlbSrvFunc.GetGroupByKnum(Ato.AttValue)
            If grp IsNot Nothing AndAlso grp.BlockList.Count > 0 Then
                With Me.CurTenderDoc.ActiveWindow.Selection
                    .TypeText(AddItem)
                    .HomeKey(Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdExtend)
                    .Font.Bold = WdConstants.wdToggle
                    .Font.BoldBi = WdConstants.wdToggle
                    .Font.UnderlineColor = WdColor.wdColorAutomatic
                    .Font.Underline = WdUnderline.wdUnderlineSingle
                    .EndKey()
                    Me.CurTenderDoc.ActiveWindow.Selection.TypeParagraph()
                    Me.CurTenderDoc.ActiveWindow.Selection.TypeParagraph()
                End With
                Dim UsedB As New List(Of String)
                For Each childBro As BlockRefOne In grp.BlockList
                    If UsedB.Contains(childBro.BlockName) Then
                        Continue For
                    End If
                    Me.AddSonBro2Selection(childBro, grp.BlockQntColl.Item(childBro.BlockName))
                    ata = childBro.GetBlkAttsByPartTag("KK")
                    For Each AtoTnd In ata.AttrList
                        If AtoTnd.AttValue Is Nothing OrElse AtoTnd.AttValue = "" Then
                            Continue For
                        End If
                        If AtoTnd.ShowInTender = False Then
                            Continue For
                        End If
                        Me.AddAtt2Selection(AtoTnd, FirstAtt)
                    Next

                    ata = childBro.GetBlkAttsByPartTag("KS")
                    For Each AtoTnd In ata.AttrList
                        If AtoTnd.AttValue Is Nothing OrElse AtoTnd.AttValue = "" Then
                            Continue For
                        End If
                        If AtoTnd.ShowInTender = False Then
                            Continue For
                        End If
                        Me.AddAtt2Selection(AtoTnd, FirstAtt)
                    Next

                    ata = childBro.GetBlkAttsByPartTag("KT")
                    For Each AtoTnd In ata.AttrList
                        If AtoTnd.AttValue Is Nothing OrElse AtoTnd.AttValue = "" Then
                            Continue For
                        End If
                        If AtoTnd.ShowInTender = False Then
                            Continue For
                        End If
                        Me.AddAtt2Selection(AtoTnd, FirstAtt)
                    Next

                    ata = childBro.GetBlkAttsByPartTag("KC") ' Get all KCLD_x attributes (Cold compressors)
                    For Each AtoTnd In ata.AttrList
                        If AtoTnd.AttValue Is Nothing OrElse AtoTnd.AttValue = "" Then
                            Continue For
                        End If
                        If AtoTnd.ShowInTender = False Then
                            Continue For
                        End If
                        Me.AddAtt2Selection(AtoTnd, FirstAtt)
                    Next

                    UsedB.Add(childBro.BlockName)
                Next
            End If
        End If

        Me.CurTenderDoc.ActiveWindow.Selection.EndKey()
        Me.CurTenderDoc.ActiveWindow.Selection.InsertParagraphAfter()

        Me.CurTenderDoc.ActiveWindow.Selection.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak)

    End Sub

    Public Sub AddBlock2Selection(ByVal bro As BlockRefOne, ByVal Knum As String, ByVal qnt As String)
        Dim Ato, AtoSizeType As AttribTemplateOne
        Dim IsArea, noElec, noGas, noSteam As Boolean
        Dim TmpName As String
        AtoSizeType = bro.GetBlkAttrByTag("KMID_A")
        If AtoSizeType IsNot Nothing AndAlso AtoSizeType.AttValue <> "" Then
            'TmpName = "TenderTmpltArea.Doc"
            IsArea = True
        Else
            'TmpName = "TenderTmpt.Doc"
            IsArea = False
        End If
        TmpName = "Docs\Tender\TenderTmpt_new_" & Me.Lang & ".Doc"
        Dim data As IDataObject = Nothing
        Dim p2Form As String = GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) & TmpName
        Dim Fdoc As Microsoft.Office.Interop.Word.Document = WordApp.Documents.Open(p2Form)
        Me.FillFields(Fdoc, bro, qnt, False, noElec, noGas, noSteam, IsArea)
        Try
            Fdoc.Bookmarks("Form").Select()
            Fdoc.ActiveWindow.Selection.Copy()
            data = Clipboard.GetDataObject()
        Catch ex As Exception
        Finally
            Fdoc.Close(False)
        End Try

        If data IsNot Nothing Then
            Me.CurTenderDoc.ActiveWindow.Selection.InsertParagraphAfter()
            Me.CurTenderDoc.ActiveWindow.Selection.Paste()
        End If
        'Dim DeletedRows As Integer = 1
        Dim tbl As Table
        tbl = Me.CurTenderDoc.Tables.Item(Me.CurTenderDoc.Tables.Count)

        ' Temporary dont include supplies in Tender (asked by Itzik June 2011) 'SZ
        ' Cancel the following 3 lines in order to regain supply in tender
        'noSteam = True
        'noGas = True
        'noElec = True
        ''------------------------------------------------------------------------
        'If noSteam And tbl.Rows.Count = 6 Then           
        '    tbl.Rows.Last.Cells.Delete()
        'End If

        'If noGas And tbl.Rows.Count = 5 Then
        '    tbl.Rows.Last.Cells.Delete()
        'End If

        'If noElec And tbl.Rows.Count = 4 Then
        '    tbl.Rows.Last.Cells.Delete()
        'End If

        'If IsArea Then
        '    tbl.Rows.Item(GlbEnum.TndTlbRows.Size).Cells.Delete()
        'Else
        '    tbl.Rows.Item(GlbEnum.TndTlbRows.Area).Cells.Delete()
        'End If


        data = Nothing

        Dim PcountStart As Integer = Me.CurTenderDoc.ComputeStatistics _
                        (Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages)
        Dim TxtDoc As Microsoft.Office.Interop.Word.Document
        Try
            TxtDoc = WordApp.Documents.Open(GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) _
            & "Docs\Parts\" & bro.BlockName.Substring(0, 2) & "_" & Me.Lang & ".Doc")
            'TxtDoc.PageSetup.PaperSize = WdPaperSize.wdPaperLetter
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Bm As String = bro.BlockName.Remove(3, 1)
        Bm = Bm.Remove(bro.BlockName.Length - 2, 1)
        Dim txtRng As String = ""
        Dim Rbm As String = ""
        Try
            If Not Me.IsBookmarkStartsWith(Bm, TxtDoc.Bookmarks, Rbm) Then
                Exit Try
            End If
            TxtDoc.Bookmarks(Rbm).Select()
            TxtDoc.ActiveWindow.Selection.Tables(1).PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPoints
            TxtDoc.ActiveWindow.Selection.Tables(1).PreferredWidth = WordApp.InchesToPoints(7)
            TxtDoc.ActiveWindow.Selection.Copy()
            data = Clipboard.GetDataObject()
        Catch ex As Exception
        Finally
            TxtDoc.Close(False)
        End Try

        If data IsNot Nothing Then
            Me.CurTenderDoc.ActiveWindow.Selection.EndKey(Unit:=WdUnits.wdStory)
            Try
                Me.CurTenderDoc.ActiveWindow.Selection.Paste()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub AddAtt2Selection(ByVal ato As AttribTemplateOne, ByRef FirstAtt As Boolean)
        Dim TmpName As String
        Dim data As IDataObject = Nothing
        Dim TxtDoc As Microsoft.Office.Interop.Word.Document
        Try
            TxtDoc = WordApp.Documents.Open(My.Settings.Path2Temp & "Docs\Parts\ATT_" & Me.Lang & ".doc")
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Am As String = ato.Tag
        Dim txtRng As String = ""
        Dim Rbm As String = ""
        Try
            If Not Me.IsBookmarkStartsWith(Am, TxtDoc.Bookmarks, Rbm) Then
                Exit Try
            End If

            TxtDoc.Bookmarks(Am).Select()
            TxtDoc.ActiveWindow.Selection.Copy()

            data = Clipboard.GetDataObject()

        Catch ex As Exception
        Finally
            TxtDoc.Close(False)
        End Try


        Dim AddItem As String
        If Me.Lang = Language.Hebrew Then
            AddItem = vbCr & "הפריט יסופק עם:"
        Else
            AddItem = vbCr & "The item will be supplied with: "
        End If
        If data IsNot Nothing Then
            If FirstAtt Then
                With Me.CurTenderDoc.ActiveWindow.Selection
                    .TypeText(AddItem)
                    .HomeKey(Unit:=WdUnits.wdLine, Extend:=WdMovementType.wdExtend)
                    .Font.Bold = WdConstants.wdToggle
                    .Font.BoldBi = WdConstants.wdToggle
                    .Font.UnderlineColor = WdColor.wdColorAutomatic
                    .Font.Underline = WdUnderline.wdUnderlineSingle
                    .EndKey()
                    Me.CurTenderDoc.ActiveWindow.Selection.TypeParagraph()
                    Me.CurTenderDoc.ActiveWindow.Selection.TypeParagraph()
                End With

                FirstAtt = False
            End If

            Me.CurTenderDoc.ActiveWindow.Selection.Paste()
            Me.CurTenderDoc.ActiveWindow.Selection.EndKey(Unit:=WdUnits.wdStory)
        End If

    End Sub

    Public Sub AddSonBro2Selection(ByVal bro As BlockRefOne, ByVal qnt As Integer)
        Dim Ato, AtoSizeType As AttribTemplateOne
        Dim IsArea, noElec, noGas, noSteam As Boolean
        Dim TmpName As String
        AtoSizeType = bro.GetBlkAttrByTag("KMID_A")
        If AtoSizeType IsNot Nothing AndAlso AtoSizeType.AttValue <> "" Then
            IsArea = True
        Else
            IsArea = False
        End If
        TmpName = "Docs\Tender\TenderTmptSon_" & Me.Lang & ".Doc"
        Dim data As IDataObject = Nothing
        Dim p2Form As String = GlbData.GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) & TmpName
        Dim Fdoc As Microsoft.Office.Interop.Word.Document = WordApp.Documents.Open(p2Form)

        Me.FillFields(Fdoc, bro, qnt, True, noElec, noGas, noSteam, IsArea)
        Try
            Fdoc.Bookmarks("Form").Select()
            Fdoc.ActiveWindow.Selection.Copy()
            data = Clipboard.GetDataObject()
        Catch ex As Exception
        Finally
            Fdoc.Close(False)
        End Try

        If data IsNot Nothing Then
            Me.CurTenderDoc.ActiveWindow.Selection.InsertParagraphAfter()
            Me.CurTenderDoc.ActiveWindow.Selection.Paste()
            ' Me.CurTenderDoc.ActiveWindow.Selection.EndKey()
        End If
        'Dim DeletedRows As Integer = 1
        Dim tbl As Table
        tbl = Me.CurTenderDoc.Tables.Item(Me.CurTenderDoc.Tables.Count)
        If tbl.Rows.Count > 6 Then
            tbl.Split(tbl.Rows.Count - 5)
            tbl = Me.CurTenderDoc.Tables.Item(Me.CurTenderDoc.Tables.Count)
        End If

        ' Temporary dont include supplies in Tender (asked by Itzik June 2011) 'SZ
        ' Cancel the following 3 lines in order to regain supply in tender
        'noSteam = True
        'noGas = True
        'noElec = True

        'If noSteam Then
        '    tbl = Me.CurTenderDoc.Tables.Item(Me.CurTenderDoc.Tables.Count)
        '    tbl.Rows.Item(GlbEnum.TndTlbRows.Steam).Delete()
        'End If

        'If noGas Then
        '    tbl = Me.CurTenderDoc.Tables.Item(Me.CurTenderDoc.Tables.Count)
        '    tbl.Rows.Item(GlbEnum.TndTlbRows.Gas).Delete()
        'End If

        'If noElec Then
        '    tbl = Me.CurTenderDoc.Tables.Item(Me.CurTenderDoc.Tables.Count)
        '    tbl.Rows.Item(GlbEnum.TndTlbRows.Elec).Delete()
        'End If

        'If IsArea Then
        '    tbl.Rows.Item(GlbEnum.TndTlbRows.Size).Delete()
        'Else
        '    tbl.Rows.Item(GlbEnum.TndTlbRows.Area).Delete()
        'End If


        ' New paragraph needed
        Me.CurTenderDoc.ActiveWindow.Selection.InsertParagraphAfter()

        data = Nothing

        Dim PcountStart As Integer = Me.CurTenderDoc.ComputeStatistics _
                        (Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages)
        Dim TxtDoc As Microsoft.Office.Interop.Word.Document
        Try
            TxtDoc = WordApp.Documents.Open(GlbSrvFunc.AddSlash2Path(My.Settings.Path2Temp) & "Docs\Parts\" & _
                     bro.BlockName.Substring(0, 2) & "_" & Me.Lang & ".Doc")

        Catch ex As Exception
            Exit Sub
        End Try

        Dim Bm As String = bro.BlockName.Remove(3, 1)
        Bm = Bm.Remove(bro.BlockName.Length - 2, 1)
        Dim txtRng As String = ""
        Dim Rbm As String = ""
        Try
            If Not Me.IsBookmarkStartsWith(Bm, TxtDoc.Bookmarks, Rbm) Then
                Exit Try
            End If
            TxtDoc.Bookmarks(Rbm).Select()
            TxtDoc.ActiveWindow.Selection.Copy()
            TxtDoc.ActiveWindow.Selection.Tables(1).PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPoints
            TxtDoc.ActiveWindow.Selection.Tables(1).PreferredWidth = WordApp.InchesToPoints(7)
            data = Clipboard.GetDataObject()
        Catch ex As Exception
        Finally
            TxtDoc.Close(False)
        End Try

        If data IsNot Nothing Then
            Try
                Me.CurTenderDoc.ActiveWindow.Selection.InsertParagraphAfter()
                Me.CurTenderDoc.ActiveWindow.Selection.Paste()
                Me.CurTenderDoc.ActiveWindow.Selection.EndKey(Unit:=WdUnits.wdStory)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Function CloseWrdDoc(ByVal path_name As String) As Boolean
        Me.WordApp.DisplayAlerts = True 'SZ
        'Dim wName As String = path_name.Substring(path_name.LastIndexOf("\") + 1)
        For Each doc As Microsoft.Office.Interop.Word.Document In WordApp.Documents
            If doc.FullName = path_name Then
                Try
                    doc.Save()
                    doc.Close()
                    System.Threading.Thread.Sleep(200)
                    Me.WordApp.Quit()
                    Return True
                Catch ex As Exception
                End Try
            End If
        Next
        Me.WordApp.DisplayAlerts = False 'SZ
        Return False
    End Function

    Public Function IsBookmarkStartsWith(ByVal bm As String, ByVal Barr As Microsoft.Office.Interop.Word.Bookmarks, ByRef rBm As String) As Boolean
        For Each Bobj As Microsoft.Office.Interop.Word.Bookmark In Barr
            If Bobj.Name.StartsWith(bm) Then
                rBm = Bobj.Name
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub Set_Performance(ByVal doit As Boolean)

        'WordApp.EnableEvents = doit
        WordApp.ScreenUpdating = Not doit

    End Sub

    Public Sub SetDocStyle()
        WordApp.ActiveDocument.Select()
        'WordApp.ActiveDocument.EmbedTrueTypeFonts = True
        ' Dock and style the document according to it's language
        If Me.Lang = Language.Hebrew Then
            Me.CurTenderDoc.ActiveWindow.Selection.RtlPara()
            Me.CurTenderDoc.ActiveWindow.Selection.Font.NameBi = "Arial"
            'Me.CurTenderDoc.ActiveWindow.Selection.Font.SizeBi = 11  ' Was canceled due to problems with number reversing 12/2011
        Else
            Me.CurTenderDoc.ActiveWindow.Selection.LtrPara()
            Me.CurTenderDoc.ActiveWindow.Selection.Font.Name = "Arial" ' SZ
            Me.CurTenderDoc.ActiveWindow.Selection.Font.Size = 11 ' SZ
        End If
        Dim tblCount As Integer = 0

        For Each tbl As Table In Me.CurTenderDoc.Tables
            If tbl.Rows.Count = 0 Then Continue For
            If tbl.Rows.AllowBreakAcrossPages = 0 Then
                Continue For
            End If
            tbl.PreferredWidth = WordApp.InchesToPoints(7)
            If Me.Lang = Language.Hebrew Then
                'tbl.TableDirection = WdTableDirection.wdTableDirectionRtl  ' Determine the direction of the table (left->right or right->left)
            Else
                If tbl.Rows.Alignment <> WdRowAlignment.wdAlignRowRight Then
                    tbl.Rows.Alignment = WdRowAlignment.wdAlignRowRight
                End If
                If tbl.Rows.LeftIndent <> WordApp.InchesToPoints(0) Then
                    tbl.Rows.LeftIndent = WordApp.InchesToPoints(0)
                End If
                'tbl.Style = CurTenderDoc.Styles("Normal")
                'tbl.TableDirection = WdTableDirection.wdTableDirectionLtr ' Canceled by SZ 10/6/2012
            End If
            tblCount = tblCount + 1
        Next
        WordApp.ActiveDocument.FormFields.Shaded = False 'Disable Field gray shading
        Me.CurTenderDoc.ActiveWindow.ActivePane.View.Zoom.Percentage = 70

        Me.CurTenderDoc.ActiveWindow.Selection.EndKey()
    End Sub

    ''' <summary>
    ''' for True Font - reverse numbers around point 22.3 -> 3.22
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns>The reversed number as string</returns>
    ''' <remarks></remarks>
    Public Function ReverseAroundPoint(ByVal str As String) As String
        Dim StrArr(), RetStr As String
        RetStr = str
        If IsNumeric(str) And str.Contains(".") Then
            StrArr = str.Split(".")
            RetStr = StrArr(1) & "." & StrArr(0)
        End If
        Return RetStr
    End Function

End Class