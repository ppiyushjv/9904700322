using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblWorkLogMap : EntityTypeConfiguration<tblWorkLog>
    {
        public tblWorkLogMap()
        {
            // Primary Key
            this.HasKey(t => t.WorkLogId);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblWorkLog");
            this.Property(t => t.WorkLogId).HasColumnName("WorkLogId");
            this.Property(t => t.TaskId).HasColumnName("TaskId");
            this.Property(t => t.CreatedById).HasColumnName("CreatedById");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.AverageTime).HasColumnName("AverageTime");
            this.Property(t => t.SupApproval).HasColumnName("SupApproval");
            this.Property(t => t.SupReviewBy).HasColumnName("SupReviewBy");
            this.Property(t => t.SupRemark).HasColumnName("SupRemark");
            this.Property(t => t.SupSatisfaction).HasColumnName("SupSatisfaction");
            this.Property(t => t.ManApproval).HasColumnName("ManApproval");
            this.Property(t => t.ManReviewBy).HasColumnName("ManReviewBy");
            this.Property(t => t.ManRemark).HasColumnName("ManRemark");
            this.Property(t => t.ManSatisfaction).HasColumnName("ManSatisfaction");
            this.Property(t => t.ClientApproval).HasColumnName("ClientApproval");
            this.Property(t => t.ClientReviewBy).HasColumnName("ClientReviewBy");
            this.Property(t => t.ClientRemark).HasColumnName("ClientRemark");
            this.Property(t => t.ClientSatisfaction).HasColumnName("ClientSatisfaction");
        }
    }
}
