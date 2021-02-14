namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeTreatmentIdAsNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "TreatmentId", "dbo.Treatments");
            DropIndex("dbo.Patients", new[] { "TreatmentId" });
            AlterColumn("dbo.Patients", "TreatmentId", c => c.Int());
            CreateIndex("dbo.Patients", "TreatmentId");
            AddForeignKey("dbo.Patients", "TreatmentId", "dbo.Treatments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "TreatmentId", "dbo.Treatments");
            DropIndex("dbo.Patients", new[] { "TreatmentId" });
            AlterColumn("dbo.Patients", "TreatmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "TreatmentId");
            AddForeignKey("dbo.Patients", "TreatmentId", "dbo.Treatments", "Id", cascadeDelete: true);
        }
    }
}
