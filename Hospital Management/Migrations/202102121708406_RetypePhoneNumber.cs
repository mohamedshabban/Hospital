namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetypePhoneNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Mobile", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Mobile", c => c.Int(nullable: false));
        }
    }
}
