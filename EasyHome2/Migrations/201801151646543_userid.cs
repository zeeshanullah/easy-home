namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddCommercialTypeRentals", "UserId", c => c.String());
            AddColumn("dbo.AddHomeTypeRentals", "UserId", c => c.String());
            AddColumn("dbo.AdHomeProperties", "UserId", c => c.String());
            AddColumn("dbo.AdPlotProperties", "UserId", c => c.String());
            AddColumn("dbo.PayingGuests", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayingGuests", "UserId");
            DropColumn("dbo.AdPlotProperties", "UserId");
            DropColumn("dbo.AdHomeProperties", "UserId");
            DropColumn("dbo.AddHomeTypeRentals", "UserId");
            DropColumn("dbo.AddCommercialTypeRentals", "UserId");
        }
    }
}
