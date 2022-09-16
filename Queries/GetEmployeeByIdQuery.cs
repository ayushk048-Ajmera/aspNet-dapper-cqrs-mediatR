using DapperExample.Entities;
using MediatR;

namespace DapperExample.Queries
{
    public record GetEmployeeByIdQuery(int id): IRequest<Employee>;
}
