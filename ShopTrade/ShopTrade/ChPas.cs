using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Drawing.Design;
using System.Runtime;
using System.Data.SQLite;
using System.Globalization;

namespace ShopTrade
{
    public partial class ChPas : Form
    {
        public ChPas()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        async void ChPas_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000); // 5 секунд
            this.Close();
        }
    }
}
