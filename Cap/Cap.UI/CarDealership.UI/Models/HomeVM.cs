using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.UI.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
	public class HomeVM
	{
		public List<Special> Specials { get; set; }
		public List<FeaturedVehicleItem> Featured { get; set; }

		public HomeVM()
		{
			Specials = new List<Special>();
			Featured = new List<FeaturedVehicleItem>();
		}

		public void Populate()
		{
			Specials = SpecialsRepositoryFactory.GetRepository().GetAllSpecials();
			Featured = VehicleRepositoryFactory.GetRepository().GetFeatured();
		}
	}
}