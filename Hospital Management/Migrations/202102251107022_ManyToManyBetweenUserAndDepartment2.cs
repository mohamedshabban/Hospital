namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyBetweenUserAndDepartment2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserDepartments",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Department_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Department_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserDepartments", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.ApplicationUserDepartments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserDepartments", new[] { "Department_Id" });
            DropIndex("dbo.ApplicationUserDepartments", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserDepartments");
        }
    }
}
