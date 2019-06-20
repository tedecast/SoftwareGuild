using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
	public class FeaturedVehicleItem
	{
		public int VehicleId { get; set; }
		public string PhotoPath { get; set; }
		public int Year { get; set; }
		public string MakeName { get; set; }
		public string ModelName { get; set; }
		public decimal SalePrice { get; set; }

	}
}
