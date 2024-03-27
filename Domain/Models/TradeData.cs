using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TradeData
    {
        public string Symbol {  get; set; }
        public DateTime? TradeTime { get; set; }
        public decimal? Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
