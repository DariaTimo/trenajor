using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Тренажер
{
    public partial class Form12 : Form
    {
        int k;
        string num, fr, fra;
        DataTable DT;
        DataTable dTable;
        int s, m, sm;

        public Form12(int key, string chi, string fraz)
        {
            InitializeComponent();
            k = key;
            num = chi;
            fr = fraz;
            fra = fraz;
            
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            Test();
            toolStripButton1.Text = "Справка";
            timer1.Enabled = true;

            toolStripStatusLabel1.Text = "00";
            toolStripStatusLabel3.Text = "00";

            s = 0;
            m = 0;
            sm = 0;
            button2.Enabled = false;
            timer1.Interval = 1000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowTable(DT);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s < 59)
            {
                s++;
                if (s < 10)
                    toolStripStatusLabel3.Text = "0" + s.ToString();
                else
                    toolStripStatusLabel3.Text = s.ToString();
            }
            else
            {
                if (m < 59)
                {

                    m++;
                    if (m < 10)
                        toolStripStatusLabel1.Text = "0" + m.ToString();
                    else
                        toolStripStatusLabel1.Text = m.ToString();
                    s = 0;
                    toolStripStatusLabel3.Text = "00";
                   
                    if (m == 3)
                    {
                        button2.Enabled = true;
                    }
                }
                else
                {
                    m = 0;
                    toolStripStatusLabel1.Text = "00";
                }

            }
        }

        private void Form12_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form2 = Application.OpenForms[1];
            form2.Show();
            for (int i = Application.OpenForms.Count - 1; i > 0; i--)
            {
                if (Application.OpenForms[i].Name != "Form11")
                {
                    Application.OpenForms[i].Close();
                }

            }
        }

        private void Test()
        {
            DT = new DataTable();
            dTable = new DataTable();
            int[] chi = new int[k];
           // char[] sfr = new char[];
           List<string> sfr = new List<string>();

            for (int i = 0; i < k; i++)
            {
                DT.Columns.Add();
                dTable.Columns.Add();
            }
            int n = 0;
            int m = 0;
            int p;

            fr = fr.Replace(" ", "");
            
            fr = fr.ToUpper();

            for (int j = 0; j < fr.Length; j++)
            {

                if (fr[j] == Convert.ToChar(","))
                {
                    sfr.Add("З");
                    sfr.Add("П");
                    sfr.Add("Т");

                }
                else
                {
                    if (fr[j] == Convert.ToChar("."))
                    {
                        sfr.Add("Т");

                        sfr.Add("Ч");
                        sfr.Add("К");
                    }
                    else
                    {
                        sfr.Add(Convert.ToString(fr[j]));
                    }
                }
                

            }

            
            
            p = sfr.Count / k;
            for (int i = 0; i < p+1; i++)
            {
                DT.Rows.Add();
                dTable.Rows.Add();
            }


            for (int i = 0; i < sfr.Count; i++)
            {

                if (m < DT.Columns.Count)
                {
                    DT.Rows[n][m] = sfr[i];
                    m++;

                }
                else
                {
                    n++;
                    m = 0;

                    DT.Rows[n][m] = sfr[i];
                    m++;

                }


            }
            int[] number = num.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < dTable.Columns.Count; i++)
            {
                for (int j = 0; j < dTable.Rows.Count; j++)
                {
                    dTable.Rows[j][i] = DT.Rows[j][number[i] - 1];
                }
            }


            ShowTable(dTable);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Открыть справку?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form9 form3 = new Form9();
                form3.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gf;
            int p, n;
            p = 0;
            n = 0;
            gf = richTextBox1.Text;
            gf = gf.ToUpper();
            fra = fra.ToUpper();
            if (gf.Length == fra.Length)
            {


                for (int i = 0; i < gf.Length; i++)
                {
                    if (fra[i] == gf[i])
                    {
                        p++;



                    }
                    else
                    {
                        n++;

                    }
                }
                if (p == fra.Length)
                {
                    richTextBox1.BackColor = Color.Green;
                    DialogResult result = MessageBox.Show("Поздравляем! Ошибок нет.", "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    timer1.Enabled = false;
                }
                else
                {
                    richTextBox1.BackColor = Color.Red;
                    DialogResult result = MessageBox.Show("Неправильно. Количество ошибок: " + n, "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }


            }
            else
            {
                DialogResult result = MessageBox.Show("Количество символов не совпадает", "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void ShowTable(DataTable DT)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToOrderColumns = true;
            char j;
            int[] number = num.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
            for (int colum = 0; colum < DT.Columns.Count; colum++)
            {
                string ColumName = Convert.ToString(colum+1);
                dataGridView1.Columns.Add(ColumName, ColumName);
                dataGridView1.Columns[colum].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



            }
            for (int row = 0; row< DT.Rows.Count; row++)
            {
                dataGridView1.Rows.Add();

            }
            
            for(int c=0; c<DT.Columns.Count; c++)
            {
                for (int r=0; r<DT.Rows.Count; r++)
                {
                   
                    dataGridView1.Rows[r].Cells[c].Value = DT.Rows[r][c];
                }
            }
            

        }

        
    }
}
