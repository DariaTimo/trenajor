using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Тренажер
{
    public partial class Form7 : Form
    {
        string key, fr;
        private SQLiteConnection SQLiteConn;
        private DataTable dTable, dt;
        int s, m, sm;

        private void Form7_Load(object sender, EventArgs e)
        {
            SQLiteConn = new SQLiteConnection();
            dTable = new DataTable();




            SQLiteConn = new SQLiteConnection("Data Source=D:\\Практика\\3 курс\\СиППО\\Программа\\Tre.db ;Version=3;");
            SQLiteConn.Open();

            string SQLQuery = "SELECT *FROM Виженер";
            dTable.Clear();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQLQuery, SQLiteConn);
            adapter.Fill(dTable);
            textBox1.Text = key;

            Rew(key, fr, dTable,dt);
            toolStripButton1.Text = "Справка";
            s = 0;
            timer1.Enabled = true;
            timer1.Interval = 1000; 
            toolStripStatusLabel1.Text = "00";
            toolStripStatusLabel3.Text = "00";

            s = 0;
            m = 0;
            sm = 0;
            //toolStripButton1.Text = "Главное меню";
            //toolStripButton2.Text = "Шифр 2";
            //toolStripButton3.Text = "Шифр 3";
            //toolStripButton4.Text = "Сбросить";
            //toolStripButton5.Text = "Закрыть";
        }

        public Form7(string k, string f)
        {
            InitializeComponent();
            key = k;
            fr = f;
            
            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8(dTable);
            form.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gf;
            int p, n;
            p = 0;
            n = 0;
            gf = richTextBox2.Text;
            gf = gf.ToUpper();

            if (gf.Length == fr.Length)
            {


                for (int i = 0; i < gf.Length; i++)
                {
                    if (fr[i] == gf[i])
                    {
                        p++;




                    }
                    else
                    {
                        n++;

                    }
                }
                if (p == fr.Length)
                {
                    richTextBox2.BackColor = Color.Green;
                    DialogResult result = MessageBox.Show("Поздравляем! Ошибок нет.", "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    timer1.Enabled = false;
                }
                else
                {
                    richTextBox2.BackColor = Color.Red;
                    DialogResult result = MessageBox.Show("Неправильно. Количество ошибок: " + n, "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }


            }
            else
            {
                DialogResult result = MessageBox.Show("Количество символов не совпадает", "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Открыть справку?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form10 form = new Form10();
                form.Show();


            }

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
                    
                }
                else
                {
                    m = 0;
                    toolStripStatusLabel1.Text = "00";
                }

            }
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form2 = Application.OpenForms[1];
            form2.Show();
            
        }

        private void Rew(string k, string f, DataTable dt, DataTable DB)
        {
           DB = new DataTable();
            DB.Clear();
            int t = 0;

            for (int i = 0; i < f.Length; i++)
            {
                DB.Columns.Add("" + i + "");
                
            }
            for (int i = 0; i < f.Length; i++)
            {
                DB.Rows.Add();
                DB.Rows[i][1] = f[i];
                
            }
            
            for (int i = 0; i < f.Length; i++)
            {
                DB.Rows.Add();
               if (f[i]!=' ' && f[i] != '\b' && f[i] != '-' && f[i] != ',' && f[i] != '.' && f[i] != '?' && f[i] != '!')
                {
                    if (t>k.Length-1)
                    {
                    t = 0;
                    }
                DB.Rows[i][2] = k[t];
                t++;

                }
               else
                {
                    DB.Rows[i][2] = "" + f[i]+""; 

                }
                
                
                
                
            }
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            char ms;
            for (int i = 0; i < f.Length;i++)
            {
                string ColumName = ""+i+"";
                dataGridView1.Columns.Add(ColumName, ColumName);
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
            }
            dataGridView1.Rows.Add();
            for (int i = 0; i < DB.Columns.Count; i++)
            {
                //mor = Convert.ToChar(DB.Rows[i][1]);
                //dataGridView1.Rows[0].Cells[i].Value = mor;
                ms = Convert.ToChar(DB.Rows[i][2]);
                dataGridView1.Rows[0].Cells[i].Value = ms;


            }
            dataGridView1.Rows[0].HeaderCell.Value = "Ключ";
            dataGridView1.Rows[0].HeaderCell.ToolTipText = "Ключ";
            dataGridView1.Rows[1].HeaderCell.ToolTipText = "Зашифрованные символы";
            dataGridView1.Rows[1].HeaderCell.Value = "Зашифрованные символы";




            string sfr = new String(new char[f.Length]);

            for (int i = 0; i < f.Length; i++)
            {
                if (f[i] != ' ' && f[i] != '\b' && f[i] != '-' && f[i] != ',' && f[i] != '.' && f[i] != '?' && f[i] != '!') 
                {


                    for (int j = 1; j < dt.Columns.Count; j++)
                    {


                        if (Convert.ToString(dt.Columns[j].ColumnName) == Convert.ToString(DB.Rows[i][1]))
                        {

                            for (int p = 1; p < dt.Rows.Count + 1; p++)
                            {
                                if (Convert.ToString(dt.Rows[0][p]) == Convert.ToString(DB.Rows[i][2]))
                                {


                                    sfr = Convert.ToString(dt.Rows[j - 1][p]);
                                    richTextBox1.Text += sfr;
                                    dataGridView1.Rows[1].Cells[i].Value = sfr;
                                }
                            }
                        }

                    }

                }
                else
                {
                    sfr = "" + f[i] + "";
                    richTextBox1.Text += sfr;

                }

            }

        }

        


    }
}
