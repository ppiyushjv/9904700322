using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblTaskMap : EntityTypeConfiguration<tblTask>
    {
        public tblTaskMap()
        {
            // Primary Key
            this.HasKey(t => t.TaskId);

            // Properties
            this.Property(t => t.TaskName)
                .HasMaxLength(100);

            this.Property(t => t.TaskFrequency)
                .HasMaxLength(10);

            this.Property(t => t.TaskTick)
                .HasMaxLength(10);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblTask");
            this.Property(t => t.TaskId).HasColumnName("TaskId");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.TaskName).HasColumnName("TaskName");
            this.Property(t => t.TaskDescription).HasColumnName("TaskDescription");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.TaskFrequency).HasColumnName("TaskFrequency");
            this.Property(t => t.TaskTick).HasColumnName("TaskTick");
            this.Property(t => t.TaskStartDate).HasColumnName("TaskStartDate");
            this.Property(t => t.TaskEndDate).HasColumnName("TaskEndDate");
            this.Property(t => t.Email).HasColumnName("Email");
        }
    }
}
