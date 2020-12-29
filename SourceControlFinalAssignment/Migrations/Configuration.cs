using System.Data.Entity.Migrations;

namespace Source_Control_Final_Assignment.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Source_Control_Final_Assignment.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Source_Control_Final_Assignment.Models.ApplicationDbContext";
        }

        protected override void Seed(Source_Control_Final_Assignment.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
