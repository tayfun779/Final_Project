using Final_project.Data.Models;
using Final_project.Services.Concrete;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Helpers
{
    public class SubMenu
    {
        public static void ProductSubMenu()
        {
            int option;

            do
            {

                Console.WriteLine("\n");
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Edit the product");
                Console.WriteLine("3. Remove product");
                Console.WriteLine("4. Show all products");
                Console.WriteLine("5. Show Products by Category");
                Console.WriteLine("6. Show Products by Price Range");
                Console.WriteLine("7. Search Products by Name");
                Console.WriteLine("0. Go Back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");


                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        MenuService.AddNewProduct();
                        break;
                    case 2:
                        MenuService.UpdateProduct();
                        break;
                    case 3:
                        MenuService.DeleteProduct();
                        break;
                    case 4:
                        MenuService.ShowAllProducts();
                        break;
                    case 5:
                        MenuService.ShowProductsByCategory();
                        break;
                    case 6:
                        MenuService.ShowProductsByPriceRange();
                        break;
                    case 7:
                        MenuService.SearchProductsByName();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
        public static void SaleSubMenu()
        {
            int option;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("1. Add New Sales");
                Console.WriteLine("2. Returning Any Product on Sale");
                Console.WriteLine("3. Remove Sales");
                Console.WriteLine("4. Show All Sales");
                Console.WriteLine("5. Show Sales (Date Range)");
                Console.WriteLine("6. Show Sales (Amount Range)");
                Console.WriteLine("7. Show Sales (Given Date)");
                Console.WriteLine("8. Show Information by Id, mainly the sales with that ID");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");


                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        MenuService.AddNewSales();
                        break;
                    case 2:
                        MenuService.ReturnSale();
                        break;
                    case 3:
                        MenuService.DeleteSales();
                        break;
                    case 4:
                        MenuService.DisplayOfAllSales();
                        break;
                    case 5:
                        MenuService.DisplayOfSalesAccordingGivenDateRange();
                        break;
                    case 6:
                        MenuService.DisplayOfSalesAccordingGivenAmountRange();
                        break;
                    case 7:
                        MenuService.ShowingSalesOnGivenDate();
                        break;
                    case 8:
                        MenuService.ShowingInformationGivenIDMainlySalesWithThatID();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
    }
}
