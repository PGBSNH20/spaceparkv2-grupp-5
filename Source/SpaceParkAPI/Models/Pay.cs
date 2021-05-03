using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class Pay
    {
        public int Id { get; set; }

        public DateTime EndTime { get; set; }

        public decimal Price { get; set; }

        public int ParkId { get; set; }

        public virtual Park Park { get; set; }
    }
}
