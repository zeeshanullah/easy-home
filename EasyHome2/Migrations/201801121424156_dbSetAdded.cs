namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbSetAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdCommecialProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        AddressLatitude = c.Double(nullable: false),
                        AddressLongitude = c.Double(nullable: false),
                        Address = c.String(),
                        CommercialTypeId = c.Int(nullable: false),
                        City = c.String(),
                        Location = c.String(),
                        PropertyTitle = c.String(),
                        PropertyDescription = c.String(),
                        PropertyPrice = c.Double(nullable: false),
                        PropertyLandArea = c.Int(nullable: false),
                        PropertyLandAreaUnit = c.String(),
                        BuiltinYear = c.Int(nullable: false),
                        Bathrooms = c.Byte(nullable: false),
                        ExpiresAfter = c.DateTime(nullable: false),
                        CommercialTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommercialTypes", t => t.CommercialTypes_Id)
                .Index(t => t.CommercialTypes_Id);
            
            CreateTable(
                "dbo.CommercialTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommercialTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AddCommercialTypeRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommercialTypeId = c.Int(nullable: false),
                        City = c.String(),
                        Location = c.String(),
                        PropertyTitle = c.String(),
                        PropertyDescription = c.String(),
                        Rent = c.Double(nullable: false),
                        PropertyLandArea = c.Int(nullable: false),
                        PropertyLandAreaUnit = c.String(),
                        BuiltinYear = c.Int(nullable: false),
                        Bathrooms = c.Byte(nullable: false),
                        ExpiresAfter = c.DateTime(nullable: false),
                        CommercialTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommercialTypes", t => t.CommercialTypes_Id)
                .Index(t => t.CommercialTypes_Id);
            
            CreateTable(
                "dbo.AddHomeTypeRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentalHomeTypeId = c.Byte(nullable: false),
                        City = c.String(),
                        Location = c.String(),
                        PropertyTitle = c.String(),
                        PropertyDescription = c.String(),
                        PropertyPrice = c.Double(nullable: false),
                        PropertyLandArea = c.Int(nullable: false),
                        PropertyLandAreaUnit = c.String(),
                        Bedrooms = c.Byte(nullable: false),
                        Bathrooms = c.Byte(nullable: false),
                        BuiltinYear = c.Int(nullable: false),
                        ParkingSpaces = c.Byte(nullable: false),
                        DiningRoom = c.Boolean(nullable: false),
                        DrawingRoom = c.Boolean(nullable: false),
                        Kitchens = c.Byte(nullable: false),
                        ExpiresAfter = c.DateTime(nullable: false),
                        HomeTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HomeTypes", t => t.HomeTypes_Id)
                .Index(t => t.HomeTypes_Id);
            
            CreateTable(
                "dbo.HomeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdHomeProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTypeId = c.Byte(nullable: false),
                        City = c.String(),
                        Location = c.String(),
                        PropertyTitle = c.String(),
                        PropertyDescription = c.String(),
                        PropertyPrice = c.Double(nullable: false),
                        PropertyLandArea = c.Int(nullable: false),
                        PropertyLandAreaUnit = c.String(),
                        Bedrooms = c.Byte(nullable: false),
                        Bathrooms = c.Byte(nullable: false),
                        BuiltinYear = c.Int(nullable: false),
                        ParkingSpaces = c.Byte(nullable: false),
                        DiningRoom = c.Boolean(nullable: false),
                        DrawingRoom = c.Boolean(nullable: false),
                        Kitchens = c.Byte(nullable: false),
                        ExpiresAfter = c.DateTime(nullable: false),
                        HomeTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HomeTypes", t => t.HomeTypes_Id)
                .Index(t => t.HomeTypes_Id);
            
            CreateTable(
                "dbo.AdPlotProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlotTypeId = c.Int(nullable: false),
                        City = c.String(),
                        Location = c.String(),
                        PropertyTitle = c.String(),
                        PropertyDescription = c.String(),
                        PropertyPrice = c.Double(nullable: false),
                        PropertyLandArea = c.Int(nullable: false),
                        PropertyLandAreaUnit = c.String(),
                        ExpiresAfter = c.DateTime(nullable: false),
                        PlotTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlotTypes", t => t.PlotTypes_Id)
                .Index(t => t.PlotTypes_Id);
            
            CreateTable(
                "dbo.PlotTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlotTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommercialImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageNumber = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        AltText = c.String(),
                        Caption = c.String(),
                        ImageUrl = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CommercialId = c.Int(nullable: false),
                        AdCommecialProperty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdCommecialProperties", t => t.AdCommecialProperty_Id)
                .Index(t => t.AdCommecialProperty_Id);
            
            CreateTable(
                "dbo.HomeImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        AltText = c.String(),
                        Caption = c.String(),
                        ImageUrl = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        HomeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdHomeProperties", t => t.HomeId, cascadeDelete: true)
                .Index(t => t.HomeId);
            
            CreateTable(
                "dbo.PayingGuests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ChargesPerHour = c.Int(nullable: false),
                        Description = c.String(),
                        Rooms = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PayingGuestImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        AltText = c.String(),
                        Caption = c.String(),
                        ImageUrl = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        PayingGuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PayingGuests", t => t.PayingGuestId, cascadeDelete: true)
                .Index(t => t.PayingGuestId);
            
            CreateTable(
                "dbo.RentalCommercialImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        AltText = c.String(),
                        Caption = c.String(),
                        ImageUrl = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RentalCommercialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddCommercialTypeRentals", t => t.RentalCommercialId, cascadeDelete: true)
                .Index(t => t.RentalCommercialId);
            
            CreateTable(
                "dbo.RentalHomeImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        AltText = c.String(),
                        Caption = c.String(),
                        ImageUrl = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RentalHomeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddHomeTypeRentals", t => t.RentalHomeId, cascadeDelete: true)
                .Index(t => t.RentalHomeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalHomeImages", "RentalHomeId", "dbo.AddHomeTypeRentals");
            DropForeignKey("dbo.RentalCommercialImages", "RentalCommercialId", "dbo.AddCommercialTypeRentals");
            DropForeignKey("dbo.PayingGuestImages", "PayingGuestId", "dbo.PayingGuests");
            DropForeignKey("dbo.HomeImages", "HomeId", "dbo.AdHomeProperties");
            DropForeignKey("dbo.CommercialImages", "AdCommecialProperty_Id", "dbo.AdCommecialProperties");
            DropForeignKey("dbo.AdPlotProperties", "PlotTypes_Id", "dbo.PlotTypes");
            DropForeignKey("dbo.AdHomeProperties", "HomeTypes_Id", "dbo.HomeTypes");
            DropForeignKey("dbo.AddHomeTypeRentals", "HomeTypes_Id", "dbo.HomeTypes");
            DropForeignKey("dbo.AddCommercialTypeRentals", "CommercialTypes_Id", "dbo.CommercialTypes");
            DropForeignKey("dbo.AdCommecialProperties", "CommercialTypes_Id", "dbo.CommercialTypes");
            DropIndex("dbo.RentalHomeImages", new[] { "RentalHomeId" });
            DropIndex("dbo.RentalCommercialImages", new[] { "RentalCommercialId" });
            DropIndex("dbo.PayingGuestImages", new[] { "PayingGuestId" });
            DropIndex("dbo.HomeImages", new[] { "HomeId" });
            DropIndex("dbo.CommercialImages", new[] { "AdCommecialProperty_Id" });
            DropIndex("dbo.AdPlotProperties", new[] { "PlotTypes_Id" });
            DropIndex("dbo.AdHomeProperties", new[] { "HomeTypes_Id" });
            DropIndex("dbo.AddHomeTypeRentals", new[] { "HomeTypes_Id" });
            DropIndex("dbo.AddCommercialTypeRentals", new[] { "CommercialTypes_Id" });
            DropIndex("dbo.AdCommecialProperties", new[] { "CommercialTypes_Id" });
            DropTable("dbo.RentalHomeImages");
            DropTable("dbo.RentalCommercialImages");
            DropTable("dbo.PayingGuestImages");
            DropTable("dbo.PayingGuests");
            DropTable("dbo.HomeImages");
            DropTable("dbo.CommercialImages");
            DropTable("dbo.PlotTypes");
            DropTable("dbo.AdPlotProperties");
            DropTable("dbo.AdHomeProperties");
            DropTable("dbo.HomeTypes");
            DropTable("dbo.AddHomeTypeRentals");
            DropTable("dbo.AddCommercialTypeRentals");
            DropTable("dbo.CommercialTypes");
            DropTable("dbo.AdCommecialProperties");
        }
    }
}
