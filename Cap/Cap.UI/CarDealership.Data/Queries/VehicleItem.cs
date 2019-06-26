using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
	public class VehicleItem
	{
		public int VehicleId { get; set; }
		public string MakeName { get; set; }
		public string ModelName { get; set; }
		public int Year { get; set; }
		public string VIN { get; set; }
		public decimal MSRP { get; set; }
		public string BodyType { get; set; }
		public string TypeName { get; set; }
		public string TransmissionType { get; set; }
		public string ColorName { get; set; }
		public string InteriorColor { get; set; }
		public int Mileage { get; set; }
		public string Description { get; set; }
		public decimal SalePrice { get; set; }
		public string PhotoPath { get; set; }
		public bool IsFeatured { get; set; }
		public bool IsSold { get; set; }
		public bool IsDeleted { get; set; }
	}
}
