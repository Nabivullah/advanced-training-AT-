using CollegeRepositoryDataBase.Models;

namespace CollegeRepositoryDataBase.Repository
{
    public interface IstudentRepo<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id); 
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(int id,T entity);
        public Task<bool> DeleteAsync(int id);
        public Task<T> GetByNameAsync(string name);
    }
}
