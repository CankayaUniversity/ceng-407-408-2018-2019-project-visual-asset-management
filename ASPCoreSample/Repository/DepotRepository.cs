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
    public class DepotRepository : IRepository<DepotModel>
    {
        private string connectionString;

        public DepotRepository(IConfiguration configuration)
        {
            
            connectionString = "User ID=root;Password=ASM123!;Host=206.189.23.48;Port=5432;Database=ASM;Pooling=true;";
        }
        public DepotRepository()
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

        public void Add(DepotModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                item.Id = System.DateTime.Now.Ticks;
                item.notusecount = item.totalcount;
                item.inusecount = 0;
                dbConnection.Execute("INSERT INTO depot (name,type_id,brand_id,totalcount,notusecount,inusecount) VALUES(@name,@type_id,@brand_id,@totalcount,@notusecount,@inusecount)", item);
            }

        }

        public IEnumerable<DepotModel> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<DepotModel>("SELECT a.id, a.name,a.type_id,a.brand_id,a.inusecount,a.totalcount,a.notusecount,c.name AS \"brandName\" , b.name AS \"typeName\" FROM public.depot a LEFT JOIN brand c on a.brand_id = c.id LEFT JOIN asset_type b on a.type_id = b.id ORDER By a.name ASC ");
            }
        }

        public DepotModel FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<DepotModel>("SELECT * FROM depot WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM depot WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(DepotModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                
                dbConnection.Query("UPDATE depot SET name = @name ,type_id = @type_id ,brand_id = @brand_id ,inusecount = @inusecount,notusecount = @notusecount ,totalcount = @totalcount  WHERE id = @Id", item);
            }
        }
        
        
    }
}
