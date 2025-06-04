using System.Linq.Expressions;
using Core.Common;

namespace Core.Criterias;

public class Criteria<T>
{
    private ParameterExpression _parameter;
    public Expression Value { get; }

    private Criteria(Expression value, ParameterExpression parameter) { Value = value; _parameter = parameter; }

    public static Criteria<T> Success => new(Expression.Constant(true), Expression.Parameter(typeof(T)));

    public static Criteria<T> Build<P>(string propertyName, string operatorType, P value)
    {
        var parameter = Expression.Parameter(typeof(T));
        var expression = ExpressionBuilder.CreateExpression(value, null, propertyName, parameter, operatorType);
        return new Criteria<T>(expression, parameter);
    }

    public static Criteria<T> Build<P>(string propertyName, string operatorType, P value, bool condition)
    {
        if (!condition)
            return Success;
        var parameter = Expression.Parameter(typeof(T));
        var expression = ExpressionBuilder.CreateExpression(value, null, propertyName, parameter, operatorType);
        return new Criteria<T>(expression, parameter);
    }

    public Criteria<T> And<P>(string propertyName, string operatorType, P? value)
    {
        var expression = ExpressionBuilder.CreateExpression(value, Value, propertyName, _parameter, operatorType);
        return new Criteria<T>(expression, _parameter);
    }

    public Criteria<T> And<P>(string propertyName, string operatorType, P? value, bool condition)
    {
        if (!condition)
            return this;
        var expression = ExpressionBuilder.CreateExpression(value, Value, propertyName, _parameter, operatorType);
        return new Criteria<T>(expression, _parameter);
    }

    public Expression<Func<T, bool>> ToExpression()
    {
        return Expression.Lambda<Func<T, bool>>(Value, _parameter);
    }
}