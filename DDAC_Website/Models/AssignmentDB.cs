using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DDAC_Website.Models
{
    public class AssignmentDB : DbContext
    {
        public DbSet<Location> Location { get; set; }
        public DbSet<Cruise> Cruise { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<State> State { get; set; }
    }
}
