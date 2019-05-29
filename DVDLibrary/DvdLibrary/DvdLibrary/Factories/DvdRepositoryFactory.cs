using DvdLibrary.Data;
using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.Factories
{
	public static class DvdRepositoryFactory
	{
		public static IDvdLibraryRepository GetRepository()
		{
			switch (Settings.GetRepositoryType())
			{
				case "ADO":
					return new DvdRepositoryADO();
				case "Sample Data":
					return new DvdLibraryRepositoryMock();
				default:
					throw new Exception("Couldn't find the configuration type.");
			}

		}
	}
}