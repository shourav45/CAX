namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cnupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CNInfoes", "Size", c => c.String());
            AddColumn("dbo.CNInfoes", "KPNumber", c => c.String());
            DropColumn("dbo.CNInfoes", "Ex2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CNInfoes", "Ex2", c => c.String());
            DropColumn("dbo.CNInfoes", "KPNumber");
            DropColumn("dbo.CNInfoes", "Size");
        }
    }
}
