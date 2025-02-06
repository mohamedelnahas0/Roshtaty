using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Entites
{
    public class Active_Ingredient:BaseEntity
    {
        public string ActiveIngredientName { get; set; }
        public decimal Strength { get; set; }
        public string StrengthUnit { get; set; }

        public int DiseaseId { get; set; } //Fk
        public Disease Disease { get; set; }
    }
}
