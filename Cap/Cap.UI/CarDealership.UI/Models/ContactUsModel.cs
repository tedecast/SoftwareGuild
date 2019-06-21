using CarDealership.Models.Tables;
using System;
using System.Activities.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace CarDealership.UI.Models
{
	public class ContactUsModel : IValidatableObject
	{
		public int ContactUsId { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Message { get; set; }
		public string VIN { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			List<ValidationResult> errors = new List<ValidationResult>();
			if (string.IsNullOrEmpty(Name))
			{
				errors.Add(new ValidationResult("Name is required"));
			}
			if (string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(Email))
			{
				errors.Add(new ValidationResult("Phone or Email is required"));
			}
			if (string.IsNullOrEmpty(Message))
			{
				errors.Add(new ValidationResult("Message is required"));
			}
			return errors;
		}
	}
}