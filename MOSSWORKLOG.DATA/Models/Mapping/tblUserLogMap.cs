using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblUserLogMap : EntityTypeConfiguration<tblUserLog>
    {
        public tblUserLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblUserLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.TimeLog).HasColumnName("TimeLog");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
