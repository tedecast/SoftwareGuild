using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
	public class ReportViewModel
	{
		public List<SelectListItem> Users { get; set; }
		public string FromDate { get; set; }
		public string ToDate { get; set; }


		public ReportViewModel()
		{
			Users = new List<SelectListItem>();

		}

		public void Populate()
		{
			var context = new ApplicationDbContext();
			var allUsers = context.Users.ToList().Where(x => x.RoleId == "Admin" || x.RoleId == "sales");

			foreach (var user in allUsers)
			{
				Users.Add(new SelectListItem { Text = user.FirstName + " " + user.LastName, Value = user.Id });
			}
		}
	}
}