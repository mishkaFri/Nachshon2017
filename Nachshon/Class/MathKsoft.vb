Imports System.Math
Public Class MathKsoft

#Region " Constants "
    Const TolEps = 0.0001
    Const TolInters = 0.000001
    Const TolEpsAngl = 0.000001
    Const PI = System.Math.PI
    Const FLTMAX = 1000000
#End Region

    Private _coeffPerMm As Double
    Private Const Rad2Deg = 180 / System.Math.PI
    Private Const Deg2Rad = Math.PI / 180


#Region " Properties"
    Public Property CoeffPerMm() As Double
        Get
            Return _coeffPerMm
        End Get
        Set(ByVal value As Double)
            _coeffPerMm = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal CoefPerMM As Double)
        _coeffPerMm = CoefPerMM
    End Sub


#Region " 3D Vector Operation"
    ''' <summary>
    ''' Make Unit Vector 3D
    ''' </summary>
    ''' <param name="ioVect">Given Vector -> Unit Vector</param>
    ''' <remarks></remarks>
    Public Sub UnitVect(ByVal ioVect() As Double)
        Dim Lent As Double
        'Get Length of Given vector
        Lent = Me.LenVect(ioVect)
        If Lent > TolEps Then
            'calculate Unit Vector
            ioVect(0) = ioVect(0) / Lent
            ioVect(1) = ioVect(1) / Lent
            ioVect(2) = ioVect(2) / Lent
        End If
    End Sub
    ''' <summary>
    ''' Get Vector Lenght 3D
    ''' </summary>
    ''' <param name="iVect">Given Vector</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LenVect(ByVal iVect() As Double) As Double
        Dim Lent As Double
        Lent = iVect(0) * iVect(0) + _
               iVect(1) * iVect(1) + _
               iVect(2) * iVect(2)
        Lent = System.Math.Sqrt(Lent)
        Return (Lent)
    End Function
    ''' <summary>
    ''' Calculate Cross Vector 3D
    ''' </summary>
    ''' <param name="iVect1">Vector From</param>
    ''' <param name="iVect2">Vector To</param>
    ''' <param name="oVCros">Result Cross Vector</param>
    ''' <remarks></remarks>
    Public Sub CrossVect(ByVal iVect1() As Double, _
                         ByVal iVect2() As Double, _
                         ByRef oVCros() As Double)
        oVCros(0) = iVect1(1) * iVect2(2) - _
                    iVect1(2) * iVect2(1)
        oVCros(1) = -(iVect1(0) * iVect2(2) - _
                      iVect1(2) * iVect2(0))
        oVCros(2) = iVect1(0) * iVect2(1) - _
                    iVect1(1) * iVect2(0)
    End Sub
    ''' <summary>
    ''' Get Vector By 2 given Points 3D 
    ''' </summary>
    ''' <param name="iPnt1">Point From</param>
    ''' <param name="iPnt2">Point To</param>
    ''' <param name="oVect">Result Vector</param>
    ''' <remarks></remarks>
    Public Sub VectByPnt(ByVal iPnt1() As Double, _
                         ByVal iPnt2() As Double, _
                         ByRef oVect() As Double)

        oVect(0) = iPnt2(0) - iPnt1(0)
        oVect(1) = iPnt2(1) - iPnt1(1)
        oVect(2) = iPnt2(2) - iPnt1(2)
    End Sub

    ''' <summary>
    ''' Get New Point by Point From + Vector 3D
    ''' </summary>
    ''' <param name="iPnt1">Point From</param>
    ''' <param name="iVect1">Given Vector</param>
    ''' <param name="oPntNew">New Point</param>
    ''' <remarks></remarks>
    Public Sub PntAddVect(ByVal iPnt1() As Double, _
    ByVal iVect1() As Double, _
    ByRef oPntNew() As Double)
        oPntNew(0) = iPnt1(0) + iVect1(0)
        oPntNew(1) = iPnt1(1) + iVect1(1)
        oPntNew(2) = iPnt1(2) + iVect1(2)
    End Sub
    ''' <summary>
    ''' Get New Point By Point - Vector 3D
    ''' </summary>
    ''' <param name="iPnt1">Point From</param>
    ''' <param name="iVect1">Given Vector</param>
    ''' <param name="oPntNew">New Point</param>
    ''' <remarks></remarks>
    Public Sub PntMinusVect(ByVal iPnt1() As Double, _
                            ByVal iVect1() As Double, _
                            ByRef oPntNew() As Double)
        oPntNew(0) = iPnt1(0) - iVect1(0)
        oPntNew(1) = iPnt1(1) - iVect1(1)
        oPntNew(2) = iPnt1(2) - iVect1(2)
    End Sub
    ''' <summary>
    ''' Calculate Dot Vector 3D
    ''' </summary>
    ''' <param name="iVect1">Vector First</param>
    ''' <param name="iVect2">Vector Second</param>
    ''' <returns>Result Dot Vector</returns>
    ''' <remarks></remarks>
    Public Function DotVector(ByVal iVect1() As Double, _
                              ByVal iVect2() As Double) As Double
        Dim Vdot As Double

        Vdot = iVect1(0) * iVect2(0) + _
               iVect1(1) * iVect2(1) + _
               iVect1(2) * iVect2(2)

        Return (Vdot)
    End Function
    ''' <summary>
    ''' Scale Given Vector 3D
    ''' </summary>
    ''' <param name="ioVect">Given Vector</param>
    ''' <param name="iVScl">Scale Factor</param>
    ''' <remarks></remarks>
    Public Sub VectScale(ByVal ioVect() As Double, _
                         ByVal iVScl As Double)
        ioVect(0) = ioVect(0) * iVScl
        ioVect(1) = ioVect(1) * iVScl
        ioVect(2) = ioVect(2) * iVScl
    End Sub

    Public Sub VectAngDeg2rAD(ByVal ioVect() As Double)

        ioVect(0) = ioVect(0) * MathKsoft.Deg2Rad
        ioVect(1) = ioVect(1) * MathKsoft.Deg2Rad
        ioVect(2) = ioVect(2) * MathKsoft.Deg2Rad
    End Sub
    Public Sub VectAngrAD2Deg(ByVal ioVect() As Double)

        ioVect(0) = ioVect(0) * MathKsoft.Rad2Deg
        ioVect(1) = ioVect(1) * MathKsoft.Rad2Deg
        ioVect(2) = ioVect(2) * MathKsoft.Rad2Deg
    End Sub
   
    ''' <summary>
    ''' Rotate Vector About Axis
    ''' </summary>
    ''' <param name="iVctRot">Given Vector</param>
    ''' <param name="iVctAxs">Given Axis</param>
    ''' <param name="iAngl">Given Angle in Degree</param>
    ''' <param name="oVctNew">Result Vector</param>
    ''' <remarks></remarks>
    Public Sub VctRotAbtAxis(ByVal iVctRot() As Double, _
                             ByVal iVctAxs() As Double, _
                             ByVal iAngl As Double, _
                             ByRef oVctNew() As Double)
        Dim VctZ(2) As Double
        Dim VctX(2) As Double
        Dim VctY(2) As Double
        Dim AngRad As Double
        Dim VctTmp(2) As Double

        Me.CopyArrDb2Db(iVctRot, VctX, 3)
        Me.CopyArrDb2Db(iVctAxs, VctZ, 3)
        Me.CrossVect(VctZ, VctX, VctY)
        If Me.LenVect(VctY) < TolEps Then
            Me.CopyArrDb2Db(iVctRot, oVctNew, 3)
            Exit Sub
        End If
        Me.UnitVect(VctX)
        Me.UnitVect(VctY)
        Me.UnitVect(VctZ)

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
        Me.UnitVect(oVctNew)

    End Sub

#End Region

#Region " Measure"
    ''' <summary>
    ''' Distance Between Two Points 3D
    ''' </summary>
    ''' <param name="iPnt1">Point From</param>
    ''' <param name="iPnt2">Point To</param>
    ''' <returns>Calculated Distance </returns>
    ''' <remarks></remarks>
    Public Function Dist3D(ByVal iPnt1() As Double, _
                           ByVal iPnt2() As Double) As Double
        Dim VectTmp(2) As Double
        Me.VectByPnt(iPnt1, iPnt2, VectTmp)
        Return (Me.LenVect(VectTmp))
    End Function


    ''' <summary>
    ''' Distance Between Two Points 3D in Squre
    ''' </summary>
    ''' <param name="iPnt1">Point From</param>
    ''' <param name="iPnt2">Point To</param>
    ''' <returns>Calculated Distance </returns>
    ''' <remarks></remarks>
    Public Function Dist3DSqr(ByVal iPnt1() As Double, _
                              ByVal iPnt2() As Double) As Double
        Dim VectTmp(2) As Double
        Dim Len As Double
        Me.VectByPnt(iPnt1, iPnt2, VectTmp)
        Len = VectTmp(0) * VectTmp(0) + VectTmp(1) * VectTmp(1) + VectTmp(2) * VectTmp(2)
        Return (Len)
    End Function

    ''' <summary>
    ''' Get Distance 2D between Ponts in Squre
    ''' </summary>
    ''' <param name="Xfm"></param>
    ''' <param name="Yfm"></param>
    ''' <param name="Xto"></param>
    ''' <param name="Yto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Dist2DSqr(ByVal Xfm, ByVal Yfm, ByVal Xto, ByVal Yto) As Double
        Return ((Xto - Xfm) * (Xto - Xfm) + (Yto - Yfm) * (Yto - Yfm))
    End Function




    ''' <summary>
    ''' Distance Between Two Points 2D 
    ''' </summary>
    ''' <param name="iPnt1">Point From</param>
    ''' <param name="iPnt2">Point To</param>
    ''' <returns>Calculated Distance</returns>
    ''' <remarks></remarks>
    Public Function Dist2D(ByVal iPnt1() As Double, _
                           ByVal iPnt2() As Double) As Double
        Dim dVectTmp(2) As Double
        Dim dLenVct As Double

        dVectTmp(0) = iPnt2(0) - iPnt1(0)
        dVectTmp(1) = iPnt2(1) - iPnt1(1)
        dVectTmp(2) = 0

        dLenVct = Me.LenVect(dVectTmp)
        Return (dLenVct)

    End Function




    ''' <summary>
    ''' Get Distance From Point to Line 3D
    ''' </summary>
    ''' <param name="iPnt">Given Point</param>
    ''' <param name="iPLin1">Point Line Base</param>
    ''' <param name="iVectL">Line Vector</param>
    ''' <returns>Calculated Distance</returns>
    ''' <remarks>Line Vector can be free ( Not Unit) </remarks>
    Public Function DistPnt2Line(ByVal iPnt() As Double, _
                                 ByVal iPLin1() As Double, _
                                 ByVal iVectL() As Double) As Double
        '
        '          + pnt
        '          |
        '          | +D
        ' PLin1 +-------> VectL
        '          |
        '          | -D
        '          + pnt
        '

        Dim VectAxis(2) As Double
        Dim VectP(2) As Double
        Dim VectC(2) As Double
        Dim VectY(2) As Double
        Dim VectD As Double

        Me.VectByPnt(iPLin1, iPnt, VectP)
        Me.CrossVect(iVectL, VectP, VectC)
        Me.CrossVect(VectC, iVectL, VectY)
        Me.UnitVect(VectY)
        VectD = Me.DotVector(VectY, VectP)
        Return (VectD)
    End Function
    ''' <summary>
    ''' Get Distance From Point to Plane
    ''' </summary>
    ''' <param name="iPlnCoef">Plane Coefficients [4]A,B,C,D </param>
    ''' <param name="iPnt">Given Point</param>
    ''' <returns>Distance to Plane</returns>
    ''' <remarks></remarks>
    Public Function DistPnt2Pln(ByVal iPlnCoef() As Double, ByVal iPnt() As Double) As Double
        Dim dLenTmp As Double
        Dim dLenTmp1 As Double

        dLenTmp = System.Math.Sqrt(iPlnCoef(0) * iPlnCoef(0) + _
                                   iPlnCoef(1) * iPlnCoef(1) + _
                                   iPlnCoef(2) * iPlnCoef(2))

        If dLenTmp < TolEps Then
            Return (0)
        End If

        dLenTmp1 = iPlnCoef(0) * iPnt(0) + _
                   iPlnCoef(1) * iPnt(1) + _
                   iPlnCoef(2) * iPnt(2) + iPlnCoef(3)

        Return (System.Math.Abs(dLenTmp1 / dLenTmp))
    End Function

    ''' <summary>
    ''' Calculate Middle Point Between Two Given Points 3D
    ''' </summary>
    ''' <param name="iPnt1">Given 1st Point</param>
    ''' <param name="iPnt2">Given 2nd Point</param>
    ''' <param name="oPntMid">Calculated Point</param>
    ''' <remarks></remarks>
    Public Sub GetMidPnt(ByVal iPnt1() As Double, _
    ByVal iPnt2() As Double, _
    ByRef oPntMid() As Double)

        oPntMid(0) = 0.5 * (iPnt1(0) + iPnt2(0))
        oPntMid(1) = 0.5 * (iPnt1(1) + iPnt2(1))
        oPntMid(2) = 0.5 * (iPnt1(2) + iPnt2(2))

    End Sub

    ''' <summary>
    ''' Angle Between Two Given Vectors 3D
    ''' </summary>
    ''' <param name="iVct1">Given 1st Vector</param>
    ''' <param name="iVct2">Given 2nd Vector</param>
    ''' <returns>Angle between Vectors</returns>
    ''' <remarks>Return Angle in Radian</remarks>
    Public Function Angl2Vector(ByVal iVct1() As Double, _
                                ByVal iVct2() As Double) As Double
        '      / V1
        '     /
        '    /
        '   +  Algl ( Rad )
        '    \
        '     \  -
        '      \ V2
        Dim Vect1(2) As Double
        Dim Vect2(2) As Double
        Dim CosAlf As Double

        Me.CopyArrDb2Db(iVct1, Vect1, 3)
        Me.CopyArrDb2Db(iVct2, Vect2, 3)
        Me.UnitVect(Vect1)
        Me.UnitVect(Vect2)

        CosAlf = Me.DotVector(Vect1, Vect2)
        If System.Math.Abs(CosAlf) > 1 Then
            CosAlf = CosAlf / System.Math.Abs(CosAlf)
        End If
      
        Return (System.Math.Acos(CosAlf))
    End Function

    ''' <summary>
    ''' Get Absolute Angle to Given Point 2D
    ''' </summary>
    ''' <param name="iPntX">X Point coordinate</param>
    ''' <param name="iPntY">Y Point coordinate</param>
    ''' <returns>Absolute Angle</returns>
    ''' <remarks>Return Value in Degree</remarks>
    Public Function AnglAbs2D(ByVal iPntX As Double, _
                              ByVal iPntY As Double) As Double
        '          Y
        '           ^            
        '      iLenY|-- . 45     
        '           |   |       
        '   --------+-------->X
        '           |iLenx
        '   225 +   |   + 315
        '           |
        '

        Dim dVctPnt(2) As Double
        Dim dVctX(2) As Double
        Dim dVctY(2) As Double
        Dim Angl As Double
        Dim dSideByY As Double

        dVctPnt(0) = iPntX
        dVctPnt(1) = iPntY
        dVctPnt(2) = 0

        dVctX(0) = 1
        dVctX(1) = 0
        dVctX(2) = 0

        dVctY(0) = 1
        dVctY(1) = 0
        dVctY(2) = 0

        Angl = 0

        'Get Angle Between Axis X & Point Vector
        Angl = System.Math.Abs(Me.Angl2Vector(dVctX, dVctPnt))

        'Get Side Of Quadrant 
        dSideByY = Me.DotVector(dVctY, dVctPnt)

        If dSideByY < 0 Then
            Angl = System.Math.PI * 2 - Angl
        End If

        Return (Angl * 180 / System.Math.PI)

    End Function


    ' Only For 2D Event Return: False - Vectors Parall
    ''' <summary>
    '''  Get Intersection Point Between Two Lines 2D
    ''' </summary>
    ''' <param name="iPnt1">Line 1, Point From</param>
    ''' <param name="iVct1">Line 1, Vector Direction</param>
    ''' <param name="iPnt2">Line 2, Point From</param>
    ''' <param name="iVct2">Line 2, Vector Direction</param>
    ''' <param name="oPntInS">Intersection Point</param>
    ''' <returns>False = Lines are Parallel</returns>
    ''' <remarks></remarks>
    Public Function IntersTwoLineV01_2d(ByVal iPnt1() As Double, _
                                        ByVal iVct1() As Double, _
                                        ByVal iPnt2() As Double, _
                                        ByVal iVct2() As Double, _
                                        ByRef oPntInS() As Double) As Boolean
        ' Vct1      Vct2
        '   \       /
        '    \     /
        ' Pnt1+   +Pnt2
        '
        '       +PntInS
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
            Return (False)
        Else
            DeltPar1 = C * F - D * E
            DeltPar1 = DeltPar1 / Delt
            oPntInS(0) = iPnt1(0) + iVct1(0) * DeltPar1
            oPntInS(1) = iPnt1(1) + iVct1(1) * DeltPar1
        End If
        Return (True)
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
    ''' <summary>
    ''' Get Intersection Point And Parameters Between Two Lines
    ''' </summary>
    ''' <param name="iPnt1">Line 1, Start Point</param>
    ''' <param name="iVct1">Line 1, Vector Direction</param>
    ''' <param name="iPnt2">Line 2, Start Point</param>
    ''' <param name="iPnt3">Line 2, End point</param>
    ''' <param name="oPntInS">Intersection Point</param>
    ''' <param name="oParam1">Parameter on Line 1</param>
    ''' <param name="oParam2">Parameter on Line 2</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IntersTwoLine3D(ByVal iPnt1() As Double, _
                                    ByVal iVct1() As Double, _
                                    ByVal iPnt2() As Double, _
                                    ByVal iPnt3() As Double, _
                                    ByRef oPntInS() As Double, _
                                    ByRef oParam1 As Double, _
                                    ByRef oParam2 As Double) As Boolean
        ' Vct1       + Pnt3
        '   \       /
        '    \     /
        ' Pnt1+   +Pnt2
        '
        '       +PntInS
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
            Return (False)
        Else
            DeltPar1 = C * F - D * E
            DeltPar2 = A * F - B * E
            oParam1 = DeltPar1 / Delt
            oParam2 = DeltPar2 / Delt
            oPntInS(0) = iPnt1(0) + iVct1(0) * oParam1
            oPntInS(1) = iPnt1(1) + iVct1(1) * oParam1
            oPntInS(2) = iPnt1(2) + iVct1(2) * oParam1
        End If

        Return (True)

    End Function

    ''' <summary>
    ''' Get Intersection Point between Two Lines 2D
    ''' </summary>
    ''' <param name="iPntL1S">Line 1, Start Point </param>
    ''' <param name="iPntL1E">Line 1, End Point</param>
    ''' <param name="iPntL2S">Line 2, Start Point</param>
    ''' <param name="iPntL2E">Line 2, End Point</param>
    ''' <param name="oPntIntr">Intersection Point</param>
    ''' <param name="oParL1">Parameter on Line 1</param>
    ''' <param name="oParL2">Parameter on Line 2</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IntersecTwoLineV02_2D(ByVal iPntL1S() As Double, _
                                          ByVal iPntL1E() As Double, _
                                          ByVal iPntL2S() As Double, _
                                          ByVal iPntL2E() As Double, _
                                          ByRef oPntIntr() As Double, _
                                          ByRef oParL1 As Double, _
                                          ByRef oParL2 As Double) As Boolean
        '       iPntL1S +       + iPntL2S
        '                \     /
        '                 \   /
        '                  \ /              For This Case: Return = TRUE
        '                   + oPntIntr
        '                  / \
        '                 /   \
        '       iPntL2E  +     + iPntL1E
        Dim A As Double
        Dim B As Double
        Dim C As Double
        Dim D As Double
        Dim E As Double
        Dim H As Double
        Dim Dsc As Double
        Dim Dsc1 As Double

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
            Return (False)
        End If

        Dsc1 = E * D - H * B
        oParL1 = Dsc1 / Dsc

        Dsc1 = A * H - E * C
        oParL2 = Dsc1 / Dsc

        oPntIntr(0) = iPntL1S(0) + A * oParL1
        oPntIntr(1) = iPntL1S(1) + C * oParL1

        Return (True)

    End Function

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
    Public Function IntersecLineFull3D(ByVal iPnt1() As Double, _
                                       ByVal iVct1() As Double, _
                                       ByVal iPnt2() As Double, _
                                       ByVal iVct2() As Double, _
                                       ByRef oPntInS() As Double) As Boolean
        Dim VctCros1(2) As Double
        Dim VctCros2(2) As Double
        Dim PlnC(3) As Double
        Dim RetValBool As Boolean

        RetValBool = False

        'Get Vector Normal For Two Given Vectors
        Me.CrossVect(iVct1, iVct2, VctCros1)
        Me.UnitVect(VctCros1)
        'Get Vector Normal By Perpendic
        Me.CrossVect(VctCros1, iVct1, VctCros2)
        Me.UnitVect(VctCros2)
        'Get Coeff. Plane
        Me.PlaneByPntAndVect(iPnt1, VctCros2, PlnC)
        Me.UnitVect(PlnC)
        'Get Intersect Line & Plane
        RetValBool = Me.IntersLinePlane(iPnt2, iVct2, PlnC, oPntInS)

        Return (RetValBool)

    End Function
    ''' <summary>
    ''' get the length value of the part of a vector that will become bent with givven bend radius 
    ''' </summary>
    ''' <param name="dPntFm">start point for the first vec</param>
    ''' <param name="dPntTo">end point for the second vec</param>
    ''' <param name="dPntM">end point for first and start for the second vec</param>
    ''' <param name="Rad">future bend radius</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BentDeltaLen(ByVal dPntFm() As Double, _
                                   ByVal dPntTo() As Double, _
                                   ByVal dPntM() As Double, _
                                   ByVal Rad As Double) As Double
        Dim dVct2Fm(2) As Double
        Dim dVct2To(2) As Double
        Dim dAngl As Double
        Dim dDelt As Double

        Me.VectByPnt(dPntM, dPntFm, dVct2Fm)
        Me.VectByPnt(dPntM, dPntTo, dVct2To)
        dAngl = Me.Angl2Vector(dVct2Fm, dVct2To)
        If Abs(dAngl) < 0.001 Then
            Return (0)
        End If
        dDelt = Rad / Tan(0.5 * dAngl)
        Return (dDelt)
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
    Public Function IntersLinePlane(ByVal iPln() As Double, _
                                    ByVal iVln() As Double, _
                                    ByVal iPCof() As Double, _
                                    ByRef oPnt() As Double) As Boolean

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
            Me.CopyArrDb2Db(iPln, oPnt, 3)
            Return (False)
        Else
            Param = -(Numerat / Denominat)
            oPnt(0) = iPln(0) + iVln(0) * Param
            oPnt(1) = iPln(1) + iVln(1) * Param
            oPnt(2) = iPln(2) + iVln(2) * Param
            Return (True)
        End If
    End Function

    Public Function BentDataAll(ByVal PntFm() As Double, ByVal VctAxs() As Double, _
    ByVal L1 As Double, ByVal L2 As Double, ByVal RadBent As Double, _
    ByVal Ang As Double) As Boolean

        Return (True)
    End Function

    ''' <summary>
    ''' Calculate Bent Param by Given 2  intersect Lines
    ''' </summary>
    ''' <param name="PntVrx">Given Vertex</param>
    ''' <param name="PntFm">Given Point From</param>
    ''' <param name="PntTo">Given point To</param>
    ''' <param name="RadBent">Radius Bent</param>
    ''' <param name="PntS">Output Start Bent</param>
    ''' <param name="PntM">Output Middle Bent</param>
    ''' <param name="PntE">Output End Bent</param>
    ''' <param name="PntC">Output Center Bent</param>
    ''' <returns>True: Calculation is OK</returns>
    ''' <remarks></remarks>
    ''' 
    Public Function BentDataCalcul(ByVal PntVrx() As Double, ByVal PntFm() As Double, _
                                   ByVal PntTo() As Double, ByVal RadBent As Double, _
                                   ByRef PntS() As Double, ByRef PntM() As Double, _
                                   ByRef PntE() As Double, ByRef PntC() As Double) As Boolean
        '
        '         Vrx         E
        '          +----------+-----------+ To                                                                                          
        '          |   M    * |                                                                         
        '          |    *     | R                                                                       
        '          |          |                                                                         
        '          | *        |                                                                         
        '       S  +----------+ C                                                                      
        '          |                                                                                    
        '          |                                                                                    
        '          |                                                                                    
        '          |
        '    Fm    +                                                                                     
        '
        Dim RetValBool As Boolean
        Dim VctV2Fm(2) As Double
        Dim VctV2To(2) As Double
        Dim VctTmp(2) As Double
        Dim PntTmp(2) As Double
        Dim LenEdge As Double
        Dim Alfa As Double

        RetValBool = False

        Me.VectByPnt(PntVrx, PntFm, VctV2Fm)
        Me.UnitVect(VctV2Fm)
        Me.VectByPnt(PntVrx, PntTo, VctV2To)
        Me.UnitVect(VctV2To)

        'Check whether Vectors are not coincided
        LenEdge = Me.DotVector(VctV2Fm, VctV2To)
        If Math.Abs(LenEdge) > 1 - TolEpsAngl Then
            Return (RetValBool)
        End If

        'Get Angle Between Vectors
        Alfa = Me.Angl2Vector(VctV2Fm, VctV2To)
        LenEdge = RadBent / System.Math.Tan(Alfa * 0.5)

        'Start Point
        Me.VectScale(VctV2Fm, LenEdge)
        Me.PntAddVect(PntVrx, VctV2Fm, PntS)
        'End Point 
        Me.VectScale(VctV2To, LenEdge)
        Me.PntAddVect(PntVrx, VctV2To, PntE)
        'Center Point
        Me.GetMidPnt(PntS, PntE, PntTmp)
        Me.VectByPnt(PntVrx, PntTmp, VctTmp)
        Me.UnitVect(VctTmp)
        LenEdge = RadBent / System.Math.Sin(Alfa * 0.5)
        Me.VectScale(VctTmp, LenEdge)
        Me.PntAddVect(PntVrx, VctTmp, PntC)

        'Middle Point 
        Me.VectByPnt(PntC, PntVrx, VctTmp)
        Me.UnitVect(VctTmp)
        Me.VectScale(VctTmp, RadBent)
        Me.PntAddVect(PntC, VctTmp, PntM)

        RetValBool = True
        Return (RetValBool)

    End Function



#End Region

#Region " Plane "
    ''' <summary>
    ''' Calculate Distance from Given Point to Given Plane
    ''' </summary>
    ''' <param name="iPnt">Given Point 3D</param>
    ''' <param name="iPlnCoef">Plane Coefficients(A,B,C,D)</param>
    ''' <returns>Calculated Distance</returns>
    ''' <remarks></remarks>
    Public Function DistPntPlane(ByVal iPnt() As Double, ByVal iPlnCoef() As Double) As Double
        Return (Me.DotVector(iPnt, iPlnCoef) + iPlnCoef(3))
    End Function

    ''' <summary>
    ''' Check Whether Given Point Belongs to Given Plane
    ''' </summary>
    ''' <param name="iPnt">Given Point</param>
    ''' <param name="iCoefPln">Given Plane [4] (A,B,C,D)</param>
    ''' <returns>True = On Plane, False = Outside</returns>
    ''' <remarks></remarks>
    Public Function CheckPntOnPlane(ByVal iPnt() As Double, _
                                    ByVal iCoefPln() As Double) As Boolean
        Dim dTmpVal As Double

        dTmpVal = iPnt(0) * iCoefPln(0)
        dTmpVal = dTmpVal + iPnt(1) * iCoefPln(1)
        dTmpVal = dTmpVal + iPnt(2) * iCoefPln(2)
        dTmpVal = dTmpVal + iCoefPln(3)

        If Abs(dTmpVal) > TolEps * 100 Then
            Return (False)
        End If
        Return (True)

    End Function

    ' Map Given Point to Given Plane
    ' Input: iPlnTransf(8) - Plane Transform. Matrix
    '        iPnt(2)       - Given Pnt
    '        oPnt(2)       - Mapped Point

    ''' <summary>
    ''' Map Given Point to Given Plane
    ''' </summary>
    ''' <param name="iPlnTransf">Plane Transform. Matrix [9] (UCS of Plane)</param>
    ''' <param name="iPnt">Given Point 3D</param>
    ''' <param name="oPnt">Transformated Point</param>
    ''' <remarks></remarks>
    Public Sub BMath_MapPnt2Pln(ByVal iPlnTransf() As Double, _
                                ByVal iPnt() As Double, _
                                ByVal oPnt() As Double)

        Dim VectTmp(2) As Double

        Me.CopyArrDb2DbByIndx(iPlnTransf, 0, VectTmp, 0, 3)
        oPnt(0) = Me.DotVector(VectTmp, iPnt)

        Me.CopyArrDb2DbByIndx(iPlnTransf, 3, VectTmp, 0, 3)
        oPnt(1) = Me.DotVector(VectTmp, iPnt)

        Me.CopyArrDb2DbByIndx(iPlnTransf, 6, VectTmp, 0, 3)
        oPnt(2) = Me.DotVector(VectTmp, iPnt)

    End Sub

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
    Public Sub PlaneByPntAndVect(ByVal iPnt() As Double, _
                                 ByVal iVct() As Double, _
                                 ByRef oPCof() As Double)
        Me.CopyArrDb2Db(iVct, oPCof, 3)
        Me.UnitVect(oPCof)
        oPCof(3) = -(oPCof(0) * iPnt(0) + _
                     oPCof(1) * iPnt(1) + _
                     oPCof(2) * iPnt(2))

    End Sub

    Public Function PlaneBy3Pnt(ByRef iPnt1() As Double, _
                                ByRef iPnt2() As Double, _
                                ByRef iPnt3() As Double, _
                                ByRef oPCof() As Double) As Boolean
        Dim RetValBool As Boolean
        Dim dVctTmp1(2) As Double
        Dim dVctTmp2(2) As Double
        Dim dVctCros(2) As Double
        Dim dLenVct As Double

        RetValBool = False

        Me.VectByPnt(iPnt1, iPnt2, dVctTmp1)
        Me.UnitVect(dVctTmp1)
        Me.VectByPnt(iPnt1, iPnt3, dVctTmp2)
        Me.UnitVect(dVctTmp2)

        Me.CrossVect(dVctTmp1, dVctTmp2, dVctCros)
        Me.UnitVect(dVctCros)

        'Check whether Vector Norm is Not 0
        dLenVct = Me.LenVect(dVctCros)
        If dLenVct < TolEps * 0.01 Then
            Return (RetValBool)
        End If

        Me.PlaneByPntAndVect(iPnt1, dVctCros, oPCof)

        RetValBool = True
        Return (RetValBool)
    End Function

    'Projection Point on Given Plane
    Public Sub PrjPnt2Pln(ByRef iPnt() As Double, _
                          ByRef iPln() As Double, _
                          ByRef oPnt() As Double)

        Dim RetValBool As Integer
        Dim TmpPnt(2) As Double

        RetValBool = Me.IntersLinePlane(iPnt, iPln, iPln, TmpPnt)

        If RetValBool = True Then
            oPnt(0) = TmpPnt(0)
            oPnt(1) = TmpPnt(1)
            oPnt(2) = TmpPnt(2)
        Else
            oPnt(0) = iPnt(0)
            oPnt(1) = iPnt(1)
            oPnt(2) = iPnt(2)
        End If
    End Sub


#End Region

#Region " Copy Array"

    Public Sub ResetArray(ByRef Arr() As Double, ByVal NArr As Integer)
        For ch As Integer = 0 To NArr - 1
            Arr(ch) = 0
        Next ch
    End Sub

    ''' <summary>
    ''' Copy Array double 
    ''' </summary>
    ''' <param name="iArrFrom">Source Array</param>
    ''' <param name="oArrTo">Target Array</param>
    ''' <param name="iNArr">Number elements to Copy</param>
    ''' <remarks></remarks>
    Public Sub CopyArrDb2Db(ByVal iArrFrom() As Double, _
                            ByVal oArrTo() As Double, _
                            ByVal iNArr As Integer)
        Dim i As Integer

        For i = 0 To iNArr - 1
            oArrTo(i) = iArrFrom(i)
        Next i
    End Sub

    ''' <summary>
    ''' Copy double Array from Index to other Array from Index 
    ''' </summary>
    ''' <param name="iArrFm">Source Array</param>
    ''' <param name="iIdxFm">Start Index</param>
    ''' <param name="oArrTo">Target Array</param>
    ''' <param name="iIdxTo">Start Index</param>
    ''' <param name="iNArr">Number Elements to Copy</param>
    ''' <remarks></remarks>
    Public Sub CopyArrDb2DbByIndx(ByVal iArrFm() As Double, _
                                  ByVal iIdxFm As Long, _
                                  ByVal oArrTo() As Double, _
                                  ByVal iIdxTo As Long, _
                                  ByVal iNArr As Long)

        Dim ch As Integer

        For ch = 0 To iNArr - 1
            oArrTo(iIdxTo + ch) = iArrFm(iIdxFm + ch)
        Next ch

    End Sub

    Public Function EqualDoubleArrayByTol(ByVal Arr1() As Double, ByVal Arr2() As Double, ByVal tolerance As Double) As Boolean
        If Not Arr1.Length = Arr2.Length Then
            Return False
        End If
        Dim d As Double

        For i As Integer = 0 To Arr1.Length - 1
            d = Arr1(i) - Arr2(i)
            If d > tolerance Then
                Return False
            End If
        Next
        Return True
    End Function

#End Region

#Region " Box Operation "

    ''' <summary>
    ''' Initialization of Ortogonal BOX (Array of Double)
    ''' </summary>
    ''' <param name="ioBox">Box Array [5] </param>
    ''' <remarks></remarks>
    Public Sub IniBox(ByVal ioBox() As Double)

        ioBox(0) = FLTMAX
        ioBox(1) = FLTMAX
        ioBox(2) = FLTMAX
        ioBox(3) = -FLTMAX
        ioBox(4) = -FLTMAX
        ioBox(5) = -FLTMAX
    End Sub
    'Add Box to Box that Already Existed]
    ''' <summary>
    ''' Add Box to already Existed Box 
    ''' </summary>
    ''' <param name="ioBoxExist">Existed Box [5]</param>
    ''' <param name="iBox2Add">Box to Add [5]</param>
    ''' <remarks></remarks>
    Public Sub AddBox2Box(ByVal ioBoxExist() As Double, _
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

    'Add Given Point To Box Thet Alrerady Existed
    ''' <summary>
    ''' Add Given Point To already Existed Box
    ''' </summary>
    ''' <param name="ioBoxExist">Existed Box [5]</param>
    ''' <param name="iPnt2Add">Given Point 3D</param>
    ''' <remarks></remarks>
    Public Sub AddPnt2Box(ByVal ioBoxExist() As Double, _
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

    ''' <summary>
    ''' Get Minimum Distance Between TWO given Boxes
    ''' </summary>
    ''' <param name="box1">Given 1st Box [6]</param>
    ''' <param name="box2">Given 2nd Box [6]</param>
    ''' <param name="len_inp">Given Tolerance</param>
    ''' <returns>minimal Distance</returns>
    ''' <remarks>not used function</remarks>
    Public Function MinDist2Box(ByVal box1() As Double, _
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
            Return (dist_min)
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
            Return (dist_min)
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
            Return (dist_min)
        End If

        Return (dist_min)

    End Function

    ''' <summary>
    ''' Check Whether Given Point into Given Box
    ''' </summary>
    ''' <param name="iPnt">Given Point 3D</param>
    ''' <param name="iBox">Given Box [6]</param>
    ''' <param name="iToler">Given Tolerance</param>
    ''' <returns>True = Point into Box</returns>
    ''' <remarks>Tolerance for Boundary Solution </remarks>
    Public Function CheckPntInBox(ByVal iPnt() As Double, _
                                  ByVal iBox() As Double, _
                                  ByVal iToler As Double) As Boolean

        If (iPnt(0) >= iBox(0) - iToler) And (iPnt(0) <= iBox(3) + iToler) Then
            If (iPnt(1) >= iBox(1) - iToler) And (iPnt(1) <= iBox(4) + iToler) Then
                If (iPnt(2) >= iBox(2) - iToler) And (iPnt(2) <= iBox(5) + iToler) Then
                    Return (True)
                End If
            End If
        End If

        Return (False)

    End Function


    ''' <summary>
    ''' Check Whether Given Point into Given Triangle
    ''' </summary>
    ''' <param name="iPnt">Given Point 3D</param>
    ''' <param name="iTrg">Given Triangle [9] (three points )</param>
    ''' <returns>True = Into Triangle, False = Outside</returns>
    ''' <remarks></remarks>
    Public Function CheckPntInTrg(ByVal iPnt() As Double, _
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

        dR(0) = iPnt(0) - iTrg(0)
        dR(1) = iPnt(1) - iTrg(1)
        dR(2) = iPnt(2) - iTrg(2)

        e1(0) = iTrg(3) - iTrg(0)
        e1(1) = iTrg(4) - iTrg(1)
        e1(2) = iTrg(5) - iTrg(2)

        e2(0) = iTrg(6) - iTrg(0)
        e2(1) = iTrg(7) - iTrg(1)
        e2(2) = iTrg(8) - iTrg(2)

        e1e1 = Me.DotVector(e1, e1)
        e2e2 = Me.DotVector(e2, e2)
        e1e2 = Me.DotVector(e1, e2)
        dre1 = Me.DotVector(dR, e1)
        dre2 = Me.DotVector(dR, e2)

        delta = e1e1 * e2e2 - e1e2 * e1e2
        alfa = dre1 * e2e2 - e1e2 * dre2
        beta = e1e1 * dre2 - dre1 * e1e2

        If delta > 0 Then

            If alfa >= 0 And beta >= 0 And (alfa + beta <= delta) Then
                Return (True)
            End If
        ElseIf delta < 0 Then
            If alfa <= 0 And beta <= 0 And (alfa + beta >= delta) Then
                Return (True)
            End If
        End If

        Return (False)

    End Function

    'By Given Two Boxes Get Common Area ( for 2D Only )
    'Input:  iBox1(3)  As  Double  - 1st Box (2d)
    '        iBox2(3)  As  Double  - 2nd Box (2d)
    'Output: oBox(3)   As  Double  - Common Box
    'Return: Boolean: False - Not common Area, True - Yes

    ''' <summary>
    ''' By Given Two Boxes Get Common Area 2D Only 
    ''' </summary>
    ''' <param name="iBox1">Given 1st Box [4] </param>
    ''' <param name="iBox2">Given 2nd Box [4] </param>
    ''' <param name="oBox">Common Box [4]</param>
    ''' <returns>True = Common Box Found, False = not common area</returns>
    ''' <remarks></remarks>
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

        'If Minim. Box2 > Maxim Box1
        If iBox2(0) > iBox1(2) Then
            Return (False)
        End If
        If iBox2(1) > iBox1(3) Then
            Return (False)
        End If

        'if Maxim Box2 < Minim Box1
        If iBox2(2) < iBox1(0) Then
            Return (False)
        End If
        If iBox2(3) < iBox1(1) Then
            Return (False)
        End If

        ArrX(0) = iBox1(0)
        ArrX(1) = iBox1(2)
        ArrX(2) = iBox2(0)
        ArrX(3) = iBox2(2)
        RetValIntg = Me.SortArrDbl(ArrX, 4)


        ArrY(0) = iBox1(1)
        ArrY(1) = iBox1(3)
        ArrY(2) = iBox2(1)
        ArrY(3) = iBox2(3)
        RetValIntg = Me.SortArrDbl(ArrY, 4)

        oBox(0) = ArrX(1)
        oBox(1) = ArrY(1)
        oBox(2) = ArrX(2)
        oBox(3) = ArrY(2)
        Return (True)
    End Function

    ''' <summary>
    ''' Sort Double Array
    ''' </summary>
    ''' <param name="ioArrDbl">Given Double Array</param>
    ''' <param name="NArr">Size of Array</param>
    ''' <returns>Number Swap Operation</returns>
    ''' <remarks></remarks>
    Public Function SortArrDbl(ByVal ioArrDbl() As Double, _
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

        Return (Count)
    End Function

#End Region

#Region " Matrix"
    ''' <summary>
    ''' Initialization Unit Matrix [9]
    ''' </summary>
    ''' <param name="CurMatrx">Matrix to be Unit</param>
    ''' <remarks>Unit Matrix - Diagonal = 1</remarks>
    Public Sub UnitMatrx(ByVal CurMatrx() As Double)

        CurMatrx(0) = 1
        CurMatrx(1) = 0
        CurMatrx(2) = 0
        CurMatrx(3) = 0
        CurMatrx(4) = 1
        CurMatrx(5) = 0
        CurMatrx(6) = 0
        CurMatrx(7) = 0
        CurMatrx(8) = 1
    End Sub

    Public Sub MatrxRepairSE(ByRef curMatx() As Double)
        Dim dVctX(2) As Double
        Dim dVctY(2) As Double
        Dim dVctZ(2) As Double

        Me.CopyArrDb2DbByIndx(curMatx, 0, dVctX, 0, 3)
        Me.UnitVect(dVctX)
        Me.CopyArrDb2DbByIndx(dVctX, 0, curMatx, 0, 3)

        Me.CopyArrDb2DbByIndx(curMatx, 4, dVctY, 0, 3)
        Me.UnitVect(dVctY)
        Me.CopyArrDb2DbByIndx(dVctY, 0, curMatx, 4, 3)

        Me.CrossVect(dVctX, dVctY, dVctZ)
        Me.UnitVect(dVctZ)
        Me.CopyArrDb2DbByIndx(dVctZ, 0, curMatx, 8, 3)

    End Sub




    ''' <summary>
    ''' Initialization SE Unit Matrix [16] ( for Assembly Placement )
    ''' </summary>
    ''' <param name="CurMatrx">matrix to be Unit</param>
    ''' <remarks>Matrix Structure see SE matrix</remarks>
    Public Sub UnitMatrxSE(ByVal CurMatrx() As Double)

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
    End Sub
    ''' <summary>
    ''' Transport ( Inversion Matrix) 3x3   
    ''' </summary>
    ''' <param name="iMatrx">Given Matrix</param>
    ''' <param name="oMatrx">Result Matrix</param>
    ''' <remarks></remarks>
    Public Sub TransportMatrx(ByVal iMatrx() As Double, _
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
    ''' <summary>
    ''' Multiply Given Vector to Given Matrix(3x3)
    ''' </summary>
    ''' <param name="iVct">Given Vector</param>
    ''' <param name="iMtrx">Given Matrix</param>
    ''' <param name="oVct">Result Vector</param>
    ''' <remarks></remarks>
    Public Sub MultVect3DByMatx(ByVal iVct() As Double, _
                                ByVal iMtrx() As Double, _
                                ByVal oVct() As Double)
        Dim VectTmp(2) As Double

        VectTmp(0) = iMtrx(0)
        VectTmp(1) = iMtrx(1)
        VectTmp(2) = iMtrx(2)
        oVct(0) = Me.DotVector(VectTmp, iVct)

        VectTmp(0) = iMtrx(3)
        VectTmp(1) = iMtrx(4)
        VectTmp(2) = iMtrx(5)
        oVct(1) = Me.DotVector(VectTmp, iVct)

        VectTmp(0) = iMtrx(6)
        VectTmp(1) = iMtrx(7)
        VectTmp(2) = iMtrx(8)
        oVct(2) = Me.DotVector(VectTmp, iVct)

    End Sub

    Public Sub Mult3DMatx23DMatrx(ByVal M1() As Double, ByVal M2() As Double, ByRef MM() As Double)

        MM(0) = M1(0) * M2(0) + M1(1) * M2(3) + M1(2) * M2(6)
        MM(1) = M1(0) * M2(1) + M1(1) * M2(4) + M1(2) * M2(7)
        MM(2) = M1(0) * M2(2) + M1(1) * M2(5) + M1(2) * M2(8)

        MM(3) = M1(3) * M2(0) + M1(4) * M2(3) + M1(5) * M2(6)
        MM(4) = M1(3) * M2(1) + M1(4) * M2(4) + M1(5) * M2(7)
        MM(5) = M1(3) * M2(2) + M1(4) * M2(5) + M1(5) * M2(8)

        MM(6) = M1(6) * M2(0) + M1(7) * M2(3) + M1(8) * M2(6)
        MM(7) = M1(6) * M2(1) + M1(7) * M2(4) + M1(8) * M2(7)
        MM(8) = M1(6) * M2(2) + M1(7) * M2(5) + M1(8) * M2(8)

    End Sub
    ''' <summary>
    ''' Create Transform Rotatation Matrix By Given Axis and Angle ( Degree)
    ''' </summary>
    ''' <param name="VctAxs">Rotation Axis</param>
    ''' <param name="Angl">Given Angle (Degree)</param>
    ''' <param name="Mtx">Result Matrix</param>
    ''' <remarks></remarks>
    Public Sub MatxRotByAxisAngl(ByVal VctAxs() As Double, ByVal Angl As Double, ByRef Mtx() As Double)
        Dim VctCur(2) As Double
        Dim VctNew(2) As Double

        ' Me.UnitMatrx(Mtx)

        Me.CopyArrDb2DbByIndx(Mtx, 0, VctCur, 0, 3)
        Me.VctRotAbtAxis(VctCur, VctAxs, Angl, VctNew)
        Me.CopyArrDb2DbByIndx(VctNew, 0, Mtx, 0, 3)

        Me.CopyArrDb2DbByIndx(Mtx, 3, VctCur, 0, 3)
        Me.VctRotAbtAxis(VctCur, VctAxs, Angl, VctNew)
        Me.CopyArrDb2DbByIndx(VctNew, 0, Mtx, 3, 3)

        Me.CopyArrDb2DbByIndx(Mtx, 6, VctCur, 0, 3)
        Me.VctRotAbtAxis(VctCur, VctAxs, Angl, VctNew)
        Me.CopyArrDb2DbByIndx(VctNew, 0, Mtx, 6, 3)
    End Sub

    Public Sub MatxSERotByAxisAngl(ByVal VctAxs() As Double, ByVal Angl As Double, ByRef Mtx() As Double)
        Dim M1(8) As Double

        Me.CopyArrDb2DbByIndx(Mtx, 0, M1, 0, 3)
        Me.CopyArrDb2DbByIndx(Mtx, 4, M1, 3, 3)
        Me.CopyArrDb2DbByIndx(Mtx, 8, M1, 6, 3)
        ' Me.UnitMatrx(M1)
        MatxRotByAxisAngl(VctAxs, Angl, M1)

        Me.CopyArrDb2DbByIndx(M1, 0, Mtx, 0, 3)
        Me.CopyArrDb2DbByIndx(M1, 3, Mtx, 4, 3)
        Me.CopyArrDb2DbByIndx(M1, 6, Mtx, 8, 3)


    End Sub

    ''' <summary>
    ''' Calculate Rotation Angles for Given Transf Matrix[9] 
    ''' </summary>
    ''' <param name="MM">Given Matrix</param>
    ''' <param name="Ang">Output Angles (Degree)</param>
    ''' <remarks></remarks>
    Public Sub Matx2Angls(ByVal MM() As Double, ByRef Ang() As Double)
        Dim MatxUnit(8) As Double
        Dim Mtx(8) As Double
        Dim Mtx_tmp(8) As Double
        Dim M_New(8) As Double
        Dim VctAxs(2) As Double
        Dim CurVct(2) As Double
        Dim dCosA As Double
        Dim dVctCrs(2) As Double
        Dim dLenTmp As Double
        'Dim dSinA As Double

        Me.UnitMatrx(MatxUnit)

        'Angle Rotate About Z 
        Me.CopyArrDb2DbByIndx(MatxUnit, 0, VctAxs, 0, 3)
        Me.CopyArrDb2DbByIndx(MM, 0, CurVct, 0, 3)
        CurVct(2) = 0
        Me.UnitVect(CurVct)

        Me.CrossVect(VctAxs, CurVct, dVctCrs)
        dLenTmp = Me.LenVect(dVctCrs)
        If System.Math.Abs(dLenTmp) < 0.0001 Then
            dLenTmp = 0
        End If

        Ang(2) = 0
        '    If dLenTmp <> 0 Then
        Ang(2) = Me.Angl2Vector(VctAxs, CurVct)
        '     End If
        Ang(2) *= 180 / System.Math.PI

        Me.CopyArrDb2DbByIndx(MatxUnit, 6, VctAxs, 0, 3)

        dLenTmp = Me.DotVector(dVctCrs, VctAxs)
        If dLenTmp < 0 Then
            Ang(2) *= -1
        End If

        'Create Matrix About Z 
        Me.CopyArrDb2DbByIndx(MatxUnit, 6, VctAxs, 0, 3)
        Me.UnitMatrx(Mtx)
        MatxRotByAxisAngl(VctAxs, Ang(2), Mtx)
        'Get Previous 
        Me.TransportMatrx(Mtx, Mtx_tmp)
        Me.Mult3DMatx23DMatrx(MM, Mtx_tmp, Mtx)

        'Angle Rotate About X
        Me.CopyArrDb2DbByIndx(Mtx, 0, CurVct, 0, 3)
        Me.CopyArrDb2DbByIndx(MatxUnit, 0, VctAxs, 0, 3)
        Me.CrossVect(VctAxs, CurVct, dVctCrs)
        dCosA = Me.DotVector(VctAxs, CurVct)
        dCosA = Math.Acos(dCosA)
        dLenTmp = Me.LenVect(dVctCrs)
        If System.Math.Abs(dLenTmp) < 0.0001 Then
            dLenTmp = 0
        End If

        Ang(1) = 0
        'If dLenTmp <> 0 Then
        Ang(1) = Me.Angl2Vector(VctAxs, CurVct)
        'End If
        Ang(1) *= 180 / System.Math.PI

        Me.CopyArrDb2DbByIndx(MatxUnit, 3, VctAxs, 0, 3)
        dLenTmp = Me.DotVector(dVctCrs, VctAxs)
        If dLenTmp < 0 Then
            Ang(1) *= -1
        End If

        'Create Matrix About Y
        Me.CopyArrDb2DbByIndx(MatxUnit, 3, VctAxs, 0, 3)
        Me.UnitMatrx(M_New)
        MatxRotByAxisAngl(VctAxs, Ang(1), M_New)
        Me.TransportMatrx(M_New, Mtx_tmp)
        Me.Mult3DMatx23DMatrx(Mtx, Mtx_tmp, M_New)

        'Angle Rotate About Y
        Me.CopyArrDb2DbByIndx(M_New, 3, CurVct, 0, 3)
        Me.CopyArrDb2DbByIndx(MatxUnit, 3, VctAxs, 0, 3)
        Me.CrossVect(VctAxs, CurVct, dVctCrs)
        dLenTmp = Me.LenVect(dVctCrs)
        If System.Math.Abs(dLenTmp) < 0.0001 Then
            dLenTmp = 0
        End If

        Ang(0) = 0
        '    If dLenTmp <> 0 Then
        Ang(0) = Me.Angl2Vector(VctAxs, CurVct)
        'End If
        Ang(0) *= 180 / System.Math.PI

        Me.CopyArrDb2DbByIndx(MatxUnit, 0, VctAxs, 0, 3)
        dLenTmp = Me.DotVector(dVctCrs, VctAxs)
        If dLenTmp < 0 Then
            Ang(0) *= -1
        End If

    End Sub
    ''' <summary>
    '''  Calculate Rotation Angles for Given SE Transf Matrix[16] 
    ''' </summary>
    ''' <param name="MM">Given SE Matrix</param>
    ''' <param name="Ang">Output Angles</param>
    ''' <remarks></remarks>
    Public Sub MatxSE2Angls(ByVal MM() As Double, ByRef Ang() As Double)
        Dim MM_1(8) As Double

        'Prepare Matrix 
        Me.CopyArrDb2DbByIndx(MM, 0, MM_1, 0, 3)
        Me.CopyArrDb2DbByIndx(MM, 4, MM_1, 3, 3)
        Me.CopyArrDb2DbByIndx(MM, 8, MM_1, 6, 3)

        Me.Matx2Angls(MM_1, Ang)

    End Sub

    ''' <summary>
    '''  Calculate Simple Matrix By Given Angles 
    ''' </summary>
    ''' <param name="Ang"></param>
    ''' <param name="MM"></param>
    ''' <remarks></remarks>
    Public Sub MatxAngl2Matx(ByVal Ang() As Double, ByRef MM() As Double)
        Dim M_X(8) As Double
        Dim M_Y(8) As Double
        Dim M_Z(8) As Double
        Dim M_Unit(8) As Double
        Dim M_tmp(8) As Double
        Dim VctAxs(2) As Double

        Me.UnitMatrx(M_Unit)

        Me.CopyArrDb2DbByIndx(M_Unit, 0, VctAxs, 0, 3)
        Me.UnitMatrx(M_X)
        MatxRotByAxisAngl(VctAxs, Ang(0), M_X)

        Me.CopyArrDb2DbByIndx(M_Unit, 3, VctAxs, 0, 3)
        Me.UnitMatrx(M_Y)
        MatxRotByAxisAngl(VctAxs, Ang(1), M_Y)

        Me.CopyArrDb2DbByIndx(M_Unit, 6, VctAxs, 0, 3)
        Me.UnitMatrx(M_Z)
        MatxRotByAxisAngl(VctAxs, Ang(2), M_Z)

        Me.Mult3DMatx23DMatrx(M_X, M_Y, M_tmp)
        Me.Mult3DMatx23DMatrx(M_tmp, M_Z, MM)

    End Sub
    ''' <summary>
    ''' Calculate SE Matrix By Given Angles 
    ''' </summary>
    ''' <param name="Ang">Given Angles (Degree)</param>
    ''' <param name="MM">SE Matrix [16]</param>
    ''' <remarks></remarks>
    Public Sub MatxAngl2MatxSE(ByVal Ang() As Double, ByRef MM() As Double)
        Dim MM_1(8) As Double

        MatxAngl2Matx(Ang, MM_1)

        Me.CopyArrDb2DbByIndx(MM_1, 0, MM, 0, 3)
        Me.CopyArrDb2DbByIndx(MM_1, 3, MM, 4, 3)
        Me.CopyArrDb2DbByIndx(MM_1, 6, MM, 8, 3)

    End Sub

    ''' <summary>
    ''' Create UCS Matrix By Given Line ( 2 Points ) Line is X dir of Matrix 
    ''' </summary>
    ''' <param name="dPntFm">Start Line Point</param>
    ''' <param name="dPntTo">End Line Point</param>
    ''' <param name="Mx">Result Matrix</param>
    ''' <remarks></remarks>
    Public Sub MatxSEUcsByLine(ByVal dPntFm() As Double, ByVal dPntTo() As Double, ByRef Mx() As Double)
        Dim dVctDir(2) As Double
        Dim dVctX(2) As Double
        Dim dVctCross(2) As Double
        Dim Ang As Double

        Me.UnitMatrxSE(Mx)
        Me.VectByPnt(dPntFm, dPntTo, dVctDir)
        Me.UnitVect(dVctDir)

        Me.CopyArrDb2DbByIndx(Mx, 0, dVctX, 0, 3)
        Me.CrossVect(dVctX, dVctDir, dVctCross)
        Me.UnitVect(dVctCross)
        If Me.LenVect(dVctCross) < 0.001 Then
            dVctCross(0) = 0
            dVctCross(1) = 0
            dVctCross(2) = 1
        End If

        Ang = Rad2Deg * Me.Angl2Vector(dVctX, dVctDir)
        If System.Math.Abs(Ang) > 0.01 Then
            Me.MatxSERotByAxisAngl(dVctCross, Ang, Mx)
        End If
        Me.CopyArrDb2DbByIndx(dPntTo, 0, Mx, 12, 3)

    End Sub

    Public Sub MatxSEToNormalMatx(ByVal SeMat() As Double, ByRef Mat() As Double)
        If SeMat.Length < 15 Or Mat.Length < 9 Then
            Exit Sub
        End If
        Me.CopyArrDb2DbByIndx(SeMat, 0, Mat, 0, 3)
        Me.CopyArrDb2DbByIndx(SeMat, 4, Mat, 3, 3)
        Me.CopyArrDb2DbByIndx(SeMat, 8, Mat, 6, 3)
    End Sub

    Public Sub MatxNormalToSEMatx(ByVal Mat() As Double, ByRef SeMat() As Double)

        If SeMat.Length < 15 Or Mat.Length < 9 Then
            Exit Sub
        End If
        For Each d As Double In SeMat
            d = 0
        Next
        Me.CopyArrDb2DbByIndx(Mat, 0, SeMat, 0, 3)
        Me.CopyArrDb2DbByIndx(Mat, 3, SeMat, 4, 3)
        Me.CopyArrDb2DbByIndx(Mat, 6, SeMat, 8, 3)
        SeMat(15) = 1
    End Sub

    Public Sub AddMtrx2Mtrx(ByVal Mat1() As Double, ByRef Mat2() As Double, ByVal ResMat() As Double)
        If ResMat.Length < Mat2.Length Then
            ReDim ResMat(Mat2.Length)
        End If

        If Mat1.Length > Mat2.Length Then
            Exit Sub
        End If
        For i As Integer = 0 To Mat1.Length - 1
            ResMat(i) = Mat1(i) + Mat2(i)
        Next
    End Sub

    Public Sub MatxConcatTwoMx(ByVal Mat1() As Double, _
                               ByVal Mat2() As Double, _
                               ByRef MatRes() As Double)

        Dim ch As Integer
        Dim ch1 As Integer
        Dim ch2 As Integer
        Dim Mat2T(8) As Double
        Dim VctCh(2) As Double
        Dim VctCh1(2) As Double

        Me.TransportMatrx(Mat2, Mat2T)

        ch2 = 0
        For ch = 0 To 2
            Me.CopyArrDb2DbByIndx(Mat1, ch * 3, VctCh, 0, 3)
            For ch1 = 0 To 2
                Me.CopyArrDb2DbByIndx(Mat2T, ch1 * 3, VctCh1, 0, 3)
                MatRes(ch2) = Me.DotVector(VctCh, VctCh1)
                ch2 += 1
            Next ch1

        Next ch

    End Sub

#End Region


End Class
