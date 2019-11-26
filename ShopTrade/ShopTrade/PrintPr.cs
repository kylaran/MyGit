using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Sql;
using System.IO;
using System.Data.Entity;
using System.Diagnostics;

namespace ShopTrade
{
    public partial class PrintPr : Form
    {
        //="<table border=\"1\" style=\"height: 86px; width: 400px; border-collapse: collapse; border: solid;\">"; 
        string s1 = "<table border = \"1\" width:\"500\" style = \"border-collapse: collapse; border: solid;\">";//начало таблицы
        string s2 = "<tbody>"; //начало таблицы
        string s3 = "<tr style=\"height: 15px;\">"; //начало строки таблицы
        string sl = "border-right: solid;"; // стиль ячеек в центре левых
        string sr = "border-left: solid;"; // стиль ячеек в центре правых
        string sc = "\"";
        string sn1 = "<td style=\"min-width:130px;max-width:130px; height: 86px; border-style: none;";//ячейка название
        string sn11= "><strong>&nbsp; "; //ячейка название
        string sn2 = "</strong></td>";//ячейка название
        string sd1 = "<td style=\"min-width:100px;max-width:100px; height: 23px; border-style: none; text-align: right; ";//ячейка дата
        string sd11 ="><strong>&nbsp; "; //ячейка дата
        string sd2 = "</strong></td>";//ячейка дата
        string snn1 = "<td style=\"min-width:3px; height: 23px; border-style: none;"; //пустая ячейка
        string snn2  = ">&nbsp; </td>"; //пустая ячейка
        string ser = "</tr>"; //конец строки
        string sa1 = "<td style=\"min-width:100px;max-width:100px; height: 23px; border-style: none;text-align: center;";//ячейка артикул
        string sa11= "><strong>&nbsp;"; //ячейка артикул
        string sa2 = "</strong></td>"; //ячейка артикул
        string sp1 = "<td style=\"min-width:100px;max-width:100px; height: 23px; border-style: none;text-align: right;";//ячейка цены
        string sp11 = "><strong><big><big>&nbsp;"; //ячейка цены
        string sp2 = " руб.</big></big></strong></td>"; //ячейка цены
        string sa = "<td style=\"min-width:100px;max-width:100px; height: 15px; border-style: none;";//ячейка код
        string saa =    "><strong><small>&nbsp;код:</small></strong></td>"; //ячейка код
        string sp = "<td style = \"min-width:100px; height: 15px; border-style: none;";// ячейка цена
        string spp  =  " ><small> &nbsp; цена:</small></td>"; // ячейка цена
        string sm1 = "<td style=\"min-width:100px;max-width:100px; height: 14px; border-style: none;text-align: right;";//Машбум
        string sm2 = "><strong><small><small>ООО \"МашБум\"</small></small></strong></td>"; //Машбум
        string s4 = "</tbody>";//конец таблицы
        string s5 = "</table>"; //конец таблицы
        string s6 = "<p></p> "; // пустая строчка
        string N = "<br>";
        private readonly String dbFileName = "ShopTrade.db";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        DataTable dt1;
        int n = 0;
        public PrintPr()
        {
            InitializeComponent();
        }
        public void PrintPrices (int count)
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            string nam;
            float pri;
            string art,art2,art3;
            int j=0,k=0;

            if (count == 1)
                MessageBox.Show("Не выбраны товары для печати!");
            else
            {
                StreamWriter sw = new StreamWriter(@"prices.html");
                if (count == 2)
                {
                    nam = dataGridView2[1, 0].Value.ToString();
                    pri = int.Parse(dataGridView2[4, 0].Value.ToString());

                    try
                    {
                        m_sqlCmd.CommandText = "SELECT Articule FROM Products " +
                                         " WHERE (Name = '" + nam + "' ) AND (Price = " + pri + ");";

                        m_sqlCmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                    object result = m_sqlCmd.ExecuteScalar();
                    art = Convert.ToString(result);

                    sw.WriteLine(s1);
                    sw.WriteLine(s2);
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(s3); //начало строки

                    sw.Write(sn1 + sc + sn11);//название               
                    sw.Write(dataGridView2[1, 0].Value.ToString());//название
                    sw.WriteLine(sn2);//название

                    sw.Write(sd1 + sl + sc + sd11);//дата                    
                    sw.Write(DateTime.Now.ToShortDateString());//дата
                    sw.WriteLine(sd2);//дата
                                      //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(snn1 + sc + snn2);//пустая строка
                                                   //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.Write(sn1 + sr + sc + sn11);//название    центр            
                    sw.Write(dataGridView2[1, 0].Value.ToString());//название центр
                    sw.WriteLine(sn2);//название центр

                    sw.Write(sd1 + sl + sc + sd11);//дата         центр            
                    sw.Write(DateTime.Now.ToShortDateString());//дата центр
                    sw.WriteLine(sd2);//дата центр
                                      //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(snn1 + sc + snn2);//пустая строка
                                                   //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.Write(sn1 + sr + sc + sn11); //название таблица справа  
                    sw.Write(dataGridView2[1, 0].Value.ToString());//название
                    sw.WriteLine(sn2);//название таблица справа

                    sw.Write(sd1 + sc + sd11); //дата таблица справа  
                    sw.Write(DateTime.Now.ToShortDateString());//дата
                    sw.WriteLine(sd2);//дата таблица справа

                    sw.WriteLine(ser); //конец строки
                                       //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(s3); //начало строки

                    sw.WriteLine(sa1 + sc + sa11 + art + sa2);// Артикул

                    sw.Write(sp1 + sl + sc + sp11);// Цена
                    sw.Write(dataGridView2[4, 0].Value.ToString());// Цена
                    sw.WriteLine(sp2);// Цена
                                      //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(snn1 + sc + snn2);//пустая строка
                                                   //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(sa1 + sr + sc + sa11 + art + sa2);// Артикул центр

                    sw.Write(sp1 + sl + sc + sp11);// Цена центр
                    sw.Write(dataGridView2[4, j].Value.ToString());// Цена центр
                    sw.WriteLine(sp2);// Цена центр
                                      //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(snn1 + sc + snn2);//пустая строка
                                                   //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.Write(sa1 + sr + sc + sa11 + art); // Артикул таблица справа       
                    sw.WriteLine(sa2);// Артикул

                    sw.Write(sp1 + sc + sp11);// Цена таблица справа  
                    sw.Write(dataGridView2[4, k].Value.ToString());// Цена
                    sw.WriteLine(sp2);// Цена таблица справа  

                    sw.WriteLine(ser); //конец строки 
                                       //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(s3); //начало строки

                    sw.Write(snn1 + sc);//пустая строка
                    sw.WriteLine(snn2);//пустая строка

                    sw.WriteLine(sm1 + sl + sc + sm2);//  МашБум
                                                      //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(snn1 + sc + snn2);//пустая строка
                                                   //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.Write(snn1 + sr + sc);//пустая строка центр
                    sw.WriteLine(snn2);//пустая строка центр

                    sw.WriteLine(sm1 + sl + sc + sm2);//  МашБум центр
                                                      //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(snn1 + sc + snn2);//пустая строка
                                                   //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    sw.Write(snn1 + sr + sc);//пустая строка таблица справа  
                    sw.WriteLine(snn2);//пустая строка таблица справа  

                    sw.WriteLine(sm1 + sc + sm2);//  МашБум таблица справа  

                    sw.WriteLine(ser); //конец строки
                                       //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine(s4); //конец таблицы
                    sw.WriteLine(s5); // конец таблицы
                    sw.WriteLine(s6); // пустая строка

                }
                else
                for (int i = 0; i <= count - 2; i++)
                {
                        
                        nam = dataGridView2[1,i].Value.ToString();
                        pri = float.Parse(dataGridView2[4, i].Value.ToString());

                        try
                        {
                            m_sqlCmd.CommandText = "SELECT Articule FROM Products " +
                                             " WHERE (Name = '" + nam + "' ) AND (Price = " + pri + ");";

                            m_sqlCmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        object result = m_sqlCmd.ExecuteScalar();
                        art = Convert.ToString(result);

                        if (i < (count-2))
                            j = i + 1;
                        if (j <(count-2))
                            k = j + 1;
                     /*   if (j == (count - 1))
                            j = (count - 2);*/

                        nam = dataGridView2[1, j].Value.ToString();
                        pri = float.Parse(dataGridView2[4, j].Value.ToString());

                        try
                        {
                            m_sqlCmd.CommandText = "SELECT Articule FROM Products " +
                                             " WHERE (Name = '" + nam + "' ) AND (Price = " + pri + ");";

                            m_sqlCmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        result = m_sqlCmd.ExecuteScalar();
                        art2 = Convert.ToString(result);

                        nam = dataGridView2[1, k].Value.ToString();
                        pri = float.Parse(dataGridView2[4, k].Value.ToString());

                        try
                        {
                            m_sqlCmd.CommandText = "SELECT Articule FROM Products " +
                                             " WHERE (Name = '" + nam + "' ) AND (Price = " + pri + ");";

                            m_sqlCmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        result = m_sqlCmd.ExecuteScalar();
                        art3 = Convert.ToString(result);
                        sw.WriteLine(s1);
                        sw.WriteLine(s2);
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(s3); //начало строки

                        sw.Write(sn1 + sc + sn11);//название               
                        sw.Write(dataGridView2[1, i].Value.ToString());//название
                        sw.WriteLine(sn2);//название

                        sw.Write(sd1 + sl + sc + sd11);//дата                    
                        sw.Write(DateTime.Now.ToShortDateString());//дата
                        sw.WriteLine(sd2);//дата
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(snn1 + sc + snn2);//пустая строка
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.Write(sn1 + sr + sc + sn11);//название    центр            
                        sw.Write(dataGridView2[1, j].Value.ToString());//название центр
                        sw.WriteLine(sn2);//название центр

                        sw.Write(sd1 + sl + sc + sd11);//дата         центр            
                        sw.Write(DateTime.Now.ToShortDateString());//дата центр
                        sw.WriteLine(sd2);//дата центр
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(snn1 + sc + snn2);//пустая строка
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.Write(sn1 + sr + sc + sn11); //название таблица справа  
                        sw.Write(dataGridView2[1, k].Value.ToString());//название
                        sw.WriteLine(sn2);//название таблица справа

                        sw.Write(sd1 + sc + sd11); //дата таблица справа  
                        sw.Write(DateTime.Now.ToShortDateString());//дата
                        sw.WriteLine(sd2);//дата таблица справа

                        sw.WriteLine(ser); //конец строки
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(s3); //начало строки

                        sw.WriteLine(sa1 + sc + sa11 + art + sa2);// Артикул

                        sw.Write(sp1 + sl + sc + sp11);// Цена
                        sw.Write(dataGridView2[4, i].Value.ToString());// Цена
                        sw.WriteLine(sp2);// Цена
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(snn1 + sc + snn2);//пустая строка
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(sa1 + sr + sc + sa11 + art2 + sa2);// Артикул центр

                        sw.Write(sp1 + sl + sc + sp11);// Цена центр
                        sw.Write(dataGridView2[4, j].Value.ToString());// Цена центр
                        sw.WriteLine(sp2);// Цена центр
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(snn1 + sc + snn2);//пустая строка
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.Write(sa1 + sr + sc + sa11 + art3); // Артикул таблица справа       
                        sw.WriteLine(sa2);// Артикул

                        sw.Write(sp1 + sc + sp11);// Цена таблица справа  
                        sw.Write(dataGridView2[4, k].Value.ToString());// Цена
                        sw.WriteLine(sp2);// Цена таблица справа  

                        sw.WriteLine(ser); //конец строки 
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(s3); //начало строки

                        sw.Write(snn1 + sc);//пустая строка
                        sw.WriteLine(snn2);//пустая строка

                        sw.WriteLine(sm1 + sl + sc + sm2);//  МашБум
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(snn1 + sc + snn2);//пустая строка
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.Write(snn1 + sr + sc);//пустая строка центр
                        sw.WriteLine(snn2);//пустая строка центр

                        sw.WriteLine(sm1 + sl + sc + sm2);//  МашБум центр
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(snn1 + sc + snn2);//пустая строка
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        sw.Write(snn1 + sr + sc);//пустая строка таблица справа  
                        sw.WriteLine(snn2);//пустая строка таблица справа  

                        sw.WriteLine(sm1 + sc + sm2);//  МашБум таблица справа  

                        sw.WriteLine(ser); //конец строки
                                           //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sw.WriteLine(s4); //конец таблицы
                        sw.WriteLine(s5); // конец таблицы
                        sw.WriteLine(s6); // пустая строка
                        i += 2;
                    }
                sw.Close();
                Process.Start("prices.html");
                
            }


            
        }
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
        private void PrintPr_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            LoadBase(dataGridView1);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                AddInBask formN = new AddInBask();
                formN.ShowDialog();
            }
            else
            {
                int tr = 0;
                int ind = dataGridView1.CurrentRow.Index; // индекс выделенной строки
                if (dataGridView2.Rows.Count == 0)
                    n = 0;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {

                        for (int i = 0; i < n; i++)
                        {
                        if (dataGridView1[1, ind].Value.ToString() == dataGridView2[1, i].Value.ToString())
                        {
                            goto qwer;
                            tr = 1;
                        }
                        }
                        if (tr==0)
                    {
                        dt1.ImportRow(((DataTable)dataGridView1.DataSource).Rows[row.Index]);
                        dataGridView2.DataSource = dt1;
                    }
                }
                n++;
                dt1.AcceptChanges();
                qwer:
                tr = 0;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            PrintPrices(dataGridView2.Rows.Count);


        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
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
    }
}
