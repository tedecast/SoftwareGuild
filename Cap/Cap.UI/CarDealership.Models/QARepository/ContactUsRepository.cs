using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepository
{
	public class ContactUsRepository : IContactUsRepository
	{
		
		private List<ContactUs> _contactUsTable  =  new List<ContactUs>()
		{
			new ContactUs
			{
				ContactUsId = 1,
				Name = "Charles",
				Phone = "1111111111",
				Email = "charles@gmail.com",
				Message = "What are your hours on weekends?"
			},
			new ContactUs
			{
				ContactUsId = 2,
				Name = "Thomas",
				Phone = "222222222",
				Email = "Thomas@gmail.com",
				Message = "Can I test drive a vehicle this next Wednesday?"
			},
		};

		public void AddContactUs(ContactUs item)
		{
			_contactUsTable.Add(item);
		}

		public List<ContactUs> GetAllContactUs()
		{
			return _contactUsTable;
		}
	}
}
