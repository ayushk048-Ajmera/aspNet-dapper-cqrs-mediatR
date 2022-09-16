using DapperExample.Entities;
using DapperExample.Queries;
using DapperExample.Repository;
using MediatR;

namespace DapperExample.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken) => await _employeeRepository.GetById(request.id);

    }
}
