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
    public partial class MainMenu : Form
    {
        
        private readonly String dbFileName = "ShopTrade.db";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        int n = 0;
        DataTable dt1;
        readonly DataSet ds = new DataSet();
        readonly DataTable dt = new DataTable();
        public double tv = 0;
        readonly int SellN = 0;

        public class BasContext : DbContext
        {

            public BasContext()
                : base("DBConnection")
            { }

            public DbSet<Basket> Baskets { get; set; }
        }
        public MainMenu()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            ds.Tables.Add(dt);
            DateTime mod = new DateTime();
            mod = DateTime.Today;
            StreamWriter sw = new StreamWriter(@"dd.ddd");
            sw.Write(mod.ToString());
            sw.Close();
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
           // textBox1.Width = textBox1.Width * 2;
        }

        private void Exit_Click(object sender, EventArgs e)//кнопка закрытия
        {
            Close();
        }

        private void EntProduct_Click(object sender, EventArgs e)//кнопка ввода товара
        {
            AddProduct form2 = new AddProduct();
            this.Hide();
            form2.ShowDialog();
            this.Close();
        }

        private void OpenDay_Click(object sender, EventArgs e)//Открытие смены
        {
            string nF = "dd.ddd";
            
            DateTime mod= new DateTime();
            DateTime openD=new DateTime();

            StreamReader sr = new StreamReader(@nF);
            sr.BaseStream.Position = 0;

            openD = DateTime.Parse(sr.ReadToEnd());
            sr.Close();
            mod = DateTime.Today;
            ///////////////////////////////
            //Проверка на открытие смены
            ///////////////////////////////
            if (openD.DayOfYear == mod.DayOfYear)
            {
                WarningOpenDay form4 = new WarningOpenDay();
                form4.ShowDialog();

            }
            else
            {
                StreamWriter sw = new StreamWriter(@"dd.ddd");
                sw.Write(mod.ToString());
                sw.Close();

                NewDay form5 = new NewDay();
                form5.ShowDialog();


            }
        }

        private void CloseDay_Click(object sender, EventArgs e)//кнопка закрытия смены
        {
            CloseDay form3 = new CloseDay();
            form3.ShowDialog();
        }

        private void MainMenu_Resize(object sender, EventArgs e)
        {
            int formW = Width;
            int h = label1.Height + button2.Height + dataGridView2.Height + label3.Height+40*4;
            dataGridView1.Height = Height - h; //Корзина таблица
            dataGridView1.Width = formW - 44;//Отображение товара
            int t1 = dataGridView1.Top + dataGridView1.Height + 10;
            label1.Top = t1;            //поиск по 
            t1 = t1 + label1.Height + 25;
            button2.Top = t1;           //Оплата
            t1 = t1 + button2.Height + 25;
            dataGridView2.Left = dataGridView1.Left;//Корзина таблица
            dataGridView2.Top = t1;         //Корзина таблица
            dataGridView2.Width = formW -44;//Корзина таблица
            t1 = t1 + dataGridView2.Height + 5;
            label3.Top = t1;            //К оплате
            int t2 = label1.Top;
            int l1 = label1.Left + label1.Width + 10;
            comboBox1.Top = t2;         //Критерий поиска
            comboBox1.Left = l1;        //Критерий поиска
            l1 = l1 + comboBox1.Width + 10;
            textBox1.Top = t2;          //Ввод поиска
            textBox1.Left = l1;         //Ввод поиска
            textBox1.Width = formW - 44 - label1.Left - label1.Width - comboBox1.Width;   //Ввод поиска
            int l2 = Convert.ToInt32((dataGridView2.Width - label2.Width) / 2);
            int t3 = dataGridView2.Top - 45;
            label2.Left = l2;           //Корзина
            label2.Top = t3;            //Корзина
            int t4 = label2.Top+button4.Height -65 ;
            int t5 = label2.Top + button4.Height - 25;
            int l3 = formW - 28 - button3.Width;
            int l4 = formW - 28 - button4.Width;
            button3.Top = t4;           //Добавить в корзину
            button3.Left = l3;          //Добавить в корзину
            button4.Top = t5;           //Удалить с корзины
            button4.Left = l4;          //Удалить с корзины

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns["ProductId"].Visible = false;
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateTime OpenD = new DateTime();
            StreamReader sr = new StreamReader(@"dd.ddd");
            OpenD = DateTime.Parse(sr.ReadToEnd());
            sr.Close();
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            if (OpenD.DayOfYear != DateTime.Today.DayOfYear)
            {
                Warning2NewDay form6 = new Warning2NewDay();
                form6.ShowDialog();
            }
            else
            {

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
                    sqlQuery = "SELECT * FROM Products";
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
                //  this.productsTableAdapter.Fill(this.DBSDataSet1.Products);
                // dataGridView1.DataSource = DBSDataSet1.Products;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                dataGridView1.FirstDisplayedScrollingRowIndex = i;
                                break;
                            }
                }

            }
           dt1 = ((DataTable)dataGridView1.DataSource).Clone();
        }
        
        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }

        private void Button3_Click(object sender, EventArgs e) //добавить в корзину
        {
            if (dataGridView1.CurrentRow == null)
            {
                AddInBask formN = new AddInBask();
                formN.ShowDialog();
            }
            else
            {
                if (dataGridView2.Rows.Count == 0)
                    n = 0;
                int tr = 0;
                int ind = dataGridView1.CurrentRow.Index; // индекс выделенной строки
                int qua = int.Parse((dataGridView1[3, ind].Value).ToString()); // количество, в выделенной строке  
                dataGridView1[3, ind].Value = int.Parse((dataGridView1[3, ind].Value).ToString()) - 1; // минус 1 в таблице

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {

                    for (int i = 0; i < n; i++)
                    {
                        if (dataGridView1[1, ind].Value == dataGridView2[0, i].Value)
                        {
                            // dt1.ImportRow(((DataTable)dataGridView1.DataSource).Rows[row.Index]);
                            dataGridView2[2, i].Value = int.Parse((dataGridView2[2, i].Value).ToString()) + 1; // введенное значение в корзине
                            tv += double.Parse((dataGridView2[3, i].Value).ToString());
                            tr = 1;
                            goto qwer;
                        }
                    }
                    if (tr == 0)
                    {
                        dt1.ImportRow(((DataTable)dataGridView1.DataSource).Rows[row.Index]);
                        dataGridView2.DataSource = dt1;
                        dataGridView2[2, n].Value = qua - int.Parse((dataGridView1[3, ind].Value).ToString()); // введенное значение в корзине
                        tv += double.Parse((dataGridView2[3, n].Value).ToString());
                    }

                }
                n++;
                qwer:
                label3.Text = "К ОПЛАТЕ: " + tv;
                dt1.AcceptChanges();
                
            }
            //dataset2 = dataGridView2.DataSource;
            // dataset2.WriteXml("1.xml");//сериализовать в файл все данные из датасет
        }

        private void Button2_Click(object sender, EventArgs e)//оплата
        {
            //dataGridView2.DataSource = ds.Tables[0];
            ds.WriteXml("1.xml");
            Payment formP = new Payment(tv)
            {
                Owner = this
            };
            //this.Hide();
            formP.ShowDialog();
            //this.Close();
            if (formP.ff == false)
            { n = 0; tv = 0; }
            else { ds.WriteXml("1.xml"); }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditProduct_Click(object sender, EventArgs e)
        {

        }

        private void DelProduct_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int prID;
                int ind = dataGridView1.CurrentRow.Index;
                prID = int.Parse(dataGridView1.Rows[ind].Cells[0].Value.ToString());
                DataTable dTable = new DataTable();
                String sqlQuery = "DELETE FROM Products " +
                    "WHERE productId = " + prID + ";";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                sqlQuery = "SELECT * FROM Products";
                SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter2.Fill(dTable);
                dataGridView1.DataSource = dTable;

                //  DBSDataSet1.Products.Rows.RemoveAt(ind);
                // productsTableAdapter.Update(DBSDataSet1.Products);
              //  dataGridView1.DataSource = DBSDataSet1.Products;
               // DataRow row = DBSDataSet1.Products.Rows[ind];
               // DBSDataSet1.Products.Rows.Remove(row);
            }
            else
            {
                NotSelect formN = new NotSelect();
                //this.Hide();
                formN.ShowDialog();
                //this.Close();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
           
            if (n != 0)
            {
                int ind = dataGridView2.CurrentRow.Index; // индекс выделенной строки
                int qua = int.Parse((dataGridView2[2, ind].Value).ToString()); // количество, в выделенной строке  
                n--;
                dataGridView1[3, ind].Value = int.Parse((dataGridView1[3, ind].Value).ToString()) + qua; // минус 1 в таблице
                tv -= double.Parse(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString()) * qua;
                dataGridView2.Rows.Remove(dataGridView2.Rows[dataGridView2.CurrentRow.Index]);
                label3.Text = "К ОПЛАТЕ: " + tv;
            }
            else
            {
               
                DelBask formD = new DelBask();
                formD.ShowDialog();
            }
        }

        private void InfoDay_Click(object sender, EventArgs e)
        {
            DayResults formD = new DayResults();
            formD.ShowDialog();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();
            String sqlQuery = "DELETE FROM Baskets; ";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
        }
    }
}
