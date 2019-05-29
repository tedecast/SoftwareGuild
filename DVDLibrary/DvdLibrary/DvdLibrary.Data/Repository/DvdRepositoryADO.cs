using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using Dapper;
using System.Configuration;
using DvdLibrary.Models;
using System.Data.SqlClient;
using DvdLibrary.Data.Interfaces;

namespace DvdLibrary.Data
{
	public class DvdRepositoryADO : IDvdLibraryRepository 
	{
		public List<DvdListView> DvdSelectAll()
		{
			List<DvdListView> dvds = new List<DvdListView>();

			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DvdSelectAll";

				conn.Open();

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						DvdListView currentRow = new DvdListView();

						currentRow.DvdId = (int)dr["DvdId"];
						currentRow.Title = dr["Title"].ToString();
						currentRow.ReleaseYear = (int)dr["ReleaseYear"];
						currentRow.Director = dr["Director"].ToString();
						currentRow.Rating = dr["RatingName"].ToString();
						currentRow.Notes = dr["Notes"].ToString();

						dvds.Add(currentRow);
					}
				}
				return dvds;
			}
		}

		public DvdListView GetDvdById(int id)
		{
			List<DvdListView> dvds = new List<DvdListView>();

			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DvdSelectById";

				cmd.Parameters.AddWithValue("@DvdId", id);

				conn.Open();

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						DvdListView currentRow = new DvdListView();

						currentRow.DvdId = (int)dr["DvdId"];
						currentRow.Title = dr["Title"].ToString();
						currentRow.ReleaseYear = (int)dr["ReleaseYear"];
						currentRow.Director = dr["Director"].ToString();
						currentRow.Rating = dr["RatingName"].ToString();
						currentRow.Notes = dr["Notes"].ToString();

						dvds.Add(currentRow);
					}
				}
				return dvds[0];
			}
		}

		public List<DvdListView> GetDvdByTitle(string title)
		{
			List<DvdListView> dvds = new List<DvdListView>();

			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DvdSelectByTitle";

				cmd.Parameters.AddWithValue("@Title", title);

				conn.Open();

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						DvdListView currentRow = new DvdListView();

						currentRow.DvdId = (int)dr["DvdId"];
						currentRow.Title = dr["Title"].ToString();
						currentRow.ReleaseYear = (int)dr["ReleaseYear"];
						currentRow.Director = dr["Director"].ToString();
						currentRow.Rating = dr["RatingName"].ToString();
						currentRow.Notes = dr["Notes"].ToString();

						dvds.Add(currentRow);
					}
				}
				return dvds;
			}
		}

		public List<DvdListView> GetDvdByReleaseYear(int releaseYear)
		{
			List<DvdListView> dvds = new List<DvdListView>();

			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DvdSelectByReleaseYear";

				cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);

				conn.Open();

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						DvdListView currentRow = new DvdListView();

						currentRow.DvdId = (int)dr["DvdId"];
						currentRow.Title = dr["Title"].ToString();
						currentRow.ReleaseYear = (int)dr["ReleaseYear"];
						currentRow.Director = dr["Director"].ToString();
						currentRow.Rating = dr["RatingName"].ToString();
						currentRow.Notes = dr["Notes"].ToString();

						dvds.Add(currentRow);
					}
				}
				return dvds;
			}
		}

		public List<DvdListView> GetDvdByDirectorName(string name)
		{
			List<DvdListView> dvds = new List<DvdListView>();

			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DvdSelectByDirectorName";

				cmd.Parameters.AddWithValue("@Director", name);

				conn.Open();

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						DvdListView currentRow = new DvdListView();

						currentRow.DvdId = (int)dr["DvdId"];
						currentRow.Title = dr["Title"].ToString();
						currentRow.ReleaseYear = (int)dr["ReleaseYear"];
						currentRow.Director = dr["Director"].ToString();
						currentRow.Rating = dr["RatingName"].ToString();
						currentRow.Notes = dr["Notes"].ToString();

						dvds.Add(currentRow);
					}
				}
				return dvds;
			}
		}

		public List<DvdListView> GetDvdByRating(string rating)
		{
			List<DvdListView> dvds = new List<DvdListView>();

			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DvdSelectByRating";

				cmd.Parameters.AddWithValue("@Rating", rating);

				conn.Open();

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						DvdListView currentRow = new DvdListView();

						currentRow.DvdId = (int)dr["DvdId"];
						currentRow.Title = dr["Title"].ToString();
						currentRow.ReleaseYear = (int)dr["ReleaseYear"];
						currentRow.Director = dr["Director"].ToString();
						currentRow.Rating = dr["RatingName"].ToString();
						currentRow.Notes = dr["Notes"].ToString();

						dvds.Add(currentRow);
					}
				}
				return dvds;
			}
		}

		public void  DvdInsert(Dvd dvd)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DvdInsert";

				SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
				param.Direction = ParameterDirection.Output;

				cmd.Parameters.Add(param);

				cmd.Parameters.AddWithValue("@Title", dvd.Title);
				cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
				cmd.Parameters.AddWithValue("@Director", dvd.Director);
				cmd.Parameters.AddWithValue("@RatingId", dvd.RatingId);
				cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

				conn.Open();
				cmd.ExecuteNonQuery();

				dvd.DvdId = (int)param.Value;
			}
		}

		public void DvdEdit(Dvd dvd)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DvdUpdate";

				cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
				cmd.Parameters.AddWithValue("@Title", dvd.Title);
				cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
				cmd.Parameters.AddWithValue("@Director", dvd.Director);
				cmd.Parameters.AddWithValue("@RatingId", dvd.RatingId);
				cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

				conn.Open();
				cmd.ExecuteNonQuery();
			}
		}

		public void DvdDelete(int id)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DvdDelete";

				cmd.Parameters.AddWithValue("@DvdId", id);

				conn.Open();
				cmd.ExecuteNonQuery();
			}
		}
	}
}
