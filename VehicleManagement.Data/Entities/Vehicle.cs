using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagement.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; } 
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Equipment { get; set; }
        public decimal Price {get;set;}
    }
}
