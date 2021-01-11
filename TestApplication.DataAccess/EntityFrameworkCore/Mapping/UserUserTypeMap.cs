using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.Mapping
{
    public class UserUserTypeMap : IEntityTypeConfiguration<UserUserType>
    {
        public void Configure(EntityTypeBuilder<UserUserType> builder)
        {
            
            //userId,UserTypeId anahtar alan
            builder.HasKey(x => x.UserUserTypeId);

            builder.Property(x => x.UserUserTypeId).ValueGeneratedOnAdd();
            //userId boş geçilemez.
            builder.Property(x => x.UserId).IsRequired();
            //usertype boş geçilemez.
            builder.Property(x => x.UserTypeId).IsRequired();
            //bir kullanıcının birden fazla usertypeı olabilir.
            builder.HasOne(x => x.user).WithMany(x => x.userUserTypes).HasForeignKey(x => x.UserId);
            
            
            builder.HasOne(x => x.userType).WithMany(x => x.userUserTypes).HasForeignKey(x => x.UserTypeId);
                   
            //kolon adı değiştirildi
            builder.Property(e => e.UserId).HasColumnName("UserId");

            //kolon adı değiştirildi
            builder.Property(e => e.UserTypeId).HasColumnName("UserTypeId");
        }
    }
}
