using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using ASPCoreSample.Models;
using System.Text;

namespace ASPCoreSample.Repository
{
    public class assetRepository : IRepository2<AssetModel>
    {
        private string connectionString;

        public assetRepository(IConfiguration configuration)
        {
            
            connectionString = "User ID=root;Password=ASM123!;Host=206.189.23.48;Port=5432;Database=ASM;Pooling=true;";
        }
        public assetRepository()
        {
            
            connectionString = "User ID=root;Password=ASM123!;Host=206.189.23.48;Port=5432;Database=ASM;Pooling=true;";
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(AssetModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                item.Id = System.DateTime.Now.Ticks;
                dbConnection.Execute("INSERT INTO asset_location (numberofasset,assettype_id,brand_id,room_id,acquisition_date,serial_no,owner_id,depot_id)VALUES(@numberofasset, @assettype_id, @brand_id, @room_id, @acquisition_date, @serial_no, @owner_id,@depot_id)", item);
            }

        }

        public IEnumerable<AssetModel> FindAll(int roomID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string chunk = "";
                if (roomID!=0)
                {
                    chunk= " where a.room_id = "+roomID;
                }
                return dbConnection.Query<AssetModel>("SELECT a.id, a.numberofasset,a.assettype_id,a.brand_id,a.room_id, a.acquisition_date,a.serial_no, c.name AS \"type_name\" , b.name AS \"brand_name\" ,d.name AS \"owner_name\",e.roomname AS \"room_name\", f.name AS \"depot_name\" FROM public.asset_location a LEFT JOIN asset_type c on a.assettype_id = c.id LEFT JOIN brand b on a.brand_id = b.id LEFT JOIN owner d on a.owner_id= d.id LEFT JOIN room e on a.room_id= e.id LEFT JOIN depot f on a.depot_id=f.id"+ chunk);
            }
        }

        public AssetModel FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<AssetModel>("SELECT * FROM asset_location WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM asset_location WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(AssetModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE asset_location SET id = @id ,owner_id = @owner_id,depot_id = @depot_id,acquisition_date = @acquisition_date,numberofasset = @numberofasset,assettype_id = @assettype_id ,brand_id = @brand_id ,room_id = @room_id ,serial_no = @serial_no  WHERE id = @Id", item);
            }
        }
        
    }
}
