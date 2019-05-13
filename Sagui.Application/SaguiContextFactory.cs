using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Sagui.Application
{
   
    public class SaguiContextFactory : IDesignTimeDbContextFactory<Sagui.Postgres.Sagui>
    {
        public Sagui.Postgres.Sagui CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
               var connectionString = configuration.GetConnectionString("SaguiPostgres");
               var optionsBuilder = new DbContextOptionsBuilder<Sagui.Postgres.Sagui>();
           optionsBuilder.UseNpgsql(connectionString);

            return new Sagui.Postgres.Sagui(optionsBuilder.Options);
        }
    }
}