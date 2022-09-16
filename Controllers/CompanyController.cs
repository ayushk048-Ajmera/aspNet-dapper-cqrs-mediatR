using DapperExample.DTOs;
using DapperExample.Entities;
using DapperExample.Queries;
using DapperExample.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IMediator _mediator;

        public CompanyController(ICompanyRepository companyRepository, IMediator mediator)
        {
            _companyRepository = companyRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Company>> getAll()
        {

            IEnumerable<Company> compnies = await _companyRepository.GetAll();
            return compnies.ToList();
        }


        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Company>> getById(int id)
        {
            Company company = await _companyRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> create([FromBody] CompanyForCreationDTO company)
        {
            Company createCompany = await _companyRepository.create(company);
            return Ok(createCompany);
        }

        [HttpPut, Route("{id}")]
        public async Task<ActionResult> update(int id,[FromBody] CompanyForCreationDTO company) {
            await _companyRepository.Update(id, company);
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            await _companyRepository.Delete(id);
            return Ok(id);
        }
    }
}
