using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.IO;
using System.Data.SQLite;
using System.Data.Entity;

namespace ShopTrade
{
    public partial class Result1 : Form
    {
        String dbFileName = "ShopTrade.db";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        readonly DataSet ds = new DataSet();
        readonly DataTable dt = new DataTable();
        public Result1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }

        private void Result1_Load(object sender, EventArgs e)
        {
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String sqlQuery;
            string dt;
            DateTime pickedD = new DateTime();
            pickedD = dateTimePicker1.Value;
            string pd = pickedD.ToString();
            string[] piD = pd.Split('/');
            string[] md;

            //sqlQuery = "SELECT DateTrade FROM Baskets WHERE условие;";
            pickedD.Date.ToString();//день
            pickedD = pickedD.AddDays(1);//следующий день
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
                }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            double pr1 = 0;
            double pr2 = 0;
            //dataGridView1.CurrentCell = null;
            int dd = dataGridView1.RowCount;
            for (int i = dd-2; i >= 0; i--)
            {
                dt = dataGridView1[5, i].Value.ToString();
                md = dt.Split('/');
                if (md[1] != piD[1])
                {
                    dataGridView1.CurrentCell = null;
                    dataGridView1.Rows.RemoveAt(i);
                    //dataGridView1.Rows[i].Visible = false;
                }
                else
                {
                    if (dataGridView1[1, i].Value.ToString() == "1")
                        pr1 = pr1 + double.Parse(dataGridView1[6, i].Value.ToString());
                    else pr2 = pr2 + double.Parse(dataGridView1[6, i].Value.ToString());
                }
            }
            label1.Text = "Итого наличных: " + pr1 + " р. ; безналичных: " + pr2 + " р.";
            dd = dataGridView1.RowCount;
            for (int i = dd - 2; i >= 0; i--)
            {
                if (dataGridView1[1, i].Value.ToString() == "1")
                    dataGridView1[1, i].Value = "Наличный";
                else if (dataGridView1[1, i].Value.ToString() == "2")
                    dataGridView1[1, i].Value = "Безналичный";
                else if (dataGridView1[1, i].Value.ToString() == "3")
                    dataGridView1[1, i].Value = "Списано";
            }

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;  
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[1].HeaderText = "Вид оплаты";
            dataGridView1.Columns[2].HeaderText = "Наименование";
            dataGridView1.Columns[4].HeaderText = "Количество";
            dataGridView1.Columns[5].HeaderText = "Дата и время продажи";
            dataGridView1.Columns[6].HeaderText = "Цена";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            /*  dataGridView1.Columns[0].HeaderText = "Порядковый номер";
              dataGridView1.Columns[1].HeaderText = "Наименование";
              dataGridView1.Columns[2].HeaderText = "Количество";
              dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
              dataGridView1.Columns[0].ReadOnly = true;*/

            // label1.Text = String.Format("Вы выбрали: {0}", dateTimePicker1.Value.ToString());
        }
    }
}
