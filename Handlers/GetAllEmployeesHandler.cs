using DapperExample.Entities;
using DapperExample.Queries;
using DapperExample.Repository;
using MediatR;

namespace DapperExample.Handlers
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        IEmployeeRepository _employeeRepository;

        public GetAllEmployeesHandler(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;
        

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken) => await _employeeRepository.GetAll();
    }
}
