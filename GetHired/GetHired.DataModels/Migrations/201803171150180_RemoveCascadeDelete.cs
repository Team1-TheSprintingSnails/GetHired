using System.Data.Entity.Migrations;

namespace GetHired.DataModels.Migrations
{
    
    public partial class RemoveCascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Addresses", "TownId", "dbo.Towns");
            DropForeignKey("dbo.JobOffers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserJobCategories", "JobCategory_Id", "dbo.JobCategories");
            DropForeignKey("dbo.JobTypeUsers", "JobType_Id", "dbo.JobTypes");
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            AddForeignKey("dbo.Addresses", "CompanyId", "dbo.Companies", "Id");
            AddForeignKey("dbo.Addresses", "TownId", "dbo.Towns", "Id");
            AddForeignKey("dbo.JobOffers", "CompanyId", "dbo.Companies", "Id");
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserJobCategories", "JobCategory_Id", "dbo.JobCategories", "Id");
            AddForeignKey("dbo.JobTypeUsers", "JobType_Id", "dbo.JobTypes", "Id");
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.JobTypeUsers", "JobType_Id", "dbo.JobTypes");
            DropForeignKey("dbo.UserJobCategories", "JobCategory_Id", "dbo.JobCategories");
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.JobOffers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Addresses", "TownId", "dbo.Towns");
            DropForeignKey("dbo.Addresses", "CompanyId", "dbo.Companies");
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobTypeUsers", "JobType_Id", "dbo.JobTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserJobCategories", "JobCategory_Id", "dbo.JobCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobOffers", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "TownId", "dbo.Towns", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
