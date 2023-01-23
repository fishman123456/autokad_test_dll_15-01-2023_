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
                    textBox1.Text = item.ToString();
                   
                //} 
                   
                
            }
            // Урааа заработало 19-01-2023
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Layout_WF.Cmd_Lay_Renum();
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
            textBox1.Text = fileText + Environment.NewLine;
            Layout_WF.list_layout.Clear();
            Layout_WF.list_layout_new.Clear();
            foreach (var item in textBox1.Lines)
            {
                Layout_WF.list_layout_new.Add(item);
            }
            
            MessageBox.Show("Файл открыт");
            MessageBox.Show( "кол-во листов новые: ", Layout_WF.list_layout_new.Count.ToString());
            MessageBox.Show("кол-во листов сущ.: ", Layout_WF.list_layout.Count.ToString());
        }

        private void button3_Save_file_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox1.Text);
            //Layout_WF.list_layout_new.Clear();
            Layout_WF.list_layout_new.Add(textBox1.Lines.ToString());
            Layout_WF.list_layout.Clear();
            Layout_WF.list_layout_new.Clear();
            foreach (var item in textBox1.Lines)
            {
                Layout_WF.list_layout_new.Add(item);
            }
            MessageBox.Show("Файл сохранен");
            MessageBox.Show("кол-во листов новые: ", Layout_WF.list_layout_new.Count.ToString());
            MessageBox.Show("кол-во листов сущ.: ", Layout_WF.list_layout.Count.ToString());
        }
    }
}
