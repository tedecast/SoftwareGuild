using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepository
{
	public class VehicleRepository : IVehicleRepository
	{
		private List<MakeItem> _makes = new List<MakeItem>
		{
			new MakeItem
			{
				MakeId = 1,
				UserId = "00000000-0000-0000-0000-000000000000",
				MakeName = "Subaru",
				DateAdded = DateTime.Parse("1/1/2011")
			},
			new MakeItem
			{
				MakeId = 2,
				UserId = "00000000-0000-0000-0000-000000000000",
				MakeName = "Ford",
				DateAdded = DateTime.Parse("1/1/2012")

			},
			new MakeItem
			{
				MakeId = 3,
				UserId = "00000000-0000-0000-0000-000000000000",
				MakeName = "Kia",
				DateAdded = DateTime.Parse("1/1/2013")
			},

		};
		private List<Model> _models = new List<Model>
		{

			new Model
			{
				ModelId = 1,
				MakeId = 1,
				UserId = "00000000-0000-0000-0000-000000000000",
				ModelName = "Outback",
				DateAdded = DateTime.Parse("1/1/2019")
			},
			new Model
			{
				ModelId = 2,
				MakeId = 2,
				UserId = "00000000-0000-0000-0000-000000000000",
				ModelName = "F-150",
				DateAdded = DateTime.Parse("1/1/2018")
			},
			new Model
			{
				ModelId = 3,
				MakeId = 3,
				UserId = "00000000-0000-0000-0000-000000000000",
				ModelName = "Sedona",
				DateAdded = DateTime.Parse("1/1/2017")
			},
			new Model
			{
				ModelId = 4,
				MakeId = 1,
				UserId = "00000000-0000-0000-0000-000000000000",
				ModelName = "Forester",
				DateAdded = DateTime.Parse("1/1/2017")
			},
		};
		private static List<Body> _bodies = new List<Body>
		{

			new Body
			{
				BodyId = 1,
				BodyType = "Car"
			},
			new Body
			{
				BodyId = 2,
				BodyType = "SUV"
			},
			new Body
			{
				BodyId = 3,
				BodyType = "Truck"
			},
			new Body
			{
				BodyId = 4,
				BodyType = "Van"
			},
		};
		private static List<Interior> _interiors = new List<Interior>
		{
			new Interior
			{
				InteriorId = 1,
				InteriorColor = "Black"
			},
			new Interior
			{
				InteriorId = 2,
				InteriorColor = "White"
			},
			new Interior
			{
				InteriorId = 3,
				InteriorColor = "Red"
			},
			new Interior
			{
				InteriorId = 4,
				InteriorColor = "Leather - Black"
			},
			new Interior
			{
				InteriorId = 5,
				InteriorColor = "Leather - Tan"
			}
		};
		private static List<Color> _colors = new List<Color>
		{
			new Color
			{
				ColorId = 1,
				ColorName = "Black"
			},
			new Color
			{
				ColorId = 2,
				ColorName = "White"
			},
			new Color
			{
				ColorId = 3,
				ColorName = "Grey"
			},
			new Color
			{
				ColorId = 4,
				ColorName = "Red"
			},
			new Color
			{
				ColorId = 5,
				ColorName = "Beige"
			}
		};
		private static List<Models.Tables.Type> _types = new List<Models.Tables.Type>
		{
			new Models.Tables.Type
			{
				TypeId = 1,
				TypeName = "New"
			},
			new Models.Tables.Type
			{
				TypeId = 2,
				TypeName = "Used"
			}
		};
		private static List<Transmission> _transmissions = new List<Transmission>()
		{
			new Transmission
			{
				TransmissionId = 1,
				TransmissionType = "Automatic"
			},
			new Transmission
			{
				TransmissionId = 2,
				TransmissionType = "Manual"
			}
		};
		private List<Vehicle> _vehicles = new List<Vehicle>()
		{
			new Vehicle
			{
				VehicleId = 1,
				MakeId = 3,
				ModelId = 3,
				BodyId = 4,
				InteriorId = 3,
				ColorId = 1,
				TypeId = 1,
				TransmissionId = 1,
				Year = 2019,
				VIN = "3TMMU4FN2AM023309",
				Mileage = 0,
				MSRP = 25000.00M,
				SalePrice = 23000.00M,
				Description = "New Kia for sale",
				PhotoPath = "inventory-1.jpg",
				IsSold = false,
				IsFeatured = true
			},
			new Vehicle
			{
				VehicleId = 2,
				MakeId = 2,
				ModelId = 2,
				BodyId = 3,
				InteriorId = 2,
				ColorId = 4,
				TypeId = 2,
				TransmissionId = 2,
				Year = 2015,
				VIN = "JT2SW22N7M0049240",
				Mileage = 30000,
				MSRP = 20000.00M,
				SalePrice = 18000.00M,
				Description = "Gently used Ford F-150 for sale",
				PhotoPath = "inventory-2.jpg",
				IsSold = false,
				IsFeatured = true
			},
			new Vehicle
			{
				VehicleId = 3,
				MakeId = 1,
				ModelId = 1,
				BodyId = 1,
				InteriorId = 1,
				ColorId = 2,
				TypeId = 2,
				TransmissionId = 1,
				Year = 2011,
				VIN = "1GDHK39KX7E580109",
				Mileage = 75000,
				MSRP = 13000.00M,
				SalePrice = 12000.00M,
				Description = "Subaru OutBack for sale. Only one previous owner. Great family car!",
				PhotoPath = "inventory-3.jpg",
				IsSold = false,
				IsFeatured = false
			},
			new Vehicle
			{
				VehicleId = 4,
				MakeId = 1,
				ModelId = 4,
				BodyId = 1,
				InteriorId = 1,
				ColorId = 2,
				TypeId = 2,
				TransmissionId = 1,
				Year = 2012,
				VIN = "JH4DA9390MS033554",
				Mileage = 80000,
				MSRP = 16000.00M,
				SalePrice = 14000.00M,
				Description = "Subaru Forester for sale.",
				PhotoPath = "inventory-4.jpg",
				IsSold = false,
				IsFeatured = false
			}
		};

		public List<VehicleItem> GetAllVehiclesToItem()
		{

			var itemVehicles = from vehicle in _vehicles
						   join m in _makes on vehicle.MakeId equals m.MakeId
						   join mo in _models on vehicle.ModelId equals mo.ModelId
						   join i in _interiors on vehicle.InteriorId equals i.InteriorId
						   join c in _colors on vehicle.ColorId equals c.ColorId
						   join t in _types on vehicle.TypeId equals t.TypeId
						   join b in _bodies on vehicle.BodyId equals b.BodyId
						   join tr in _transmissions on vehicle.TransmissionId equals tr.TransmissionId
						   where vehicle.IsSold == false
							   select new VehicleItem { VehicleId = vehicle.VehicleId, MakeName = m.MakeName, ModelName = mo.ModelName,
							   InteriorColor = i.InteriorColor, ColorName = c.ColorName, TypeName = t.TypeName, BodyType = b.BodyType,
							   TransmissionType = tr.TransmissionType, Year = vehicle.Year, VIN = vehicle.VIN, MSRP = vehicle.MSRP,
								Mileage = vehicle.Mileage, Description = vehicle.Description, SalePrice = vehicle.SalePrice, PhotoPath = vehicle.PhotoPath,
								IsFeatured = vehicle.IsFeatured, IsSold = vehicle.IsSold};

			return itemVehicles.ToList();
		}

		public List<VehicleItem> GetVehicleToItemBySelect(List<Vehicle> v)
		{
			IEnumerable<VehicleItem> itemVehicles = (from vehicle in v
							   join m in _makes on vehicle.MakeId equals m.MakeId
							   join mo in _models on vehicle.ModelId equals mo.ModelId
							   join i in _interiors on vehicle.InteriorId equals i.InteriorId
							   join c in _colors on vehicle.ColorId equals c.ColorId
							   join t in _types on vehicle.TypeId equals t.TypeId
							   join b in _bodies on vehicle.BodyId equals b.BodyId
							   join tr in _transmissions on vehicle.TransmissionId equals tr.TransmissionId
							   select new VehicleItem()
							   {
								   VehicleId = vehicle.VehicleId,
								   MakeName = m.MakeName,
								   ModelName = mo.ModelName,
								   InteriorColor = i.InteriorColor,
								   ColorName = c.ColorName,
								   TypeName = t.TypeName,
								   BodyType = b.BodyType,
								   TransmissionType = tr.TransmissionType,
								   Year = vehicle.Year,
								   VIN = vehicle.VIN,
								   MSRP = vehicle.MSRP,
								   Mileage = vehicle.Mileage,
								   Description = vehicle.Description,
								   SalePrice = vehicle.SalePrice,
								   PhotoPath = vehicle.PhotoPath,
								   IsFeatured = vehicle.IsFeatured,
								   IsSold = vehicle.IsSold
							   });
			return itemVehicles.ToList();
		}

		public List<FeaturedVehicleItem> GetFeaturedVehicles(List<Vehicle> v)
		{
			var itemVehicles = from vehicle in _vehicles
							   join m in _makes on vehicle.MakeId equals m.MakeId
							   join mo in _models on vehicle.ModelId equals mo.ModelId
							   join ve in v on vehicle.VehicleId equals ve.VehicleId
							   where vehicle.VehicleId == ve.VehicleId
							   where vehicle.IsSold == false
							   select new FeaturedVehicleItem
							   {
								   VehicleId = vehicle.VehicleId,
								   MakeName = m.MakeName,
								   ModelName = mo.ModelName,
								   Year = vehicle.Year,
								   SalePrice = vehicle.SalePrice,
								   PhotoPath = vehicle.PhotoPath,
							   };

			return itemVehicles.ToList();
		}

		public List<MakeItem> GetMakes()
		{
			return _makes;
		}

		public List<ModelItem> GetModels()
		{
			var itemVehicles = from make in _makes
							   join mo in _models on make.MakeId equals mo.MakeId
							   select new ModelItem
							   {
								   MakeName = make.MakeName,
								   ModelName = mo.ModelName,
								   DateAdded = mo.DateAdded,
								   UserId = make.UserId,
								   MakeId = mo.MakeId
							   };

			return itemVehicles.ToList();
		}

		public void AddMake(Make make)
		{
			MakeItem item = new MakeItem()
			{
				MakeId = make.MakeId,
				UserId = make.UserId,
				MakeName = make.MakeName,
				DateAdded = make.DateAdded
			};
			_makes.Add(item);
		}

		public void AddModel(Model model)
		{
			_models.Add(model);
		}

		public void AddVehicle(Vehicle vehicle)
		{
			_vehicles.Add(vehicle);
		}

		public void DeleteVehicle(int id)
		{
			_vehicles.RemoveAll(v => v.VehicleId == id);
		}

		public void EditVehicle(Vehicle vehicle)
		{
			foreach (var editVehicle in _vehicles.Where(v => v.VehicleId == vehicle.VehicleId))
			{
				editVehicle.VehicleId = vehicle.VehicleId;
				editVehicle.MakeId = vehicle.MakeId;
				editVehicle.ModelId = vehicle.ModelId;
				editVehicle.BodyId = vehicle.BodyId;
				editVehicle.InteriorId = vehicle.InteriorId;
				editVehicle.ColorId = vehicle.ColorId;
				editVehicle.TypeId = vehicle.TypeId;
				editVehicle.TransmissionId = vehicle.TransmissionId;
				editVehicle.Year = vehicle.Year;
				editVehicle.VIN = vehicle.VIN;
				editVehicle.Mileage = vehicle.Mileage;
				editVehicle.MSRP = vehicle.MSRP;
				editVehicle.SalePrice = vehicle.SalePrice;
				editVehicle.Description = vehicle.Description;
				editVehicle.PhotoPath = vehicle.PhotoPath;
				editVehicle.IsFeatured = vehicle.IsFeatured;
				editVehicle.IsSold = vehicle.IsSold;
			}
		}

		public List<VehicleItem> GetAll()
		{
			return GetAllVehiclesToItem();
		}

		public List<FeaturedVehicleItem> GetFeatured()
		{
			var match = from vehicle in _vehicles
						where vehicle.IsFeatured == true
						select (vehicle);
			return GetFeaturedVehicles(match.ToList());
		}

		public List<MakeItem> GetMakeItems()
		{
			return GetMakes();
		}

		public List<ModelItem> GetModelItems()
		{
			return GetModels();
		}

		public VehicleItem GetVehicleItemById(int id)
		{
			var match = from vehicle in _vehicles
						where vehicle.VehicleId == id
						select (vehicle);

			return GetVehicleToItemBySelect(match.ToList()).FirstOrDefault();
		}

		public Vehicle GetVehicleById(int id)
		{
			var match = from vehicle in _vehicles
						where vehicle.VehicleId == id
						select (vehicle);

			return (match.ToList())[0];
		}



		public List<VehicleItem> GetVehicleBySearch(SearchItem search)
		{
			List<VehicleItem> vehicles = GetAllVehiclesToItem();

			if (!search.MinPrice.HasValue && !search.MaxPrice.HasValue && !search.MinYear.HasValue && !search.MaxYear.HasValue && string.IsNullOrEmpty(search.SearchTerm))
			{
				return vehicles.Take(20).OrderBy(x => x.MSRP).ToList();
			}

			var filteredVehicles = from v in vehicles
								   select v;

			if(search.MinPrice.HasValue)
			{
				filteredVehicles = from v in filteredVehicles
								   where (v.SalePrice >= search.MinPrice)
								   select v;
			}
			if (search.MaxPrice.HasValue)
			{
				filteredVehicles = from v in filteredVehicles
								   where (v.SalePrice <= search.MaxPrice)
								   select v;
			}
			if (search.MinYear.HasValue)
			{
				filteredVehicles = from v in filteredVehicles
								   where (v.Year >= search.MinYear)
								   select v;
			}
			if (search.MaxYear.HasValue)
			{
				filteredVehicles = from v in filteredVehicles
								   where (v.Year <= search.MaxYear)
								   select v;
			}
			if (!string.IsNullOrEmpty(search.SearchTerm))
			{
				filteredVehicles = from v in filteredVehicles
								   where (v.MakeName.ToLower().StartsWith(search.SearchTerm.ToLower()) || v.ModelName.ToLower().StartsWith(search.SearchTerm.ToLower()))
								   select v;
			}

			return filteredVehicles.ToList();
		}

		public List<InventoryReportItem> InventoryReport()
		{
			List<VehicleItem> vehicles = GetAllVehiclesToItem();

			var groupReport = from vehicle in _vehicles
							  join m in _makes on vehicle.MakeId equals m.MakeId
							  join mo in _models on vehicle.ModelId equals mo.ModelId
							  join t in _types on vehicle.TypeId equals t.TypeId
							  where vehicle.IsSold = false
							  group vehicle by new
							  {
								  vehicle.Year,
								  m.MakeName,
								  mo.ModelName,
								  mo.ModelId,
								  t.TypeName
							  };

			var finalReport = from g in groupReport
							  select new InventoryReportItem
							  {
								  Year = g.Key.Year,
								  MakeName = g.Key.MakeName,
								  ModelName = g.Key.ModelName,
								  Count = g.Count(),
								  StockValue = _vehicles.Where(x => x.ModelId == g.Key.ModelId).Sum(x => x.MSRP),
								  TypeName = g.Key.TypeName
							  };

			return finalReport.ToList();
		}
	}
}

