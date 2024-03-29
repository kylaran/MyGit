﻿using System;
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

namespace ShopTrade
{
    public partial class Password : Form
    {
        string pas;
        private readonly String dbFileName = "ShopTrade.db";
        readonly int data;
        public Password(int data)
        {
            MainMenu form2 = this.Owner as MainMenu;
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.data = data;
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
            MainMenu form2 = new MainMenu();
            if (textBox1.Text.ToString() == pas)
            {
                    EditProduct formE = new EditProduct(data);
                    formE.ShowDialog();
                    this.Close();
            }
        }


    }
}
