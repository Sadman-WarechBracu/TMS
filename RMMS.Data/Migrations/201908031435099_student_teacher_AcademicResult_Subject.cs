namespace RMMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_teacher_AcademicResult_Subject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicResults",
                c => new
                    {
                        T_ID = c.Int(nullable: false),
                        SchoolName = c.String(),
                        S_Result = c.Double(nullable: false),
                        CollageName = c.String(),
                        C_Result = c.Double(nullable: false),
                        VarsityName = c.String(),
                        V_Result = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.T_ID)
                .ForeignKey("dbo.UserInfoes", t => t.T_ID)
                .Index(t => t.T_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        S_ID = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Class = c.String(),
                    })
                .PrimaryKey(t => t.S_ID)
                .ForeignKey("dbo.UserInfoes", t => t.S_ID)
                .Index(t => t.S_ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        T_ID = c.Int(nullable: false),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserInfoes", t => t.T_ID, cascadeDelete: true)
                .Index(t => t.T_ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        T_ID = c.Int(nullable: false),
                        Location = c.String(),
                        ContactNo = c.String(),
                        Description = c.String(),
                        IsVarified = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.T_ID)
                .ForeignKey("dbo.UserInfoes", t => t.T_ID)
                .Index(t => t.T_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "T_ID", "dbo.UserInfoes");
            DropForeignKey("dbo.Subjects", "T_ID", "dbo.UserInfoes");
            DropForeignKey("dbo.Students", "S_ID", "dbo.UserInfoes");
            DropForeignKey("dbo.AcademicResults", "T_ID", "dbo.UserInfoes");
            DropIndex("dbo.Teachers", new[] { "T_ID" });
            DropIndex("dbo.Subjects", new[] { "T_ID" });
            DropIndex("dbo.Students", new[] { "S_ID" });
            DropIndex("dbo.AcademicResults", new[] { "T_ID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.AcademicResults");
        }
    }
}
