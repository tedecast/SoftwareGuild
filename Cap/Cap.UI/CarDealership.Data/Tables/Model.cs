﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
	public class Model
	{
		public int ModelId { get; set; }
		public int MakeId { get; set; }
		public string ModelName { get; set; }
		public string Id { get; set; }
		public DateTime DateAdded { get; set; }
	}
}
