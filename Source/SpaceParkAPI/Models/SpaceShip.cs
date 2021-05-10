using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class SpaceShips
    {
        public int Count { get; set; }
        public List<SpaceShip> Results { get; set; }
        public string Next { get; set; }
    }

    public class SpaceShip
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Length { get; set; }
    }
}
