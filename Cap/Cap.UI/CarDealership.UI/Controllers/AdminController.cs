using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.UI.Factories;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
	public class AdminController : Controller
	{
		// GET: Admin
		public ActionResult Index()
		{
			InventoryViewModel model = new InventoryViewModel();
			model.Populate(false, true, false);
			return View(model);
		}

		// GET: Sales
		[Authorize]
		public ActionResult AddVehicle()
		{
			AdminViewModelAdd viewModel = new AdminViewModelAdd();
			viewModel.Populate();

			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		public ActionResult AddVehicle(AdminViewModelAdd model)
		{
			if (ModelState.IsValid)
			{
				var repo = VehicleRepositoryFactory.GetRepository();
				try
				{
					repo.AddVehicle(model.Vehicle);

					if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
					{
						var savepath = Server.MapPath("~/Images/");

						int vehicleId = model.Vehicle.VehicleId;
						string strVehicleId = "inventory-" + vehicleId.ToString();
						string extension = Path.GetExtension(model.ImageUpload.FileName);


						var filePath = Path.Combine(savepath, strVehicleId + extension);

						model.ImageUpload.SaveAs(filePath);

						model.Vehicle.PhotoPath = Path.GetFileName(filePath);
					}

					repo.EditVehicle(model.Vehicle);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				return RedirectToAction("editVehicle", "admin", new { id = model.Vehicle.VehicleId });
			}

			AdminViewModelAdd adminView = new AdminViewModelAdd();
			adminView.Populate();
			adminView.Vehicle = model.Vehicle;
			return View(adminView);
		}

		[Authorize]
		public ActionResult EditVehicle(int id)
		{
			Vehicle vehicle = VehicleRepositoryFactory.GetRepository().GetVehicleById(id);
			AdminViewModelEdit viewModel = new AdminViewModelEdit();
			viewModel.Populate();
			viewModel.Vehicle = vehicle;

			return View(viewModel);
		}


		[Authorize]
		[HttpPost]
		public ActionResult EditVehicle(AdminViewModelEdit model)
		{
			if (ModelState.IsValid)
			{
				var repo = VehicleRepositoryFactory.GetRepository();
				try
				{
					if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
					{
						var savepath = Server.MapPath("~/Images/");

						int vehicleId = model.Vehicle.VehicleId;
						string strVehicleId = "inventory-" + vehicleId.ToString();
						string extension = Path.GetExtension(model.ImageUpload.FileName);


						var filePath = Path.Combine(savepath, strVehicleId + extension);

						model.ImageUpload.SaveAs(filePath);

						model.Vehicle.PhotoPath = Path.GetFileName(filePath);
					}
					repo.EditVehicle(model.Vehicle);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				return RedirectToAction("index", "admin", new { id = model.Vehicle.VehicleId });
			}

			AdminViewModelEdit viewModel = new AdminViewModelEdit();
			viewModel.Populate();
			viewModel.Vehicle = model.Vehicle;

			return View(viewModel);
		}


		[Authorize]
		[HttpPost]
		public ActionResult DeleteVehicle(AdminViewModelEdit viewModel)
		{
			var savepath = Server.MapPath("~/Images/");
			var filePath = savepath + viewModel.Vehicle.PhotoPath;

			if (System.IO.File.Exists(filePath))
			{
				System.IO.File.Delete(filePath);
			}

			viewModel.Vehicle.IsDeleted = true;
			VehicleRepositoryFactory.GetRepository().EditVehicle(viewModel.Vehicle);

			return RedirectToAction("Index", "Admin");
		}

		[Authorize]
		public ActionResult Users()
		{
			var model = UsersRepositoryFactory.GetRepository().GetAll();
			return View(model);
		}

		[Authorize]
		public ActionResult AddUser()
		{
			UserViewModel model = new UserViewModel();
			var context = new ApplicationDbContext();

			model.User = new ApplicationUser();
			model.Roles = new SelectList(context.Roles.ToList(), "Name", "Name");
			return View(model);
		}

		[Authorize]
		[HttpPost]
		public async Task<ActionResult> AddUser(UserViewModel viewModel)
		{
			ApplicationDbContext context = new ApplicationDbContext();

			try
			{
				if (ModelState.IsValid)
				{

					var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
					var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
					var user = viewModel.User;
					user.Email = viewModel.User.UserName;
					var result = await UserManager.CreateAsync(user, user.PasswordHash);
					if (result.Succeeded)
						result = UserManager.AddToRole(user.Id, user.RoleId);

					return RedirectToAction("Users", "Admin");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			viewModel.Roles = new SelectList(context.Roles.ToList(), "Name", "Name");
			return View(viewModel);
		}

		[Authorize]
		public ActionResult UpdateUser(string id)
		{
			var context = new ApplicationDbContext();
			var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			UserViewModel viewModel = new UserViewModel();

			viewModel.User = UserManager.FindById(id);
			viewModel.User.PasswordHash = "";
			viewModel.Roles = new SelectList(context.Roles.ToList(), "Name", "Name");
			return View(viewModel);
		}

		[Authorize(Roles = "admin,sales")]
		[HttpPost]
		public ActionResult UpdateUser(UserViewModel viewModel)
		{
			ApplicationDbContext context = new ApplicationDbContext();

			try
			{
				if (ModelState.IsValid)
				{

					var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
					var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
					var user = UserManager.FindById(viewModel.User.Id);

					user.FirstName = viewModel.User.FirstName;
					user.LastName = viewModel.User.LastName;
					user.UserName = viewModel.User.UserName;
					user.Email = viewModel.User.UserName;
					user.PasswordHash = viewModel.User.PasswordHash;

					var result = UserManager.Update(user);
					if (result.Succeeded)
						result = UserManager.AddToRole(user.Id, user.RoleId);

					return RedirectToAction("Users", "Admin");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			viewModel.Roles = new SelectList(context.Roles.ToList(), "Name", "Name");
			return View(viewModel);
		}

		public ActionResult ChangePassword()
		{
			return View();
		}

		[Authorize]
		public ActionResult Makes()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		public ActionResult Makes(Make make)
		{
			make.DateAdded = DateTime.Now;
			make.UserId = User.Identity.Name;
			VehicleRepositoryFactory.GetRepository().AddMake(make);
			return View();
		}

		[Authorize]
		public ActionResult Models()
		{
			ModelViewModel viewModel = new ModelViewModel();
			viewModel.Makes = new SelectList(VehicleRepositoryFactory.GetRepository().GetMakeItems(), "MakeId", "MakeName");
			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		public ActionResult Models(ModelViewModel viewModel)
		{
			Model vehicleModel = new Model();
			vehicleModel.DateAdded = DateTime.Now;
			vehicleModel.UserId = User.Identity.Name;
			vehicleModel.ModelName = viewModel.VehicleModel.ModelName;
			vehicleModel.MakeId = viewModel.VehicleModel.MakeId;
			VehicleRepositoryFactory.GetRepository().AddModel(vehicleModel);

			viewModel.VehicleModel = new ModelItem();
			viewModel.Makes = new SelectList(VehicleRepositoryFactory.GetRepository().GetMakeItems(), "MakeId", "MakeName");
			return View(viewModel);
		}

		[Authorize]
		public ActionResult Specials()
		{
			SpecialsViewModel viewModel = new SpecialsViewModel();
			viewModel.Specials = SpecialsRepositoryFactory.GetRepository().GetAllSpecials();
			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		public ActionResult Specials(SpecialsViewModel viewModel)
		{
			SpecialsRepositoryFactory.GetRepository().AddSpecial(viewModel.AddSpecial);

			viewModel.AddSpecial = new Special();
			viewModel.Specials = SpecialsRepositoryFactory.GetRepository().GetAllSpecials();
			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		public ActionResult DeleteSpecial(SpecialsViewModel viewModel)
		{
			SpecialsRepositoryFactory.GetRepository().DeleteSpecial(viewModel.AddSpecial.SpecialId);

			return RedirectToAction("Specials","Admin");
		}
	}
}