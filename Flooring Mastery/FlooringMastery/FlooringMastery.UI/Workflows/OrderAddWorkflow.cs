using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
	public class OrderAddWorkflow
	{
		public void Execute()
		{
			OrderManager manager = OrderManagerFactory.Create();
			Response response = new Response();
			response.order = new Order();
			string orderDate;
			decimal area = 0;

			while (true)
			{
				while (true)
				{
					Console.Clear();
					ConsoleIO.DividingLine();
					Console.WriteLine("Enter an order date: (mm/dd/yyyy)");
					orderDate = Console.ReadLine();
					bool validDate = ConsoleIO.checkDate(orderDate);
					response.order.OrderDate = orderDate;

					Console.WriteLine("Enter the Customer's Name: ");
					response.order.CustomerName = Console.ReadLine();

					Console.WriteLine("Enter the state: ");
					response.order.State = Console.ReadLine();

					Console.WriteLine("Enter product type: ");
					response.order.ProductType = Console.ReadLine();

					Console.WriteLine("Enter an area: ");
					string userArea = Console.ReadLine();
					ConsoleIO.DividingLine();
					if (Decimal.TryParse(userArea, out area))
					{
						if (IsAnyNullOrEmpty(response.order) || !validDate)
						{
							ConsoleIO.DividingLine();
							if (!validDate)
								Console.WriteLine("Enter a valid date (mm/dd/yyyy)");

							else
							{
								ConsoleIO.NullInput();
							}
							Console.WriteLine("Press any key to continue");
							Console.ReadKey();
						}
						else
						{
							break;
						}
					}
					else
					{
						ConsoleIO.DividingLine();
						Console.WriteLine("Enter a number for the area.");
						Console.WriteLine("Press any key to continue");
						Console.ReadKey();
					}
				}

				//add area, products, material cost and labor cost
				response.order.Area = area;
				response = OrderAddRules.UserAddInput(orderDate, response);
				response.order = ExpenseCalculator.Calculator(response);
				response.order.OrderNumber = manager.LookupOrder(orderDate).Orders.Count;

				if (response.Success)
				{
					Console.Clear();
					ConsoleIO.DisplayOrderSummaryDetails(response.order, orderDate);
					if (ConsoleIO.ConfirmAddEntry())
					{
						manager.AddOrder(response, orderDate);
					}
					break;
				}
				else
				{
					Console.WriteLine(response.Message);
				}
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}
		}

		public string ValidUserProduct(string userProduct, OrderManager manager)
		{
			var products = OrderManager.LoadProducts();
			int index = ProductIndex(products, userProduct);
			if (index != -1)
			{
				return products[index].productType;
			}
			return null;
		}

		public Order AddProducts(Response response, string userProduct, OrderManager manager)
		{
			var products = OrderManager.LoadProducts();
			int index = ProductIndex(products, userProduct);
			response.order.CostPerSquareFoot = decimal.Parse(products[index].costPerSquareFoot.ToString());
			response.order.LaborCostPerSquareFoot = decimal.Parse(products[index].laborCostPerSquareFoot.ToString());

			return response.order;
		}

		int ProductIndex(List<Products> products, string userProduct)
		{
			return products.FindIndex(a => a.productType == userProduct);

		}

		public decimal AddStateInfo(Response response, string userProduct)
		{
			var taxes = OrderManager.LoadTaxes();
			var products = OrderManager.LoadProducts();
			int index = TaxesIndex(taxes, response.order.State);
			if (index == -1)
			{
				return index;
			}
			else
			{
				return taxes[index].taxRate;
			}
		}

		int TaxesIndex(List<Taxes> taxes, string state)
		{
			return taxes.FindIndex(a => a.stateAbbreviation == state || a.stateName == state);
		}

		bool IsAnyNullOrEmpty(Order order)
		{
			if (string.IsNullOrWhiteSpace(order.CustomerName) || string.IsNullOrWhiteSpace(order.State) || string.IsNullOrWhiteSpace(order.ProductType))
				return true;
			else
				return false;
		}


	}
}
