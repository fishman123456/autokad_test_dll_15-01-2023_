using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
// Создан 15-01-2023 ()
namespace autokad_test_dll_15_01_2023
{
    public class For_WF
    {
        [CommandMethod ("WF_Form")]
        public void Demo()
        {
            WF_1 mf = new WF_1();
            mf.Show();
        }

       


        }
}
// https://www.youtube.com/watch?v=yx7IT5xYBLw
// сделано по видео