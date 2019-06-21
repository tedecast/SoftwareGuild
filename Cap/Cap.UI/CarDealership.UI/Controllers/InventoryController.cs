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
		// GET: New Vehicle Inventory
		public ActionResult New()
		{
			InventoryViewModel model = new InventoryViewModel();
			model.Populate(true);
			return View(model);
		}

		// GET: Used Vehicle Inventory
		public ActionResult Used()
		{
			InventoryViewModel model = new InventoryViewModel();
			model.Populate(false);
			return View(model);
		}

		public ActionResult Details(int id)
		{
			var model = VehicleRepositoryFactory.GetRepository().GetVehicleItemById(id);
			return View(model);
		}
	}
}