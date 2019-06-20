using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepository
{
	public class SpecialsRepository : ISpecialsRepository
	{
		private List<Special> _specials = new List<Special>()
		{
			new Special
			{
				SpecialId = 1,
				SpecialTitle = "Labor Day Sale",
				SpecialDescription = "15% Off All New Cars!"
			},
			new Special
			{
				SpecialId = 2,
				SpecialTitle = "Auction Bid Day",
				SpecialDescription = "Come bid on the largest selection of used vehicles!"
			},
			new Special
			{
				SpecialId = 3,
				SpecialTitle = "New Selection of Luxury Vehicles!",
				SpecialDescription = "Come check out the latest from Tesla, Audi, BMW and More!"
			},
		};
		public void AddSpecial(Special s)
		{
			_specials.Add(s);
		}

		public void DeleteSpecial(int id)
		{
			_specials.RemoveAll(s => s.SpecialId == id);
		}

		public List<Special> GetAllSpecials()
		{
			return _specials;
		}
	}
}
