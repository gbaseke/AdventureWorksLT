using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string? name, string? sort, int priceMin = 0)
        {
            var products = await repo.GetProductsAsync(name, sort, priceMin);   
            return Ok(products);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.AddProduct(product);
            await repo.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductID }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductID || !repo.ProductExists(id))
            {
                return BadRequest("Cannot update product");
            }

            repo.UpdateProduct(product);
            await repo.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
           
            repo.DeleteProduct(product);
            await repo.SaveChangesAsync();

            return NoContent();
        }
    }
}
