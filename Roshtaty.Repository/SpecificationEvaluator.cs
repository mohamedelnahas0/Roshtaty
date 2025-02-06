using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Roshtaty.Core.Entites;
using Roshtaty.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Repository
{
    public static class SpecificationEvaluator<T> where T : BaseEntity
    {
       //Function To build Query Dynamic 

         public static IQueryable<T> GetQuery(IQueryable<T> InputQuery , ISpecifications<T> specifications)
        {
            var Query = InputQuery;
            if (specifications.Criteria is not null) 
            { 
            Query = Query.Where(specifications.Criteria);
            }
            if(specifications.OrderBy is not null)
            {
                Query = Query.OrderBy(specifications.OrderBy);
            }
            if(specifications.OrderByDescending is not null)
            {
                Query = Query.OrderByDescending(specifications.OrderByDescending);
            }




            Query = specifications.Includes.Aggregate(Query, (CurrentQuery, IncludeExpression)
                => CurrentQuery.Include(IncludeExpression)
            );
            return Query;


        }
    }
}
