using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
	public class TaxesRepository
	{
		private List<Taxes> _taxRates;

		public List<Taxes> LoadTaxes()
		{
			_taxRates = new List<Taxes>();
			string fileEnd = @"Taxes.txt";
			string fileName = Path.GetFullPath(fileEnd);
			fileName = fileName.Substring(0, fileName.Length - 23);
			fileName += ".Data\\" + fileEnd;
			string[] rows = File.ReadAllLines(fileName);


			for (int i = 1; i < rows.Length; i++)
			{
				string[] columns = rows[i].Split(',');

				Taxes a = new Taxes();
				a.stateAbbreviation = columns[0];
				a.stateName = columns[1];
				a.taxRate = decimal.Parse(columns[2]);

				_taxRates.Add(a);
			}
			return _taxRates;
		}

	}
}
