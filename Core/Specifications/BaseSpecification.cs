using System.Linq.Expressions;
using Core.Interfaces;
using LanguageExt;

namespace Core.Specifications;

public class BaseSpecification<T>(Expression<Func<T, bool>> criteria) : ISpecification<T>
{
    protected BaseSpecification() : this(Expression.Lambda<Func<T, bool>>(Expression.Constant(true), Expression.Parameter(typeof(T)))) { }
    public Expression<Func<T, bool>> Criteria => criteria;
    public Option<Expression<Func<T, object>>> OrderBy { get; private set; }
    public Option<Expression<Func<T, object>>> OrderByDescending { get; private set; }

    protected void AddOrderBy(Expression<Func<T, Object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<T, Object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
}   

