using CarDealership.BLL;
using CarDealership.UI.Factories;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
	public class InventoryController : Controller
	{
		// GET: Vehicle
		public ActionResult New()
		{
			InventoryViewModel model = new InventoryViewModel();
			model.Populate();
			return View(model);
		}
    }
}