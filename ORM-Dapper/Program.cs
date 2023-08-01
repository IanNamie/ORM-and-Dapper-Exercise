using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Http.Headers;
using System;
using System.Data;
using System.IO;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			string connString = config.GetConnectionString("DefaultConnection");

			IDbConnection conn = new MySqlConnection(connString);


			var DepartmentRepo = new DapperDepartmentRepository(conn);
			var Departments = DepartmentRepo.GetAllDepartments();

			foreach (var department in Departments) 
			{
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
            }

			var productRepo = new DapperProductRepository(conn);

			// Call CreateProducts method
			var products = productRepo.CreateProducts("Product Name", 10.99, 1);
			Console.WriteLine($"New Product ID: {products}");

			// Call GetAllProducts method
			var allProducts = productRepo.GetallProducts();
			foreach (var product in allProducts)
			{
				Console.WriteLine($"Name: {product.Name}");
				Console.WriteLine($"ProductID: {product.ProductId}");
				Console.WriteLine($"CategoryID: {product.CategoryId}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine();
				Console.WriteLine();
			}
			// Call UpdateProducts method
			var productIdToUpdate = 948; // Replace with the actual ID of the product you want to update
			var isUpdated = productRepo.UpdateProduct(productIdToUpdate, "Ian's updated product", 15.99, 10);
			Console.WriteLine($"Product update status: {isUpdated}");

			//call DeleteProducts
			var deleteProduct = 950;
			var isDeleted = productRepo.DeleteProduct(deleteProduct);
			Console.WriteLine($"Product delete Status: {isDeleted}");

		}
    }
}
