using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using CarDealership.Models.Tables;

namespace CarDealership.Data.ProductRepository
{
	public class ContactUsRepository : IContactUsRepository
	{
		public void AddContactUs(ContactUs item)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@ContactUsId",
				dbType: DbType.Int32, direction: ParameterDirection.Output);
				parameters.Add("@Email", item.Email);
				parameters.Add("@Name", item.Name);
				parameters.Add("@Phone", item.Phone);
				parameters.Add("@Message", item.Message);

				cn.Execute("AddContactUs", parameters, 
							commandType: CommandType.StoredProcedure);

				item.ContactUsId = parameters.Get<int>("@ContactUsId");
			}
		}

		public List<ContactUs> GetAllContactUs()
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				return cn.Query<ContactUs>("GetAllContactUs",
					commandType: CommandType.StoredProcedure).ToList();
			}
		}

	}
}
