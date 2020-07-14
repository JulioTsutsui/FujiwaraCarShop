using System.ComponentModel.DataAnnotations;
namespace FujiwaraCarShop.Models {
    public class Vehicle {
        public Vehicle() {

        }

        public Vehicle(string name, int year, double price, int vehicleBrandId, int vehicleTypeId, string photo) {
            Name = name;
            Year = year;
            Price = price;
            VehicleBrandId = vehicleBrandId;
            VehicleTypeId = vehicleTypeId;
            Photo = photo;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public VehicleBrand Brand { get; set; }
        public int VehicleBrandId { get; set; }
        public VehicleType Type { get; set; }
        public int VehicleTypeId { get; set; }
        public string Photo { get; set; }

        
    }
}
