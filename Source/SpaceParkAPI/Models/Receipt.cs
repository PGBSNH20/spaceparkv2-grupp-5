using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Price { get; set; }
    }

}
