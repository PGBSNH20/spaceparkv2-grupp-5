using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        
        [ForeignKey("SpacePort")]
        public int SpacePortId { get; set; }
        
        public string PersonName { get; set; }
        
        public string SpaceShip { get; set; }
        
        public DateTime ArrivalTime { get; set; }
        
        public DateTime? EndTime { get; set; }

        public decimal Price { get; set; }

        public bool Payed { get; set; }


    }
}
