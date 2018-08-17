namespace TrakME.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeCity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrakMeCity()
        {
            TrakMeUsers = new HashSet<TrakMeUser>();
        }

        public int Id { get; set; }

        public string CoutryCode { get; set; }

        public string CountryName { get; set; }

        public string StateCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string TimeZone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeUser> TrakMeUsers { get; set; }
    }
}
