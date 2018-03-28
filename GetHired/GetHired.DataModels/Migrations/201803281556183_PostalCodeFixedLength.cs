namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostalCodeFixedLength : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Addresses", new[] { "PostalCode", "StreetName" });
            AlterColumn("dbo.Addresses", "PostalCode", c => c.String(nullable: false, maxLength: 4, fixedLength: true));
            CreateIndex("dbo.Addresses", new[] { "PostalCode", "StreetName" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Addresses", new[] { "PostalCode", "StreetName" });
            AlterColumn("dbo.Addresses", "PostalCode", c => c.String(nullable: false, maxLength: 4, unicode: false));
            CreateIndex("dbo.Addresses", new[] { "PostalCode", "StreetName" }, unique: true);
        }
    }
}
