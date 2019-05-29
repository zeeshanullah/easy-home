namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class total : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdCommecialProperties", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdCommecialProperties", "Count");
        }
    }
}
