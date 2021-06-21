namespace helloWebapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes set Name='PayAsyougo' where Id=1");
            Sql("UPDATE MembershipTypes set Name='Monthly' where Id=2");
        }
        //Sql("Insert INTO MembershipTypes (Id,SignUpFee,DurationinMonth,DiscountRate) VALUES(1,0,0,0)");

        public override void Down()
        {
        }
    }
}
