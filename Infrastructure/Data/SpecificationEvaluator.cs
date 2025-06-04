using Core.Interfaces;

namespace Infrastructure.Data;

public class SpecificationEvaluator<T>
    where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        query = query.Where(spec.Criteria);

        spec.OrderBy.Match(
            Some: orderBy => query = query.OrderBy(orderBy),
            None: () => { }
        );

        spec.OrderByDescending.Match(
            Some: orderByDesc => query = query.OrderByDescending(orderByDesc),
            None: () => { }
        );

        return query;
    }
}
