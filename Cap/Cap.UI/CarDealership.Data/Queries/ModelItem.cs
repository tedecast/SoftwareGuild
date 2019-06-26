using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
	public class ModelItem
	{
		public string MakeName { get; set; }
		public string ModelName { get; set; }
		public DateTime DateAdded { get; set; }
		public string UserId { get; set; }
		public int MakeId { get; set; }
		public int ModelId { get; set; }
	}
}
