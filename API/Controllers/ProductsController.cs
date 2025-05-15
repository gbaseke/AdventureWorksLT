using API.DTOs;
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
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts([FromQuery]SearchProductDTO dto)
        {
            var spec = new ProductSpecification(dto.Name, dto.Sort, dto.PriceMin);
            var products = await repo.ListAsync(spec);
            var dtos = products.Select(p => p.ToDTO()).ToList();
            return Ok(dtos);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);
            
            return product
            .Map(p => p.ToDTO())
            .Match<ActionResult<ProductDTO>>(
                Some: p => Ok(p),
                None: () => NotFound() 
            );
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductDTO product)
        {
            repo.Add(product.ToProduct());
            await repo.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductID }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDTO product)
        {
            if (id != product.ProductID || !repo.EntityExists(id))
            {
                return BadRequest("Cannot update product");
            }

            repo.Update(product.ToProduct());
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
