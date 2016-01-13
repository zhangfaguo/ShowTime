namespace ShowTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsValid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleFunction",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        FnId = c.Int(nullable: false),
                        IsValid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.FnId })
                .ForeignKey("dbo.SysFunction", t => t.FnId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.FnId);
            
            CreateTable(
                "dbo.SysFunction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Style = c.String(maxLength: 66),
                        Parent = c.Int(nullable: false),
                        Area = c.String(maxLength: 33),
                        Controller = c.String(maxLength: 33),
                        Action = c.String(maxLength: 33),
                        IsMenu = c.Int(nullable: false),
                        Create = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        IsValid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Password = c.String(maxLength: 23),
                        RealName = c.String(maxLength: 30),
                        Tel = c.String(maxLength: 14),
                        Statue = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserFunExtend",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FnId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FnId })
                .ForeignKey("dbo.SysFunction", t => t.FnId, cascadeDelete: true)
                .ForeignKey("dbo.SysUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FnId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TelPhone = c.String(maxLength: 12),
                        PassWord = c.String(maxLength: 23),
                        RealName = c.String(maxLength: 30),
                        IdCard = c.String(maxLength: 20),
                        Adress = c.String(maxLength: 100),
                        ReMark = c.String(),
                        EMail = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TelPhone, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserFunExtend", "UserId", "dbo.SysUser");
            DropForeignKey("dbo.UserFunExtend", "FnId", "dbo.SysFunction");
            DropForeignKey("dbo.RoleFunction", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleFunction", "FnId", "dbo.SysFunction");
            DropIndex("dbo.User", new[] { "TelPhone" });
            DropIndex("dbo.UserFunExtend", new[] { "FnId" });
            DropIndex("dbo.UserFunExtend", new[] { "UserId" });
            DropIndex("dbo.SysUser", new[] { "RoleId" });
            DropIndex("dbo.RoleFunction", new[] { "FnId" });
            DropIndex("dbo.RoleFunction", new[] { "RoleId" });
            DropTable("dbo.User");
            DropTable("dbo.UserFunExtend");
            DropTable("dbo.SysUser");
            DropTable("dbo.SysFunction");
            DropTable("dbo.RoleFunction");
            DropTable("dbo.Role");
        }
    }
}
