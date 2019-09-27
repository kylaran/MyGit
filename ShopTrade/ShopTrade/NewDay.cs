using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopTrade
{
    public partial class NewDay : Form
    {
        public NewDay()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainMenu form2 = new MainMenu();
            this.Hide();
            form2.ShowDialog();
            this.Close();
        }
    }
}
