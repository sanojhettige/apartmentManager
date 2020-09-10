namespace ApartmentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "PropertyId", c => c.Int());
        }
        
        public override void Down() 
        {
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "PropertyId");
        }
    }
}
