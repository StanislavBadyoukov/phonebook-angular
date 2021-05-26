using System.Collections.Generic;
using System.Threading.Tasks;
using CIB.PhoneBook.Domain;

namespace CIB.PhoneBook.Application
{
    public interface IPhoneBookService
    {
        Task AddEntry(PhoneBookEntry entry);
        IReadOnlyCollection<PhoneBookEntry> Search(string searchText);
    }
}
