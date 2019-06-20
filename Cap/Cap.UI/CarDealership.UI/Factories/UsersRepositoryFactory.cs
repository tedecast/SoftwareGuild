using CarDealership.Data;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Factories
{
	public class UsersRepositoryFactory
	{
		public static IUsersRepository GetRepository()
		{
			switch (Settings.GetRepositoryType())
			{
				case "QA":
					return new Data.QARepository.UsersRepository();
				case "PROD":
					return new Data.ProductRepository.UsersRepository();
				default:
					throw new Exception("Couldn't find the configuration type");
			}
		}
	}
}