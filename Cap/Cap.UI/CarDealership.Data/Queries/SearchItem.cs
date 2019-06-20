using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
	public class SearchItem
	{
		public string SearchTerm { get; set; }
		public int ?MinPrice { get; set; }
		public int ?MaxPrice { get; set; }
		public int ?MinYear { get; set; }
		public int ?MaxYear { get; set; }
	}
}
