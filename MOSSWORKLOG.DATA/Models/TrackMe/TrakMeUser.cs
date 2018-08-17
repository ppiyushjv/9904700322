using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeUser
    {
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
        public virtual TrakMeCountry Country { get; set; }
        public int CityId { get; set; }
        public virtual TrakMeCity City { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public bool IsVerified { get; set; }
        public bool IsPaid { get; set; }
        public string AccessCode { get; set; }
    }
}