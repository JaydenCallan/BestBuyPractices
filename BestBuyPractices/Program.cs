using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using BestBuyPractices;
using System.Net.WebSockets;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperProductRepository(conn);


            // USER INTERFACE
            while (true)
            {
                Console.WriteLine("To view all products, press 1\nTo add a new product, press 2\nTo delete a product, press 3\nTo rename a product, press 4");
                var input = Console.ReadLine();
                int id;

                switch (input)
                {
                    case "1": // Read

                        var products = repo.GetAllProducts();
                        foreach (var product in products)
                        {
                            Console.WriteLine($"[{product.ProductID}] {product.Name}");
                        }
                        break;


                    case "2": // Create

                        Console.Write("Product name: ");
                        var name = Console.ReadLine();

                        Console.Write("Product price: ");
                        var price = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Product category: ");
                        var cat = Convert.ToInt32(Console.ReadLine());

                        repo.CreateProduct(name, price, cat, 0, 0);
                        Console.WriteLine($"Created new product {name}");
                        break;


                    case "3": // Delete

                        Console.Write("Type the ID of the product to delete: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        repo.DeleteProduct(id);
                        Console.WriteLine($"Deleted product #{id}");
                        break;


                    case "4": // Update

                        Console.Write("Type the ID of the product to update: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("New product name: ");
                        var newName = Console.ReadLine();

                        repo.UpdateProduct(id, newName);
                        Console.WriteLine($"Product renamed to {newName}");
                        break;


                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

                Console.WriteLine("\n\n");
            }
        }
    }
}