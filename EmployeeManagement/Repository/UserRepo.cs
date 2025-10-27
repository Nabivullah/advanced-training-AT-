using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class UserRepo : IUserRepository
    {
        public readonly EmployeeDbContext _context;
        public UserRepo(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
            return;
        }

        public async Task DeleteAsync(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user =  _context.Users.Find(id);
            return user;
        }

        public async Task UpdateAsync(User User)
        {
            var existingUser = _context.Users.Find(User.UserId);
            if (existingUser != null)
            {
                existingUser.UserName = User.UserName;
                existingUser.Password = User.Password;
                existingUser.Role = User.Role;
                _context.SaveChanges();
            }
            return;
        }
    }
}
