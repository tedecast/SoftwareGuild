using CarDealership.Data.ProductRepository;
using CarDealership.Models.Queries;
using CarDealership.UI.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.Integration_Tests
{
	[TestFixture]
	class SearchFilterSalesTests
	{
		[Test]
		public void CanSearchByNoParameters()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SalesSearchItem search = new SalesSearchItem();
			var repo = SalesRepositoryFactory.GetRepository();
			var searchResults = repo.GetSalesBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual(40500, searchResults[0].TotalSales);
			Assert.AreEqual(2, searchResults[0].TotalVehicles);

		}
		[Test]
		public void CanSearchByQuery()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SalesSearchItem search = new SalesSearchItem();
			search.User = "Test";
			var repo = SalesRepositoryFactory.GetRepository();
			var searchResults = repo.GetSalesBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual(40500, searchResults[0].TotalSales);
			Assert.AreEqual(2, searchResults[0].TotalVehicles);

		}
		[Test]
		public void CanSearchByFromDate()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SalesSearchItem search = new SalesSearchItem();
			search.FromDate = DateTime.Parse("1/2/2018");
			var repo = SalesRepositoryFactory.GetRepository();
			var searchResults = repo.GetSalesBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual(18000, searchResults[0].TotalSales);
			Assert.AreEqual(1, searchResults[0].TotalVehicles);

		}
		[Test]
		public void CanSearchByToDate()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SalesSearchItem search = new SalesSearchItem();
			search.ToDate = DateTime.Parse("1/2/2018");
			var repo = SalesRepositoryFactory.GetRepository();
			var searchResults = repo.GetSalesBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual(22500, searchResults[0].TotalSales);
			Assert.AreEqual(1, searchResults[0].TotalVehicles);
		}
		[Test]
		public void CanSearchByQueryAndFromDate()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SalesSearchItem search = new SalesSearchItem();
			search.User = "Test";
			search.FromDate = DateTime.Parse("1/2/2018");
			var repo = SalesRepositoryFactory.GetRepository();
			var searchResults = repo.GetSalesBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual(18000, searchResults[0].TotalSales);
			Assert.AreEqual(1, searchResults[0].TotalVehicles);
		}
		[Test]
		public void CanSearchByQueryAndToDate()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SalesSearchItem search = new SalesSearchItem();
			search.User = "Test";
			search.ToDate = DateTime.Parse("1/2/2018");
			var repo = SalesRepositoryFactory.GetRepository();
			var searchResults = repo.GetSalesBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual(22500, searchResults[0].TotalSales);
			Assert.AreEqual(1, searchResults[0].TotalVehicles);
		}
		[Test]
		public void CanSearchByFromDateAndToDate()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SalesSearchItem search = new SalesSearchItem();
			search.ToDate = DateTime.Parse("12/31/2018");
			search.FromDate = DateTime.Parse("1/2/2018");
			var repo = SalesRepositoryFactory.GetRepository();
			var searchResults = repo.GetSalesBySearch(search);

			Assert.AreEqual(0, searchResults.Count);
		}
		[Test]
		public void CanSearchByAllParameters()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SalesSearchItem search = new SalesSearchItem();
			search.User = "test";
			search.ToDate = DateTime.Parse("1/2/2019");
			search.FromDate = DateTime.Parse("1/2/2018");
			var repo = SalesRepositoryFactory.GetRepository();
			var searchResults = repo.GetSalesBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual(18000, searchResults[0].TotalSales);
			Assert.AreEqual(1, searchResults[0].TotalVehicles);
		}
	}
}
