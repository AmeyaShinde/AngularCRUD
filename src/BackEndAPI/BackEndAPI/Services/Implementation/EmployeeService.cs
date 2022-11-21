using BackEndAPI.Models;
using BackEndAPI.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DBEmployeeContext _context;

        public EmployeeService(DBEmployeeContext context)
        {
            _context = context;
        }

        public async Task<Employee> Add(Employee model)
        {
            try
            {
                _context.Employees.Add(model);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Employee model)
        {
            try
            {
                _context.Employees.Remove(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> Get(int id)
        {
            try
            {
                Employee employee = new Employee();
                employee = await _context.Employees.Include(dpt => dpt.Department)
                    .Where(e => e.Id == id)
                    .FirstOrDefaultAsync();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Employee>> GetList()
        {
            try
            {
                List<Employee> employeeList = new List<Employee>();
                employeeList = await _context.Employees.Include(dpt => dpt.Department).ToListAsync();

                return employeeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> Update(Employee model)
        {
            try
            {
                _context.Employees.Update(model);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
