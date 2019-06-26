using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
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
	public class SalesRepository : ISalesRepository
	{
		public void AddSale(Sale sale)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@SaleId",
				dbType: DbType.Int32, direction: ParameterDirection.Output);
				parameters.Add("@UserId", sale.UserId);
				parameters.Add("@PurchaseTypeId", sale.PurchaseTypeId);
				parameters.Add("@VehicleId", sale.VehicleId);
				parameters.Add("@PurchasePrice", sale.PurchasePrice);
				parameters.Add("@Name", sale.Name);
				parameters.Add("@Phone", sale.Phone);
				parameters.Add("@Email", sale.Email);
				parameters.Add("@Street1", sale.Street1);
				parameters.Add("@Street2", sale.Street2);
				parameters.Add("@City", sale.City);
				parameters.Add("@State", sale.State);
				parameters.Add("@Zipcode", sale.Zipcode);
				sale.DateSold = DateTime.Now;
				parameters.Add("@DateSold", sale.DateSold);

				cn.Execute("AddSale", parameters,
							commandType: CommandType.StoredProcedure);

				sale.SaleId = parameters.Get<int>("@SaleId");
			}
		}

		public List<SalesReportItem> GetSalesBySearch(SalesSearchItem search)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();
				var parameters = new DynamicParameters();

				string query = "SELECT u.FirstName, u.LastName, SUM(Sale.PurchasePrice) AS TotalSales, COUNT(Sale.VehicleId) AS TotalVehicles " +
								"FROM Sale " +
								"INNER JOIN AspNetUsers u ON u.Id = sale.UserId ";


				if (search.FromDate.HasValue)
				{
					query += "AND DateSold >= @fromDate ";
					parameters.Add("@fromDate", search.FromDate);
				}
				if (search.ToDate.HasValue)
				{
					query += "AND DateSold <= @toDate ";
					parameters.Add("@toDate", search.ToDate);
				}
				if (!string.IsNullOrEmpty(search.UserSelect))
				{
					query += "AND (u.Id LIKE @User) ";
					parameters.Add("@User", search.UserSelect);
				}

				query += " GROUP BY u.FirstName, u.LastName ";

				return cn.Query<SalesReportItem>(query, parameters,
							commandType: CommandType.Text).ToList();
			}
		}
	}
}
