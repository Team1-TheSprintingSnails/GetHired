namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressIndexChanged : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Addresses", new[] { "PostalCode", "StreetName" });
            CreateIndex("dbo.Addresses", "PostalCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Addresses", new[] { "PostalCode" });
            CreateIndex("dbo.Addresses", new[] { "PostalCode", "StreetName" }, unique: true);
        }
    }
}
