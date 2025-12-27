using System;
using HostMgd.ApplicationServices;
using Teigha.DatabaseServices;
using Teigha.Geometry;
using HostMgd.PlottingServices;
using Teigha.Runtime;

namespace Test;

public class TestCircle
{
    [CommandMethod("CreateCircle")]
    public static void cmdCreateCircle()
    {
        var doc = Application.DocumentManager.MdiActiveDocument;
        var ed = doc.Editor;
        var db = doc.Database;

        using (var tr = db.TransactionManager.StartTransaction())
        {
            var bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            if (bt != null)
            {
                var ms = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                var circle = new Teigha.DatabaseServices.Circle();
                Random ran = new Random();
                int c = ran.Next(0, 100);
                circle.Center = new Point3d(0, 10, 0);
                circle.Radius = c;
                ms?.AppendEntity(circle);
                tr.AddNewlyCreatedDBObject(circle, true);
            }

            tr.Commit();

        }
    }
}