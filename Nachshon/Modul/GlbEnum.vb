Module GlbEnum
    Public Enum ModeSaveProject
        FromNewProject = 0
        FromOpenProject = 1
    End Enum

    Public Class FilePropertNames
        Public Const CustomProp_PartNumber As String = "Part Number"
        Public Const CustomProp_Description As String = "Part_Description"
        Public Const CustomProp_DescriptionHeb As String = "Part_DescriptionHeb"
    End Class

    Public Enum MainMenuButtonsMode
        StartMode = 0
        ProjectOk = 1
        KitchenOk = 2
        ProjectClosed = 3
    End Enum

    Public Enum TndTlbRows
        SonName = 0
        Name = 1
        Size = 2
        Area = 3
        Elec = 4
        Gas = 5
        Steam = 6
    End Enum

    Public Enum TndTlbFields
        Num = 1
        Desc = 2
        Qnt = 3
        Length = 4
        Width = 5
        Height = 6
        Area = 7
        Elec = 8
        Phase = 9
        Horse = 10
        Gas = 11
        Steam = 12
    End Enum

    Public Enum ListUcMode
        ListCreation = 0
        ListSelectionLst = 1
        ListSelectionBom = 2
        ListSelectionTnd = 3
        ListSelectionTndBom = 4
    End Enum

    Public Class ListTypes
        Public Const Wide As String = "Wide"
        Public Const Narrow As String = "Narrow"
        Public Const Fixed As String = "Fixed"
        Public Const Operational As String = "Operational"
        Public Const BOM As String = "BOM"
    End Class

    Public Enum GroupMenuButtonsMode
        StartMode = 0
        Add1 = 1
        Add2 = 2
        Edit = 3
        'ProjectClosed = 3
    End Enum

    Public Enum PriceUnitTypes 'SZ
        Meter_cm = 2 ' Meter - measured in cm
        Unit = 4
        MeterCon_cm = 5 ' "Running" meter measured in cm
        Area = 9 ' Area = measured in Squered meter
    End Enum

    Public Class Language
        Public Const Hebrew As String = "H"
        Public Const English As String = "E"
    End Class

End Module
