using DapperExample.DTOs;
using DapperExample.Entities;
using MediatR;

namespace DapperExample.Commands
{
    public record AddEmployeeCommand(EmployeeForCreationDTO employee): IRequest<Employee>;
}
