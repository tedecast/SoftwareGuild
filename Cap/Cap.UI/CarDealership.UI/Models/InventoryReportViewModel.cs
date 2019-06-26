using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
	public class InventoryReportViewModel
	{
		public List<InventoryReportItem> New { get; set; }
		public List<InventoryReportItem> Used { get; set; }
	}
}