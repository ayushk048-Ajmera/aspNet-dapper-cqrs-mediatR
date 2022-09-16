using DapperExample.Commands;
using DapperExample.Entities;
using DapperExample.Repository;
using MediatR;

namespace DapperExample.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AddEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken) => _employeeRepository.Create(request.employee);
    }
}
