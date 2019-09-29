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
namespace ShopTrade
{
    public partial class DayResults : Form
    {
        readonly double data;
        public bool ff = false;
        readonly DataTable dTable = new DataTable();
        readonly String sqlQuery;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        private readonly String dbFileName = "ShopTrade.db";
        public DayResults()
        {
            InitializeComponent();
        }

        private void DayResults_Load(object sender, EventArgs e)
        {
            DateTime OpenD = new DateTime();
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
                sqlQuery = "SELECT * FROM Baskets";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                //for (int i = 0; i < dTable.Rows.Count; i++)
                //  dataGridView1.Rows.Add(dTable.Rows[i].ItemArray);

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            // TODO: This line of code loads data into the 'dBSDataSet1.Baskets' table. You can move, or remove it, as needed.

        }
    }
}
