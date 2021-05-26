using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIB.PhoneBook.Api.Models;
using CIB.PhoneBook.Application;
using CIB.PhoneBook.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CIB.PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            this.phoneBookService = phoneBookService;
        }

        [HttpGet("{searchText}")]
        public IReadOnlyCollection<EntryViewModel> Search(string searchText)
        {
            var foundEntries = phoneBookService.Search(searchText);

            //Normally would use automapper for mapping but since its such a small use case decided to map manually
            return foundEntries.Select(entry => new EntryViewModel(entry.Name, entry.PhoneNumber)).ToList()
                .AsReadOnly();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEntryViewModel entry)
        {
            //Normally would use automapper for mapping but since its such a small use case decided to map manually
            await phoneBookService.AddEntry(new PhoneBookEntry(entry.Name, entry.PhoneNumber));
            return CreatedAtAction("Search", entry.Name);
        }
    }
}