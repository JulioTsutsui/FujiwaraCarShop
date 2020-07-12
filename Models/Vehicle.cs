using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FujiwaraCarShop.Models {
    public class Vehicle {
        public Vehicle() {

        }
        public Vehicle(string name, int year, double price, VehicleBrand brand, VehicleType type, string photo) {
            Name = name;
            Year = year;
            Price = price;
            Brand = brand;
            Type = type;
            Photo = photo;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public double Price { get; set; }

        public VehicleBrand Brand { get; set; }

        public VehicleType Type { get; set; }

        public string Photo { get; set; }

        
    }
}
