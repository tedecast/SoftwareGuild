using CarDealership.Data;
using CarDealership.Data.Interfaces;
using CarDealership.Data.QARepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Factories
{
	public class VehicleRepositoryFactory
	{
		public static IVehicleRepository GetRepository()
		{
			switch (Settings.GetRepositoryType())
			{
				case "QA":
					return new Data.QARepository.VehicleRepository();
				case "PROD":
					return new Data.ProductRepository.VehicleRepository();
				default:
					throw new Exception("Couldn't find the configuration type");
			}
		}
	}
}