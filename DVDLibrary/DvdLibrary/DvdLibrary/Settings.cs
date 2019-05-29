using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DvdLibrary
{
	public class Settings
	{
		private static string _repositoryType;

		public static string GetRepositoryType()
		{
			if (string.IsNullOrEmpty(_repositoryType))
				_repositoryType = ConfigurationManager.AppSettings["Mode"].ToString();

			return _repositoryType;
		}
	}
}