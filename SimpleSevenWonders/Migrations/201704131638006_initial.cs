namespace SimpleSevenWonders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .Index(t => t.Player_Id)
                .Index(t => t.Game_Id);
            
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
            DropForeignKey("dbo.PlayerPoints", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.PlayerPoints", "Player_Id", "dbo.Players");
            DropIndex("dbo.PlayerPoints", new[] { "Game_Id" });
            DropIndex("dbo.PlayerPoints", new[] { "Player_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.PlayerPoints");
            DropTable("dbo.Games");
        }
    }
}
