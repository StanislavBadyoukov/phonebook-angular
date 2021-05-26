using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIB.PhoneBook.Domain
{
    public interface IPhoneBookRepository
    {
        Task AddEntry(PhoneBookEntry entry);

        IList<PhoneBookEntry> GetAll();

        Task<PhoneBookEntry> GetById(string name);
    }
}
