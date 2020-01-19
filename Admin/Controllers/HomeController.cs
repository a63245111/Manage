﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Admin.Models;
using Service.Interface;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IUserService _Service;

        public HomeController(ILogger<HomeController> logger, IUserService Service)
        {
            _logger = logger;
            _Service = Service;
        }

        public async Task<IActionResult> Index()
        {
            var Model = await _Service.DetailAsync(1);
            return View();
        }

        public IActionResult Login()
        {
            return View();        
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.Log(LogLevel.Error, 0, "页面报错");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
