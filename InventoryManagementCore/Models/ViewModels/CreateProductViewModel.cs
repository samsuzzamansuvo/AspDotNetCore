using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models.ViewModels
{
    public class CreateProductViewModel
    {
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Enter Product Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Chose Your  Image")]
        public IFormFile UrlImage { get; set; }
        [Required(ErrorMessage = "Chose Your  Category")]
        public int CategoryId { get; set; }
    }
}
