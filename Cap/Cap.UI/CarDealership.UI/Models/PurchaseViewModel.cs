using CarDealership.Models.Queries;
using CarDealership.UI.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
	public class PurchaseViewModel
	{
		public VehicleItem Vehicle { get; set; }
		public SaleInformationItem Sale { get; set; }
		public List<SelectListItem> States { get; set; }
		public List<SelectListItem> PurchaseType { get; set; }

		public PurchaseViewModel()
		{
			Vehicle = new VehicleItem();
			Sale = new SaleInformationItem();
			States = new List<SelectListItem>() { new SelectListItem { Text = "KY", Value = "KY" }, new SelectListItem { Text = "FL", Value = "FL" }, new SelectListItem { Text = "CA", Value = "CA" } };
			PurchaseType = new List<SelectListItem>() { new SelectListItem { Text = "Bank Finance", Value = "1" }, new SelectListItem { Text = "Cash", Value = "2" }, new SelectListItem { Text = "Dealer Finance", Value = "3" } };
		}

		public void Populate(int id)
		{
			Vehicle = VehicleRepositoryFactory.GetRepository().GetVehicleItemById(id);
		}
	}
}