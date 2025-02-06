using Roshtaty.Core.Entites;

namespace Roshtaty.DTOS
{
    public class CategorisToReturnDTO
    {
        public int id { get; set; }
        public string CategoryName { get; set; }

        public int MainSystemId { get; set; } //Fk
        public string MainSystem { get; set; }
    }
}
