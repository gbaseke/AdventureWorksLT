using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string? name, string? sort, int priceMin = 0)
        {
            var spec = new ProductSpecification(name, sort, priceMin);
            var products = await repo.ListAsync(spec);
            return Ok(products);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);

            return product.Match<ActionResult<Product>>(
                Some: p => Ok(p),
                None: () => NotFound() 
            );
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.Add(product);
            await repo.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductID }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductID || !repo.EntityExists(id))
            {
                return BadRequest("Cannot update product");
            }

            repo.Update(product);
            await repo.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);

            return product.Match<IActionResult>(
                Some: p => 
                {
                    repo.Delete(p);
                    //await repo.SaveChangesAsync();
                    return NoContent();
                },
                None: () => NotFound()
            );
        }
    }
}
