using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.GraphicsSystem;

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
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void WF_1_Load(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            foreach (var item in Layout_WF.list_layout)
            {
                //if (item.ToString() != "model")
                //{
                    textBox1.Text = item.ToString()+'\r' + '\n';
                   
                //} 
                   
                
            }
            // Урааа заработало 19-01-2023
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Layout_WF.ListUpdate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Load_file_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            List<string> list_f_t = new List<string>();
            
            textBox1.Text = fileText + Environment.NewLine;
            Layout_WF.new_list_layout.Add(textBox1.Lines.ToString());
            MessageBox.Show("Файл открыт");
        }

        private void button3_Save_file_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }
    }
}
