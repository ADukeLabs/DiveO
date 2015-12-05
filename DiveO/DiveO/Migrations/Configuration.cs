using DiveO.Models;
using DiveO.Models.Model_Attributes;

namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiveO.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DiveO.Models.ApplicationDbContext context)
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
            //context.Divers.AddOrUpdate(
            //    d => d.Name,
            //    new Diver { Id = 1, Name = "Diver Dan", HomeBase = "Key Largo, Florida", Description = "The legendary scuba diver", Certification = Certification.CertificationLevel.PadiDiveMaster}
            //    );
        }
    }
}
