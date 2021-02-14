namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToDepartment1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "ShortDescription", c => c.String());
            AddColumn("dbo.Departments", "LongDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "LongDescription");
            DropColumn("dbo.Departments", "ShortDescription");
        }
    }
}
