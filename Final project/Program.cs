using System;
using System.Linq;
namespace Final_project
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;


            do
            {
                Console.WriteLine("1.To carry out operations on products");
                Console.WriteLine("2. To carry out operations on sales");
                Console.WriteLine("0 Exit from system");


                Console.WriteLine("____________");
                Console.WriteLine("Please enter an options");
                Console.WriteLine("____________");

                while (int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option!");
                    Console.WriteLine("Enter an option please!");
                    Console.WriteLine("____________");
                }
                 
               

                switch (option)
                {
                    case 1:
                        SubMenu.ProductSubMenu();
                }
            } while (option!=0);
        }
    }
}
