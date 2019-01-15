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
    public class UserRepository : IRepository<UserModel>
    {
        private string connectionString;

        public UserRepository(IConfiguration configuration)
        {
           
            connectionString = "User ID=root;Password=ASM123!;Host=206.189.23.48;Port=5432;Database=ASM;Pooling=true;";
        }
        public UserRepository()
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

        public void Add(UserModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                item.Id = System.DateTime.Now.Ticks;
                item.password = CreateMD5(item.password);
                dbConnection.Execute("INSERT INTO users (name,surname,department,password,email,username) VALUES(@name,@surname,@department,@password,@email,@username)", item);
            }

        }

        public IEnumerable<UserModel> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UserModel>("SELECT * FROM users");
            }
        }

        public UserModel FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UserModel>("SELECT name,surname,department,email,username FROM users WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM users WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(UserModel item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                item.password = CreateMD5(item.password);
                dbConnection.Query("UPDATE users SET name = @name,  surname  = @surname, department= @department, password= @password, email= @email, username= @username WHERE id = @Id", item);
            }
        }

        public void updatePass(string newPass,string email)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
            dbConnection.Query("UPDATE users SET  password= '"+newPass+"' WHERE email = '"+email+"'");
            }
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
