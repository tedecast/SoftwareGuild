using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
	public class Vehicle
	{
		public int VehicleId { get; set; }
		public int MakeId { get; set; }
		public int ModelId { get; set; }
		public int InteriorId { get; set; }
		public int ColorId { get; set;}
		public int TypeId { get; set;}
		public int BodyId { get; set; }
		public int TransmissionId { get; set; }
		public int Year { get; set; }
		public string VIN { get; set; }
		public int Mileage { get; set;}
		public decimal MSRP { get; set; }
		public decimal SalePrice { get; set; }
		public string Description { get; set; }
		public string PhotoPath { get; set; }
		public bool IsSold { get; set; }
		public bool IsFeatured { get; set; }
	}
}
