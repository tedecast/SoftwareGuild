using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
		public class BasicAccountWithdrawRule : IWithdraw
		{
			public AccountWithdrawResponse Withdraw(Account account, decimal amount)
			{
				AccountWithdrawResponse response = new AccountWithdrawResponse();

				if (account.Type != AccountType.Basic || account.Name != "Basic Customer")
				{
					response.Success = false;
					response.Message = "Error: a non-basic account hit the Basic Deposit Rule. Contact IT";
					return response;
				}
				if (amount >= 0)
				{
					response.Success = false;
					response.Message = "Withdrawal amounts must negative!";
					return response;
				}
				if (amount < -500)
				{
					response.Success = false;
					response.Message = "Basic accounts cannot withdrawal more than $500";
					return response;
				}
				if (account.Balance + amount < -100)
				{
					response.Success = false;
					response.Message = "This amount will overdraft your $100 limit!";
					return response;
				}



				response.OldBalance = account.Balance;
				account.Balance += amount;
				response.Account = account;
				response.Amount = amount;
				response.Success = true;
			if (account.Balance < 0)
			{
				account.Balance += -10;
			}

				return response;
			}
		}
}

