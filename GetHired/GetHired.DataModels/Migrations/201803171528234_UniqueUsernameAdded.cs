namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueUsernameAdded : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.ContactInfoes", "Email", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.ContactInfoes", "PhoneNumber", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            CreateIndex("dbo.ContactInfoes", "Email", unique: true);
            CreateIndex("dbo.ContactInfoes", "PhoneNumber", unique: true);
            CreateIndex("dbo.Users", "Username", unique: true);
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String(maxLength: 8000, unicode: false));
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.ContactInfoes", new[] { "PhoneNumber" });
            DropIndex("dbo.ContactInfoes", new[] { "Email" });
            AlterColumn("dbo.ContactInfoes", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.ContactInfoes", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Username");
            CreateIndex("dbo.Users", "Email", unique: true);
        }
    }
}
