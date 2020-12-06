using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.Mapping
{
    public class UserUserTypeMap : IEntityTypeConfiguration<UserUserType>
    {
        public void Configure(EntityTypeBuilder<UserUserType> builder)
        {
            
            
            builder.HasKey(x => new { x.UserId, x.UserTypeId });

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.UserTypeId).IsRequired();

            builder.HasOne(x => x.user).WithMany(x => x.userUserTypes).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.userType).WithMany(x => x.userUserTypes).HasForeignKey(x => x.UserTypeId);
                   
            builder.Property(e => e.UserId).HasColumnName("UserId");

            builder.Property(e => e.UserTypeId).HasColumnName("UserTypeId");
        }
    }
}
