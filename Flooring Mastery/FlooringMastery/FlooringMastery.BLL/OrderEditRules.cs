using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
	public class OrderEditRules
	{
		public static Response UserEditInput(Response response)
		{

			Regex rg = new Regex(@"^[a-zA-Z0-9\s,.!?]*$");
			bool validName = rg.IsMatch(response.order.CustomerName);

			if (!validName)
			{
				response.Success = false;
				response.Message = "Error: the name must be [a-z] [0-9] or punctuation.";
				return response;
			}

			var states = new List<Taxes>();
			states = OrderManager.LoadTaxes();
			int index = states.FindIndex(a => a.stateAbbreviation == response.order.State || a.stateName == response.order.State);
			if (index == -1)
			{
				response.Success = false;
				response.Message = "Error: the state is not included in our system.";
				return response;
			}
			else
			{
				response.order.State = states[index].stateAbbreviation;
				response.order.TaxRate = states[index].taxRate;
			}
			var products = new List<Products>();
			products = OrderManager.LoadProducts();
			index = products.FindIndex(a => a.productType == response.order.ProductType);
			if (index == -1)
			{
				response.Success = false;
				response.Message = "Error: the product is not included in our system.";
				return response;
			}
			else
			{
				response.order.ProductType = products[index].productType;
				response.order.CostPerSquareFoot = products[index].costPerSquareFoot;
				response.order.LaborCostPerSquareFoot = products[index].laborCostPerSquareFoot;
			}
			if (response.order.Area < 100)
			{
				response.Success = false;
				response.Message = "Error: the area must be a positive number and greater than 100.";
				return response;
			}
			response.Success = true;
			return response;
		}
	}
}
