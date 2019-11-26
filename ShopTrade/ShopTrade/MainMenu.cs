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
using System.Diagnostics;

namespace ShopTrade
{
    public partial class MainMenu : Form
    {

        
       string s1 = "<table border = \"2\" cellpadding=\"1\" cellspacing=\"1\" style=\"width: 740px; border-style: solid;border-color: black;\">";
       string s2 = "<tbody>";
       string s3 = "<tr>";
       string cn1 = "<td style = \"width: 350px;max-width:350px;\"><font size=\"3\"><font face=\"Arial, Helvetica, sans-serif\">"; //Название
       string cn2 = "</font></font></td>";
       string ca1 = "<td style = \"width: 200px;max-width:200px;\"><font size=\"3\"><font face=\"Arial, Helvetica, sans-serif\">";//Артикул
       string ca2 = "</font></font></td>"; //Артикул
       string cq1 = "<td style = \"width: 100px;max-width:100px;\"><font size=\"3\"><font face=\"Arial, Helvetica, sans-serif\">"; // количество
       string cq2 = "</font></font></td>"; // количество
       string cp1 = "<td style = \"width: 90px;max-width:90px;\"><font size=\"3\"><font face=\"Arial, Helvetica, sans-serif\">"; //Цена
       string cp2 = "</font></font></td>"; //Цена
       string s4 = "</tr>";
       string s5 = "</tbody>";
       string s6 = "</table>";

        private readonly String dbFileName = "ShopTrade.db";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        int n = 0;
        DataTable dt1;
        readonly DataSet ds = new DataSet();
        readonly DataTable dt = new DataTable();
        public double tv = 0;
        // readonly int SellN = 0;
        public void LoadBase(DataGridView dg)
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
                    sqlQuery = "SELECT * FROM Products";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                    adapter.Fill(dTable);
                    dg.DataSource = dTable;
                    //for (int i = 0; i < dTable.Rows.Count; i++)
                    //  dataGridView1.Rows.Add(dTable.Rows[i].ItemArray);

                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            dt1 = ((DataTable)dataGridView1.DataSource).Clone();
          
           

        }
        public MainMenu()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            ds.Tables.Add(dt);           
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            // textBox1.Width = textBox1.Width * 2;
            this.KeyPreview = true;
        } 

        private void Exit_Click(object sender, EventArgs e)//кнопка закрытия
        {
            Close();
        }
        /// ////////////////////////////
        private void EntProduct_Click(object sender, EventArgs e)//кнопка ввода товара
        {
            AddProduct form2 = new AddProduct();
            form2.ShowDialog();
        }
        /// ////////////////////////////
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
            l1 = l1 + 10;
            textBox1.Top = t2;          //Ввод поиска
            textBox1.Left = l1;         //Ввод поиска
            textBox1.Width = formW - 44 - label1.Left - label1.Width ;   //Ввод поиска
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
        /// ////////////////////////////
        private void MainMenu_Load(object sender, EventArgs e)
        {

            string nF = "ff";
            string first ;
            if (!System.IO.File.Exists(nF))
            { 
                StreamWriter file = new StreamWriter(@nF);
                file.Write("");
                file.Close();
            }
            StreamReader sr = new StreamReader(@nF);
            sr.BaseStream.Position = 0;

            first = (sr.ReadToEnd()).ToString();
            sr.Close();
            ///////////////////////////////
            //Проверка на открытие смены
            ///////////////////////////////
            if (first == "1")
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns["ProductId"].Visible = false;

                dataGridView1.ContextMenuStrip = contextMenuStrip2;
                LoadBase(dataGridView1);

            }
            else
            {
                
                StreamWriter sw = new StreamWriter(@nF);
                sw.Write("1");
                sw.Close();
                Attention form = new Attention();
                form.ShowDialog();

            }

        }
        /// ////////////////////////////
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        /// ////////////////////////////
        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }
        /// ////////////////////////////
        private void Button3_Click(object sender, EventArgs e) //добавить в корзину
        {
            if (dataGridView1.CurrentRow == null)
            {
                AddInBask formN = new AddInBask();
                formN.ShowDialog();
            }
            else
            {
                //if (dataGridView2.Rows.Count == 0)
                    n = dataGridView2.Rows.Count-1;
                int tr = 0;
                int ind = dataGridView1.CurrentRow.Index; // индекс выделенной строки
                int qua = int.Parse((dataGridView1[3, ind].Value).ToString()); // количество, в выделенной строке  
                dataGridView1[3, ind].Value = int.Parse((dataGridView1[3, ind].Value).ToString()) - 1; // минус 1 в таблице

                    for (int i = 0; i < n; i++)
                    {
                        if (dataGridView1[1, ind].Value == dataGridView2[0, i].Value)
                        {
                            //dt1.ImportRow(((DataTable)dataGridView1.DataSource).Rows[ind]);
                            dataGridView2[2, i].Value = int.Parse((dataGridView2[2, i].Value).ToString()) + 1; // введенное значение в корзине
                            tv += double.Parse((dataGridView1[5, ind].Value).ToString());
                            tr = 1;
                            goto qwer;
                        }
                    }
                    if (tr == 0)
                    {
                        dt1.ImportRow(((DataTable)dataGridView1.DataSource).Rows[ind]);
                        dataGridView2.DataSource = dt1;
                        dataGridView2[2, n].Value = qua - int.Parse((dataGridView1[3, ind].Value).ToString()); // введенное значение в корзине
                        tv += double.Parse((dataGridView1[5, ind].Value).ToString());
                    }
            
                qwer:
                label3.Text = "К ОПЛАТЕ: " + tv;
                dt1.AcceptChanges();
                
            }
        }
        /// ////////////////////////////
        private void Button2_Click(object sender, EventArgs e)//оплата
        {
            Payment formP = new Payment(tv)
            {
                Owner = this
            };
            formP.ShowDialog();
        }
        /// ////////////////////////////
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// ////////////////////////////
        private void EditProduct_Click(object sender, EventArgs e)//Редактировать
        {
            int ind = dataGridView1.CurrentRow.Index;
            int PrId = int.Parse(dataGridView1.Rows[ind].Cells[0].Value.ToString());
            Password formP = new Password(PrId);
            formP.ShowDialog();
        }
        /// ////////////////////////////
        private void DelProduct_Click(object sender, EventArgs e)//Удалить продукт
        {

            if (dataGridView1.CurrentRow != null)
            {
                int ind = dataGridView1.CurrentRow.Index;
                int PrId = int.Parse(dataGridView1.Rows[ind].Cells[0].Value.ToString());
                PasswordD formP = new PasswordD(PrId);
                formP.ShowDialog();
            }
            else
            {
                NotSelect formN = new NotSelect();
                //this.Hide();
                formN.ShowDialog();
                //this.Close();
            }
        }
        private void Button4_Click(object sender, EventArgs e)//Удалить из корзины
        {
           
            if (n != 0)
            {
                int ind = dataGridView2.CurrentRow.Index; // индекс выделенной строки
                int qua = int.Parse((dataGridView2[2, ind].Value).ToString()); // количество, в выделенной строке  
                n--;
                dataGridView1[3, ind].Value = int.Parse((dataGridView1[3, ind].Value).ToString()) + qua; // минус 1 в таблице
                tv -= double.Parse(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString()) * qua;
                dataGridView2.Rows.Remove(dataGridView2.Rows[dataGridView2.CurrentRow.Index]);
                label3.Text = " К ОПЛАТЕ: " + tv;
                LoadBase(dataGridView1);
            }
            else
            {
               
                DelBask formD = new DelBask();
                formD.ShowDialog();
            }
        }
        /// ////////////////////////////Итоги
        private void InfoDay_Click(object sender, EventArgs e)//Помощь
        {
            Result1 formR = new Result1();
            formR.ShowDialog();
        }
        /// ////////////////////////////Помощь
        private void Help_Click(object sender, EventArgs e)//Краски
        {
        
        }
        /// ////////////////////////////Краски
        private void КраскиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colors formС = new Colors();
            formС.ShowDialog();
        }
        /// ////////////////////////////
        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        /// ////////////////////////////
        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }
        /// ////////////////////////////Поиск
        private void TextBox1_KeyPress(object sender, KeyEventArgs e)//Поиск
        {
            int n = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    var Row = dataGridView1.Rows[i];
                    Row.Selected = false;

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (Row.Cells[j].Value != null)
                    {
                        if (Row.Cells[j].Value.ToString().ToLower() == (textBox1.Text.ToLower()))
                        {
                            n = 1;
                            Row.Selected = true;
                            dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        }
                    }
                }
            }
                if (n == 0)
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var Row = dataGridView1.Rows[i];
                Row.Selected = false;

                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (Row.Cells[j].Value != null)
                        {
                            if (Row.Cells[j].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                            {
                                n = 1;
                                Row.Selected = true;
                                dataGridView1.FirstDisplayedScrollingRowIndex = i;
                            }
                        }
                    }
            }
                

            dt1 = ((DataTable)dataGridView1.DataSource).Clone();
        }

        private void НастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings S = new Settings();
            S.ShowDialog();
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About S = new About();
            S.ShowDialog();
        }

        private void MainMenu_Activated(object sender, EventArgs e)
        {
            LoadBase(dataGridView1);
        }

        private void ПечатьЦенниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPr S = new PrintPr();
            S.ShowDialog();
        }

        private void ПереучётToolStripMenuItem_Click(object sender, EventArgs e)    
        {
            int count = dataGridView1.Rows.Count;

            StreamWriter sw = new StreamWriter(@"full.html");
            sw.WriteLine(s1);
            sw.WriteLine(s2);
            /////////////////////////////////////////////////////////
            sw.WriteLine(s3); //начало строки таблицы

            sw.WriteLine(cn1 + "Наименование" + cn2);//название 

            sw.WriteLine(ca1 + "Артикул" + ca2);//название 

            sw.WriteLine(cq1 + "Количество" + cq2);//название 

            sw.WriteLine(cp1 + "Цена" + cp2);//название 


            for (int i = 0; i <= count - 2; i++)
                    {

                        string name = dataGridView1[1, i].Value.ToString();
                        string art = dataGridView1[2, i].Value.ToString();
                        int quan = int.Parse(dataGridView1[3, i].Value.ToString());
                        float price = float.Parse(dataGridView1[5, i].Value.ToString());

                    /////////////////////////////////////////////////////////
                    sw.WriteLine(s3); //начало строки таблицы

                    sw.WriteLine(cn1 + name + cn2);//название 

                    sw.WriteLine(ca1 + art + ca2);//артикул 
                ///
                if (quan <= 0)
                {
                    sw.WriteLine(cq1 + "||&nbsp;" + quan + "&nbsp;||" + cq2);//количество

                }
                else sw.WriteLine(cq1 + quan + cq2);//количество
                ///
                     sw.WriteLine(cp1 + price + "&nbsp; руб." + cp2);//цена

                     sw.WriteLine(s4); //конец строки таблицы

                                        ////////////////////////////////////////////////////////////
            }
            sw.WriteLine(s5); // конец таблицы
            sw.WriteLine(s6); // пустая строка
            sw.Close();
            Process.Start("full.html");
        }

        private void резервнаяКопияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordR S = new PasswordR();
            S.Show();

        }

        private void загрузкаПоследнихБазToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection("Data Source=" + "Colors.db" + ";Version=3;");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            m_dbConn.Dispose();
            GC.Collect();
            PasswordL S = new PasswordL();
            S.Show();

        }
    }
}
