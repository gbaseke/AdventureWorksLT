using System.Linq.Expressions;
using Core.Criterias;
using Core.Entities;
using LanguageExt;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(string? name, string? sort, int minPrice) 
        : base(Option<Expression<Func<Product, bool>>>.Some(
            ProductNameCriteria.CreateNameCriteria(name)
            .And(ProductPriceCriteria.CreatePriceCriteria(minPrice))
            .ToExpression()))
    {
        switch (sort)
        {
            case "priceAsc":
                AddOrderBy(x => x.ListPrice);
                break;
            case "priceDesc":
                AddOrderByDescending(x => x.ListPrice);
                break;
            case "nameAsc":
                AddOrderBy(x => x.Name);
                break;
            case "nameDesc":
                AddOrderByDescending(x => x.Name);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;
        }
    }
}
