using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models
{
    public interface IStock
    {
        List<Stock> GetAllStock();
        Stock GetStock(int id);
        Stock AddStock(Stock obj);
        Stock UpdateStock(Stock changeStock);
        Stock DeleteStock(int id);
    }
}
