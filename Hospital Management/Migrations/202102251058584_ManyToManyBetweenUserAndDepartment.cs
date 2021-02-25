namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyBetweenUserAndDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Department_Id", c => c.Byte());
            CreateIndex("dbo.AspNetUsers", "Department_Id");
            CreateIndex("dbo.Doctors", "ApplicationUser_Id");
            AddForeignKey("dbo.Doctors", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Doctors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Department_Id" });
            DropColumn("dbo.AspNetUsers", "Department_Id");
            DropColumn("dbo.Doctors", "ApplicationUser_Id");
        }
    }
}
