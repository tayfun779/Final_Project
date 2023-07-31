using Final_project.Common;
using Final_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Data.Models
{
    public class SalesItem : BaseEntity
    {
        private static int count = 0;
        public SalesItem(Product product, int count)
        {
            Product = product;
            Count = count;
            Id = count;
            count++;
        }

        public Product Product { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
        public double TotalPrice()
        {
            return Product.Price * Count;
        }
    }
}
