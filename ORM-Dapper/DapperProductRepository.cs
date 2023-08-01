using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ORM_Dapper
{
	public class DapperProductRepository : IProductRepository
	{
		private readonly IDbConnection _conn;

		public DapperProductRepository(IDbConnection conn)
		{
			_conn = conn;
		}

		public IEnumerable<products> CreateProducts(string name, double price, int categoryId)
		{
			_conn.Open();

			var sql = "INSERT INTO Products (Name, Price, CategoryId) VALUES (@Name, @Price, @CategoryId)";
			var parameters = new { Name = name, Price = price, CategoryId = categoryId };

			_conn.Execute(sql, parameters);

			// Fetch the updated list of products
			var selectSql = "SELECT * FROM Products";
			var products = _conn.Query<products>(selectSql);

			_conn.Close();

			return products;
		}

		public IEnumerable<products> GetallProducts()
		{
			var Query = "SELECT * FROM PRODUCTS";
			return _conn.Query<products>(Query);
		}

		public bool UpdateProduct(int productId, string name, double price, int categoryId)
		{
			var query = "UPDATE Products SET Name = @Name, Price = @Price, CategoryId = @CategoryId WHERE ProductID = @ProductID;";
			var parameters = new { ProductID = productId, Name = name, Price = price, CategoryId = categoryId };

			var affectedRows = _conn.Execute(query, parameters);
			return affectedRows > 0;
		}

		public bool DeleteProduct(int productId)
		{
			var query = "DELETE FROM Products WHERE ProductID = @ProductID;";
			var parameters = new { ProductID = productId };

			var affectedRows = _conn.Execute(query, parameters);
			return affectedRows > 0;
		}


	}
}
