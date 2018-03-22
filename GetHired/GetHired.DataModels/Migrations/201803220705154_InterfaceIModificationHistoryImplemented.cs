namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InterfaceIModificationHistoryImplemented : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Addresses", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobOffers", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobOffers", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobCategories", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobCategories", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobTypes", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobTypes", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Towns", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Towns", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Towns", "DateCreated");
            DropColumn("dbo.Towns", "DateModified");
            DropColumn("dbo.JobTypes", "DateCreated");
            DropColumn("dbo.JobTypes", "DateModified");
            DropColumn("dbo.JobCategories", "DateCreated");
            DropColumn("dbo.JobCategories", "DateModified");
            DropColumn("dbo.Users", "DateCreated");
            DropColumn("dbo.Users", "DateModified");
            DropColumn("dbo.JobOffers", "DateCreated");
            DropColumn("dbo.JobOffers", "DateModified");
            DropColumn("dbo.Companies", "DateCreated");
            DropColumn("dbo.Companies", "DateModified");
            DropColumn("dbo.Addresses", "DateCreated");
            DropColumn("dbo.Addresses", "DateModified");
        }
    }
}
