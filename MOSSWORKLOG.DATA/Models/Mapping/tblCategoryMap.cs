using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblCategoryMap : EntityTypeConfiguration<tblCategory>
    {
        public tblCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("tblCategory");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.CatId).HasColumnName("CatId");
        }
    }
}
