using Microsoft.EntityFrameworkCore;
using SoftlogicLife.Data;
using SoftlogicLife.Models;

namespace SoftlogicLife.Services.EmployeeService
{
    public class EmployeeService:IEmployeeService
    {
        private readonly SoftlogicLifeDbContext _dbContext;

        public EmployeeService(SoftlogicLifeDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<List<Employee>?> AddEmployee(Employee employee)
        {
            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>?> DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == id);
            if (employee == null)
                return null;
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Employees.ToListAsync();

        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee?> GetSingleEmployee(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == id);
            if (employee == null)
                return null;
            return employee;
        }

        public async Task<List<Employee>?> UpdateEmployee(int id, Employee employee)
        {
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == id);
            if (emp == null)
                return null;
            emp.Name = employee.Name;

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Employees.ToListAsync();
        }

    }
}
