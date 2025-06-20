using System.Linq.Expressions;
using LanguageExt;

namespace Core.Interfaces;

public interface ISpecification<T>
{
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }
    Option<Expression<Func<T, bool>>> Criteria { get; }
    Option<Expression<Func<T, object>>> OrderBy { get; }
    Option<Expression<Func<T, object>>> OrderByDescending { get; }
    IQueryable<T> ApplyCriteria(IQueryable<T> query);
}
