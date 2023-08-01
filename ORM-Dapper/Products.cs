using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
	public class products
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public Double Price { get; set; }
		public int CategoryId { get; set; }
		public int DepartmentId { get; set; }
	}
}
