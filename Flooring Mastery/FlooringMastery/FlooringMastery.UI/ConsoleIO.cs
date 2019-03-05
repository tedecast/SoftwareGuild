using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
	public static class ConsoleIO
	{
		public static string OrderNumberPrompt()
		{
			Console.WriteLine("Lookup an order");
			DividingLine();
			Console.Write("Enter an order number: ");
			return Console.ReadLine();

		}
		public static string OrderDatePrompt()
		{
			Console.Write("Enter an order date (mm/dd/yyyy): ");
			return Console.ReadLine();

		}

		public static bool ConfirmAddEntry()
		{
			string confirmAdd;
			while (true)
			{
				Console.WriteLine("Please confirm the above order to enter it into the system. (Y/N)");
				confirmAdd = Console.ReadLine().ToUpper();

				if (!isNull(confirmAdd))
				{
					break;
				}

				NullInput();
			}

			if (confirmAdd == "Y")
				return true;
			else
				return false;

		}
		public static bool ConfirmDeleteEntry()
		{
			string confirmDelete;
			while (true)
			{
				Console.WriteLine("Please confirm the above order to delete it from the system. (Y/N)");
				confirmDelete = Console.ReadLine().ToUpper();

				if (!isNull(confirmDelete))
				{
					break;
				}

				NullInput();
			}

			if (confirmDelete == "Y")
				return true;
			else
				return false;

		}

		public static bool isValidOrderNumber(string orderNumber)
		{
			int orderNum;
			return int.TryParse(orderNumber, out orderNum);

		}
		public static Response isDateValid(Response response)
		{
			var userTime = DateTime.Parse(response.Date);
			var timeNow = DateTime.Now;
			if (timeNow > userTime)
			{
				response.Success = false;
				response.Message = "Error: the date must be in the future.";
				return response;
			}
			return response;
		}
		public static bool isNull(string input)
		{
			
			if (input != null && input != "")
			{
				return false;
			}

			return true;
		}
		public static void NullInput()
		{
			Console.WriteLine("The input cannot be blank");
		}
		public static void InvalidInput(Response response)
		{
			Console.WriteLine(response.Message);
		}

		public static void DisplayOrdersDetails(List<Order> orders)
		{
			foreach (Order order in orders)
			{
				Console.WriteLine($"Order Number: {order.OrderNumber+1} Order Date: {order.OrderDate}");
				Console.WriteLine($"Customer Name: {order.CustomerName}");
				Console.WriteLine($"State: {order.State}");
				Console.WriteLine($"Product: {order.ProductType}");
				Console.WriteLine($"Materials: {order.MaterialCost}");
				Console.WriteLine($"Labor: {order.LaborCost}");
				Console.WriteLine($"Tax: {order.Tax}");
				Console.WriteLine($"Total: {order.Total}");
				DividingLine();
			}
		}
		public static void DisplayOrderSummaryDetails(Order order, string orderDate/*figure out a way to make the date look nice*/)
		{
			{ 
				Console.WriteLine($"Order Number: {order.OrderNumber+1} Order Date: {orderDate}");
				Console.WriteLine($"Customer Name: {order.CustomerName}");
				Console.WriteLine($"State: {order.State}");
				Console.WriteLine($"Product: {order.ProductType}");
				Console.WriteLine($"Materials: {order.MaterialCost}");
				Console.WriteLine($"Labor: {order.LaborCost}");
				Console.WriteLine($"Tax: {order.Tax}");
				Console.WriteLine($"Total: {order.Total}");
				DividingLine();
			}
		}
		public static void DividingLine()
		{
			Console.WriteLine("***************************************************************************");
		}
	
		public static void EditOrderDetails(Order order)
		{
			Console.WriteLine($"Enter a new customer name: ");
			string edit = Console.ReadLine();
			if (edit != null) 
			{
				order.CustomerName = edit;
			}

			Console.WriteLine($"Enter a new state: ");
			edit = Console.ReadLine();
			if (edit != null)
			{
				order.State = edit;
			}
			Console.WriteLine($"Enter a new Product: ");
			edit = Console.ReadLine();
			if (edit != null)
			{
				order.ProductType = edit;
			}

		}
		public static bool checkDate(string orderDate)
		{
			DateTime s;
			if (DateTime.TryParseExact(orderDate, "mm/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture,
		System.Globalization.DateTimeStyles.None, out s))
				return true;

			
			return false;
		}

		/*public static Response CheckInput(string date, Response response)
		{
			if (date == "" || response.o)

			//logic 
			
		}*/
	}
}

