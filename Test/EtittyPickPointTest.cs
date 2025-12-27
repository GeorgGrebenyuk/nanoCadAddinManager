using HostMgd.ApplicationServices;
using HostMgd.ApplicationServices;
using Teigha.DatabaseServices;
using HostMgd.EditorInput;
using Teigha.Geometry;
using Teigha.Runtime;
using Application = HostMgd.ApplicationServices.Application;

namespace Test;

public class EntityPickPointTest
{
    [CommandMethod("getEntityPickPoint")]
    public static void getEntityPickPoint()
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        Editor ed = doc.Editor;

        PromptEntityOptions peo = new PromptEntityOptions("\nSelect Entity");
        PromptEntityResult per = ed.GetEntity(peo);
        if (per.Status == PromptStatus.OK)
        {
            Point3d pickedPoint = per.PickedPoint;
            Point3d pickedPtOsnap = ed.Snap("_near", pickedPoint);

            ed.WriteMessage("\n Selected pick point: {0}", pickedPoint.ToString());
            ed.WriteMessage("\n Selected Picked Point Osnap near: {0}", pickedPtOsnap);
        }
    }
}