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
using System.Data.SQLite;
using System.Data.Entity;

namespace ShopTrade
{
    public partial class Colors : Form
    {
        int c ;
        int r ;
        int id;
        string cel;
        string n1;
        String dbFileName = "Colors.db";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        readonly DataSet ds = new DataSet();
        readonly DataTable dt = new DataTable();
        public Colors()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddColor formAC = new AddColor();
            formAC.ShowDialog();
        }

        private void Colors_Load(object sender, EventArgs e) // Добавить краску
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            DataTable dTable = new DataTable();
            String sqlQuery;
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }

            try
            {
                sqlQuery = "SELECT * FROM Colors";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                dataGridView1.DataSource = dTable;


            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            dataGridView1.Columns[0].HeaderText = "Порядковый номер";
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[0].ReadOnly = true;

        }

        private void Button2_Click(object sender, EventArgs e) // применение изменений в ячейках
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            cel = textBox1.Text.ToString();
            id = int.Parse(dataGridView1[0,r].Value.ToString());
            if (c == 1)
                n1 = "Name";
            else if (c == 2)
                n1 = "Quantity";
            try
            {
                m_sqlCmd.CommandText = "UPDATE Colors SET " + n1 + " = '" + cel +"' WHERE ColorId = '" + id + "';";

                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void Button3_Click(object sender, EventArgs e) // Обновление таблицы
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            DataTable dTable = new DataTable();
            String sqlQuery;
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }

            try
            {
                sqlQuery = "SELECT * FROM Colors";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                dataGridView1.DataSource = dTable;


            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            dataGridView1.Columns[0].HeaderText = "Порядковый номер";
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[0].ReadOnly = true;
        }

        private void DataGridView1_EditModeChanged(object sender, EventArgs e)
        {
       
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox1.Text = (dataGridView1.CurrentCell.Value).ToString();
            c = dataGridView1.CurrentCell.ColumnIndex;
            r = dataGridView1.CurrentCell.RowIndex;
        }
    }
}
