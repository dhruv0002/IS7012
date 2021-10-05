using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;

namespace RealEstate.Data
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext (DbContextOptions<RealEstateContext> options)
            : base(options)
        {
        }

        public DbSet<RealEstate.Models.Agent> Agent { get; set; }

        public DbSet<RealEstate.Models.City> City { get; set; }

        public DbSet<RealEstate.Models.Dwelling> Dwelling { get; set; }

        public DbSet<RealEstate.Models.SalesOffice> SalesOffice { get; set; }
    }
}
