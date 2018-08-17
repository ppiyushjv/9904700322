namespace MOSSWORKLOG.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13062018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrakMeEventParticipates", "IsAccept", c => c.String());
            CreateIndex("dbo.TrakMeUserRouteNotificaions", "UserId");
            CreateIndex("dbo.TrakMeUserRouteNotificaions", "EventId");
            CreateIndex("dbo.TrakMeUserRouteNotificaions", "RouteLocationId");
            AddForeignKey("dbo.TrakMeUserRouteNotificaions", "RouteLocationId", "dbo.TrakMeRouteLocations", "RouteLocationId", cascadeDelete: true);
            AddForeignKey("dbo.TrakMeUserRouteNotificaions", "EventId", "dbo.TrakMeEvents", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.TrakMeUserRouteNotificaions", "UserId", "dbo.TrakMeUsers", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrakMeUserRouteNotificaions", "UserId", "dbo.TrakMeUsers");
            DropForeignKey("dbo.TrakMeUserRouteNotificaions", "EventId", "dbo.TrakMeEvents");
            DropForeignKey("dbo.TrakMeUserRouteNotificaions", "RouteLocationId", "dbo.TrakMeRouteLocations");
            DropIndex("dbo.TrakMeUserRouteNotificaions", new[] { "RouteLocationId" });
            DropIndex("dbo.TrakMeUserRouteNotificaions", new[] { "EventId" });
            DropIndex("dbo.TrakMeUserRouteNotificaions", new[] { "UserId" });
            DropColumn("dbo.TrakMeEventParticipates", "IsAccept");
        }
    }
}
