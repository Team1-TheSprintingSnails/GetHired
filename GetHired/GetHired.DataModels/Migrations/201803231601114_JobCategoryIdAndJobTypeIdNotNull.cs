using System.Data.Entity.Migrations;

namespace GetHired.DataModels.Migrations
{
    public partial class JobCategoryIdAndJobTypeIdNotNull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.JobOffers", new[] { "JobTypeId" });
            DropIndex("dbo.JobOffers", new[] { "JobCategoryId" });
            AlterColumn("dbo.JobOffers", "JobTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.JobOffers", "JobCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobOffers", "JobTypeId");
            CreateIndex("dbo.JobOffers", "JobCategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.JobOffers", new[] { "JobCategoryId" });
            DropIndex("dbo.JobOffers", new[] { "JobTypeId" });
            AlterColumn("dbo.JobOffers", "JobCategoryId", c => c.Int());
            AlterColumn("dbo.JobOffers", "JobTypeId", c => c.Int());
            CreateIndex("dbo.JobOffers", "JobCategoryId");
            CreateIndex("dbo.JobOffers", "JobTypeId");
        }
    }
}
