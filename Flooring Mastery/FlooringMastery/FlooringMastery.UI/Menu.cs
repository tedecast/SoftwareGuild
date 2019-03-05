using FlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
	public static class Menu
	{
		public static void Start()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("Flooring Ordering Application");
				ConsoleIO.DividingLine();
				Console.WriteLine("1. Display an Order");
				Console.WriteLine("2. Add an Order");
				Console.WriteLine("3. Edit an Order");
				Console.WriteLine("4. Remove an Order");
				ConsoleIO.DividingLine();
				Console.WriteLine("\nQ to quit");
				Console.WriteLine("\nEnter selection: ");

				string userinput = Console.ReadLine();

				switch (userinput)
				{
					case "1":
						OrderLookupWorkflow lookupWorkflow = new OrderLookupWorkflow();
						lookupWorkflow.Execute();
						break;
					case "2":
						OrderAddWorkflow addWorkflow = new OrderAddWorkflow();
						addWorkflow.Execute();
						break;
					case "3":
						OrderEditWorkflow editWorkflow = new OrderEditWorkflow();
						editWorkflow.Execute();
						break;
					case "4":
						OrderDeleteWorkflow deleteWorkflow = new OrderDeleteWorkflow();
						deleteWorkflow.Execute();
						break;
					case "Q":
						return;

				}
			}
		}
	}
}
