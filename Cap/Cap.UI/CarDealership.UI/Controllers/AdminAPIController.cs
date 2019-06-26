using CarDealership.Models.Tables;
using CarDealership.UI.Factories;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CarDealership.UI.Controllers
{
    public class AdminAPIController : ApiController
    {
		[Route("Admin/Add/ModelList/")]
		[AcceptVerbs("GET")]
		public IHttpActionResult SelectAll(int MakeId)
		{
			var repo = VehicleRepositoryFactory.GetRepository().GetModelItems().Where(x => x.MakeId == MakeId);

			return Ok(repo);
		}

		[Route("Admin/GetMakes/")]
		[AcceptVerbs("GET")]
		public IHttpActionResult SelectAllMakes()
		{
			var repo = VehicleRepositoryFactory.GetRepository().GetMakeItems();

			return Ok(repo);
		}

		[Route("Admin/GetModels/")]
		[AcceptVerbs("GET")]
		public IHttpActionResult SelectAllModels()
		{
			var repo = VehicleRepositoryFactory.GetRepository().GetModelItems();

			return Ok(repo);
		}
	}
}
