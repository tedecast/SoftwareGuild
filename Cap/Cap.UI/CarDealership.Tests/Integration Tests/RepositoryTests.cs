using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Data.ADO;
using CarDealership.Data.ProductRepository;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.UI.Factories;
using CarDealership.Data;

namespace CarDealership.Tests.Integration_Tests
{
	[TestFixture]
	public class RepositoryTests
	{
		[Test]
		public void CanLoadSpecials()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			var repo = SpecialsRepositoryFactory.GetRepository();
			var specials = repo.GetAllSpecials();
		
			Assert.AreEqual(3, specials.Count);
			Assert.AreEqual("Labor Day Sale", specials[0].SpecialTitle);
			Assert.AreEqual("Auction Bid Day", specials[1].SpecialTitle);
			Assert.AreEqual("New Selection of Luxury Vehicles!", specials[2].SpecialTitle);
		}

		[Test]
		public void CanLoadContactUs()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			var repo = ContactUsRepositoryFactory.GetRepository();
			var contact = repo.GetAllContactUs();

			Assert.AreEqual(2, contact.Count);
			Assert.AreEqual("Charles", contact[0].Name);
		}

		[Test]
		public void CanAddContactUs()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			ContactUs item = new ContactUs();
			item.Name = "Test";
			item.Phone = "2222222222";
			item.Email = "test@test.com";
			item.Message = "Are you open memorial day?";

			var repo = ContactUsRepositoryFactory.GetRepository();
			repo.AddContactUs(item);

			var contact = repo.GetAllContactUs();
			Assert.AreEqual(3, contact.Count);
		}

		[Test]
		public void CanGetVehicleById()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			var repo = VehicleRepositoryFactory.GetRepository();
			VehicleItem vehicle = repo.GetVehicleItemById(1);

			Assert.AreEqual("Black", vehicle.ColorName);
			Assert.AreEqual("New Kia for sale", vehicle.Description);
			Assert.AreEqual("Kia", vehicle.MakeName);
			Assert.AreEqual("Sedona", vehicle.ModelName);
			Assert.AreEqual("Red", vehicle.InteriorColor);
			Assert.AreEqual("New", vehicle.TypeName);
			Assert.AreEqual("Van", vehicle.BodyType);
			Assert.AreEqual("Automatic", vehicle.TransmissionType);
			Assert.AreEqual(2019, vehicle.Year);
			Assert.AreEqual("3TMMU4FN2AM023309", vehicle.VIN);
			Assert.AreEqual(0, vehicle.Mileage);
			Assert.AreEqual(25000.00, vehicle.MSRP);
			Assert.AreEqual(23000.00, vehicle.SalePrice);
			Assert.AreEqual("inventory-1.jpg", vehicle.PhotoPath);
			Assert.AreEqual(true, vehicle.IsFeatured);
			Assert.AreEqual(false, vehicle.IsSold);
		}

		[Test]
		public void CanAddVehicle()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			Vehicle v = new Vehicle();
			v.VehicleId = 5;
			v.MakeId = 2;
			v.ModelId = 2;
			v.BodyId = 3;
			v.InteriorId = 3;
			v.ColorId = 1;
			v.TypeId = 2;
			v.TransmissionId = 1;
			v.Year = 2019;
			v.VIN = "3TMMU4FN2AM023309";
			v.Mileage = 5000;
			v.MSRP = 25000;
			v.SalePrice = 22000;
			v.Description = "Used Kia for sale.";
			v.PhotoPath = "~/images/inventory-1";
			v.IsFeatured = true;
			v.IsSold = false;

			var repo = VehicleRepositoryFactory.GetRepository();
			repo.AddVehicle(v);
			var vehicles = repo.GetAll();

			Assert.AreEqual(5, vehicles.Count);
		}

		[Test]
		public void CanEditVehicles()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			Vehicle v = new Vehicle();
			v.VehicleId = 1;
			v.MakeId = 3;
			v.ModelId = 3;
			v.BodyId = 4;
			v.InteriorId = 3;
			v.ColorId = 1;
			v.TypeId = 2;
			v.TransmissionId = 1;
			v.Year = 2019;
			v.VIN = "3TMMU4FN2AM023309";
			v.Mileage = 5000;
			v.MSRP = 25000;
			v.SalePrice = 22000;
			v.Description = "Used Kia for sale.";
			v.PhotoPath = "~/images/inventory-1";
			v.IsFeatured = true;
			v.IsSold = false;

			var repo = VehicleRepositoryFactory.GetRepository();
			repo.EditVehicle(v);
			var vehicles = repo.GetAll();

			Assert.AreEqual(4, vehicles.Count);
			Assert.AreEqual("Black", vehicles[0].ColorName);
			Assert.AreEqual("Used Kia for sale.", vehicles[0].Description);
			Assert.AreEqual("Kia", vehicles[0].MakeName);
			Assert.AreEqual("Sedona", vehicles[0].ModelName);
			Assert.AreEqual("Red", vehicles[0].InteriorColor);
			Assert.AreEqual("Used", vehicles[0].TypeName);
			Assert.AreEqual("Van", vehicles[0].BodyType);
			Assert.AreEqual("Automatic", vehicles[0].TransmissionType);
			Assert.AreEqual(2019, vehicles[0].Year);
			Assert.AreEqual("3TMMU4FN2AM023309", vehicles[0].VIN);
			Assert.AreEqual(5000, vehicles[0].Mileage);
			Assert.AreEqual(25000.00, vehicles[0].MSRP);
			Assert.AreEqual(22000.00, vehicles[0].SalePrice);
			Assert.AreEqual("~/images/inventory-1", vehicles[0].PhotoPath);
			Assert.AreEqual(true, vehicles[0].IsFeatured);
			Assert.AreEqual(false, vehicles[0].IsSold);
		}

		[Test]
		public void CanLoadFeatured()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			var repo = VehicleRepositoryFactory.GetRepository();
			var featured = repo.GetFeatured();

			Assert.AreEqual(2, featured.Count);
			Assert.AreEqual("Kia", featured[0].MakeName);
			Assert.AreEqual("Ford", featured[1].MakeName);

		}

		[Test]
		public void CanLoadMake()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			var repo = VehicleRepositoryFactory.GetRepository();
			var makes = repo.GetMakeItems();

			Assert.AreEqual(3, makes.Count);
			Assert.AreEqual("Subaru", makes[0].MakeName);
			Assert.AreEqual("Ford", makes[1].MakeName);
			Assert.AreEqual("Kia", makes[2].MakeName);

		}

		[Test]
		public void CanAddModel()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			Model item = new Model();
			item.MakeId = 2;
			item.ModelName = "Focus";
			item.UserId = "00000000-0000-0000-0000-000000000000";
			item.DateAdded = DateTime.Parse("5/5/2019");

			var repo = VehicleRepositoryFactory.GetRepository();
			repo.AddModel(item);

			var models = repo.GetModelItems();
			Assert.AreEqual(5, models.Count);
			Assert.AreEqual("Focus", models.Where(x => x.DateAdded == DateTime.Parse("5/5/2019")).ToList()[0].ModelName);

		}

		[Test]
		public void CanAddMake()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			Make item = new Make();
			item.MakeName = "Lexus";
			item.UserId = "00000000-0000-0000-0000-000000000000";
			item.DateAdded = DateTime.Parse("1/1/2015");

			var repo = VehicleRepositoryFactory.GetRepository();
			repo.AddMake(item);

			var makes = repo.GetMakeItems();
			Assert.AreEqual(4, makes.Count);
			Assert.AreEqual("Lexus", makes[3].MakeName);

		}
		[Test]
		public void CanAddSale()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			Sale sale = new Sale();
			sale.UserId = "00000000-0000-0000-0000-000000000000";
			sale.PurchaseTypeId = 1;
			sale.VehicleId = 1;
			sale.PurchasePrice = 230000;
			sale.Name = "Jeremy Wakefield";
			sale.Phone = "8595477393";
			sale.Email = "jeremy@jeremy.com";
			sale.Street1 = "555 Street Ave";
			sale.City = "Lexington";
			sale.State = "KY";
			sale.Zipcode = "40508";

			var sRepo = SalesRepositoryFactory.GetRepository();
			var vRepo = VehicleRepositoryFactory.GetRepository();

			if (Settings.GetRepositoryType() == "QA")
			{
				Vehicle v = vRepo.GetVehicleById(sale.VehicleId);
				v.IsSold = true;

				vRepo.EditVehicle(v);
			}

			sRepo.AddSale(sale);
			VehicleItem sold = vRepo.GetVehicleItemById(sale.VehicleId);


			Assert.AreEqual(true, sold.IsSold);
		}
	}
}
