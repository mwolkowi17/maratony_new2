namespace Maratony.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class C : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Biegaczs",
                c => new
                    {
                        BiegaczID = c.Long(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Czas = c.Time(nullable: false, precision: 7),
                        ZawodyID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.BiegaczID)
                .ForeignKey("dbo.Zawodies", t => t.ZawodyID, cascadeDelete: true)
                .Index(t => t.ZawodyID);
            
            CreateTable(
                "dbo.Zawodies",
                c => new
                    {
                        ZawodyID = c.Long(nullable: false, identity: true),
                        Miejsce = c.String(),
                        Data = c.DateTime(nullable: false),
                        Dystans = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ZawodyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Biegaczs", "ZawodyID", "dbo.Zawodies");
            DropIndex("dbo.Biegaczs", new[] { "ZawodyID" });
            DropTable("dbo.Zawodies");
            DropTable("dbo.Biegaczs");
        }
    }
}
