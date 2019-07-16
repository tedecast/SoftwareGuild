using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.UI.Factories;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
		[Authorize(Roles ="Sales, Admin")]
        public ActionResult Index()
        {
			InventoryViewModel model = new InventoryViewModel();
			model.Populate(false, true, true);
			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Sales, Admin")]
		public ActionResult Purchase(PurchaseModel model)
		{
			Sale sale = new Sale()
			{
				UserId = model.UserId,
				PurchaseTypeId = model.PurchaseTypeId,
				VehicleId = model.VehicleId,
				PurchasePrice = model.PurchasePrice,
				Name = model.Name,
				Phone = model.Phone,
				Email = model.Email,
				Street1 = model.Street1,
				Street2 = model.Street2,
				City = model.City,
				State = model.State,
				Zipcode = model.Zipcode,
				DateSold = model.DateSold
			};
			if (ModelState.IsValid)
			{
				SalesRepositoryFactory.GetRepository().AddSale(sale);
				return RedirectToAction("Index", "Sales");
			}

			PurchaseViewModel viewModel = new PurchaseViewModel();
			viewModel.Populate(model.VehicleId);

			SaleInformationItem saleInfo = new SaleInformationItem()
			{
				UserId = model.UserId,
				PurchaseTypeId = model.PurchaseTypeId,
				VehicleId = model.VehicleId,
				PurchasePrice = model.PurchasePrice,
				Name = model.Name,
				Phone = model.Phone,
				Email = model.Email,
				Street1 = model.Street1,
				Street2 = model.Street2,
				City = model.City,
				Zipcode = model.Zipcode,
				DateSold = model.DateSold
			};


			viewModel.Sale = saleInfo;

			return View(viewModel);
		}

		// GET: Sales
		[Authorize(Roles = "Sales, Admin")]
		public ActionResult Purchase(int id)
		{
			PurchaseViewModel viewModel = new PurchaseViewModel();
			viewModel.Populate(id);
			viewModel.Sale.UserId = User.Identity.GetUserId();
			viewModel.Sale.DateSold = DateTime.Now;
			viewModel.Sale.VehicleId = id;

			return View(viewModel);
		}
	}
}