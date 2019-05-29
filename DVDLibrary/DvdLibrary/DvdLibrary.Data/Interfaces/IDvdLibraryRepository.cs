using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Interfaces
{
	public interface IDvdLibraryRepository
	{
		List<DvdListView> DvdSelectAll();
		DvdListView GetDvdById(int id);
		List<DvdListView> GetDvdByTitle(string title);
		List<DvdListView> GetDvdByReleaseYear(int releaseYear);
		List<DvdListView> GetDvdByDirectorName(string name);
		List<DvdListView> GetDvdByRating(string rating);
		void DvdInsert(Dvd dvd);
		void DvdEdit(Dvd dvd);
		void DvdDelete(int id);
	}
}
