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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("D:\\Практика\\3 курс\\СиППО\\Программа\\Тренажер\\Тренажер\\bin\\Debug\\Alvi.JPG");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
