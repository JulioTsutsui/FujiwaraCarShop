using FujiwaraCarShop.Models;
using Microsoft.EntityFrameworkCore;

namespace FujiwaraCarShop.Data {
    public class FujiwaraCarShopContext: DbContext  {

        public FujiwaraCarShopContext(DbContextOptions<FujiwaraCarShopContext> options):base(options) {

        }
        public DbSet<VehicleBrand> VehicleBrand { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<User> User { get; set; }

    }
}
