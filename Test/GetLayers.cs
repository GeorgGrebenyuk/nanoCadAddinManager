using HostMgd.ApplicationServices;
using Teigha.DatabaseServices;
using Teigha.Runtime;
using Application = HostMgd.ApplicationServices.Application;

namespace Test;

public class GetLayers
{
    [CommandMethod("GetAllLayers", "TestListLayer",CommandFlags.Modal)]
    public void GetAllLayer()
    {
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);
            foreach (ObjectId id in lt)
            {
                LayerTableRecord ltr = (LayerTableRecord)tr.GetObject(id, OpenMode.ForRead);
                doc.Editor.WriteMessage(ltr.Name);
            }
        }
    }
}