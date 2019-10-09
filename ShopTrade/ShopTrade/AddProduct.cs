using System;
using System.Windows.Forms;
using Microsoft.SqlServer;
using System.ComponentModel;
using System.Data.Entity;
using System.Threading;
using System.Timers;
using System.Drawing.Design;
using System.Runtime;
using System.Drawing;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;
namespace ShopTrade
{
    
    public partial class AddProduct : Form
    {
       // CurrentCulture = new System.Globalization.CultureInfo("en-US");
        private readonly String dbFileName = "ShopTrade.db";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        public AddProduct()
        {

            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        public class UserContext : DbContext
        {


            public UserContext()
                : base("DBConnection")
            { }

            public DbSet<Product> Products { get; set; }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            this.Close();
        }
     
       
        async void Button1_Click(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            string name= "0";
            string arti= "0";
            int quan = 0;
            string coun = "0";
            float pric = 0;
            if (textBox1.Text.Length >= 2)
            {
                label1.ForeColor = Color.Green; //name
                name = textBox1.Text.ToString();
                
            }
            else
            {
                label1.ForeColor = Color.Red; //name
            }
            if (textBox5.Text.Length >= 1)
            {
                label5.ForeColor = Color.Green; //name
                quan = int.Parse(textBox5.Text);
                
            }
            else
            {
                label5.ForeColor = Color.Red; // quan
            }
            if (textBox3.Text.Length >=1)
            {
                label3.ForeColor = Color.Green; //name
                pric =float.Parse(textBox3.Text);
                
            }
            else
            {

                label3.ForeColor = Color.Red; // Price
            }
            if (textBox4.Text.Length >= 1)
                arti = textBox4.Text.ToString();
            else arti = "0";
            if (textBox2.Text.Length >= 1)
                coun = textBox2.Text.ToString();
            else coun = "0";

            if ((textBox1.Text.Length >= 2) && (textBox3.Text.Length >= 1) & (textBox5.Text.Length >= 1))
            {
                var originalColor = button1.BackColor;
                button1.BackColor = Color.Green;
                await Task.Delay(1000); // 5 секунд
                button1.BackColor = originalColor;

               /* using (UserContext db = new UserContext())
                {

                    // создаем два объекта User
                    Product product1 = new Product { Name = name, Articule = arti, Quantity = quan, Country = coun, Price = pric };
                    // добавляем их в бд
                    db.Products.Add(product1);
                    db.SaveChanges();
                    // Делегат для типа Timer

                };*/
                try
                    {
                        m_sqlCmd.CommandText = "INSERT INTO Products ('Name', 'Articule', 'Quantity', 'Country', 'Price') values ('" +
                            name + "' , '" +
                            arti + "' , '" +
                            quan + "' , '" +
                            coun + "' , '" +
                            pric + "')";

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
            /*MainMenu form2 = new MainMenu();
            this.Hide();
            form2.ShowDialog();
            this.Close()f
            ;*/
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
        }
        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if ((num <= 96 || num >= 123) && (num <= 64 || num >= 91) && (num <= 47 || num >= 58) && num != 8) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if ((num <= 47 || num >= 58) && num != 8 && num != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }
        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if ((num <= 47 || num >= 58) && num != 8) //цифры, клавиша BackSpace ASCII
            {
                e.Handled = true;
            }
        }
    }
}
