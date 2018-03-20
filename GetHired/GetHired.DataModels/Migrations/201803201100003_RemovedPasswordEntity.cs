namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPasswordEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserJobCategories", "JobCategory_Id", "dbo.JobCategories");
            DropForeignKey("dbo.JobTypeUsers", "JobType_Id", "dbo.JobTypes");
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Passwords", "Id", "dbo.Users");
            DropIndex("dbo.Passwords", new[] { "Id" });
            DropIndex("dbo.UserJobCategories", new[] { "User_Id" });
            DropIndex("dbo.UserJobCategories", new[] { "JobCategory_Id" });
            DropIndex("dbo.JobTypeUsers", new[] { "JobType_Id" });
            DropIndex("dbo.JobTypeUsers", new[] { "User_Id" });
            CreateTable(
                "dbo.UserJobOffers",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        JobOffer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.JobOffer_Id })
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.JobOffers", t => t.JobOffer_Id)
                .Index(t => t.User_Id)
                .Index(t => t.JobOffer_Id);
            
            AddColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false));
            AddColumn("dbo.Users", "PasswordSalt", c => c.String(nullable: false));
            DropTable("dbo.Passwords");
            DropTable("dbo.UserJobCategories");
            DropTable("dbo.JobTypeUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobTypeUsers",
                c => new
                    {
                        JobType_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobType_Id, t.User_Id });
            
            CreateTable(
                "dbo.UserJobCategories",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        JobCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.JobCategory_Id });
            
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PasswordHash = c.String(),
                        PasswordSalt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.UserJobOffers", "JobOffer_Id", "dbo.JobOffers");
            DropForeignKey("dbo.UserJobOffers", "User_Id", "dbo.Users");
            DropIndex("dbo.UserJobOffers", new[] { "JobOffer_Id" });
            DropIndex("dbo.UserJobOffers", new[] { "User_Id" });
            DropColumn("dbo.Users", "PasswordSalt");
            DropColumn("dbo.Users", "PasswordHash");
            DropTable("dbo.UserJobOffers");
            CreateIndex("dbo.JobTypeUsers", "User_Id");
            CreateIndex("dbo.JobTypeUsers", "JobType_Id");
            CreateIndex("dbo.UserJobCategories", "JobCategory_Id");
            CreateIndex("dbo.UserJobCategories", "User_Id");
            CreateIndex("dbo.Passwords", "Id");
            AddForeignKey("dbo.Passwords", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.JobTypeUsers", "JobType_Id", "dbo.JobTypes", "Id");
            AddForeignKey("dbo.UserJobCategories", "JobCategory_Id", "dbo.JobCategories", "Id");
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id");
        }
    }
}
