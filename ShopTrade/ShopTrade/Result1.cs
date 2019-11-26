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
        DateTime pickedD = new DateTime();
        int pickedD2;
        String dbFileName = "ShopTrade.db";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        readonly DataSet ds = new DataSet();
        readonly DataTable dt = new DataTable();
        string pd1, pd2;
        public Result1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }
        public void ChooseDay(string pd1, string pd2)
        {
           

        }
        private void Result1_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            button2.Visible = false;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String sqlQuery;
            //string dt;
            pickedD = dateTimePicker1.Value;
            string pd = pickedD.ToString();
            string[] piD = pd.Split('/');
          //  string[] md;
            DataTable dTable = new DataTable();

            //sqlQuery = "SELECT DateTrade FROM Baskets WHERE условие;";
            pickedD.Date.ToString();//день
            pickedD = pickedD.AddDays(1);//следующий день
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            pd1 = piD[0] + '/' + piD[1] + '/' + DateTime.Now.Year.ToString();
            
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

            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                sqlQuery = "SELECT * FROM Baskets" +
                " WHERE DateTrade LIKE '%" +pd1 +"%'; ";
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
            for (int i = dd - 2; i >= 0; i--)
            {
                    if (dataGridView1[1, i].Value.ToString() == "1")
                        pr1 = pr1 + double.Parse(dataGridView1[6, i].Value.ToString());
                    else pr2 = pr2 + double.Parse(dataGridView1[6, i].Value.ToString());
                
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
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           comboBox1.Visible = true;
            dateTimePicker1.Visible = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            pickedD = dateTimePicker1.Value;
            pickedD2 = comboBox1.SelectedIndex;
            string pd1 = pickedD.ToString();
            string pd2 = pickedD2.ToString();
           // string[] md;
            DataTable dTable = new DataTable();

            string[] days = new string[12] { "31", "28", "31", "30", "31", "30", "31", "31", "30", "31", "30", "31" };
            if (int.Parse(DateTime.Now.Year.ToString()) % 4 == 0)
                days[1] = "29";
            int dd = 0;
            int[] m = new int[12];
            int pdD2 = 0;
            DateTime pdD = dateTimePicker1.Value;
            pdD2 = comboBox1.SelectedIndex;
            string p = pdD.ToString();
            string p2 = (pdD2+1).ToString() + '/' + days[pdD2] + '/' + DateTime.Now.Year ;
            string[] piD = p.Split('/');
            piD[2] = piD[2].Substring(0, 4);
            string[] piD2 = p2.Split('/');
            pd1 = piD[0] + '/' + piD[1] + '/' + piD[2];
            pd2 = piD2[0] + '/' + piD2[1] + '/' + piD2[2];
            string da;
            String sqlQuery;
            //string dt;
            m[0] = 0;
            pdD2 = int.Parse(days[pdD2]);
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            for (int i = 0; i <= pdD2; i++)
            {

                if (m[0] == 0)
                {
                    da = piD2[0] + '/' + (i).ToString() + '/' + piD[2];
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

                    if (m_dbConn.State != ConnectionState.Open)
                    {
                        MessageBox.Show("Open connection with database");
                        return;
                    }
                    try
                    {
                        sqlQuery = "SELECT * FROM Baskets" +
                        " WHERE DateTrade LIKE '%" + da + "%'; ";
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                        adapter.Fill(dTable);
                        dataGridView1.DataSource = dTable;
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
               
            }
            double pr1 = 0;
            double pr2 = 0;
            //dataGridView1.CurrentCell = null;
            dd = dataGridView1.RowCount;
            for (int i = dd - 2; i >= 0; i--)
            {
                if (dataGridView1[1, i].Value.ToString() == "1")
                    pr1 = pr1 + double.Parse(dataGridView1[6, i].Value.ToString());
                else pr2 = pr2 + double.Parse(dataGridView1[6, i].Value.ToString());

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
        }
    }
}
