using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class PasswordResetRequestMap : EntityTypeConfiguration<PasswordResetRequest>
    {
        public PasswordResetRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("PasswordResetRequests");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RequestId).HasColumnName("RequestId");
            this.Property(t => t.RequestedUserId).HasColumnName("UserId");
            this.Property(t => t.Timestamp).HasColumnName("Timestamp");
        }
    }
}
