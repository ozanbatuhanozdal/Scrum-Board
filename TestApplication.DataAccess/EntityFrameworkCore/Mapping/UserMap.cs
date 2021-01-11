using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //userId anahtar alan
            builder.HasKey(x => x.UserId);

            //userId kolon adı USerID
            builder.Property(e => e.UserId).HasColumnName("UserId");
         
            //email alanaı boş geçilemez.
            //kolon adı eMail
            //maksimum uzunluk 50
            
            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("eMail")
                .HasMaxLength(50)
                .IsUnicode(false);

            //password alanı boş geçilemez.
            //kolon adı password
            //maksimum uzunluk 200         


            //Name alanı boş geçilemez
            //kolon adı Name
            //maksimum uzunluk 200
            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(200)
                .IsUnicode(false);

         
                


        }
    }
}
