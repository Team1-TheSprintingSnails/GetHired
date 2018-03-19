namespace GetHired.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOneOrZeroFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Id", "dbo.Passwords");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Passwords");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Passwords", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Passwords", "Id");
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
            DropPrimaryKey("dbo.Passwords");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Passwords", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Passwords", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Id", "dbo.Passwords", "Id");
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id");
        }
    }
}
