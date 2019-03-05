using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
	public class OrderLookupWorkflow
	{
		public void Execute()
		{
			string orderDate;
			while (true)
			{
				OrderManager manager = OrderManagerFactory.Create();
				Response response = new Response();
				while (true)
				{
					Console.Clear();
					ConsoleIO.DividingLine();

					//Get date and check that it is valid
					orderDate = ConsoleIO.OrderDatePrompt();
					if (ConsoleIO.checkDate(orderDate))
					{
						break;
					}

					Console.WriteLine();
					Console.WriteLine("An error occurred.");
					Console.WriteLine("Please enter a valid date");
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
				}

				response = manager.LookupOrder(orderDate);
				if (response.Success)
				{
					ConsoleIO.DisplayOrdersDetails(response.Orders);

					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
					ConsoleIO.DividingLine();
					break;
				}
				else
				{
					Console.WriteLine("An error occurred: ");
					Console.WriteLine(response.Message);
				}

				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				ConsoleIO.DividingLine();
			}
		}
	}
}
