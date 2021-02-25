namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIdentityFromDoctor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropColumn("dbo.Doctors", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Doctors", "UserId");
            AddForeignKey("dbo.Doctors", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
