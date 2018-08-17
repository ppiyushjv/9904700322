using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblProjectMap : EntityTypeConfiguration<tblProject>
    {
        public tblProjectMap()
        {
            // Primary Key
            this.HasKey(t => t.ProjectId);

            // Properties
            this.Property(t => t.ProjectName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblProject");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Email).HasColumnName("Email");
        }
    }
}
