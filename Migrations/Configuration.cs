namespace Sklep.Migrations
{
    using Sklep.Data_access_layer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Sklep.Data_access_layer.ProduktyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Sklep.Data_access_layer.ProduktyContext";
        }

        protected override void Seed(Sklep.Data_access_layer.ProduktyContext context)
        {
            ProduktyInitializer.SeedProduktyData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
