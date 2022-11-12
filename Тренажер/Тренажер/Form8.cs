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
    public partial class Form8 : Form
    {
        private SQLiteConnection SQLiteConn;
        private DataTable dTable;
        public Form8(DataTable dTable)
        {
            InitializeComponent();
            this.dTable = dTable;
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            SQLiteConn = new SQLiteConnection();
            dTable = new DataTable();




            SQLiteConn = new SQLiteConnection("Data Source=D:\\Практика\\3 курс\\СиППО\\Программа\\Tre.db ;Version=3;");
            SQLiteConn.Open();

            string SQLQuery = "SELECT *FROM Виженер";
            dTable.Clear();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQLQuery, SQLiteConn);
            adapter.Fill(dTable);

            ShowTable(dTable, dataGridView1);
            dataGridView1.EnableHeadersVisualStyles = false;
            for (int i = 0; i < dTable.Columns.Count; i++)
            {


                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.BlueViolet;
            }
            //toolStripButton1.Text = "Главное меню";
            //toolStripButton2.Text = "Шифр 2";
            //toolStripButton3.Text = "Шифр 3";
            //toolStripButton4.Text = "Сбросить";
            //toolStripButton5.Text = "Закрыть";
        }
        public void ShowTable(DataTable DTable, DataGridView Table) // Заполнение datagridView данными DataTable 
        {
            Table.Columns.Clear();
            Table.Rows.Clear();

            for (int colum = 0; colum < DTable.Columns.Count; colum++)
            {
                string ColumName = DTable.Columns[colum].ColumnName;
                Table.Columns.Add(ColumName, ColumName);
                Table.Columns[colum].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (int row = 0; row < DTable.Rows.Count; row++)
            {
                Table.Rows.Add(DTable.Rows[row].ItemArray);
            }
            foreach (DataGridViewColumn column in Table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i=0; i<Table.Rows.Count;i++)
            {
                Table[0, i].Style.BackColor = Color.LemonChiffon;
            }
                
              

        }

        
    }
}
