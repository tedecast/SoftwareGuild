using SGBank.Data;
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
	public class PremiumAccountWithdrawRule : IWithdraw
	{
		public AccountWithdrawResponse Withdraw(Account account, decimal amount)
		{
			AccountWithdrawResponse response = new AccountWithdrawResponse();

			if (account.Type != AccountType.Premium || account.Name != "Premium Customer")
			{
				response.Success = false;
				response.Message = "Error: a non-premium account hit the Premium Deposit Rule. Contact IT";
				return response;
			}
			if (amount >= 0)
			{
				response.Success = false;
				response.Message = "Withdrawal amounts must negative!";
				return response;
			}

			if (account.Balance + amount <= -500)
			{
				response.Success = false;
				response.Message = "This amount will overdraft your $500 limit!";
				return response;
			}



			response.OldBalance = account.Balance;
			account.Balance += amount;
			response.Account = account;
			response.Amount = amount;
			response.Success = true;

			return response;
		}
	}
}


