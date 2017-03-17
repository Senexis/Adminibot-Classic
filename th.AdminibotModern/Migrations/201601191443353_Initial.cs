namespace th.AdminibotModern.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        CommandId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Response = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommandId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Level = c.Int(nullable: false),
                        Desciption = c.String(),
                        Origin = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Points = c.Int(nullable: false),
                        IsRegular = c.Boolean(nullable: false),
                        IsSubscriber = c.Boolean(nullable: false),
                        Tag = c.String(),
                        Level = c.Int(nullable: false),
                        WatchTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "User_UserId", "dbo.Users");
            DropIndex("dbo.Events", new[] { "User_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Events");
            DropTable("dbo.Commands");
        }
    }
}
