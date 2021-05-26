using System.Collections.Generic;
using System.Linq;

namespace CIB.PhoneBook.Domain
{
    /// <summary>
    /// In ddd terms this would be the aggregate root and should try to encapsulate all domain behaviour.
    /// it is responsible for all operations on phone book and phone book entries
    /// </summary>
    public class PhoneBook
    {
        public PhoneBook()
        {
        }

        public PhoneBook(List<PhoneBookEntry> entries)
        {
            Entries = entries;
        }

        public List<PhoneBookEntry> Entries { get; private set; }

        public void AddEntry(PhoneBookEntry entry)
        {
            if (Entries == null)
                Entries = new List<PhoneBookEntry>();

            Entries.Add(entry);
        }

        public IReadOnlyCollection<PhoneBookEntry> SearchEntries(string searchText) =>
            Entries?.Where(entry =>
                    entry.Name.ToLower().Contains(searchText.ToLower()) ||
                    entry.PhoneNumber.ToLower().Contains(searchText.ToLower()))
                .ToList();
    }
}