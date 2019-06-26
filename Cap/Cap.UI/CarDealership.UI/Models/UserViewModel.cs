using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
	public class UserViewModel : IValidatableObject
	{
		public ApplicationUser User { get; set; }
		public IEnumerable<SelectListItem> Roles { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			List<ValidationResult> errors = new List<ValidationResult>();

			if (string.IsNullOrEmpty(User.FirstName))
			{
				errors.Add(new ValidationResult("First name is required."));
			}
			if (string.IsNullOrEmpty(User.LastName))
			{
				errors.Add(new ValidationResult("Last name is required."));
			}
			if (string.IsNullOrEmpty(User.UserName))
			{
				errors.Add(new ValidationResult("Email is required."));
			}
			if (string.IsNullOrEmpty(User.PasswordHash))
			{
				errors.Add(new ValidationResult("Password is required."));
			}

			return errors;
		}
	}
}