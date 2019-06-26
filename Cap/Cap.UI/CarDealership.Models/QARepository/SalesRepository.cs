using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepository
{
	public class SalesRepository : ISalesRepository
	{
		private List<Sale> _salesTable = new List<Sale>()
		{
			new Sale
			{
				SaleId = 1,
				UserId = "00000000-0000-0000-0000-000000000000",
				PurchaseTypeId = 1,
				VehicleId = 1,
				PurchasePrice = 22500,
				Name = "John",
				Phone = "5555555555",
				Email = "john@gmail.com",
				Street1 = "555 BobCat Way",
				Street2 = "Apt 7",
				City = "Austin",
				State = "Texas",
				Zipcode = "55551",
				DateSold = DateTime.Parse("1/1/2018")
			},
			new Sale
			{
				SaleId = 2,
				UserId = "00000000-0000-0000-0000-000000000000",
				PurchaseTypeId = 2,
				VehicleId = 2,
				PurchasePrice = 18000,
				Name = "James",
				Phone = "5555555555",
				Email = "james@gmail.com",
				Street1 = "555 Whirlaway Court",
				City = "Union",
				State = "Kentucky",
				Zipcode = "55552",
				DateSold = DateTime.Parse("1/1/2019")
			}
		};
		private List<PurchaseType> _purchaseTypeTable = new List<PurchaseType>()
		{
			new PurchaseType
			{
				PurchaseTypeId = 1,
				PurchaseTypeName = "Bank Finance"
			},
			new PurchaseType
			{
				PurchaseTypeId = 2,
				PurchaseTypeName = "Cash"
			},
			new PurchaseType
			{
				PurchaseTypeId = 3,
				PurchaseTypeName = "Dealer Finance"
			}
		};

		public List<Sale> GetAllSales()
		{

			return _salesTable;
		}

		public void AddSale(Sale sale)
		{
			_salesTable.Add(sale);
		}

		public List<SalesReportItem> GetSalesBySearch(SalesSearchItem search)
		{
			var salesReport = GetAllSales();
			var userRepo = new QARepository.UsersRepository();
			List<UserItem> users = userRepo.GetAll();

			var sales = from u in users
						join s in salesReport on u.UserId equals s.UserId
						select s;

			if (!string.IsNullOrEmpty(search.UserSelect))
			{
				 sales = from u in users
						join s in sales on u.UserId equals s.UserId
						 where (u.FirstName.ToLower() == search.UserSelect.ToLower())
						select s;
			}
			if (search.FromDate.HasValue)
			{ 
				sales = from u in users
						join s in sales on u.UserId equals s.UserId
						where (s.DateSold >= search.FromDate)
						select s;
			}
			if (search.ToDate.HasValue)
			{
				sales = from u in users
						join s in sales on u.UserId equals s.UserId
						where (s.DateSold <= search.ToDate)
						select s;
			}

			var filteredSales = from u in users
								join s in sales on u.UserId equals s.UserId
								group s by u.UserId;

			var filteredGroup = from s in filteredSales
								 select new SalesReportItem
						 {
							 FirstName = users.Find(x => x.UserId == s.Key).FirstName,
							LastName = users.Find(x => x.UserId == s.Key).LastName,
							FullName = users.Find(x => x.UserId == s.Key).FirstName + " " + users.Find(x => x.UserId == s.Key).LastName,
							 TotalSales = s.Where(p => p.UserId == s.Key).Sum(x => x.PurchasePrice),
							 TotalVehicles = s.Where(p => p.UserId == s.Key).Count()
						 };

			return filteredGroup.ToList();

		}

	}
}
