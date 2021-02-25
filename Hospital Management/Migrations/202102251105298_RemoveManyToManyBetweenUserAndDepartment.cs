namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveManyToManyBetweenUserAndDepartment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "Department_Id" });
            DropIndex("dbo.Doctors", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Department_Id");
            DropColumn("dbo.Doctors", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Department_Id", c => c.Byte());
            CreateIndex("dbo.Doctors", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "Department_Id");
            AddForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Doctors", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
