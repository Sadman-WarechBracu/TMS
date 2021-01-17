namespace RMMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_location_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "location");
        }
    }
}
