namespace PetVertApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetVertApp.Models.PetDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PetVertApp.Models.PetDBContext";
            AutomaticMigrationDataLossAllowed = true;

            PetVertApp.Models.PetDBContext context = new PetVertApp.Models.PetDBContext();

            Seed(context);
        }

        protected override void Seed(PetVertApp.Models.PetDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (context.User.Where(ss => ss.email == "admin@petshop.com").Count() == 0) {

                context.User.AddOrUpdate(

              new Models.Users
              {
                  fullname = "ROOT USER",
                  email = "admin@petshop.com",
                  IsActive = true,
                  IsDeleted = false,
                  usertype = "super",
                  password = "admin123",
                  phonenumber = "12345555",
                  resetpasswordonlogin = false,
                  CreatedBy = 1,
                  CreatedOn = DateTime.Now
              }

            );

                context.SaveChanges();
            }
        

           
        }
    }
}
