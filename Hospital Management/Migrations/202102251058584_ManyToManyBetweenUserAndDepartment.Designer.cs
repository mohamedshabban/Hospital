// <auto-generated />
namespace Hospital_Management.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class ManyToManyBetweenUserAndDepartment : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(ManyToManyBetweenUserAndDepartment));
        
        string IMigrationMetadata.Id
        {
            get { return "202102251058584_ManyToManyBetweenUserAndDepartment"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
