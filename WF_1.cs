using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autokad_test_dll_15_01_2023
{
    public partial class WF_1 : Form
    {
       
        public WF_1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void WF_1_Load(object sender, EventArgs e)
        {
            foreach (var item in Layout_WF_void.list_layout)
            {
                listBox1.Items.Add( item.ToString());
            }
            // Урааа заработало 19-01-2023
        }
    }
}
