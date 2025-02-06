namespace Roshtaty.DTOS
{
    public class AddTradeNameDto
    {
        public string TradeName { get; set; }
     
        public decimal PublicPrice { get; set; }

        public int Quantity { get; set; }
        public string PharmaceuticalForm { get; set; }


        public string IngridientName { get; set; }

    }
}
