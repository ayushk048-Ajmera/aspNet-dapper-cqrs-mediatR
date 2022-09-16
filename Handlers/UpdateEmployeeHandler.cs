using DapperExample.Commands;
using DapperExample.Repository;
using MediatR;

namespace DapperExample.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

        async Task<Unit> IRequestHandler<UpdateEmployeeCommand, Unit>.Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeRepository.Update(request.id, request.employee);
            return Unit.Value;
        }
    }
}
