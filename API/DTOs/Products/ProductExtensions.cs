using Core.Entities;

namespace API.DTOs;

public static class ProductExtensions 
{
    public static ProductDTO ToDTO(this Product p)
    {
        return new ProductDTO
            {
                ProductID = p.ProductID,
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                Color = p.Color,
                StandardCost = p.StandardCost,
                ListPrice = p.ListPrice,
                Size = p.Size,
                Weight = p.Weight,
                SellStartDate = p.SellStartDate,
                SellEndDate = p.SellEndDate,
                DiscontinuedDate = p.DiscontinuedDate
            };
    }

    public static Product ToProduct(this CreateProductDTO p)
    {
        return new Product
            {
                ProductID = p.ProductID,
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                Color = p.Color,
                StandardCost = p.StandardCost,
                ListPrice = p.ListPrice,
                Size = p.Size,
                Weight = p.Weight,
                SellStartDate = p.SellStartDate,
                SellEndDate = p.SellEndDate,
                DiscontinuedDate = p.DiscontinuedDate
            };
    }
    
    public static Product ToProduct(this UpdateProductDTO p)
    {
        return new Product
            {
                ProductID = p.ProductID,
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                Color = p.Color,
                StandardCost = p.StandardCost,
                ListPrice = p.ListPrice,
                Size = p.Size,
                Weight = p.Weight,
                SellStartDate = p.SellStartDate,
                SellEndDate = p.SellEndDate,
                DiscontinuedDate = p.DiscontinuedDate
            };
    }
}
