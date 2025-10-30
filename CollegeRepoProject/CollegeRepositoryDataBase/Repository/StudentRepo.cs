using CollegeRepositoryDataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeRepositoryDataBase.Repository
{
    public class StudentRepo<T> : IstudentRepo<T> where T : class
    {
        private readonly NewCollegeDbContext _context;

        public StudentRepo(NewCollegeDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var existingEntity = await GetByIdAsync(id);
            if (existingEntity == null)
                return null; // Not found — handle this in controller

            // Copy updated values into the existing tracked entity
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
            return existingEntity;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
                return false;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(); 
            return true;
        }

        public async Task<T> GetByNameAsync(string name)
        {
            //return await _context.Set<T>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);
            // Check if this entity type has a "CourseName" property
            var entityType = typeof(T);
            var courseNameProp = entityType.GetProperty("CourseName");

            if (courseNameProp != null)
            {
                return await _context.Set<T>()
                    .FirstOrDefaultAsync(e => EF.Property<string>(e, "CourseName").ToLower().Trim() == name.ToLower().Trim());
            }

            // Fallback for entities that actually have "Name"
            return await _context.Set<T>()
                .FirstOrDefaultAsync(e => EF.Property<string>(e, "Name").ToLower().Trim() == name.ToLower().Trim());
        }
    }
}
