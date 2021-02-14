namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDescriptionFromDept : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Doctors", "ShortDescription");
            DropColumn("dbo.Doctors", "LongDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "LongDescription", c => c.String());
            AddColumn("dbo.Doctors", "ShortDescription", c => c.String());
        }
    }
}
