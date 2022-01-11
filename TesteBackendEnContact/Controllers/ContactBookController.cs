using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain.ContactBook;
using TesteBackendEnContact.Core.Interface.ContactBook;
using TesteBackendEnContact.Repository.Interface;
using TesteBackendEnContact.Controllers.Models;

namespace TesteBackendEnContact.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ContactBookController : ControllerBase
    {
        private readonly ILogger<ContactBookController> _logger;

        public ContactBookController(ILogger<ContactBookController> logger)
        {
            _logger = logger;
        }

        [HttpPost("contactbook")]
        public async Task<ActionResult<IContactBook>> Post(SaveContactBookRequest contactBook, [FromServices] IContactBookRepository contactBookRepository)
        {
            return Ok(await contactBookRepository.SaveAsync(contactBook.ToContactBook()));
        }

        [HttpDelete]
        [Route("contactbook/{id}")]
        public async Task Delete(int id, [FromServices] IContactBookRepository contactBookRepository)
        {
            await contactBookRepository.DeleteAsync(id);
        }

        [HttpGet]
        [Route("contactbook")]
        public async Task<IEnumerable<IContactBook>> Get([FromServices] IContactBookRepository contactBookRepository)
        {
            return await contactBookRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("contactbook/{id}")]
        public async Task<IContactBook> Get(int id, [FromServices] IContactBookRepository contactBookRepository)
        {
            return await contactBookRepository.GetAsync(id);
        }

        [HttpPut]
        [Route("contactbook")]
        public async Task<IActionResult> PutAsync(UpdateContactBookRequest contactBook, [FromServices] IContactBookRepository contactBookRepository)
        {
            return Ok(await contactBookRepository.SaveAsync(contactBook.ToContactBook()));
        }

    }
}
