namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addresslang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddCommercialTypeRentals", "AddressLatitude", c => c.Double(nullable: false));
            AddColumn("dbo.AddCommercialTypeRentals", "AddressLongitude", c => c.Double(nullable: false));
            AddColumn("dbo.AddCommercialTypeRentals", "Address", c => c.String());
            AddColumn("dbo.AddHomeTypeRentals", "AddressLatitude", c => c.Double(nullable: false));
            AddColumn("dbo.AddHomeTypeRentals", "AddressLongitude", c => c.Double(nullable: false));
            AddColumn("dbo.AddHomeTypeRentals", "Address", c => c.String());
            AddColumn("dbo.AdHomeProperties", "AddressLatitude", c => c.Double(nullable: false));
            AddColumn("dbo.AdHomeProperties", "AddressLongitude", c => c.Double(nullable: false));
            AddColumn("dbo.AdHomeProperties", "Address", c => c.String());
            AddColumn("dbo.AdPlotProperties", "AddressLatitude", c => c.Double(nullable: false));
            AddColumn("dbo.AdPlotProperties", "AddressLongitude", c => c.Double(nullable: false));
            AddColumn("dbo.AdPlotProperties", "Address", c => c.String());
            AddColumn("dbo.PayingGuests", "AddressLatitude", c => c.Double(nullable: false));
            AddColumn("dbo.PayingGuests", "AddressLongitude", c => c.Double(nullable: false));
            AddColumn("dbo.PayingGuests", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayingGuests", "Address");
            DropColumn("dbo.PayingGuests", "AddressLongitude");
            DropColumn("dbo.PayingGuests", "AddressLatitude");
            DropColumn("dbo.AdPlotProperties", "Address");
            DropColumn("dbo.AdPlotProperties", "AddressLongitude");
            DropColumn("dbo.AdPlotProperties", "AddressLatitude");
            DropColumn("dbo.AdHomeProperties", "Address");
            DropColumn("dbo.AdHomeProperties", "AddressLongitude");
            DropColumn("dbo.AdHomeProperties", "AddressLatitude");
            DropColumn("dbo.AddHomeTypeRentals", "Address");
            DropColumn("dbo.AddHomeTypeRentals", "AddressLongitude");
            DropColumn("dbo.AddHomeTypeRentals", "AddressLatitude");
            DropColumn("dbo.AddCommercialTypeRentals", "Address");
            DropColumn("dbo.AddCommercialTypeRentals", "AddressLongitude");
            DropColumn("dbo.AddCommercialTypeRentals", "AddressLatitude");
        }
    }
}
