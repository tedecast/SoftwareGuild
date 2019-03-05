using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
	public class ProductsRepository
	{
		private List<Products> _products;

		public List<Products> LoadProducts()
		{
			_products = new List<Products>();

			string fileEnd = @"Products.txt";
			string fileName = Path.GetFullPath(fileEnd);
			fileName = fileName.Substring(0, fileName.Length - 26);
			fileName += ".Data\\" + fileEnd;
			string[] rows = File.ReadAllLines(fileName);

			for (int i = 1; i < rows.Length; i++)
			{
				string[] columns = rows[i].Split(',');

				Products a = new Products();
				a.productType = columns[0];
				a.costPerSquareFoot = decimal.Parse(columns[1]);
				a.laborCostPerSquareFoot = decimal.Parse(columns[2]);

				_products.Add(a);
			}
			return _products;
		}

	}
}
