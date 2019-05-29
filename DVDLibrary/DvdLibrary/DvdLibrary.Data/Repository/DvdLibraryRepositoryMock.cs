using DvdLibrary.Data.Interfaces;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data
{
	public class DvdLibraryRepositoryMock : IDvdLibraryRepository
	{

		private static List<Rating> _ratings = new List<Rating>()
		{
			new Rating{ RatingId = 1, RatingName = "G"},
			new Rating{ RatingId = 2, RatingName = "PG"},
			new Rating{ RatingId = 3, RatingName = "PG-13"},
			new Rating{ RatingId = 4, RatingName = "R"},
		};

		private static List<Dvd> _dvds = new List<Dvd>()
		{
			new Dvd
			{
				DvdId = 1,
				Title = "The Shawshank Redemption",
				ReleaseYear= 1994,
				Director =  "Frank Darabont",
				RatingId = 4,
				Notes = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency"
			},
			new Dvd
			{
				DvdId = 2,
				Title = "The Godfather",
				ReleaseYear= 1972,
				Director =  "Francis Ford Coppola",
				RatingId = 4,
				Notes = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
			},
			new Dvd
			{
				DvdId = 3,
				Title = "The Dark Knight",
				ReleaseYear= 2008,
				Director = "Christopher Nolan",
				RatingId = 3,
				Notes = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham."
			}
		};
		/*private static List<DvdListView> _dvdsListView = new List<DvdListView>()
		{
			new DvdListView
			{
				DvdId = 1,
				Title = "The Shawshank Redemption",
				ReleaseYear= 1994,
				Director =  "Frank Darabont",
				Rating = "R",
				Notes = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency"
			},
			new DvdListView
			{
				DvdId = 2,
				Title = "The Godfather",
				ReleaseYear= 1972,
				Director =  "Francis Ford Coppola",
				Rating = "R",
				Notes = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
			},
			new DvdListView
			{
				DvdId = 3,
				Title = "The Dark Knight",
				ReleaseYear= 2008,
				Director =  "Chrsitopher Nolan",
				Rating = "Pg-13",
				Notes = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham."
			}
		};*/

		public List<DvdListView> GetAllDvdsToListView()
		{

				    var listView = from dvd in _dvds
					join rating in _ratings on dvd.RatingId equals rating.RatingId
					select new DvdListView { DvdId = dvd.DvdId, Director = dvd.Director, Notes = dvd.Notes, Rating = rating.RatingName, ReleaseYear = dvd.ReleaseYear, Title = dvd.Title };
		
				return listView.ToList();
		}

		public List<DvdListView> DvdToListViewSelect(IEnumerable<Dvd> movies)
		{

				var listView = from dvd in _dvds
							   join rating in _ratings on dvd.RatingId equals rating.RatingId
							   join movie in movies on dvd.DvdId equals movie.DvdId
							   where dvd.DvdId == movie.DvdId
							   select new DvdListView { DvdId = dvd.DvdId, Director = dvd.Director, Notes = dvd.Notes, Rating = rating.RatingName, ReleaseYear = dvd.ReleaseYear, Title = dvd.Title };


			return listView.ToList();
		}

		public void DvdDelete(int id)
		{
			_dvds.RemoveAll(d => d.DvdId == id);
		}

		public void DvdEdit(Dvd dvd)
		{
			foreach (var editDvd in _dvds.Where(d => d.DvdId== dvd.DvdId))
			{
				editDvd.Title = dvd.Title;
				editDvd.ReleaseYear = dvd.ReleaseYear;
				editDvd.Director = dvd.Director;
				editDvd.RatingId = dvd.RatingId;
				editDvd.Notes = dvd.Notes;
			}
		}

		public void DvdInsert(Dvd dvd)
		{
			_dvds.Add(dvd);
		}

		public List<DvdListView> DvdSelectAll()
		{
			return GetAllDvdsToListView();
		}

		public List<DvdListView> GetDvdByDirectorName(string name)
		{
			var match = from dvd in _dvds
						where dvd.Director == name
						select (dvd);

			return DvdToListViewSelect(match);
		}

		public DvdListView GetDvdById(int id)
		{
			var match = from dvd in _dvds
						where dvd.DvdId == id
						select (dvd);

			return DvdToListViewSelect(match)[0];

		}

		public List<DvdListView> GetDvdByRating(string strRating)
		{
			var match = from dvd in _dvds
						join rating in _ratings on strRating equals rating.RatingName
						where dvd.RatingId == rating.RatingId
						select (dvd);

			return DvdToListViewSelect(match);
		}

		public List<DvdListView> GetDvdByReleaseYear(int releaseYear)
		{
			var match = from dvd in _dvds
						where dvd.ReleaseYear == releaseYear
						select (dvd);

			return DvdToListViewSelect(match);
		}

		public List<DvdListView> GetDvdByTitle(string title)
		{
			var match = from dvd in _dvds
						where dvd.Title == title
						select (dvd);

			return DvdToListViewSelect(match);
		}
	}
}
