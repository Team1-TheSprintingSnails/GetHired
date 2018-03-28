using System.Data.Entity.Migrations;

namespace GetHired.DataModels.Migrations
{
    public partial class CompanyNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Name");
        }
    }
}
