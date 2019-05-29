namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userupdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentalCommercialImages", "ImageNumber", c => c.Int(nullable: false));
            AddColumn("dbo.RentalHomeImages", "ImageNumber", c => c.Int(nullable: false));
            AddColumn("dbo.HomeImages", "ImageNumber", c => c.Int(nullable: false));
            AddColumn("dbo.PayingGuestImages", "ImageNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayingGuestImages", "ImageNumber");
            DropColumn("dbo.HomeImages", "ImageNumber");
            DropColumn("dbo.RentalHomeImages", "ImageNumber");
            DropColumn("dbo.RentalCommercialImages", "ImageNumber");
        }
    }
}
