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
    public class RoomRepository : IRepository<RoomModel>
    {
        private string connectionString;

        public RoomRepository(IConfiguration configuration)
        {
            
            connectionString = "User ID=root;Password=ASM123!;Host=206.189.23.48;Port=5432;Database=ASM;Pooling=true;";
        }
        public RoomRepository()
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

        public void Add(RoomModel item)
        {
            //using (IDbConnection dbConnection = Connection)
            //{
            //    dbConnection.Open();
            //    item.Id = System.DateTime.Now.Ticks;
            //    dbConnection.Execute("INSERT INTO asset_type (name) VALUES(@name)", item);
            //}

        }

        public IEnumerable<RoomModel> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RoomModel>("SELECT a.id, a.roomname, floor, block, isactive, owner_id, name FROM public.room a LEFT JOIN owner c on a.owner_id = c.id ORDER By roomname ASC ");
            }
        }

        public RoomModel FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RoomModel>("SELECT * FROM room WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            //using (IDbConnection dbConnection = Connection)
            //{
            //    dbConnection.Open();
            //    dbConnection.Execute("DELETE FROM asset_type WHERE Id=@Id", new { Id = id });
            //}
        }

        public void Update(RoomModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE room SET owner_id = @owner_id,isactive = @isactive WHERE id = @Id", item);
            }
        }
        
        
    }
}
