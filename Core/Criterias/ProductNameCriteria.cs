using System.Linq.Expressions;
using Core.Entities;

namespace Core.Criterias;

public class ProductNameCriteria : Criteria<Product>
{
    private readonly string? name;

    private ProductNameCriteria(string? name)
    {
        this.name = name;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        return x => string.IsNullOrEmpty(name) || x.Name.StartsWith(name);
    }

    public static ProductNameCriteria CreateNameCriteria(string? name)
    {
        return new ProductNameCriteria(name);
    }
}
