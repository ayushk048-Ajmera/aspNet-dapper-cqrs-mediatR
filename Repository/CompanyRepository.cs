using Dapper;
using DapperExample.Context;
using DapperExample.DTOs;
using DapperExample.Entities;
using System.Data;

namespace DapperExample.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context) => _context = context;

        async Task<Company> ICompanyRepository.create(CompanyForCreationDTO company)
        {
            string query = " INSERT INTO Companies ( Name , Address , Country ) VALUES ( @Name , @Address , @Country ) " + 
                "SELECT CAST(SCOPE_IDENTITY() AS int)";
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Name", company.Name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);

            using (IDbConnection dbConnection = _context.CreateConnection()) {
                dynamic id = await dbConnection.QuerySingleAsync<int>(query, parameters);

                return new Company
                {
                    Id = id,
                    Name = company.Name,
                    Address = company.Address,
                    Country = company.Country,
                };
            }
        }

        async Task ICompanyRepository.Delete(int id)
        {
            string query = "DELETE FROM Companies WHERE id = @Id";
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                await dbConnection.ExecuteAsync(query, new { id });
            }
        }

        async Task<IEnumerable<Company>> ICompanyRepository.GetAll()
        {
            string query = "SELECT * FROM Companies";
            
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                IEnumerable<Company> companies = await dbConnection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }

        async Task<Company> ICompanyRepository.GetById(int id)
        {
            string query = "SELECT * FROM Companies WHERE Id = @Id";

            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                Company employee = await dbConnection.QuerySingleOrDefaultAsync<Company>(query, new { id });

                return employee;
            }
        }

        async Task ICompanyRepository.Update(int id, CompanyForCreationDTO company)
        {
            string query = " UPDATE Companies SET Name = @Name , Address = @Address , Country = @Country WHERE Id = @Id ";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", company.Name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);

            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                await dbConnection.ExecuteAsync(query, parameters);
            }

        }
    }
}
