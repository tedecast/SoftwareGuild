using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models
{
	public class Dvd
	{
		public int DvdId { get; set; }
		public string Title { get; set; }
		public int ReleaseYear { get; set; }
		public int RatingId { get; set; }
		public string Director { get; set; }
		public string Notes { get; set; }
	}
}
