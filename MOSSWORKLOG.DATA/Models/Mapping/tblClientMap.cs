using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblClientMap : EntityTypeConfiguration<tblClient>
    {
        public tblClientMap()
        {
            // Primary Key
            this.HasKey(t => t.ClientId);

            // Properties
            this.Property(t => t.ShortName)
                .HasMaxLength(10);

            this.Property(t => t.ClientName)
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .HasMaxLength(1000);

            this.Property(t => t.Contact)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblClient");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.ClientName).HasColumnName("ClientName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Contact).HasColumnName("Contact");
        }
    }
}
