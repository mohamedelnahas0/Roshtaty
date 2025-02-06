using Roshtaty.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Specifications
{
    public interface ISpecifications<T> where T : BaseEntity
    {
       // _roshtatyContext.categories.Include(p => p.MainSystem).ToListAsync()

        //Sign for prop (Where Condition)

        public Expression<Func <T, bool>> Criteria { get; set; }


        //Sign For Prop (list of Includes)

        public  List<Expression<Func<T,object>>> Includes { get; set; }
        // Property For OrderBy
        public Expression<Func<T, Object>> OrderBy {  get; set; }
        // Property For OrderByDes
        public Expression<Func<T, Object>> OrderByDescending { get; set; }

    }
}
