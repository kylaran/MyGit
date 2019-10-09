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
    public partial class Settings : Form
    { string pas;
        int t;
        public Settings()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (textBox1.Text.ToString() == pas)
            {
                label4.Text = "Пароль введён верно!";
                t = 1;
                textBox2.Visible = true;
                textBox1.Visible = false;
            }
            else t = 0;
        }

        private void TextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.TextLength >= 5)
            {
                t = 2;
                if (t == 2)
                {
                    label4.Text = "Новый пароль введён верно!";
                    pas = textBox2.Text.ToString();
                }
                else label4.Text = "Слишком короткий пароль!";
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            t = 0;
            label4.Text = "Неверно введён старый пароль!";
            textBox1.MaxLength = 8;
            textBox1.PasswordChar = '*';
            textBox2.MaxLength = 8;
            textBox2.PasswordChar = '*';
            textBox2.Visible = false;
            StreamReader sr = new StreamReader(@"pp.ppp");
            sr.BaseStream.Position = 0;
            pas = sr.ReadToEnd();
            sr.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (t == 2)
            {
                StreamWriter sw = new StreamWriter(@"pp.ppp");
               // sw.Write(pas);
                sw.Write(pas);
                sw.Close();
                ChPas C = new ChPas();
                C.ShowDialog();
                this.Close();
            }
        }
    }
}
