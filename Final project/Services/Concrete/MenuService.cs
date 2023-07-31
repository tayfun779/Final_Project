﻿using Final_project.Data.Enums;
using Final_project.Data.Models;
using Final_project.Models;
using Final_project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Services.Concrete
{
    public class MenuService
    {
        private static MarketableService marketservices = new MarketableService();

        public static void AddNewProduct()
        {
            try
            {
                bool choose = true;

                while (choose)
                {
                    Console.WriteLine("Please enter name of product:");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Please enter price of product: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please enter count of product:");
                    int count = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please choose and enter one category in list:");
                    foreach (var item in Enum.GetNames(typeof(Category)))
                    {
                        Console.WriteLine($"{item}");
                    }
                    Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);

                    Console.WriteLine("Will there be more product? Enter Y or N");
                    string answer = Console.ReadLine();
                    switch (answer.ToUpper())
                    {
                        case "Y":
                            choose = true;
                            break;
                        case "N":
                            choose = false;
                            break;
                        default:
                            Console.WriteLine("Enter correctly!");
                            Console.WriteLine("Will there be a harvest? Y or N");
                            answer = Console.ReadLine();
                            break;
                    }
                    marketservices.AddProduct(productName, price, category, count);
                    Console.WriteLine("Added new product succesfuly:)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ooops,eror. {ex.Message}");
            }
        }
        public static void AddNewSales()
        {
            try
            {
                int productId;
                int prodCount;
                bool choose = true;
                List<ProductDto> products = new List<ProductDto>();

                while (choose)
                {
                    foreach (Product item in marketservices.ShowAllProducts())
                    {
                        if (products != null && products.FirstOrDefault(p => p.Id == item.Id) != null)
                        {
                            Console.WriteLine($"{item.Id} - {item.ProductName} : quantity {item.ProductCount - products.FirstOrDefault(p => p.Id == item.Id).Count}");
                        }
                        else
                        {
                            Console.WriteLine($"{item.Id} - {item.ProductName} : quantity {item.ProductCount}");
                        }
                    }
                    Console.WriteLine("Enter the Id of the product for sale");
                    productId = Convert.ToInt32(Console.ReadLine());
                    while (marketservices.ShowAllProducts().FirstOrDefault(p => p.Id == productId) == null)
                    {
                        Console.WriteLine("The Id you entered was wrong!");
                        productId = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Enter the number of the product");
                    prodCount = Convert.ToInt32(Console.ReadLine());
                    if (products.FirstOrDefault(p => p.Id == productId) != null)
                    {
                        products.FirstOrDefault(p => p.Id == productId).Count = products.FirstOrDefault(p => p.Id == productId).Count + prodCount;
                    }
                    else
                    {
                        ProductDto productDto = new()
                        {
                            Id = productId,
                            Count = prodCount,
                        };
                        products.Add(productDto);
                    }

                    Console.WriteLine("Will there be more fruit? Enter Y or N");
                    string answer = Console.ReadLine();
                    switch (answer.ToUpper())
                    {
                        case "Y":
                            choose = true;
                            break;
                        case "N":
                            choose = false;
                            break;
                        default:
                            Console.WriteLine("Enter correctly!");
                            Console.WriteLine("Will there be a harvest? Y or N");
                            answer = Console.ReadLine();
                            break;
                    }
                }
                marketservices.AddSale(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ooops,eror. {ex.Message}");
            }
        }
        public static void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Please enter Product Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                marketservices.DeleteProduct(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }
        public static void DeleteSales()
        {
            try
            {
                Console.WriteLine("Please enter Sale Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                marketservices.DeleteSale(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void DisplayOfAllSales()
        {
            try
            {
                foreach (Sale item in marketservices.DisplayOfAllSales())
                {
                    Console.WriteLine($"ID - {item.Id} , Date : {item.Date} , Sales Amount : {item.SalesAmount}");
                    foreach (SalesItem salesItem in item.SalesItems)
                    {
                        Console.WriteLine($"Product : {salesItem.Product.ProductName}, Product Count : {salesItem.Count}, Product Price : {salesItem.Product.Price}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }
        public static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Please enter name of product");
                string productName = Console.ReadLine();
                Console.WriteLine("Please enter ID:");
                int productId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter count:");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter price:");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter category:");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);
                marketservices.UpdateProduct(productId, productName, count, price, category);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }
        public static void SearchProductsByName()
        {
            try
            {
                Console.WriteLine("Please enter name of product for search:");
                string name = Console.ReadLine();
                var foundproducts = marketservices.FindProductsByName(name);

                if (foundproducts.Count == 0)
                {
                    Console.WriteLine("No products found");
                }
                foreach (var product in foundproducts)
                {
                    Console.WriteLine($"Name:{product.ProductName}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops,error.{ex.Message}");
            }
        }
        public static void ShowAllProducts()
        {
            var products = marketservices.ShowAllProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("No products yet!");
                return;
            }
            foreach (var product in products)
            {
                Console.WriteLine($"ID:{product.Id},Name:{product.ProductName}, Count:{product.ProductCount}, Price:{product.Price}, Category:{product.Category}");
            }
        }
        public static void ShowProductsByCategory()
        {
            try
            {
                List<Category> categories = new List<Category>();
                Category category = Category.iPhone;
                Console.WriteLine(category);
                Category category1 = Category.Samsung;
                Console.WriteLine(category1);
                Category category2 = Category.Xiaomi;
                Console.WriteLine(category2);
                Console.WriteLine("Please enter category name:");
                Category cateName = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);

                var foundproducts = marketservices.ShowProductsByCategory(cateName);
                if (foundproducts.Count == 0)
                {
                    Console.WriteLine("Not found");
                    return;
                }
                foreach (var product in foundproducts)
                {
                    Console.WriteLine($"ID:{product.Id},Name:{product.ProductName}, Count:{product.ProductCount}, Price:{product.Price}, Category:{product.Category}");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }
        public static void ShowProductsByPriceRange()
        {
            try
            {
                Console.WriteLine("Please enter minimum amount:");
                double minPrice = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter maximum amount:");
                double maxPrice = Convert.ToDouble(Console.ReadLine());
                var foundproduct = marketservices.ViewProductsByPrice(minPrice, maxPrice);
                if (foundproduct.Count == 0)
                {
                    Console.WriteLine("No products found!");
                }
                foreach (var product in foundproduct)
                {
                    Console.WriteLine($"ID:{product.Id},Name:{product.ProductName}, Count:{product.ProductCount}, Price:{product.Price}, Category:{product.Category}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
        }
    }
}
