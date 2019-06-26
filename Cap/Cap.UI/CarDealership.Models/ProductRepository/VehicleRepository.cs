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
	public class VehicleRepository : IVehicleRepository
	{

		public void AddVehicle(Vehicle vehicle)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@VehicleId",
				dbType: DbType.Int32, direction: ParameterDirection.Output);
				parameters.Add("@MakeId", vehicle.MakeId);
				parameters.Add("@ModelId", vehicle.ModelId);
				parameters.Add("@InteriorId", vehicle.InteriorId);
				parameters.Add("@ColorId", vehicle.ColorId);
				parameters.Add("@TypeId", vehicle.TypeId);
				parameters.Add("@BodyId", vehicle.BodyId);
				parameters.Add("@TransmissionId", vehicle.TransmissionId);
				parameters.Add("@Year", vehicle.Year);
				parameters.Add("@VIN", vehicle.VIN);
				parameters.Add("@Mileage", vehicle.Mileage);
				parameters.Add("@MSRP", vehicle.MSRP);
				parameters.Add("@SalePrice", vehicle.SalePrice);
				parameters.Add("@Description", vehicle.Description);
				parameters.Add("@isSold", vehicle.IsSold);
				parameters.Add("@isFeatured", vehicle.IsFeatured);


				if (string.IsNullOrEmpty(vehicle.PhotoPath))
				{
					parameters.Add("@PhotoPath", " ");
				}
				else
				{
					parameters.Add("@PhotoPath", vehicle.PhotoPath);
				}

				cn.Execute("AddVehicle", parameters,
							commandType: CommandType.StoredProcedure);

				vehicle.VehicleId = parameters.Get<int>("@VehicleId");
			}
		}

		public void DeleteVehicle(int id)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				cn.Execute("DeleteVehicle",
							commandType: CommandType.StoredProcedure);
			}

		}

		public void EditVehicle(Vehicle vehicle)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@VehicleId", vehicle.VehicleId);
				parameters.Add("@MakeId", vehicle.MakeId);
				parameters.Add("@ModelId", vehicle.ModelId);
				parameters.Add("@InteriorId", vehicle.InteriorId);
				parameters.Add("@ColorId", vehicle.ColorId);
				parameters.Add("@TypeId", vehicle.TypeId);
				parameters.Add("@BodyId", vehicle.BodyId);
				parameters.Add("@TransmissionId", vehicle.TransmissionId);
				parameters.Add("@Year", vehicle.Year);
				parameters.Add("@VIN", vehicle.VIN);
				parameters.Add("@Mileage", vehicle.Mileage);
				parameters.Add("@MSRP", vehicle.MSRP);
				parameters.Add("@SalePrice", vehicle.SalePrice);
				parameters.Add("@Description", vehicle.Description);
				parameters.Add("@PhotoPath", vehicle.PhotoPath);
				parameters.Add("@isSold", vehicle.IsSold);
				parameters.Add("@isFeatured", vehicle.IsFeatured);
				parameters.Add("@isDeleted", vehicle.IsDeleted);

				cn.Execute("UpdateVehicle", parameters, commandType: CommandType.StoredProcedure);

				vehicle.VehicleId = parameters.Get<int>("@VehicleId");

			}
		}

		public List<VehicleItem> GetAll()
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				return cn.Query<VehicleItem>("GetAllVehicles",
							commandType: CommandType.StoredProcedure).ToList();
			}

		}

		public List<FeaturedVehicleItem> GetFeatured()
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				return cn.Query<FeaturedVehicleItem>("GetFeatured",
							commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public List<MakeItem> GetMakeItems()
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				return cn.Query<MakeItem>("GetMakeItems",
							commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public void AddMake(Make item)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@MakeId",
				dbType: DbType.Int32, direction: ParameterDirection.Output);
				parameters.Add("@MakeName", item.MakeName);
				parameters.Add("@UserId", item.UserId);
				parameters.Add("@DateAdded", item.DateAdded);

				cn.Execute("AddMakeItem", parameters,
							commandType: CommandType.StoredProcedure);

				item.MakeId = parameters.Get<int>("@MakeId");

			}
		}

		public List<ModelItem> GetModelItems()
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				return cn.Query<ModelItem>("GetModelItems",
							commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public void AddModel(Model item )
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@ModelId",
				dbType: DbType.Int32, direction: ParameterDirection.Output);
				parameters.Add("@MakeId", item.MakeId);
				parameters.Add("@ModelName", item.ModelName);
				parameters.Add("@UserId", item.UserId);
				parameters.Add("@DateAdded", item.DateAdded);

				cn.Execute("AddModelItem", parameters,
							commandType: CommandType.StoredProcedure);

				item.MakeId = parameters.Get<int>("@MakeId");
			}
		}

		public VehicleItem GetVehicleItemById(int id)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@VehicleId", id);
				return cn.Query<VehicleItem>("GetVehicleItemById", parameters,
							commandType: CommandType.StoredProcedure).FirstOrDefault();
			}
		}

		public List<VehicleItem> GetVehicleBySearch(SearchItem item)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();
				var parameters = new DynamicParameters();

				string query = "SELECT TOP 20 VehicleId, m.MakeName, mo.ModelName, b.BodyType, i.InteriorColor, c.ColorName, t.TypeName,  tr.TransmissionType, " +
				"[Year], VIN, Mileage, MSRP, SalePrice, PhotoPath, isFeatured, isSold " +
				"FROM Vehicle v " +
				"INNER JOIN Make m ON m.MakeId = v.MakeId " +
				"INNER JOIN Model mo ON mo.ModelId = v.ModelId " +
				"INNER JOIN Interior i ON i.InteriorId = v.InteriorId " +
				"INNER JOIN Color c ON c.ColorId = v.ColorId " +
				"INNER JOIN[Type] t ON t.TypeId = v.TypeID " +
				"INNER JOIN Body b ON b.BodyId = v.BodyId " +
				"INNER JOIN Transmission tr ON tr.TransmissionId = v.TransmissionId " +
				"WHERE 1 = 1 AND isSold = 0 AND isDeleted = 0";

				if (item.MinPrice.HasValue)
				{
					query += "AND SalePrice >= @minPrice ";
					parameters.Add("@minPrice", item.MinPrice);
				}
				if (item.MaxPrice.HasValue)
				{
					query += "AND SalePrice <= @maxPrice ";
					parameters.Add("@maxPrice", item.MaxPrice);
				}
				if (item.MinYear.HasValue)
				{
					query += "AND [Year] >= @minYear ";
					parameters.Add("@minYear", item.MinYear);
				}
				if (item.MaxYear.HasValue)
				{
					query += "AND [Year] <= @maxYear ";
					parameters.Add("@maxYear", item.MaxYear);
				}
				if (!string.IsNullOrEmpty(item.SearchTerm))
				{
					query += "AND (m.MakeName LIKE @SearchTerm OR mo.ModelName LIKE @SearchTerm)";
					parameters.Add("@SearchTerm", item.SearchTerm + "%");
				}

				query += " ORDER BY v.MSRP DESC";


				return cn.Query<VehicleItem>(query, parameters,
							commandType: CommandType.Text).ToList();
			}
		}

		public Vehicle GetVehicleById(int id)
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				var parameters = new DynamicParameters();
				parameters.Add("@VehicleId", id);
				return cn.Query<Vehicle>("GetVehicleById", parameters,
							commandType: CommandType.StoredProcedure).FirstOrDefault();
			}
		}

		public List<InventoryReportItem> InventoryReport()
		{
			using (var cn = new SqlConnection())
			{
				cn.ConnectionString = Settings.GetConnectionString();

				return cn.Query<InventoryReportItem>("GetInventoryReport",
							commandType: CommandType.StoredProcedure).ToList();
			}
		}
	}
}

