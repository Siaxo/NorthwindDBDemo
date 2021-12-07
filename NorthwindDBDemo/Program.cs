using Microsoft.Extensions.Configuration;
using System;

namespace NorthwindDBDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var application = new Application(connectionString);
            application.Run();
        }
    }
}
