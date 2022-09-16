using Dapper;
using DapperExample.Context;
using DapperExample.DTOs;
using DapperExample.Entities;
using System.Data;

namespace DapperExample.Repository
{
    public class EmployeeRepository : IEmployeeRepository      
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context) => _context = context;

        async Task<Employee> IEmployeeRepository.GetById(int id)
        {
            string query = "SELECT * FROM Employees WHERE Id = @Id";

            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                Employee employee = await dbConnection.QuerySingleOrDefaultAsync<Employee>(query, new { id });

                return employee;
            }
        }

        async Task<IEnumerable<Employee>> IEmployeeRepository.GetAll()
        {
            string query = "SELECT * FROM Employees";

            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                IEnumerable<Employee> employees = await dbConnection.QueryAsync<Employee>(query);
                return employees;
            }
        }

        public async Task<Employee> Create(EmployeeForCreationDTO employee)
        {
            string query = " INSERT INTO Employees ( Name , Age , Position, CompanyId ) VALUES ( @Name , @Age , @Position, @CompanyId ) " +
                "SELECT CAST(SCOPE_IDENTITY() AS int)";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("Age", employee.Age, DbType.String);
            parameters.Add("Position", employee.Position, DbType.String);
            parameters.Add("CompanyId", employee.CompanyId, DbType.String);

            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                int id = await dbConnection.QuerySingleAsync<int>(query, parameters);

                return new Employee
                {
                    Id = id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Position = employee.Position,
                    CompanyId = employee.CompanyId,
                };
            }

        }

        public async Task Update(int id, EmployeeForCreationDTO employee)
        {
            string query = "UPDATE Employees SET Name = @Name , Age = @Age , Position = @Position , CompanyId = @CompanyId WHERE Id = @Id";
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("Age", employee.Age, DbType.String);
            parameters.Add("Position", employee.Position, DbType.String);
            parameters.Add("CompanyId", employee.CompanyId, DbType.String);

            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                await dbConnection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Delete(int id)
        {
            string query = "DELETE FROM Employees WHERE id = @Id";
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                await dbConnection.ExecuteAsync(query, new { id });
            }
        }
    }
}
