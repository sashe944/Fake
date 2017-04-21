namespace FakeApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FakeApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FakeApplication.Models.ApplicationDbContext context)
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

            context.FakeUsers.AddOrUpdate(
                  p => p.FakeName,
                  new Models.FakeUsers { FakeName =DateTime.Now.AddYears(99).ToString(), FakeDate = "Andrew Peters" },
                  new Models.FakeUsers {FakeName = DateTime.Now.AddDays(15).ToString(), FakeDate = "Brice Lambson" },
                  new Models.FakeUsers { FakeName = DateTime.Now.AddDays(-15).ToString(), FakeDate = "Rowan Miller" }
                );

        }
    }
}
