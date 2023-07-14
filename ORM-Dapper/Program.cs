using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Http.Headers;

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
		}
    }
}
