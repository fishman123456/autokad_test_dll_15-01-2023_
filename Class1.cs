using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

namespace autokad_test_dll_15_01_2023
{
    public class Class1
    {
        [CommandMethod ("Demo")]
        public void Demo()
        {
            Form1 mf = new Form1();
            mf.Show();
        }
    }
}
