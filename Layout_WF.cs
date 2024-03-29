﻿using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.LayerManager;
using Autodesk.AutoCAD.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autokad_test_dll_15_01_2023
{
    public class Layout_WF
    {
        public static List<String> list_layout = new List<string>(); 
        [CommandMethod("Lay_WF_Renum")]
        //public  List<String> list_layout { get; set; }


        public static void Cmd_Lay_Renum()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor edt = doc.Editor;
            Database db = doc.Database;

            
            string oldName;
            string newName;
            
            bool model = true;

            try
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    DBDictionary layoutDict = trans.GetObject(db.LayoutDictionaryId, OpenMode.ForRead) as DBDictionary;

                    foreach (DBDictionaryEntry layoutEntry in layoutDict)
                    {
                        Layout layout = trans.GetObject((ObjectId)layoutEntry.Value, OpenMode.ForRead) as Layout;
                        layout.UpgradeOpen();
                        list_layout.Add(layout.LayoutName.ToString());
                       
                      
                        //код для изменения имён листов-------
                        //https://stackoverflow.com/questions/72216779/renaming-layout-tab-autocad-c-sharp-net
                        //oldName = layout.LayoutName;
                        //newName = "blad" + layout.TabOrder.ToString("00");
                        //if (oldName != newName)
                        //{
                        //    if (layout.ModelType != model)
                        //    {
                        //        LayoutManager.Current.RenameLayout(oldName, newName);
                        //    }
                        //}
                    }
                    trans.Commit();
                }
            }
            catch (System.Exception ex)
            {
                edt.WriteMessage("\nError >> " + ex.Message);
            }
        }
        // метод для обновления значений в textbox1, список листов
        static public void ListUpdate()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor edt = doc.Editor;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                DBDictionary layoutDict = trans.GetObject(db.LayoutDictionaryId, OpenMode.ForRead) as DBDictionary;

                foreach (DBDictionaryEntry layoutEntry in layoutDict)
                {
                    Layout layout = trans.GetObject((ObjectId)layoutEntry.Value, OpenMode.ForRead) as Layout;
                    layout.UpgradeOpen();
                }
                trans.Commit();
            }
           

        }
        }
}

