using Core.Criterias;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(string? name, string? sort, int minPrice)
        : base(Criteria<Product>.Build<Decimal>("ListPrice", ">", minPrice, minPrice > 0)
            .And<string?>("Name", "StartsWith", name, !string.IsNullOrEmpty(name)).ToExpression())

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
