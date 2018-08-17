namespace TrakME.DATA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TrakMEEntities : DbContext
    {
        public TrakMEEntities()
            : base("name=TrakMEEntities")
        {
        }

        public virtual DbSet<TrakMeCity> TrakMeCities { get; set; }
        public virtual DbSet<TrakMeCountry> TrakMeCountries { get; set; }
        public virtual DbSet<TrakMeEventParticipate> TrakMeEventParticipates { get; set; }
        public virtual DbSet<TrakMeEvent> TrakMeEvents { get; set; }
        public virtual DbSet<TrakMeEventSubType> TrakMeEventSubTypes { get; set; }
        public virtual DbSet<TrakMeEventViewer> TrakMeEventViewers { get; set; }
        public virtual DbSet<TrakMeMessage> TrakMeMessages { get; set; }
        public virtual DbSet<TrakMeRequest> TrakMeRequests { get; set; }
        public virtual DbSet<TrakMeRouteLocation> TrakMeRouteLocations { get; set; }
        public virtual DbSet<TrakMeRoute> TrakMeRoutes { get; set; }
        public virtual DbSet<TrakMeSetting> TrakMeSettings { get; set; }
        public virtual DbSet<TrakMeUserLog> TrakMeUserLogs { get; set; }
        public virtual DbSet<TrakMeUserRouteNotificaion> TrakMeUserRouteNotificaions { get; set; }
        public virtual DbSet<TrakMeUser> TrakMeUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrakMeCity>()
                .HasMany(e => e.TrakMeUsers)
                .WithRequired(e => e.TrakMeCity)
                .HasForeignKey(e => e.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrakMeCountry>()
                .HasMany(e => e.TrakMeUsers)
                .WithRequired(e => e.TrakMeCountry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrakMeEvent>()
                .HasMany(e => e.TrakMeEventViewers)
                .WithRequired(e => e.TrakMeEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrakMeEvent>()
                .HasMany(e => e.TrakMeRoutes)
                .WithRequired(e => e.TrakMeEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrakMeEventSubType>()
                .HasMany(e => e.TrakMeEvents)
                .WithOptional(e => e.TrakMeEventSubType)
                .HasForeignKey(e => e.SubType_Id);

            modelBuilder.Entity<TrakMeRoute>()
                .HasMany(e => e.TrakMeRouteLocations)
                .WithRequired(e => e.TrakMeRoute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrakMeUser>()
                .HasMany(e => e.TrakMeEventViewers)
                .WithRequired(e => e.TrakMeUser)
                .WillCascadeOnDelete(false);
        }
    }
}
