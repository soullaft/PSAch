using Microsoft.EntityFrameworkCore;
using NLog.Fluent;
using PSAch.API.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PSAch.API.Generator
{
    public class Generator
    {
        private const string HARDCODED_PASSWORD = "1234";

        public static async Task GenerateUsersAsync(DataContext dataContext, IConfiguration configuration)
        {
            var generatedFilePath = configuration["GeneratedUserFile"];
            //if (await dataContext.Users.AnyAsync() && !File.Exists(generatedFilePath)) return;

            var userdata = await File.ReadAllTextAsync(generatedFilePath);
            //var users = JsonSerializer.Deserialize<ICollection<User>>(userdata);

            //foreach(var user in users)
        }

        public static (byte[], byte[]) GenerateHashSalt(string password)
        {
            using var hmac = new HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var salt = hmac.Key;

            return (hash, salt);
        }
    }
}
