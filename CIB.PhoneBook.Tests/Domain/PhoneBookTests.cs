using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CIB.PhoneBook.Tests.Domain
{
    using CIB.PhoneBook.Domain;

    [TestClass]
    public class PhoneBookTests
    {
        [TestMethod]
        public void AddEntry_Adds_Entry_Successfully()
        {
            //arrange
            var phoneBook = new PhoneBook();

            //act
            phoneBook.AddEntry(new PhoneBookEntry
            {
                Name = "Test",
                PhoneNumber = "123"
            });

            //assert
            Assert.AreEqual(1, phoneBook.Entries.Count);
        }
        
        [TestMethod]
        public void SearchEntries_When_Null_Entries_Then_Return_Null()
        {
            //arrange
            var phoneBook = new PhoneBook();

            //act
            var result = phoneBook.SearchEntries("anything");

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SearchEntries_When_No_Search_Match_Then_Return_Empty_List()
        {
            //arrange
            var phoneBook = new PhoneBook();
            phoneBook.AddEntry(new PhoneBookEntry("",""));

            //act
            var result = phoneBook.SearchEntries("anything");

            //assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SearchEntries_When_Match_Found_On_Name_Then_Return_Item()
        {
            //arrange
            var phoneBook = new PhoneBook();
            phoneBook.AddEntry(new PhoneBookEntry("123", ""));

            //act
            var result = phoneBook.SearchEntries("123");

            //assert
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void SearchEntries_When_Match_Found_On_Number_Then_Return_Item()
        {
            //arrange
            var phoneBook = new PhoneBook();
            phoneBook.AddEntry(new PhoneBookEntry("", "456"));

            //act
            var result = phoneBook.SearchEntries("456");

            //assert
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void SearchEntries_When_Match_Found_On_Name_And_Number_Then_Return_Both()
        {
            //arrange
            var phoneBook = new PhoneBook();
            phoneBook.AddEntry(new PhoneBookEntry("123", "a"));
            phoneBook.AddEntry(new PhoneBookEntry("b", "123"));

            //act
            var result = phoneBook.SearchEntries("123");

            //assert
            Assert.AreEqual(2, result.Count);
        }
    }
}
