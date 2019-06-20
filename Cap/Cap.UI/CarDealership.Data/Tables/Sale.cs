using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
	public class Sale
	{
		public int SaleId { get; set; }
		public string Id { get; set; }
		public int PurchaseTypeId { get; set; }
		public int VehicleId {get;set;}
		public decimal PurchasePrice { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zipcode { get; set; }
		public DateTime DateSold { get; set; }
	}
}
