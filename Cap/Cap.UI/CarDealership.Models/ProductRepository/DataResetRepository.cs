using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ProductRepository
{
	public class DataResetRepository
	{
		public void ResetData()
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				 cn.Execute("DbReset",
					commandType: CommandType.StoredProcedure);
			}
		}
	}
}
