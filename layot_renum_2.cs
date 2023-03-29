using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.GraphicsSystem;
using Autodesk.AutoCAD.LayerManager;
using Autodesk.AutoCAD.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace autokad_test_dll_15_01_2023
{
   public class layot_renum_2
    {
        [CommandMethod("Lay_Renum_2")]
        public void Cmd_Lay_Renum_2()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var edt = doc.Editor;
            var db = doc.Database;
            var layoutMgr = LayoutManager.Current;

            try
            {
                using (var trans = db.TransactionManager.StartTransaction())
                {
                    var layoutDict = (DBDictionary)trans.GetObject(db.LayoutDictionaryId, OpenMode.ForRead);
                    var layouts = layoutDict
                        .Cast<System.Collections.DictionaryEntry>()
                        .Select(entry => (Layout)trans.GetObject((ObjectId)entry.Value, OpenMode.ForWrite))
                        .OrderBy(layout => layout.TabOrder)
                        .ToArray();
                    for (int i = 1; i < layouts.Length; i++)
                    {
                        var layout = layouts[i];
                        LayoutManager.Current.RenameLayout(layout.LayoutName, $"blad{i:00}");
                    }
                    trans.Commit();
                }
            }

            catch (System.Exception ex)
            {
                edt.WriteMessage("\nError >> " + ex.Message);
            }
        }
    }
}
