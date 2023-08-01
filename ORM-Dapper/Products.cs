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
		public int Price { get; set; }
		public int CategoreyId { get; set; }
		public int OnSale { get; set; }
		public int StockLevel { get; set; }
		public int DepartmentId { get; set; }
	}
}
