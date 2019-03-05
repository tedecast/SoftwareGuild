using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
	public class OrderManager
	{
		private IOrderRepository _orderRepository;

		public OrderManager(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public Response LookupOrder(string orderDate)
		{
			Response response = new Response();

			response.Orders = _orderRepository.LoadOrders(orderDate);

			if (response.Orders.Count == 0)
			{
				response.Success = false;
				response.Message = $"{orderDate} does not exist.";
			}
			else { response.Success = true; }

			return response;
		}
		
		/* look for file extension. If it doesn't exist. Create a new one. */
		public void AddOrder(Response response, string orderDate)
		{
			Response addResponse = new Response();
			addResponse.Orders = _orderRepository.LoadOrders(orderDate);

			if (addResponse.Orders == null)
			{
				addResponse.Orders = _orderRepository.LoadOrders(orderDate);
			}

			response.order.OrderNumber = addResponse.Orders.Count;
			addResponse.Orders.Add(response.order);
			_orderRepository.SaveOrders(addResponse.Orders);
		}

		public Response EditOrder(List<Order> orders, int orderNumber)
		{
			Response editOrderResponse = new Response();
			editOrderResponse.Orders = orders;
			editOrderResponse.order = orders[orderNumber];
			editOrderResponse.order.OrderNumber = orderNumber + 1;

			editOrderResponse = OrderEditRules.UserEditInput(editOrderResponse);

			if (editOrderResponse.Success)
			{
				_orderRepository.SaveOrders(editOrderResponse.Orders);
			}

			return editOrderResponse;
		}

		public bool DeleteOrder(List<Order> orders, int orderNumber)
		{
			orderNumber--;
			if (orderNumber <= orders.Count)
			{
				orders.RemoveAt(orderNumber);
				_orderRepository.SaveOrders(orders);
				return true;
			}
			else
			{
				return false;
			}
		}

		public static List<Taxes> LoadTaxes()
		{
			TaxesRepository taxesRepo = new TaxesRepository();
			List<Taxes> taxes = new List<Taxes>();
			taxes = taxesRepo.LoadTaxes();

			return taxes;
		}

		public static List<Products> LoadProducts()
		{
			ProductsRepository productsRepo = new ProductsRepository();
			List<Products> products = new List<Products>();
			products = productsRepo.LoadProducts();

			return products;
		}
	}
}
