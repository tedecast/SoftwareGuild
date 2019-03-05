using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
	public class OrderDeleteRules
	{
		public static bool UserDeleteInput(List<Order> orders, int orderNumber)
		{
			string orderDate = null;

			var userTime = DateTime.Parse(orderDate);
			var timeNow = DateTime.Now;
			if (timeNow > userTime)
			{
				return false;
			}
			return true;
		}
	}
}
