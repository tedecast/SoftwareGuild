using CarDealership.UI.Factories;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
		[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

		[Authorize(Roles = "Admin")]
		public ActionResult Sales()
		{
			ReportViewModel viewModel = new ReportViewModel();
			viewModel.Populate();
	
			return View(viewModel);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public ActionResult Sales(ReportViewModel viewModel)
		{

			return View();
		}

		[Authorize(Roles = "Admin")]
		public ActionResult Inventory()
		{
			InventoryReportViewModel model = new InventoryReportViewModel();
			model.New = VehicleRepositoryFactory.GetRepository().InventoryReport().Where(x => x.TypeName == "New").ToList();
			model.Used = VehicleRepositoryFactory.GetRepository().InventoryReport().Where(x => x.TypeName == "Used").ToList();
			return View(model);
		}
	}
}