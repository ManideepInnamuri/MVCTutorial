namespace VidlyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ImagePath");
        }
    }
}
