using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //Expression takes the function and fn takes a type returning a boolean vlaue
        //This is gonna be a criteria. What could be the criteria of the thing we are gonna get

        Expression<Func<T, bool>> Criteria {get;}
        List<Expression<Func<T, object>>> Includes {get;}
    }
}