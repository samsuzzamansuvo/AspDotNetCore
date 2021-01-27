using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models
{
    public class StockRepository : IStock
    {
        private readonly InventoryDbContext _db;

        public StockRepository( InventoryDbContext db)
        {
            _db = db;
        }
        public Stock AddStock(Stock obj)
        {
            _db.Stocks.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public Stock DeleteStock(int id)
        {
            Stock sto = _db.Stocks.FirstOrDefault(s => s.StockId == id);
            if (sto!=null)
            {
                _db.Stocks.Remove(sto);
                _db.SaveChanges();
            }
            return sto;
        }

        public List<Stock> GetAllStock()
        {
            return _db.Stocks.ToList();
        }

        public Stock GetStock(int id)
        {
            Stock sto = _db.Stocks.FirstOrDefault(s => s.StockId == id);
            return sto;
        }

        public Stock UpdateStock(Stock changeStock)
        {
            Stock sto = _db.Stocks.FirstOrDefault(s => s.StockId ==changeStock.StockId);
            sto.ProductName = changeStock.ProductName;
            sto.Quantiti = changeStock.Quantiti;
            _db.SaveChanges();
            return changeStock;
        }
    }
}
