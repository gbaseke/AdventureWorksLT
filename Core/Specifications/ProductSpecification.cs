using Core.Criterias;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecParams specParams)
        : base(
            Criteria<Product>.Build<Decimal>("ListPrice", ">", specParams.PriceMin, specParams.PriceMin > 0)
            .And<string?>("Name", "StartsWith", specParams.Name, !string.IsNullOrEmpty(specParams.Name)
            ).ToExpression())

    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        switch (specParams.Sort)
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
