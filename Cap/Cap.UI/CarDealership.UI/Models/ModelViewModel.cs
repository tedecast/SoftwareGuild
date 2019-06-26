using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
	public class ModelViewModel
	{
		public ModelItem VehicleModel { get; set; }
		public IEnumerable<SelectListItem> Makes { get; set; }
	}
}