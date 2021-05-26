using CIB.PhoneBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIB.PhoneBook.Infrastructure.Data
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options)
        {
        }

        public DbSet<PhoneBookEntry> PhoneBookEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
