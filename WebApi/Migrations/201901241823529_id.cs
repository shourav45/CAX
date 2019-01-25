namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "Mobile1", c => c.String());
            AddPrimaryKey("dbo.UserInfoes", "UserInfoId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "Mobile1", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserInfoes", "Mobile1");
        }
    }
}
