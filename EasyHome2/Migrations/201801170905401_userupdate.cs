namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdCommecialProperties", "UserName", c => c.String());
            AddColumn("dbo.AdCommecialProperties", "PhoneNumber", c => c.String());
            AddColumn("dbo.AdCommecialProperties", "UserEmail", c => c.String());
            AddColumn("dbo.AddCommercialTypeRentals", "UserName", c => c.String());
            AddColumn("dbo.AddCommercialTypeRentals", "PhoneNumber", c => c.String());
            AddColumn("dbo.AddCommercialTypeRentals", "UserEmail", c => c.String());
            AddColumn("dbo.AddHomeTypeRentals", "UserName", c => c.String());
            AddColumn("dbo.AddHomeTypeRentals", "PhoneNumber", c => c.String());
            AddColumn("dbo.AddHomeTypeRentals", "UserEmail", c => c.String());
            AddColumn("dbo.AdHomeProperties", "UserName", c => c.String());
            AddColumn("dbo.AdHomeProperties", "PhoneNumber", c => c.String());
            AddColumn("dbo.AdHomeProperties", "UserEmail", c => c.String());
            AddColumn("dbo.AdPlotProperties", "UserName", c => c.String());
            AddColumn("dbo.AdPlotProperties", "PhoneNumber", c => c.String());
            AddColumn("dbo.AdPlotProperties", "UserEmail", c => c.String());
            AddColumn("dbo.PayingGuests", "UserName", c => c.String());
            AddColumn("dbo.PayingGuests", "PhoneNumber", c => c.String());
            AddColumn("dbo.PayingGuests", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayingGuests", "UserEmail");
            DropColumn("dbo.PayingGuests", "PhoneNumber");
            DropColumn("dbo.PayingGuests", "UserName");
            DropColumn("dbo.AdPlotProperties", "UserEmail");
            DropColumn("dbo.AdPlotProperties", "PhoneNumber");
            DropColumn("dbo.AdPlotProperties", "UserName");
            DropColumn("dbo.AdHomeProperties", "UserEmail");
            DropColumn("dbo.AdHomeProperties", "PhoneNumber");
            DropColumn("dbo.AdHomeProperties", "UserName");
            DropColumn("dbo.AddHomeTypeRentals", "UserEmail");
            DropColumn("dbo.AddHomeTypeRentals", "PhoneNumber");
            DropColumn("dbo.AddHomeTypeRentals", "UserName");
            DropColumn("dbo.AddCommercialTypeRentals", "UserEmail");
            DropColumn("dbo.AddCommercialTypeRentals", "PhoneNumber");
            DropColumn("dbo.AddCommercialTypeRentals", "UserName");
            DropColumn("dbo.AdCommecialProperties", "UserEmail");
            DropColumn("dbo.AdCommecialProperties", "PhoneNumber");
            DropColumn("dbo.AdCommecialProperties", "UserName");
        }
    }
}
