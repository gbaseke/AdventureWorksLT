using System.Linq.Expressions;

namespace Core.Criterias;

public class AndCriteria<T> : Criteria<T>
{
    private readonly Criteria<T> _left;
    private readonly Criteria<T> _right;

    public AndCriteria(Criteria<T> left, Criteria<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();

        BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

        return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
    }
}
