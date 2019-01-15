using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ASPCoreSample.Models;
using ASPCoreSample.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Data;
using Npgsql;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Net.Mail;

namespace ASPCoreSample.Controllers
{
    public class AuthController : Controller
    {
       


        [HttpPost]
        public async Task<string> Login(string username,string password)
        {

            string connectionString = "User ID=root;Password=ASM123!;Host=206.189.23.48;Port=5432;Database=ASM;Pooling=true;";
            IDbConnection dbConnection = new NpgsqlConnection(connectionString);
            List < UserModel > loginResponse= dbConnection.Query<UserModel>("SELECT * FROM users WHERE username = '"+username+"' and password = '"+ CreateMD5(password) + "'").AsList<UserModel>();

            HttpContext.Session.SetString("username", username);
            HttpContext.Session.SetString("name", loginResponse[0].name);
            HttpContext.Session.SetString("userID", ""+loginResponse[0].Id);
            HttpContext.Session.SetString("surname", loginResponse[0].surname);
            HttpContext.Session.SetString("email", loginResponse[0].email);
            HttpContext.Session.SetString("department", loginResponse[0].department);
            if (loginResponse.Count > 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
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

        public async Task<string> forgetPassword(string email)
        {
            string newPassword = CreatePassword(8);
            string hashPass=CreateMD5(newPassword);
            
            UserRepository mUserRep = new UserRepository();
            mUserRep.updatePass(hashPass, email);

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            //visualassetman@gmail.com şifre: asm123!asm
            client.Credentials = new System.Net.NetworkCredential("visualassetman@gmail.com", "asm123!asm");

            MailMessage mm = new MailMessage("visualassetman@gmail.com", email, "test", "yeni şifreniz budur : "+ newPassword);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);


            return "";

        }

    }
}
