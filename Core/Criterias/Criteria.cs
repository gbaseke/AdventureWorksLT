using System.Linq.Expressions;

namespace Core.Criterias;

public abstract class Criteria<T>
{
    public static readonly Criteria<T> All = new AllCriteria<T>();

    public bool IsSatisfiedBy(T item)
    {
        Func<T, bool> predicate = ToExpression().Compile();
        return predicate(item);
    }

    public abstract Expression<Func<T, bool>> ToExpression();
    public Criteria<T> And(Criteria<T> other)
    {
        if (this == All)
        {
            return other;
        }
        
        if (other == All)
        {
            return this;
        }

        return new AndCriteria<T>(this, other);
    }

    public Criteria<T> Or(Criteria<T> other)
    {
        if (this == All || other == All)
        {
            return All;
        }

        return new OrCriteria<T>(this, other);
    }
}
