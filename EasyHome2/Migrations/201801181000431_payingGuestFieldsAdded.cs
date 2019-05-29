namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class payingGuestFieldsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PayingGuests", "City", c => c.String());
            AddColumn("dbo.PayingGuests", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayingGuests", "Location");
            DropColumn("dbo.PayingGuests", "City");
        }
    }
}
