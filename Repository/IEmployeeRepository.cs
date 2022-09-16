using DapperExample.DTOs;
using DapperExample.Entities;

namespace DapperExample.Repository
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAll();

        public Task<Employee> GetById(int id);

        public Task<Employee> Create(EmployeeForCreationDTO employee);

        public Task Update(int id, EmployeeForCreationDTO company);
        public Task Delete(int id);
    }
}
