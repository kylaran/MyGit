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
    public partial class AttCloseDay : Form
    {
        public AttCloseDay()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CloseDay      form2 =  new CloseDay();
            this.Hide();
            form2.ShowDialog();
            this.Close();
        }
    }
}
