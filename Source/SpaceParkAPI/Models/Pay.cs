using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class Pay
    {
        public int Id { get; set; }
        [ForeignKey("ParkID")]
        public int ParkID { get; set; }
        public Park Park { get; set; }
        public int Invoice { get; set; }
        public DateTime DepartTime { get; set; }


    }
}
