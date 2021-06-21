namespace helloWebapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbirthdateProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
