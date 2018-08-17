using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MOSSWORKLOG.DATA.Models.Mapping;

namespace MOSSWORKLOG.DATA
{
    public partial class MossWorkLogDbEntities : DbContext
    {
        static MossWorkLogDbEntities()
        {
            Database.SetInitializer<MossWorkLogDbEntities>(new CreateDatabaseIfNotExists<MossWorkLogDbEntities>());
        }

        public MossWorkLogDbEntities()
            : base("Name=MossWorkLogDbEntities")
        {

        }

        public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }
        public DbSet<tblCategory> tblCategories { get; set; }
        public DbSet<tblClient> tblClients { get; set; }
        public DbSet<tblDocument> tblDocuments { get; set; }
        public DbSet<tblMenu> tblMenus { get; set; }
        public DbSet<tblProject> tblProjects { get; set; }
        public DbSet<tblRole> tblRoles { get; set; }
        public DbSet<tblTask> tblTasks { get; set; }
        public DbSet<tblTaskTick> tblTaskTicks { get; set; }
        public DbSet<tblUserLog> tblUserLogs { get; set; }
        public DbSet<tblUserRoleAssign> tblUserRoleAssigns { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }
        public DbSet<tblWorkLog> tblWorkLogs { get; set; }

        public DbSet<tblDocumentKeyWord> tblDocumentKeyWords { get; set; }
        public DbSet<tblDocumentKeyWordMap> tblDocumentKeyWordMaps { get; set; }

        public DbSet<ChangeManagementDetail> ChangeManagementDetails { get; set; }
        public DbSet<ChangeManagementType> ChangeManagementTypes { get; set; }
        public DbSet<ChangeManagementSubType> ChangeManagementSubTypes { get; set; }

        public DbSet<ChangeManagementComment> ChangeManagementComments { get; set; }

        public DbSet<ChangeManagementAttachment> ChangeManagementAttachments { get; set; }

        public DbSet<tblTraining> tblTrainings { get; set; }

        public DbSet<CCTVLog> CCTVLogs { get; set; }

        public DbSet<tblVender> tblVender { get; set; }

        public DbSet<tblContract> tblContracts { get; set; }

        public DbSet<ComplianceCategory> ComplianceCategorys { get; set; }

        public DbSet<Compliance> Compliances { get; set; }

        public DbSet<ComplianceTask> ComplianceTasks { get; set; }

        public DbSet<TrakMeUser> TrakMeUsers { get; set; }

        public DbSet<TrakMeCountry> TrakMeCountrys { get; set; }

        public DbSet<TrakMeRequest> TrackMeRequests { get; set; }

        public DbSet<TrakMeCity> TrakMeCities { get; set; }

        public DbSet<TrakMeUserLog> TrakMeUserLogs { get; set; }

        public DbSet<TrakMeEvent> TrakMeEventes { get; set; }

        public DbSet<TrakMeEventSubType> TrakMeEventSubTypes { get; set; }

        public DbSet<TrakMeEventViewer> TrakMeEventViewers { get; set; }

        public DbSet<TrakMeEventParticipate> TrakMeEventParticipates { get; set; }

        public DbSet<TrakMeRoute> TrakMeRoutes { get; set; }

        public DbSet<TrakMeRouteLocation> TrakMeRouteLocations { get; set; }

        public DbSet<TrakMeSettings> TrakMeSettings { get; set; }

        public DbSet<TrakMeMessage> TrakMeMessages { get; set; }

        public DbSet<TrakMeUserRouteNotificaion> TrakMeUserRouteNotificaions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PasswordResetRequestMap());
            modelBuilder.Configurations.Add(new tblCategoryMap());
            modelBuilder.Configurations.Add(new tblClientMap());
            modelBuilder.Configurations.Add(new tblDocumentMap());
            modelBuilder.Configurations.Add(new tblMenuMap());
            modelBuilder.Configurations.Add(new tblProjectMap());
            modelBuilder.Configurations.Add(new tblRoleMap());
            modelBuilder.Configurations.Add(new tblTaskMap());
            modelBuilder.Configurations.Add(new tblTaskTickMap());
            modelBuilder.Configurations.Add(new tblUserLogMap());
            modelBuilder.Configurations.Add(new tblUserRoleAssignMap());
            modelBuilder.Configurations.Add(new tblUserMap());
            modelBuilder.Configurations.Add(new tblWorkLogMap());
        }
    }
}