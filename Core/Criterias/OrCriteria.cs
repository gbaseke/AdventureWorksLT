using System.Linq.Expressions;

namespace Core.Criterias;

public class OrCriteria<T> : Criteria<T>
{
    private readonly Criteria<T> _left;
    private readonly Criteria<T> _right;

    public OrCriteria(Criteria<T> left, Criteria<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();

        BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);

        return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters.Single());
    }
}
