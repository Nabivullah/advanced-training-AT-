using Microsoft.EntityFrameworkCore;
using ProductInventoryManagementSystem.Models;

namespace ProductInventoryManagementSystem.Repository
{
    public class ProductInventory <T> : IProductInventory <T> where T : class
    {
        public readonly ProductInventoryContext _context;
        public ProductInventory(ProductInventoryContext context)
        {
            _context = context;
            _context.Set<T>();
        }

        public async Task<T> AddAsync(T product)
        {
            await _context.Set<T>().AddAsync(product); 
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<T> DeleteAsync(int productId)
        {
            var product =await _context.Set<T>().FindAsync(productId);
            if (product != null)
            {
                _context.Set<T>().Remove(product);
                await _context.SaveChangesAsync();
            }

            return product;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var products = await _context.Set<T>().ToListAsync();
            return products;
        }


        public async Task<T?> GetByIdAsync(int productId)
        {
            var product = await _context.Set<T>().FindAsync(productId);
            return product;
        }

        public async Task<T> UpdateAsync(T product)
        {
            var updatedProduct = _context.Set<T>().Update(product).Entity;
            await _context.SaveChangesAsync();
            return updatedProduct;
        }
    }
}
