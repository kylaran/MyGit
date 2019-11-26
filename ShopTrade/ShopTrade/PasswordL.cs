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
    public partial class PasswordL : Form
    {
        string pas;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        public PasswordL()
        {
            MainMenu form2 = this.Owner as MainMenu;
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
        }

        private void Password_Load(object sender, EventArgs e)
        {
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
            if (textBox1.Text.ToString() == pas)
                {
                MainMenu form2 = this.Owner as MainMenu;
                m_dbConn = new SQLiteConnection();
                m_sqlCmd = new SQLiteCommand();

                string d1 = null, d2 = null;
                string f1 = "\\Colors.db";
                string f4 = "\\ShopTrade.db";
                d1 = Directory.GetCurrentDirectory();
                FolderBrowserDialog DirDialog = new FolderBrowserDialog();
                DirDialog.Description = "Выбор директории";
                DirDialog.SelectedPath = @"D:\";


                if (DirDialog.ShowDialog() == DialogResult.OK)
                {
                    d2 = DirDialog.SelectedPath;
                }

                if (System.IO.File.Exists(d1 + f1))
                {
                    m_dbConn = new SQLiteConnection("Data Source=" + "ShopTrade.db" + ";Version=3;");
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                    m_dbConn.Dispose();
                    GC.Collect();
                    System.IO.File.Delete(d1 + f1);
                    System.IO.File.Copy(d2 + f1, d1 + f1);
                }
                else System.IO.File.Copy(d2 + f1, d1 + f1);

                if (System.IO.File.Exists(d1 + f4))
                {
                    m_dbConn = new SQLiteConnection("Data Source=" + "Colors.db" + ";Version=3;");
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                    m_dbConn.Dispose();
                    GC.Collect();
                    System.IO.File.Delete(d1 + f4);
                    System.IO.File.Copy(d2 + f4, d1 + f4);
                }
                else System.IO.File.Copy(d2 + f4, d1 + f4);
                
                this.Close();
            }
        }
            
        
    }
}
