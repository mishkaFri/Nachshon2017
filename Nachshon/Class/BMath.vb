Imports System.Math

Module BMath

    '     LIST FUNCTIONS:
    '   BMath_UnitVect                  -  Make Unit Vector
    '   BMath_UnitMatrx                 -  Initial Unit Matrix
    '   BMath_LenVect                   -  Get Lenght of Vector
    '   BMath_CrossVect                 -  Get Cross Vector
    '   BMath_VectByPnt                 -  Vector By Given 2 Points
    '   BMath_PntAddVect                -  Get New Point By Pnt & Vector
    '   BMath_PntMinusVect              -  Get New Point by Pnt - Vector
    '   BMath_CopyArrayDb2Db            -  Copy Double Array to Other One
    '   BMath_CopyArrayVr2Db            -  Copy Variant Array to Double Array
    '   BMath_CopyArrayDb2Vr            -  Copy Double Array to Variant Array
    '   BMath_CpArrDb2DbByIndx          -  Copy Double Arraies by Indexs
    '   BMath_Vdot                      -  Get Dot by 2 Vectors
    '   BMath_Dist3D                    -  Get Distance Between 2 Points
    '   BMath_Dist3DSqur                -  Get Distance Betw.2 Pnt in Square
    '   BMath_DistPntPlane              -  Get Distance Point to Plane
    '   BMath_VectScale                 -  Get Scale Vector
    '   BMath_DistPnt2Line              -  Get Distance From Point to Line
    '   BMath_GetMidPnt                 -  Get Mid Pnt By Given 2 Points
    '   BMath_AnglAbs                   -  Get Absolute Angle (0-360) by Vector
    '   BMath_IniBox                    -  Initial. of Ortogonal Box
    '   BMath_AddBox2Box                -  Add New Box to Existed Box
    '   BMath_AddPnt2Box                -  Add Point To Existed Box
    '   BMathMinDist2Box                -  Minimum Distance Between 2 Boxes
    '   MIntersecTwoLine                -  Get Intersect. Pnt By 2 Lines( 2D )
    '   MIntersecTwoLineFull            -  As before + Return Parameters
    '   MIntersecTwoLine3D              -  Get Intersect  Pnt By 2 Lines( 3D )
    '   MGetCntrArcBy3Pnt               -  Get Circle Center By Given 3 Points( 2D )
    '   BMath_CirclBy3Pnt               -  Get Circle Center By Given 3 Points( 3D )
    '   MArcCosAngle                    -  Get ArcCos(Alfa)
    '   MGetAngl2Vector                 -  Get Angle Between Two Given Vectors
    '   MPntIntersLinePlane             -  Get Intersection Pnt Between
    '                                                    Line & Plane
    '   MPntIntersLinePlaneFull         -  Get Inters. & Parameter Status Line 2 Pnt & Plane
    '   MProjectPntOnLine               -  Get Projection Point on Line
    '   MGetPlaneByPntAndVect           -  Get Plane By Vector & Point
    '                                      ( Vector is Normal to Plane )
    '   MGetPlaneBy3Pnt                 -  Create Plane Coefficients By Given 3 Points
    '   MGetPntSide2                    -  Get Side of Point By Given Line &
    '                                      Plane Normal
    '   MGetPntSide1                    -  Get Side of Point by Line ( cross
    '                                      Vector > 0  return = 1, opposite = -1
    '   MGetPntSide                     -  Get Side of Point by Line ( dot
    '                                      < 0 - return = 1, opposite = -1
    '   MMultVect3DByMatx               -  Multiply a 3D Vector by a 3*3 Matrix
    '   MTransportMatrx                 -  Transport Matrix 3*3
    '   MM3determ                       -  Calculate Matrix 3*3 ( Determinant )
    '   MTrroaxVct                      -  Get Transform Matrix for Rotation
    '                                      About Given Axis
    '   MPrjPnt2Pln                     -  Projection Point to Plane
    '   BMath_TransfMatxPlane2XY        -  Transform Free Plane To Parral XY
    '   BMath_ByTwoBoxGetCommonArea     -  Get Common Box For Two Given( 2d )
    '   BMath_SortArrDbl                -  Sorting Array Double
    '   BMath_BoxPrj2XY                 -  Ortogonal Box Proj to Plane And
    '                                      Convert To XY Plane And Get New
    '                                      Box
    '   BMath_MapPnt2Pln                -  Map Given Point to Given Plane
    '   BMath_MapPlnPnt2Model           -  Map Plane Pnt to Model 3D
    '   BMath_CheckPntOnPlane           -  Check Given Point Belongs to Plane
    '   BMath_CheckPntInTrg             -  Check Is Point into Triangl
    '   BMath_CheckPntInBox             -  Check Whether Point into Box
    '
    '   BMath_RotVctAbtAxis             -  Rotate Vector About Rotation Axis
    '   BMath_RotPntAbtAxis             -  Rotate Point  About Rotation Axis
    '   BMath_RotVect2DByAngl           -  Rotate Vector 2D by Given Angle
    '   BMath_2PntAnd3SlopeTwoArcs      -  Get Two Arcs By Given Two Point And 3 Slope
    '   BMath_ArcMidByCentStrtEnd       -  Get Middl Point On Arc by Center & Start & End
    '   BMath_ClosePntToLine            -  Close Point to Line
    '   BMath_OffsetLine1               -  Offset Line by Offset Value & Point direction
    '   BMath_IntersecTwoLine2D         -  Get Intersection Point of 2 Lines, Return Param
    '   BMath_ExtendLineBothSide        -  Extend Line to Both Sides by Given Delta
    '   BMAth_Angl2VectByRotat          -  Get Angle Between 2 Given Vectors By Rotat. Dir.
    '   BMath_PntOnLnByRad              -  Get Point on Line By Given Center & Radius
    '   BMath_PlaneTransf               -  Get Transf & PntRoot By Plane Coefficient


    Const TolEps = 0.0001
    Const TolInters = 0.000001
    Const TolEpsAngl = 0.000001
    Const PI = 3.14159265
    Const FLTMAX = 1000000

    ' + Make Unit Vector
    Public Sub BMath_UnitVect(ByVal ioVect() As Double)
        Dim Lent As Double
        'Get Length of Given vector
        Lent = BMath_LenVect(ioVect)
        If Lent > TolEps Then
            'calculate Unit Vector
            ioVect(0) = ioVect(0) / Lent
            ioVect(1) = ioVect(1) / Lent
            ioVect(2) = ioVect(2) / Lent
        End If
    End Sub
    ' +
    Public Function BMath_LenVect(ByVal iVect() As Double) As Double
        Dim Lent As Double
        Lent = iVect(0) * iVect(0) + _
               iVect(1) * iVect(1) + _
               iVect(2) * iVect(2)
        Lent = Sqrt(Lent)
        BMath_LenVect = Lent
    End Function
    ' + 
    Public Sub BMath_CrossVect(ByVal iVect1() As Double, _
    ByVal iVect2() As Double, _
    ByVal oVCros() As Double)
        oVCros(0) = iVect1(1) * iVect2(2) - _
                    iVect1(2) * iVect2(1)
        oVCros(1) = -(iVect1(0) * iVect2(2) - _
                      iVect1(2) * iVect2(0))
        oVCros(2) = iVect1(0) * iVect2(1) - _
                    iVect1(1) * iVect2(0)
    End Sub
    ' +
    Public Sub BMath_VectByPnt(ByVal iPnt1() As Double, _
    ByVal iPnt2() As Double, _
    ByVal oVect() As Double)

        oVect(0) = iPnt2(0) - iPnt1(0)
        oVect(1) = iPnt2(1) - iPnt1(1)
        oVect(2) = iPnt2(2) - iPnt1(2)
    End Sub

    ' + 
    Public Sub BMath_PntAddVect(ByVal iPnt1() As Double, _
    ByVal iVect1() As Double, _
    ByVal oVectAdd() As Double)
        oVectAdd(0) = iPnt1(0) + iVect1(0)
        oVectAdd(1) = iPnt1(1) + iVect1(1)
        oVectAdd(2) = iPnt1(2) + iVect1(2)

    End Sub

    ' + 
    Public Sub BMath_PntMinusVect(ByVal iPnt1() As Double, _
    ByVal iVect1() As Double, _
    ByVal oVectMinus() As Double)
        oVectMinus(0) = iPnt1(0) - iVect1(0)
        oVectMinus(1) = iPnt1(1) - iVect1(1)
        oVectMinus(2) = iPnt1(2) - iVect1(2)

    End Sub
    '+
    Public Sub BMath_CopyArrayDb2Db(ByVal iArrFrom() As Double, _
    ByVal oArrTo() As Double, _
    ByVal iNArr As Long)
        Dim i As Integer

        For i = 0 To iNArr - 1
            oArrTo(i) = iArrFrom(i)
        Next i
    End Sub
    ' + 
    Public Sub BMath_CpArrDb2DbByIndx(ByVal iArrFm() As Double, _
    ByVal iIdxFm As Long, _
    ByVal oArrTo() As Double, _
    ByVal iIdxTo As Long, _
    ByVal iNArr As Long)

        Dim ch As Integer

        For ch = 0 To iNArr - 1
            oArrTo(iIdxTo + ch) = iArrFm(iIdxFm + ch)
        Next ch

    End Sub

    Public Sub BMath_CopyArrayVr2Db(ByVal iArrFrom As Object, _
    ByVal oArrTo() As Double, _
    ByVal iNArr As Long)
        Dim i As Integer

        For i = 0 To iNArr - 1
            oArrTo(i) = iArrFrom(i)
        Next i
    End Sub
    Public Sub BMath_CopyArrayDb2Vr(ByVal iArrFrom() As Double, _
    ByVal oArrTo As Object, _
    ByVal iNArr As Long)
        Dim i As Integer
        For i = 0 To iNArr - 1
            oArrTo(i) = iArrFrom(i)
        Next i
    End Sub
    ' + 
    Public Function BMath_Vdot(ByVal iVect1() As Double, _
                               ByVal iVect2() As Double) As Double
        Dim Vdot As Double

        Vdot = iVect1(0) * iVect2(0) + _
               iVect1(1) * iVect2(1) + _
               iVect1(2) * iVect2(2)

        BMath_Vdot = Vdot
    End Function
    ' +   
    Public Function BMath_Dist3D(ByVal iPnt1() As Double, _
    ByVal iPnt2() As Double) As Double
        Dim VectTmp(2) As Double

        BMath_VectByPnt(iPnt1, iPnt2, VectTmp)
        BMath_Dist3D = BMath_LenVect(VectTmp)

    End Function

    ' +
    Public Function BMath_Dist2D(ByVal iPnt1() As Double, _
                                 ByVal iPnt2() As Double) As Double
        Dim dVectTmp(2) As Double
        Dim dLenVct As Double

        dVectTmp(0) = iPnt2(0) - iPnt1(0)
        dVectTmp(1) = iPnt2(1) - iPnt1(1)
        dVectTmp(2) = 0

        dLenVct = BMath_LenVect(dVectTmp)
        Return (dLenVct)

    End Function
    ' + 
    Public Sub BMath_VectScale(ByVal ioVect() As Double, _
    ByVal iVScl As Double)
        ioVect(0) = ioVect(0) * iVScl
        ioVect(1) = ioVect(1) * iVScl
        ioVect(2) = ioVect(2) * iVScl
    End Sub
    ' +
    '  Get Distance From Point to Line
    '  Return: Distance With Sing
    '
    '          + pnt
    '          |
    '          | +D
    ' PLin1 +-------> VectL
    '          |
    '          | -D
    '          + pnt
    '
    Public Function BMath_DistPnt2Line(ByVal iPnt() As Double, _
    ByVal iPLin1() As Double, _
    ByVal iVectL() As Double) As Double

        Dim VectAxis(2) As Double
        Dim VectP(2) As Double
        Dim VectC(2) As Double
        Dim VectY(2) As Double
        Dim VectD As Double

        BMath_VectByPnt(iPLin1, iPnt, VectP)
        BMath_CrossVect(iVectL, VectP, VectC)
        BMath_CrossVect(VectC, iVectL, VectY)
        BMath_UnitVect(VectY)
        VectD = BMath_Vdot(VectY, VectP)
        BMath_DistPnt2Line = VectD
    End Function

    ' + 
    'Calculate Middle Point Between Two Given Points

    Public Sub BMath_GetMidPnt(ByVal iPnt1() As Double, _
    ByVal iPnt2() As Double, _
    ByVal oPntMid() As Double)


        oPntMid(0) = (iPnt1(0) + iPnt2(0)) / 2
        oPntMid(1) = (iPnt1(1) + iPnt2(1)) / 2
        oPntMid(2) = (iPnt1(2) + iPnt2(2)) / 2

    End Sub
    ' +
    '          Y
    '           ^            Get Absolute Angle By
    '      iLenY|-- . 45     Given  It Projection
    '           |   |        on ->X  ->Y
    '   --------+-------->X
    '           |iLenx
    '   225 +   |   + 315
    '           |
    '
    Public Function BMath_AnglAbs(ByVal iLenX As Double, _
    ByVal iLenY As Double) As Double

        Dim VectPnt(2) As Double
        Dim Angl As Double
        Dim alfa As Double

        Angl = 0

        If Abs(iLenX) < TolEps Then
            If iLenY >= 0 Then
                Angl = PI / 2
            Else
                Angl = 3 * PI / 2
            End If
        Else
            alfa = iLenY / iLenX
            alfa = Atan(alfa)
            alfa = Abs(alfa)

            If iLenY >= 0 And iLenX >= 0 Then  ' 1-st qaudrant
                Angl = alfa
            ElseIf iLenY >= 0 And iLenX < 0 Then  '2-st qaudrant
                Angl = PI - alfa
            ElseIf iLenY < 0 And iLenX <= 0 Then '3-st qaudrant
                Angl = PI + alfa
            ElseIf iLenY < 0 And iLenX >= 0 Then '4-st qaudrant
                Angl = PI * 2 - alfa
            End If
        End If
        BMath_AnglAbs = Angl * 180 / PI

    End Function
    '  Get Intersection Point Between Two Lines
    ' Vct1      Vct2
    '   \       /
    '    \     /
    ' Pnt1+   +Pnt2
    '
    '       +PntInS
    '
    ' Only For 2D Event Return: False - Vectors Parall
    Public Function MIntersecTwoLine(ByVal iPnt1() As Double, _
    ByVal iVct1() As Double, _
    ByVal iPnt2() As Double, _
    ByVal iVct2() As Double, _
    ByVal oPntInS() As Double) _
                                            As Boolean
        Dim Delt As Double
        Dim DeltPar1 As Double
        Dim A, B, C, D, E, F As Double

        A = iVct1(0)
        B = iVct1(1)
        C = iVct2(0)
        D = iVct2(1)
        E = iPnt2(0) - iPnt1(0)
        F = iPnt2(1) - iPnt1(1)

        Delt = C * B - A * D
        If Abs(Delt) < TolEps Then
            MIntersecTwoLine = False
        Else
            DeltPar1 = C * F - D * E
            DeltPar1 = DeltPar1 / Delt
            oPntInS(0) = iPnt1(0) + iVct1(0) * DeltPar1
            oPntInS(1) = iPnt1(1) + iVct1(1) * DeltPar1
            MIntersecTwoLine = True
        End If

    End Function


    '  Get Intersection Point And Parameters Between Two Lines
    '  For Pnt1 & Vector Direction Vct1 And Line By Pnt2 & Pnt3
    '  Get Intesection Point And Parameters
    ' Vct1       + Pnt3
    '   \       /
    '    \     /
    ' Pnt1+   +Pnt2
    '
    '       +PntInS
    '
    ' Only For 2D Event Return: False - Vectors Parall
    Public Function MIntersecTwoLineFull(ByVal iPnt1() As Double, _
    ByVal iVct1() As Double, _
    ByVal iPnt2() As Double, _
    ByVal iPnt3() As Double, _
    ByVal oPntInS() As Double, _
    ByVal oParam1 As Double, _
    ByVal oParam2 As Double) _
                                            As Boolean
        Dim Delt As Double
        Dim DeltPar1 As Double
        Dim DeltPar2 As Double
        Dim A, B, C, D, E, F As Double

        A = iVct1(0)
        B = iVct1(1)
        C = iPnt3(0) - iPnt2(0)
        D = iPnt3(1) - iPnt2(1)
        E = iPnt2(0) - iPnt1(0)
        F = iPnt2(1) - iPnt1(1)

        Delt = C * B - A * D
        If Abs(Delt) < TolEps Then
            MIntersecTwoLineFull = False
        Else
            DeltPar1 = C * F - D * E
            DeltPar2 = A * F - B * E
            oParam1 = DeltPar1 / Delt
            oParam2 = DeltPar2 / Delt
            oPntInS(0) = iPnt1(0) + iVct1(0) * oParam1
            oPntInS(1) = iPnt1(1) + iVct1(1) * oParam1
            MIntersecTwoLineFull = True
        End If

    End Function

    '  Get Circle Center By Given 3 Points
    '  For 2D Case
    '         P2
    '      .  +  .
    'P1  .         .
    '   +            .
    '          +     .
    '        Pc      +P3
    '
    '
    Public Function MGetCntrArcBy3Pnt(ByVal iP1() As Double, _
    ByVal iP2() As Double, _
    ByVal iP3() As Double, _
    ByVal oPc() As Double) As Integer

        Dim Vct1(2) As Double
        Dim Vct2(2) As Double
        Dim Pnt1(2) As Double
        Dim Pnt2(2) As Double
        Dim ValTmp As Double
        Dim Respon As Boolean
        Dim LenTmp As Double

        BMath_VectByPnt(iP1, iP2, Vct1)
        BMath_VectByPnt(iP2, iP3, Vct2)

        LenTmp = BMath_LenVect(Vct1)
        If LenTmp < TolEps * 100 Then
            MGetCntrArcBy3Pnt = -1
            Exit Function
        End If

        LenTmp = BMath_LenVect(Vct2)
        If LenTmp < TolEps * 100 Then
            MGetCntrArcBy3Pnt = -1
            Exit Function
        End If

        ValTmp = Vct1(0)
        Vct1(0) = -Vct1(1)
        Vct1(1) = ValTmp

        ValTmp = Vct2(0)
        Vct2(0) = -Vct2(1)
        Vct2(1) = ValTmp

        Pnt1(0) = (iP1(0) + iP2(0)) / 2
        Pnt1(1) = (iP1(1) + iP2(1)) / 2

        Pnt2(0) = (iP2(0) + iP3(0)) / 2
        Pnt2(1) = (iP2(1) + iP3(1)) / 2

        Respon = MIntersecTwoLine(Pnt1, Vct1, Pnt2, Vct2, oPc)

        If Respon = False Then
            MGetCntrArcBy3Pnt = -1
        Else
            MGetCntrArcBy3Pnt = 1
        End If
    End Function


    ' + 
    '  Angle Between Two Given Vectors
    '        -
    '      / V1
    '     /
    '    /
    '   +  Algl ( Rad )
    '    \
    '     \  -
    '      \ V2

    Public Function MGetAngl2Vector(ByVal iVct1() As Double, _
    ByVal iVct2() As Double _
                                    ) As Double
        Dim Vect1(2) As Double
        Dim Vect2(2) As Double
        Dim CosAlf As Double
        Dim Denominat As Double
        Dim ArCosAlfa As Double

        BMath_CopyArrayDb2Db(iVct1, Vect1, 3)
        BMath_CopyArrayDb2Db(iVct2, Vect2, 3)
        BMath_UnitVect(Vect1)
        BMath_UnitVect(Vect2)

        CosAlf = BMath_Vdot(Vect1, Vect2)
        Denominat = -CosAlf * CosAlf + 1
        If Abs(Denominat) < TolEpsAngl Then
            Denominat = TolEpsAngl
        Else
            Denominat = Sqrt(Denominat)
        End If

        ArCosAlfa = Atan(-CosAlf / Denominat) + 2 * Atan(1)
        MGetAngl2Vector = ArCosAlfa
    End Function

    'Get ArcCos for Given Cos(a)
    'Return in Degree
    Public Function MArcCosAngle(ByVal iCosAlfa) As Double
        Dim Denominat As Double
        Dim oAng As Double

        Denominat = -iCosAlfa * iCosAlfa + 1
        If Abs(Denominat) < TolEpsAngl Then
            Denominat = TolEpsAngl
        Else
            Denominat = Sqrt(Denominat)
        End If

        oAng = Atan(-iCosAlfa / Denominat) + 2 * Atan(1)
        oAng = oAng * 180 / PI

        MArcCosAngle = oAng
    End Function


    '  Get Intersection Point Between Line & Plane
    '        +
    ' iPLn   |\oPnt
    '  +------+\----> iVLn
    '        |  \
    '        +   +
    '         \ .|--- A,B,C,D - Coeff. Plane
    '          \ |    iPCof() - 4 Coeff.
    '           \|
    '            +
    Public Function MPntIntersLinePlane( _
    ByVal iPln() As Double, _
    ByVal iVln() As Double, _
    ByVal iPCof() As Double, _
    ByVal oPnt() As Double) As Integer

        Dim Param As Double
        Dim Numerat As Double
        Dim Denominat As Double

        Numerat = iPCof(0) * iPln(0) + _
                  iPCof(1) * iPln(1) + _
                  iPCof(2) * iPln(2) + iPCof(3)

        Denominat = iPCof(0) * iVln(0) + _
                    iPCof(1) * iVln(1) + _
                    iPCof(2) * iVln(2)
        If Abs(Denominat) < TolEps Then
            BMath_CopyArrayDb2Db(iPln, oPnt, 3)
            MPntIntersLinePlane = 0
        Else
            Param = -(Numerat / Denominat)
            oPnt(0) = iPln(0) + iVln(0) * Param
            oPnt(1) = iPln(1) + iVln(1) * Param
            oPnt(2) = iPln(2) + iVln(2) * Param
            MPntIntersLinePlane = 1
        End If
    End Function


    '  Get Intersection Point Between Line & Plane Full Version
    '        +
    ' iP1   |\oPnt  iP2
    '  +------+\----+
    '        |  \
    '        +   +
    '         \ .|--- A,B,C,D - Coeff. Plane
    '          \ |    iPCof() - 4 Coeff.
    '           \|
    '            +
    ' Return: 0 - There is not Intersection
    '         1 - Intersection Into Line
    '         2 - Intersection Before Line Start  ( - )
    '         3 - Intersection On Extension Line
    Public Function MPntIntersLinePlaneFull( _
    ByVal iP1() As Double, _
    ByVal iP2() As Double, _
    ByVal iPCof() As Double, _
    ByVal oPnt() As Double, _
    ByVal oParam As Double) As Integer

        Dim Numerat As Double
        Dim Denominat As Double
        Dim dVln(2) As Double

        BMath_VectByPnt(iP1, iP2, dVln)


        Numerat = iPCof(0) * iP1(0) + _
                  iPCof(1) * iP1(1) + _
                  iPCof(2) * iP1(2) + iPCof(3)

        Denominat = iPCof(0) * dVln(0) + _
                    iPCof(1) * dVln(1) + _
                    iPCof(2) * dVln(2)
        If Abs(Denominat) < TolEps Then
            BMath_CopyArrayDb2Db(iP1, oPnt, 3)
            oParam = 0
            MPntIntersLinePlaneFull = 0
        Else
            oParam = -(Numerat / Denominat)
            oPnt(0) = iP1(0) + dVln(0) * oParam
            oPnt(1) = iP1(1) + dVln(1) * oParam
            oPnt(2) = iP1(2) + dVln(2) * oParam
            If oParam + 0.0001 < 0 Then
                MPntIntersLinePlaneFull = 2
            ElseIf oParam > 1.0001 Then
                MPntIntersLinePlaneFull = 3
            Else
                MPntIntersLinePlaneFull = 1
            End If
        End If
    End Function


    'Create Plane Coefficients By Given 3 Points
    Public Function MGetPlaneBy3Pnt( _
    ByVal iPnt1() As Double, _
    ByVal iPnt2() As Double, _
    ByVal iPnt3() As Double, _
    ByVal oPCof() As Double) As Boolean
        Dim dVctTmp1(2) As Double
        Dim dVctTmp2(2) As Double
        Dim dVctCros(2) As Double
        Dim dLenVct As Double

        MGetPlaneBy3Pnt = False

        BMath_VectByPnt(iPnt1, iPnt2, dVctTmp1)
        BMath_UnitVect(dVctTmp1)
        BMath_VectByPnt(iPnt1, iPnt3, dVctTmp2)
        BMath_UnitVect(dVctTmp2)

        BMath_CrossVect(dVctTmp1, dVctTmp2, dVctCros)
        BMath_UnitVect(dVctCros)

        'Check whether Vector Norm is Not 0
        dLenVct = BMath_LenVect(dVctCros)
        If dLenVct < TolEps Then
            Exit Function
        End If

        MGetPlaneByPntAndVect(iPnt1, dVctCros, oPCof)

        MGetPlaneBy3Pnt = True
    End Function


    '  By Given Vector & Point Get Coeff. of Plane
    '  that Perpendicular To Given Vector
    '        +iPnt
    '        |\
    '        | \----> iVct
    '        |  \
    '        +   +
    '         \  |-- A,B,C,D - Coeff. Plane
    '          \ |    oPCof() - 4 Coeff.
    '           \|
    '            +
    '
    Public Sub MGetPlaneByPntAndVect( _
    ByVal iPnt() As Double, _
    ByVal iVct() As Double, _
    ByVal oPCof() As Double)
        BMath_CopyArrayDb2Db(iVct, oPCof, 3)
        BMath_UnitVect(oPCof)
        oPCof(3) = -(oPCof(0) * iPnt(0) + _
                     oPCof(1) * iPnt(1) + _
                     oPCof(2) * iPnt(2))

    End Sub

    ' Get Side of Point By Given Line Throu Compare
    ' With Given Plane Normal
    ' If Cross Vector of Line & Line-Point Same Direct
    ' with Olane Normal - return 1, oppsite: return -1
    '
    '          iPlnNorm
    '             ^    +
    '             |   / \
    '             |  /iPnt
    '             | / +  +\iVln
    '             |/    /  +
    '             +    /  /
    '              \  +iPln
    '               \   /
    '                \ /
    '                 +
    Public Function MGetPntSide2( _
    ByVal iPlnNorm() As Double, _
    ByVal iPnt() As Double, _
    ByVal iPln() As Double, _
    ByVal iVln() As Double) As Integer
        Dim Vect1(2) As Double
        Dim Vect2(2) As Double
        Dim VectCros(2) As Double
        Dim CosAlfa As Double

        BMath_VectByPnt(iPln, iPnt, Vect2)

        BMath_CopyArrayDb2Db(iVln, Vect1, 3)

        BMath_UnitVect(Vect1)
        BMath_UnitVect(Vect2)

        BMath_CrossVect(Vect1, Vect2, VectCros)
        BMath_UnitVect(VectCros)

        MGetPntSide2 = -1
        CosAlfa = BMath_Vdot(iPlnNorm, VectCros)
        If CosAlfa >= 0 Then
            MGetPntSide2 = 1
        End If
    End Function


    Public Function MGetPntSide1(ByVal iPnt() As Double, _
    ByVal iPln() As Double, _
    ByVal iVln() As Double) As Integer
        Dim Vect1(2) As Double
        Dim Vect2(2) As Double
        Dim VectCros(2) As Double

        BMath_VectByPnt(iPln, iPnt, Vect2)

        BMath_CopyArrayDb2Db(iVln, Vect1, 3)

        BMath_UnitVect(Vect1)
        BMath_UnitVect(Vect2)

        BMath_CrossVect(Vect1, Vect2, VectCros)

        MGetPntSide1 = -1

        If VectCros(2) > 0 Then
            MGetPntSide1 = 1
        End If
    End Function

    Public Function MGetPntSide(ByVal iPnt() As Double, _
    ByVal iPln() As Double, _
    ByVal iVln() As Double) As Integer
        Dim Vect1(2) As Double
        Dim Vect2(2) As Double
        Dim dot As Double

        BMath_VectByPnt(iPln, iPnt, Vect2)
        BMath_CopyArrayDb2Db(iVln, Vect1, 3)

        BMath_UnitVect(Vect1)
        BMath_UnitVect(Vect2)

        dot = Vect2(0) * Vect1(1) - Vect2(1) * Vect1(0)

        MGetPntSide = 1
        If (dot < 0) Then
            MGetPntSide = -1
        End If

    End Function

    '  Multiply a 3D Vector by a 3*3 Matrix
    '
    '
    Public Sub MMultVect3DByMatx(ByVal iVct() As Double, _
    ByVal iMtrx() As Double, _
    ByVal oVct() As Double)
        Dim VectTmp(2) As Double

        VectTmp(0) = iMtrx(0)
        VectTmp(1) = iMtrx(1)
        VectTmp(2) = iMtrx(2)
        oVct(0) = BMath_Vdot(VectTmp, iVct)

        VectTmp(0) = iMtrx(3)
        VectTmp(1) = iMtrx(4)
        VectTmp(2) = iMtrx(5)
        oVct(1) = BMath_Vdot(VectTmp, iVct)

        VectTmp(0) = iMtrx(6)
        VectTmp(1) = iMtrx(7)
        VectTmp(2) = iMtrx(8)
        oVct(2) = BMath_Vdot(VectTmp, iVct)

    End Sub

    '  Transport Matrix 3*3
    '
    '
    Public Sub MTransportMatrx(ByVal iMatrx() As Double, _
    ByVal oMatrx() As Double)
        oMatrx(0) = iMatrx(0)
        oMatrx(1) = iMatrx(3)
        oMatrx(2) = iMatrx(6)
        oMatrx(3) = iMatrx(1)
        oMatrx(4) = iMatrx(4)
        oMatrx(5) = iMatrx(7)
        oMatrx(6) = iMatrx(2)
        oMatrx(7) = iMatrx(5)
        oMatrx(8) = iMatrx(8)
    End Sub

    ' Calculate Matrix 3*3 ( Determinant )
    '
    '
    Public Function MM3determ(ByVal iMtx() As Double) As Double
        Dim Determ As Double

        Determ = iMtx(0) * (iMtx(4) * iMtx(8) - iMtx(7) * iMtx(5)) - _
                 iMtx(1) * (iMtx(3) * iMtx(8) - iMtx(5) * iMtx(6)) + _
                 iMtx(2) * (iMtx(3) * iMtx(7) - iMtx(4) * iMtx(6))

        MM3determ = Determ
    End Function


    '  Get Transformation Matrix for Rotation About
    '  Given Axis
    '
    '            /
    '           /
    '       Ang/ VLn    -> Transf(8)
    '    (Deg)/
    '
    Public Sub MTrroaxVct(ByVal iVln() As Double, _
    ByVal iAng As Double, _
    ByVal oTr() As Double)

        Dim TrZAx(8) As Double
        Dim TrNZAx(8) As Double
        Dim TrINAx(8) As Double
        Dim AngRad As Double
        Dim NewY(2) As Double
        Dim NewX(2) As Double
        Dim VctTmp(2) As Double

        AngRad = iAng * PI / 180
        'Get Transf. Matrix of Rotation About Z Model
        TrZAx(0) = Cos(AngRad)
        TrZAx(1) = -Sin(AngRad)
        TrZAx(2) = 0
        TrZAx(3) = Sin(AngRad)
        TrZAx(4) = Cos(AngRad)
        TrZAx(5) = 0
        TrZAx(6) = 0
        TrZAx(7) = 0
        TrZAx(8) = 1

        '*** Get Transf. Matrix of New Ucs, Whether iVln is Z
        VctTmp(0) = 0
        VctTmp(0) = 0
        VctTmp(0) = 1
        BMath_UnitVect(iVln)
        '** Get New Y Vector **
        BMath_CrossVect(VctTmp, iVln, NewY)
        BMath_UnitVect(NewY)
        '** Get New X Vector **
        BMath_CrossVect(NewY, iVln, NewX)
        BMath_UnitVect(NewX)
        'Create Matrix
        TrNZAx(0) = NewX(0)
        TrNZAx(1) = NewX(1)
        TrNZAx(2) = NewX(2)
        TrNZAx(3) = NewY(0)
        TrNZAx(4) = NewY(1)
        TrNZAx(5) = NewY(2)
        TrNZAx(6) = iVln(0)
        TrNZAx(7) = iVln(1)
        TrNZAx(8) = iVln(2)
        MTransportMatrx(TrNZAx, TrINAx)

        'Concatination Matrix

    End Sub
    '  Version For 3D
    '  Get Intersection Point Between Two Lines
    ' Vct1      Vct2
    '   \       /
    '    \     /
    ' Pnt1+   +Pnt2
    '
    '       +PntInS
    '
    ' Only For 3D Event Return: False - Vectors Parall
    Public Function MIntersecTwoLine3D(ByVal iPnt1() As Double, _
    ByVal iVct1() As Double, _
    ByVal iPnt2() As Double, _
    ByVal iVct2() As Double, _
    ByVal oPntInS() As Double) _
                                            As Boolean
        Dim VctCros1(2) As Double
        Dim VctCros2(2) As Double
        Dim PlnC(3) As Double

        'Get Vector Normal For Two Given Vectors
        BMath_CrossVect(iVct1, iVct2, VctCros1)
        BMath_UnitVect(VctCros1)
        'Get Vector Normal By Perpendic
        BMath_CrossVect(VctCros1, iVct1, VctCros2)
        BMath_UnitVect(VctCros2)
        'Get Coeff. Plane
        MGetPlaneByPntAndVect(iPnt1, VctCros2, PlnC)
        BMath_UnitVect(PlnC)
        'Get Intersect Line & Plane
        MIntersecTwoLine3D = MPntIntersLinePlane(iPnt2, _
                                                 iVct2, _
                                                 PlnC, _
                                                 oPntInS)

    End Function

    'Projection Point on Given Plane
    Public Sub MPrjPnt2Pln(ByVal iPnt() As Double, _
    ByVal iPln() As Double, _
    ByVal oPnt() As Double)

        Dim RetVal As Integer
        Dim TmpPnt(2) As Double

        RetVal = MPntIntersLinePlane(iPnt, iPln, iPln, TmpPnt)

        If RetVal > 0 Then
            oPnt(0) = TmpPnt(0)
            oPnt(1) = TmpPnt(1)
            oPnt(2) = TmpPnt(2)
        Else
            oPnt(0) = iPnt(0)
            oPnt(1) = iPnt(1)
            oPnt(2) = iPnt(2)
        End If
    End Sub


    '  Get Projection Point on Line
    '        +iPnt ( Input Point)
    '        |\
    '        | \oPPrj( Projection Point)
    ' iPAxs+---+\--------> iVAxs ( Line Vector)
    '(Root)  +   +
    '         \  |
    '          \ |
    '           \|
    '            +
    '
    Public Sub MProjectPntOnLine( _
    ByVal iPnt() As Double, _
    ByVal iPAxs() As Double, _
    ByVal iVAxs() As Double, _
    ByVal oPPrj() As Double)

        Dim PCof(3) As Double
        Dim RetValIng As Integer

        'Get Coeff. Of Plane That Perpendic. to Axis & Pass Throu iPnt
        MGetPlaneByPntAndVect(iPnt, iVAxs, PCof)

        'Get Intesect Axis And Plane
        RetValIng = MPntIntersLinePlane(iPAxs, iVAxs, PCof, oPPrj)

    End Sub
    '+
    ' Initial. of Ortogonal BOX (Array of Double)
    '
    Public Sub BMath_IniBox(ByVal ioBox() As Double)

        ioBox(0) = FLTMAX
        ioBox(1) = FLTMAX
        ioBox(2) = FLTMAX
        ioBox(3) = -FLTMAX
        ioBox(4) = -FLTMAX
        ioBox(5) = -FLTMAX

    End Sub
    '+
    'Add Box to Box that Already Existed
    Public Sub BMath_AddBox2Box(ByVal ioBoxExist() As Double, _
    ByVal iBox2Add() As Double)
        Dim ch As Integer

        ' Minimum
        For ch = 0 To 2
            If iBox2Add(ch) < ioBoxExist(ch) Then
                ioBoxExist(ch) = iBox2Add(ch)
            End If
        Next ch

        ' Maximum
        For ch = 3 To 5
            If iBox2Add(ch) > ioBoxExist(ch) Then
                ioBoxExist(ch) = iBox2Add(ch)
            End If
        Next ch
    End Sub
    '+ 
    'Add Given Point To Box Thet Alrerady Existed
    Public Sub BMath_AddPnt2Box(ByVal ioBoxExist() As Double, _
    ByVal iPnt2Add() As Double)

        Dim ch As Integer

        For ch = 0 To 2
            ' Minimum
            If iPnt2Add(ch) < ioBoxExist(ch) Then
                ioBoxExist(ch) = iPnt2Add(ch)
            End If
            'Maximum
            If iPnt2Add(ch) > ioBoxExist(ch + 3) Then
                ioBoxExist(ch + 3) = iPnt2Add(ch)
            End If

        Next ch

    End Sub

    'Get Transform. Matrix for Given Plane( Coeffic) for
    'Convertion Point on Plane to Plane that Parralel XY
    ' Input:   iPln(3) Coeffic. of Given Plane: A,B,C,D
    ' Output:  oTrf(8) Transf. Matrix
    'Remark: if Point on Plan * Trf() - Convert Point to XY
    Public Sub BMath_TransfMatxPlane2XY(ByVal iPln() As Double, _
    ByVal oTrf() As Double)

        Dim ch As Integer
        Dim VectZ(2) As Double
        Dim VCros1(2) As Double
        Dim VCros2(2) As Double
        Dim LenVct As Double

        'Create Unit Matrix
        For ch = 0 To 8
            oTrf(ch) = 0
        Next ch
        oTrf(0) = 1
        oTrf(4) = 1
        oTrf(8) = 1

        BMath_UnitVect(iPln)

        'Get Vector Y
        VectZ(0) = 0
        VectZ(1) = 0
        VectZ(2) = 1
        BMath_CrossVect(iPln, VectZ, VCros1)
        BMath_UnitVect(VCros1)
        LenVct = BMath_LenVect(VCros1)
        If LenVct < TolEps Then
            Exit Sub
        End If

        'Get Vector X
        BMath_CrossVect(VCros1, iPln, VCros2)
        BMath_UnitVect(VCros2)
        LenVct = BMath_LenVect(VCros2)
        If LenVct < TolEps Then
            Exit Sub
        End If

        oTrf(0) = VCros2(0)
        oTrf(1) = VCros2(1)
        oTrf(2) = VCros2(2)
        oTrf(3) = VCros1(0)
        oTrf(4) = VCros1(1)
        oTrf(5) = VCros1(2)
        oTrf(6) = iPln(0)
        oTrf(7) = iPln(1)
        oTrf(8) = iPln(2)
    End Sub

    'Projection Ortogonal Box to Given Plane & Rotate for XY Parallel
    '
    ' Input:  iBox(5) As Double - Given Box
    '         iPln(3) As Double - Coeff. of Plane
    ' Output: oBox(5) As Double - Result Box on XY Plane
    '
    Public Sub BMath_BoxPrj2XY(ByVal iBox() As Double, _
    ByVal iPln() As Double, _
    ByVal oBox() As Double)
        Dim Pnt1(2) As Double
        Dim Pnt2(2) As Double
        Dim Pnt3(2) As Double
        Dim Pnt4(2) As Double
        Dim Pnt5(2) As Double
        Dim Pnt6(2) As Double
        Dim Pnt7(2) As Double
        Dim Pnt8(2) As Double

        Dim PntJ1(2) As Double
        Dim PntJ2(2) As Double
        Dim PntJ3(2) As Double
        Dim PntJ4(2) As Double
        Dim PntJ5(2) As Double
        Dim PntJ6(2) As Double
        Dim PntJ7(2) As Double
        Dim PntJ8(2) As Double

        Dim Trform(8) As Double


        'Get All 8 Points of Box
        Pnt1(0) = iBox(0)
        Pnt1(1) = iBox(1)
        Pnt1(2) = iBox(2)

        Pnt2(0) = iBox(3)
        Pnt2(1) = iBox(1)
        Pnt2(2) = iBox(2)

        Pnt3(0) = iBox(3)
        Pnt3(1) = iBox(4)
        Pnt3(2) = iBox(2)

        Pnt4(0) = iBox(0)
        Pnt4(1) = iBox(4)
        Pnt4(2) = iBox(2)

        Pnt5(0) = iBox(0)
        Pnt5(1) = iBox(1)
        Pnt5(2) = iBox(5)

        Pnt6(0) = iBox(3)
        Pnt6(1) = iBox(1)
        Pnt6(2) = iBox(5)

        Pnt7(0) = iBox(3)
        Pnt7(1) = iBox(4)
        Pnt7(2) = iBox(5)

        Pnt8(0) = iBox(0)
        Pnt8(1) = iBox(4)
        Pnt8(2) = iBox(5)

        'Project Points to Given Plane
        MPrjPnt2Pln(Pnt1, iPln, PntJ1)
        MPrjPnt2Pln(Pnt2, iPln, PntJ2)
        MPrjPnt2Pln(Pnt3, iPln, PntJ3)
        MPrjPnt2Pln(Pnt4, iPln, PntJ4)
        MPrjPnt2Pln(Pnt5, iPln, PntJ5)
        MPrjPnt2Pln(Pnt6, iPln, PntJ6)
        MPrjPnt2Pln(Pnt7, iPln, PntJ7)
        MPrjPnt2Pln(Pnt8, iPln, PntJ8)

        'Rotate Points To Plane || XY
        BMath_TransfMatxPlane2XY(iPln, Trform)
        MMultVect3DByMatx(PntJ1, Trform, Pnt1)
        MMultVect3DByMatx(PntJ2, Trform, Pnt2)
        MMultVect3DByMatx(PntJ3, Trform, Pnt3)
        MMultVect3DByMatx(PntJ4, Trform, Pnt4)
        MMultVect3DByMatx(PntJ5, Trform, Pnt5)
        MMultVect3DByMatx(PntJ6, Trform, Pnt6)
        MMultVect3DByMatx(PntJ7, Trform, Pnt7)
        MMultVect3DByMatx(PntJ8, Trform, Pnt8)

        'Get Result Box
        BMath_IniBox(oBox)
        'Add Result Points To Box
        BMath_AddPnt2Box(oBox, Pnt1)
        BMath_AddPnt2Box(oBox, Pnt2)
        BMath_AddPnt2Box(oBox, Pnt3)
        BMath_AddPnt2Box(oBox, Pnt4)
        BMath_AddPnt2Box(oBox, Pnt5)
        BMath_AddPnt2Box(oBox, Pnt6)
        BMath_AddPnt2Box(oBox, Pnt7)
        BMath_AddPnt2Box(oBox, Pnt8)
    End Sub
    '+
    'By Given Two Boxes Get Common Area ( for 2D Only )
    'Input:  iBox1(3)  As  Double  - 1st Box (2d)
    '        iBox2(3)  As  Double  - 2nd Box (2d)
    'Output: oBox(3)   As  Double  - Common Box
    'Return: Boolean: False - Not common Area, True - Yes

    Public Function BMath_ByTwoBoxGetCommonArea(ByVal iBox1() As Double, _
    ByVal iBox2() As Double, _
    ByVal oBox() As Double) As Boolean
        Dim ch As Integer
        Dim RetValIntg As Integer
        Dim ArrX(3) As Double
        Dim ArrY(3) As Double

        For ch = 0 To 3
            oBox(0) = 0
        Next ch

        BMath_ByTwoBoxGetCommonArea = False

        'If Minim. Box2 > Maxim Box1
        If iBox2(0) > iBox1(2) Then
            Exit Function
        End If
        If iBox2(1) > iBox1(3) Then
            Exit Function
        End If

        'if Maxim Box2 < Minim Box1
        If iBox2(2) < iBox1(0) Then
            Exit Function
        End If
        If iBox2(3) < iBox1(1) Then
            Exit Function
        End If

        ArrX(0) = iBox1(0)
        ArrX(1) = iBox1(2)
        ArrX(2) = iBox2(0)
        ArrX(3) = iBox2(2)
        RetValIntg = BMath_SortArrDbl(ArrX, 4)


        ArrY(0) = iBox1(1)
        ArrY(1) = iBox1(3)
        ArrY(2) = iBox2(1)
        ArrY(3) = iBox2(3)
        RetValIntg = BMath_SortArrDbl(ArrY, 4)

        oBox(0) = ArrX(1)
        oBox(1) = ArrY(1)
        oBox(2) = ArrX(2)
        oBox(3) = ArrY(2)
        BMath_ByTwoBoxGetCommonArea = True
    End Function
    '+
    'Sorting Array Double from Minimum to Maximum
    ' Input: ioArrDbl() As Double  - Array of Double
    '        iNArr      As Integer - size of Array
    '
    Public Function BMath_SortArrDbl(ByVal ioArrDbl() As Double, _
    ByVal NArr As Integer) As Integer
        Dim ch As Integer
        Dim dTmp As Double
        Dim Count As Integer
        Dim FlagSwap As Integer

        Count = 0
        FlagSwap = 1
        Do While FlagSwap > 0
            FlagSwap = 0
            For ch = 0 To NArr - 2
                If ioArrDbl(ch) > ioArrDbl(ch + 1) Then
                    dTmp = ioArrDbl(ch)
                    ioArrDbl(ch) = ioArrDbl(ch + 1)
                    ioArrDbl(ch + 1) = dTmp
                    FlagSwap = 1
                    Count = Count + 1
                End If
            Next ch
        Loop

        BMath_SortArrDbl = Count
    End Function

    ' Get Angle in Radian By Given it Cos()
    ' Input: iCosAngl   As Double  - Cosin of Angle
    ' Return: Angle by Radian
    Public Function BMath_GetAnglByCosin(ByVal iCosAlf As Double) As Double
        Dim Denominat As Double

        Denominat = -iCosAlf * iCosAlf + 1
        If Abs(Denominat) < TolEps Then
            Denominat = TolEps
        Else
            Denominat = Sqrt(Denominat)
        End If

        BMath_GetAnglByCosin = Atan(-iCosAlf / Denominat) + 2 * Atan(1)

    End Function
    '+
    ' Map Given Point to Given Plane
    ' Input: iPlnTransf(8) - Plane Transform. Matrix
    '        iPnt(2)       - Given Pnt
    '        oPnt(2)       - Mapped Point

    Public Sub BMath_MapPnt2Pln(ByVal iPlnTransf() As Double, _
    ByVal iPnt() As Double, _
    ByVal oPnt() As Double)

        Dim VectTmp(2) As Double

        VectTmp(0) = iPlnTransf(0)
        VectTmp(1) = iPlnTransf(1)
        VectTmp(2) = iPlnTransf(2)
        oPnt(0) = BMath_Vdot(VectTmp, iPnt)

        VectTmp(0) = iPlnTransf(3)
        VectTmp(1) = iPlnTransf(4)
        VectTmp(2) = iPlnTransf(5)
        oPnt(1) = BMath_Vdot(VectTmp, iPnt)

        VectTmp(0) = iPlnTransf(6)
        VectTmp(1) = iPlnTransf(7)
        VectTmp(2) = iPlnTransf(8)
        oPnt(2) = BMath_Vdot(VectTmp, iPnt)

    End Sub
    '+
    ' Check Whether Given Point Belongs to Given Plane

    Public Function BMath_CheckPntOnPlane(ByVal iPnt() As Double, _
    ByVal iCoefPln() As Double) As Boolean
        Dim dTmpVal As Double

        dTmpVal = iPnt(0) * iCoefPln(0)
        dTmpVal = dTmpVal + iPnt(1) * iCoefPln(1)
        dTmpVal = dTmpVal + iPnt(2) * iCoefPln(2)
        dTmpVal = dTmpVal + iCoefPln(3)

        If Abs(dTmpVal) > TolEps * 100 Then
            BMath_CheckPntOnPlane = False
        Else
            BMath_CheckPntOnPlane = True
        End If
    End Function

    ' Rotate Given Vector About Rotation Axis By Given Angle
    ' Input: iVctRot(2) - Rotated Vector
    '        iVctAxs(2) - Rotation Axis
    '        iAngle     - Rotation Angle( Degree)
    '        oVctNew(2) - New Vector

    Public Sub BMath_RotVctAbtAxis(ByVal iVctRot() As Double, _
    ByVal iVctAxs() As Double, _
    ByVal iAngl As Double, _
    ByVal oVctNew() As Double)
        Dim VctZ(2) As Double
        Dim VctX(2) As Double
        Dim VctY(2) As Double
        Dim AngRad As Double
        Dim VctTmp(2) As Double

        BMath_CopyArrayDb2Db(iVctRot, VctX, 3)
        BMath_CopyArrayDb2Db(iVctAxs, VctZ, 3)
        BMath_CrossVect(VctZ, VctX, VctY)
        If BMath_LenVect(VctY) < TolEps Then
            BMath_CopyArrayDb2Db(iVctRot, oVctNew, 3)
            Exit Sub
        End If
        BMath_UnitVect(VctX)
        BMath_UnitVect(VctY)
        BMath_UnitVect(VctZ)

        AngRad = iAngl * PI / 180
        VctTmp(0) = Cos(AngRad)
        VctTmp(1) = Sin(AngRad)
        VctTmp(2) = 0

        oVctNew(0) = VctTmp(0) * VctX(0) + VctTmp(1) * VctY(0) + _
                     VctTmp(2) * VctZ(0)
        oVctNew(1) = VctTmp(0) * VctX(1) + VctTmp(1) * VctY(1) + _
                     VctTmp(2) * VctZ(1)
        oVctNew(2) = VctTmp(0) * VctX(2) + VctTmp(1) * VctY(2) + _
                     VctTmp(2) * VctZ(2)
        BMath_UnitVect(oVctNew)

    End Sub

    'Rotate Given Point About Given Rotation Axis
    Public Sub BMath_RotPntAbtAxis(ByVal iPntRot() As Double, _
    ByVal iPntAxs() As Double, _
    ByVal iVctAxs() As Double, _
    ByVal iAngl As Double, _
    ByVal oPntNew() As Double)

        Dim dPntPrj2Ln(2) As Double
        Dim dVct2Pnt(2) As Double
        Dim dVct2PntUnit(2) As Double
        Dim dVctAfterRot(2) As Double
        Dim LenVct As Double

        'Vector to Point
        MProjectPntOnLine(iPntRot, iPntAxs, iVctAxs, dPntPrj2Ln)
        BMath_VectByPnt(dPntPrj2Ln, iPntRot, dVct2Pnt)
        LenVct = BMath_LenVect(dVct2Pnt)
        BMath_CopyArrayDb2Db(dVct2Pnt, dVct2PntUnit, 3)
        BMath_UnitVect(dVct2PntUnit)

        'Rotate Vector about Axis
        BMath_RotVctAbtAxis(dVct2PntUnit, _
                            iVctAxs, _
                            iAngl, _
                            dVctAfterRot)

        'Get Result
        BMath_UnitVect(dVctAfterRot)
        BMath_VectScale(dVctAfterRot, LenVct)
        BMath_PntAddVect(dPntPrj2Ln, dVctAfterRot, oPntNew)

    End Sub

    ' Rotate Vector 2D by Given Angle
    Public Sub BMath_RotVect2DByAngl(ByVal iVect() As Double, _
    ByVal iAngl As Double, _
    ByVal oVect() As Double)
        Dim AnglVct As Double

        AnglVct = BMath_AnglAbs(iVect(0), iVect(1))

        AnglVct = (AnglVct + iAngl) * PI / 180

        oVect(0) = Cos(AnglVct)
        oVect(1) = Sin(AnglVct)
    End Sub


    ' By Given Two Point And 3 Slope -> Get Two Arcs
    '
    '            P3               Format oArcDat() Array
    '             . .             (0) - Number Segments
    '          . ^    .                 Min. 1 Max 2
    '        .   |      .         (1)
    '       .iVs3|        + iP2   (2) - coord. of Center Point
    '  iP1 +->   |       /        (3) - Radius
    '       \    |     iVs2       (4) - Start Angle
    '       iVs1 |     /          (5) - End Angle
    '         \  |    /
    '          \ |   /
    '           \|  /
    '         P4 +R1
    '            |/
    '         P5 +R2
    Public Function BMath_2PntAnd3SlopeTwoArcs( _
    ByVal iP1() As Double, _
    ByVal iP2() As Double, _
    ByVal iVs1() As Double, _
    ByVal iVs2() As Double, _
    ByVal iVs3() As Double, _
    ByVal oArcDat() As Double)

        Dim Ae As Double
        Dim Bf As Double
        Dim Ec As Double
        Dim Fd As Double
        Dim X2X1 As Double
        Dim Y2Y1 As Double
        Dim r1 As Double
        Dim r2 As Double
        Dim MBs As Double
        Dim MR1 As Double
        Dim MR2 As Double
        Dim XY3(2) As Double

        Ae = iVs1(0) - iVs3(0)
        Bf = iVs1(1) - iVs3(1)
        Ec = iVs3(0) - iVs2(0)
        Fd = iVs3(1) - iVs2(1)
        X2X1 = iP2(0) - iP1(0)
        Y2Y1 = iP2(1) - iP1(1)

        MBs = Ae * Fd - Ec * Bf
        MR1 = X2X1 * Fd - Ec * Y2Y1
        MR2 = Y2Y1 * Ae - X2X1 * Bf

        If Abs(MBs) < TolEps * 0.01 Then
            BMath_2PntAnd3SlopeTwoArcs = -1
            Exit Function
        End If

        r1 = Abs(MR1 / MBs)
        r2 = Abs(MR2 / MBs)

        oArcDat(0) = 1
        oArcDat(1) = iP1(0) + iVs1(0) * r1
        oArcDat(2) = iP1(1) + iVs1(1) * r1
        oArcDat(3) = r1
        oArcDat(4) = BMath_AnglAbs(iP1(0) - oArcDat(1), _
                                   iP1(1) - oArcDat(2))
        XY3(0) = oArcDat(1) - iVs3(0) * r1
        XY3(1) = oArcDat(2) - iVs3(1) * r1
        oArcDat(5) = BMath_AnglAbs(XY3(0) - oArcDat(1), _
                                   XY3(1) - oArcDat(2))

        If Abs(r1 - r2) > TolEps Then
            oArcDat(0) = 2
            oArcDat(6) = iP2(0) + iVs2(0) * r2
            oArcDat(7) = iP2(1) + iVs2(1) * r2
            oArcDat(8) = r2
            oArcDat(9) = BMath_AnglAbs(XY3(0) - oArcDat(6), _
                                       XY3(1) - oArcDat(7))
            oArcDat(10) = BMath_AnglAbs(iP2(0) - oArcDat(6), _
                                        iP2(1) - oArcDat(7))
        End If

        BMath_2PntAnd3SlopeTwoArcs = 0
    End Function

    'Get Middle Point On Arc by Given Center, Start Point, End Point
    'Given Point Belongs to Part where Central Angle < = 180

    Public Sub BMath_ArcMidByCentStrtEnd(ByVal iPntC() As Double, _
    ByVal iPntS() As Double, _
    ByVal iPntE() As Double, _
    ByVal oPntM() As Double)
        Dim dVctChord(2) As Double
        Dim dPntMidChord(2) As Double
        Dim dVctTmp1(2) As Double
        Dim dRadTmp As Double


        BMath_GetMidPnt(iPntS, iPntE, dPntMidChord)
        BMath_VectByPnt(iPntC, dPntMidChord, dVctTmp1)
        BMath_UnitVect(dVctTmp1)
        dRadTmp = BMath_Dist3D(iPntC, iPntS)
        BMath_VectScale(dVctTmp1, dRadTmp)
        BMath_PntAddVect(iPntC, dVctTmp1, oPntM)
    End Sub


    'Projection Ortogonal Box to Given Plane
    '
    ' Input:  iBox(5) As Double - Given Box
    '         iPln(3) As Double - Coeff. of Plane
    ' Output: oBox(5) As Double - Result Box on XY Plane
    '
    Public Sub BMath_BoxPrj2Plane(ByVal iBox() As Double, _
    ByVal TranMtrx() As Double, _
    ByVal oBox() As Double)
        Dim Pnt1(2) As Double
        Dim Pnt2(2) As Double
        Dim Pnt3(2) As Double
        Dim Pnt4(2) As Double
        Dim Pnt5(2) As Double
        Dim Pnt6(2) As Double
        Dim Pnt7(2) As Double
        Dim Pnt8(2) As Double

        Dim PntJ1(2) As Double
        Dim PntJ2(2) As Double
        Dim PntJ3(2) As Double
        Dim PntJ4(2) As Double
        Dim PntJ5(2) As Double
        Dim PntJ6(2) As Double
        Dim PntJ7(2) As Double
        Dim PntJ8(2) As Double


        'Get All 8 Points of Box
        Pnt1(0) = iBox(0)
        Pnt1(1) = iBox(1)
        Pnt1(2) = iBox(2)

        Pnt2(0) = iBox(3)
        Pnt2(1) = iBox(1)
        Pnt2(2) = iBox(2)

        Pnt3(0) = iBox(3)
        Pnt3(1) = iBox(4)
        Pnt3(2) = iBox(2)

        Pnt4(0) = iBox(0)
        Pnt4(1) = iBox(4)
        Pnt4(2) = iBox(2)

        Pnt5(0) = iBox(0)
        Pnt5(1) = iBox(1)
        Pnt5(2) = iBox(5)

        Pnt6(0) = iBox(3)
        Pnt6(1) = iBox(1)
        Pnt6(2) = iBox(5)

        Pnt7(0) = iBox(3)
        Pnt7(1) = iBox(4)
        Pnt7(2) = iBox(5)

        Pnt8(0) = iBox(0)
        Pnt8(1) = iBox(4)
        Pnt8(2) = iBox(5)

        'Project Points to Given Plane
        BMath_MapPnt2Pln(TranMtrx, Pnt1, PntJ1)
        BMath_MapPnt2Pln(TranMtrx, Pnt2, PntJ2)
        BMath_MapPnt2Pln(TranMtrx, Pnt3, PntJ3)
        BMath_MapPnt2Pln(TranMtrx, Pnt4, PntJ4)
        BMath_MapPnt2Pln(TranMtrx, Pnt5, PntJ5)
        BMath_MapPnt2Pln(TranMtrx, Pnt6, PntJ6)
        BMath_MapPnt2Pln(TranMtrx, Pnt7, PntJ7)
        BMath_MapPnt2Pln(TranMtrx, Pnt8, PntJ8)


        'Get Result Box
        BMath_IniBox(oBox)
        'Add Result Points To Box
        BMath_AddPnt2Box(oBox, PntJ1)
        BMath_AddPnt2Box(oBox, PntJ2)
        BMath_AddPnt2Box(oBox, PntJ3)
        BMath_AddPnt2Box(oBox, PntJ4)
        BMath_AddPnt2Box(oBox, PntJ5)
        BMath_AddPnt2Box(oBox, PntJ6)
        BMath_AddPnt2Box(oBox, PntJ7)
        BMath_AddPnt2Box(oBox, PntJ8)
    End Sub


    ' Map Given Plane Point to Model Coordinates
    ' Input: iPlnTransf(8) - Plane Transform. Matrix
    '        iPnt(2)       - Given Plane Point
    '        oPnt(2)       - Mapped 3D Point

    Public Sub BMath_MapPlnPnt2Model(ByVal iPlnTransf() As Double, _
    ByVal iPnt() As Double, _
    ByVal oPnt() As Double)

        Dim VectTmp(2) As Double

        VectTmp(0) = iPlnTransf(0)
        VectTmp(1) = iPlnTransf(3)
        VectTmp(2) = iPlnTransf(6)
        oPnt(0) = BMath_Vdot(VectTmp, iPnt)

        VectTmp(0) = iPlnTransf(1)
        VectTmp(1) = iPlnTransf(4)
        VectTmp(2) = iPlnTransf(7)
        oPnt(1) = BMath_Vdot(VectTmp, iPnt)

        VectTmp(0) = iPlnTransf(2)
        VectTmp(1) = iPlnTransf(5)
        VectTmp(2) = iPlnTransf(8)
        oPnt(2) = BMath_Vdot(VectTmp, iPnt)

    End Sub

    Public Function BMath_DistPnt2Pln(ByVal iPlnCoef() As Double, ByVal iPnt() As Double) As Double
        Dim dLenTmp As Double
        Dim dLenTmp1 As Double

        dLenTmp = Sqrt(iPlnCoef(0) * iPlnCoef(0) + _
                      iPlnCoef(1) * iPlnCoef(1) + _
                      iPlnCoef(2) * iPlnCoef(2))

        If dLenTmp < TolEps Then
            BMath_DistPnt2Pln = 0
            Exit Function
        End If

        dLenTmp1 = iPlnCoef(0) * iPnt(0) + _
                   iPlnCoef(1) * iPnt(1) + _
                   iPlnCoef(2) * iPnt(2) + iPlnCoef(3)

        BMath_DistPnt2Pln = Abs(dLenTmp1 / dLenTmp)
    End Function


    Public Function BMath_UnitMatrx(ByVal CurMatrx() As Double) As Boolean

        CurMatrx(0) = 1
        CurMatrx(1) = 0
        CurMatrx(2) = 0
        CurMatrx(3) = 0
        CurMatrx(4) = 1
        CurMatrx(5) = 0
        CurMatrx(6) = 0
        CurMatrx(7) = 0
        CurMatrx(8) = 1

        BMath_UnitMatrx = True
    End Function
    Public Function BMath_UnitMatrxSE(ByVal CurMatrx() As Double) As Boolean

        CurMatrx(0) = 1
        CurMatrx(1) = 0
        CurMatrx(2) = 0
        CurMatrx(3) = 0

        CurMatrx(4) = 0
        CurMatrx(5) = 1
        CurMatrx(6) = 0
        CurMatrx(7) = 0

        CurMatrx(8) = 0
        CurMatrx(9) = 0
        CurMatrx(10) = 1
        CurMatrx(11) = 0

        CurMatrx(12) = 0
        CurMatrx(13) = 0
        CurMatrx(14) = 0
        CurMatrx(15) = 1

        BMath_UnitMatrxSE = True
    End Function


    ' Get New Points of Line After Offset it by Given Offset Value
    ' and direction by Point
    '
    '           iPntL1+    oPntL1New
    '                /    +
    '               /    /       iPntDir
    '              /    /        +
    '             /    /
    '     iPntL2 +    /
    '                +oPntL2New
    '
    '
    ' Return:  True - O.K,  False - Cannot Get Offset

    Public Function BMath_OffsetLine1(ByVal iPntL1() As Double, _
    ByVal iPntL2() As Double, _
    ByVal iPntDir() As Double, _
    ByVal iOffsVal As Double, _
    ByVal oPntL1New() As Double, _
    ByVal oPntL2New() As Double) As Boolean

        Dim dVctLn(2) As Double
        Dim dVctDir(2) As Double
        Dim dVctPerp(2) As Double
        Dim dCosAlfa As Double

        BMath_OffsetLine1 = False

        'Get Unit Vector of Given Line
        BMath_VectByPnt(iPntL1, iPntL2, dVctLn)
        BMath_UnitVect(dVctLn)

        'Get Unit Vector to Point Direction
        BMath_VectByPnt(iPntL1, iPntDir, dVctDir)
        BMath_UnitVect(dVctDir)

        'Get Vector Perpend. to Vector Line
        dVctPerp(0) = -dVctLn(1)
        dVctPerp(1) = dVctLn(0)
        dVctPerp(2) = dVctLn(2)

        'Check Whether Vector Perpend to direction of iPnrDir
        dCosAlfa = BMath_Vdot(dVctPerp, dVctDir)
        If dCosAlfa < 0 Then
            BMath_VectScale(dVctPerp, -1)
        End If

        'Scale Vector Perpend. by Offset Value
        BMath_VectScale(dVctPerp, iOffsVal)

        'Get Result Output ( New ) Points
        BMath_PntAddVect(iPntL1, dVctPerp, oPntL1New)
        BMath_PntAddVect(iPntL2, dVctPerp, oPntL2New)

        BMath_OffsetLine1 = True

    End Function

    ' Close Point to Line
    '
    '                     iPntL1
    '            iPnt     +
    '               +    /
    '                 \ /
    '                  + oPnt
    '                 /
    '                +iPntL2
    '
    '
    ' Return:  0 - Close to Line, 1 - Close to iPntL1, 2 - Close to iPntL2

    Public Function BMath_ClosePntToLine(ByVal iPnt() As Double, _
    ByVal iPntL1() As Double, _
    ByVal iPntL2() As Double, _
    ByVal oPnt() As Double) As Integer

        Dim dVctDir(2) As Double
        Dim dLenVct As Double
        Dim dLenPrj As Double
        Dim dVctPnt(2) As Double

        'Get Vector Line
        BMath_VectByPnt(iPntL1, iPntL2, dVctDir)

        'Get Length of Line
        dLenVct = BMath_LenVect(dVctDir)

        'Get Unit Vector Line
        BMath_UnitVect(dVctDir)

        'Get Vector 1-st Point Line to Given Point
        BMath_VectByPnt(iPntL1, iPnt, dVctPnt)

        'Get Vector Point Projection to Vector Line
        dLenPrj = BMath_Vdot(dVctDir, dVctPnt)

        'Check whether iPnt into Line

        If dLenPrj < 0 Then
            'Case: iPnt closed to iPntL1
            BMath_CopyArrayDb2Db(iPntL1, oPnt, 3)
            BMath_ClosePntToLine = 1
            Exit Function
        End If

        If dLenPrj > dLenVct Then
            'Case: iPnt closed to iPntL2
            BMath_CopyArrayDb2Db(iPntL2, oPnt, 3)
            BMath_ClosePntToLine = 2
            Exit Function
        End If

        'Case Into Line Interval
        BMath_VectScale(dVctDir, dLenPrj)
        BMath_PntAddVect(iPntL1, dVctDir, oPnt)
        BMath_ClosePntToLine = 0

    End Function
    '+
    'Get Intersection Point between Two Lines
    '
    ' Output:  oPntIntr()  - Intersection Point
    '          oPar1       - Parameter Intersect. for 1 st Line
    '          oPar2       - Parameter Intersect. for 2 nd Line
    ' Return:  True - Intersection into given Lines
    '          False - at least One Line Out of Intersection
    '
    '       iPntL1S +       + iPntL2S
    '                \     /
    '                 \   /
    '                  \ /              For This Case: Return = TRUE
    '                   + oPntIntr
    '                  / \
    '                 /   \
    '       iPntL2E  +     + iPntL1E
    '
    Public Function BMath_IntersecTwoLine2D(ByVal iPntL1S() As Double, _
    ByVal iPntL1E() As Double, _
    ByVal iPntL2S() As Double, _
    ByVal iPntL2E() As Double, _
    ByVal oPntIntr() As Double, _
    ByRef oParL1 As Double, _
    ByRef oParL2 As Double) As Boolean
        Dim A As Double
        Dim B As Double
        Dim C As Double
        Dim D As Double
        Dim E As Double
        Dim H As Double
        Dim Dsc As Double
        Dim Dsc1 As Double

        BMath_IntersecTwoLine2D = False
        oParL1 = 0
        oParL2 = 0

        A = iPntL1E(0) - iPntL1S(0)
        B = -(iPntL2E(0) - iPntL2S(0))
        C = iPntL1E(1) - iPntL1S(1)
        D = -(iPntL2E(1) - iPntL2S(1))
        E = iPntL2S(0) - iPntL1S(0)
        H = iPntL2S(1) - iPntL1S(1)

        Dsc = A * D - C * B
        If Abs(Dsc) < TolInters Then
            Exit Function
        End If

        Dsc1 = E * D - H * B
        oParL1 = Dsc1 / Dsc

        Dsc1 = A * H - E * C
        oParL2 = Dsc1 / Dsc

        oPntIntr(0) = iPntL1S(0) + A * oParL1
        oPntIntr(1) = iPntL1S(1) + C * oParL1

        '   If oParL1 >= 0 And oParL1 <= 1 And oParL2 >= 0 And oParL2 <= 1 Then
        BMath_IntersecTwoLine2D = True
        '   End If


    End Function

    Public Sub BMath_ExtendLineBothSide(ByVal ioPntL1() As Double, _
    ByVal ioPntL2() As Double, _
    ByVal iOffVal As Double)
        Dim dVctLn(2) As Double
        Dim dPntTmp(2) As Double

        'Vector of Given Line
        BMath_VectByPnt(ioPntL1, ioPntL2, dVctLn)
        BMath_UnitVect(dVctLn)

        'Get Offset Vector
        BMath_VectScale(dVctLn, iOffVal)

        'Update End Line Point
        BMath_PntAddVect(ioPntL2, dVctLn, dPntTmp)
        BMath_CopyArrayDb2Db(dPntTmp, ioPntL2, 3)

        'Update Start Line Point
        BMath_VectScale(dVctLn, -1)
        BMath_PntAddVect(ioPntL1, dVctLn, dPntTmp)
        BMath_CopyArrayDb2Db(dPntTmp, ioPntL1, 3)

    End Sub

    'Get Angle Between 2 Given Vectors By Flag Rotation Direction:
    ' And Vector Axis Direction
    ' iDirCcw : 0 - CW, 1 - CWW

    Public Function BMAth_Angl2VectByRotat(ByVal iVct1() As Double, _
    ByVal iVct2() As Double, _
    ByVal iVctAxs() As Double, _
    ByVal iDirCcw As Integer) As Double

        Dim dVct1(2) As Double
        Dim dVct2(2) As Double
        Dim dVctAxs(2) As Double
        Dim dVctCrs(2) As Double
        Dim dVctNew(2) As Double
        Dim dPntB(2) As Double
        Dim dPlnCoef(3) As Double
        Dim dAngTmp1 As Double
        Dim dAngTmp2 As Double


        'Definition
        dPntB(0) = dPntB(1) = dPntB(2) = 0

        MGetPlaneByPntAndVect(dPntB, iVctAxs, dPlnCoef)

        MPrjPnt2Pln(iVct1, dPlnCoef, dVct1)
        BMath_UnitVect(dVct1)

        MPrjPnt2Pln(iVct2, dPlnCoef, dVct2)
        BMath_UnitVect(dVct2)

        'Get Angle Between Vectors
        dAngTmp1 = MGetAngl2Vector(dVct1, dVct2)
        dAngTmp1 = 180 * (dAngTmp1 / PI)

        'Check if Angle CCW
        BMath_RotVctAbtAxis(dVct1, iVctAxs, dAngTmp1, dVctNew)
        BMath_UnitVect(dVctNew)
        dAngTmp2 = MGetAngl2Vector(dVctNew, dVct2)
        If Abs(dAngTmp2) > TolEps * 100 Then
            dAngTmp1 = 360 - dAngTmp1
        End If

        If iDirCcw = 0 Then
            dAngTmp1 = dAngTmp1 - 360
        End If


        BMAth_Angl2VectByRotat = dAngTmp1
    End Function

    'Get Point on Line By Given Center & Radius
    '
    '                  iPntC
    '                  +
    '                 / \ \
    '                /   \  \
    '               / iRad\   \
    '       iPnt1  /       \    \
    '             +---->----+----+
    '              iVctLn  oPntOnLn
    '
    '
    ' Return: True - oPntOnLn in Line, False - Out of Line
    '
    Public Function BMath_PntOnLnByRad(ByVal iPntC() As Double, _
    ByVal iPnt1() As Double, _
    ByVal iVctLn() As Double, _
    ByVal iRad As Double, _
    ByVal oPntOnLn() As Double) As Boolean
        Dim dVctE(2) As Double
        Dim dVct1(2) As Double
        Dim dDot As Double
        Dim dR1 As Double
        Dim b1(1) As Double
        Dim ParB As Double

        BMath_CopyArrayDb2Db(iVctLn, dVctE, 3)
        BMath_UnitVect(dVctE)

        BMath_VectByPnt(iPntC, iPnt1, dVct1)

        dDot = BMath_Vdot(dVct1, dVctE)
        dR1 = BMath_Dist3D(iPntC, iPnt1)
        dR1 = dR1 * dR1 - iRad * iRad

        If dDot * dDot - dR1 < 0 Then
            BMath_PntOnLnByRad = False
            Exit Function
        End If

        b1(0) = -dDot + Sqrt(dDot * dDot - dR1)
        b1(1) = -dDot - Sqrt(dDot * dDot - dR1)

        If b1(0) < 0 And b1(1) < 0 Then
            ParB = b1(0)
            If b1(1) > b1(0) Then
                ParB = b1(1)
            End If
            BMath_PntOnLnByRad = False

        ElseIf b1(0) >= 0 And b1(1) >= 0 Then
            ParB = b1(0)
            If b1(1) > b1(0) Then
                ParB = b1(1)
            End If
            BMath_PntOnLnByRad = True

        Else
            ParB = b1(0)
            If b1(1) >= 0 Then
                ParB = b1(1)
            End If
            BMath_PntOnLnByRad = True
        End If

        oPntOnLn(0) = iPnt1(0) + ParB * dVctE(0)
        oPntOnLn(1) = iPnt1(1) + ParB * dVctE(1)
        oPntOnLn(2) = iPnt1(2) + ParB * dVctE(2)

    End Function

    'By Given Plane ( Coeffic ) Calculate Transformation Matrix & Root Point
    Public Sub BMath_PlaneTransf(ByVal iPlnCoef() As Double, _
    ByVal oPntRoot() As Double, _
    ByVal oTransf() As Double)
        Dim dVctN(2) As Double
        Dim dVctZ(2) As Double
        Dim dVctCrs(2) As Double
        Dim dVctTmp(2) As Double
        Dim dLenTmp As Double

        'Get Vector Normal
        BMath_CopyArrayDb2Db(iPlnCoef, dVctN, 3)
        BMath_UnitVect(dVctN)

        'Get Axis Y
        dVctZ(0) = 0
        dVctZ(1) = 0
        dVctZ(2) = 1
        BMath_CrossVect(dVctZ, dVctN, dVctCrs)
        BMath_UnitVect(dVctCrs)
        dLenTmp = BMath_LenVect(dVctCrs)
        If dLenTmp < 0.1 Then
            BMath_UnitMatrx(oTransf)
            BMath_VectScale(dVctZ, -iPlnCoef(3))
            BMath_CopyArrayDb2Db(dVctZ, oPntRoot, 3)
            Exit Sub
        End If


        'Set to Transf Vector Normal
        BMath_CpArrDb2DbByIndx(dVctN, 0, oTransf, 6, 3)

        'Set to Transf Vector Y
        BMath_CpArrDb2DbByIndx(dVctCrs, 0, oTransf, 3, 3)

        'Get Axis  X
        BMath_CrossVect(dVctCrs, dVctN, dVctTmp)
        BMath_UnitVect(dVctTmp)
        BMath_CpArrDb2DbByIndx(dVctTmp, 0, oTransf, 0, 3)

        'Get Root Point
        BMath_VectScale(dVctN, -iPlnCoef(3))
        BMath_CopyArrayDb2Db(dVctN, oPntRoot, 3)

    End Sub

    'Get Circle Center By Given 3 Points( 3D )
    Public Function BMath_CirclBy3Pnt(ByVal iPnt1() As Double, _
    ByVal iPnt2() As Double, _
    ByVal iPnt3() As Double, _
    ByVal oPntC() As Double, _
    ByVal oRad As Double) As Boolean
        Dim RetValBool As Boolean
        Dim RetValInt As Integer
        Dim dPlnCoef(3) As Double
        Dim dVct12(2) As Double
        Dim dVct13(2) As Double
        Dim dPntRoot(2) As Double
        Dim dTransf(8) As Double
        Dim dPnt1_2d(2) As Double
        Dim dPnt2_2d(2) As Double
        Dim dPnt3_2d(2) As Double
        Dim dPntC_2d(2) As Double
        Dim dPntTmp(2) As Double


        BMath_CirclBy3Pnt = False

        'Get Plane Coefficient
        RetValBool = MGetPlaneBy3Pnt(iPnt1, iPnt2, iPnt3, dPlnCoef)
        If RetValBool = False Then
            Exit Function
        End If

        'Create Transf And Root Point
        BMath_PlaneTransf(dPlnCoef, dPntRoot, dTransf)

        'Mapping Given Points to Plane
        BMath_MapPnt2Pln(dTransf, iPnt1, dPnt1_2d)
        BMath_MapPnt2Pln(dTransf, iPnt2, dPnt2_2d)
        BMath_MapPnt2Pln(dTransf, iPnt3, dPnt3_2d)
        dPnt1_2d(2) = 0
        dPnt2_2d(2) = 0
        dPnt3_2d(2) = 0


        'Calculate Center Circle
        RetValInt = MGetCntrArcBy3Pnt(dPnt1_2d, dPnt2_2d, dPnt3_2d, dPntC_2d)
        If RetValInt < 0 Then
            Exit Function
        End If

        'Mapping 2d -> Model
        BMath_MapPlnPnt2Model(dTransf, dPntC_2d, dPntTmp)
        MPrjPnt2Pln(dPntTmp, dPlnCoef, oPntC)

        oRad = BMath_Dist3D(oPntC, iPnt1)

        BMath_CirclBy3Pnt = True
    End Function

    Public Function BMath_Dist3DSqur(ByVal iPnt1() As Double, ByVal iPnt2() As Double) As Double

        BMath_Dist3DSqur = (iPnt2(0) - iPnt1(0)) * (iPnt2(0) - iPnt1(0)) + _
                           (iPnt2(1) - iPnt1(1)) * (iPnt2(1) - iPnt1(1)) + _
                           (iPnt2(2) - iPnt1(2)) * (iPnt2(2) - iPnt1(2))

    End Function
    '+
    Public Function BMath_DistPntPlane(ByVal iPnt() As Double, ByVal iPlnCoef() As Double) As Double

        BMath_DistPntPlane = BMath_Vdot(iPnt, iPlnCoef) + iPlnCoef(3)

    End Function

    '+
    '******************************************************
    '           BMathMinDist2Box
    '
    '  Purpose: Get Minimum Distance Between TWO given
    '           Boxes
    '
    '    Input:  box1(5)   Double
    '            box2(5)   Double
    '            len_inp   Double
    '    Return: Min. Distance
    '
    '*******************************************************
    Public Function BMathMinDist2Box(ByVal box1() As Double, _
    ByVal box2() As Double, _
    ByVal len_inp As Double) As Double

        Dim delta1 As Double
        Dim delta2 As Double
        Dim dist_min As Double

        dist_min = 0

        'By Axis X
        delta1 = 0
        If box1(3) < box2(0) Then
            delta1 = box2(0) - box1(3)
        End If

        delta2 = 0
        If box1(0) > box2(3) Then
            delta2 = box1(0) - box2(3)
        End If
        dist_min = dist_min + (delta1 + delta2) * (delta1 + delta2)
        If dist_min >= len_inp Then
            BMathMinDist2Box = dist_min
            Exit Function
        End If

        'By Axis Y
        delta1 = 0
        If box1(4) < box2(1) Then
            delta1 = box2(1) - box1(4)
        End If

        delta2 = 0
        If box1(1) > box2(4) Then
            delta2 = box1(1) - box2(4)
        End If
        dist_min = dist_min + (delta1 + delta2) * (delta1 + delta2)
        If dist_min >= len_inp Then
            BMathMinDist2Box = dist_min
            Exit Function
        End If

        'By Axis Z
        delta1 = 0
        If box1(5) < box2(2) Then
            delta1 = box2(2) - box1(5)
        End If

        delta2 = 0
        If box1(2) > box2(5) Then
            delta2 = box1(2) - box2(5)
        End If
        dist_min = dist_min + (delta1 + delta2) * (delta1 + delta2)
        If dist_min >= len_inp Then
            BMathMinDist2Box = dist_min
            Exit Function
        End If

        BMathMinDist2Box = dist_min

    End Function
    '+
    Public Function BMath_CheckPntInBox(ByVal iPnt() As Double, _
    ByVal iBox() As Double, _
    ByVal iToler As Double) As Boolean

        BMath_CheckPntInBox = False

        If (iPnt(0) >= iBox(0) - iToler) And (iPnt(0) <= iBox(3) + iToler) Then
            If (iPnt(1) >= iBox(1) - iToler) And (iPnt(1) <= iBox(4) + iToler) Then
                If (iPnt(2) >= iBox(2) - iToler) And (iPnt(2) <= iBox(5) + iToler) Then
                    BMath_CheckPntInBox = True
                End If
            End If
        End If

    End Function
    '+
    'Check whether given Point into Triangular
    ' Input:    iPnt(2) AS Double    - Given Point
    '           iTrg(8) AS Double    - Given Triangul
    ' Return:   True - Into,  False - Outside
    Public Function BMath_CheckPntInTrg(ByVal iPnt() As Double, _
    ByVal iTrg() As Double) As Boolean


        Dim e1(2) As Double
        Dim e2(2) As Double
        Dim dR(2) As Double
        Dim e1e2 As Double
        Dim e1e1 As Double
        Dim e2e2 As Double
        Dim dre1 As Double
        Dim dre2 As Double
        Dim alfa As Double
        Dim beta As Double
        Dim delta As Double


        BMath_CheckPntInTrg = False

        dR(0) = iPnt(0) - iTrg(0)
        dR(1) = iPnt(1) - iTrg(1)
        dR(2) = iPnt(2) - iTrg(2)

        e1(0) = iTrg(3) - iTrg(0)
        e1(1) = iTrg(4) - iTrg(1)
        e1(2) = iTrg(5) - iTrg(2)

        e2(0) = iTrg(6) - iTrg(0)
        e2(1) = iTrg(7) - iTrg(1)
        e2(2) = iTrg(8) - iTrg(2)

        e1e1 = BMath_Vdot(e1, e1)
        e2e2 = BMath_Vdot(e2, e2)
        e1e2 = BMath_Vdot(e1, e2)
        dre1 = BMath_Vdot(dR, e1)
        dre2 = BMath_Vdot(dR, e2)

        delta = e1e1 * e2e2 - e1e2 * e1e2
        alfa = dre1 * e2e2 - e1e2 * dre2
        beta = e1e1 * dre2 - dre1 * e1e2

        If delta > 0 Then

            If alfa >= 0 And beta >= 0 And (alfa + beta <= delta) Then
                BMath_CheckPntInTrg = True
            End If
        ElseIf delta < 0 Then
            If alfa <= 0 And beta <= 0 And (alfa + beta >= delta) Then
                BMath_CheckPntInTrg = True
            End If
        End If

    End Function


End Module
