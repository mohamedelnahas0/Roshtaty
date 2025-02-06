using Roshtaty.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Specifications
{
    public class TradesSpecification : BaseSpecifications<Trades>
    {
        public TradesSpecification(string sort) : base()
        {
           Includes.Add(P=> P.Active_Ingredient);


            //Criteria = t => t.Active_Ingredient.ActiveIngredientName == activeIngredientName &&
            //            t.Active_Ingredient.Strength == strength &&
            //            t.Active_Ingredient.StrengthUnit == strengthUnit;


            if (!string.IsNullOrEmpty(sort))
            {
                    switch(sort)
                {
                    case "PriceAsc":
                        AddOrderBy(P => P.PublicPrice);
                        break;
                    case "PriceDesc":
                        AddOrderByDescending(P=>P.PublicPrice);
                        break;
                    default:
                        AddOrderBy(P => P.TradeName);
                        break;
                }
            }
        }

        public TradesSpecification(int id) : base(P => P.Id == id)
        {
            Includes.Add(P => P.Active_Ingredient);
        }



    }
}
