using InventoryManagementCore.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required] [EmailAddress]
        [Remote(action: "IsEmailInUse",controller: "Account")]
        [ValidEmailDomain(allowedDomain: "gmail.com",
            ErrorMessage = "Email domain must be gmail.com")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
