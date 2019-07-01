using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepository
{
	public class UsersRepository : IUsersRepository
	{
		private List<UserItem> _users = new List<UserItem>()
		{
			new UserItem
			{
				UserId = "00000000-0000-0000-0000-000000000000",
				RoleId = "Admin",
				Email = "test1@test.com",
				LockoutEnabled = false,
				UserName = "admin@test.com",
				FirstName = "Test",
				LastName = "Subject",
				PasswordHash = "Test123!"
			}
		};

		/*private List<UserItem> _userRoles = new List<UserItem>()
		{
			new UserItem
			{
				RoleId = "admin"
			},

			new UserItem
			{
				RoleId = "sales"
			}
		};*/
		public void AddUser(UserItem user)
		{
			_users.Add(user);
			//_userRoles.Add(user);
		}

		public void EditPassword(UserItem user)
		{
			foreach (var editPassword in _users.Where(u => u.UserId == user.UserId))
			{
				editPassword.PasswordHash = user.PasswordHash;
			}
		}

		public void EditUser(UserItem user)
		{
			foreach (var editUser in _users.Where(u => u.UserId == user.UserId))
			{
				editUser.FirstName = user.FirstName;
				editUser.LastName = user.LastName;
				editUser.Email = user.Email;
				editUser.RoleId = user.RoleId;
				editUser.PasswordHash = user.PasswordHash;
			}

			/*foreach (var editUser in _userRoles.Where(u => u.Id == user.Id))
			{
				editUser.RoleId = user.RoleId;
			}*/
		}

		public List<UserItem> GetAll()
		{
			return _users;
		}
	}
}
