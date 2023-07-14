using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
	public class DapperDepartmentRepository : IDepartmentRepository
	{
		private readonly IDbConnection _conn;

		public DapperDepartmentRepository(IDbConnection conn)
		{
			_conn = conn;
		}

		public IEnumerable<Department> GetAllDepartments()
		{
			string query = "SELECT * FROM departments";
			return _conn.Query<Department>(query);
		}

		public void InsertDepartments(string name)
		{
			_conn.Execute("INSERT INTO Department (name) VALUES (@name)", new { name });
		}
	}
}
