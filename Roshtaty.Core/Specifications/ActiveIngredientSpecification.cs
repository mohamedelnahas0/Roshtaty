using Roshtaty.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Specifications
{
    public class ActiveIngredientSpecification : BaseSpecifications<Active_Ingredient>
    {
        public ActiveIngredientSpecification(): base() 
        {
            Includes.Add(P => P.Disease);
        }

        public ActiveIngredientSpecification(int id) : base(P => P.Id == id)
        {
            Includes.Add(P => P.Disease);
        }
    }
}
