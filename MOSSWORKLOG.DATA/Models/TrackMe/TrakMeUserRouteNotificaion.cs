using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeUserRouteNotificaion
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual TrakMeUser user { get; set; }

        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public virtual TrakMeEvent trackEvent { get; set; }

        public int RouteLocationId { get; set; }
        [ForeignKey("RouteLocationId")]
        public virtual TrakMeRouteLocation location { get; set; }

        public DateTime Timestamp { get; set; }
    }
}