namespace TrakME.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeUserRouteNotificaion
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual TrakMeUser User { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual TrakMeEvent Event { get; set; }


        public int RouteLocationId { get; set; }

        [ForeignKey("RouteLocationId")]
        public virtual TrakMeRouteLocation RouteLocation { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
