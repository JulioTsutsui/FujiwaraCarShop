using FujiwaraCarShop.Models;
using System.Linq;

namespace FujiwaraCarShop.Data {
    public class SeedService {
        private readonly FujiwaraCarShopContext _context;
        public SeedService(FujiwaraCarShopContext context) {
            _context = context;
        }

        public void Seed() {
            if (_context.Vehicle.Any() || _context.VehicleBrand.Any() || _context.VehicleType.Any()) {
                return;
            }

            VehicleType vt1 = new VehicleType("Carro");
            VehicleType vt2 = new VehicleType("Moto");

            VehicleBrand vb1 = new VehicleBrand("Toyota");
            VehicleBrand vb2 = new VehicleBrand("Honda");

            Vehicle v1 = new Vehicle("Toyota Corola", 2000, 15223.90, vb1, vt1, "/carro1.png");
            Vehicle v2 = new Vehicle("PCX", 2019, 9299.99, vb2, vt2, "/moto1.jpg");

            _context.VehicleBrand.AddRange(vb1, vb2);
            _context.VehicleType.AddRange(vt1, vt2);
            _context.Vehicle.AddRange(v1, v2);

            _context.SaveChanges();
        }
    }
}
