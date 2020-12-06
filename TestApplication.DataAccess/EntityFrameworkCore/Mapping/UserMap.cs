using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(e => e.UserId).HasColumnName("UserId");
         

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("eMail")
                .HasMaxLength(50)
                .IsUnicode(false);


            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasMaxLength(200)
                .IsUnicode(false);

         
                


        }
    }
}
