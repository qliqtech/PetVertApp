using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetVertApp.Models
{
    public class PetDBContext: DbContext
    {
        public DbSet<Treatment> Treatment { get; set; }

        public DbSet<Pet> Pet { get; set; }

        public DbSet<Users> User { get; set; }

        public DbSet<Drugs> Drugs { get; set; }

        public DbSet<Vaccinations> Vaccinations { get; set; }

        public System.Data.Entity.DbSet<PetVertApp.Models.Clients> Clients { get; set; }
    }
}