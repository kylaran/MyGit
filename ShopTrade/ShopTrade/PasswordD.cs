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
using System.Data.Sql;
using System.Data.SQLite;
using System.Data.Entity;

namespace ShopTrade
{
    public partial class PasswordD : Form
    {
        string pas;
        private readonly String dbFileName = "ShopTrade.db";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        readonly int data;
        public PasswordD(int data)
        {
            MainMenu form2 = this.Owner as MainMenu;
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.data = data;
            this.KeyPreview = true;
        }

        private void Password_Load(object sender, EventArgs e)
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
            textBox1.MaxLength = 8;
            // Assign the asterisk to be the password character.
            textBox1.PasswordChar = '*';
            StreamReader sr = new StreamReader(@"pp.ppp");
            sr.BaseStream.Position = 0;
            pas = sr.ReadToEnd();
            sr.Close();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            MainMenu form2 = new MainMenu();
            if (textBox1.Text.ToString() == pas)
                {
                    DataTable dTable = new DataTable();
                    String sqlQuery = "DELETE FROM Products " +
                        "WHERE productId = " + data + ";";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                    adapter.Fill(dTable);
                this.Close();

                /* EditProduct formE = new EditProduct(data);
                    formE.ShowDialog();
                    this.Close();*/
            }
        }
            
        
    }
}
