﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Controllers
{
    [AllowAnonymous]
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
