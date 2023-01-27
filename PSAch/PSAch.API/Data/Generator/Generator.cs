using Microsoft.EntityFrameworkCore;
using NLog.Fluent;
using System.Text.Json;

namespace PSAch.API.Data.Generator
{
    public class Generator
    {
        private const string HARDCODED_PASSWORD = "1234";

        public static async Task GenerateUsers(DataContext dataContext, IConfiguration configuration)
        {
            var generatedFilePath = configuration["GeneratedUserFile"];
            //if (await dataContext.Users.AnyAsync() && !File.Exists(generatedFilePath)) return;

            var userdata = await File.ReadAllTextAsync(generatedFilePath);
            //var users = JsonSerializer.Deserialize<ICollection<User>>(userdata);

            //foreach(var user in users)
        }
    }
}
