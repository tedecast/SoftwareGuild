using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.ViewModels
{
	public class AddStudentViewModel : StudentVM
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
	}
}