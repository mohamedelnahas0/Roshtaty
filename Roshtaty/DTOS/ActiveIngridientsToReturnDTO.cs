using Roshtaty.Core.Entites;

namespace Roshtaty.DTOS
{
    public class ActiveIngridientsToReturnDTO
    {
        public int id { get; set; }
        public string ActiveIngredientName { get; set; }
        public decimal Strength { get; set; }
        public string StrengthUnit { get; set; }

        public int DiseaseId { get; set; } //Fk
        public string Disease { get; set; }
    }
}
