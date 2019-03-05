using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
	public class TestOrderRepository : IOrderRepository
	{
		private static List<Order> _orders = new List<Order>
		{
			new Order
			{
				
				OrderNumber = 1,
				CustomerName = "John",
				State = "OH",
				TaxRate = 6,
				ProductType = "Carpet",
				Area = 150,
				CostPerSquareFoot = 5,
				LaborCostPerSquareFoot = 10,
			},
			new Order 
			{
				OrderNumber = 2,
				CustomerName = "Greg",
				State = "MI",
				TaxRate = 5.75M,
				ProductType = "Carpet",
				Area = 600,
				CostPerSquareFoot = 9,
				LaborCostPerSquareFoot = 100,
			}
		};
		public List<Order> LoadOrders(string orderDate)
		{
			return _orders;
		}

		public void SaveOrders(List<Order> orders)
		{
			_orders = orders;
		}

		public void EditOrder(Order order, string orderDate)
		{
			_orders.Add(order);
		}

		public void NewOrder(Order order, string orderDate)
		{
			_orders.Add(order);
		}
	}
}
