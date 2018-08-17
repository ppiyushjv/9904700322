using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblTaskTickMap : EntityTypeConfiguration<tblTaskTick>
    {
        public tblTaskTickMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TaskTick)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("tblTaskTick");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TaskId).HasColumnName("TaskId");
            this.Property(t => t.TaskTick).HasColumnName("TaskTick");
        }
    }
}
