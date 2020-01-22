namespace VidlyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Data : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Membershiptypes (Membership,SignUpFee,DurationInMonths,DiscountRate) values('Pay As You Go',0,0,0)");
            Sql("Insert into Membershiptypes (Membership,SignUpFee,DurationInMonths,DiscountRate) values('Monthly',30,1,10)");
            Sql("Insert into Membershiptypes (Membership,SignUpFee,DurationInMonths,DiscountRate) values('Quarterly',90,3,15)");
            Sql("Insert into Membershiptypes (Membership,SignUpFee,DurationInMonths,DiscountRate) values('Yearly',300,12,20)");


            Sql("Insert into Generes (Name) values('Comedy')");
            Sql("Insert into Generes (Name) values('Action')");
            Sql("Insert into Generes (Name) values('Family')");
            Sql("Insert into Generes (Name) values('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
