namespace helloWebapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatinggenrestable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (id,name) values(1,'comedy')");
            Sql("Insert into Genres (id,name) values(2,'comedy')");


        }

        public override void Down()
        {
        }
    }
}
