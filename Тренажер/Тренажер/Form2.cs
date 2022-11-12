using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Resources;

namespace Тренажер
{
    public partial class Form2 : Form
    {
        private SQLiteConnection SQLiteConn;
        private SQLiteCommand Scmd;
        private DataTable dTable;
        private string dbFileName;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form2 = Application.OpenForms[0];
            form2.Show();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SQLiteConn = new SQLiteConnection();
            Scmd = new SQLiteCommand();
            dTable = new DataTable();
            button1.Enabled = false;

            dbFileName = "Tre.db";


            SQLiteConn = new SQLiteConnection("Data Source=D:\\Практика\\3 курс\\СиППО\\Программа\\Тренажер\\Тренажер\\bin\\Debug\\Tre.db ;Version=3;");
            SQLiteConn.Open();

            string SQLQuery = "SELECT *FROM Цезарь";
            dTable.Clear();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQLQuery, SQLiteConn);
            adapter.Fill(dTable);

            toolStripButton1.Text = "Главное меню";
            toolStripButton2.Text = "Шифр Виженера";
            toolStripButton3.Text = "Шифр вертикальной перестановки";
            toolStripButton4.Text = "Сбросить";
            toolStripButton5.Text = "Справка";

        }
        

        private void button1_Click(object sender, EventArgs e) //Зашифровать 
        {
            int k, c;
            c = 0;
            k = Convert.ToInt32(textBox1.Text);
            if (k > 33)
            {

                DialogResult result = MessageBox.Show("Введите число от 1 до 33", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                {
                    textBox1.Clear();
                }
            }
            else
            {

                for (int col = 0; col < dTable.Columns.Count; ++col)
                {
                    dTable.Rows.Add();



                    if (col + k >= dTable.Columns.Count)
                    {
                        dTable.Rows[col][1] = dTable.Columns[c].ColumnName;
                        c++;

                    }
                    else
                    {
                        dTable.Rows[col][1] = dTable.Columns[col + k].ColumnName;
                    }

                }

                string fr = textBox2.Text;
                fr = fr.ToUpper();
                Form5 form = new Form5(fr, dTable, k);
                form.Show();
                this.Hide();

                //string fr = textBox2.Text;
                ////fr = fr.Replace(" ", "*");
                ////fr = fr.Trim().Replace(" ", string.Empty);
                //fr = fr.ToUpper();
                //int pro = 0;
                //int prov = 0;

                //for (int i = 0; i < fr.Length; ++i)
                //{
                //    if (fr[i] == Convert.ToChar(" "))
                //    {
                //        prov++;

                //    }
                //    else
                //    {
                //        for (int j = 0; j < dTable.Columns.Count; j++)
                //        {


                //            if (fr[i] == Convert.ToChar(dTable.Columns[j].ColumnName))
                //            {
                //                pro++;

                //            }


                //        }

                //    }

                //}

                //if (pro + prov == fr.Length)
                //{
                //    Form5 form = new Form5(fr, dTable, k) ;
                //    form.Show();
                //    this.Hide();
                //}
                //else
                //{
                //    DialogResult result = MessageBox.Show("Введите русские буквы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                //    if (result == DialogResult.OK)
                //    {
                //        textBox2.Clear();
                //    }
                //}





            }

        }

        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Вернуться в главное меню?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                this.Close();

            }
            

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Открыть шифр Виженера?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Открыть шифр вертикальной перестановки?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form form3 = new Form11();
                form3.Show();
                this.Hide();
            }
           
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Очистить всё?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Открыть справку?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form9 form3 = new Form9();
                form3.Show();
                
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char K = e.KeyChar;
            if((K < '0' || K > '9') && K != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char K = e.KeyChar;
            if ((K < 'А' || K > 'я') && K != '\b' && K != '-' && K != ',' && K != '.' && K != ' ' && K != '!' && K != '?')
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text!="")
            {
                button1.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
            }
        }
    }
}
