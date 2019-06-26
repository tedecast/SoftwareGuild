using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
	public class UserItem
	{
		public string UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string PasswordHash { get; set; }
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
		public bool PhoneNumberConfirmed { get; set; }
		public string RoleId { get; set; }
		public bool LockoutEnabled { get; set; }
		public bool TwoFactorEnabled { get; set; }
		public bool AccessFailedCount { get; set; }
	}

}
