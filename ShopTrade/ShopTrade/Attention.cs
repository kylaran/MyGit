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

namespace ShopTrade
{
    public partial class Attention : Form
    {
        public Attention()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string d1=null, d2=null;
            string f1 = "\\Colors.db";
            string f2 = "\\ff";
            string f3 = "\\pp.ppp";
            string f4 = "\\ShopTrade.db";
            string f51 = "\\x64";
            string f61 = "\\x86";
            string f5 = "\\SQLite.Interop.dll";
            string f6 = "\\SQLite.Interop.dll";
            d1 = Directory.GetCurrentDirectory();
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                d2 = DirDialog.SelectedPath;
            }
            if (System.IO.File.Exists(d1 + f1))
            {
                System.IO.File.Delete(d1 + f1);
                System.IO.File.Copy(d2 + f1, d1 + f1);
            }
            else System.IO.File.Copy(d2 + f1, d1 + f1);
            //  File.Copy(d2 + f2, d1 + f2);
            if (System.IO.File.Exists(d1 + f3))
            {
                System.IO.File.Delete(d1 + f3);
                System.IO.File.Copy(d2 + f3, d1 + f3);
            }
            else System.IO.File.Copy(d2 + f3, d1 + f3);
            if (System.IO.File.Exists(d1 + f4))
            {
                System.IO.File.Delete(d1 + f4);
                System.IO.File.Copy(d2 + f4, d1 + f4);
            }
            else System.IO.File.Copy(d2 + f4, d1 + f4);
            DirectoryInfo dirInfo = new DirectoryInfo(d1 + f51);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo = new DirectoryInfo(d1 + f61);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            if (System.IO.File.Exists(d1 + f51 + f5))
            {
                System.IO.File.Delete(d1 + f51 + f5);
                File.Copy(d2 + f51 + f5, d1 + f51 + f5);
            }
            else File.Copy(d2 + f51 + f5, d1 + f51 + f5);
           
            if (System.IO.File.Exists(d1 + f61 + f6))
            {
                System.IO.File.Delete(d1 + f61 + f6);
                File.Copy(d2 + f61 + f6, d1 + f61 + f6);
            }
            else File.Copy(d2 + f61 + f6, d1 + f61 + f6);

            this.Close();
        }

    }
}
