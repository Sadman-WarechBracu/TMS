namespace RMMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_post_request : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        P_ID = c.Int(nullable: false, identity: true),
                        S_ID = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        isActive = c.Int(nullable: false),
                        Post_Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.P_ID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        R_ID = c.Int(nullable: false, identity: true),
                        P_ID = c.Int(nullable: false),
                        T_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.R_ID)
                .ForeignKey("dbo.Posts", t => t.P_ID, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.T_ID, cascadeDelete: true)
                .Index(t => t.P_ID)
                .Index(t => t.T_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "T_ID", "dbo.UserInfoes");
            DropForeignKey("dbo.Requests", "P_ID", "dbo.Posts");
            DropIndex("dbo.Requests", new[] { "T_ID" });
            DropIndex("dbo.Requests", new[] { "P_ID" });
            DropTable("dbo.Requests");
            DropTable("dbo.Posts");
        }
    }
}
