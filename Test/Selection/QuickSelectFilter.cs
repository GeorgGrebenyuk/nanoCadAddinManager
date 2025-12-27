using HostMgd.ApplicationServices;
using Teigha.DatabaseServices;
using HostMgd.EditorInput;
using Teigha.Runtime;

namespace Test.Selection;

public class QuickSelectFilter
{
    [CommandMethod("SelectText")]
    public static void SelectText()
    {
        var doc = Application.DocumentManager.MdiActiveDocument;
        var db = doc.Database;
        var ed = doc.Editor;
        var peo = new PromptEntityOptions("\nSelect a text: ");
        peo.SetRejectMessage("\nSelected object is not a text.");
        peo.AddAllowedClass(typeof(DBText), true);
        var per = ed.GetEntity(peo);
        if (per.Status != PromptStatus.OK) 
            return;
        using (var tr = db.TransactionManager.StartTransaction())
        {
            var ent = (DBText)tr.GetObject(per.ObjectId, OpenMode.ForRead);
            ed.WriteMessage($"\n{ent.TextString}");
            tr.Commit();
        }
    }
}