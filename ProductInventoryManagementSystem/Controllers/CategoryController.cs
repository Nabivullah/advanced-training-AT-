using Microsoft.AspNetCore.Mvc;
using ProductInventoryManagementSystem.Models;

namespace ProductInventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        public readonly Repository.IProductInventory<Category> _categoryInventory;

        public CategoryController(Repository.IProductInventory<Category> categoryInventory)
        {
            _categoryInventory = categoryInventory;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            var products = await _categoryInventory.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var product = await _categoryInventory.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory([FromBody] Category product)
        {
            var addedProduct = await _categoryInventory.AddAsync(product);
            return CreatedAtAction(nameof(GetCategoryById), new { id = addedProduct.CategoryId }, addedProduct);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category product)
        {
            var updatedProduct = await _categoryInventory.UpdateAsync(product);
            return Ok(updatedProduct);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deletedProduct = await _categoryInventory.DeleteAsync(id);
            if (deletedProduct == null)
            {
                return NotFound();
            }
            return Ok(deletedProduct);
        }
    }
}
