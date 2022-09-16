using DapperExample.Entities;
using MediatR;

namespace DapperExample.Queries
{
    public record GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>;
}
