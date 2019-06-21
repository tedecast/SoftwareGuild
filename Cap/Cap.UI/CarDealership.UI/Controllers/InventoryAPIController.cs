using CarDealership.BLL;
using CarDealership.Models.Queries;
using CarDealership.UI.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class InventoryAPIController : ApiController
    {
		[Route("inventory")]
		[AcceptVerbs("GET")]
		public IHttpActionResult SelectAll()
		{
			var repo = VehicleRepositoryFactory.GetRepository().GetAll();
			return Ok(repo);
		}


		/*[Route("inventory/details/{id}")]
		[AcceptVerbs("GET")]
		public IHttpActionResult GetbyId(int id)
		{
			var repo = VehicleRepositoryFactory.GetRepository();

			VehicleItem vehicle = repo.GetVehicleItemById(id);

			if (vehicle == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(vehicle);
			}
		}*/

		[Route("inventory/search/new")]
		[AcceptVerbs("GET")]
		public IHttpActionResult GetNewBySearch(string searchTerm, int? minPrice, int?maxPrice, int?minYear, int?maxYear)
		{
			SearchItem parameters = new SearchItem()
			{
				SearchTerm = searchTerm,
				MinPrice = minPrice,
				MaxPrice = maxPrice,
				MinYear = minYear,
				MaxYear = maxYear
			};

			var repo = VehicleRepositoryFactory.GetRepository();
			List<VehicleItem> vehicle = repo.GetVehicleBySearch(parameters);

			if (vehicle == null)
			{
				return NotFound();
			}
			else
			{
				var filteredVehicles = FilterInventory.NewInventory(vehicle);
				return Ok(filteredVehicles);
			}
		}

		[Route("inventory/search/used")]
		[AcceptVerbs("GET")]
		public IHttpActionResult GetUsedBySearch(string searchTerm, int? minPrice, int? maxPrice, int? minYear, int? maxYear)
		{
			SearchItem parameters = new SearchItem()
			{
				SearchTerm = searchTerm,
				MinPrice = minPrice,
				MaxPrice = maxPrice,
				MinYear = minYear,
				MaxYear = maxYear
			};

			var repo = VehicleRepositoryFactory.GetRepository();
			List<VehicleItem> vehicle = repo.GetVehicleBySearch(parameters);

			if (vehicle == null)
			{
				return NotFound();
			}
			else
			{
				var filteredVehicles = FilterInventory.UsedInventory(vehicle);
				return Ok(filteredVehicles);
			}
		}
	}
}	
