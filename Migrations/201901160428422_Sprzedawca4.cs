namespace Sklep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprzedawca4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PozycjaZamowienia", "Sprzedawca", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PozycjaZamowienia", "Sprzedawca");
        }
    }
}
