using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepo : IEmployeeRepository
    {

        public readonly EmployeeDbContext _context;
        public EmployeeRepo(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return;
        }

        public async Task DeleteAsync(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees =await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var existingEmployee = _context.Employees.Find(employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.FullName = employee.FullName;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.Email = employee.Email;
                _context.SaveChanges();
            }
            return;
        }
    }
}
