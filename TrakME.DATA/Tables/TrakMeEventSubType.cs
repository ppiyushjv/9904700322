namespace TrakME.DATA
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeEventSubType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrakMeEventSubType()
        {
            TrakMeEvents = new HashSet<TrakMeEvent>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public int RefreshRate { get; set; }

        public EventTypeEnum Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeEvent> TrakMeEvents { get; set; }
    }
}
