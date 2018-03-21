namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactInfoes", "Id", "dbo.Companies");
            DropIndex("dbo.ContactInfoes", new[] { "Id" });
            DropIndex("dbo.ContactInfoes", new[] { "Email" });
            DropIndex("dbo.ContactInfoes", new[] { "PhoneNumber" });
            AddColumn("dbo.Companies", "Email", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AddColumn("dbo.Companies", "PhoneNumber", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AddColumn("dbo.Users", "DataOfBirth", c => c.DateTime());
            CreateIndex("dbo.Companies", "Email", unique: true);
            CreateIndex("dbo.Companies", "PhoneNumber", unique: true);
            DropTable("dbo.ContactInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Companies", new[] { "PhoneNumber" });
            DropIndex("dbo.Companies", new[] { "Email" });
            DropColumn("dbo.Users", "DataOfBirth");
            DropColumn("dbo.Companies", "PhoneNumber");
            DropColumn("dbo.Companies", "Email");
            CreateIndex("dbo.ContactInfoes", "PhoneNumber", unique: true);
            CreateIndex("dbo.ContactInfoes", "Email", unique: true);
            CreateIndex("dbo.ContactInfoes", "Id");
            AddForeignKey("dbo.ContactInfoes", "Id", "dbo.Companies", "Id");
        }
    }
}
