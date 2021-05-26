namespace CIB.PhoneBook.Domain
{
    public class PhoneBookEntry
    {
        public PhoneBookEntry()
        {
        }

        public PhoneBookEntry(string name, string number)
        {
            Name = name;
            PhoneNumber = number;
        }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
