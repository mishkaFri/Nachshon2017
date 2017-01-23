Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Geometry
Imports System.Collections.Generic

Public Class AttInfo
    Private _pos As Point3d
    Private _aln As Point3d
    Private _aligned As Boolean

#Region "Properties"
    Public Property aligned() As Boolean
        Get
            Return _aligned
        End Get
        Set(ByVal value As Boolean)
            _aligned = value
        End Set
    End Property

    Public Property Pos() As Point3d
        Get
            Return _pos
        End Get
        Set(ByVal value As Point3d)
            _pos = value
        End Set
    End Property

    Public Property Aln() As Point3d
        Get
            Return _aln
        End Get
        Set(ByVal value As Point3d)
            _aln = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal pos As Point3d, ByVal aln As Point3d, ByVal aligned As Boolean)
        _pos = pos
        _aln = aln
        _aligned = aligned
    End Sub

End Class

    
Public Class BlockJig
    Inherits EntityJig
    Private _pos As Point3d
    Private _attInfo As Dictionary(Of ObjectId, AttInfo)
    Private _tr As Transaction

    Public Sub New(ByVal tr As Transaction, ByVal br As BlockReference, ByVal attinfo As Dictionary(Of ObjectId, AttInfo))
        MyBase.New(br)
        _pos = br.Position
        _attInfo = attinfo
        _tr = tr
    End Sub

    Protected Overrides Function Sampler(ByVal prompts As Autodesk.AutoCAD.EditorInput.JigPrompts) As Autodesk.AutoCAD.EditorInput.SamplerStatus
        Dim opts As JigPromptPointOptions = New JigPromptPointOptions("\nSelect insertion point:")
        opts.BasePoint = New Point3d(0, 0, 0)
        opts.UserInputControls = UserInputControls.NoZeroResponseAccepted

        Dim ppr As PromptPointResult = prompts.AcquirePoint(opts)

        If _pos = ppr.Value Then
            Return SamplerStatus.NoChange
        End If
        _pos = ppr.Value
        Return SamplerStatus.OK

    End Function

    Protected Overrides Function Update() As Boolean
        Dim br As BlockReference = TryCast(Entity, BlockReference)
        br.Position = _pos
        If br.AttributeCollection.Count <> 0 Then
            For Each id As ObjectId In br.AttributeCollection
                Dim obj As DBObject = _tr.GetObject(id, OpenMode.ForRead)
                Dim ar As AttributeReference = TryCast(obj, AttributeReference)
                If ar IsNot Nothing Then
                    ar.UpgradeOpen()
                    Dim ai As AttInfo = _attInfo(ar.ObjectId)
                    ar.Position = ai.Pos.TransformBy(br.BlockTransform)
                    If ai.aligned Then
                        ar.AlignmentPoint = ai.Aln.TransformBy(br.BlockTransform)
                    End If
                    If ar.IsMTextAttribute Then
                        ar.UpdateMTextAttribute()
                    End If
                End If
            Next
        End If
        Return True
    End Function

    Public Function Run() As PromptStatus
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ed As Editor = doc.Editor
        Dim promptResult As PromptResult = ed.Drag(Me)
        Return promptResult.Status
    End Function



End Class


'    Public Class Commands
'              ar.TextString = ad.TextString;
'              ObjectId arId =
'                br.AttributeCollection.AppendAttribute(ar);
'              tr.AddNewlyCreatedDBObject(ar, true);

'              // Initialize our dictionary with the ObjectId of
'              // the attribute reference + attribute definition info

'              attInfo.Add(
'                arId,
'                new AttInfo(
'                  ad.Position,
'                  ad.AlignmentPoint,
'                  ad.Justify != AttachmentPoint.BaseLeft
'                )
'              );
'            }
'          }
'        }
'        // Run the jig

'        BlockJig myJig = new BlockJig(tr, br, attInfo);

'        if (myJig.Run() != PromptStatus.OK)
'          return;

'        // Commit changes if user accepted, otherwise discard

'        tr.Commit();
'      }
'    }
'  }
'}



'    [CommandMethod("BJ")]
'    static public void BlockJigCmd()
'    {
'      Document doc =
'        Application.DocumentManager.MdiActiveDocument;
'      Database db = doc.Database;
'      Editor ed = doc.Editor;

'      PromptStringOptions pso =
'        new PromptStringOptions("\nEnter block name: ");
'      PromptResult pr = ed.GetString(pso);

'      if (pr.Status != PromptStatus.OK)
'        return;

'      Transaction tr =
'        doc.TransactionManager.StartTransaction();
'      using (tr)
'      {
'        BlockTable bt =
'          (BlockTable)tr.GetObject(
'            db.BlockTableId,
'            OpenMode.ForRead
'          );

'        if (!bt.Has(pr.StringResult))
'        {
'          ed.WriteMessage(
'            "\nBlock \"" + pr.StringResult + "\" not found.");
'          return;
'        }

'        BlockTableRecord space =
'          (BlockTableRecord)tr.GetObject(
'            db.CurrentSpaceId,
'            OpenMode.ForWrite
'          );

'        BlockTableRecord btr =
'          (BlockTableRecord)tr.GetObject(
'            bt[pr.StringResult],
'            OpenMode.ForRead);

'        // Block needs to be inserted to current space before
'        // being able to append attribute to it

'        BlockReference br =
'          new BlockReference(new Point3d(), btr.ObjectId);
'        space.AppendEntity(br);
'        tr.AddNewlyCreatedDBObject(br, true);
'Dictionary<ObjectId, AttInfo> attInfo =
'          new Dictionary<ObjectId,AttInfo>();

'        if (btr.HasAttributeDefinitions)
'        {
'          foreach (ObjectId id in btr)
'          {
'            DBObject obj =
'              tr.GetObject(id, OpenMode.ForRead);
'            AttributeDefinition ad =
'              obj as AttributeDefinition;

'            if (ad != null && !ad.Constant)
'            {
'              AttributeReference ar =
'                new AttributeReference();

'              ar.SetAttributeFromBlock(ad, br.BlockTransform);
'              ar.Position =
'                ad.Position.TransformBy(br.BlockTransform);

'              if (ad.Justify != AttachmentPoint.BaseLeft)
'              {
'                ar.AlignmentPoint =
'                  ad.AlignmentPoint.TransformBy(br.BlockTransform);
'              }
'              if (ar.IsMTextAttribute)
'              {
'                ar.UpdateMTextAttribute();
'              }
