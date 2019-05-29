using DvdLibrary.Data;
using DvdLibrary.Data.Interfaces;
using DvdLibrary.Factories;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DvdLibrary.Controllers
{
	public class DvdController : ApiController
	{
		[Route("dvds")]
		[AcceptVerbs("GET")]
		public IHttpActionResult SelectAll()
		{
			var repo = DvdRepositoryFactory.GetRepository();

			return Ok(repo.DvdSelectAll());
		}

		[Route("dvd/{id}")]
		[AcceptVerbs("GET")]
		public IHttpActionResult GetbyId(int id)
		{
			var repo = DvdRepositoryFactory.GetRepository();

			DvdListView dvd = repo.GetDvdById(id);

			if (dvd == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(dvd);
			}
		}

		[Route("dvds/title/{title}")]
		[AcceptVerbs("GET")]
		public IHttpActionResult GetByTitle(string title)
		{
			var repo = DvdRepositoryFactory.GetRepository();

			List<DvdListView> dvds = repo.GetDvdByTitle(title);

			if (dvds == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(dvds);
			}
		}

		[Route("dvds/year/{releaseYear}")]
		[AcceptVerbs("GET")]
		public IHttpActionResult GetByReleaseYear(int releaseYear)
		{
			var repo = DvdRepositoryFactory.GetRepository();

			List<DvdListView> dvds = repo.GetDvdByReleaseYear(releaseYear);

			if (dvds == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(dvds);
			}
		}

		[Route("dvds/director/{directorName}")]
		[AcceptVerbs("GET")]
		public IHttpActionResult GetByDirectorName(string directorName)
		{
			var repo = DvdRepositoryFactory.GetRepository();

			List<DvdListView> dvds = repo.GetDvdByDirectorName(directorName);

			if (dvds == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(dvds);
			}
		}

		[Route("dvds/rating/{rating}")]
		[AcceptVerbs("GET")]
		public IHttpActionResult GetByRating(string rating)
		{
			var repo = DvdRepositoryFactory.GetRepository();

			List<DvdListView> dvds = repo.GetDvdByRating(rating);

			if (dvds == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(dvds);
			}
		}

		public int DvdId(string ratingName)
		{
			switch (ratingName)
			{
				case "G":
					return 1;
				case "PG":
					return 2;
				case "PG-13":
					return 3;
				default:
					return 4;
			}
		}

		[Route("dvd")]
		[AcceptVerbs("POST")]
		public IHttpActionResult Add(DvdListView newDvd)
		{
			var repo = DvdRepositoryFactory.GetRepository();

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Dvd dvd = new Dvd()
			{
				Title = newDvd.Title,
				ReleaseYear = newDvd.ReleaseYear,
				RatingId = DvdId(newDvd.Rating),
				Director = newDvd.Director,
				Notes = newDvd.Notes
			};

			repo.DvdInsert(dvd);
			return Created($"dvds/get/{dvd.DvdId}", dvd);
		}

		[Route("dvd/{id}")]
		[AcceptVerbs("PUT")]
		public IHttpActionResult UpdateDvd(DvdListView updatedDvd)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			Dvd dvd = new Dvd()
			{
				DvdId = updatedDvd.DvdId,
				Title = updatedDvd.Title,
				ReleaseYear = updatedDvd.ReleaseYear,
				RatingId = DvdId(updatedDvd.Rating),
				Director = updatedDvd.Director,
				Notes = updatedDvd.Notes
			};
			var repo = DvdRepositoryFactory.GetRepository();
			repo.DvdEdit(dvd);
			
				return Ok(HttpStatusCode.OK);
		}

		[Route("dvd/{id}")]
		[AcceptVerbs("DELETE")]
		public IHttpActionResult Delete(int id)
		{
			var repo = DvdRepositoryFactory.GetRepository();
			DvdListView dvd = repo.GetDvdById(id);

			if (dvd == null)
			{
				return NotFound();
			}

			repo.DvdDelete(id);
			return Ok();
		}
	}
}