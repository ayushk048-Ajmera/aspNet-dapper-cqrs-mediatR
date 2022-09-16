using MediatR;

namespace DapperExample.Commands
{
    public record DeleteEmployeeCommand(int id): IRequest;
}
