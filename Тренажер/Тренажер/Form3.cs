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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Тренажер
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form2 = Application.OpenForms[0];
            form2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key;
            string fr;
            fr = richTextBox1.Text;
            key = textBox1.Text;
            


            
            //fr = fr.Trim().Replace(" ", string.Empty);
            fr = fr.ToUpper();
            key = key.ToUpper();
            Form7 form = new Form7(key, fr);
            form.Show();
            this.Hide();
        }

       

        private void Form3_Load(object sender, EventArgs e)
        {
            toolStripButton1.Text = "Главное меню";
            toolStripButton2.Text = "Шифр Цезаря";
            toolStripButton3.Text = "Шифр 3";
            toolStripButton4.Text = "Сбросить";
            toolStripButton5.Text = "Справка";
            textBox1.Clear();
            richTextBox1.Clear();
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
            DialogResult result = MessageBox.Show("Открыть шифр Цезаря?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form2 form3 = new Form2();
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
                richTextBox1.Clear();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Открыть справку?", "Cообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Form10 form3 = new Form10();
                form3.Show();

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char K= e.KeyChar;
            if ((K<'А' || K>'я')&&K!='\b')
            {
                e.Handled = true;
            }

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char K = e.KeyChar;
            if ((K < 'А' || K > 'я') && K != '\b' && K!='-' && K!=',' && K!='.' && K!=' ' && K != '!' && K != '?')
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
            }
        }
    }
}
