using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public int ParkingId { get; set; }
        public int UserId { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }


    }
}
