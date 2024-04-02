using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GereMarkt.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GereMarket.Infraestructure.Persistence
{
    public class GereMarketDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public GereMarketDbContext(DbContextOptions<GereMarketDbContext> options) : base(options) 
        {
        
        }
    }
}
