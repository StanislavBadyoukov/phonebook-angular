using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIB.PhoneBook.Application
{
    using Domain;

    public class PhoneBookService: IPhoneBookService
    {
        private readonly IPhoneBookRepository phoneBookRepository;

        public PhoneBookService(IPhoneBookRepository phoneBookRepository)
        {
            this.phoneBookRepository = phoneBookRepository;
        }

        public async Task AddEntry(PhoneBookEntry entry)
        {
            var existingEntry = await phoneBookRepository.GetById(entry.Name.Trim());
            if(existingEntry != null)
                throw new ApplicationException("An entry with the same name already exists in this phone book. Please use another name or update the existing entry.");

            var phoneBook = new PhoneBook();
            phoneBook.AddEntry(entry);

            await phoneBookRepository.AddEntry(entry);
        }

        public IReadOnlyCollection<PhoneBookEntry> Search(string searchText)
        {
            var existingEntries = phoneBookRepository.GetAll().ToList();

            var phoneBook = new PhoneBook(existingEntries);
            return phoneBook.SearchEntries(searchText);
        }
    }
}
