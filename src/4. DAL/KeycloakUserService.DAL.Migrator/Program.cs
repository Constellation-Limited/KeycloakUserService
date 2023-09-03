using KeycloakUserService.DAL;
using KeycloakUserService.DAL.Misc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables("constellation_")
    .Build();

var options = new DbContextOptionsBuilder<KeycloakUserServiceDbContext>();
options.ResolveProviderSpecificOptions(configuration, "Default");

var context = new KeycloakUserServiceDbContext(options.Options);

Console.WriteLine("Starting migrations...");
context.Database.Migrate();
Console.WriteLine("Migrations done!");