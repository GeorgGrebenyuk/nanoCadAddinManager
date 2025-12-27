using System.Windows;
using Teigha.DatabaseServices;
using Teigha.Runtime;
using Application = HostMgd.ApplicationServices.Application;
public class FunctionLispTest
{
    //Test : (displayfullname "First" "Last")
    [LispFunction("DisplayFullName")]
    public static void DisplayFullName(ResultBuffer rbArgs)
    {
        if (rbArgs != null)
        {
            string strVal1 = "";
            string strVal2 = "";
            int nCnt = 0;
            foreach (TypedValue rb in rbArgs)
            {
                if (rb.TypeCode == (int)HostMgd.Runtime.LispDataType.Text)
                {
                    switch (nCnt)
                    {
                        case 0:
                            strVal1 = rb.Value.ToString();
                            break;
                        case 1:
                            strVal2 = rb.Value.ToString();
                            break;
                    }
                    nCnt = nCnt + 1;
                }
            }
            Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nName: " + strVal1 + " " + strVal2);
            MessageBox.Show("Updated");
        }
    }
}