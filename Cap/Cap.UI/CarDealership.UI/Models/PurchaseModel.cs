using CarDealership.Models.Queries;
using CarDealership.UI.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
	public class PurchaseModel : IValidatableObject
	{
		public int SaleId { get; set; }
		public string UserId { get; set; }
		public int PurchasePrice { get; set; }
		public int PurchaseTypeId { get; set; }
		public int VehicleId { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public string Zipcode { get; set; }
		public DateTime DateSold { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			VehicleItem vehicle = VehicleRepositoryFactory.GetRepository().GetVehicleItemById(VehicleId);

			List<ValidationResult> errors = new List<ValidationResult>();
			if (string.IsNullOrEmpty(Name))
			{
				errors.Add(new ValidationResult("Name is required."));
			}
			if (PurchasePrice <= 0)
			{
				errors.Add(new ValidationResult("Purchase Price is to be greater than 0."));
			}
			if (PurchasePrice > vehicle.MSRP)
			{
				errors.Add(new ValidationResult("Purchase Price cannot be greater than MSRP."));
			}
			if (PurchasePrice > 0)
			{
				if ((PurchasePrice / vehicle.SalePrice) * 100 < 94)
				{
					errors.Add(new ValidationResult("Purchase Price cannot be less than 95% of Sale Price."));

				}
			}

			if (string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(Email))
			{
				errors.Add(new ValidationResult("Phone or Email is required"));
			}
			if (string.IsNullOrEmpty(Street1))
			{
				errors.Add(new ValidationResult("Street1 is required"));
			}
			if (string.IsNullOrEmpty(City))
			{
				errors.Add(new ValidationResult("City is required"));
			}
			if (string.IsNullOrEmpty(Zipcode))
			{
				errors.Add(new ValidationResult("Zipcode is required"));
			}
			return errors;
		}
	}
}
