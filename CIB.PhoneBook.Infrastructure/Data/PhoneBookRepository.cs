using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIB.PhoneBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIB.PhoneBook.Infrastructure.Data
{
    public class PhoneBookRepository: IPhoneBookRepository
    {
        private readonly PhoneBookDbContext dbContext;

        public PhoneBookRepository(PhoneBookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddEntry(PhoneBookEntry entry)
        {
            await dbContext.PhoneBookEntries.AddAsync(entry);
            await dbContext.SaveChangesAsync();
        }

        public IList<PhoneBookEntry> GetAll() =>
            dbContext.PhoneBookEntries.ToList();

        public async Task<PhoneBookEntry> GetById(string name) =>
            await dbContext.PhoneBookEntries.Where(entry => entry.Name == name).FirstOrDefaultAsync();
    }
}
