using System;
using System.Threading.Tasks;
using CIB.PhoneBook.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CIB.PhoneBook.Tests.Application
{
    using CIB.PhoneBook.Domain;

    [TestClass]
    public class PhoneBookServiceTests
    {
        [TestMethod]
        public async Task AddEntry_When_Duplicate_Entry_Throws_exception()
        {
            //arrange
            var repository = Substitute.For<IPhoneBookRepository>();
            repository.GetById("Test").Returns(new PhoneBookEntry());
            var phoneBookService = new PhoneBookService(repository);

            //act + assert
            await Assert.ThrowsExceptionAsync<ApplicationException>(() =>
                phoneBookService.AddEntry(new PhoneBookEntry
                {
                    Name = "Test",
                    PhoneNumber = "123"
                }));
        }
    }
}