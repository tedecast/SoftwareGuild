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
    public class ReportsAPIController : ApiController
    {
		[Route("reports/search/")]
		[AcceptVerbs("GET")]
		public IHttpActionResult GetSales(string userSelect, string fromDate, string toDate)
		{
			if (string.IsNullOrEmpty(userSelect))
			{
				userSelect = "";
			}

			SalesSearchItem parameters = new SalesSearchItem();

			parameters.UserSelect = userSelect;
			if (string.IsNullOrEmpty(fromDate))
			{
				parameters.FromDate = null;
			}
			else
				parameters.FromDate = DateTime.Parse(fromDate);
			if (string.IsNullOrEmpty(toDate))
			{
				parameters.ToDate = null;
			}
			else
				parameters.ToDate = DateTime.Parse(toDate);

			List<SalesReportItem> sales = SalesRepositoryFactory.GetRepository().GetSalesBySearch(parameters);
			if (sales == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(sales);
			}
		}
	}
}
