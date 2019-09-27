using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Sql;
using System.IO;

namespace ShopTrade
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          
            string path = @"dd.ddd";
            if (!File.Exists(path))
            {
                File.Create("dd.ddd");
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
        
      
    }
    public class Basket
    {

        public int ListId { get; set; }
        public int BuyersID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime DateTrade { get; set; }
        public string Country { get; set; }
        public float Price { get; set; }

    }
    public class Product
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Articule { get; set; }
        public int Quantity { get; set; }
        public string Country { get; set; }
        public float Price { get; set; }

    }
}
