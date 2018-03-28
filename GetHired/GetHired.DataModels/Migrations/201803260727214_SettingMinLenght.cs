namespace GetHired.DataModels.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SettingMinLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "MiddleName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "MiddleName", c => c.String());
        }
    }
}
