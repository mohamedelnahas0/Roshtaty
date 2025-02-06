using Roshtaty.Core.Entites;

namespace Roshtaty.DTOS
{
    public class DiseasesToReturnDTO
    {
        public int id { get; set; }
        public string DiseaseName { get; set; }
        public int CategoryId { get; set; } //Fk
        public string Category { get; set; }
    }
}
