using Core.Interfaces;

namespace Infrastructure.Data;

public class SpecificationEvaluator<T>
    where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        spec.Criteria.Match(
            Some: criteria => query = query.Where(criteria),
            None: () => { }
        );        

        spec.OrderBy.Match(
            Some: orderBy => query = query.OrderBy(orderBy),
            None: () => { }
        );

        spec.OrderByDescending.Match(
            Some: orderByDesc => query = query.OrderByDescending(orderByDesc),
            None: () => { }
        );

        if (spec.IsPagingEnabled)
        {
            query = query.Skip(spec.Skip).Take(spec.Take);
        }

        return query;
    }
}
