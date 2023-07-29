using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Final_project.Models
{

   public class Product : BasEntity 
    {
        private int counter = 0;


        public Product(string name, double price,int count, Category category)
        {

            Name = name;
            Price = price;
            Count = count;
            ID = counter;
            count++;
        }

        public string Name { get; }
        public double Price { get; }
        public int Count { get; }
        public int ID { get; }
    }
}
