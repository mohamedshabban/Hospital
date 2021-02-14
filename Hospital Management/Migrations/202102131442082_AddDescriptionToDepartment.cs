namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "ShortDescription", c => c.String());
            AddColumn("dbo.Doctors", "LongDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "LongDescription");
            DropColumn("dbo.Doctors", "ShortDescription");
        }
    }
}
