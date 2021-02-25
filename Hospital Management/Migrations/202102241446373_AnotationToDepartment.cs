namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotationToDepartment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Departments", "ShortDescription", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Departments", "LongDescription", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "LongDescription", c => c.String());
            AlterColumn("dbo.Departments", "ShortDescription", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
        }
    }
}
