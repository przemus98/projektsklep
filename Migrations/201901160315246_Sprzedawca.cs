namespace Sklep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprzedawca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produkt", "Sprzedawca", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produkt", "Sprzedawca");
        }
    }
}
