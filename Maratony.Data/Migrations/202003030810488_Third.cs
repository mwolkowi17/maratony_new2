namespace Maratony.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Biegaczs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Czas = c.Time(nullable: false, precision: 7),
                        Bieg = c.Long(nullable: false),
                        Zawody_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Zawodies", t => t.Zawody_ID)
                .Index(t => t.Zawody_ID);
            
            CreateTable(
                "dbo.Zawodies",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Miejsce = c.String(),
                        Data = c.DateTime(nullable: false),
                        Dystans = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Biegaczs", "Zawody_ID", "dbo.Zawodies");
            DropIndex("dbo.Biegaczs", new[] { "Zawody_ID" });
            DropTable("dbo.Zawodies");
            DropTable("dbo.Biegaczs");
        }
    }
}
