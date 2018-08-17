using MOSSWORKLOG.DATA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeEvent
    {
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
        public virtual TrakMeEventSubType SubType { get; set; }

        public virtual ICollection<TrakMeEventParticipate> EventParticipate { get; set; }
        public virtual ICollection<TrakMeEventViewer> EventViewer { get; set; }
        
    }
}