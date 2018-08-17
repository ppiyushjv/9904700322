using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeRoute
    {
        [Key]
        public int RouteId { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual TrakMeEvent Event { get; set; }

        public string RouteSortName { get; set; }
        public string Description { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public bool IsActive { get; set; }

        public string days { get; set; }

    }

    public partial class TrakMeRouteLocation
    {
        [Key]
        public int RouteLocationId { get; set; }
        public int RouteId { get; set; }

        [ForeignKey("RouteId")]
        public virtual TrakMeRoute Route { get; set; }
        public int SequenceNo { get; set; }
        public string LocationMessage { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ScheduleTime { get; set; }
        public int TravelTime { get; set; }
        public int HoldTime { get; set; }
    }
}