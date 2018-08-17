namespace TrakME.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeEventParticipate
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public int UserId { get; set; }

        public string Message { get; set; }

        public bool IsTrackable { get; set; }

        public bool IsAlert { get; set; }

        public bool IsAdmin { get; set; }

        public string IsAccept { get; set; }

        [ForeignKey("EventId")]
        public virtual TrakMeEvent TrakMeEvent { get; set; }

        [ForeignKey("UserId")]
        public virtual TrakMeUser TrakMeUser { get; set; }
    }
}
