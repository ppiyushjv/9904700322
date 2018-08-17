namespace TrakME.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeMessage
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }

        public string Message { get; set; }

        public DateTime TimeSpan { get; set; }
    }
}
