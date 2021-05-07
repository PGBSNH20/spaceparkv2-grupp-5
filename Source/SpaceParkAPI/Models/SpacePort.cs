﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class SpacePort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParkingSpots { get; set; }
        public string UserName { get; set; }
    }
}
