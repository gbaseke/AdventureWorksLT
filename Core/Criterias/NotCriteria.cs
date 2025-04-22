using System.Linq.Expressions;

namespace Core.Criterias;

public sealed class NotCriteria<T> : Criteria<T>
{
    private readonly Criteria<T> _criteria;

    public NotCriteria(Criteria<T> criteria)
    {
        _criteria = criteria;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var expression = _criteria.ToExpression();
        var notExpression = Expression.Not(expression.Body);

        return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
    }
}