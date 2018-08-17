namespace TrakME.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeRouteLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrakMeRouteLocation()
        {
            TrakMeUserRouteNotificaions = new HashSet<TrakMeUserRouteNotificaion>();
        }

        [Key]
        public int RouteLocationId { get; set; }

        public int RouteId { get; set; }

        public int SequenceNo { get; set; }

        public string LocationMessage { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string ScheduleTime { get; set; }

        public int TravelTime { get; set; }

        public int HoldTime { get; set; }

        [ForeignKey("RouteId")]
        public virtual TrakMeRoute TrakMeRoute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeUserRouteNotificaion> TrakMeUserRouteNotificaions { get; set; }
    }
}
