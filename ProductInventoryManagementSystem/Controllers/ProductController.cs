using Microsoft.AspNetCore.Mvc;
using ProductInventoryManagementSystem.Models;

namespace ProductInventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        
        public readonly Repository.IProductInventory<Product> _productInventory;

        public ProductController(Repository.IProductInventory<Product> productInventory)
        {
            _productInventory = productInventory;
            
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products=await _productInventory.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productInventory.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var addedProduct = await _productInventory.AddAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = addedProduct.CategoryId }, addedProduct);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var updatedProduct = await _productInventory.UpdateAsync(product);
            return Ok(updatedProduct);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deletedProduct = await _productInventory.DeleteAsync(id);
            if (deletedProduct == null)
            {
                return NotFound();
            }
            return Ok(deletedProduct);
        }



        
    }
}
