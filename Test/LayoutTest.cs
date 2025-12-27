using HostMgd.ApplicationServices;
using Teigha.DatabaseServices;
using Teigha.Runtime;
using Application = HostMgd.ApplicationServices.Application;

namespace Test;

public class LayoutTest
{
    [CommandMethod("ListLayouts")]
    public void ListLayouts()
    {
        // Get the current document and database
        Document acDoc = Application.DocumentManager.MdiActiveDocument;
        Database acCurDb = acDoc.Database;

        // Get the layout dictionary of the current database
        using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
        {
            DBDictionary? lays =
                acTrans.GetObject(acCurDb.LayoutDictionaryId,
                    OpenMode.ForRead) as DBDictionary;

            acDoc.Editor.WriteMessage("\nLayouts:");

            // Step through and list each named layout and Model
            foreach (DBDictionaryEntry item in lays)
            {
                acDoc.Editor.WriteMessage("\n  " + item.Key);
            }

            // Abort the changes to the database
            acTrans.Abort();
        }
    }
}