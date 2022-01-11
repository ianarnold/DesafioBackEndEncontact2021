using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Controllers.Models;
using TesteBackendEnContact.Core.Interface.ContactBook.Company;
using TesteBackendEnContact.Repository.Interface;

namespace TesteBackendEnContact.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }

        [HttpPost("companies")]
        public async Task<ActionResult<ICompany>> Post(SaveCompanyRequest company, [FromServices] ICompanyRepository companyRepository)
        {
            return Ok(await companyRepository.SaveAsync(company.ToCompany()));
        }

        [HttpDelete]
        [Route("companies/{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices] ICompanyRepository companyRepository)
        {
            await companyRepository.DeleteAsync(id);
            return Ok("Removido com sucesso!");
        }

        [HttpGet]
        [Route("companies")]
        public async Task<IEnumerable<ICompany>> Get([FromServices] ICompanyRepository companyRepository)
        {
            return await companyRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("companies/{id}")]
        public async Task<ICompany> GetById(int id, [FromServices] ICompanyRepository companyRepository)
        {
            return await companyRepository.GetAsync(id);
        }

        [HttpPut]
        [Route("companies")]
        public async Task<IActionResult> PutAsync(UpdateCompanyRequest company, [FromServices] ICompanyRepository companyRepository)
        {
            return Ok(await companyRepository.SaveAsync(company.ToCompany()));
        }

        
    }
}
