using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using System.Threading;
using System.Timers;
using System.Drawing.Design;
using System.Runtime;

namespace ShopTrade
{
    public partial class AddColor : Form
    {
        private readonly String dbFileName = "Colors.db";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        public AddColor()
        {
            InitializeComponent();
    }

        async void Button1_Click(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;

            string name = "0";
            double quan = 0;
            if ((textBox1.Text.Length >= 4) && (textBox2.Text.Length >= 1))
            {
                var originalColor = button1.BackColor;
                button1.BackColor = Color.Green;
                await Task.Delay(1000); // 5 секунд
                button1.BackColor = originalColor;

                name = textBox1.Text.ToString();
                quan = double.Parse(textBox2.Text);
                try
                {
                    m_sqlCmd.CommandText = "INSERT INTO Colors ('Name', 'Quantity') values ('" +
                        name + "' , '" +
                        quan + "')";

                    m_sqlCmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                var originalColor = button1.BackColor;
                button1.BackColor = Color.Red;
                await Task.Delay(2000); // 5 секунд
                button1.BackColor = originalColor;
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if ((num <= 47 || num >= 58) && num != 8 && num != 46) //цифры, клавиша BackSpace и точка ASCII
            {
                e.Handled = true;
            }
        }

        private void AddColor_Load(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
        }
    }
}
