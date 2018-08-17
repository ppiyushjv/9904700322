using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOSSWORKLOG.DATA.Models.Mapping
{
    public class tblMenuMap : EntityTypeConfiguration<tblMenu>
    {
        public tblMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.MainId)
                .HasMaxLength(3);

            this.Property(t => t.SubId)
                .HasMaxLength(3);

            this.Property(t => t.Lable)
                .HasMaxLength(50);

            this.Property(t => t.Action)
                .HasMaxLength(50);

            this.Property(t => t.Controller)
                .HasMaxLength(50);

            this.Property(t => t.Area)
                .HasMaxLength(50);

            this.Property(t => t.IconClass)
                .HasMaxLength(50);

            this.Property(t => t.UserRole)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblMenu");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MainId).HasColumnName("MainId");
            this.Property(t => t.SubId).HasColumnName("SubId");
            this.Property(t => t.Lable).HasColumnName("Lable");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.Controller).HasColumnName("Controller");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.IconClass).HasColumnName("IconClass");
            this.Property(t => t.UserRole).HasColumnName("UserRole");
            this.Property(t => t.SerialNo).HasColumnName("SerialNo");
            this.Property(t => t.IsSub).HasColumnName("IsSub");
        }
    }
}
