using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class Park
    {
        public int Id { get; set; }      
        public string UserName { get; set; }     
        public string SpaceShip { get; set; }     
        public DateTime ArrivalTime { get; set; }
        public bool Paid { get; set; }
        [Required]
        public int SpacePortId { get; set; }
        public virtual SpacePort SpacePort { get; set; }
    }
}
