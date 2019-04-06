using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.ViewModels
{
	public class EditStudentViewModel : StudentVM
	{
		[Required(ErrorMessage = "Please enter the student's major")]
		public int MajorId { get; set; }
		[Required(ErrorMessage = "Please enter the student's first name")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Please enter the student's last name")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Please enter the student's GPA")]
		public decimal GPA { get; set; }
		[Required(ErrorMessage = "Please register for a course")]
		public List<int> SelectedCourseId { get; set; }

		[Required(ErrorMessage = "Please enter your street address")]
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		[Required(ErrorMessage = "Please enter your city")]
		public string City { get; set; }
		[Required(ErrorMessage = "Please enter your state name")]
		public string StateName { get; set; }
		[Required(ErrorMessage = "Please enter your state abbreviation")]
		public string StateAbbreviation { get; set; }
		[Required(ErrorMessage = "Please enter your postal code")]
		public string PostalCode { get; set; }





}
}