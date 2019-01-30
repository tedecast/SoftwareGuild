using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgBank.UI.Workflows
{
	public class DepositWorkflow
	{
		public void Execute()
		{
			AccountManager accountManager = AccountManagerFactory.Create();

			Console.Clear();
			Console.WriteLine("Enter an account number: ");
			string accountNumber = Console.ReadLine();

			Console.Write("Enter a deposit amount: ");
			decimal amount = decimal.Parse(Console.ReadLine());

			AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

			if (response.Success)
			{
				Console.WriteLine("Deposit completed!");
				Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
				Console.WriteLine($"Old balance: {response.OldBalance:c}");
				Console.WriteLine($"Amount Deposited: {response.Amount:c}");
				Console.WriteLine($"New Balance: {response.Account.Balance:c}");

			}
			else { Console.WriteLine("An error occured: "); Console.WriteLine(response.Message); }

			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}
