namespace TrakME.DATA
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeRequest
    {
        public int Id { get; set; }

        public string RequestId { get; set; }

        public int? RequestedUserId { get; set; }

        public string RequestedUserEmaiId { get; set; }

        public RequestTypeEnum Type { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
