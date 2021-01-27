using InventoryManagementCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Controllers
{
    public class StockController:Controller
    {
        private readonly IStock _stocks;

        public StockController(IStock stocks)
        {
            _stocks = stocks;
        }

        public ViewResult Index()
        {
            GetAllStock();
            return View();
        }
        public string GetAllStock()
        {
            var list = _stocks.GetAllStock();
            string result = JsonConvert.SerializeObject(list, Formatting.None);
            return result;
        }
        [HttpPost]
        public IActionResult AddStock([FromBody]Stock obj)
        {
            _stocks.AddStock(obj);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateStock([FromBody]Stock obj)
        {
            _stocks.UpdateStock(obj);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteStock(int id)
        {
            _stocks.DeleteStock(id);
            return RedirectToAction("Index");
        }
    }
}
