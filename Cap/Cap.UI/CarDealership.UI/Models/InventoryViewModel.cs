using CarDealership.BLL;
using CarDealership.Models.Queries;
using CarDealership.UI.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
	public class InventoryViewModel
	{
		public List<VehicleItem> Vehicles { get; set; }
		public List<SelectListItem> Year { get; set; }
		public List<SelectListItem> Price { get; set; }

		public InventoryViewModel()
		{
			Vehicles = new List<VehicleItem>();
			Year = new List<SelectListItem>();
			Price = new List<SelectListItem>();
		}

		public void Populate()
		{
			var repo = VehicleRepositoryFactory.GetRepository();
			Vehicles = FilterInventory.NewInventory(repo);
			for (int i = 2000; i <= DateTime.Now.Year; i++)
			{
				var year = new SelectListItem { Value = i.ToString(), Text = i.ToString() };
				Year.Add(year);
			}
			for (int i = 5000; i <= 50000; i += 5000)
			{
				var price = new SelectListItem { Value = i.ToString(), Text = i.ToString("C0") };
				Price.Add(price);
			}
		}
	}
}
