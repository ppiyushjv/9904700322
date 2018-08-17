using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblDocumentMap : EntityTypeConfiguration<tblDocument>
    {
        public tblDocumentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DocumentPath)
                .HasMaxLength(50);

            this.Property(t => t.Descriptions)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblDocuments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.SubCategoryId).HasColumnName("SubCategoryId");
            this.Property(t => t.DocumentPath).HasColumnName("DocumentPath");
            this.Property(t => t.Descriptions).HasColumnName("Descriptions");
        }
    }
}
