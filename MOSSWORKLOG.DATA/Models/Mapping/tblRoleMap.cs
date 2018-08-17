using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblRoleMap : EntityTypeConfiguration<tblRole>
    {
        public tblRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);

            // Properties
            this.Property(t => t.RoleDesc)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblRole");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.RoleDesc).HasColumnName("RoleDesc");
        }
    }
}
