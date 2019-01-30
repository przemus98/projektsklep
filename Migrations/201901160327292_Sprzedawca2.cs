namespace Sklep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprzedawca2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zamowienie", "Sprzedawca", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zamowienie", "Sprzedawca");
        }
    }
}
