using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblUserRoleAssignMap : EntityTypeConfiguration<tblUserRoleAssign>
    {
        public tblUserRoleAssignMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblUserRoleAssign");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AssignUserId).HasColumnName("UserId");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.TaskId).HasColumnName("TaskId");
        }
    }
}
