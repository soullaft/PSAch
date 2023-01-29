using PSAch.API.Data;
using PSAch.API.Models;
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
            if (!File.Exists(generatedFilePath)) throw new FileNotFoundException($"Файл не найден по пути:{generatedFilePath}");

            var userdata = await File.ReadAllTextAsync(generatedFilePath);
            var users = JsonSerializer.Deserialize<ICollection<AppUser>>(userdata);

            foreach(var user in users)
            {
                user.Login = user.Login.ToLower();
                var hashSalt = GenerateHashSalt(HARDCODED_PASSWORD);
                user.PasswordHash = hashSalt.Item1;
                user.PasswordSalt = hashSalt.Item2;

                await dataContext.AppUsers.AddAsync(user);
            }

            await dataContext.SaveChangesAsync();
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
