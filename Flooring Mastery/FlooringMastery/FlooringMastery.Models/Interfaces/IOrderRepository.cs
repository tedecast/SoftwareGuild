using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
	public interface IOrderRepository
	{
		/* Load, save*/
		List<Order> LoadOrders(string orderDate);
		void EditOrder(Order order, string orderDate);
		void SaveOrders(List<Order> order);
		void NewOrder(Order order, string orderDate);
	}
}
