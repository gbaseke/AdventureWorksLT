using System.Linq.Expressions;
using Core.Interfaces;
using LanguageExt;

namespace Core.Specifications;

public class BaseSpecification<T>(Option<Expression<Func<T, bool>>> criteria) : ISpecification<T>
{
    protected BaseSpecification() : this(Option<Expression<Func<T, bool>>>.None) { }
    public Option<Expression<Func<T, bool>>> Criteria => criteria;
    public Option<Expression<Func<T, object>>> OrderBy { get; private set; }
    public Option<Expression<Func<T, object>>> OrderByDescending { get; private set; }

    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; }

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }

    protected void AddOrderBy(Expression<Func<T, Object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<T, Object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
    
    public IQueryable<T> ApplyCriteria(IQueryable<T> query)
    {
        Criteria.Match(
            Some: criteria => query = query.Where(criteria),
            None: () => { }
        );        

        return query;
    }
}   

