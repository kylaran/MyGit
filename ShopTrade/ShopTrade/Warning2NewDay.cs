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
    public partial class Warning2NewDay : Form
    {
        public Warning2NewDay()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            this.Close();
        }
    }
}
