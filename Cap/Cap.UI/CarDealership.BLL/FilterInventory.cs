using CarDealership.Data;
using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL
{
	public class FilterInventory
	{
		public static List<VehicleItem> NewInventory(List<VehicleItem> inventory)
		{

			List<VehicleItem> filteredInventory = inventory.Where(x => x.TypeName == "New").ToList();

			return filteredInventory;
		}

		public static List<VehicleItem> UsedInventory(List<VehicleItem> inventory)
		{

			List<VehicleItem> filteredInventory = inventory.Where(x => x.TypeName == "Used").ToList();

			return filteredInventory;
		}

		public static List<VehicleItem> SalesInventory(List<VehicleItem> inventory)
		{

			List<VehicleItem> filteredInventory = inventory.Where(x => x.IsSold == false).ToList();

			return filteredInventory;
		}
	}
}
