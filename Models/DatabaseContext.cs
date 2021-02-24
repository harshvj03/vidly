using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Movie> Movie { get; set; }

        public DbSet<MemberShipType> MemberShipType { get; set; }

        public DbSet<Genre> Genre { get; set; }
    }

    
    
}