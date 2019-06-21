using CarDealership.Models.Tables;
using CarDealership.UI.Factories;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			HomeVM viewModel = new HomeVM();
			viewModel.Populate();

			return View(viewModel);
		}

		public ActionResult Specials()
		{
			var model = SpecialsRepositoryFactory.GetRepository().GetAllSpecials();
			return View(model);
		}

		public ActionResult ContactUs()
		{
			ContactUs model = new ContactUs();

			if (ModelState.IsValid)
			{
				return View(model);
			}

			return View(model);
		}

	}
}