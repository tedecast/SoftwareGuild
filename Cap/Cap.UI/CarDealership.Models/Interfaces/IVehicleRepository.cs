using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
	public interface IVehicleRepository
	{
		List<VehicleItem> GetAll();
		VehicleItem GetVehicleItemById(int id);
		List<VehicleItem> GetVehicleToItemBySelectforSale(List<VehicleItem> v );
		Vehicle GetVehicleById(int id);
		List<FeaturedVehicleItem> GetFeatured();
		List<VehicleItem> GetVehicleBySearch(SearchItem search);
		void AddVehicle(Vehicle vehicle);
		void EditVehicle(Vehicle vehicle);
		void DeleteVehicle(int id);
		List<MakeItem> GetMakeItems();
		void AddMake(Make make);
		List<ModelItem> GetModelItems();
		void AddModel(Model model);


	}
}
