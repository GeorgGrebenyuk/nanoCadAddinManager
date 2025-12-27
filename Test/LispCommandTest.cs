using HostMgd.ApplicationServices;
using Teigha.DatabaseServices;
using HostMgd.EditorInput;
using Teigha.Runtime;

namespace Test;

public class LispCommand
{
    [CommandMethod("TestLispFunction", CommandFlags.Modal)]
    public void Test()
    {
        ResultBuffer args = new ResultBuffer(
            new TypedValue((int)HostMgd.Runtime.LispDataType.Text, "c:hello"));
        ResultBuffer result = Application.Invoke(args);
        Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
        ed.WriteMessage(result.ToString());
    }
}