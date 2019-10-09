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
    public partial class EditProduct : Form
    {
        readonly int data;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        private readonly String dbFileName = "ShopTrade.db";
        public EditProduct(int data)
        {
            InitializeComponent();
            // this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainMenu MM = this.Owner as MainMenu;
            this.KeyPreview = true;
            this.data = data;
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            MainMenu MM = this.Owner as MainMenu;
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
                sqlQuery = "SELECT * FROM Products WHERE ProductId = "+data+";";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                textBox1.Text = dTable.Rows[0][1].ToString();
                textBox2.Text = dTable.Rows[0][2].ToString();
                textBox3.Text = dTable.Rows[0][3].ToString();
                textBox4.Text = dTable.Rows[0][4].ToString();
                textBox5.Text = dTable.Rows[0][5].ToString();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                m_sqlCmd.CommandText = "UPDATE Products SET "+
                "Name = '"+ textBox1.Text.ToString()       + "', "+ 
                "Articule = '"+ textBox2.Text.ToString()    + "', " +
                "Quantity = "+ textBox3.Text.ToString()    + ", " +
                "Country = '"+ textBox4.Text.ToString()     + "', " +
                "Price = "+ textBox5.Text.ToString()       + 
                " WHERE ProductId = " + data + "; ";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
            this.Close();
        }
    }
}
