namespace SimpleSevenWonders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "RegTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "RegTime");
        }
    }
}
