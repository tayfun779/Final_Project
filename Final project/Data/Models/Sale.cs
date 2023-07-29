using Final_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class Sale : BaseEntity
    {
        //private static int counter = 0;

        //public Sale(int amount,string saleitem,DateTime da)
        //{
        //    Amount = amount;
        //    SaleItem = saleitem;
        //    date = date;
        //    counter++;

        //}

        public double Price { get; set; }
        public SalesItem SalesItem { get; set; }

        //private string SaleItem;
    }
}