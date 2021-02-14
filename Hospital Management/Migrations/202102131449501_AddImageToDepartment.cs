namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Image");
        }
    }
}
