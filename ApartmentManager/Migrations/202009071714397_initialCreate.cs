namespace ApartmentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ActivityLog = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        ApartmentTypeId = c.Int(nullable: false),
                        OwnerId = c.Int(),
                        TenentId = c.Int(),
                        FloorNo = c.Int(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApartmentTypes", t => t.ApartmentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Owners", t => t.OwnerId)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.Tenents", t => t.TenentId)
                .Index(t => t.PropertyId)
                .Index(t => t.ApartmentTypeId)
                .Index(t => t.OwnerId)
                .Index(t => t.TenentId);
            
            CreateTable(
                "dbo.ApartmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SquareFeets = c.Int(nullable: false),
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
                        Name = c.String(nullable: false, maxLength: 100),
                        NicNo = c.String(maxLength: 20),
                        PhoneNumber = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
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
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
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
                "dbo.Tenents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        NicNo = c.String(maxLength: 20),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaintenanceInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApartmentId = c.Int(nullable: false),
                        MonthId = c.String(),
                        MaintenanceCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ElectricityUnits = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ElectricityCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WaterUnits = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WaterCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GasUnits = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GasCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherNotes = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartments", t => t.ApartmentId, cascadeDelete: true)
                .Index(t => t.ApartmentId);
            
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
                "dbo.SecurityGuards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        NicNo = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
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
            DropForeignKey("dbo.SecurityGuards", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MaintenanceInvoices", "ApartmentId", "dbo.Apartments");
            DropForeignKey("dbo.Apartments", "TenentId", "dbo.Tenents");
            DropForeignKey("dbo.Apartments", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Apartments", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Apartments", "ApartmentTypeId", "dbo.ApartmentTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SecurityGuards", new[] { "PropertyId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.MaintenanceInvoices", new[] { "ApartmentId" });
            DropIndex("dbo.Apartments", new[] { "TenentId" });
            DropIndex("dbo.Apartments", new[] { "OwnerId" });
            DropIndex("dbo.Apartments", new[] { "ApartmentTypeId" });
            DropIndex("dbo.Apartments", new[] { "PropertyId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SecurityGuards");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MaintenanceInvoices");
            DropTable("dbo.Tenents");
            DropTable("dbo.Properties");
            DropTable("dbo.Owners");
            DropTable("dbo.ApartmentTypes");
            DropTable("dbo.Apartments");
            DropTable("dbo.Activities");
        }
    }
}
