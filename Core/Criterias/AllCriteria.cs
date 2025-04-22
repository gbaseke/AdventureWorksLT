using System.Linq.Expressions;

namespace Core.Criterias;

public class AllCriteria<T> : Criteria<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return item => true;
    }
}
