using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormularzKontaktowy.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("ContactForm")
        {

        }

        public DbSet<ContactForm> ContactForms { get; set; }
    }
}