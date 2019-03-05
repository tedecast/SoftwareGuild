using System;
using FlooringMastery.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models.Interfaces;

namespace FlooringMastery.Data
{
	public class FileOrderRepository : IOrderRepository
	{
		private List<Order> _orders;
		private string _filePath;

		public List<Order> LoadFile()
		{
			_orders = new List<Order>();
			if (File.Exists(_filePath))
			{
				string[] rows = File.ReadAllLines(_filePath);


				for (int i = 1; i < rows.Length; i++)
				{
					string[] columns = rows[i].Split(',');

					Order a = new Order();
					a.OrderNumber = int.Parse(columns[0]);
					a.CustomerName = columns[1];
					a.State = columns[2];
					a.TaxRate = decimal.Parse(columns[3]);
					a.ProductType = columns[4];
					a.Area = decimal.Parse(columns[5]);
					a.CostPerSquareFoot = decimal.Parse(columns[6]);
					a.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
					a.MaterialCost = decimal.Parse(columns[8]);
					a.LaborCost = decimal.Parse(columns[9]);
					a.Tax = decimal.Parse(columns[10]);
					a.Total = decimal.Parse(columns[11]);
					a.OrderDate = _filePath.Substring(_filePath.Length - 12);
					a.OrderDate = a.OrderDate.Substring(0, 8);
					a.OrderDate = a.OrderDate.Substring(0, 2) + "/" + a.OrderDate.Substring(2, 2) + "/" + a.OrderDate.Substring(4);
					_orders.Add(a);
				}
			}
			return _orders;
		}

		public List<Order> LoadOrders(string orderDate)
		{
			_filePath = FindFilePath(orderDate);
			if (_filePath == null)
			{
				return null;
			}
			var _orders = LoadFile();

			return _orders;
		}

		public void NewOrder(Order order, string orderDate)
		{
			_filePath = Directory.GetCurrentDirectory() + "orders_" + orderDate;
			List<Order> orders = new List<Order>();
			orders.Add(order);
			CreateOrderFile(orders);
		}

		public string FindFilePath(string orderDate)
		{
			orderDate = orderDate.Replace(@"/", "");


			string fileEnd = $@"Orders_{orderDate}.txt";
			string fileName = Path.GetFullPath(fileEnd);
			fileName = fileName.Substring(0, fileName.Length - 33);
			fileName += ".Data\\" + fileEnd;

			return fileName;
		}

		public void SaveOrders(List<Order> orders)
		{ 
			CreateOrderFile(orders);
		}

		public void EditOrder(Order order, string orderDate)
		{
			var orders = LoadFile();
			int index = _orders.FindIndex(a => a.OrderNumber == order.OrderNumber);

			orders[index] = order;

			CreateOrderFile(orders);
		}
		public void AddOrder(Order order, string orderDate)
		{
			_filePath = FindFilePath(orderDate);

			if (_filePath == null)
			{
				NewOrder(order, orderDate);
			}

			else
			{
				using (StreamWriter sw = new StreamWriter(_filePath, true))
				{
					string line = CreateCsvForOrder(order);
					sw.WriteLine(line);
				}
			}
		}

		public bool Delete(int index, string orderDate)
		{
			var orders = LoadFile();

			orders.RemoveAt(index);
			CreateOrderFile(orders);
			return true;
		}

		private string CreateCsvForOrder(Order order)
		{
			return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate.ToString(), order.ProductType, order.Area.ToString(), order.CostPerSquareFoot.ToString(), order.LaborCostPerSquareFoot.ToString(), order.MaterialCost.ToString(), order.LaborCost.ToString(), order.Tax.ToString(), order.Total.ToString());
		}

		private void CreateOrderFile(List<Order> orders)
		{
			if (File.Exists(_filePath))
				File.Delete(_filePath);

			using (StreamWriter sr = new StreamWriter(_filePath))
			{
				sr.WriteLine("Order Number, Customer Name, State, Tax Rate, Product Type, Area, Cost Per Square Foot, Labor Cost Per Square Foot, Material Cost, Labor Cost, Tax, Total ");
				foreach (var order in orders)
				{
					sr.WriteLine(CreateCsvForOrder(order));
				}
			}
		}
	}
}
