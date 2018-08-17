namespace TrakMe.CLASSIFIED.DATA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TrakMEClassified : DbContext
    {
        public TrakMEClassified()
            : base("name=TrakMEClassifiedEntities")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
