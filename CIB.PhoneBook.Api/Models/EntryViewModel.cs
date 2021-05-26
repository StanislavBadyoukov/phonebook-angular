namespace CIB.PhoneBook.Api.Models
{
    public class EntryViewModel
    {
        public EntryViewModel(string name, string number)
        {
            Name = name;
            PhoneNumber = number;
        }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
