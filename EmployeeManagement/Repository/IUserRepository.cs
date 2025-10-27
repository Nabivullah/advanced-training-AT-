using EmployeeManagement.Models;

namespace EmployeeManagement.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllAsync();

        public Task<User?> GetByIdAsync(int id);

        public Task AddAsync(User User);

        public Task UpdateAsync(User User);

        public Task DeleteAsync(int id);
    }
}
