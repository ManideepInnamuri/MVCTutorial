namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                        DateofBirth = c.DateTime(),
                        MembershipTypeId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Membership = c.String(),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Generes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GenereId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(),
                        NumberinStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Generes", t => t.GenereId, cascadeDelete: true)
                .Index(t => t.GenereId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenereId", "dbo.Generes");
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Movies", new[] { "GenereId" });
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Generes");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
