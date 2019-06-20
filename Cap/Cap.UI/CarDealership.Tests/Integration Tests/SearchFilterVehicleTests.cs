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
	class SearchFilterVehicleTests
	{
		[Test]
		public void CanSearchByNoParameters()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(4, searchResults.Count);
		}

		[Test]
		public void CanSearchByQuery()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.SearchTerm = "fo";
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
			Assert.AreEqual("Forester", searchResults[1].ModelName);
		}
		[Test]
		public void CanSearchByMinPrice()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinPrice = 15000;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
		}
		[Test]
		public void CanSearchByMaxPrice()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MaxPrice = 15000;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
		}
		[Test]
		public void CanSearchByMinYear()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinYear = 2015;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
		}
		[Test]
		public void CanSearchByMaxYear()
		{

			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MaxYear = 2015;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(3, searchResults.Count);
		}
		[Test]
		public void CanSearchByQueryAndMinPrice()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.SearchTerm = "fo";
			search.MinPrice = 18000;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
		}
		[Test]
		public void CanSearchByQueryAndMaxPrice()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.SearchTerm = "fo";
			search.MaxPrice = 17000;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual("Subaru", searchResults[0].MakeName);
		}

		[Test]
		public void CanSearchByQueryAndMinYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.SearchTerm = "fo";
			search.MinYear = 2015;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
		}

		[Test]
		public void CanSearchByQueryAndMaxYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.SearchTerm = "fo";
			search.MaxYear = 2015;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
			Assert.AreEqual("Subaru", searchResults[1].MakeName);
		}
		[Test]
		public void CanSearchByMinAndMaxPrice()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinPrice = 12000;
			search.MaxPrice = 18000;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(3, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
			Assert.AreEqual("Subaru", searchResults[1].MakeName);
			Assert.AreEqual("Subaru", searchResults[2].MakeName);

		}
		[Test]
		public void CanSearchByMinYearAndMinPrice()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinYear = 2015;
			search.MinPrice = 18000;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
			Assert.AreEqual("Kia", searchResults[0].MakeName);
			Assert.AreEqual("Ford", searchResults[1].MakeName);
		}
		[Test]
		public void CanSearchByMinPriceAndMaxYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MaxYear = 2015;
			search.MinPrice = 14000;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
			Assert.AreEqual("Subaru", searchResults[1].MakeName);
		}
		[Test]
		public void CanSearchByMaxPriceAndMinYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MaxPrice = 18000;
			search.MinYear = 2011;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(3, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
			Assert.AreEqual("Subaru", searchResults[1].MakeName);
			Assert.AreEqual("Subaru", searchResults[2].MakeName);
		}
		[Test]
		public void CanSearchByMaxYearAndMaxPrice()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MaxPrice = 18000;
			search.MaxYear = 2015;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(3, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
			Assert.AreEqual("Subaru", searchResults[1].MakeName);
			Assert.AreEqual("Subaru", searchResults[2].MakeName);
		}
		[Test]
		public void CanSearchByMinYearAndMaxYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinYear = 2011;
			search.MaxYear = 2015;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(3, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
			Assert.AreEqual("Subaru", searchResults[1].MakeName);
			Assert.AreEqual("Subaru", searchResults[2].MakeName);
		}
		[Test]
		public void CanSearchByQueryAndMinPriceAndMaxPrice()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinPrice = 13000;
			search.MaxPrice = 18000;
			search.SearchTerm = "ford";
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
		}
		[Test]
		public void CanSearchMinYearAndMinPriceAndMaxPrice()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinYear = 2015;
			search.MinPrice = 12000;
			search.MaxPrice = 25000;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
			Assert.AreEqual("Kia", searchResults[0].MakeName);
			Assert.AreEqual("Ford", searchResults[1].MakeName);
		}
		[Test]
		public void CanSearchMinPriceAndMinYearAndMaxYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinYear = 2015;
			search.MinPrice = 12000;
			search.MaxYear = 2019;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
			Assert.AreEqual("Kia", searchResults[0].MakeName);
			Assert.AreEqual("Ford", searchResults[1].MakeName);
		}
		[Test]
		public void CanSearchMaxPriceAndMinYearAndMaxYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinYear = 2015;
			search.MaxPrice = 20000;
			search.MaxYear = 2019;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
		}

		[Test]
		public void CanSearchMinPriceAndMaxPriceAndMinYearAndMaxYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.MinPrice = 12000;
			search.MaxPrice = 20000;
			search.MinYear = 2015;
			search.MaxYear = 2019;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual("Ford", searchResults[0].MakeName);
		}

		[Test]
		public void CanSearchByQueryAndMaxPriceAndMinYearAndMaxYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.SearchTerm = "subaru";
			search.MaxPrice = 20000;
			search.MinYear = 2015;
			search.MaxYear = 2019;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(0, searchResults.Count);

		}
		[Test]
		public void CanSearchByQueryAndMinPriceAndMinYearAndMaxYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.SearchTerm = "subaru";
			search.MinPrice = 10000;
			search.MinYear = 2010;
			search.MaxYear = 2019;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
			Assert.AreEqual("Forester", (searchResults.Where(x => x.ModelName == "Forester").ToList()[0].ModelName));
			Assert.AreEqual("Outback", (searchResults.Where(x => x.ModelName == "Outback").ToList()[0].ModelName));
		}
		[Test]
		public void CanSearchByQueryAndMinPriceAndMaxPriceAndMaxYear()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.SearchTerm = "subaru";
			search.MinPrice = 10000;
			search.MaxPrice = 13000;
			search.MinYear = 2010;
			search.MaxYear = 2019;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(1, searchResults.Count);
			Assert.AreEqual("Outback", searchResults[0].ModelName);
		}
		[Test]
		public void CanSearchByQueryAndMinYearAndMinPriceAndMaxPrice()
		{
			var reset = new DataResetRepository();
			reset.ResetData();

			SearchItem search = new SearchItem();
			search.SearchTerm = "subaru";
			search.MinPrice = 10000;
			search.MaxPrice = 15000;
			search.MinYear = 2010;
			var repo = VehicleRepositoryFactory.GetRepository();
			var searchResults = repo.GetVehicleBySearch(search);

			Assert.AreEqual(2, searchResults.Count);
			Assert.AreEqual("Forester", (searchResults.Where(x => x.ModelName == "Forester").ToList()[0].ModelName));
			Assert.AreEqual("Outback", (searchResults.Where(x => x.ModelName == "Outback").ToList()[0].ModelName));
		}
	}
}
