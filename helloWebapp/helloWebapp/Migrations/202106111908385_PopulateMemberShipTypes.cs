namespace helloWebapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO MembershipTypes (Id,SignUpFee,DurationinMonth,DiscountRate) VALUES(1,0,0,0)");

            Sql("Insert INTO MembershipTypes (Id,SignUpFee,DurationinMonth,DiscountRate) VALUES(2,30,1,10)");

            Sql("Insert INTO MembershipTypes (Id,SignUpFee,DurationinMonth,DiscountRate) VALUES(3,90,3,15)");

            Sql("Insert INTO MembershipTypes (Id,SignUpFee,DurationinMonth,DiscountRate) VALUES(4,300,12,30)");
        }
        
        public override void Down()
        { 
        }
    }
}
