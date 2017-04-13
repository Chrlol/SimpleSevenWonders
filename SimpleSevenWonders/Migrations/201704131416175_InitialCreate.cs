namespace SimpleSevenWonders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Player_Id = c.Int(),
                        PlayerPoints_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .ForeignKey("dbo.PlayerPoints", t => t.PlayerPoints_Id)
                .Index(t => t.Player_Id)
                .Index(t => t.PlayerPoints_Id);
            
            CreateTable(
                "dbo.PlayerPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RedPoints = c.Int(nullable: false),
                        CoinPoints = c.Int(nullable: false),
                        WonderPoints = c.Int(nullable: false),
                        BluePoints = c.Int(nullable: false),
                        OrangePoints = c.Int(nullable: false),
                        PurplePoints = c.Int(nullable: false),
                        GreenPoints = c.Int(nullable: false),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PlayerPoints_Id", "dbo.PlayerPoints");
            DropForeignKey("dbo.PlayerPoints", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Games", "Player_Id", "dbo.Players");
            DropIndex("dbo.PlayerPoints", new[] { "Player_Id" });
            DropIndex("dbo.Games", new[] { "PlayerPoints_Id" });
            DropIndex("dbo.Games", new[] { "Player_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.PlayerPoints");
            DropTable("dbo.Games");
        }
    }
}
