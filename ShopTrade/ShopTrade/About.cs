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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void About_Resize(object sender, EventArgs e)
        {
            int fw = this.Width;
            groupBox1.Top = 10;             // выбор из списка
            groupBox1.Left = 20;            // -//-
            groupBox1.Width = fw - 55;      // -//-
            int h = groupBox1.Height-30;
            groupBox2.Top = 40 +h;          // Оплата
            groupBox2.Left = 20;            // -//-
            groupBox2.Width = fw - 55;      // -//-
            h = h + groupBox2.Height;
            groupBox3.Top = 40 + h;         // Итоги
            groupBox3.Left = 20;            // -//-
            groupBox3.Width = fw - 55;      // -//-
            h = h + groupBox3.Height;
            groupBox4.Top = 40 + h;         // Ввод товара
            groupBox4.Left = 20;            // -//-
            groupBox4.Width = fw - 55;      // -//-
            h = h + groupBox4.Height;
            groupBox5.Top = 40 + h;         // Ввод краски
            groupBox5.Left = 20;            // -//-
            groupBox5.Width = fw - 55;      // -//-
            h = h + groupBox5.Height;
            groupBox6.Top = 40 + h;         // Удаление
            groupBox6.Left = 20;            // -//-
            groupBox6.Width = fw - 55;      // -//-
            h = h + groupBox6.Height;
            groupBox7.Top = 40 + h;         // Редактирование
            groupBox7.Left = 20;            // -//-
            groupBox7.Width = fw - 55;      // -//-
        }
    }
}
