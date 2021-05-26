using CIB.PhoneBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CIB.PhoneBook.Api
{
    public class DbContextFactory : IDesignTimeDbContextFactory<PhoneBookDbContext>
    {
        public PhoneBookDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.Development.json", optional: true,
                    reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var connString = config.GetConnectionString("PhoneBookApiApiDefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookDbContext>();
            optionsBuilder.UseSqlServer(connString);

            return new PhoneBookDbContext(optionsBuilder.Options);
        }
    }
}
