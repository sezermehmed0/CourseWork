using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RentACarDBContext : DbContext
    {
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Customers>Customers { get; set; }
        public DbSet<Rental>Rental { get; set; }

    }
}