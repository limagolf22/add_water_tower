using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace WindowsForms_add_water_tower
{   
    public partial class Form1 : Form
    {
        private static string Path_csv = "";
        int n_rows = 0; //number of rows in the datagrid
        public Form1()
        {
            InitializeComponent();

            refresh_open();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   StreamWriter sw = new StreamWriter("C:\\Users\\ultra\\source\\repos\\WindowsForms_add_water_tower\\water_tower.xml",false);
         //   sw.WriteLine("<?xml version=\"1.0\"?>\n<FSData version=\"9.0\">");
            StreamWriter sw = new StreamWriter(Path_csv, false);
            foreach (DataGridViewRow col in dataGridView1.Rows)
            {
                try
                {
                    if (col.Cells[1].Value!=null)
                    {
 //                       sw.WriteLine("\t < !--SceneryObject name: Water_Tower_FR-- >");
                        Debug.WriteLine("Val : " + col.Cells[0].Value + col.Cells[1].Value + col.Cells[2].Value + col.Cells[3].Value);
 //                       sw.WriteLine("\t < SceneryObject lat =\"{0}\" lon=\"{1}\" alt=\"0.00000000000000\" pitch=\"0.000068\" bank=\"-0.000068\" heading=\"-179.999991\" imageComplexity=\"VERY_SPARSE\" altitudeIsAgl=\"TRUE\" snapToGround=\"TRUE\" snapToNormal=\"FALSE\">\n\t\t<LibraryObject name=\"{2}{3}{4}\" scale=\"{5}\"/>\n\t</SceneryObject>", col.Cells[1].Value.ToString(), col.Cells[2].Value.ToString(), "{", "93EE3F27 - 3429 - 4CC7 - A9CC - 0FB5ED33AFC2", "}", col.Cells[3].Value.ToString());
                        sw.WriteLine("{0};{1};{2};{3}", col.Cells[0].Value.ToString(), col.Cells[1].Value.ToString(), col.Cells[2].Value.ToString(), col.Cells[3].Value.ToString());
                    }
                }
                catch (Exception e2)
                {
                    Debug.WriteLine("Exception: " + e2.Message);
                }
            }
         //   sw.WriteLine("</FSData>");
            sw.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void compile_Click(object sender, EventArgs e)
        {
            string relpath = "./exec.bat";
            string exactPath = Path.GetFullPath(relpath);
            Process.Start(exactPath);
        }

        private void add_object_Click(object sender, EventArgs e)
        {
            try
            {
                string[] parse_obj;
                parse_obj = textBox1.Text.Split(new[] { ", " }, StringSplitOptions.None);
                dataGridView1.Rows.Add("", parse_obj[0], parse_obj[1], "1.0");
                textBox1.Text = "";
            }
            catch (Exception e_add)
            {
                Debug.WriteLine("Exception: " + e_add.Message);
            }
        }

        private void refresh_open()
        {
            try
            {
                string[] o_files = Directory.GetFiles(@"./files", "*.csv");
                listOpen.Items.Clear();
                
                foreach(string o_file in o_files)
                {
                    listOpen.Items.Add(o_file.Split('\\')[1]);
                }
                listOpen.SelectedItem=o_files[0].Split('\\')[1];
            }
            catch(Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
            
        }

        private void refresh_table()
        {
            String line;
            string[] parse;

            //            float lat, lon, scale;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(Path_csv);
                //Read the first line of text
                line = sr.ReadLine();
                dataGridView1.Rows.Clear();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Debug.WriteLine(line);
                    parse = line.Split(';');

                    dataGridView1.Rows.Add(parse[0], parse[1], parse[2], parse[3]);
                    n_rows++;
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                //     Console.ReadLine();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Debug.WriteLine("Executing finally block.");
            }
        }

        private void open_button_Click(object sender, EventArgs e)
        {
            Path_csv = "./files/" + listOpen.SelectedItem;
            refresh_table();
        }

        private void new_button_Click(object sender, EventArgs e)
        {
            Path_csv = "./files/" + new_text.Text + ".csv";
            FileStream fs_n = File.Create(Path_csv);
            fs_n.Close();
            refresh_open();
            refresh_table();
            listOpen.SelectedItem = new_text.Text + ".csv";
            new_text.Text = "";
        }
    }
}
