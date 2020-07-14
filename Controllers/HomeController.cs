using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FujiwaraCarShop.Models;
using FujiwaraCarShop.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FujiwaraCarShop.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly FujiwaraCarShopContext _context;


        public HomeController(ILogger<HomeController> logger, FujiwaraCarShopContext context) {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index() {
            var fujiwaraCarShopContext = _context.Vehicle.Include(v => v.Brand).Include(v => v.Type);
            return View(await fujiwaraCarShopContext.ToListAsync());
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
