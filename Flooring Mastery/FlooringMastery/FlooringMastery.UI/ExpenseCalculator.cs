using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
	public class ExpenseCalculator
	{
			public static Order Calculator(Response response)
			{
				response.order.MaterialCost = Math.Round((response.order.Area * response.order.CostPerSquareFoot), 2);
				response.order.LaborCost = Math.Round((response.order.Area * response.order.LaborCostPerSquareFoot), 2);
				response.order.Tax = Math.Round((response.order.MaterialCost + response.order.LaborCost) * (response.order.TaxRate / 100), 2);
				response.order.Total = Math.Round((response.order.MaterialCost + response.order.LaborCost + response.order.Tax),2);

				return response.order;
			}
	}
}
