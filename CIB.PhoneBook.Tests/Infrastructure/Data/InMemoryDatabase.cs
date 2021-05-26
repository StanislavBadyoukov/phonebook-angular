using System;
using System.Diagnostics.CodeAnalysis;
using CIB.PhoneBook.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CIB.PhoneBook.Tests.Infrastructure.Data
{
    [ExcludeFromCodeCoverage]
    public class InMemoryDatabase
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<PhoneBookDbContext> options;

        public PhoneBookDbContext DbContext { get; }

        public InMemoryDatabase()
        {
            connection = new SqliteConnection(InMemoryConnectionString);
            connection.CreateFunction("getdate", () => DateTime.Now);
            connection.Open();

            options = new DbContextOptionsBuilder<PhoneBookDbContext>()
                .UseSqlite(connection)
                .Options;

            DbContext = new PhoneBookDbContext(options);
            DbContext.Database.EnsureCreated();
        }
    }
}
