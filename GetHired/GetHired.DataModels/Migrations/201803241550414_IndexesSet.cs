namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexesSet : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Companies", new[] { "Email" });
            DropIndex("dbo.Companies", new[] { "PhoneNumber" });
            DropIndex("dbo.Users", new[] { "Username" });
            AlterColumn("dbo.Addresses", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Companies", "Email", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Companies", "PhoneNumber", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.JobOffers", "Position", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.JobOffers", "Description", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.JobCategories", "CategoryName", c => c.String(nullable: false, maxLength: 125));
            AlterColumn("dbo.JobTypes", "TypeName", c => c.String(nullable: false, maxLength: 125));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Towns", "Name", c => c.String(nullable: false, maxLength: 125));
            CreateIndex("dbo.Addresses", "Name", unique: true);
            CreateIndex("dbo.Companies", "Name", unique: true);
            CreateIndex("dbo.Companies", "Email", unique: true);
            CreateIndex("dbo.Companies", "PhoneNumber", unique: true);
            CreateIndex("dbo.JobCategories", "CategoryName", unique: true);
            CreateIndex("dbo.JobTypes", "TypeName", unique: true);
            CreateIndex("dbo.Users", "Username", unique: true);
            CreateIndex("dbo.Towns", "Name", unique: true);
            DropColumn("dbo.JobCategories", "DateModified");
            DropColumn("dbo.JobCategories", "DateCreated");
            DropColumn("dbo.JobTypes", "DateModified");
            DropColumn("dbo.JobTypes", "DateCreated");
            DropColumn("dbo.Users", "PasswordSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PasswordSalt", c => c.String(nullable: false));
            AddColumn("dbo.JobTypes", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobTypes", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobCategories", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobCategories", "DateModified", c => c.DateTime(nullable: false));
            DropIndex("dbo.Towns", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.JobTypes", new[] { "TypeName" });
            DropIndex("dbo.JobCategories", new[] { "CategoryName" });
            DropIndex("dbo.Companies", new[] { "PhoneNumber" });
            DropIndex("dbo.Companies", new[] { "Email" });
            DropIndex("dbo.Companies", new[] { "Name" });
            DropIndex("dbo.Addresses", new[] { "Name" });
            AlterColumn("dbo.Towns", "Name", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.JobTypes", "TypeName", c => c.String());
            AlterColumn("dbo.JobCategories", "CategoryName", c => c.String());
            AlterColumn("dbo.JobOffers", "Description", c => c.String());
            AlterColumn("dbo.JobOffers", "Position", c => c.String());
            AlterColumn("dbo.Companies", "PhoneNumber", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Companies", "Email", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Companies", "Name", c => c.String());
            AlterColumn("dbo.Addresses", "Name", c => c.String());
            CreateIndex("dbo.Users", "Username", unique: true);
            CreateIndex("dbo.Companies", "PhoneNumber", unique: true);
            CreateIndex("dbo.Companies", "Email", unique: true);
        }
    }
}
