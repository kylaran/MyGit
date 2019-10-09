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
    public partial class Password : Form
    {
        readonly int data;
        public Password(int data)
        {
            MainMenu form2 = this.Owner as MainMenu;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            this.data = data;
            this.KeyPreview = true;
        }

        private void Password_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 8;
            // Assign the asterisk to be the password character.
            textBox1.PasswordChar = '*';
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
                if (textBox1.Text.ToString() == "11111")
                {
                    EditProduct formE = new EditProduct(data);
                    formE.ShowDialog();
                    this.Close();
                }
            
        }
    }
}
