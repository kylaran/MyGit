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

    public partial class Payment : Form
    {
        readonly double data;
        public bool ff = false;
        readonly DataTable dTable = new DataTable();
        readonly String sqlQuery;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        private readonly String dbFileName = "ShopTrade.db";

        public Payment(double data)
        {
            MainMenu form2 = this.Owner as MainMenu;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            this.data = data;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            //form2.Show();
            this.Close();
            ff = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;

            DateTime DT = DateTime.Now;
            float QuPr = 0;
            MainMenu form2 = this.Owner as MainMenu;
            form2.label3.Text = "К ОПЛАТЕ: 0";
            while (form2.dataGridView2.Rows.Count > 1)
                for (int i = 0; i < form2.dataGridView2.Rows.Count - 1; i++)
                {
                    int qu = int.Parse(form2.dataGridView2[2, i].Value.ToString());
                    string nam;
                    float pri;
                    nam = form2.dataGridView2.Rows[i].Cells[0].Value.ToString();
                    pri = int.Parse(form2.dataGridView2[2, i].Value.ToString());
                    DataTable dTable = new DataTable();
                    try
                    {
                        m_sqlCmd.CommandText = "UPDATE Products " +
                                        "SET Quantity = Quantity - " + qu +
                                         " WHERE (Name = '" + nam + "' ) AND (Price = "+pri+");";

                        m_sqlCmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                    QuPr = (float.Parse(form2.dataGridView2[3, i].Value.ToString()) * int.Parse(form2.dataGridView2[2, i].Value.ToString()));
                    try
                    {
                        m_sqlCmd.CommandText = "INSERT INTO Baskets ('Name', 'Country', 'Quantity', 'DateTrade', 'Price', 'BuyersID') values ('" +
                            form2.dataGridView2[0, i].Value + "' , '" + //наименование
                            form2.dataGridView2[1, i].Value + "' , '" + //страна
                            form2.dataGridView2[2, i].Value + "' , '" + //количество
                            DT + "' , '" + //дата продажи
                            QuPr + "' , '" + //цена
                            01 + "')"; //BuyersID Наличные

                        m_sqlCmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    form2.dataGridView2.Rows.Remove(form2.dataGridView2.Rows[i]);
                }
            this.Close();
        }

        private void Payment_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn; 
            DateTime DT = DateTime.Now;
            float QuPr = 0;
            MainMenu form2 = this.Owner as MainMenu;
            form2.label3.Text = "К ОПЛАТЕ: 0";
            while (form2.dataGridView2.Rows.Count > 1)
                for (int i = 0; i < form2.dataGridView2.Rows.Count - 1; i++)
                {
                    int qu = int.Parse(form2.dataGridView2[2, i].Value.ToString());
                    string nam;
                    nam = form2.dataGridView2.Rows[i].Cells[0].Value.ToString();
                    DataTable dTable = new DataTable();
                    try
                    {
                        m_sqlCmd.CommandText = "UPDATE Products " +
                                        "SET Quantity = Quantity - " + qu +
                                         " WHERE Name = '" + nam + "';";

                        m_sqlCmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    QuPr = (float.Parse(form2.dataGridView2[3, i].Value.ToString()) * int.Parse(form2.dataGridView2[2, i].Value.ToString()));
                    try
                    {
                        m_sqlCmd.CommandText = "INSERT INTO Baskets ('Name', 'Country', 'Quantity', 'DateTrade', 'Price', 'BuyersID') values ('" +
                            form2.dataGridView2[0, i].Value + "' , '" + //наименование
                            form2.dataGridView2[1, i].Value + "' , '" + //страна
                            form2.dataGridView2[2, i].Value + "' , '" + //количество
                            DT + "' , '" + //дата продажи
                            QuPr + "' , '" + //цена
                            02 + "')"; //BuyersID Безнал

                        m_sqlCmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    form2.dataGridView2.Rows.Remove(form2.dataGridView2.Rows[i]);
                }
            this.Close();
        }

        private void Payment_Load(object sender, EventArgs e)
        {

                label1.Text = "К ОПЛАТЕ: " + (data).ToString();

        }
    }
}
