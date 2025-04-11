using System;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class ProductRepository(StoreContext context) : IProductRepository
{
    private readonly StoreContext _context = context;

    public async Task<IReadOnlyList<Product>> GetProductsAsync(string? name, string? sort, int priceMin)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(p => p.Name.Contains(name));
        }

        if (priceMin > 0)
        {
            query = query.Where(p => p.ListPrice >= priceMin);
        }

        if (!string.IsNullOrEmpty(sort))
        {
            query = sort switch
            {
                "name" => query.OrderBy(p => p.Name),
                "price" => query.OrderBy(p => p.ListPrice),
                _ => query.OrderBy(p => p.ProductID)
            };
        }

        return await query.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
    }

    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
    }

    public bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.ProductID == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}

