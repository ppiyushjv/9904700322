namespace TrakME.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeRoute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrakMeRoute()
        {
            TrakMeRouteLocations = new HashSet<TrakMeRouteLocation>();
        }

        [Key]
        public int RouteId { get; set; }

        public int EventId { get; set; }

        public string RouteSortName { get; set; }

        public string Description { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public bool IsActive { get; set; }

        public string days { get; set; }

        [ForeignKey("EventId")]
        public virtual TrakMeEvent TrakMeEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeRouteLocation> TrakMeRouteLocations { get; set; }
    }
}
