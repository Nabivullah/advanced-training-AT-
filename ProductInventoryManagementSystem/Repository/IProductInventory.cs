namespace ProductInventoryManagementSystem.Repository
{
    public interface IProductInventory <T> where T : class
    {

        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int productId);
        public Task<T> AddAsync(T product);    
        public Task<T> UpdateAsync(T product);
        public Task<T> DeleteAsync(int productId);


    }
}
