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

        public DbSet<Payment> Payments { get; set; }
        
        


    }
}
