
namespace Domain.Models
{
    public class TradeData
    {
        public string Symbol {  get; set; }
        public DateTime? ChangeTime { get; set; }
        public decimal Price { get; set; }
    }
}
