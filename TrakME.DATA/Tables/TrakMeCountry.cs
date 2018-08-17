namespace TrakME.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeCountry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrakMeCountry()
        {
            TrakMeUsers = new HashSet<TrakMeUser>();
        }

        [Key]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string ISDCode { get; set; }

        public string ShortCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeUser> TrakMeUsers { get; set; }
    }
}
