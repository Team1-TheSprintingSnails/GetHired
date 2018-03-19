namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipsFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Passwords", "Id", "dbo.Users");
            DropIndex("dbo.Passwords", new[] { "Id" });
            RenameColumn(table: "dbo.JobOffers", name: "JobCategory_Id", newName: "JobCategoryId");
            RenameColumn(table: "dbo.JobOffers", name: "JobType_Id", newName: "JobTypeId");
            RenameIndex(table: "dbo.JobOffers", name: "IX_JobType_Id", newName: "IX_JobTypeId");
            RenameIndex(table: "dbo.JobOffers", name: "IX_JobCategory_Id", newName: "IX_JobCategoryId");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            RenameIndex(table: "dbo.JobOffers", name: "IX_JobCategoryId", newName: "IX_JobCategory_Id");
            RenameIndex(table: "dbo.JobOffers", name: "IX_JobTypeId", newName: "IX_JobType_Id");
            RenameColumn(table: "dbo.JobOffers", name: "JobTypeId", newName: "JobType_Id");
            RenameColumn(table: "dbo.JobOffers", name: "JobCategoryId", newName: "JobCategory_Id");
            CreateIndex("dbo.Passwords", "Id");
            AddForeignKey("dbo.Passwords", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id");
        }
    }
}
