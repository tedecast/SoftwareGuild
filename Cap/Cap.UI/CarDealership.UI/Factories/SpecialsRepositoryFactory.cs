using CarDealership.Data;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Factories
{
	public class SpecialsRepositoryFactory
	{
		public static ISpecialsRepository GetRepository()
		{
			switch (Settings.GetRepositoryType())
			{
				case "QA":
					return new Data.QARepository.SpecialsRepository();
				case "PROD":
					return new Data.ADO.SpecialsRepositoryADO();
				default:
					throw new Exception("Couldn't find the configuration type");
			}
		}
	}
}