namespace ApartmentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        FloorNo = c.Int(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApartmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SqurareFeets = c.Int(nullable: false),
                        MaintenanceCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumRooms = c.Int(nullable: false),
                        NumBathRooms = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApartmentId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        NicNo = c.String(maxLength: 20),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        OwnerFrom = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        FaxNumber = c.String(),
                        NumFloors = c.Int(nullable: false),
                        NumUnits = c.Int(nullable: false),
                        PoolExists = c.Boolean(nullable: false),
                        GymExists = c.Boolean(nullable: false),
                        OtherAmenities = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Tenents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApartmentId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        NicNo = c.String(maxLength: 20),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        TenentFrom = c.DateTime(nullable: false),
                        TenentTo = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Status = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tenents");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Properties");
            DropTable("dbo.Owners");
            DropTable("dbo.ApartmentTypes");
            DropTable("dbo.Apartments");
        }
    }
}
