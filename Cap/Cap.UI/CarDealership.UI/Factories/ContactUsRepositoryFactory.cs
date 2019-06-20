using CarDealership.Data;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Factories
{
	public class ContactUsRepositoryFactory
	{
		public static IContactUsRepository GetRepository()
		{
			switch (Settings.GetRepositoryType())
			{
				case "QA":
					return new Data.QARepository.ContactUsRepository();
				case "PROD":
					return new Data.ProductRepository.ContactUsRepository();
				default:
					throw new Exception("Couldn't find the configuration type");
			}
		}
	}
}
