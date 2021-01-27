using InventoryManagementCore.Models;
using InventoryManagementCore.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Controllers
{
    public class ProductController:Controller
    {
        private IProductRepository _productRepository;
        private readonly IHostingEnvironment _hostingEnviroment;

        public ProductController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            _hostingEnviroment = hostingEnvironment;
        }

        public ActionResult Index(string sortOrder, string currentFilter, string searchstring, int? pageNumber)
        {
           
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchstring != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchstring = currentFilter;
            }
            ViewData["CurrentFilter"] = searchstring;
            var data = _productRepository.GetProducts();
            if (!String.IsNullOrEmpty(searchstring))
            {
                data = data.Where(p => p.ProductName.Contains(searchstring));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderByDescending(p => p.ProductName);
                    break;
                default:
                    data = data.OrderBy(p => p.ProductName);
                    break;
            }
            int pageSize = 3;
            return View(PaginatedList<Product>.
                Create(data.AsQueryable<Product>(), pageNumber ?? 1, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            CategoryDDL();
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string urlImage = "";
                var files = HttpContext.Request.Form.Files;
                foreach (var image in files)
                {
                    if (image != null && image.Length > 0)
                    {
                        var file = image;
                        var uploadFile = Path.Combine(_hostingEnviroment.WebRootPath, "Images");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("_", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploadFile, fileName), FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                                urlImage = fileName;
                            }
                        }
                    }
                }
                var data = new Product()
                {
                    ProductName = model.ProductName,
                    Price = model.Price,
                    CategoryId = model.CategoryId,
                    UrlImage = urlImage
                };
                _productRepository.AddProduct(data);
                return RedirectToAction("Index");
            }
            CategoryDDL();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            CategoryDDL();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product changeProduct)
        {
            if (ModelState.IsValid)
            {
                string UrlImage = "";
                var files = HttpContext.Request.Form.Files;
                foreach (var image in files)
                {
                    if (image != null && image.Length > 0)
                    {
                        var file = image;
                        var uploadFile = Path.Combine(_hostingEnviroment.WebRootPath, "Images");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("_", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploadFile, fileName), FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                                UrlImage = fileName;
                            }
                        }

                    }
                }
                var data = _productRepository.GetProductById(id);
                data.ProductName = changeProduct.ProductName;
                data.Price = changeProduct.Price;
                data.CategoryId = changeProduct.CategoryId;
                if (data.UrlImage != null)
                {
                    string fp = Path.Combine(_hostingEnviroment.WebRootPath, "Images", data.UrlImage);
                    System.IO.File.Delete(fp);
                }
                data.UrlImage = UrlImage;
                _productRepository.UpdateProduct(data);
                return RedirectToAction("Index");
            }
            CategoryDDL();
            return View();
        }
        private void CategoryDDL(object categorySelect = null)
        {
            var catgoryes = _productRepository.GetCategories();
            ViewBag.ListofCategry = new SelectList(catgoryes, "CategoryId", "CategoryName"
                , categorySelect);
        }
        public ActionResult Delete(int id)
        {
            _productRepository.DeleteProducr(id);
            return RedirectToAction("Index");
        }
    }
}
