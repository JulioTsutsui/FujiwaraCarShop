using FujiwaraCarShop.Models;
using System.Linq;

namespace FujiwaraCarShop.Data {
    public class SeedService {
        private readonly FujiwaraCarShopContext _context;

        public SeedService(FujiwaraCarShopContext context) {
            _context = context;
        }

        public void Seed() {
            if (_context.VehicleBrand.Any() || _context.VehicleType.Any() || _context.User.Any()) {
                return;
            }
            VehicleBrand vb1 = new VehicleBrand("Toyota");
            VehicleBrand vb2 = new VehicleBrand("Honda");
            VehicleBrand vb3 = new VehicleBrand("Nissan");
            VehicleBrand vb4 = new VehicleBrand("Ford");
            VehicleBrand vb5 = new VehicleBrand("BMW");
            VehicleBrand vb6 = new VehicleBrand("Suzuki");

            VehicleType vt1 = new VehicleType("Hatchback");
            VehicleType vt2 = new VehicleType("Sedan");
            VehicleType vt3 = new VehicleType("Pickup");
            VehicleType vt4 = new VehicleType("Sport");
            VehicleType vt5 = new VehicleType("Van");

            User user = new User("Dacioso", "admin", "123".GetHashCode().ToString(), true);

            _context.VehicleBrand.AddRange(vb1, vb2, vb3, vb4, vb5, vb6);
            _context.VehicleType.AddRange(vt1, vt2, vt3, vt4, vt5);
            _context.User.Add(user);

            _context.SaveChanges();
        }
    }
}
