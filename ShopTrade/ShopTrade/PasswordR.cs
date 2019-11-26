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
    public partial class PasswordR : Form
    {
        string pas;
        public PasswordR()
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
                MainMenu form2 = new MainMenu();
                string d1 = null, d2 = null;
                string f1 = "\\Colors.db";
                string f3 = "\\pp.ppp";
                string f4 = "\\ShopTrade.db";
                string f51 = "\\x64\\";
                string f61 = "\\x86\\";
                string f5 = "\\SQLite.Interop.dll";
                string f6 = "\\SQLite.Interop.dll";
                d1 = Directory.GetCurrentDirectory();
                FolderBrowserDialog DirDialog = new FolderBrowserDialog();
                DirDialog.Description = "Выбор директории";
                DirDialog.SelectedPath = @"C:\";

                if (DirDialog.ShowDialog() == DialogResult.OK)
                {
                    d2 = DirDialog.SelectedPath + "\\Копия Баз";
                }
                DirectoryInfo dirInfo = new DirectoryInfo(d2);

                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo = new DirectoryInfo(d2 + f51);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo = new DirectoryInfo(d2 + f61);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }

                if (!System.IO.File.Exists(d2 + f1))
                {
                    System.IO.File.Delete(d2 + f1);
                    System.IO.File.Copy(d1 + f1, d2 + f1);
                }

                if (!System.IO.File.Exists(d2 + f3))
                {
                    System.IO.File.Delete(d2 + f3);
                    System.IO.File.Copy(d1 + f3, d2 + f3);
                }
                if (!System.IO.File.Exists(d2 + f4))
                {
                    System.IO.File.Delete(d2 + f4);
                    System.IO.File.Copy(d1 + f4, d2 + f4);
                }

                if (!System.IO.File.Exists(d2 + f51 + f5))
                {
                    System.IO.File.Delete(d2 + f51 + f5);
                    System.IO.File.Copy(d1 + f51 + f5, d2 + f51 + f5);
                }
                if (!System.IO.File.Exists(d2 + f61 + f6))
                {
                    System.IO.File.Delete(d2 + f61 + f6);
                    System.IO.File.Copy(d1 + f61 + f6, d2 + f61 + f6);
                }
                this.Close();
                
            }
        }
            
        
    }
}
