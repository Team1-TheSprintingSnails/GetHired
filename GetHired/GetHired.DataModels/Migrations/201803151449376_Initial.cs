namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TownId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Towns", t => t.TownId, cascadeDelete: true)
                .Index(t => t.TownId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessInfo = c.String(),
                        ContactInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        Description = c.String(),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Int(nullable: false),
                        JobCategory_Id = c.Int(),
                        JobType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.JobCategories", t => t.JobCategory_Id)
                .ForeignKey("dbo.JobTypes", t => t.JobType_Id)
                .Index(t => t.CompanyId)
                .Index(t => t.JobCategory_Id)
                .Index(t => t.JobType_Id);
            
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserJobCategories",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        JobCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.JobCategory_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.JobCategories", t => t.JobCategory_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.JobCategory_Id);
            
            CreateTable(
                "dbo.JobTypeUsers",
                c => new
                    {
                        JobType_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobType_Id, t.User_Id })
                .ForeignKey("dbo.JobTypes", t => t.JobType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.JobType_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "TownId", "dbo.Towns");
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.JobTypeUsers", "JobType_Id", "dbo.JobTypes");
            DropForeignKey("dbo.JobOffers", "JobType_Id", "dbo.JobTypes");
            DropForeignKey("dbo.UserJobCategories", "JobCategory_Id", "dbo.JobCategories");
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.JobOffers", "JobCategory_Id", "dbo.JobCategories");
            DropForeignKey("dbo.JobOffers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ContactInfoes", "Id", "dbo.Companies");
            DropForeignKey("dbo.Addresses", "CompanyId", "dbo.Companies");
            DropIndex("dbo.JobTypeUsers", new[] { "User_Id" });
            DropIndex("dbo.JobTypeUsers", new[] { "JobType_Id" });
            DropIndex("dbo.UserJobCategories", new[] { "JobCategory_Id" });
            DropIndex("dbo.UserJobCategories", new[] { "User_Id" });
            DropIndex("dbo.JobOffers", new[] { "JobType_Id" });
            DropIndex("dbo.JobOffers", new[] { "JobCategory_Id" });
            DropIndex("dbo.JobOffers", new[] { "CompanyId" });
            DropIndex("dbo.ContactInfoes", new[] { "Id" });
            DropIndex("dbo.Addresses", new[] { "CompanyId" });
            DropIndex("dbo.Addresses", new[] { "TownId" });
            DropTable("dbo.JobTypeUsers");
            DropTable("dbo.UserJobCategories");
            DropTable("dbo.Towns");
            DropTable("dbo.JobTypes");
            DropTable("dbo.Users");
            DropTable("dbo.JobCategories");
            DropTable("dbo.JobOffers");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.Companies");
            DropTable("dbo.Addresses");
        }
    }
}
