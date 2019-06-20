using CarDealership.Data;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Factories
{
	public class SalesRepositoryFactory
	{
		public static ISalesRepository GetRepository()
		{
			switch (Settings.GetRepositoryType())
			{
				case "QA":
					return new Data.QARepository.SalesRepository();
				case "PROD":
					return new Data.ProductRepository.SalesRepository();
				default:
					throw new Exception("Couldn't find the configuration type");
			}
		}
	}
}