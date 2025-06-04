using System.Linq.Expressions;

namespace Core.Common;

// var pass = Expression.parameter(typeof(Product));
public static class ExpressionBuilder
{
    public static Expression CreateExpression<T>(T value, Expression? currentExpression, string propertyName, ParameterExpression objectParameter, string OperatorType)
    {
        var valueToTest = Expression.Constant(value);
        var propertyToCall = Expression.Property(objectParameter, propertyName);

        Expression operatorExpression;

        switch (OperatorType)
        {
            case "!=":
                operatorExpression = Expression.NotEqual(propertyToCall, valueToTest);
                break;
            case ">":
                operatorExpression = Expression.GreaterThan(propertyToCall, valueToTest);
                break;
            case "<":
                operatorExpression = Expression.LessThan(propertyToCall, valueToTest);
                break;
            case ">=":
                operatorExpression = Expression.GreaterThanOrEqual(propertyToCall, valueToTest);
                break;
            case "<=":
                operatorExpression = Expression.LessThanOrEqual(propertyToCall, valueToTest);
                break;
            case "StartsWith":
                operatorExpression = Expression.Call(propertyToCall, typeof(string).GetMethod("StartsWith", new[] { typeof(string) })!, valueToTest);
                break;
            default:
                operatorExpression = Expression.Equal(propertyToCall, valueToTest);
                break;
        }

        if (currentExpression == null)
        {
            currentExpression = operatorExpression;
        }
        else
        {
            var previousExpression = currentExpression;
            currentExpression = Expression.And(previousExpression, operatorExpression);
        }

        return currentExpression;
    }    
}
