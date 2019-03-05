using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
	public class OrderDeleteWorkflow
	{
		public void Execute()
		{
			OrderManager manager = OrderManagerFactory.Create();
			int orderNumber;
			string orderDate;
			while (true)
			{
				while (true)
				{
					Console.Clear();
					Console.WriteLine("Lookup an order to delete");
					ConsoleIO.DividingLine();

					Console.WriteLine("Enter a date (dd/mm/yyyy): ");
					orderDate = Console.ReadLine();
					bool validDate = ConsoleIO.checkDate(orderDate);

					Console.WriteLine("Enter an order number: ");
					bool numSuccess = int.TryParse(Console.ReadLine(), out orderNumber);

					if (numSuccess && orderNumber > -1 && validDate)
					{
						break;
					}

					if(!numSuccess || orderNumber <= -1)
						Console.WriteLine("Please enter a valid order number.");
					if (!validDate)
						Console.WriteLine("Please enter a valid date - mm/dd/yyyy");

					Console.WriteLine("Press any key to continue");
					Console.ReadKey();
				}

				OrderManagerFactory.Create();
				Response deleteResponse = new Response();

				deleteResponse = manager.LookupOrder(orderDate);
				if (orderNumber <= deleteResponse.Orders.Count && deleteResponse.Success)
				{
					bool confirmDeleteEntry;

						ConsoleIO.DisplayOrderSummaryDetails(deleteResponse.Orders[orderNumber - 1], orderDate);
						confirmDeleteEntry = ConsoleIO.ConfirmDeleteEntry();

					if (deleteResponse.Success && confirmDeleteEntry)
					{
						manager.DeleteOrder(deleteResponse.Orders, orderNumber);
					}
						break;
				}
				else
				{
					Console.WriteLine("An error occurred: ");

					if(!deleteResponse.Success)
						Console.WriteLine("That date does not exist.");
					else
						Console.WriteLine("That order number does not exist.");

					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
				}
			}
		}
	}
}
