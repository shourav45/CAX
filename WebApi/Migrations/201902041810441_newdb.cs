namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CNInfoes",
                c => new
                    {
                        CNInfoId = c.Int(nullable: false, identity: true),
                        CNType = c.String(nullable: false),
                        DeliveryStatus = c.String(),
                        Status = c.String(),
                        PolySize = c.String(),
                        CNDate = c.DateTime(nullable: false),
                        ServiceType = c.String(nullable: false),
                        PartyId = c.String(nullable: false),
                        Destination = c.String(nullable: false),
                        Follio = c.String(),
                        ConsingeeName = c.String(nullable: false),
                        ConsigneeAddress = c.String(),
                        ItemInfo = c.String(),
                        Kgpiece = c.String(nullable: false),
                        RateType = c.String(),
                        Weight = c.String(),
                        ServiceCharge = c.String(),
                        VatStatus = c.String(),
                        VatPercent = c.String(),
                        VatAmount = c.String(),
                        AitStatus = c.String(),
                        AitPercent = c.String(),
                        AitAmount = c.String(),
                        TotalAmount = c.String(nullable: false),
                        Size = c.String(),
                        KPNumber = c.String(),
                        Ex1 = c.String(),
                        AddDate = c.String(),
                        AddBy = c.String(),
                        AddIp = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.CNInfoId);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        DestinationId = c.Int(nullable: false, identity: true),
                        District = c.String(nullable: false),
                        Area = c.String(),
                        AddBy = c.String(),
                        AddDate = c.String(),
                        Status = c.String(),
                        Ex1 = c.String(),
                    })
                .PrimaryKey(t => t.DestinationId);
            
            CreateTable(
                "dbo.PartyInfoes",
                c => new
                    {
                        PartyInfoId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(nullable: false),
                        Email = c.String(),
                        SPOId = c.String(),
                        AddDate = c.String(),
                        Status = c.String(),
                        AddBy = c.String(),
                    })
                .PrimaryKey(t => t.PartyInfoId);
            
            CreateTable(
                "dbo.RateInfoes",
                c => new
                    {
                        RateInfoId = c.Int(nullable: false, identity: true),
                        PartyInfoId = c.String(),
                        RateType = c.String(nullable: false),
                        FirstKP = c.String(nullable: false),
                        FirstKPRate = c.String(nullable: false),
                        AfterFirstKPRate = c.String(nullable: false),
                        AddBy = c.String(),
                        AddDate = c.String(),
                        Ex1 = c.String(),
                        Ex2 = c.String(),
                    })
                .PrimaryKey(t => t.RateInfoId);
            
            CreateTable(
                "dbo.SPOInfoes",
                c => new
                    {
                        SPOInfoId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Designation = c.String(),
                        Mobile1 = c.String(nullable: false),
                        Mobile2 = c.String(),
                        Address = c.String(),
                        Status = c.String(),
                        Ex1 = c.String(),
                        AddDate = c.String(),
                        AddBy = c.String(),
                    })
                .PrimaryKey(t => t.SPOInfoId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserInfoId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Mobile1 = c.String(nullable: false),
                        Mobile2 = c.String(),
                        Designation = c.String(),
                        UserPassword = c.String(nullable: false),
                        UserRole = c.String(nullable: false),
                        AddBy = c.String(),
                        AddDate = c.String(),
                        Ex1 = c.String(),
                        Ex2 = c.String(),
                    })
                .PrimaryKey(t => t.UserInfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfoes");
            DropTable("dbo.SPOInfoes");
            DropTable("dbo.RateInfoes");
            DropTable("dbo.PartyInfoes");
            DropTable("dbo.Destinations");
            DropTable("dbo.CNInfoes");
        }
    }
}
