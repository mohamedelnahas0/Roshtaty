using Roshtaty.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Specifications
{
    public class CategorySpecifications: BaseSpecifications<Category>
    {
        public CategorySpecifications():base()
        {
            Includes.Add(P => P.MainSystem);
        }

        public CategorySpecifications(int id):base(P => P.Id == id) 
        {
            Includes.Add(P => P.MainSystem);
        }
    }
}
