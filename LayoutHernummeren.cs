﻿using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autokad_test_dll_15_01_2023
{
        public class LayoutHernummeren
        {
            [CommandMethod("LayRenum")]
            public void CmdLayRenum()
            {
                Document doc = Application.DocumentManager.MdiActiveDocument;
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

                            oldName = layout.LayoutName;
                            newName = "blad" + layout.TabOrder.ToString("00");


                            if (oldName != newName)
                            {
                                if (layout.ModelType != model)
                                {
                                    LayoutManager.Current.RenameLayout(oldName, newName);

                                }
                            }
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

