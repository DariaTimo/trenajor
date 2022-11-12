using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Тренажер
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k;
            int g;
            int m;
            
            m = 0;
            g = 0;
            k = Convert.ToInt32(textBox1.Text);
            string num, fr;
            num = Convert.ToString(textBox2.Text);
            fr = Convert.ToString(richTextBox1.Text);
            if (k>=5 && k<=20 )
            {
                int[] a = textBox2.Text.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
                if (a.Length==k)
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i]<=k)
                        { 
                            for (int j = i+1; j < a.Length; j++)
                            {
                                if (a[i] == a[j])
                                {
                                    g++;
                                   
                                }
                                
                            }

                        }
                        else
                        {
                            m++;
                        }

                    }
                    if (g==0)
                    {   
                        if (m==0)
                        {
                            Form form = new Form12(k, num, fr);
                            form.Show();
                            this.Hide();

                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("не существует столбца", "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Введенные числа не соответствуют столбцам", "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    
                }
                else
                {
                    DialogResult result = MessageBox.Show("Введите числа по количеству столбцов", "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                

            }
            else
            {
                DialogResult result = MessageBox.Show("Введите число от 5 до 20", "Cообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char K = e.KeyChar;
            if ((K < '0' || K > '9') && K != '\b')
            {
                e.Handled = true;
                
            }
            

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char K = e.KeyChar;
            if ((K < 'А' || K > 'я') && K != '\b' &&  K != ',' && K != '.' && K != ' ')
            {
                e.Handled = true;
            }
            
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char K = e.KeyChar;
            if ((K < '0' || K > '9') && K != '\b'&& K!=' ')
            {
                e.Handled = true;
            }
            

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            toolStripButton1.Text = "Главное меню";
            toolStripButton2.Text = "Шифр Цезаря";
            toolStripButton3.Text = "Шифр Виженера";
            toolStripButton4.Text = "Сбросить";
            toolStripButton5.Text = "Справка";
            button1.Enabled = false;
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
            DialogResult result = MessageBox.Show("Открыть шифр Цезаря?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form2 form3 = new Form2();
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
                richTextBox1.Clear();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Открыть справку?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form13 form3 = new Form13();
                form3.Show();

            }
        }
        private void Form11_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form2 = Application.OpenForms[0];
            form2.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && textBox1.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
        }
    }
}
