using BackEndAPI.Models;
using BackEndAPI.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementation
{
    public class DepartmentService : IDeparmentService
    {
        private readonly DBEmployeeContext _context;

        public DepartmentService(DBEmployeeContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetList()
        {
            try
            {
                List<Department> departmentList = new List<Department>();
                departmentList = await _context.Departments.ToListAsync();

                return departmentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
