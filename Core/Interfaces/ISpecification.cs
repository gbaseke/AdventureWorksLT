using System;
using System.Linq.Expressions;
using LanguageExt;

namespace Core.Interfaces;

public interface ISpecification<T>
{
    Option<Expression<Func<T, bool>>> Criteria { get; }
    Option<Expression<Func<T, object>>> OrderBy { get; }
    Option<Expression<Func<T, object>>> OrderByDescending { get; }
}
