using Final_project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Final_project.Models
{

   public class Product : BaseEntity 
    {
        private int counter = 0;


        public Product(string name, double price,int count, Category category)
        {

            Name = name;
            Price = price;
            Count = count;
            Id = counter;
            count++;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int Count { get; set; }
        //public int Id { get; set; }
    }
}
