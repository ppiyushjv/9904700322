namespace MOSSWORKLOG.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12062018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrakMeUserRouteNotificaions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        RouteLocationId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrakMeUserRouteNotificaions");
        }
    }
}
