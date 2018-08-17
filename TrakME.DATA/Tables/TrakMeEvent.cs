namespace TrakME.DATA
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrakMeEvent()
        {
            TrakMeEventParticipates = new HashSet<TrakMeEventParticipate>();
            TrakMeEventViewers = new HashSet<TrakMeEventViewer>();
            TrakMeRoutes = new HashSet<TrakMeRoute>();
            TrakMeUserRouteNotificaions = new HashSet<TrakMeUserRouteNotificaion>();
        }

        [Key]
        public int EventId { get; set; }

        public int UserId { get; set; }

        public string ShortName { get; set; }

        public string ImageData { get; set; }

        public string EventMessage { get; set; }

        public EventTypeEnum EventType { get; set; }
        public EventStatEnum EventState { get; set; }
        public EventPublicPrivateEnum IsPublic { get; set; }
        public EventTemporaryPermanentEnum IsPermanent { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int EventSubType { get; set; }

        public int? SubType_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeEventParticipate> TrakMeEventParticipates { get; set; }

        [ForeignKey("EventSubType")]
        public virtual TrakMeEventSubType TrakMeEventSubType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeEventViewer> TrakMeEventViewers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeRoute> TrakMeRoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeUserRouteNotificaion> TrakMeUserRouteNotificaions { get; set; }
    }
}
