using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblUserMap : EntityTypeConfiguration<tblUser>
    {
        public tblUserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.FullName)
                .HasMaxLength(100);

            this.Property(t => t.Mobile)
                .HasMaxLength(20);

            this.Property(t => t.email)
                .HasMaxLength(100);

            this.Property(t => t.Password)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblUsers");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
        }
    }
}
