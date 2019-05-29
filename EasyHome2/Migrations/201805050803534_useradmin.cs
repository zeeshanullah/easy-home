namespace EasyHome2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useradmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ad9aebc0-ea48-4c7d-a8e4-9f0a3170bfe5', N'Admin@EasyHome.com', 0, N'AIc3Mc1mOE1PbiOe4HsAUFVZ7nbiJcomB9RMe7PxKVFrAt4qV9V0C0bJ2+8BHWyI/w==', N'c995ce72-1e98-4a72-9821-da5d9a4c36b9', N'+923218820555', 0, 0, NULL, 1, 0, N'Admin@EasyHome.com')
INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'da208ee3-fc57-46b4-a369-6cbbc75ec440', N'AdminE')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ad9aebc0-ea48-4c7d-a8e4-9f0a3170bfe5', N'da208ee3-fc57-46b4-a369-6cbbc75ec440')

");

        }
        
        public override void Down()
        {
        }
    }
}
