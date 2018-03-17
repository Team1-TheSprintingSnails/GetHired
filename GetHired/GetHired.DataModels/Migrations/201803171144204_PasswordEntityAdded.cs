using System.Data.Entity.Migrations;

namespace GetHired.DataModels.Migrations
{
    public partial class PasswordEntityAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasswordHash = c.String(),
                        PasswordSalt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Id", "dbo.Passwords", "Id");
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Id", "dbo.Passwords");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Passwords");
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.JobTypeUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserJobCategories", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
