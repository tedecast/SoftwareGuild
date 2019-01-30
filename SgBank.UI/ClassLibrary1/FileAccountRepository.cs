using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
	public class FileAccountRepository : IAccountRepository
	{
		private List<Account> _accounts;
		private string _filePath;

		public FileAccountRepository(string filePath)
		{
		    _filePath = filePath;
		}
		public List<Account> LoadFile()
		{
			_accounts = new List<Account>();
			string[] rows = File.ReadAllLines(_filePath);


			for (int i = 1; i < rows.Length; i++)
			{
				string[] columns = rows[i].Split(',');

				Account a = new Account();
				a.AccountNumber = columns[0];
				a.Name = columns[1];
				a.Balance = decimal.Parse(columns[2]);
				string type = columns[3];

				switch (type)
				{
					case "F":
						a.Type = AccountType.Free;
						break;
					case "B":
						a.Type = AccountType.Basic;
						break;
					case "P":
						a.Type = AccountType.Premium;
						break;
				}
				_accounts.Add(a);
			}
			return _accounts;
		}
		public Account LoadAccount(string accountNumber)
		{
			var accounts = LoadFile();
			int index = accounts.FindIndex(a => a.AccountNumber == accountNumber);

			if (index != -1)
				{
					return accounts[index];
				}
				else
				{
					return null;
				}
		}

		public void SaveAccount(Account account)
		{
			var accounts = LoadFile();
			int index = _accounts.FindIndex(a => a.AccountNumber == account.AccountNumber);

			accounts[index] = account;

			CreateAccountFile(accounts);

		}

		public void Add(Account account)
		{
			using (StreamWriter sw = new StreamWriter(_filePath, true))
			{
				string line = CreateCsvForAccount(account);
				sw.WriteLine(line);
			}
		}

		public void Delete(int index)
		{

			var accounts = LoadFile();
			accounts.RemoveAt(index);

			CreateAccountFile(accounts);
		}

		private string CreateCsvForAccount(Account account)
		{ 
			return string.Format("{0},{1},{2},{3}", account.AccountNumber, account.Name, account.Balance, account.Type.ToString()[0]);
		}
		private void CreateAccountFile(List<Account> accounts)
		{
			if (File.Exists(_filePath))
				File.Delete(_filePath);

			using (StreamWriter sr = new StreamWriter(_filePath))
			{
				sr.WriteLine("AccountNumber,Name,Balance,Type");
				foreach (var account in accounts)
				{
					sr.WriteLine(CreateCsvForAccount(account));
				}
			}
		}


	}
}
