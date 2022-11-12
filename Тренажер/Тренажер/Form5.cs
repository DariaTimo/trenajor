using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Тренажер
{
    public partial class Form5 : Form
    {
        string f;
        DataTable dTable;
        int key;
        
        int s, m, sm;

        public Form5(string fr, DataTable DT, int k)
        {
            InitializeComponent();
            f = fr;
            dTable = DT;
            key = k;
            timer1.Interval = 1000;
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Rew();
            textBox1.Text = Convert.ToString(key);
            toolStripButton1.Text = "Справка";

            timer1.Enabled = true;

            toolStripStatusLabel1.Text = "00";
            toolStripStatusLabel3.Text = "00";
            
            s = 0;
            m = 0;
            sm = 0;
            button3.Enabled = false;
            button4.Enabled = false;


        }
        private void Rew()
        {
            string sfr = new String(new char[f.Length]);

           

            List<string> list = new List<string>();
            for(int i = 0; i < f.Length; i++)
            {
                list.Add(Convert.ToString(f[i]));
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] ==" " || list[i] == "," || list[i] == "."|| list[i] == "-" || list[i] == "!" || list[i] == "?" || list[i]=="" )
                {
                    sfr = list[i];
                    richTextBox1.Text += sfr;

                }
                else
                {
                    for (int j = 0; j < dTable.Columns.Count; j++)
                    {
                        if (f[i] == Convert.ToChar(dTable.Columns[j].ColumnName))
                        {
                            sfr = Convert.ToString(dTable.Rows[j][1]);
                            richTextBox1.Text += sfr;
                        }
                    }
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(dTable);
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
            
            if (gf.Length == f.Length)
            {


                for (int i = 0; i < gf.Length; i++)
                {
                    if (f[i] == gf[i])
                    {
                        p++;
                        
                        
                        

                    }
                    else
                    {
                        n++;
                        
                    }
                }
                if (p==f.Length)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
           richTextBox2.Text = f;
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

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Form form2 = Application.OpenForms[1];
            //form2.Show();

            for(int i = Application.OpenForms.Count-1; i >0 ; i--)
            {
                if (Application.OpenForms[i].Name != "Form2")
                {
                    Application.OpenForms[i].Close();
                }
                
            }
            Form form2 = Application.OpenForms[0];
            form2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
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
                    if(m==1)
                        {
                            button3.Enabled = true;
                        }
                    if (m == 3)
                    {
                        button4.Enabled = true;
                    }
                }
                    else
                    {
                        m = 0;
                    toolStripStatusLabel1.Text = "00";
                    }

                }
               
            


        }
    }
    
}
