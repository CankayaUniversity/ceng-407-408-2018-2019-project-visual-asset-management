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
    public class AssetTypeRepository : IRepository<AssetTypeModel>
    {
        private string connectionString;

        public AssetTypeRepository(IConfiguration configuration)
        {
           
            connectionString = "User ID=root;Password=ASM123!;Host=206.189.23.48;Port=5432;Database=ASM;Pooling=true;";
        }
        public AssetTypeRepository()
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

        public void Add(AssetTypeModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                item.Id = System.DateTime.Now.Ticks;
                dbConnection.Execute("INSERT INTO asset_type (name) VALUES(@name)", item);
            }

        }

        public IEnumerable<AssetTypeModel> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<AssetTypeModel>("SELECT * FROM asset_type");
            }
        }

        public AssetTypeModel FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<AssetTypeModel>("SELECT name FROM asset_type WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM asset_type WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(AssetTypeModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE asset_type SET name = @name WHERE id = @Id", item);
            }
        }
        
        
    }
}
