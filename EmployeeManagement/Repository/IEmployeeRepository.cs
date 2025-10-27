using EmployeeManagement.Models;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllAsync();

        public Task<Employee?> GetByIdAsync(int id);

        public Task AddAsync(Employee employee);

        public Task UpdateAsync(Employee employee);

        public Task DeleteAsync(int id);
    }
}
