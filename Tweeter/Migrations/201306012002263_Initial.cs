namespace Tweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 140),
                        CreatedAt = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Avatar = c.String(),
                        About = c.String(),
                        Name = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tweets", new[] { "UserId" });
            DropForeignKey("dbo.Tweets", "UserId", "dbo.Users");
            DropTable("dbo.Users");
            DropTable("dbo.Tweets");
        }
    }
}
