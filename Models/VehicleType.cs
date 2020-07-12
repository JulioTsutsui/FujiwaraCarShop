using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FujiwaraCarShop.Models {
    public class VehicleType {
        public int Id { get; set; }

        public string Name { get; set; }

        public VehicleType(string name) {
            Name = name;
        }
        public VehicleType() {

        }
    }
}
