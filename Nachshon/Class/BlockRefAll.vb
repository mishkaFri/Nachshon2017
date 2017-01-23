Imports System
Imports Autodesk.AutoCAD.Interop.Common
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports System.Collections.Generic

Public Class BlockRefAll
    Private _blockList As New Collection

    Public Property BlockList() As Collection
        Get
            Return _blockList
        End Get
        Set(ByVal value As Collection)
            _blockList = value
        End Set
    End Property

    Public Function LoadBlock_1() As Boolean
        Dim Db As Database = HostApplicationServices.WorkingDatabase()
        Dim trans As Transaction = Db.TransactionManager.StartTransaction()

        Dim bt As BlockTable = trans.GetObject(Db.BlockTableId, OpenMode.ForRead)
        Dim btr As BlockTableRecord = trans.GetObject(bt.Item(BlockTableRecord.ModelSpace), OpenMode.ForWrite)


        trans.Dispose()
    End Function

    Public Function Addblock(ByVal ent As AcadEntity, ByVal tr As Transaction) As BlockRefOne
        Dim blkrefOne As BlockRefOne
        Dim CurBlockRef As BlockReference = GlbData.GlbSrvArx.GetBlkRefFmAcadEnt(ent, tr)
        If CurBlockRef Is Nothing Then
            Return Nothing
        End If
        blkrefOne = New BlockRefOne
        blkrefOne.BlockObj = CurBlockRef
        blkrefOne.BlockName = CurBlockRef.Name
        blkrefOne.FlagStaticKnum = False
        Me.BlockList.Add(blkrefOne)
        blkrefOne.LoadAttrib()
        Dim att As AttribTemplateOne = blkrefOne.GetBlkAttrByTag("KNUM")
        'If att IsNot Nothing AndAlso att.AttValue <> "" AndAlso IsNumeric(att.AttValue.Chars(0)) Then
        '    att.AttValue = ""
        '    Me.UpdateKnumInAcad()
        'End If
        GlbData.GlbSrvArx.RemoveAttByTag(blkrefOne, "AppGrpParent")
        GlbData.GlbSrvArx.RemoveAttByTag(blkrefOne, "AppGrpNum")

        Return blkrefOne
    End Function

    Public Function LoadBlocks() As Boolean

        Dim ch As Integer
        Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim CurBlockRef As BlockReference = Nothing
        Dim MyBlockOne As BlockRefOne = Nothing
        Dim ent As Entity = Nothing
        Me.BlockList = New Collection()
        GlbData.GlbGroups.Clear()
        tm = db.TransactionManager
        Dim tr As Transaction = tm.StartTransaction()

        Dim Bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForRead, False), BlockTable)
        Dim msbtr As BlockTableRecord = tm.GetObject(Bt.Item(BlockTableRecord.ModelSpace), OpenMode.ForRead)

        Dim id As ObjectId ' First, dimension an ID variable used in the For Loop.
        For Each id In msbtr
            ent = tr.GetObject(id, OpenMode.ForRead)
            If ent IsNot Nothing AndAlso TypeOf ent Is BlockReference Then
                CurBlockRef = CType(ent, BlockReference)
                ' Don't count in blocks that doesen't have attributes (not 'Systhema' blocks)
                If CurBlockRef.AttributeCollection.Count = 0 Then
                    Continue For
                End If
                MyBlockOne = New BlockRefOne
                MyBlockOne.BlockObj = CurBlockRef
                MyBlockOne.BlockName = CurBlockRef.Name
                If CurBlockRef.Name.StartsWith("*") Then
                    MyBlockOne.BlockName = GlbData.GlbSrvArx.GetBlockRealName(CurBlockRef)
                End If
                MyBlockOne.FlagStaticKnum = False
                If Me.BlockList Is Nothing Then
                    Me.BlockList = New Collection
                End If
                Me.BlockList.Add(MyBlockOne)
            End If
        Next

        tr.Dispose()
        tm.Dispose()
        If BlockList Is Nothing Then
            Return (True)
        End If

        For ch = 1 To BlockList.Count
            MyBlockOne = Me.BlockList.Item(ch)
            MyBlockOne.LoadAttrib()

        Next ch

        Return (True)
    End Function

    Public Sub Clear()
        Dim ch As Integer

        If Me.BlockList Is Nothing Then
            Exit Sub
        End If

        For ch = Me.BlockList.Count To 1 Step -1
            Me.BlockList.Remove(ch)
        Next ch

        Me.BlockList = Nothing

        Me.BlockList = New Collection

    End Sub

    Private Function IsSmaller(ByVal KnumCur As String, ByVal KnumMin As String) As Boolean
        Dim NumPartcur, NumPartMin, ch As Integer
        Dim StrPartcur, StrPartMin As String
        For ch = 0 To KnumCur.Length - 1
            If Not IsNumeric(KnumCur.Chars(ch)) Then
                Exit For
            End If
        Next
        If ch = 0 Then
            NumPartcur = 1000
        Else
            NumPartcur = CInt(KnumCur.Substring(0, ch))
        End If

        StrPartcur = KnumCur.Substring(ch)

        For ch = 0 To KnumMin.Length - 1
            If Not IsNumeric(KnumMin.Chars(ch)) Then
                Exit For
            End If
        Next
        If ch = 0 Then
            NumPartMin = 1000
        Else
            NumPartMin = CInt(KnumMin.Substring(0, ch))
        End If

        StrPartMin = KnumMin.Substring(ch)

        If NumPartcur < NumPartMin Then
            Return True
        End If
       
        If NumPartcur = NumPartMin Then
            If StrPartcur = "" Then
                StrPartcur = "0"
            End If
            If StrPartMin = "" Then
                StrPartMin = "0"
            End If

            If Asc(StrPartcur) < Asc(StrPartMin) Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function GetMinKnum(ByVal Blist As List(Of BlockRefOne)) As BlockRefOne
        Dim CurAsc, MinAsc As Integer
        MinAsc = 999
        Dim MinAscBro As BlockRefOne
        Dim AtKnum, MinAtKnum As AttribTemplateOne
        MinAscBro = Nothing
        MinAtKnum = New AttribTemplateOne
        For Each bro As BlockRefOne In Blist
            AtKnum = Me.GetAttrOneByTag(bro, "KNUM")
            If AtKnum Is Nothing OrElse AtKnum.AttValue = "" Then
                Continue For
            End If

            If MinAscBro Is Nothing Then
                MinAscBro = bro
                MinAtKnum = AtKnum
                Continue For
            End If
            If Me.IsSmaller(AtKnum.AttValue, MinAtKnum.AttValue) Then
                MinAscBro = bro
                MinAtKnum = AtKnum
                Continue For
            End If

            
        Next
        Return MinAscBro
    End Function

    Public Sub SortByKNum()
        Dim TmpColl As New List(Of BlockRefOne)
        Dim sortedBlocks As New List(Of BlockRefOne)
        Dim MinBro As BlockRefOne
        TmpColl = GlbData.GlbSrvFunc.FillListFromDadsFuckingCollection(Me.BlockList)
        Dim sort As Boolean = True
        While sort
            MinBro = Me.GetMinKnum(TmpColl)
            If MinBro Is Nothing Then
                sort = False
                Exit While
            End If
            TmpColl.Remove(MinBro)
            sortedBlocks.Add(MinBro)
        End While
        sortedBlocks.AddRange(TmpColl.ToArray())
        Me.BlockList.Clear()
        For ch As Integer = 0 To sortedBlocks.Count - 1
            Me.BlockList.Add(sortedBlocks.Item(ch))
        Next
    End Sub

    Public Sub Clear_KNUM()
        Dim ch As Integer
        Dim CurBlock As BlockRefOne
        Dim CurAttrList As AttribTemplateAll
        Dim CurAttribOne As AttribTemplateOne

        If Me.BlockList Is Nothing Then
            Exit Sub
        End If

        For ch = 1 To Me.BlockList.Count
            CurBlock = Me.BlockList.Item(ch)
            CurAttrList = CurBlock.BlockAttrib
            CurAttribOne = CurAttrList.GetAttrByTag("KNUM")
            If CurAttribOne Is Nothing OrElse CurAttribOne.AttValue = "" Then
                Continue For
            End If
            If Not IsNumeric(CurAttribOne.AttValue.Chars(0)) Then
                CurBlock.FlagStaticKnum = True
                Continue For
            End If

            CurAttribOne.AttValue = ""

        Next ch
    End Sub

    Public Function GetAttrOneByTag(ByRef CurBlock As BlockRefOne, ByVal AttrTag As String) As AttribTemplateOne
        Dim FoundAttrib As AttribTemplateOne = Nothing
        Dim CurAttrList As AttribTemplateAll

        CurAttrList = CurBlock.BlockAttrib
        If CurAttrList Is Nothing Then
            Return (FoundAttrib)
        End If

        FoundAttrib = CurAttrList.GetAttrByTag(AttrTag) '("KNUM")

        Return (FoundAttrib)
    End Function

    Public Function GetBlockByName(ByVal Bname As String, ByVal num As Integer) As BlockRefOne
        Dim grpnum As Integer
        Dim grpName As String = ""
        Dim IsPar As Boolean
        For Each blk As BlockRefOne In Me.BlockList
            If blk.BlockName = Bname AndAlso blk.IsGrpMember(grpnum, grpName, IsPar) AndAlso grpnum = num Then

                Return blk

            End If
        Next
        Return Nothing
    End Function

    Public Sub SetPrevKnum(ByRef ProgBar As System.Windows.Forms.ProgressBar)
        Dim ch As Integer
        Dim ch1 As Integer
        Dim CurNumb As Integer = 1
        Dim CurNewBlockNumb = Me.GetBiggestKnum()
        Dim PosN As Integer
        Dim CurNumStr As String
        Dim CurBlock As BlockRefOne
        Dim CurAttribOne As AttribTemplateOne
        ' Progress bar settings
        Dim PrgCount As Integer = 20
        Dim PrgStep As Double = PrgCount / Me.BlockList.Count

        If Me.BlockList Is Nothing Then
            Exit Sub
        End If
        Dim TmpList As New List(Of BlockRefOne)
        Dim SameBlockList As New List(Of BlockRefOne)

        For ch = 1 To Me.BlockList.Count
            ProgBar.Value = Math.Floor(ProgBar.Value + PrgStep)
            ProgBar.Update()
            CurBlock = Me.BlockList.Item(ch)
            If SameBlockList.Contains(CurBlock) Then
                Continue For
            End If
            CurAttribOne = Me.GetAttrOneByTag(CurBlock, "KNUM")
            If CurAttribOne Is Nothing Then
                Continue For
            End If
            'Prepare next number for numbering
            Dim gNum As Integer
            Dim GPName As String = ""
            Dim isPar As Boolean

            If CurAttribOne.AttValue = "" And CurBlock.IsGrpMember(gNum, GPName, isPar) = False Then ' This is a new block ' SZ 04/2012
                CurNumb = CurNewBlockNumb
                CurNewBlockNumb += 1
            Else
                CurNumb = GlbData.GlbSrvFunc.GetUnSignedIntFmStr(CurAttribOne.AttValue)
            End If

            If CurNumb < 0 Then
                Continue For
            End If

            If CurBlock.FlagStaticKnum = True Then
                Continue For
            End If

            CurNumStr = CStr(CurNumb)
            PosN = Len(CurNumStr)
            'For ch1 = PosN To 2
            '    CurNumStr = "0" & CurNumStr
            'Next ch1

            'Find Same Blocks And Set CurNumStr 
            TmpList = FindSameBlockAndSetKnum(CurBlock.BlockName, CurNumStr)
            SameBlockList.AddRange(TmpList)
            'CurNumb += 1
        Next ch

    End Sub

    Private Function FindSameBlockAndSetKnum(ByVal BlockName As String, ByVal CurNumStr As String) As List(Of BlockRefOne)
        Dim ch As Integer
        Dim CurBlock As BlockRefOne = Nothing
        Dim CurAttribOne As New AttribTemplateOne
        Dim SameBlocks As New List(Of BlockRefOne)

        For ch = 1 To Me.BlockList.Count
            CurBlock = Me.BlockList.Item(ch)
            If CurBlock.BlockName = BlockName Then
                'CurAttrList = CurBlock.BlockAttrib
                CurAttribOne = CurBlock.GetBlkAttrByTag("KNUM")
                If CurAttribOne Is Nothing Then
                    Continue For
                End If
                'If Knum contains Letters - don't ruin it , keep the letter.
                If IsNumeric(CurAttribOne.AttValue) = False And CurAttribOne.AttValue <> "" Then 'SZ
                    SameBlocks.Add(CurBlock)
                    Continue For
                End If
                CurAttribOne.AttValue = CurNumStr
                SameBlocks.Add(CurBlock)
            End If
        Next ch
        Return SameBlocks

    End Function

    Public Sub ResetFlagUsed()
        Dim ch As Integer
        Dim CurBlock As BlockRefOne
        For ch = 1 To Me.BlockList.Count
            CurBlock = Me.BlockList.Item(ch)
            If CurBlock.FlagStaticKnum = True Then
                CurBlock.FlagUsed = True
                Continue For
            End If
            CurBlock.FlagUsed = False
        Next ch
    End Sub

    ''' <summary>
    ''' Set final Knum according to Group relevance and/or same type variance (add letters)
    ''' (SZ) 07/2011 fix due to letter bug
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetResultKnum2(ByRef ProgBar As System.Windows.Forms.ProgressBar)
        Dim ch As Integer
        Dim IndxLettr As Integer
        Dim CurKnum, CurNewKnum As String
        Dim CurBlock As BlockRefOne
        Dim BCount As Integer = 0
        Dim grpnum As Integer = 0
        Dim grpName As String = ""
        Dim IsPar As Boolean = False
        Dim ChangedBlocks As New List(Of BlockRefOne)

        'Progress Bar Settings
        Dim PrgCount As Integer = 10
        Dim PrgStep As Double = PrgCount / Me.BlockList.Count

        For ch = 1 To Me.BlockList.Count
            ProgBar.Value = Math.Floor(ProgBar.Value + PrgStep)
            ProgBar.Update()
            CurBlock = Me.BlockList.Item(ch)
            ' Dump all used blocks
            If CurBlock.FlagUsed = True Then
                Continue For
            End If

            ' Dump "Special" blocks (Knum contains 3 signs and starts with a letter)
            Dim kNumAtt As AttribTemplateOne = Me.GetAttrOneByTag(CurBlock, "KNUM")
            If kNumAtt Is Nothing Then
                Continue For
            End If
            If kNumAtt.AttValue <> "" AndAlso kNumAtt.AttValue.Length = 3 _
               AndAlso Not IsNumeric(kNumAtt.AttValue(0)) Then
                CurBlock.FlagUsed = True
                ' Reset "Changed" flag
                Dim ChgVal As String = GlbSrvArx.GetBrAttVal(CurBlock.BlockObj, "AppFlgChg")
                If ChgVal IsNot Nothing Then
                    If ChgVal = "1" Then
                        GlbSrvArx.SetBrAttVal(CurBlock.BlockObj, "0", "AppFlgChg")
                    End If
                End If
                Continue For
            End If

            ' Clear "Son's" KNUM 
            If CurBlock.IsGrpMember(grpnum, grpName, IsPar) Then
                If Not IsPar And grpnum > 0 Then
                    Dim CurAttrOne As AttribTemplateOne
                    CurAttrOne = Me.GetAttrOneByTag(CurBlock, "KNUM")
                    CurAttrOne.AttValue = ""
                    Continue For
                End If
            End If

            ' Filter changed blocks
            Dim Val As String = GlbSrvArx.GetBrAttVal(CurBlock.BlockObj, "AppFlgChg")
            If Val IsNot Nothing Then
                If Val = "1" Then
                    ChangedBlocks.Add(CurBlock)
                    CurBlock.FlagUsed = True
                    Continue For
                End If
            End If
        Next ch

        Dim SameNumList As New List(Of BlockRefOne)

      
        ' set KNums for changed blocks 
        For Each ChgBro As BlockRefOne In ChangedBlocks 'ChgBro = Changed Blocks
            ' get all possible blocks with current knum (as number)
            SameNumList = GetUnchangedBlockListByName(ChgBro.BlockName) 'List of blocks who has the same name (except changed blocks)
            Dim TmpAttr1 As New AttribTemplateOne
            Dim TmpAttr2 As New AttribTemplateOne
            Dim TmpAttr3 As New AttribTemplateOne
            Dim FoundFlg As Boolean = False
            For Each blk As BlockRefOne In SameNumList
                'if any of the blocks is simmilar to the changed one - set the changed to be it!
                If Me.CompareTwoBlocks(ChgBro, blk) = True Then
                    FoundFlg = True
                    ' get blk Knum
                    TmpAttr1 = blk.GetBlkAttrByTag("KNUM")
                    CurKnum = TmpAttr1.AttValue
                    TmpAttr1 = Nothing ' Clean Att
                    ' set ChgBro Knum 
                    TmpAttr2 = ChgBro.GetBlkAttrByTag("KNUM")
                    TmpAttr2.AttValue = CurKnum
                    ' reset "changed" attribute
                    Dim chgAttr As New AttribTemplateOne()
                    chgAttr.Tag = "AppFlgChg"
                    chgAttr.AttValue = "0"
                    GlbSrvArx.SetBrAttVal(ChgBro.BlockObj, "0", "AppFlgChg")
                End If
            Next
            

            ' if no simmilar blocks were found - set new knum with letter
            If FoundFlg <> True And SameNumList.Count > 0 Then
                TmpAttr3 = ChgBro.GetBlkAttrByTag("KNUM")
                CurKnum = TmpAttr3.AttValue
                ' Don't change KNUM if ChgBro is the only one.
                Dim SameKnumColl As New Collection
                SameKnumColl = Me.GetListSameKnum(CurKnum)
                If SameKnumColl.Count = 1 Then
                    ChgBro.FlagUsed = True
                    GlbSrvArx.SetBrAttVal(ChgBro.BlockObj, "0", "AppFlgChg")
                    Continue For
                End If

                IndxLettr = GetMaxBlockLetter(CurKnum) + 1
                ' Get only the number
                Dim KnumTmp As Integer = CInt(GlbData.GlbSrvFunc.GetUnSignedIntFmStr(CurKnum))
                CurNewKnum = KnumTmp & Chr(IndxLettr) ' set number and letter
                TmpAttr3.AttValue = CurNewKnum
                ChgBro.FlagUsed = True
                GlbSrvArx.SetBrAttVal(ChgBro.BlockObj, "0", "AppFlgChg")
            Else
                ChgBro.FlagUsed = True
                GlbSrvArx.SetBrAttVal(ChgBro.BlockObj, "0", "AppFlgChg")
            End If
        Next

        ' Set quantity for all blocks
        Dim SameList As Collection
        Me.ResetFlagUsed() ' Reset FlagUsed

        ' set quantity according to same KNUM
        Dim tmpKNumAttr, CurQntAttr As AttribTemplateOne
        Dim blocktmp As BlockRefOne
        Dim TotQnt As Integer = 0 ' Total Block Quantity per KNUM

        ' Reset Progress bar
        PrgCount = 50
        PrgStep = PrgCount / Me.BlockList.Count

        For Each Bro As BlockRefOne In Me.BlockList
            ProgBar.Value = Math.Floor(ProgBar.Value + PrgStep)
            ProgBar.Update()
            If Bro.FlagUsed = True Then
                Continue For
            End If

            Bro.FlagUsed = True
            ' get same knum list and set quantity to each block
            tmpKNumAttr = Bro.GetBlkAttrByTag("KNUM")
            If tmpKNumAttr IsNot Nothing AndAlso tmpKNumAttr.AttValue <> "" Then
                SameList = GetListSameKnum(tmpKNumAttr.AttValue)
                TotQnt = SameList.Count ' total block quantity for current block
                For ch1 As Integer = 1 To SameList.Count
                    blocktmp = SameList.Item(ch1)
                    blocktmp.FlagUsed = True
                    CurQntAttr = blocktmp.GetBlkAttrByTag("KQNT")
                    If CurQntAttr Is Nothing Then
                        blocktmp.FlagUsed = True
                        Continue For
                    End If
                    CurQntAttr.AttValue = TotQnt
                    GlbData.GlbSrvArx.SetBrAttVal(blocktmp.BlockObj, TotQnt, "KQNT")
                    Bro.FlagUsed = True
                Next
                ' Set main block quantity
                CurQntAttr = Bro.GetBlkAttrByTag("KQNT")
                CurQntAttr.AttValue = TotQnt
                GlbData.GlbSrvArx.SetBrAttVal(Bro.BlockObj, TotQnt, "KQNT")
            Else
                Continue For
            End If
        Next
        Me.ResetFlagUsed() ' Reset FlagUsed
    End Sub

    Public Sub SetResultKnum()
        Dim ch As Integer
        Dim Res As Integer
        Dim IndxLast As Integer
        Dim ch1 As Integer
        Dim IndxLettr As Integer
        Dim RetValComp As Boolean
        Dim CurKnum, CurNewKnum As String
        Dim CurList As Collection
        Dim CurBlock As BlockRefOne
        Dim BlockTmp As BlockRefOne
        Dim CurBlockFm As BlockRefOne
        Dim CurAttrOne, TmpAttr As AttribTemplateOne
        Dim BCount As Integer = 0
        Dim grpnum As Integer = 0
        Dim grpName As String = ""
        Dim IsPar As Boolean = False
        Dim CurBroSet As List(Of BlockRefOne)
        Dim ChangedBlocks As New List(Of BlockRefOne)
        For ch = 1 To Me.BlockList.Count
            CurBlock = Me.BlockList.Item(ch)
            ' Dump all used blocks
            If CurBlock.FlagUsed = True Then
                Continue For
            End If

            'Get Knum
            CurAttrOne = Me.GetAttrOneByTag(CurBlock, "KNUM")
            If CurAttrOne Is Nothing OrElse CurAttrOne.AttValue = "" Then
                Continue For
            End If

            ' Get number from knum
            Dim CurNumb As Integer = GlbData.GlbSrvFunc.GetUnSignedIntFmStr(CurAttrOne.AttValue)
            If CurNumb < 0 Then
                Continue For
            End If

            If CurBlock.IsGrpMember(grpnum, grpName, IsPar) Then
                If Not IsPar And grpnum > 0 Then
                    CurAttrOne.AttValue = ""
                    Continue For
                End If
            End If
            'Fill List of Same KNUM (including letter)
            CurList = Me.GetListSameKnum(CurAttrOne.AttValue)
            If CurList Is Nothing Then
                Continue For
            End If

            'Compare Current List Elements 
            IndxLettr = 0
            ' Set correct index letter according to the highest available
            IndxLettr = GetMaxBlockLetter(CurAttrOne.AttValue) + 1
            Res = 1
            Do While Res > 0
                CurBlockFm = Nothing
                'Find First Not Used 
                CurBlockFm = GetFistNotUsedBlock(CurList, IndxLast)
                If CurBlockFm Is Nothing Then
                    Res = 0
                    Continue Do
                End If

                CurBlockFm.FlagUsed = True
                CurAttrOne = CurBlockFm.GetBlkAttrByTag("KNUM")
                CurKnum = CurAttrOne.AttValue

                CurBroSet = New List(Of BlockRefOne)

                'Check CurBlockFm with Others
                For ch1 = IndxLast + 1 To CurList.Count
                    BlockTmp = CurList.Item(ch1)
                    If BlockTmp.FlagUsed = True Then
                        Continue For
                    End If

                    RetValComp = Me.CompareTwoBlocks(CurBlockFm, BlockTmp)
                    If RetValComp = True Then
                        RetValComp = Me.CompareTwoParentBlocks(CurBlockFm, BlockTmp)
                    End If

                    'If same - mark as used and add quantity
                    If RetValComp = True Then
                        BlockTmp.FlagUsed = True
                        TmpAttr = BlockTmp.GetBlkAttrByTag("KNUM")
                        If TmpAttr Is Nothing Then
                            Continue For
                        End If
                        TmpAttr.AttValue = CurKnum
                        BCount += 1
                        CurBroSet.Add(BlockTmp)
                    Else
                        ' Filter changed blocks
                        Dim Val As String = GlbSrvArx.GetBrAttVal(BlockTmp.BlockObj, "AppFlgChg")
                        If Val IsNot Nothing Then
                            If Val = "1" Then
                                ChangedBlocks.Add(BlockTmp) ' Add block to changed blocks
                                BlockTmp.FlagUsed = True
                                Continue For
                            End If
                        End If

                        'ChangedBlocks.Add(BlockTmp)
                        'BlockTmp.FlagUsed = True
                    End If
                Next ch1

                ' Set quantity according to found similar blocks
                For Each b As BlockRefOne In CurBroSet
                    CurAttrOne = b.GetBlkAttrByTag("KQNT")
                    If CurAttrOne Is Nothing Then
                        Continue For
                    End If
                    CurAttrOne.AttValue = BCount
                    GlbData.GlbSrvArx.SetBrAttVal(b.BlockObj, BCount, "KQNT")
                Next
                'IndxLettr += 1
            Loop

        Next ch

        Dim TmpList As New List(Of BlockRefOne)
        ' reset flagUsed in ChanedBlocks list
        For Each b As BlockRefOne In ChangedBlocks
            b.FlagUsed = False
        Next
        ' set KNums for changed blocks
        For Each Bro As BlockRefOne In ChangedBlocks
            ' get all possible blocks with current knum (as number)
            TmpList = GetUnchangedBlockListByName(Bro.BlockName)
            Dim FoundFlg As Boolean = False
            For Each blk As BlockRefOne In TmpList
                'if any of the blocks is simmilar to the changed one - set the changed to be it!
                If Me.CompareTwoBlocks(Bro, blk) = True Then
                    FoundFlg = True
                    ' get blk Knum
                    TmpAttr = blk.GetBlkAttrByTag("KNUM")
                    CurKnum = TmpAttr.AttValue
                    'set Bro Knum 
                    TmpAttr = Bro.GetBlkAttrByTag("KNUM")
                    TmpAttr.AttValue = CurKnum
                    'Exit For
                End If
            Next
            ' if no simmilar blocks were found - set new knum with letter
            If FoundFlg <> True Then
                TmpAttr = Bro.GetBlkAttrByTag("KNUM")
                CurKnum = TmpAttr.AttValue
                ' Get only the number
                Dim KnumTmp As Integer = CInt(GlbData.GlbSrvFunc.GetUnSignedIntFmStr(CurKnum))
                CurNewKnum = KnumTmp & Chr(IndxLettr) ' set number and letter
                TmpAttr = Bro.GetBlkAttrByTag("KNUM")
                TmpAttr.AttValue = CurNewKnum
                GlbData.GlbSrvArx.SetBrAttVal(Bro.BlockObj, "0", "AppFlgChg")
                Bro.FlagUsed = True
            End If

        Next

    End Sub

    Private Function GetListSameKnum(ByVal KNumName As String) As Collection
        Dim ch As Integer
        Dim CurBlock As BlockRefOne
        Dim CurAttrOne As AttribTemplateOne
        Dim CurList As Collection = Nothing
        Dim grpnum As Integer = 0
        Dim grpName As String = ""
        Dim IsPar As Boolean = False

        If Me.BlockList Is Nothing Then
            Return (CurList)
        End If

        CurList = New Collection
        For ch = 1 To Me.BlockList.Count
            CurBlock = Me.BlockList.Item(ch)
            CurAttrOne = Me.GetAttrOneByTag(CurBlock, "KNUM")
            If CurAttrOne Is Nothing Then
                Continue For
            End If
            If CurBlock.IsGrpMember(grpnum, grpName, IsPar) AndAlso Not IsPar Then
                Continue For
            End If

            If CurAttrOne.AttValue = KNumName Then
                CurList.Add(CurBlock)
            End If
        Next ch

        Return (CurList)
    End Function

    ''' <summary>
    ''' Get max letter index (ascii) for any given knum
    ''' </summary>
    ''' <param name="KnumName">Any Knum (with or without letter)</param>
    ''' <returns>Ascii index of max used letter (EX. 26 for 'A' or 27 for 'b' )</returns>
    ''' <remarks></remarks>
    Private Function GetMaxBlockLetter(ByVal KnumName As String) As Integer
        Dim retLtrIdx As Integer = 0
        Dim curLtr As Char = Chr(64) ' Ascii code of '@' - one befor 'A' (=65)
        Dim tmpChr As Char = ""
        Dim ato As AttribTemplateOne
        Dim KnumTmp, curBNum As Integer
        Dim CurKNum As String = ""
        KnumTmp = CInt(GlbData.GlbSrvFunc.GetUnSignedIntFmStr(KnumName))
        For Each bro As BlockRefOne In Me.BlockList
            ato = Me.GetAttrOneByTag(bro, "KNUM")
            If ato Is Nothing OrElse ato.AttValue = "" Then
                Continue For
            End If
            curBNum = CInt(GlbData.GlbSrvFunc.GetUnSignedIntFmStr(ato.AttValue)) ' Current block number (without the letter)
            CurKNum = ato.AttValue
            If (curBNum = KnumTmp) Then
                ' Check wether a letter exists
                If IsNumeric(CurKNum(CurKNum.Length - 1)) = True Then  ' if knum doesn't contain any letters - move on
                    Continue For
                End If
                ' Get letter
                tmpChr = CurKNum(CurKNum.Length - 1)
                ' Compare with curLtr
                If Asc(tmpChr) > Asc(curLtr) Then
                    curLtr = tmpChr
                End If
            End If
        Next
        ' Return Ascii index (if letters found) or 0 otherwise
        retLtrIdx = Asc(curLtr)
        Return retLtrIdx
   
    End Function

    Public Function GetBlkByKnum(ByVal KNumName As String, ByRef IsParent As Boolean) As BlockRefOne
        Dim ch As Integer
        Dim CurBlock As BlockRefOne = Nothing
        Dim CurAttrOne As AttribTemplateOne
        Dim grpnum As Integer = 0
        Dim grpName As String = ""
        Dim IsPar As Boolean = False

        If Me.BlockList Is Nothing Then
            Return (CurBlock)
        End If


        For ch = 1 To Me.BlockList.Count
            CurBlock = Me.BlockList.Item(ch)
            CurAttrOne = Me.GetAttrOneByTag(CurBlock, "KNUM")
            If CurAttrOne Is Nothing Then
                Continue For
            End If

            If CurBlock.IsGrpMember(grpnum, grpName, IsPar) AndAlso Not IsPar Then
                Continue For
            End If

            If CurAttrOne.AttValue = KNumName Then
                IsParent = IsPar
                Return CurBlock
            End If
        Next ch

        Return (Nothing)
    End Function

    'Compare Current List Elements 
    Private Function CompareTwoBlocks(ByVal BlockFm As BlockRefOne, ByVal BlockTo As BlockRefOne) As Boolean
        Dim RetValBool As Boolean = False
        Dim ch As Integer
        Dim AttrFm As AttribTemplateAll
        Dim AttrTo As AttribTemplateAll
        Dim AttrOneFm As AttribTemplateOne
        Dim AttrOneTo As AttribTemplateOne

        AttrFm = BlockFm.BlockAttrib()
        AttrTo = BlockTo.BlockAttrib()

        If AttrFm.AttrList.Count <> AttrTo.AttrList.Count Then
            Return (RetValBool)
        End If

        For ch = 1 To AttrFm.AttrList.Count

            AttrOneFm = AttrFm.AttrList.Item(ch)
            AttrOneTo = AttrTo.AttrList.Item(ch)
            If AttrOneFm.Tag = "KQNT" OrElse AttrOneFm.Tag.StartsWith("AppGrp") OrElse AttrOneFm.Tag = "KNUM" Then
                Continue For
            End If
            If AttrOneFm.AttValue <> AttrOneTo.AttValue Then
                Return (RetValBool)
            End If
        Next ch

        RetValBool = True

        Return (RetValBool)

    End Function

    Private Function CompareTwoParentBlocks(ByVal BlockFm As BlockRefOne, ByVal BlockTo As BlockRefOne) As Boolean
        Dim grpnumFm As Integer = 0
        Dim grpNameFm As String = ""
        Dim IsParFm As Boolean = False
        Dim grpnumTo As Integer = 0
        Dim grpNameTo As String = ""
        Dim IsParTo As Boolean = False
        Dim GrpFm, GrpTo As Group


        If Not BlockFm.IsGrpMember(grpnumFm, grpNameFm, IsParFm) = _
                    BlockTo.IsGrpMember(grpnumTo, grpNameTo, IsParTo) Then
            Return False
        End If



        If grpnumTo = grpnumFm Then
            Return True
        End If
        GrpFm = GlbData.GlbSrvFunc.GetorSetGroupByNum(grpnumFm, False)
        GrpTo = GlbData.GlbSrvFunc.GetorSetGroupByNum(grpnumTo, False)
        If GrpFm.BlockList.Count <> GrpTo.BlockList.Count Then
            Return False
        End If

        For Each bro As BlockRefOne In GrpFm.BlockList
            If Not GrpTo.ContainBlock(bro.BlockName) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function GetFistNotUsedBlock(ByRef CurList As Collection, ByRef IndxLast As Integer) As BlockRefOne
        Dim FoundBlock As BlockRefOne = Nothing
        Dim CurBlock As BlockRefOne
        Dim ch As Integer

        For ch = 1 To CurList.Count
            CurBlock = CurList.Item(ch)
            If CurBlock.FlagUsed = False Then
                FoundBlock = CurBlock
                IndxLast = ch
                Exit For
            End If
        Next ch

        Return (FoundBlock)
    End Function

    Private Function GetUnchangedBlockListByName(ByVal BlkName As String) As List(Of BlockRefOne)
        Dim RetList As New List(Of BlockRefOne)
        For Each bro As BlockRefOne In Me.BlockList
            If bro.BlockName = BlkName Then
                Dim Val As String = GlbSrvArx.GetBrAttVal(bro.BlockObj, "AppFlgChg")
                If Val Is Nothing OrElse Val = 0 Then
                    RetList.Add(bro)
                End If
            End If
        Next
        Return RetList
    End Function

    Public Sub UpdateKnumInAcad(ByRef ProgBar As System.Windows.Forms.ProgressBar)
        Dim RetValBool As Boolean
        Dim CurBlock As BlockRefOne
        Dim CurAttrOne As AttribTemplateOne
        Dim ch As Integer

        ' Progress bar settings
        Dim PrgCount As Integer = 5
        Dim PrgStep As Double = PrgCount / Me.BlockList.Count

        If Me.BlockList Is Nothing Then
            Exit Sub
        End If

        For ch = 1 To Me.BlockList.Count
            ProgBar.Value = Math.Floor(ProgBar.Value + PrgStep)
            ProgBar.Update()
            CurBlock = Me.BlockList.Item(ch)
            CurAttrOne = Me.GetAttrOneByTag(CurBlock, "KNUM")
            If CurAttrOne Is Nothing Then
                Continue For
            End If
            RetValBool = GlbData.GlbSrvArx.SetBrAttVal(CurBlock.BlockObj, CurAttrOne.AttValue, "KNUM")
        Next ch

    End Sub

    Public Function GetListKnumForCombo() As ArrayList
        Dim ch As Integer
        Dim RetValInt As Integer
        Dim ItemList As New ArrayList()
        Dim CurBlock As BlockRefOne
        Dim CurAttrOne As AttribTemplateOne

        For ch = 1 To Me.BlockList.Count
            CurBlock = Me.BlockList.Item(ch)
            CurAttrOne = CurBlock.GetBlkAttrByTag("KNUM")
            If CurAttrOne Is Nothing Then
                Continue For
            End If
            RetValInt = ItemList.IndexOf(CurAttrOne.AttValue)
            If RetValInt < 0 Then
                ItemList.Add(CurAttrOne.AttValue)
            End If
        Next ch

        ItemList.Sort()
        Return (ItemList)
    End Function

    Public Function GetBiggestKnum() As Integer
        Dim ato As AttribTemplateOne
        Dim KnumTmp, curLast As Integer
        curLast = 0
        For Each bro As BlockRefOne In Me.BlockList
            ato = Me.GetAttrOneByTag(bro, "KNUM")
            If ato Is Nothing OrElse ato.AttValue = "" Then
                Continue For
            End If
            KnumTmp = CInt(GlbData.GlbSrvFunc.GetUnSignedIntFmStr(ato.AttValue))
            If KnumTmp > curLast Then
                curLast = KnumTmp
            End If
        Next
        Return curLast + 1
    End Function
End Class

