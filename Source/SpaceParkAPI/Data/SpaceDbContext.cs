using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Data
{
    public class SpaceDbContext : DbContext
    {
        public SpaceDbContext(DbContextOptions<SpaceDbContext> options) :base(options)
        {
            
        }

        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<SpaceShip> SpaceShips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Parking> Parkings { get; set; }


    }
}
