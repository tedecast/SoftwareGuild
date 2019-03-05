using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Tests
{
	public class FlooringMasteryTests
	{
		[TestFixture]
		public class OrderTests
		{
			[Test]
			public void CanLoadOrderTestData()
			{
				OrderManager manager = OrderManagerFactory.Create();

				Response response = manager.LookupOrder("06/01/2019");

				Assert.IsNotNull(response.Orders);
				Assert.IsTrue(response.Success);
				Assert.AreEqual("John", response.Orders[0].CustomerName);
			}

			[TestCase("06/01/2019", "Jeremy", "OH", "Wood", 250, true)]
			[TestCase("06/01/2000", "Jeremy", "OH", "Wood", 250, false)]
			[TestCase("06/01/2019", "+++", "OH", "Wood", 250, false)]
			[TestCase("06/01/2019", "Jeremy", "CA", "Wood", 250, false)]
			[TestCase("06/01/2019", "Jeremy", "OH", "Chuck", 250, false)]
			[TestCase("06/01/2019", "Jeremy", "OH", "Wood", 50, false)]
			public void OrderAddRulesTest(string orderDate, string customerName, string state, string userProduct, decimal userArea, bool expectedResult)
			{
				OrderManager manager = OrderManagerFactory.Create();
				Response response = new Response();
				Order order = new Order();
				Directory.SetCurrentDirectory(@"\\\\Mac\\Home\\Desktop\\SoftwareGuild\\Bitbucket\\jeremy-wakefield-individual-work\\Flooring Mastery\\FlooringMastery\\FlooringMastery.UI\\bin\\Debug\\");

				response.Date = orderDate;
				order.CustomerName = customerName;
				order.State = state;
				order.ProductType = userProduct;
				order.Area = userArea;

				response.order = order;
				response = OrderAddRules.UserAddInput(orderDate, response);
				Assert.AreEqual(expectedResult, response.Success);
			}

			[TestCase("06/01/2019", "Jeremy", "OH", "Wood", 250, true)]
			[TestCase("06/01/2019", "+++", "OH", "Wood", 250, false)]
			[TestCase("06/01/2019", "Jeremy", "CA", "Wood", 250, false)]
			[TestCase("06/01/2019", "Jeremy", "OH", "Chuck", 250, false)]
			[TestCase("06/01/2019", "Jeremy", "OH", "Wood", 50, false)]
			public void OrderEditRulesTest(string orderDate, string customerName, string state, string userProduct, decimal userArea, bool expectedResult)
			{
				OrderManager manager = OrderManagerFactory.Create();
				Response response = new Response();
				Order order = new Order();
				Directory.SetCurrentDirectory(@"\\\\Mac\\Home\\Desktop\\SoftwareGuild\\Bitbucket\\jeremy-wakefield-individual-work\\Flooring Mastery\\FlooringMastery\\FlooringMastery.UI\\bin\\Debug\\");

				response.Date = orderDate;
				order.CustomerName = customerName;
				order.State = state;
				order.ProductType = userProduct;
				order.Area = userArea;

				response.order = order;
				response = OrderEditRules.UserEditInput(response);
				Assert.AreEqual(expectedResult, response.Success);
			}

			[TestCase("06/01/2019", 1, true)]
			[TestCase("06/01/2019", 100, false)]
			public void OrderDeleteTest(string orderDate, int orderNumber, bool expectedResult)
			{
				OrderManager manager = OrderManagerFactory.Create();
				Response response = new Response();
				Order order = new Order();
				response = manager.LookupOrder(orderDate);
				if (response.Orders == null)
				{
					response.Success = false;
					Assert.AreEqual(expectedResult, response.Success);
				}
				else
				{
					Directory.SetCurrentDirectory(@"\\\\Mac\\Home\\Desktop\\SoftwareGuild\\Bitbucket\\jeremy-wakefield-individual-work\\Flooring Mastery\\FlooringMastery\\FlooringMastery.UI\\bin\\Debug\\");


					response.Success = manager.DeleteOrder(response.Orders, orderNumber);
					Assert.AreEqual(expectedResult, response.Success);
				}
			}
		}
	}
}
