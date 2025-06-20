using API.DTOs;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController(IGenericRepository<Product> repo) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDTO>>> GetProducts([FromQuery]ProductSpecParams specParams)
        {
            var spec = new ProductSpecification(specParams);
            return await CreatePagedResult<Product, ProductDTO>(
                repo, 
                spec, 
                p => p.ToDTO(), 
                specParams.PageIndex, 
                specParams.PageSize
            );
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
