using Core.Entities;

namespace Core.Criterias;

public class ProductPriceCriteria : Criteria<Product>
{
    private readonly decimal minPrice;

    private ProductPriceCriteria(decimal minPrice)
    {
        this.minPrice = minPrice;
    }

    public override System.Linq.Expressions.Expression<Func<Product, bool>> ToExpression()
    {
        return x => minPrice <= 0 || x.ListPrice >= minPrice;
    }

    public static ProductPriceCriteria CreatePriceCriteria(decimal minPrice)
    {
        return new ProductPriceCriteria(minPrice);
    }
}

