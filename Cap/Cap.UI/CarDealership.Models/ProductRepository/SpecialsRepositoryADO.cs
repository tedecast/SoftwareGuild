using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CarDealership.Models.Tables;
using CarDealership.Models.Queries;

namespace CarDealership.Data.ADO
{
	public class SpecialsRepositoryADO : ISpecialsRepository
	{
		public void AddSpecial(Special special)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = Settings.GetConnectionString();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddSpecial";

				SqlParameter param = new SqlParameter("@SpecialId", SqlDbType.Int);
				param.Direction = ParameterDirection.Output;

				cmd.Parameters.Add(param);

				cmd.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);
				cmd.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);


				conn.Open();
				cmd.ExecuteNonQuery();

				special.SpecialId = (int)param.Value;
			}
		}
		public void DeleteSpecial(int id)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = Settings.GetConnectionString();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteSpecial";

				cmd.Parameters.AddWithValue("@SpecialId", id);

				conn.Open();
				cmd.ExecuteNonQuery();
			}
		}
		public List<Special> GetAllSpecials()
		{
			List<Special> specials = new List<Special>();

			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = Settings.GetConnectionString();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAllSpecials";

				conn.Open();

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						Special currentRow = new Special();

						currentRow.SpecialId = (int)dr["SpecialId"];
						currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
						currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

						specials.Add(currentRow);
					}
				}
				return specials;
			}
		}
	}
}
