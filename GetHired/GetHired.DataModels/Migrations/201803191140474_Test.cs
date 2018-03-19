namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Passwords", "Id");
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Passwords", "Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passwords", "Id", "dbo.Users");
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropIndex("dbo.Passwords", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id");
        }
    }
}
