using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.UI.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
	public class AdminViewModelAdd : IValidatableObject
	{
		public Vehicle Vehicle { get; set; }
		public List<SelectListItem> Make { get; set; }
		public List<SelectListItem> Model { get; set; }
		public List<SelectListItem> Type { get; set; }
		public List<SelectListItem> BodyStyle { get; set; }
		public List<SelectListItem> Transmission { get; set; }
		public List<SelectListItem> Color { get; set; }
		public List<SelectListItem> Interior { get; set; }
		public HttpPostedFileBase ImageUpload { get; set; }


		public AdminViewModelAdd()
		{
			Vehicle = new Vehicle();
			Make = new List<SelectListItem>();
			Model = new List<SelectListItem>();
			Type = new List<SelectListItem>();
			BodyStyle = new List<SelectListItem>();
			Transmission = new List<SelectListItem>();
			Color = new List<SelectListItem>();
			Interior = new List<SelectListItem>();
		}

		public void Populate()
		{
			List<MakeItem> makes = VehicleRepositoryFactory.GetRepository().GetMakeItems();
			List<ModelItem> models = VehicleRepositoryFactory.GetRepository().GetModelItems();
			for (int i = 0; i < makes.Count; i++)
			{
				var makeItem = new SelectListItem { Value = (makes[i].MakeId).ToString(), Text = makes[i].MakeName.ToString() };
				Make.Add(makeItem);
			}

			for (int i = 0; i < models.Count; i++)
			{
				var modelItem = new SelectListItem { Value = (models[i].MakeId).ToString(), Text = models[i].ModelName.ToString() };
				Model.Add(modelItem);
			}

			Type.Add(new SelectListItem { Value = "1", Text = "New" });
			Type.Add(new SelectListItem { Value = "2", Text = "Used" });

			BodyStyle.Add(new SelectListItem { Value = "1", Text = "Car" });
			BodyStyle.Add(new SelectListItem { Value = "2", Text = "SUV" });
			BodyStyle.Add(new SelectListItem { Value = "3", Text = "Truck" });
			BodyStyle.Add(new SelectListItem { Value = "4", Text = "Van" });

			Transmission.Add(new SelectListItem { Value = "1", Text = "Automatic" });
			Transmission.Add(new SelectListItem { Value = "2", Text = "Manual" });

			Color.Add(new SelectListItem { Value = "1", Text = "Black" });
			Color.Add(new SelectListItem { Value = "2", Text = "White" });
			Color.Add(new SelectListItem { Value = "3", Text = "Grey" });
			Color.Add(new SelectListItem { Value = "4", Text = "Red" });
			Color.Add(new SelectListItem { Value = "5", Text = "Beige" });

			Interior.Add(new SelectListItem { Value = "1", Text = "Black" });
			Interior.Add(new SelectListItem { Value = "2", Text = "White" });
			Interior.Add(new SelectListItem { Value = "3", Text = "Red" });
			Interior.Add(new SelectListItem { Value = "4", Text = "Leather - Black" });
			Interior.Add(new SelectListItem { Value = "5", Text = "Leather - Tan" });


		}
		public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			List<ValidationResult> errors = new List<ValidationResult>();

			if (Vehicle.TypeId == 1 && Vehicle.Mileage > 1000)
			{
				errors.Add(new ValidationResult("Mileage must be less than 1000 for a car to be new."));
			}
			if (Vehicle.SalePrice <= 0 || Vehicle.MSRP <= 0)
			{
				errors.Add(new ValidationResult("Price values must be positive."));
			}
			if (string.IsNullOrEmpty(Vehicle.Description))
			{
				errors.Add(new ValidationResult("Vehicle must have a description."));
			}
			if (string.IsNullOrEmpty(Vehicle.VIN))
				errors.Add(new ValidationResult("VIN is a required field"));

			if (ImageUpload != null && ImageUpload.ContentLength > 0)
			{
				var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg", "jpg" };
				var extension = Path.GetExtension(ImageUpload.FileName);

				if (!extensions.Contains(extension))
				{
					errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg."));
				}
			}
			else
			{
				errors.Add(new ValidationResult("Image is required to add a vehicle."));

			}

			return errors;
		}

	}
}