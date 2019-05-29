namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class count : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddCommercialTypeRentals", "CRCount", c => c.Int(nullable: false));
            AddColumn("dbo.AddHomeTypeRentals", "HRCount", c => c.Int(nullable: false));
            AddColumn("dbo.AdHomeProperties", "HCount", c => c.Int(nullable: false));
            AddColumn("dbo.AdPlotProperties", "PCount", c => c.Int(nullable: false));
            AddColumn("dbo.PayingGuests", "PGCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayingGuests", "PGCount");
            DropColumn("dbo.AdPlotProperties", "PCount");
            DropColumn("dbo.AdHomeProperties", "HCount");
            DropColumn("dbo.AddHomeTypeRentals", "HRCount");
            DropColumn("dbo.AddCommercialTypeRentals", "CRCount");
        }
    }
}
