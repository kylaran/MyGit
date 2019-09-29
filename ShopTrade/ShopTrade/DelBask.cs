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
    public partial class DelBask : Form
    {
        public DelBask()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
