namespace helloWebapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingcustomerwithbirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers set Birthdate='1997/11/01' where Id=1");
            Sql("UPDATE Customers set Birthdate='1998/12/01' where Id=2");


        }

        public override void Down()
        {
        }
    }
}
