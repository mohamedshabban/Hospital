namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTreatmentsTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "TreatmentId", "dbo.Treatments");
            DropIndex("dbo.Patients", new[] { "TreatmentId" });
            DropTable("dbo.Treatments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Patients", "TreatmentId");
            AddForeignKey("dbo.Patients", "TreatmentId", "dbo.Treatments", "Id");
        }
    }
}
