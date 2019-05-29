namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emptyMigration : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CommercialTypes (CommercialTypeName ) VALUES ('Office')");
            Sql("INSERT INTO CommercialTypes (CommercialTypeName ) VALUES ('Shop')");
            Sql("INSERT INTO CommercialTypes (CommercialTypeName ) VALUES ('Building')");
            Sql("INSERT INTO CommercialTypes (CommercialTypeName ) VALUES ('Warehouse')");
            Sql("INSERT INTO CommercialTypes (CommercialTypeName ) VALUES ('Factory')");
            Sql("INSERT INTO CommercialTypes (CommercialTypeName ) VALUES ('Other')");

            Sql("INSERT INTO HomeTypes (HomeTypeName ) VALUES ('House')");
            Sql("INSERT INTO HomeTypes (HomeTypeName ) VALUES ('Flat')");
            Sql("INSERT INTO HomeTypes (HomeTypeName ) VALUES ('Upper Portion')");
            Sql("INSERT INTO HomeTypes (HomeTypeName ) VALUES ('Lower Portion')");
            Sql("INSERT INTO HomeTypes (HomeTypeName ) VALUES ('Room')");
            Sql("INSERT INTO HomeTypes (HomeTypeName ) VALUES ('Pent House')");
            Sql("INSERT INTO HomeTypes (HomeTypeName ) VALUES ('Farm House')");

            Sql("INSERT INTO PlotTypes (PlotTypeName ) VALUES ('Residential Plot')");
            Sql("INSERT INTO PlotTypes (PlotTypeName ) VALUES ('Commercial Plot')");
            Sql("INSERT INTO PlotTypes (PlotTypeName ) VALUES ('Agricultural Land')");
            Sql("INSERT INTO PlotTypes (PlotTypeName ) VALUES ('Industrial Land')");
            Sql("INSERT INTO PlotTypes (PlotTypeName ) VALUES ('Plot File')");
            Sql("INSERT INTO PlotTypes (PlotTypeName ) VALUES ('Plot Form')");
        }
        
        public override void Down()
        {
        }
    }
}
