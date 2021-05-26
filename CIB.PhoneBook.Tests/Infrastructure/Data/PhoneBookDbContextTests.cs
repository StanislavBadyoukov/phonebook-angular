using System.Diagnostics.CodeAnalysis;
using CIB.PhoneBook.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace CIB.PhoneBook.Tests.Infrastructure.Data
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PhoneBookDbContextTests
    {
        [TestMethod]
        public async Task CanAddPhoneBookEntry()
        {
            //arrange
            var inMemDb = new InMemoryDatabase();
            
            //act
            await inMemDb.DbContext.PhoneBookEntries.AddAsync(new PhoneBookEntry
            {
                Name = "test",
                PhoneNumber = "123"
            });
            await inMemDb.DbContext.SaveChangesAsync();

            //assert
            Assert.AreEqual(1, inMemDb.DbContext.PhoneBookEntries.Count());
        }
    }
}
