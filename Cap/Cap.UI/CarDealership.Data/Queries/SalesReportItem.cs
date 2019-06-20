using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
	public class SalesReportItem
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public Decimal TotalSales { get; set; }
		public int TotalVehicles { get; set; }
	}
}
