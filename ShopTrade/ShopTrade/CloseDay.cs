using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.IO;
using System.Data.SQLite;
using System.Data.Entity;
namespace ShopTrade
{
    public partial class CloseDay : Form
    {
        public class OperDay
        {

            public int OperDayId { get; set; }
            public string NameTrade { get; set; }
            public DateTime OpenTime { get; set; }
            public DateTime CloseTime { get; set; }
            public float Money { get; set; }
            public float Pos { get; set; }

        }
        public class ODContext : DbContext
        {

            public ODContext()
                : base("DBConnection")
            { }

            public DbSet<OperDay> OperDays { get; set; }
        }
        public CloseDay()
        {

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            StreamReader sr = new StreamReader(@"dd.ddd");
            DateTime OpenD = DateTime.Parse(sr.ReadToEnd());
            sr.Close();
            label2.Text = OpenD.ToString();
           
        }
       /* class UserContext : DbContext
        {
           public UserContext()
                : base("DbConnection")
            { }

            public DbSet<OperDay> OperDays { get; set; }
        }*/
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {
                if (number == 44)
                {
                    number = ',';
                }
                e.Handled = true;
            }
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {if (number == 44)
                {
                    number = ',';
                }
                e.Handled = true;
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            ///////////////////////////////
            //Проверка на закрытие смены
            ///////////////////////////////
            /*if (!File.Exists("od.ooo"))
            {
                var myFile = File.Create("od.ooo");
                myFile.Close();
                File.Create("od.ooo");
                File.Create("od.ooo").Close;
            }
            ///////////////////////////////
            //Присваивание значения номера строки
            ///////////////////////////////
            int count = File.ReadAllLines("od.ooo").Length + 1;
            ///////////////////////////////
            //если больше 30 строк, создание копии, сохранение, и очистка основного файла
            ///////////////////////////////
            if (count>30)

            {
                count = 1;
                string path = @"c:\TEMP";
                string subpath = @"WORKSHOP";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo.CreateSubdirectory(subpath);
               path = @"c:\TEMP\WORKSHOP\";

               string path2 =DateTime.Now.DayOfYear.ToString();
                File.Copy(@"od.ooo", path+path2);
                File.Delete(@"od.ooo");
                var myFile = File.Create("od.ooo");
                myFile.Close();
            }
            ///////////////////////////////
            //Проверка на закрытие смены
            ///////////////////////////////
            StreamWriter sw = new StreamWriter(@"od.ooo", true, System.Text.Encoding.Default);
                var fileInfo = new FileInfo(@"dd.ddd");
                DateTime mod = fileInfo.LastAccessTime;
                string OpenDa = mod.ToString();                     //время открытия дня
                string CloseDa = DateTime.Now.ToString();           //время закрытия дня
                string TraderName = comboBox1.Text.ToString();
                string AmountNal = textBox1.Text.ToString();
                string AmountBez = textBox2.Text.ToString();
                
                sw.WriteLine($"{count.ToString()}  {OpenDa}   {CloseDa}  {TraderName}  {AmountNal}  {AmountBez}");            
                sw.Close();
             File.SetLastAccessTime(@"dd.ddd", new DateTime(1995, 10, 16));
            ///////////////////////////////
            //Проверка на закрытие смены
            ///////////////////////////////
            MainMenu form2 = new MainMenu();
                this.Hide();
                form2.ShowDialog();
                this.Close();*/

            DateTime CloseD= new DateTime();
            DateTime OpenD = new DateTime();

            StreamReader sr = new StreamReader(@"dd.ddd");
            OpenD = DateTime.Parse(sr.ReadToEnd());
            sr.Close();

            //DateTime OpenD = (from m in db.OperDays select m.OpenTime).ToList().Last(); //Последняя строка базы
            CloseD = DateTime.Now; //Закрыта смена

            if (OpenD.Date == CloseD.Date)
            {
                using (ODContext db = new ODContext())
                {
                    float AmountNal;
                    float AmountBez;
                    string TraderName;

                    TraderName = comboBox1.Text.ToString();
                    if (textBox1.Text.Contains("."))
                    {
                        textBox1.Text = textBox1.Text.Replace(".", ",");

                    }
                    if (textBox1.Text == "")
                    { AmountNal = 0; }
                    else
                    { AmountNal = float.Parse(textBox1.Text); }
                    if (textBox2.Text == "")
                    { AmountBez = 0; }
                    else { AmountBez = float.Parse(textBox2.Text); }
                    // создаем объект
                    OperDay OperDay1 = new OperDay { OpenTime = OpenD, CloseTime = CloseD, NameTrade = TraderName, Money = AmountNal, Pos = AmountBez };
                    // добавляем их в бд
                    db.OperDays.Add(OperDay1);
                    db.SaveChanges();

                };
                OpenD = new DateTime(1995, 10, 16);
                StreamWriter sw = new StreamWriter(@"dd.ddd", false, System.Text.Encoding.Default);
                sw.Write(OpenD.ToString());
                sw.Close();

                MainMenu form2 = new MainMenu();
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
            else {
                
                AttCloseDay form3 = new AttCloseDay();
                this.Hide();
                form3.ShowDialog();
                this.Close();
            }

        }

        private void CloseDay_Load(object sender, EventArgs e)//Случайность
        {

        }

        private void Button1_Click(object sender, EventArgs e)//Кнопка отмены
        {
            MainMenu form2 = new MainMenu();
            this.Hide();
            form2.ShowDialog();
            this.Close();
        }
    }
}
