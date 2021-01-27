using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantiti { get; set; }
    }
}
