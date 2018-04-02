namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserJobOffers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserJobOffers", "JobOffer_Id", "dbo.JobOffers");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.UserJobOffers", new[] { "User_Id" });
            DropIndex("dbo.UserJobOffers", new[] { "JobOffer_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UserJobOffers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserJobOffers",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        JobOffer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.JobOffer_Id });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false, maxLength: 125, fixedLength: true),
                        DataOfBirth = c.DateTime(),
                        Role = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserJobOffers", "JobOffer_Id");
            CreateIndex("dbo.UserJobOffers", "User_Id");
            CreateIndex("dbo.Users", "Email", unique: true);
            AddForeignKey("dbo.UserJobOffers", "JobOffer_Id", "dbo.JobOffers", "Id");
            AddForeignKey("dbo.UserJobOffers", "User_Id", "dbo.Users", "Id");
        }
    }
}
