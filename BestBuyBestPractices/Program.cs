using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace BestBuyBestPractices
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
            var departmentRepo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Type a new Department Name");

            var newDepartment = Console.ReadLine();

     
            var departments = departmentRepo.GetAllDepartments();
            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
            }

            var productRepo = new DapperProductRepository(conn);

            Console.WriteLine("Create a new product");
            var newProduct = Console.ReadLine();
            Console.WriteLine("What would you like to sell it for?");
            var newProductPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Select a CategoryID");
            var newProductCategory = int.Parse(Console.ReadLine());
            
            var products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} {product.Price} {product.CategoryID}");
            }
        }
    }
}
