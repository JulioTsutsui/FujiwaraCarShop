using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FujiwaraCarShop.Models {
    public class VehicleBrand {
        public int Id { get; set; }

        public string Name { get; set; }

        public VehicleBrand(string name) {
            Name = name;
        }
        public VehicleBrand() {

        }
    }
}
