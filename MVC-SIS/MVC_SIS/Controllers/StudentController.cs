using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new AddStudentViewModel();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(AddStudentViewModel viewModel)
        {
			if (ModelState.IsValid)
			{
				viewModel.Student.Courses = new List<Course>();

				foreach (var id in viewModel.SelectedCourseId)
					viewModel.Student.Courses.Add(CourseRepository.Get(id));

				viewModel.Student.Major = MajorRepository.Get(viewModel.MajorId);
				viewModel.Student.FirstName = viewModel.FirstName;
				viewModel.Student.LastName = viewModel.LastName;
				viewModel.Student.GPA = viewModel.GPA;

				StudentRepository.Add(viewModel.Student);
				return RedirectToAction("List");
			}
			else
			{
				viewModel.SetCourseItems(CourseRepository.GetAll());
				viewModel.SetMajorItems(MajorRepository.GetAll());
				return View(viewModel);
			}
        }

		[HttpGet]
		public ActionResult Edit(int id)
		{

			var student = StudentRepository.Get(id);
			var viewModel = new EditStudentViewModel();

			viewModel.MajorId = student.Major.MajorId;
			viewModel.Student.StudentId = student.StudentId;
			viewModel.FirstName = student.FirstName;
			viewModel.LastName = student.LastName;
			viewModel.GPA = student.GPA;

			viewModel.Street1 = student.Address.Street1;
			viewModel.Street2 = student.Address.Street2;
			viewModel.City = student.Address.City;
			viewModel.PostalCode = student.Address.PostalCode;
			viewModel.StateName = student.Address.State.StateName;
			viewModel.StateAbbreviation = student.Address.State.StateAbbreviation;

			viewModel.SetStateItems(StateRepository.GetAll());
			viewModel.SetCourseItems(CourseRepository.GetAll());
			viewModel.SetMajorItems(MajorRepository.GetAll());
			viewModel.SelectedCourseId = student.Courses.Select(m => m.CourseId).ToList();
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(EditStudentViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				viewModel.Student.Courses = new List<Course>();
				viewModel.Student.Address = new Address();
				viewModel.Student.Address.State = new State();

				viewModel.Student.Major = MajorRepository.Get(viewModel.MajorId);
				viewModel.Student.FirstName = viewModel.FirstName;
				viewModel.Student.LastName = viewModel.LastName;
				viewModel.Student.GPA = viewModel.GPA;
				viewModel.Student.Address.Street1 = viewModel.Street1;
				viewModel.Student.Address.Street2 = viewModel.Street2;
				viewModel.Student.Address.City = viewModel.City;
				viewModel.Student.Address.State.StateName = viewModel.StateName;
				viewModel.Student.Address.State.StateAbbreviation = viewModel.StateAbbreviation;
				viewModel.Student.Address.PostalCode = viewModel.PostalCode;

				StudentRepository.Edit(viewModel.Student);
				StudentRepository.SaveAddress(viewModel.Student.StudentId, viewModel.Student.Address);

				foreach (var id in viewModel.SelectedCourseId)
					viewModel.Student.Courses.Add(CourseRepository.Get(id));
				return RedirectToAction("List");
			}
			else
			{
				viewModel.SetCourseItems(CourseRepository.GetAll());
				viewModel.SetMajorItems(MajorRepository.GetAll());
				viewModel.SetStateItems(StateRepository.GetAll());

				return View(viewModel);
			}


		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var state = StudentRepository.Get(id);
			return View(state);
		}

		[HttpPost]
		public ActionResult Delete(Student student)
		{
			StudentRepository.Delete(student.StudentId);
			return RedirectToAction("List");
		}
	}
}