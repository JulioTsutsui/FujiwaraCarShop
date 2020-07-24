using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FujiwaraCarShop.Data;
using FujiwaraCarShop.Models;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FujiwaraCarShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly FujiwaraCarShopContext _context;

        public AdminController(FujiwaraCarShopContext context)
        {
            _context = context;
        }
        public IActionResult Login() {
            return View("~/Views/Admin/Login.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Login,Password")] User user) {
            if (await _context.User.AnyAsync(users => users.Login == user.Login && users.Password == user.Password)) {
                string key = "AUTH_TOKEN_COOKIE";
                string value = user.ToString();
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Append(key, value, cookieOptions);
                return RedirectToAction(nameof(Index));
            }
            TempData["Login"] = 1;
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Logout() {
            if (Request.Cookies["AUTH_TOKEN_COOKIE"] == null) {
                return BadRequest();
            }
            string key = "AUTH_TOKEN_COOKIE";
            string value = "";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Append(key, value, cookieOptions);
            return RedirectToAction("Index", "Home");
        }
        // GET: Vehicles
        public async Task<IActionResult> Index()
        {

            if (Request.Cookies["AUTH_TOKEN_COOKIE"] == null) {
                return Unauthorized();
            }
            var fujiwaraCarShopContext = _context.Vehicle.Include(v => v.Brand).Include(v => v.Type);
            return View("~/Views/Admin/Vehicles/Index.cshtml",await fujiwaraCarShopContext.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (Request.Cookies["AUTH_TOKEN_COOKIE"] == null) {
                return Unauthorized();
            }
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Brand)
                .Include(v => v.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Vehicles/Details.cshtml",vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            if (Request.Cookies["AUTH_TOKEN_COOKIE"] == null) {
                return Unauthorized();
            }
            ViewData["VehicleBrandName"] = new SelectList(_context.VehicleBrand, "Id", "Name");
            ViewData["VehicleTypeName"] = new SelectList(_context.VehicleType, "Id", "Name");
            return View("~/Views/Admin/Vehicles/Create.cshtml");
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Year,Price,VehicleBrandId,VehicleTypeId,Photo")] Vehicle vehicle)
        {
            if (Request.Cookies["AUTH_TOKEN_COOKIE"] == null) {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {

                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleBrandName"] = new SelectList(_context.VehicleBrand, "Id", "Name", vehicle.VehicleBrandId);
            ViewData["VehicleTypeName"] = new SelectList(_context.VehicleType, "Id", "Name", vehicle.VehicleTypeId);
            return View("~/Views/Admin/Vehicles/Create.cshtml",vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (Request.Cookies["AUTH_TOKEN_COOKIE"] == null) {
                return Unauthorized();
            }
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["VehicleBrandName"] = new SelectList(_context.VehicleBrand, "Id", "Name", vehicle.VehicleBrandId);
            ViewData["VehicleTypeName"] = new SelectList(_context.VehicleType, "Id", "Name", vehicle.VehicleTypeId);
            return View("~/Views/Admin/Vehicles/Edit.cshtml",vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year,Price,VehicleBrandId,VehicleTypeId,Photo")] Vehicle vehicle)
        {
            if (Request.Cookies["AUTH_TOKEN_COOKIE"] == null) {
                return Unauthorized();
            }
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleBrandName"] = new SelectList(_context.VehicleBrand, "Id", "Name", vehicle.VehicleBrandId);
            ViewData["VehicleTypeName"] = new SelectList(_context.VehicleType, "Id", "Name", vehicle.VehicleTypeId);
            return View("~/Views/Admin/Vehicles/Edit.cshtml",vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (Request.Cookies["AUTH_TOKEN_COOKIE"] == null) {
                return Unauthorized();
            }
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Brand)
                .Include(v => v.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/Vehicles/Delete.cshtml",vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (Request.Cookies["AUTH_TOKEN_COOKIE"] == null) {
                return Unauthorized();
            }
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
