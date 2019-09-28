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
    public partial class Payment : Form
    {
        public bool ff = false;
        DataTable dTable = new DataTable();
        String sqlQuery;

        public Payment()
        {
            MainMenu form2 = new MainMenu();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            if (form2.label3.Text != null)
                label1.Text = "К ОПЛАТЕ: "+(form2.tv).ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MainMenu form2 = new MainMenu();
            this.Hide();
            //form2.Show();
            this.Close();
            ff = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            MainMenu form2 = new MainMenu();
            form2.label3.Text = "К ОПЛАТЕ: 0";
            while (form2.dataGridView2.Rows.Count != 0)
            {
                form2.dataGridView2.Rows.Remove(form2.dataGridView2.CurrentRow);
            }
            ff = false;
        }

        private void Payment_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MainMenu form2 = new MainMenu();
            form2.label3.Text = "К ОПЛАТЕ: 0";
            while (form2.dataGridView2.Rows.Count != 0)
            {
                form2.dataGridView2.Rows.Remove(form2.dataGridView2.CurrentRow);
            }
            ff = false;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            MainMenu form2 = this.Owner as MainMenu;
         /*   if (form2.label3.Text != null)
                label1.Text = "К ОПЛАТЕ: " + (form2.tv).ToString();*/

        }
    }
}
