using DapperExample.DTOs;
using DapperExample.Entities;
using System.Runtime.CompilerServices;

namespace DapperExample.Repository
{
    public interface ICompanyRepository
    {
        public  Task<IEnumerable<Company>> GetAll();

        public Task<Company> GetById(int id);

        public Task<Company> create(CompanyForCreationDTO company);

        public Task Update(int id, CompanyForCreationDTO company);
        public Task Delete(int id);
    }
}
