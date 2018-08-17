namespace TrakME.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrakMeUser()
        {
            TrakMeEventParticipates = new HashSet<TrakMeEventParticipate>();
            TrakMeEventViewers = new HashSet<TrakMeEventViewer>();
            TrakMeUserRouteNotificaions = new HashSet<TrakMeUserRouteNotificaion>();
        }

        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public string BirthYear { get; set; }

        public string Gender { get; set; }

        public string Occupation { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string State { get; set; }

        public string StateCode { get; set; }

        public string ZipCode { get; set; }

        public bool IsVerified { get; set; }

        public bool IsPaid { get; set; }

        public int OccupationId { get; set; }

        [ForeignKey("OccupationId")]
        public virtual TrakMeEventSubType TrakMeEventSubType { get; set; }

        public string ProfileImage { get; set; }

        public string AccessCode { get; set; }
        [ForeignKey("CityId")]
        public virtual TrakMeCity TrakMeCity { get; set; }
        [ForeignKey("CountryId")]
        public virtual TrakMeCountry TrakMeCountry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeEventParticipate> TrakMeEventParticipates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeEventViewer> TrakMeEventViewers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrakMeUserRouteNotificaion> TrakMeUserRouteNotificaions { get; set; }
    }
}
