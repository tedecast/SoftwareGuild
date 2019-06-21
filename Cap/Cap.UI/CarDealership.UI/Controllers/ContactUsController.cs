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
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(ContactUsModel model)
		{
			if (ModelState.IsValid)
			{
				ContactUs contact = new ContactUs()
				{
					Name = model.Name,
					Phone = model.Phone,
					Email = model.Email,
					Message = model.Message
				};

				ContactUsRepositoryFactory.GetRepository().AddContactUs(contact);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return View(model);
			}
		}

		[HttpGet]
		public ActionResult VIN(string VIN)
		{
			ContactUsModel model = new ContactUsModel();
			ViewBag.VIN = VIN;

			return View("Index", model);
		}
    }
}