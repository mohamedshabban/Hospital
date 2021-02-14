namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Image");
        }
    }
}
