using FlooringMastery.Data;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
	public static class OrderManagerFactory
	{
		public static OrderManager Create()
		{
			string mode = ConfigurationManager.AppSettings["Mode"].ToString();

			switch (mode)
			{
				case "TestOrder":
					return new OrderManager(new TestOrderRepository());
				case "ReadFile":
					return new OrderManager(new FileOrderRepository());
				default:
					throw new Exception("Mode value in app config is not valid");
			}
		}
	}
}
