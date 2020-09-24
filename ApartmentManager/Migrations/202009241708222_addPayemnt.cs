namespace ApartmentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPayemnt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaintenanceInvoices", "PaidAmount", c => c.Decimal());
            AddColumn("dbo.MaintenanceInvoices", "PaidNote", c => c.String(nullable: true, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaintenanceInvoices", "PaidAmount");
            DropColumn("dbo.MaintenanceInvoices", "PaidNote");
        }
    }
}
