namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6d5939a4-b14b-4882-af07-eb6c1a48d710', N'admin@EasyHome.com', 0, N'AHlYrc0QfvOZYaAez+ssZLENmLaL7lA7xuzo/D0486z96vxi0Sp3kdeDGqhmUgIhJA==', N'18690865-b6db-4e6d-920d-6ee55fcea979', N'+923218820555', 0, 0, NULL, 1, 0, N'admin@EasyHome.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'381c4087-43d0-4e63-8ebd-7e74e41bc34a', N'AdminE')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d5939a4-b14b-4882-af07-eb6c1a48d710', N'381c4087-43d0-4e63-8ebd-7e74e41bc34a')

");
        }
        
        public override void Down()
        {
        }
    }
}
