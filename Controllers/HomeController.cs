using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FujiwaraCarShop.Models;
using FujiwaraCarShop.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

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
            ViewBag.Brands = await _context.VehicleBrand.ToListAsync();
            return View(await fujiwaraCarShopContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Brand)
                .Include(v => v.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null) {
                return NotFound();
            }
            return View(vehicle);
        }

        public async Task<IActionResult> Brand(int? id) {
            if(id == null) {
                return NotFound();
            }
            var brand = await _context.VehicleBrand.FirstOrDefaultAsync(model => model.Id == id);
            if(brand == null) {
                return NotFound();
            }
            ViewBag.Brand = brand;
            var vehicle = _context.Vehicle.Include(v => v.Brand).Include(v => v.Type).Where(model => model.Brand.Id == id);
            return View(vehicle);
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
