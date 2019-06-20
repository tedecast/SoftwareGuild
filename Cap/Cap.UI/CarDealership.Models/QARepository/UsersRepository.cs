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
				Id = "00000000-0000-0000-0000-000000000000",
				RoleId = "admin",
				Email = "test1@test.com",
				LockoutEnabled = false,
				UserName = "Test Subject",
				FirstName = "Test",
				LastName = "Subject"
			}
		};
		public void AddUser(UserItem user)
		{
			_users.Add(user);
		}

		public void EditPassword(UserItem user)
		{
			foreach (var editPassword in _users.Where(u => u.Id == user.Id))
			{
				editPassword.Password = user.Password;
			}
		}

		public void EditUser(UserItem user)
		{
			foreach (var editUser in _users.Where(u => u.Id == user.Id))
			{
				editUser.FirstName = user.FirstName;
				editUser.LastName = user.LastName;
				editUser.Email = user.Email;
				editUser.RoleId = user.RoleId;
				editUser.Password = user.Password;
			}
		}

		public List<UserItem> GetAll()
		{
			return _users;
		}
	}
}
