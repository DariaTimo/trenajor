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
    public partial class Form6 : Form
    {
        DataTable dTable;
        public Form6(DataTable DT)
        {
            InitializeComponent();
            dTable = DT;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            char j;
            for (int colum = 0; colum < dTable.Columns.Count; colum++)
            {
                string ColumName = dTable.Columns[colum].ColumnName;
                dataGridView1.Columns.Add(ColumName, ColumName);
                dataGridView1.Columns[colum].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



            }
            dataGridView1.Rows.Add();
            for (int i = 0; i < dTable.Columns.Count; i++)
            {
                j = Convert.ToChar(dTable.Rows[i][1]);
                dataGridView1.Rows[0].Cells[i].Value = j;
            }

        }
    }
}
