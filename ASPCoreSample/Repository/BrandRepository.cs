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
    public class BrandRepository : IRepository<BrandModel>
    {
        private string connectionString;

        public BrandRepository(IConfiguration configuration)
        {
            //connectionString = "Brand ID=postgres;Password=mete;Host=localhost;Port=5432;Database=ASM;Pooling=true;";
            connectionString = "User ID=root;Password=ASM123!;Host=206.189.23.48;Port=5432;Database=ASM;Pooling=true;";
        }
        public BrandRepository()
        {
            //connectionString = "Brand ID=postgres;Password=mete;Host=localhost;Port=5432;Database=ASM;Pooling=true;";
            connectionString = "User ID=root;Password=ASM123!;Host=206.189.23.48;Port=5432;Database=ASM;Pooling=true;";
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(BrandModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                item.Id = System.DateTime.Now.Ticks;
                dbConnection.Execute("INSERT INTO brand (name) VALUES(@name)", item);
            }

        }

        public IEnumerable<BrandModel> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<BrandModel>("SELECT * FROM brand");
            }
        }

        public BrandModel FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<BrandModel>("SELECT name FROM brand WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM brand WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(BrandModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE brand SET name = @name WHERE id = @Id", item);
            }
        }
        
        
    }
}
