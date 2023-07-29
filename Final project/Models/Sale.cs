using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class Sale : BasEntity
    {
        private static int counter = 0;

        public Sale(int amount,string saleitem,DateTime da)
        {
            Amount = amount;
            SaleItem = saleitem;
            date = date;
            counter++;

        }

        public int Amount { get; }
        public object date { get; }

        private string SaleItem;
    }
}
