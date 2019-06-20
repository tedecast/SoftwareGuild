using CarDealership.Data;
using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL
{
	public class AddSaleLogic
	{
		public static IVehicleRepository AddSale(IVehicleRepository vRepo, ISalesRepository sRepo, int id)
		{
			if (Settings.GetRepositoryType() == "QA")
			{
				Vehicle v = vRepo.GetVehicleById(id);
				v.IsSold = true;

				vRepo.EditVehicle(v);
			}

			return vRepo;
		}
	}
}
