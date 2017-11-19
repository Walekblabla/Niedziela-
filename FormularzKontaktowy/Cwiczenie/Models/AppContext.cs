using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cwiczenie.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("FormList")
        {

        }

        public DbSet<FormList> FormLists { get; set; }
        public DbSet<CarList> CarLists { get; set; }
        public DbSet<HomeList> HomeLists { get; set; }
    }
}