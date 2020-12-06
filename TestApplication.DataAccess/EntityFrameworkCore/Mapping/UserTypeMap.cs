using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.Mapping
{
    public class UserTypeMap : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.Property(e => e.UserTypeId).HasColumnName("userTypeId");

            builder.Property(e => e.UserTypeDescription)
                .IsRequired()
                .HasColumnName("userTypeDescription")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.UserTypeName)
                .IsRequired()
                .HasColumnName("userTypeName")
                .HasMaxLength(50)
                .IsUnicode(false);

            // builder.HasMany(x => x.user).WithOne(x => x.userType).HasForeignKey(x => x.userId);

        }
    }
}
