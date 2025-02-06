using Roshtaty.Core.Entites;

namespace Roshtaty.DTOS
{
    public class TradesToReturnDTO
    {
        public int id { get; set; }
        public string TradeName { get; set; }
        public string Indication { get; set; }
        public string SideEffects { get; set; }
        public decimal PublicPrice { get; set; }
        public decimal ShelfLife { get; set; }
        public string StorageConditions { get; set; }
        public string ManufactureCountry { get; set; }
        public string Dose { get; set; }
        public string PharmaceuticalForm { get; set; }
        public string AdministrationRoute { get; set; }
        public string PackageTypes { get; set; }
        public decimal PackageSize { get; set; }
        public string LegalStatus { get; set; }
        public string DistributeArea { get; set; }
        public string ProductControl { get; set; }
        public int Active_IngredientId { get; set; } 
        public string Active_Ingredient { get; set; }
    }
}
