namespace GetHired.DataModels.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class JobTypeJobCategoryModelsRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobOffers", "JobCategoryId", "dbo.JobCategories");
            DropForeignKey("dbo.JobOffers", "JobTypeId", "dbo.JobTypes");
            DropForeignKey("dbo.Addresses", "TownId", "dbo.Towns");
            DropIndex("dbo.Addresses", new[] { "Name" });
            DropIndex("dbo.Addresses", new[] { "TownId" });
            DropIndex("dbo.Companies", new[] { "Name" });
            DropIndex("dbo.Companies", new[] { "Email" });
            DropIndex("dbo.Companies", new[] { "PhoneNumber" });
            DropIndex("dbo.JobOffers", new[] { "JobTypeId" });
            DropIndex("dbo.JobOffers", new[] { "JobCategoryId" });
            DropIndex("dbo.JobCategories", new[] { "CategoryName" });
            DropIndex("dbo.JobTypes", new[] { "TypeName" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Towns", new[] { "Name" });
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        State = c.String(maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Addresses", "StreetName", c => c.String(nullable: false, maxLength: 125, unicode: false));
            AddColumn("dbo.Addresses", "PostalCode", c => c.String(nullable: false, maxLength: 4, unicode: false));
            AddColumn("dbo.Addresses", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "Website", c => c.String(nullable: false, maxLength: 125));
            AddColumn("dbo.JobOffers", "Rating", c => c.Decimal(nullable: false, precision: 2, scale: 1));
            AddColumn("dbo.JobOffers", "JobType", c => c.Int(nullable: false));
            AddColumn("dbo.JobOffers", "JobCategory", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Users", "MiddleName", c => c.String());
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Companies", "BusinessInfo", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Companies", "PhoneNumber", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.JobOffers", "Position", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.JobOffers", "Description", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.JobOffers", "Payment", c => c.Decimal(nullable: false, precision: 20, scale: 2));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false, maxLength: 125, fixedLength: true));
            CreateIndex("dbo.Addresses", new[] { "PostalCode", "StreetName" }, unique: true);
            CreateIndex("dbo.Addresses", "CityId");
            CreateIndex("dbo.Companies", "Name", unique: true);
            CreateIndex("dbo.Companies", "Website", unique: true);
            CreateIndex("dbo.Users", "Email", unique: true);
            AddForeignKey("dbo.Addresses", "CityId", "dbo.Cities", "Id");
            DropColumn("dbo.Addresses", "Name");
            DropColumn("dbo.Addresses", "TownId");
            DropColumn("dbo.Companies", "Email");
            DropColumn("dbo.JobOffers", "JobTypeId");
            DropColumn("dbo.JobOffers", "JobCategoryId");
            DropColumn("dbo.Users", "Username");
            DropTable("dbo.JobCategories");
            DropTable("dbo.JobTypes");
            DropTable("dbo.Towns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 125),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 125),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 125),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.JobOffers", "JobCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.JobOffers", "JobTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "Email", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Addresses", "TownId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "Name", c => c.String(nullable: false, maxLength: 256));
            DropForeignKey("dbo.Addresses", "CityId", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Companies", new[] { "Website" });
            DropIndex("dbo.Companies", new[] { "Name" });
            DropIndex("dbo.Addresses", new[] { "CityId" });
            DropIndex("dbo.Addresses", new[] { "PostalCode", "StreetName" });
            AlterColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.JobOffers", "Payment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.JobOffers", "Description", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.JobOffers", "Position", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Companies", "PhoneNumber", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Companies", "BusinessInfo", c => c.String());
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Users", "MiddleName");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.JobOffers", "JobCategory");
            DropColumn("dbo.JobOffers", "JobType");
            DropColumn("dbo.JobOffers", "Rating");
            DropColumn("dbo.Companies", "Website");
            DropColumn("dbo.Addresses", "CityId");
            DropColumn("dbo.Addresses", "PostalCode");
            DropColumn("dbo.Addresses", "StreetName");
            DropTable("dbo.Cities");
            CreateIndex("dbo.Towns", "Name", unique: true);
            CreateIndex("dbo.Users", "Username", unique: true);
            CreateIndex("dbo.JobTypes", "TypeName", unique: true);
            CreateIndex("dbo.JobCategories", "CategoryName", unique: true);
            CreateIndex("dbo.JobOffers", "JobCategoryId");
            CreateIndex("dbo.JobOffers", "JobTypeId");
            CreateIndex("dbo.Companies", "PhoneNumber", unique: true);
            CreateIndex("dbo.Companies", "Email", unique: true);
            CreateIndex("dbo.Companies", "Name", unique: true);
            CreateIndex("dbo.Addresses", "TownId");
            CreateIndex("dbo.Addresses", "Name", unique: true);
            AddForeignKey("dbo.Addresses", "TownId", "dbo.Towns", "Id");
            AddForeignKey("dbo.JobOffers", "JobTypeId", "dbo.JobTypes", "Id");
            AddForeignKey("dbo.JobOffers", "JobCategoryId", "dbo.JobCategories", "Id");
        }
    }
}
