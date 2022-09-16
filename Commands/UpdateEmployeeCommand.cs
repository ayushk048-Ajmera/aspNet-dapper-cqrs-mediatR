using DapperExample.DTOs;
using MediatR;

namespace DapperExample.Commands
{
    public record UpdateEmployeeCommand(int id, EmployeeForCreationDTO employee): IRequest;
}
