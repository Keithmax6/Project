namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2929ac80-93fe-4c0c-8755-ebef28c423b5', N'admin@mark.com', 0, N'AESrwc4iXXttBfJqRFBNgjiGgK2ZDdYoarEpIOO7zQ+/ERHI3Ri5yRdXXFtorueNhA==', N'406fcc62-a882-4715-89bd-a2b3a7f22271', NULL, 0, 0, NULL, 1, 0, N'admin@mark.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ea1f5254-7fac-4939-a02f-fbba14ee328c', N'guest@mark.com', 0, N'AHQ+1Iemw9L4KlWVEJ/TXRcBExZnJaNPTM/IgOmMKglgiZjWoe0xp/ETsiEHhbXAVA==', N'4908191d-0d55-4cd9-99a1-2dd03b0206d5', NULL, 0, 0, NULL, 1, 0, N'guest@mark.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1ec330ca-4359-4a73-8506-87e18fa86592', N'CanManageComponent')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2929ac80-93fe-4c0c-8755-ebef28c423b5', N'1ec330ca-4359-4a73-8506-87e18fa86592')

");
        }
        
        public override void Down()
        {
        }
    }
}
