using DapperExample.Commands;
using DapperExample.DTOs;
using DapperExample.Entities;
using DapperExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            IEnumerable<Employee> employees = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(employees);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Employee>> getById(int id)
        {
            Employee employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> create([FromBody] EmployeeForCreationDTO employee)
        {
            Employee createdEmplyee = await _mediator.Send(new AddEmployeeCommand(employee));
            return Ok(createdEmplyee);
        }


        [HttpPut, Route("{id}")]
        public async Task<ActionResult> update(int id, [FromBody] EmployeeForCreationDTO employee)
        {
            await _mediator.Send(new UpdateEmployeeCommand(id, employee));
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return Ok(id);
        }
    }
}
